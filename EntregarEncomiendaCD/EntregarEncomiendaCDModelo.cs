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
                .FirstOrDefault(d => d != null && d.DNI.ToString() == dni);

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

            // IMPORTANTE: No modificar el historial aquí.
            // La pantalla de Consulta de Estado ya tiene fallback para mostrar ubicación
            // de 'Pendiente de entrega' cuando el registro no la trae. Esto evita que,
            // por una búsqueda, se inserten movimientos posteriores a 'Entregada'.

            // 3) Proyección a la clase consumida por la pantalla
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
                    var fechaEntregada = DateTime.Now;
                    entidad.Estado = EstadoGuiaEnum.Entregada;
                    entidad.Historial.Add(new RegistroEstadoAux
                    {
                        Estado = EstadoGuiaEnum.Entregada,
                        UbicacionGuia = string.Empty, // Entregada: sin ubicación visible
                        FechaActualizacionEstado = fechaEntregada
                    });

                    // Si por alguna operación anterior se insertó un 'Pendiente de entrega' con
                    // fecha posterior a la entrega, retrotraemos esa fecha para mantener el orden cronológico.
                    foreach (var pend in entidad.Historial.Where(h => h.Estado == EstadoGuiaEnum.PendienteDeEntrega && h.FechaActualizacionEstado > fechaEntregada))
                    {
                        pend.FechaActualizacionEstado = fechaEntregada.AddSeconds(-1);
                    }

                    huboCambios = true;
                }
                else if (entidad.Estado == EstadoGuiaEnum.Entregada)
                {
                    // Ya figuraba como entregada: actualizar fecha del último movimiento "Entregada" en lugar de duplicarlo
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

