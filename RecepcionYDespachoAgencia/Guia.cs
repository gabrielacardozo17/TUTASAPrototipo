namespace TUTASAPrototipo.RecepcionYDespachoAgencia
{
    public class Guia
    {
        public string Numero { get; set; } = "";
        public string Tamaño { get; set; } = "";     // S/M/L/XL
        public string Destino { get; set; } = "";    // nombre de la agencia destino
        public string Tipo { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public int? FleteroDni { get; set; }         // Asignación a fletero específico
        public string UbicacionActual { get; set; } = "";  // Ubicación actual de la guía
    }
}
