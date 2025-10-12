using System.Collections.Generic;
using System.Linq;

namespace TUTASAPrototipo.RecepcionYDespachoLargaDistancia
{
    public class RecepcionYDespachoLargaDistanciaModelo
    {
        private List<ServicioTransporte> servicios;
        private List<Guia> guiasPendientesDeAsignacion;

        public RecepcionYDespachoLargaDistanciaModelo()
        {
            CargarDatosDePrueba();
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

        private void CargarDatosDePrueba()
        {
            var empresas = new[]
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
                new Guia { NroGuia = "101000015", Destino = "CD 0040", Tamanio = "S" },
                new Guia { NroGuia = "001004567", Destino = "CD 0050", Tamanio = "M" },
                new Guia { NroGuia = "000200001", Destino = "CD 0010", Tamanio = "L" },
                new Guia { NroGuia = "104000011", Destino = "CD 0040", Tamanio = "XL" },
                new Guia { NroGuia = "007000150", Destino = "CD 0060", Tamanio = "S" },
                new Guia { NroGuia = "101100005", Destino = "CD 0070", Tamanio = "M" },
                new Guia { NroGuia = "102400007", Destino = "CD 0080", Tamanio = "L" },
                new Guia { NroGuia = "011000077", Destino = "CD 0090", Tamanio = "XL" },
                new Guia { NroGuia = "108000023", Destino = "CD 0100", Tamanio = "S" },
                new Guia { NroGuia = "101000016", Destino = "CD 0110", Tamanio = "M" },
                new Guia { NroGuia = "001004568", Destino = "CD 0001", Tamanio = "L" },
                new Guia { NroGuia = "000200002", Destino = "CD 0002", Tamanio = "XL" },
                new Guia { NroGuia = "104000012", Destino = "CD 0040", Tamanio = "S" },
                new Guia { NroGuia = "007000151", Destino = "CD 0050", Tamanio = "M" },
                new Guia { NroGuia = "101100006", Destino = "CD 0060", Tamanio = "L" },
                new Guia { NroGuia = "102400008", Destino = "CD 0070", Tamanio = "XL" },
                new Guia { NroGuia = "011000078", Destino = "CD 0080", Tamanio = "S" },
                new Guia { NroGuia = "108000024", Destino = "CD 0090", Tamanio = "M" },
                new Guia { NroGuia = "009000045", Destino = "CD 0090", Tamanio = "L" },
                new Guia { NroGuia = "105000031", Destino = "CD 0100", Tamanio = "XL" },
                new Guia { NroGuia = "004000210", Destino = "CD 0050", Tamanio = "S" },
                new Guia { NroGuia = "000100101", Destino = "CD 0110", Tamanio = "M" },
                new Guia { NroGuia = "102000029", Destino = "CD 0001", Tamanio = "L" },
                new Guia { NroGuia = "010000055", Destino = "CD 0002", Tamanio = "XL" },
                new Guia { NroGuia = "105200042", Destino = "CD 0010", Tamanio = "S" },
                new Guia { NroGuia = "006000075", Destino = "CD 0011", Tamanio = "M" },
                new Guia { NroGuia = "109500017", Destino = "CD 0040", Tamanio = "L" },
                new Guia { NroGuia = "004000089", Destino = "CD 0050", Tamanio = "XL" },
                new Guia { NroGuia = "002000061", Destino = "CD 0011", Tamanio = "S" },
                new Guia { NroGuia = "106000022", Destino = "CD 0060", Tamanio = "M" },
                new Guia { NroGuia = "011000081", Destino = "CD 0070", Tamanio = "L" },
                new Guia { NroGuia = "008000065", Destino = "CD 0080", Tamanio = "XL" },
                new Guia { NroGuia = "010000066", Destino = "CD 0090", Tamanio = "S" },
                new Guia { NroGuia = "013000088", Destino = "CD 0100", Tamanio = "M" },
                new Guia { NroGuia = "014000054", Destino = "CD 0110", Tamanio = "L" },
                new Guia { NroGuia = "015000035", Destino = "CD 0001", Tamanio = "XL" },
                new Guia { NroGuia = "016000029", Destino = "CD 0050", Tamanio = "S" },
                new Guia { NroGuia = "017000021", Destino = "CD 0070", Tamanio = "M" },
                new Guia { NroGuia = "018000010", Destino = "CD 0002", Tamanio = "L" },
                new Guia { NroGuia = "019000011", Destino = "CD 0010", Tamanio = "XL" },
                new Guia { NroGuia = "101200003", Destino = "CD 0011", Tamanio = "S" },
                new Guia { NroGuia = "101300009", Destino = "CD 0040", Tamanio = "M" },
                new Guia { NroGuia = "104100025", Destino = "CD 0040", Tamanio = "L" },
                new Guia { NroGuia = "104200019", Destino = "CD 0050", Tamanio = "XL" },
                new Guia { NroGuia = "104400022", Destino = "CD 0040", Tamanio = "S" },
                new Guia { NroGuia = "105300018", Destino = "CD 0060", Tamanio = "M" },
                new Guia { NroGuia = "105400014", Destino = "CD 0070", Tamanio = "L" },
                new Guia { NroGuia = "105500013", Destino = "CD 0080", Tamanio = "XL" },
                new Guia { NroGuia = "106300011", Destino = "CD 0090", Tamanio = "S" },
                new Guia { NroGuia = "107200033", Destino = "CD 0100", Tamanio = "M" },
                new Guia { NroGuia = "107300045", Destino = "CD 0070", Tamanio = "L" },
                new Guia { NroGuia = "107400025", Destino = "CD 0070", Tamanio = "XL" },
                new Guia { NroGuia = "107500031", Destino = "CD 0110", Tamanio = "S" },
                new Guia { NroGuia = "107600042", Destino = "CD 0001", Tamanio = "M" },
                new Guia { NroGuia = "107700019", Destino = "CD 0002", Tamanio = "L" },
                new Guia { NroGuia = "108200029", Destino = "CD 0090", Tamanio = "XL" },
                new Guia { NroGuia = "108300037", Destino = "CD 0010", Tamanio = "S" },
                new Guia { NroGuia = "108400048", Destino = "CD 0011", Tamanio = "M" },
                new Guia { NroGuia = "108500059", Destino = "CD 0040", Tamanio = "L" },
                new Guia { NroGuia = "108600067", Destino = "CD 0050", Tamanio = "XL" }
            };
            // Normalizar nombres de CD en destino
            foreach (var g in todasLasGuias)
                g.Destino = NormalizarDestino(g.Destino);
            todasLasGuias = todasLasGuias.Where(g => !string.IsNullOrWhiteSpace(g.Destino)).ToList();

            // Guías extra para pruebas (no asignadas a empresas)
            var guiasExtra = new List<Guia>
            {
                new Guia { NroGuia = "999900001", Destino = "CD 0040", Tamanio = "M" },
                new Guia { NroGuia = "999900002", Destino = "CD 0050", Tamanio = "L" },
                new Guia { NroGuia = "999900003", Destino = "CD 0060", Tamanio = "XL" },
                new Guia { NroGuia = "999900004", Destino = "CD 0080", Tamanio = "S" },
                new Guia { NroGuia = "999900005", Destino = "CD 0090", Tamanio = "M" }
            };
            foreach (var g in guiasExtra)
                g.Destino = NormalizarDestino(g.Destino);

            var servicios = new List<ServicioTransporte>();
            int totalEmpresas = empresas.Length;
            int totalGuias = todasLasGuias.Count;
            int[] guiasPorEmpresa = { 10, 8, 12, 14, 10, totalGuias - (10+8+12+14+10) };
            int guiaIndex = 0;
            for (int i = 0; i < totalEmpresas; i++)
            {
                var guiasEmpresa = todasLasGuias.Skip(guiaIndex).Take(guiasPorEmpresa[i]).ToList();
                guiaIndex += guiasPorEmpresa[i];
                var recibir = guiasEmpresa.Take(guiasEmpresa.Count/2).ToList();
                var despachar = guiasEmpresa.Skip(guiasEmpresa.Count/2).ToList();
                servicios.Add(new ServicioTransporte
                {
                    NumeroServicio = empresas[i].Servicio,
                    GuiasARecibir = recibir,
                    GuiasADespachar = despachar
                });
            }
            // Guías extra quedan fuera de los servicios asignados
            this.servicios = servicios;
            
            // Inicializar pool de guías pendientes de asignación
            this.guiasPendientesDeAsignacion = guiasExtra;
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