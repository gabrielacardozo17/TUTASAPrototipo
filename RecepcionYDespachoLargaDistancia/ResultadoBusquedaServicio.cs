using System.Collections.Generic;

namespace TUTASAPrototipo.RecepcionYDespachoLargaDistancia
{
    public class ResultadoBusquedaServicio
    {
        public List<Guia> aRecibir { get; set; } = new List<Guia>();
        public List<Guia> aDespachar { get; set; } = new List<Guia>();
    }
}