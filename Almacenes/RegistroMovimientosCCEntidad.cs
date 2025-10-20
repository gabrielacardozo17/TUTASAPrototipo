using System;

namespace TUTASAPrototipo.Almacenes
{
    public class RegistroMovimientosCCEntidad
    {
        public int IDMovimientosCC { get; set; }
        public int IDFactura { get; set; }
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; } = string.Empty;
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public decimal SaldoActual { get; set; }
    }
}
