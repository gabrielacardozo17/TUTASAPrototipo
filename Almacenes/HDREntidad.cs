using System.Collections.Generic;

namespace TUTASAPrototipo.Almacenes
{
    public class HDREntidad
    {
        public string ID { get; set; }
        public TipoHDREnum TipoHDR { get; set; }
        public int DNIFletero { get; set; }
        public int IDServicioTransporte { get; set; }
        
        //REVISAR CON ANDRES (EN EL DIAGRAMA DE CLASES HACEMOS UNA LISTA DE int)
        public List<GuiaEntidad> Guias { get; set; }
        public int CodigoPostalOrigen { get; set; }
        public int CodigoPostalDestino { get; set; }
    }
}
