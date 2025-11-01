using System;

namespace TUTASAPrototipo.Almacenes
{
    public class MovimientoEmpresaTransporteAux
    {
        public string NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public decimal SaldoActual { get; set; }
    }
}
