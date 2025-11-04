using System;
using System.Collections.Generic;
using System.Linq;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.RecepcionYDespachoUltimaMillaCD
{
    public class RecepcionYDespachoUltimaMillaCDModelo
    {
        private int _seqHdr = 1;
        private int _seqGuia = 10000;

        // ================= API (usado por el Form) =================

        public FleteroEntidad? BuscarFleteroPorDni(int dni) =>
            FleteroAlmacen.fleteros.FirstOrDefault(f => f.DNI == dni);

        // Devuelve guías asignadas al fletero en HDR
        public (IEnumerable<GuiaEntidad> distribucion, IEnumerable<GuiaEntidad> retiro) GetGuiasPorFletero(int dni)
        {
            var hdrsFletero = HDRAlmacen.HDR.Where(h => h.DNIFletero == dni).ToList();

            var guiasDistribucion = hdrsFletero
                .Where(h => h.TipoHDR == TipoHDREnum.Distribucion)
                .SelectMany(h => h.Guias)
                .Where(g => g.Estado != EstadoGuiaEnum.Entregada)
                .OrderBy(g => g.NumeroGuia)
                .ToList();

            var guiasRetiro = hdrsFletero
                .Where(h => h.TipoHDR == TipoHDREnum.Retiro)
                .SelectMany(h => h.Guias)
                .Where(g => g.Estado ==EstadoGuiaEnum.ARetirarPorDomicilioDelCliente
                            || g.Estado == EstadoGuiaEnum.ARetirarEnAgenciaDeOrigen)
                .OrderBy(g => g.NumeroGuia)
                .ToList();

            return (guiasDistribucion, guiasRetiro);
        }

        // Devuelve guías que aún NO están en HDR (para nuevos cuadros)
        public List<GuiaEntidad> GetGuiasPendientes()
        {
            var guiasAsignadas = HDRAlmacen.HDR
                .SelectMany(h => h.Guias)
                .Select(g => g.NumeroGuia)
                .ToHashSet();

            return GuiaAlmacen.guias
                .Where(g => !guiasAsignadas.Contains(g.NumeroGuia)
                            && g.Estado != EstadoGuiaEnum.Entregada
                            && g.Estado != EstadoGuiaEnum.Cancelada
                            && g.Estado != EstadoGuiaEnum.NoEntregada
                            && g.Estado != EstadoGuiaEnum.Facturada)
                .OrderBy(g => g.NumeroGuia)
                .ToList();
        }

        // Confirma entrega o retiro de guías en HDR asignadas al fletero
        public void ConfirmarRendicion(int dni, List<string> entregasDistribucionMarcadas, List<string> retirosMarcados)
        {
            var hdrsFletero = HDRAlmacen.HDR.Where(h => h.DNIFletero == dni).ToList();

            foreach (var hdr in hdrsFletero)
            {
                foreach (var g in hdr.Guias)
                {
                    // Distribución: marcar entregadas
                    if (hdr.TipoHDR == TipoHDREnum.Distribucion &&
                        entregasDistribucionMarcadas.Contains(g.NumeroGuia.ToString()) &&
                        EstadosDistribucionAsignables.Contains(g.Estado))
                    {
                        g.Estado = EstadoGuiaEnum.Entregada;
                    }

                    // Retiro: marcar en tránsito al CD
                    if (hdr.TipoHDR == TipoHDREnum.Retiro &&
                        retirosMarcados.Contains(g.NumeroGuia.ToString()) &&
                        EsRetiro(g.Estado))
                    {
                        g.Estado = EstadoGuiaEnum.EnTransitoAlCDDestino;
                    }
                }
            }

            HDRAlmacen.Grabar();
        }

        // Asigna nuevas HDRs por dirección (solo guías que aún no están en HDR)
        public void AsignarHDRsPorDireccion(int dni)
        {
            var guiasPendientes = GetGuiasPendientes();

            foreach (var grp in guiasPendientes.GroupBy(g => NormalizarDestino(g.Destinatario?.Direccion ?? "")))
            {
                foreach (var chunk in grp.Chunk(5))
                {
                    var nroHdr = $"H{_seqHdr++:000}";
                    var tipoHdr = chunk.Any(g => EsRetiro(g.Estado)) ? TipoHDREnum.Retiro : TipoHDREnum.Distribucion;

                    var hdr = new HDREntidad
                    {
                        ID = nroHdr,
                        TipoHDR = tipoHdr,
                        DNIFletero = dni,
                        Guias = chunk.ToList()
                    };

                    HDRAlmacen.HDR.Add(hdr);
                }
            }

            HDRAlmacen.Grabar();
        }

        // ================= Helpers =================

        private static bool EsRetiro(EstadoGuiaEnum estado) =>
            estado == EstadoGuiaEnum.ARetirarEnAgenciaDeOrigen ||
            estado == EstadoGuiaEnum.ARetirarPorDomicilioDelCliente;

        private static readonly HashSet<EstadoGuiaEnum> EstadosDistribucionAsignables = new()
        {
            EstadoGuiaEnum.Admitida,
            EstadoGuiaEnum.PendienteDeEntrega,
            EstadoGuiaEnum.EnCDDestino,
            EstadoGuiaEnum.EnRutaAlDomicilioDeEntrega,
            EstadoGuiaEnum.EnRutaAlaAgenciaDestino
        };

        private static string NormalizarDestino(string destino) =>
            string.IsNullOrWhiteSpace(destino) ? "DOMICILIO" : destino.Trim().ToUpperInvariant();

        private int NextGuiaNumber() => _seqGuia++;


        public (List<GuiaEntidad> enCDDestino, List<GuiaEntidad> pendientesRetiro) GetGuiasNoAsignadasPorEstado()
{

    // Filtrar las guías que NO están en HDR y que siguen activas
    var guiasNoAsignadas = GuiaAlmacen.guias
        .Where(g => g.Estado !=EstadoGuiaEnum.Entregada
                    && g.Estado != EstadoGuiaEnum.Cancelada
                    && g.Estado != EstadoGuiaEnum.NoEntregada
                    && g.Estado != EstadoGuiaEnum.Facturada)
        .ToList();

    // Cuadro 3: guías en estado EnCDDestino
    var enCDDestino = guiasNoAsignadas
        .Where(g => g.Estado == EstadoGuiaEnum.EnCDDestino)
        .OrderBy(g => g.NumeroGuia)
        .ToList();

    // Cuadro 4: guías pendientes de retiro (usando helper EsRetiro)
    var pendientesRetiro = guiasNoAsignadas
        .Where(g => EsRetiro(g.Estado))
        .OrderBy(g => g.NumeroGuia)
        .ToList();

    return (enCDDestino, pendientesRetiro);
}

    }
}
