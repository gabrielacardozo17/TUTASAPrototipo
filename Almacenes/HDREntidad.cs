using System.Collections.Generic;

namespace TUTASAPrototipo.Almacenes
{
    public class HDREntidad
    {
        public string ID { get; set; }
        public TipoHDREnumeracion TipoHDR { get; set; }
        public int DNIFletero { get; set; }
        public int IDServicioTransporte { get; set; }
        public List<int> Guias { get; set; }
        public int CodPostalOrigen { get; set; }
        public int CodPostalDestino { get; set; }
    }
}
