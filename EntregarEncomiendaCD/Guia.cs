// ===============================
// Guia.cs  (NO redefinas Tamanio si ya existe en este namespace)
// ===============================
namespace TUTASAPrototipo.EntregarEncomiendaCD
{
    public class Guia
    {
        public string NumeroGuia { get; set; } = string.Empty;
        public string Tamanio { get; set; } = string.Empty; // S/M/L/XL
        public string DniDestinatario { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;
    }
}
