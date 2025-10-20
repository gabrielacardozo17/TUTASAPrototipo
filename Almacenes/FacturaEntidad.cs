using System;

namespace TUTASAPrototipo.Almacenes
{
    // Se usa nombre distinto para no colisionar con EmitirFactura.Factura
    public class FacturaEntidad
    {
        public string IDFactura { get; set; } = string.Empty;
        public DateTime FechaEmisionFactura { get; set; }
        public string CUITCliente { get; set; } = string.Empty;
        public decimal Total { get; set; }
    }
}
