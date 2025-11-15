using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.EntregarEncomiendaEnAgencia
{
    public class EntregarEncomiendaEnAgenciaModelo
    {
        public List<Destinatario> Destinatarios { get; private set; } = new();
        public List<Guia> Guias { get; private set; } = new();

        // Estado local: números de guía entregados en esta sesión 
        private readonly HashSet<string> _guiasEntregadasLocalmente = new();

        public Destinatario? BuscarDestinatarioPorDNI(string dni)
        {
            // Tomamos el primer destinatario que matchee el DNI desde las guías cargadas en almacén
            var dest = GuiaAlmacen.guias
                .Select(g => g.Destinatario)
                .FirstOrDefault(d => d != null && d.DNI.ToString() == dni);

            if (dest is null) return null;

            var resultado = new Destinatario
            {
                DNI = dest.DNI.ToString(),
                Nombre = dest.Nombre,
                Apellido = dest.Apellido
            };

            Destinatarios = new List<Destinatario> { resultado };
            return resultado;
        }

        public List<Guia> BuscarGuiasPendientes(string dni, string agenciaActual)
        {
            // Resolver la agencia por nombre -> ID para comparar contra IDAgenciaDestino en las guías
            var agencias = File.Exists(Path.Combine("Datos", "Agencias.json"))
                ? (JsonSerializer.Deserialize<List<AgenciaEntidad>>(File.ReadAllText(Path.Combine("Datos", "Agencias.json"))) ?? new List<AgenciaEntidad>())
                : new List<AgenciaEntidad>();

            AgenciaEntidad? agencia = null;

            if (!string.IsNullOrWhiteSpace(agenciaActual))
            {
                // 1) Intentar por nombre exacto
                agencia = agencias.FirstOrDefault(a => string.Equals(a.Nombre, agenciaActual, StringComparison.OrdinalIgnoreCase));

                if (agencia == null)
                {
                    // 2) Extraer dígitos del texto del label 
                    var digits = new string((agenciaActual ?? string.Empty).Where(char.IsDigit).ToArray());

                    if (!string.IsNullOrWhiteSpace(digits))
                    {
                        // Buscar por ID exacto 
                        agencia = agencias.FirstOrDefault(a =>
                        {
                            var aIdDigits = new string((a.ID ?? string.Empty).Where(char.IsDigit).ToArray());
                            if (string.Equals(aIdDigits, digits, StringComparison.OrdinalIgnoreCase)) return true;
                            // comparar con padding a 5 dígitos (formato usado en el almacen)
                            if (aIdDigits == digits.PadLeft(5, '0')) return true;
                            return false;
                        });

                        // 3) Si sigue null, intentar buscar por CodigoPostal igual al número extraído
                        if (agencia == null && int.TryParse(digits, out var cp))
                        {
                            agencia = agencias.FirstOrDefault(a => a.CodigoPostal == cp || a.CodigoPostalCD == cp);
                        }
                    }
                }
            }

            if (agencia is null)
            {
                Guias = new List<Guia>();
                return Guias;
            }

            // Normalizador: obtiene solo dígitos del ID de agencia de la guía y del almacén para comparar sin problemas de ceros.
            static string NormalizeIdDigits(string? id) => new string((id ?? string.Empty).Where(char.IsDigit).ToArray()).TrimStart('0');

            var agenciaIdNormalized = NormalizeIdDigits(agencia.ID);

            var resultados = GuiaAlmacen.guias
                .Where(g =>
                    g.Destinatario != null &&
                    g.Destinatario.DNI.ToString() == dni &&
                    g.Estado == EstadoGuiaEnum.PendienteDeEntrega &&
                    g.TipoEntrega == EntregaEnum.Agencia &&
                    // comparar IDs normalizados (evita fallo por ceros a la izquierda)
                    string.Equals(NormalizeIdDigits(g.IDAgenciaDestino), agenciaIdNormalized, StringComparison.OrdinalIgnoreCase) &&
                    !_guiasEntregadasLocalmente.Contains(g.NumeroGuia.ToString()) // excluir entregadas en esta sesión
                )
                .Select(g => new Guia
                {
                    NumeroGuia = g.NumeroGuia.ToString(),
                    Tamanio = g.Tamano.ToString(),
                    DniDestinatario = g.Destinatario.DNI.ToString(),
                    Estado = "Pendiente de entrega",
                    Ubicacion = agencia.Nombre
                })
                .ToList();

            Guias = resultados;
            return resultados;
        }

        public bool ConfirmarEntrega(List<string> numerosDeGuia)
        {
            // Persistir cambio de estado a "Entregada" en el JSON
            if (numerosDeGuia == null || numerosDeGuia.Count == 0)
                return false;

            bool huboCambios = false;

            foreach (var numeroGuia in numerosDeGuia)
            {
                if (string.IsNullOrWhiteSpace(numeroGuia)) continue;
                if (!int.TryParse(numeroGuia, out var nroInt)) continue;

                var entidad = GuiaAlmacen.guias.FirstOrDefault(g => g.NumeroGuia == nroInt);
                if (entidad == null) continue;

                entidad.Historial ??= new List<RegistroEstadoAux>();

                if (entidad.Estado == EstadoGuiaEnum.PendienteDeEntrega)
                {
                    var fechaEntregada = DateTime.Now;
                    entidad.Estado = EstadoGuiaEnum.Entregada;
                    entidad.Historial.Add(new RegistroEstadoAux
                    {
                        Estado = EstadoGuiaEnum.Entregada,
                        UbicacionGuia = string.Empty, // Entregada: sin ubicación
                        FechaActualizacionEstado = fechaEntregada
                    });

                    // Si quedara algún 'Pendiente de entrega' con fecha posterior, lo ajustamos VER
                    foreach (var pend in entidad.Historial.Where(h => h.Estado == EstadoGuiaEnum.PendienteDeEntrega && h.FechaActualizacionEstado > fechaEntregada))
                    {
                        pend.FechaActualizacionEstado = fechaEntregada.AddSeconds(-1);
                    }

                    huboCambios = true;
                }
                else if (entidad.Estado == EstadoGuiaEnum.Entregada)
                {
                    // Ya entregada: refrescamos la marca temporal del último registro Entregada VER
                    var lastEnt = entidad.Historial.LastOrDefault(h => h.Estado == EstadoGuiaEnum.Entregada);
                    var nuevaFecha = DateTime.Now;
                    if (lastEnt != null)
                    {
                        lastEnt.FechaActualizacionEstado = nuevaFecha;
                        lastEnt.UbicacionGuia = string.Empty;
                    }
                    else
                    {
                        entidad.Historial.Add(new RegistroEstadoAux
                        {
                            Estado = EstadoGuiaEnum.Entregada,
                            UbicacionGuia = string.Empty,
                            FechaActualizacionEstado = nuevaFecha
                        });
                    }
                    huboCambios = true;
                }

                // Registrar como entregada en esta sesión para excluir en resultados subsiguientes
                _guiasEntregadasLocalmente.Add(numeroGuia);

                // Mantener coherencia con la lista local usada por la UI
                var guiaLocal = Guias.FirstOrDefault(g => g.NumeroGuia == numeroGuia);
                if (guiaLocal != null)
                {
                    guiaLocal.Estado = "Entregada";
                    guiaLocal.Ubicacion = string.Empty;
                }
            }


            return true;
        }
    }
}
