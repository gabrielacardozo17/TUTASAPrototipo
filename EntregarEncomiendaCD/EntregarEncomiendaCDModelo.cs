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
        // - No escribimos en almacenes/JSON (SOLO LECTURA), tal como indicaron.
        // - Usamos LINQ para mapear desde las entidades de los almacenes a las clases simples de esta pantalla.

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

            // 2) Obtenemos en UNA consulta LINQ las guías pendientes de entrega en este CD y para el DNI indicado
            //    Hacemos un join con Centros para reforzar la relación y usar el Nombre en la proyección final.
            var resultados = GuiaAlmacen.guias
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
                    !_guiasEntregadasLocalmente.Contains(x.guia.NumeroGuia.ToString()) // excluir entregadas en esta sesión
                )
                .Select(x => new Guia
                {
                    // Mapeo simple a la clase usada por la pantalla
                    NumeroGuia = x.guia.NumeroGuia.ToString(),
                    Tamanio = x.guia.Tamano.ToString(), // Enum -> texto "S/M/L/XL"
                    DniDestinatario = x.guia.Destinatario.DNI.ToString(),
                    Estado = "Pendiente de entrega",
                    Ubicacion = x.cd.Nombre
                })
                .ToList();

            // Dejamos el resultado en memoria (solo para esta sesión del modelo)
            Guias = resultados;
            return resultados;
        }

        // ---------------------------------------------------------------------
        // CONFIRMAR ENTREGA (solo actualiza el estado local; no persiste en almacenes/JSON)
        // ---------------------------------------------------------------------
        public bool ConfirmarEntrega(List<string> numerosDeGuia)
        {
            // Respetamos la consigna: SOLO LECTURA en almacenes.
            // Por lo tanto, no modificamos GuiaAlmacen.guias ni grabamos JSON.
            // Actualizamos solamente la colección local de resultados para mantener coherencia en memoria.

            foreach (var numero in numerosDeGuia)
            {
                var guiaLocal = Guias.FirstOrDefault(g => g.NumeroGuia == numero);
                if (guiaLocal != null)
                {
                    guiaLocal.Estado = "Entregada";
                    guiaLocal.Ubicacion = string.Empty; // Entregada => sin ubicación
                }

                // Además, registramos que esta guía ya fue entregada en esta sesión
                if (!string.IsNullOrWhiteSpace(numero))
                {
                    _guiasEntregadasLocalmente.Add(numero);
                }
            }

            return true;
        }
    }
}

