using System;
using System.Collections.Generic;
using System.Linq;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.ConsultarEstado
{
    public class ConsultarEstadoModelo
    {
        // --- Conexión con almacenes: se usa GuiaAlmacen/AgenciaAlmacen/CentroDeDistribucionAlmacen ---

        // Normaliza texto de ubicación a un nombre descriptivo
        private static string ResolverNombreUbicacion(string? ubicacion)
        {
            if (string.IsNullOrWhiteSpace(ubicacion)) return ubicacion ?? string.Empty;

            var txt = ubicacion.Trim();

            // Detectar prefijos conocidos
            bool empiezaAgencia = txt.StartsWith("Agencia", StringComparison.OrdinalIgnoreCase);
            bool empiezaCD = txt.StartsWith("CD", StringComparison.OrdinalIgnoreCase);

            // Agencia: "Agencia03000" -> buscar por ID y devolver Nombre (incluye prefijo "Agencia ...")
            if (empiezaAgencia)
            {
                var dig = new string(txt.Where(char.IsDigit).ToArray());
                if (!string.IsNullOrEmpty(dig))
                {
                    var ag = AgenciaAlmacen.agencias.FirstOrDefault(a => string.Equals(a.ID, dig, StringComparison.OrdinalIgnoreCase));
                    if (ag != null && !string.IsNullOrWhiteSpace(ag.Nombre))
                        return ag.Nombre;
                }
                return txt; // fallback
            }

            // CD: "CD3000" -> buscar por CodigoPostal y devolver Nombre (normalmente "CD ...")
            if (empiezaCD)
            {
                var dig = new string(txt.Where(char.IsDigit).ToArray());
                if (int.TryParse(dig, out var cp))
                {
                    var cd = CentroDeDistribucionAlmacen.centrosDeDistribucion.FirstOrDefault(c => c.CodigoPostal == cp);
                    if (cd != null && !string.IsNullOrWhiteSpace(cd.Nombre))
                        return cd.Nombre;
                }
                return txt; // fallback
            }

            // Otros textos libres ("Domicilio ...", etc.) -> devolver tal cual
            return txt;
        }

        // Texto presentable del estado
        private static string EstadoDisplay(EstadoGuiaEnum estado)
        {
            return estado switch
            {
                EstadoGuiaEnum.ARetirarEnAgenciaDeOrigen => "A retirar en agencia de origen",
                EstadoGuiaEnum.ARetirarPorDomicilioDelCliente => "A retirar por domicilio del cliente",
                EstadoGuiaEnum.EnCaminoARetirarPorDomicilio => "En camino a retirar por domicilio",
                EstadoGuiaEnum.EnCaminoARetirarPorAgencia => "En camino a retirar por agencia",
                EstadoGuiaEnum.EnRutaACDDeOrigenDesdeAgencia => "En ruta a CD de origen (desde agencia)",
                EstadoGuiaEnum.Admitida => "Admitida",
                EstadoGuiaEnum.EnTransitoAlCDDestino => "En tránsito al CD destino",
                EstadoGuiaEnum.EnCDDestino => "En CD destino",
                EstadoGuiaEnum.EnRutaAlDomicilioDeEntrega => "En ruta al domicilio de entrega",
                EstadoGuiaEnum.EnRutaAlaAgenciaDestino => "En ruta a la agencia destino",
                EstadoGuiaEnum.PendienteDeEntrega => "Pendiente de entrega",
                EstadoGuiaEnum.Entregada => "Entregada",
                EstadoGuiaEnum.Cancelada => "Cancelada",
                EstadoGuiaEnum.NoEntregada => "No entregada",
                EstadoGuiaEnum.Facturada => "Facturada",
                _ => InsertarEspaciosEnPascalCase(estado.ToString())
            };
        }

        private static string InsertarEspaciosEnPascalCase(string name)
        {
            if (string.IsNullOrEmpty(name)) return name;
            var sb = new System.Text.StringBuilder(name.Length * 2);
            for (int i = 0; i < name.Length; i++)
            {
                var c = name[i];
                if (i > 0 && char.IsUpper(c) && char.IsLower(name[i - 1])) sb.Append(' ');
                sb.Append(c);
            }
            return sb.ToString();
        }

        // Normalización de ubicación para mostrar
        private static string NormalizarUbicacionDisplay(string? ubicacionRaw)
        {
            var resolved = ResolverNombreUbicacion(ubicacionRaw);
            return string.IsNullOrWhiteSpace(resolved) ? "No disponible" : resolved;
        }

        // Fallback: determina ubicación física esperable para estados con lugar conocido
        private static string? UbicacionFisicaSegunEstadoActual(GuiaEntidad g)
        {
            switch (g.Estado)
            {
                case EstadoGuiaEnum.PendienteDeEntrega:
                    switch (g.TipoEntrega)
                    {
                        case EntregaEnum.CD:
                            var cd = CentroDeDistribucionAlmacen.centrosDeDistribucion
                                .FirstOrDefault(c => c.CodigoPostal == g.CodigoPostalCDDestino);
                            return cd?.Nombre ?? ($"CD{g.CodigoPostalCDDestino}");
                        case EntregaEnum.Agencia:
                            var ag = AgenciaAlmacen.agencias
                                .FirstOrDefault(a => string.Equals(a.ID, g.IDAgenciaDestino, StringComparison.OrdinalIgnoreCase));
                            return ag?.Nombre ?? ($"Agencia{g.IDAgenciaDestino}");
                        case EntregaEnum.Domicilio:
                            return "Domicilio del destinatario";
                        default:
                            return null;
                    }
                default:
                    return null;
            }
        }

        // Determina la ubicación final a mostrar para cada movimiento del historial
        private static string UbicacionDisplayParaMovimiento(RegistroEstadoAux h, GuiaEntidad g)
        {
            var baseDisplay = NormalizarUbicacionDisplay(h.UbicacionGuia);
            var estadoDisp = EstadoDisplay(h.Estado);
            if (estadoDisp == "Pendiente de entrega" && baseDisplay == "No disponible")
            {
                var fb = UbicacionFisicaSegunEstadoActual(g);
                if (!string.IsNullOrWhiteSpace(fb)) return fb;
            }
            return baseDisplay;
        }

        // --- Lógica de búsqueda ---
        public Guia? ObtenerPorNumero(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;
            if (!input.All(char.IsDigit)) return null;
            if (input.Length != 9) return null;

            var numeroGuiaBuscado = int.Parse(input);
            var guiaEntidad = GuiaAlmacen.guias.FirstOrDefault(g => g.NumeroGuia == numeroGuiaBuscado);
            if (guiaEntidad == null) return null;

            var historial = guiaEntidad.Historial ?? new List<RegistroEstadoAux>();

            // Construir movimientos (con normalización + fallback de ubicación para Pendiente de entrega)
            var movimientos = historial
                .Select(h => new Guia.Movimiento(
                    h.FechaActualizacionEstado,
                    EstadoDisplay(h.Estado),
                    UbicacionDisplayParaMovimiento(h, guiaEntidad)
                ))
                .GroupBy(m => new { m.Estado, m.Ubicacion })
                .Select(g => g.OrderBy(m => m.Fecha).Last())
                .OrderBy(m => m.Fecha)
                .ToList();

            var estadoActualDisplay = EstadoDisplay(guiaEntidad.Estado);

            // Ubicación actual: si hay un movimiento del mismo estado, usar su última ubicación
            string ubicacionActual;
            var lastMovMismoEstado = movimientos.LastOrDefault(m => m.Estado == estadoActualDisplay);
            if (lastMovMismoEstado != null)
            {
                ubicacionActual = lastMovMismoEstado.Ubicacion;
            }
            else
            {
                var ultimoRaw = historial.LastOrDefault();
                ubicacionActual = NormalizarUbicacionDisplay(ultimoRaw?.UbicacionGuia);
            }

            // Si sigue "No disponible" y es un estado con ubicación física conocida, usar fallback
            if (ubicacionActual == "No disponible")
            {
                var fbActual = UbicacionFisicaSegunEstadoActual(guiaEntidad);
                if (!string.IsNullOrWhiteSpace(fbActual)) ubicacionActual = fbActual;
            }

            var guiaParaPantalla = new Guia
            {
                Numero = guiaEntidad.NumeroGuia.ToString("D9"),
                EstadoActual = estadoActualDisplay,
                UbicacionActual = ubicacionActual,
                Historial = movimientos
            };

            return guiaParaPantalla;
        }
    }
}
