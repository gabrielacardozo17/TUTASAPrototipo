namespace TUTASAPrototipo.RecepcionYDespachoUltimaMillaCD
{
    public class Guia
    {
        public string Numero { get; set; } = "";
        public string Destino { get; set; } = "";
        public string Tamaño { get; set; } = "";   // S/M/L/XL
        public TipoGuia Tipo { get; set; }
        public EstadoGuia Estado { get; set; }
    }
}
