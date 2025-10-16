using System;

namespace TUTASAPrototipo.RecepcionYDespachoUltimaMillaCD
{
    public class Guia
    {
        public string Numero { get; set; } = "";
        public string Estado { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Origen { get; set; } = "";
        public string Destino { get; set; } = "";
        public string Tamaño { get; set; } = ""; // S/M/L
        public string? NroHDR { get; set; }
        public int? FleteroDni { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
