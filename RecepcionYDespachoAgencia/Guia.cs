namespace TUTASAPrototipo.RecepcionYDespachoAgencia
{
    public class Guia
    {
        public string Numero { get; set; } = "";
        public string Tamaño { get; set; } = "";     // S/M/L/XL
        public string Destino { get; set; } = "";    // opcional (no hay columna en el designer)
        public TipoGuia Tipo { get; set; }
        public EstadoGuia Estado { get; set; }
    }
}
