// ===============================
// EntregarEncomiendaCDModelo.cs
// ===============================
using System;
using System.Collections.Generic;
using System.Linq;
using TUTASAPrototipo.Almacenes; // <- USAMOS SOLO LECTURA DE LOS ALMACENES Y ENTIDADES

namespace TUTASAPrototipo.EntregarEncomiendaCD
{
    public class EntregarEncomiendaCDModelo
    {
        // NOTA IMPORTANTE
        // - No tocamos pantallas.
        // - Usamos los almacenes existentes (JSON) sin modificar su estructura.
        // - Cambios mínimos: lectura para búsqueda y escritura de estado al confirmar.

        // Se mantienen estas listas para que el formulario pueda inspeccionar/depender si quisiera.
        // No se cargan con datos "semilla"; se completan con resultados de las búsquedas.
        public List<Destinatario> Destinatarios { get; private set; } = new();
        public List<Guia> Guias { get; private set; } = new();

        // Mantener estado local de guías entregadas (solo durante la vida de este modelo)
        private readonly HashSet<string> _guiasEntregadasLocalmente = new();

        public EntregarEncomiendaCDModelo()
        {
            // Sin datos de prueba: todo sale de los almacenes.
        }

        // ---------------------------------------------------------------------
        // BUSCAR DESTINATARIO POR DNI
        // ---------------------------------------------------------------------
        public Destinatario? BuscarDestinatarioPorDNI(string dni)
        {
            // Tomamos el primer destinatario que matchee el DNI desde las guías cargadas en almacén.
            // (No hay un almacén independiente de Destinatarios, la info vive dentro de cada guía)
            var dest = GuiaAlmacen.guias
                .Select(g => g.Destinatario)
                .FirstOrDefault(d => d.DNI.ToString() == dni);

            // Si no hay coincidencia, devolvemos null (la pantalla muestra el mensaje correspondiente)
            if (dest is null) return null;

            var resultado = new Destinatario
            {
                DNI = dest.DNI.ToString(),
                Nombre = dest.Nombre,
                Apellido = dest.Apellido
            };

            // Guardamos el último resultado en memoria (solo para trazabilidad local en el modelo)
            Destinatarios = new List<Destinatario> { resultado };
            return resultado;
        }

        // ---------------------------------------------------------------------
        // BUSCAR GUÍAS PENDIENTES PARA ENTREGAR EN ESTE CD (por DNI + CD actual)
        // ---------------------------------------------------------------------
        public List<Guia> BuscarGuiasPendientes(string dni, string cdActual)
        {
            // 1) Resolvemos el CD actual por Nombre -> CodigoPostal (una sola línea LINQ)
            int? codigoPostalCD = CentroDeDistribucionAlmacen.centrosDeDistribucion
                .Where(cd => string.Equals(cd.Nombre, cdActual, StringComparison.OrdinalIgnoreCase))
                .Select(cd => (int?)cd.CodigoPostal)
                .FirstOrDefault();

            if (codigoPostalCD is null)
            {
                // Si el nombre del CD en sesión no coincide con el catálogo, no listamos nada.
                Guias = new List<Guia>();
                return Guias;
            }

            // 2) Obtenemos los pares (guía, cd) relevantes
            var pares = GuiaAlmacen.guias
                .Join(
                    CentroDeDistribucionAlmacen.centrosDeDistribucion,
                    guia => guia.CodigoPostalCDDestino,
                    cd => cd.CodigoPostal,
                    (guia, cd) => new { guia, cd }
                )
                .Where(x =>
                    x.guia.Destinatario.DNI.ToString() == dni &&
                    x.guia.Estado == EstadoGuiaEnum.PendienteDeEntrega &&
                    x.guia.TipoEntrega == EntregaEnum.CD &&
                    string.Equals(x.cd.Nombre, cdActual, StringComparison.OrdinalIgnoreCase) &&
                    !_guiasEntregadasLocalmente.Contains(x.guia.NumeroGuia.ToString())
                )
                .ToList();

            // 3) Asegurar que el estado "Pendiente de entrega" tenga ubicación física en el historial
            bool huboCambios = false;
            foreach (var x in pares)
            {
                x.guia.Historial ??= new List<RegistroEstadoAux>();
                // Tomar el último registro con PendienteDeEntrega
                var lastPend = x.guia.Historial.LastOrDefault(h => h.Estado == EstadoGuiaEnum.PendienteDeEntrega);
                var ubicacionDeseada = $"CD{x.cd.CodigoPostal}"; // reconocible por ConsultarEstadoModelo

                if (lastPend == null)
                {
                    // Si no existía registro pendiente en historial pero el estado actual lo es, agregamos uno con ubicación
                    x.guia.Historial.Add(new RegistroEstadoAux
                    {
                        Estado = EstadoGuiaEnum.PendienteDeEntrega,
                        UbicacionGuia = ubicacionDeseada,
                        FechaActualizacionEstado = DateTime.Now
                    });
                    huboCambios = true;
                }
                else if (string.IsNullOrWhiteSpace(lastPend.UbicacionGuia))
                {
                    lastPend.UbicacionGuia = ubicacionDeseada;
                    huboCambios = true;
                }
            }

            if (huboCambios)
            {
                // Persistimos la corrección de ubicación para que Consultar Estado la muestre
                GuiaAlmacen.Grabar();
            }

            // 4) Proyección a la clase consumida por la pantalla
            var resultados = pares
                .Select(x => new Guia
                {
                    NumeroGuia = x.guia.NumeroGuia.ToString(),
                    Tamanio = x.guia.Tamano.ToString(),
                    DniDestinatario = x.guia.Destinatario.DNI.ToString(),
                    Estado = "Pendiente de entrega",
                    Ubicacion = x.cd.Nombre
                })
                .ToList();

            Guias = resultados;
            return resultados;
        }

        // ---------------------------------------------------------------------
        // CONFIRMAR ENTREGA: Actualiza estado en JSON a "Entregada" y registra movimiento
        // ---------------------------------------------------------------------
        public bool ConfirmarEntrega(List<string> numerosDeGuia)
        {
            if (numerosDeGuia == null || numerosDeGuia.Count == 0)
                return false;

            bool huboCambios = false;

            foreach (var numero in numerosDeGuia)
            {
                if (string.IsNullOrWhiteSpace(numero)) continue;
                if (!int.TryParse(numero, out var nroInt)) continue;

                var entidad = GuiaAlmacen.guias.FirstOrDefault(g => g.NumeroGuia == nroInt);
                if (entidad == null) continue;

                entidad.Historial ??= new List<RegistroEstadoAux>();

                if (entidad.Estado == EstadoGuiaEnum.PendienteDeEntrega)
                {
                    // Transición válida: Pendiente -> Entregada
                    entidad.Estado = EstadoGuiaEnum.Entregada;
                    entidad.Historial.Add(new RegistroEstadoAux
                    {
                        Estado = EstadoGuiaEnum.Entregada,
                        UbicacionGuia = string.Empty, // Entregada: sin ubicación visible
                        FechaActualizacionEstado = DateTime.Now
                    });
                    huboCambios = true;
                }
                else if (entidad.Estado == EstadoGuiaEnum.Entregada)
                {
                    // Ya figuraba como entregada: actualizar fecha del último movimiento "Entregada" en lugar de duplicarlo
                    var lastEnt = entidad.Historial.LastOrDefault(h => h.Estado == EstadoGuiaEnum.Entregada);
                    if (lastEnt != null)
                    {
                        lastEnt.FechaActualizacionEstado = DateTime.Now;
                        // Asegurar ubicación vacía en entregada
                        lastEnt.UbicacionGuia = string.Empty;
                    }
                    else
                    {
                        // Si no existía registro (datos antiguos), agregamos uno
                        entidad.Historial.Add(new RegistroEstadoAux
                        {
                            Estado = EstadoGuiaEnum.Entregada,
                            UbicacionGuia = string.Empty,
                            FechaActualizacionEstado = DateTime.Now
                        });
                    }
                    huboCambios = true;
                }

                // Marcar como entregada en esta sesión para que no reaparezca hasta nueva búsqueda
                _guiasEntregadasLocalmente.Add(numero);

                // Mantener coherencia en la lista local que consume la UI
                var guiaLocal = Guias.FirstOrDefault(g => g.NumeroGuia == numero);
                if (guiaLocal != null)
                {
                    guiaLocal.Estado = "Entregada";
                    guiaLocal.Ubicacion = string.Empty;
                }
            }

            if (huboCambios)
            {
                GuiaAlmacen.Grabar();
            }

            return true;
        }
    }
}

