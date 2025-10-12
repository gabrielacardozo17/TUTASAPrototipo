using System.Collections.Generic;
using System.Linq;

namespace TUTASAPrototipo.RecepcionYDespachoLargaDistancia
{
    public class RecepcionYDespachoLargaDistanciaModelo
    {
        private List<ServicioTransporte> servicios;

        public RecepcionYDespachoLargaDistanciaModelo()
        {
            CargarDatosDePrueba();
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
                new Guia { NroGuia = "001004567", Destino = "Domicilio", Tamanio = "M" },
                new Guia { NroGuia = "000200001", Destino = "CD 1010", Tamanio = "L" },
                new Guia { NroGuia = "104000011", Destino = "CD 0040", Tamanio = "XL" },
                new Guia { NroGuia = "007000150", Destino = "Agencia", Tamanio = "S" },
                new Guia { NroGuia = "101100005", Destino = "Ag. 1011", Tamanio = "M" },
                new Guia { NroGuia = "102400007", Destino = "Domicilio", Tamanio = "L" },
                new Guia { NroGuia = "011000077", Destino = "Domicilio", Tamanio = "XL" },
                new Guia { NroGuia = "108000023", Destino = "", Tamanio = "S" },
                new Guia { NroGuia = "101000016", Destino = "CD 0040", Tamanio = "M" },
                new Guia { NroGuia = "001004568", Destino = "Domicilio", Tamanio = "L" },
                new Guia { NroGuia = "000200002", Destino = "CD 1010", Tamanio = "XL" },
                new Guia { NroGuia = "104000012", Destino = "CD 0040", Tamanio = "S" },
                new Guia { NroGuia = "007000151", Destino = "Agencia", Tamanio = "M" },
                new Guia { NroGuia = "101100006", Destino = "Ag. 1011", Tamanio = "L" },
                new Guia { NroGuia = "102400008", Destino = "Domicilio", Tamanio = "XL" },
                new Guia { NroGuia = "011000078", Destino = "Domicilio", Tamanio = "S" },
                new Guia { NroGuia = "108000024", Destino = "", Tamanio = "M" },
                new Guia { NroGuia = "009000045", Destino = "CD 0090", Tamanio = "L" },
                new Guia { NroGuia = "105000031", Destino = "Ag. 1050", Tamanio = "XL" },
                new Guia { NroGuia = "004000210", Destino = "CD 0050", Tamanio = "S" },
                new Guia { NroGuia = "000100101", Destino = "Ag. 1001", Tamanio = "M" },
                new Guia { NroGuia = "102000029", Destino = "Domicilio", Tamanio = "L" },
                new Guia { NroGuia = "010000055", Destino = "Domicilio", Tamanio = "XL" },
                new Guia { NroGuia = "105200042", Destino = "", Tamanio = "S" },
                new Guia { NroGuia = "006000075", Destino = "CD", Tamanio = "M" },
                new Guia { NroGuia = "109500017", Destino = "Ag. 1095", Tamanio = "L" },
                new Guia { NroGuia = "004000089", Destino = "Domicilio", Tamanio = "XL" },
                new Guia { NroGuia = "002000061", Destino = "CD 0011", Tamanio = "S" },
                new Guia { NroGuia = "106000022", Destino = "Domicilio", Tamanio = "M" },
                new Guia { NroGuia = "011000081", Destino = "", Tamanio = "L" },
                new Guia { NroGuia = "008000065", Destino = "Ag. 1081", Tamanio = "XL" },
                new Guia { NroGuia = "010000066", Destino = "CD 0090", Tamanio = "S" },
                new Guia { NroGuia = "013000088", Destino = "Domicilio", Tamanio = "M" },
                new Guia { NroGuia = "014000054", Destino = "Ag. 1096", Tamanio = "L" },
                new Guia { NroGuia = "015000035", Destino = "CD", Tamanio = "XL" },
                new Guia { NroGuia = "016000029", Destino = "CD 0050", Tamanio = "S" },
                new Guia { NroGuia = "017000021", Destino = "CD 0070", Tamanio = "M" },
                new Guia { NroGuia = "018000010", Destino = "Domicilio", Tamanio = "L" },
                new Guia { NroGuia = "019000011", Destino = "", Tamanio = "XL" },
                new Guia { NroGuia = "101200003", Destino = "Ag. 1012", Tamanio = "S" },
                new Guia { NroGuia = "101300009", Destino = "Domicilio", Tamanio = "M" },
                new Guia { NroGuia = "104100025", Destino = "CD 0040", Tamanio = "L" },
                new Guia { NroGuia = "104200019", Destino = "CD 0050", Tamanio = "XL" },
                new Guia { NroGuia = "104400022", Destino = "CD 0040", Tamanio = "S" },
                new Guia { NroGuia = "105300018", Destino = "Domicilio", Tamanio = "M" },
                new Guia { NroGuia = "105400014", Destino = "Ag. 1054", Tamanio = "L" },
                new Guia { NroGuia = "105500013", Destino = "Agencia", Tamanio = "XL" },
                new Guia { NroGuia = "106300011", Destino = "Ag. 1060", Tamanio = "S" },
                new Guia { NroGuia = "107200033", Destino = "Ag. 1072", Tamanio = "M" },
                new Guia { NroGuia = "107300045", Destino = "CD 0070", Tamanio = "L" },
                new Guia { NroGuia = "107400025", Destino = "CD 0070", Tamanio = "XL" },
                new Guia { NroGuia = "107500031", Destino = "Domicilio", Tamanio = "S" },
                new Guia { NroGuia = "107600042", Destino = "Ag. 1076", Tamanio = "M" },
                new Guia { NroGuia = "107700019", Destino = "", Tamanio = "L" },
                new Guia { NroGuia = "108200029", Destino = "CD 0090", Tamanio = "XL" },
                new Guia { NroGuia = "108300037", Destino = "Agencia", Tamanio = "S" },
                new Guia { NroGuia = "108400048", Destino = "Ag. 1081", Tamanio = "M" },
                new Guia { NroGuia = "108500059", Destino = "Ag. 1081", Tamanio = "L" },
                new Guia { NroGuia = "108600067", Destino = "", Tamanio = "XL" }
            };
            // Filtrar guías sin destino
            todasLasGuias = todasLasGuias.Where(g => !string.IsNullOrWhiteSpace(g.Destino)).ToList();

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
            this.servicios = servicios;
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
    }
}