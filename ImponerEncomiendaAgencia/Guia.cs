namespace TUTASAPrototipo.ImponerEncomiendaAgencia
{
    public class Guia
    {
        public string NumeroGuia { get; set; }
        public Tamanio Tamanio { get; set; }
        public string DniDestinatario { get; set; }
        public string DireccionDestino { get; set; }
        public string CuitRemitente { get; set; }
        // Nota: Según el caso de uso, el estado inicial es "Impuesto".
        // En un modelo más complejo, aquí habría una propiedad de estado.
    }
}