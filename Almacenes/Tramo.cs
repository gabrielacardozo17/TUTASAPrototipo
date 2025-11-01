using System;

namespace TUTASAPrototipo.Almacenes
{
    public class Tramo
    {
        public int ID { get; set; }
        public int CodigoPostalOrigen { get; set; }
        public DateTime Salida { get; set; }
        public int CodigoPostalDestino { get; set; }
        public DateTime Llegada { get; set; }
    }
}
