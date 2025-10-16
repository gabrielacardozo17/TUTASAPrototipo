namespace TUTASAPrototipo.EntregarEncomiendaEnAgencia
{
    public class Guia
    {
        // Inicializados para cumplir no-nullable
        public string NumeroGuia { get; set; } = string.Empty;
        public string Tamanio { get; set; } = string.Empty;
        public string DniDestinatario { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty; // Agencia/CD o vacío si Entregada
    }
}