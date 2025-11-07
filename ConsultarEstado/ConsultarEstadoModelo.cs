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

        // Helpers directos por catálogo
        private static string NombreAgenciaPorId(string? id)
        {
            if (string.IsNullOrWhiteSpace(id)) return string.Empty;
            var ag = AgenciaAlmacen.agencias.FirstOrDefault(a => string.Equals(a.ID, id, StringComparison.OrdinalIgnoreCase));
            return ag?.Nombre ?? $"Agencia {id}";
        }
        private static string NombreCDPorCP(int cp)
        {
            var cd = CentroDeDistribucionAlmacen.centrosDeDistribucion.FirstOrDefault(c => c.CodigoPostal == cp);
            return cd?.Nombre ?? $"CD {cp}";
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
                            return NombreCDPorCP(g.CodigoPostalCDDestino);
                        case EntregaEnum.Agencia:
                            return NombreAgenciaPorId(g.IDAgenciaDestino);
                        default:
                            return null;
                    }
                default:
                    return null;
            }
        }

        // Busca DNI de fletero segun prioridad: preferido -> Transporte -> cualquiera -> por ruta
        private static int? BuscarDNIFletero(GuiaEntidad g, TipoHDREnum tipoPreferido)
        {
            var hdrs = HDRAlmacen.HDR.Where(h => h.Guias != null && h.Guias.Contains(g.NumeroGuia)).ToList();
            var prefer = hdrs.FirstOrDefault(h => h.TipoHDR == tipoPreferido)?.DNIFletero;
            if (prefer.HasValue && prefer.Value > 0) return prefer;
            var trans = hdrs.FirstOrDefault(h => h.TipoHDR == TipoHDREnum.Transporte)?.DNIFletero;
            if (trans.HasValue && trans.Value > 0) return trans;
            var cualquiera = hdrs.FirstOrDefault()?.DNIFletero;
            if (cualquiera.HasValue && cualquiera.Value > 0) return cualquiera;

            // Fallback por ruta (si no está explicitamente asignada la guía a una HDR)
            var hdrRuta = HDRAlmacen.HDR.FirstOrDefault(h =>
                h.TipoHDR == tipoPreferido &&
                (h.CodigoPostalDestino == g.CodigoPostalCDDestino || h.CodigoPostalOrigen == g.CodigoPostalCDOrigen));
            if (hdrRuta != null && hdrRuta.DNIFletero > 0) return hdrRuta.DNIFletero;

            // Como último recurso, tomar cualquier HDR por ruta
            var hdrRutaAny = HDRAlmacen.HDR.FirstOrDefault(h =>
                (h.CodigoPostalDestino == g.CodigoPostalCDDestino || h.CodigoPostalOrigen == g.CodigoPostalCDOrigen));
            return hdrRutaAny?.DNIFletero;
        }

        // Busca ID de servicio de transporte para la guía (HDR Transporte) o por ruta
        private static int? BuscarIDServicioTransporte(GuiaEntidad g)
        {
            //1) HDR de Transporte que contenga la guía y tenga servicio
            var hdr = HDRAlmacen.HDR.FirstOrDefault(h => h.Guias != null && h.Guias.Contains(g.NumeroGuia) && h.TipoHDR == TipoHDREnum.Transporte && h.IDServicioTransporte > 0);
            if (hdr != null) return hdr.IDServicioTransporte;

            //2) Coincidencia exacta de ruta (origen+destino) y servicio válido
            var hdrRuta = HDRAlmacen.HDR.FirstOrDefault(h => h.TipoHDR == TipoHDREnum.Transporte && h.CodigoPostalOrigen == g.CodigoPostalCDOrigen && h.CodigoPostalDestino == g.CodigoPostalCDDestino && h.IDServicioTransporte > 0);
            if (hdrRuta != null) return hdrRuta.IDServicioTransporte;

            //3) Mismo destino (posible tramo intermedio) con servicio válido
            var hdrMismoDestino = HDRAlmacen.HDR.FirstOrDefault(h => h.TipoHDR == TipoHDREnum.Transporte && h.CodigoPostalDestino == g.CodigoPostalCDDestino && h.IDServicioTransporte > 0);
            if (hdrMismoDestino != null) return hdrMismoDestino.IDServicioTransporte;

            //4) Último recurso: cualquier Transporte con servicio
            var cualquiera = HDRAlmacen.HDR.FirstOrDefault(h => h.TipoHDR == TipoHDREnum.Transporte && h.IDServicioTransporte > 0);
            return cualquiera?.IDServicioTransporte;
        }

        // Determina la ubicación final a mostrar para cada movimiento del historial
        private static string UbicacionDisplayParaMovimiento(RegistroEstadoAux h, GuiaEntidad g)
        {
            // Base a partir del historial (CD/Agencia normalizado)
            var baseDisplay = NormalizarUbicacionDisplay(h.UbicacionGuia);

            switch (h.Estado)
            {
                case EstadoGuiaEnum.ARetirarEnAgenciaDeOrigen:
                case EstadoGuiaEnum.EnCaminoARetirarPorAgencia:
                    return NombreAgenciaPorId(g.IDAgenciaOrigen);

                case EstadoGuiaEnum.ARetirarPorDomicilioDelCliente:
                case EstadoGuiaEnum.EnCaminoARetirarPorDomicilio:
                    return "En domicilio Cliente";

                case EstadoGuiaEnum.EnRutaACDDeOrigenDesdeAgencia:
                    {
                        var dni = BuscarDNIFletero(g, TipoHDREnum.Retiro);
                        return dni.HasValue ? $"En transporte con Fletero DNI: {dni.Value}" : "En transporte con Fletero DNI:";
                    }

                case EstadoGuiaEnum.Admitida:
                    return NombreCDPorCP(g.CodigoPostalCDOrigen);

                case EstadoGuiaEnum.EnTransitoAlCDDestino:
                    {
                        // Priorizar CD intermedio si viene en historial y NO es el CD destino final
                        var txt = h.UbicacionGuia?.Trim() ?? string.Empty;
                        if (txt.StartsWith("CD", StringComparison.OrdinalIgnoreCase))
                        {
                            var dig = new string(txt.Where(char.IsDigit).ToArray());
                            if (int.TryParse(dig, out var cp))
                            {
                                if (cp != g.CodigoPostalCDDestino)
                                {
                                    return $"En CD Intermedio: {NombreCDPorCP(cp)}";
                                }
                            }
                        }

                        // Si no hay CD intermedio, intentar Servicio Transporte (por guía o por ruta)
                        var idServ = BuscarIDServicioTransporte(g);
                        if (idServ.HasValue && idServ.Value > 0)
                            return $"En Servicio Nº {idServ.Value}";

                        // Último recurso: no dejar "No disponible" en tránsito
                        return "En Servicio Nº -";
                    }

                case EstadoGuiaEnum.EnCDDestino:
                    return NombreCDPorCP(g.CodigoPostalCDDestino);

                case EstadoGuiaEnum.EnRutaAlDomicilioDeEntrega:
                case EstadoGuiaEnum.EnRutaAlaAgenciaDestino:
                    {
                        var dni = BuscarDNIFletero(g, TipoHDREnum.Distribucion);
                        return dni.HasValue ? $"En transporte con Fletero DNI: {dni.Value}" : "En transporte con Fletero DNI:";
                    }

                case EstadoGuiaEnum.PendienteDeEntrega:
                    {
                        // Siempre forzar CD/Agencia destino según tipo de entrega
                        var fb = UbicacionFisicaSegunEstadoActual(g);
                        if (!string.IsNullOrWhiteSpace(fb)) return fb;
                        return baseDisplay;
                    }

                case EstadoGuiaEnum.Entregada:
                case EstadoGuiaEnum.Cancelada:
                case EstadoGuiaEnum.NoEntregada:
                case EstadoGuiaEnum.Facturada:
                    return "-";

                default:
                    return baseDisplay;
            }
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

            // Construir movimientos (con normalización + reglas de ubicación por estado)
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
                // Intentar aplicar reglas también al último registro si no coincide el estado
                ubicacionActual = ultimoRaw != null ? UbicacionDisplayParaMovimiento(ultimoRaw, guiaEntidad) : "No disponible";
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
