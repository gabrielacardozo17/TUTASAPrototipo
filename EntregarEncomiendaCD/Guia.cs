namespace TUTASAPrototipo.EntregarEncomiendaCD
{
    public class Guia
    {
        public string NumeroGuia { get; set; }
        public Tamanio Tamanio { get; set; }
        public string DniDestinatario { get; set; }
        public string CDDestino { get; set; }
        public bool Entregada { get; set; }
    }
}