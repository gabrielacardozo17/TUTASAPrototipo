using System;

namespace TUTASAPrototipo.Almacenes
{
    public class MovimientoCCEntidad
    {
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; } = string.Empty;
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public string Referencia { get; set; } = string.Empty;
    }
}
