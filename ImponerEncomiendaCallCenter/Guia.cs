using System.Collections.Generic;

namespace TUTASAPrototipo.ImponerEncomiendaCallCenter
{
    public class Guia
    {
        public string NumeroGuia { get; set; }
        public Cliente Remitente { get; set; }
        public Destinatario Destinatario { get; set; }
        public Dictionary<Tamanio, int> Encomiendas { get; set; }
        public string Estado { get; set; }
    }
}