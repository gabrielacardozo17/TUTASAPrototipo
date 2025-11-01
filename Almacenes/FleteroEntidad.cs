using System.Collections.Generic;

namespace TUTASAPrototipo.Almacenes
{
    public class FleteroEntidad
    {
        public int DNI { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int CodigoPostalCD { get; set; }
        public Dictionary<TamanoEnum, decimal> PreciosXTamano { get; set; }
    }
}
