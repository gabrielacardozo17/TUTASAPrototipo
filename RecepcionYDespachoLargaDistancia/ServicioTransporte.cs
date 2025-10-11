using System.Collections.Generic;

namespace TUTASAPrototipo.RecepcionYDespachoLargaDistancia
{
    public class ServicioTransporte
    {
        public string NumeroServicio { get; set; }
        public List<Guia> GuiasARecibir { get; set; }
        public List<Guia> GuiasADespachar { get; set; }

        public ServicioTransporte()
        {
            GuiasARecibir = new List<Guia>();
            GuiasADespachar = new List<Guia>();
        }
    }
}