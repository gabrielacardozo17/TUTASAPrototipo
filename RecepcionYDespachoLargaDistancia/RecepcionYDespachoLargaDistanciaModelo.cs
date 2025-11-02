using System.Collections.Generic;
using System.Linq;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.RecepcionYDespachoLargaDistancia
{
    public class RecepcionYDespachoLargaDistanciaModelo
    {
        private List<ServicioTransporte> servicios;
        private List<Guia> guiasPendientesDeAsignacion;

        public RecepcionYDespachoLargaDistanciaModelo()
        {
            // Los datos de prueba históricos quedan comentados en CargarDatosDePrueba().
            CargarDatosDePrueba();
            // Mapear los datos reales desde los almacenes usando LINQ
            MapearDesdeAlmacenes();
        }

        private static readonly Dictionary<string, string> CdNombres = new()
        {
            ["0001"] = "CD CABA Oeste",
            ["0002"] = "CD CABA Sur",
            ["0010"] = "CD Buenos Aires – La Plata",
            ["0011"] = "CD Buenos Aires – Mar del Plata",
            ["0040"] = "CD Córdoba Capital",
            ["0050"] = "CD Rosario",
            ["0060"] = "CD San Miguel de Tucumán",
            ["0070"] = "CD Corrientes",
            ["0080"] = "CD Neuquén",
            ["0090"] = "CD Viedma",
            ["0100"] = "CD Mendoza Capital",
            ["0110"] = "CD Bahía Blanca"
        };

        private string NormalizarDestino(string destino)
        {
            if (string.IsNullOrWhiteSpace(destino)) return destino;
            var cdMatch = System.Text.RegularExpressions.Regex.Match(destino, @"CD (\d{4})");
            if (cdMatch.Success && CdNombres.TryGetValue(cdMatch.Groups[1].Value, out var nombre))
                return nombre;
            return destino;
        }

        // Mapear los datos de los almacenes a las clases usadas por la UI usando LINQ (GroupJoin / SELECT / ToList)
        private void MapearDesdeAlmacenes()
        {
            var serviciosEnt = ServicioTransporteAlmacen.serviciosTransporte ?? new List<ServicioTransporteEntidad>();
            var hdrs = HDRAlmacen.HDR ?? new List<HDREntidad>();
            var guiasAlmacen = GuiaAlmacen.guias ?? new List<GuiaEntidad>();
            var cds = CentroDeDistribucionAlmacen.centrosDeDistribucion ?? new List<CentroDeDistribucionEntidad>();

            // GroupJoin (left join) para conservar servicios aun cuando no tengan HDRs
            this.servicios = serviciosEnt
                .GroupJoin(
                    hdrs,
                    s => s.ID,
                    h => h.IDServicioTransporte,
                    (s, hdrGroup) => new { s, hdrGroup })
                .Select(x =>
                {
                    var s = x.s;
                    var hdrGroup = x.hdrGroup;

                    // Conjunto de códigos postales del servicio (maneja tramos nulos)
                    var cpSet = (s.Tramos ?? Enumerable.Empty<TramoAux>())
                                .SelectMany(t => new[] { t.CodigoPostalOrigen, t.CodigoPostalDestino })
                                .Where(cp => cp != 0)
                                .Distinct()
                                .ToHashSet();

                    // Guias a recibir: desde las HDR relacionadas (si las hay)
                    var guiasARecibir = hdrGroup
                        .SelectMany(h => h.Guias ?? Enumerable.Empty<GuiaEntidad>())
                        .Select(gent => new Guia
                        {
                            NroGuia = gent.NumeroGuia.ToString(),
                            Tamanio = gent.Tamano.ToString(),
                            Destino = cds.FirstOrDefault(cd => cd.CodigoPostal == gent.CodigoPostalCDDestino)?.Nombre ?? gent.CodigoPostalCDDestino.ToString()
                        })
                        .ToList();

                    // Guias a despachar: guías admitidas que coincidan con los códigos postales del servicio
                    var guiasADespachar = guiasAlmacen
                        .Where(ga => ga.Estado == EstadoGuiaEnum.Admitida &&
                                     (cpSet.Contains(ga.CodigoPostalCDOrigen) || cpSet.Contains(ga.CodigoPostalCDDestino)))
                        .DistinctBy(ga => ga.NumeroGuia)
                        .Select(ga => new Guia
                        {
                            NroGuia = ga.NumeroGuia.ToString(),
                            Tamanio = ga.Tamano.ToString(),
                            Destino = cds.FirstOrDefault(cd => cd.CodigoPostal == ga.CodigoPostalCDDestino)?.Nombre ?? ga.CodigoPostalCDDestino.ToString()
                        })
                        .ToList();

                    return new ServicioTransporte
                    {
                        NumeroServicio = s.ID.ToString(),
                        GuiasARecibir = guiasARecibir,
                        GuiasADespachar = guiasADespachar
                    };
                })
                .ToList();

            // Pool de guías pendientes: guías en almacen que NO están en ninguna HDR
            var guiasEnHDRNums = hdrs
                .SelectMany(h => h.Guias ?? Enumerable.Empty<GuiaEntidad>())
                .Select(g => g.NumeroGuia)
                .ToHashSet();

            this.guiasPendientesDeAsignacion = guiasAlmacen
                .Where(g => !guiasEnHDRNums.Contains(g.NumeroGuia))
                .Select(g => new Guia
                {
                    NroGuia = g.NumeroGuia.ToString(),
                    Tamanio = g.Tamano.ToString(),
                    Destino = cds.FirstOrDefault(cd => cd.CodigoPostal == g.CodigoPostalCDDestino)?.Nombre ?? g.CodigoPostalCDDestino.ToString()
                })
                .ToList();

            // Asegurar listas no-nulas
            this.servicios = this.servicios ?? new List<ServicioTransporte>();
            this.guiasPendientesDeAsignacion = this.guiasPendientesDeAsignacion ?? new List<Guia>();
        }

        private void CargarDatosDePrueba()
        {
            // DATOS DE PRUEBA COMENTADOS: se conservan como comentario histórico tal como se pidió.
/*  var empresas = new[]
{
    new { Codigo = "100", Nombre = "Plusmar", Servicio = "10012345" },
    new { Codigo = "200", Nombre = "Fletar SRL", Servicio = "20023456" },
    new { Codigo = "300", Nombre = "AndesMar Cargas", Servicio = "30034567" },
    new { Codigo = "400", Nombre = "Via Bariloche Cargo", Servicio = "40045678" },
    new { Codigo = "500", Nombre = "El Cóndor – La Estrella Cargo", Servicio = "50056789" },
    new { Codigo = "600", Nombre = "Crucero del Norte Cargo", Servicio = "60067890" }
};
var todasLasGuias = new List<Guia>
{
    // CD CABA Oeste (0001) - origen
    new Guia { NroGuia = "000100015", Destino = "CD 0040", Tamanio = "S" },
    new Guia { NroGuia = "000100016", Destino = "CD 0110", Tamanio = "M" },
    // CD CABA Sur (0002) - origen
    new Guia { NroGuia = "000200001", Destino = "CD 0010", Tamanio = "L" },
    new Guia { NroGuia = "000200002", Destino = "CD 0002", Tamanio = "XL" },
    new Guia { NroGuia = "000200061", Destino = "CD 0011", Tamanio = "S" },
    // CD Buenos Aires La Plata (0010) - origen
    new Guia { NroGuia = "001004567", Destino = "CD 0050", Tamanio = "M" },
    new Guia { NroGuia = "001004568", Destino = "CD 0001", Tamanio = "L" },
    new Guia { NroGuia = "001000055", Destino = "CD 0002", Tamanio = "XL" },
    new Guia { NroGuia = "001000066", Destino = "CD 0090", Tamanio = "S" },
    new Guia { NroGuia = "001000101", Destino = "CD 0110", Tamanio = "M" },
    // CD Buenos Aires Mar del Plata (0011) - origen
    new Guia { NroGuia = "001100077", Destino = "CD 0090", Tamanio = "XL" },
    new Guia { NroGuia = "001100078", Destino = "CD 0080", Tamanio = "S" },
    new Guia { NroGuia = "001100081", Destino = "CD 0070", Tamanio = "L" },
    // CD Córdoba Capital (0040) - origen
    new Guia { NroGuia = "004000011", Destino = "CD 0040", Tamanio = "XL" },
    new Guia { NroGuia = "004000012", Destino = "CD 0040", Tamanio = "S" },
    new Guia { NroGuia = "004000210", Destino = "CD 0050", Tamanio = "S" },
    new Guia { NroGuia = "004000089", Destino = "CD 0050", Tamanio = "XL" },
    new Guia { NroGuia = "004100025", Destino = "CD 0040", Tamanio = "L" },
    new Guia { NroGuia = "004200019", Destino = "CD 0050", Tamanio = "XL" },
    new Guia { NroGuia = "004400022", Destino = "CD 0040", Tamanio = "S" },
    // CD Rosario (0050) - origen
    new Guia { NroGuia = "005000031", Destino = "CD 0100", Tamanio = "XL" },
    new Guia { NroGuia = "005200042", Destino = "CD 0010", Tamanio = "S" },
    new Guia { NroGuia = "005300018", Destino = "CD 0060", Tamanio = "M" },
    new Guia { NroGuia = "005400014", Destino = "CD 0070", Tamanio = "L" },
    new Guia { NroGuia = "005500013", Destino = "CD 0080", Tamanio = "XL" },
    // CD San Miguel de Tucumán (0060) - origen
    new Guia { NroGuia = "006000075", Destino = "CD 0011", Tamanio = "M" },
    new Guia { NroGuia = "006000022", Destino = "CD 0060", Tamanio = "M" },
    new Guia { NroGuia = "006300011", Destino = "CD 0090", Tamanio = "S" },
    // CD Corrientes (0070) - origen
    new Guia { NroGuia = "007000150", Destino = "CD 0060", Tamanio = "S" },
    new Guia { NroGuia = "007000151", Destino = "CD 0050", Tamanio = "M" },
    new Guia { NroGuia = "007200033", Destino = "CD 0100", Tamanio = "M" },
    new Guia { NroGuia = "007300045", Destino = "CD 0070", Tamanio = "L" },
    new Guia { NroGuia = "007400025", Destino = "CD 0070", Tamanio = "XL" },
    new Guia { NroGuia = "007500031", Destino = "CD 0110", Tamanio = "S" },
    new Guia { NroGuia = "007600042", Destino = "CD 0001", Tamanio = "M" },
    new Guia { NroGuia = "007700019", Destino = "CD 0002", Tamanio = "L" },
    // CD Neuquén (0080) - origen
    new Guia { NroGuia = "008000065", Destino = "CD 0080", Tamanio = "XL" },
    new Guia { NroGuia = "008000023", Destino = "CD 0100", Tamanio = "S" },
    new Guia { NroGuia = "008000024", Destino = "CD 0090", Tamanio = "M" },
    new Guia { NroGuia = "008200029", Destino = "CD 0090", Tamanio = "XL" },
    new Guia { NroGuia = "008300037", Destino = "CD 0010", Tamanio = "S" },
    new Guia { NroGuia = "008400048", Destino = "CD 0011", Tamanio = "M" },
    new Guia { NroGuia = "008500059", Destino = "CD 0040", Tamanio = "L" },
    new Guia { NroGuia = "008600067", Destino = "CD 0050", Tamanio = "XL" },
    // CD Viedma (0090) - origen
    new Guia { NroGuia = "009000045", Destino = "CD 0090", Tamanio = "L" },
    new Guia { NroGuia = "009500017", Destino = "CD 0040", Tamanio = "L" },
    // CD Mendoza Capital (0100) - origen
    new Guia { NroGuia = "010000029", Destino = "CD 0001", Tamanio = "L" },
    new Guia { NroGuia = "010000088", Destino = "CD 0100", Tamanio = "M" },
    // CD Bahía Blanca (0110) - origen
    new Guia { NroGuia = "011000005", Destino = "CD 0070", Tamanio = "M" },
    new Guia { NroGuia = "011000007", Destino = "CD 0080", Tamanio = "L" },
    new Guia { NroGuia = "011200003", Destino = "CD 0011", Tamanio = "S" },
    new Guia { NroGuia = "011300009", Destino = "CD 0040", Tamanio = "M" },
    new Guia { NroGuia = "011000054", Destino = "CD 0110", Tamanio = "L" },
    new Guia { NroGuia = "011000035", Destino = "CD 0001", Tamanio = "XL" },
    new Guia { NroGuia = "011000029", Destino = "CD 0050", Tamanio = "S" },
    new Guia { NroGuia = "011000021", Destino = "CD 0070", Tamanio = "M" },
    new Guia { NroGuia = "011000010", Destino = "CD 0002", Tamanio = "L" },
    new Guia { NroGuia = "011000011", Destino = "CD 0010", Tamanio = "XL" }
*/
}

// Validación Nivel 3-4: Lógica de búsqueda en la fuente de datos.
public ServicioTransporte BuscarServicio(string numeroServicio)
{
if (string.IsNullOrWhiteSpace(numeroServicio))
{
    return null;
}
var servicio = servicios.FirstOrDefault(s => s.NumeroServicio == numeroServicio);
if (servicio == null) return null;
// Filtrar guías no procesadas
servicio.GuiasARecibir = servicio.GuiasARecibir.Where(g => !g.Procesada).ToList();
servicio.GuiasADespachar = servicio.GuiasADespachar.Where(g => !g.Procesada).ToList();
return servicio;
}

public void MarcarGuiasProcesadas(string numeroServicio, List<string> guiasRecibidas, List<string> guiasDespachadas)
{
var servicio = servicios.FirstOrDefault(s => s.NumeroServicio == numeroServicio);
if (servicio == null) return;
foreach (var guia in servicio.GuiasARecibir)
{
    if (guiasRecibidas.Contains(guia.NroGuia))
        guia.Procesada = true;
}
foreach (var guia in servicio.GuiasADespachar)
{
    if (guiasDespachadas.Contains(guia.NroGuia))
        guia.Procesada = true;
}
}

/// <summary>
/// Asigna guías pendientes a un servicio cuando se queda sin guías para despachar.
/// Toma hasta 5 guías del pool de guías pendientes.
/// </summary>
public bool AsignarGuiasPendientes(string numeroServicio)
{
var servicio = servicios.FirstOrDefault(s => s.NumeroServicio == numeroServicio);
if (servicio == null) return false;

// Verificar si hay guías pendientes disponibles
if (guiasPendientesDeAsignacion == null || guiasPendientesDeAsignacion.Count == 0)
    return false;

// Tomar hasta 5 guías del pool
var guiasAAsignar = guiasPendientesDeAsignacion.Take(5).ToList();

// Agregar a la lista de guías a despachar del servicio
servicio.GuiasADespachar.AddRange(guiasAAsignar);

// Remover del pool de pendientes
foreach (var guia in guiasAAsignar)
{
    guiasPendientesDeAsignacion.Remove(guia);
}

return true;
}

/// <summary>
/// Obtiene la cantidad de guías pendientes de asignación disponibles.
/// </summary>
public int ObtenerCantidadGuiasPendientes()
{
return guiasPendientesDeAsignacion?.Count ?? 0;
}
}
}