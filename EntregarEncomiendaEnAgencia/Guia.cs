namespace TUTASAPrototipo.EntregarEncomiendaEnAgencia
{
    public class Guia
    {
        public required string NumeroGuia { get; set; }
        public Tamanio Tamanio { get; set; }
        public required string DniDestinatario { get; set; }
        public required string AgenciaDestino { get; set; }
        public bool Entregada { get; set; }
    }
}