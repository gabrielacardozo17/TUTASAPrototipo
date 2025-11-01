using System;

namespace TUTASAPrototipo.Almacenes
{
    public class MovimientoClienteAux
    {
        public int IDFactura { get; set; }
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public decimal SaldoActual { get; set; }
    }
}
