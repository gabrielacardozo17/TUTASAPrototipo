namespace TUTASAPrototipo.RecepcionYDespachoAgencia
{
    public class Guia
    {
        public string NumeroGuia { get; set; } = "";
        public string Tamanio { get; set; } = "";     // S/M/L/XL
        public string Destino { get; set; } = "";    // nombre de la agencia destino
        public string TipoEntrega { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public int? FleteroDni { get; set; }         // Asignación a fletero específico
        public string Ubicacion { get; set; } = "";  // Ubicación actual de la guía
    }
}
