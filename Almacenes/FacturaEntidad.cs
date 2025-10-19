using System;

namespace TUTASAPrototipo.Almacenes
{
    // Se usa nombre distinto para no colisionar con EmitirFactura.Factura
    public class FacturaEntidad
    {
        public string IdFactura { get; set; } = string.Empty;
        public DateTime FechaEmision { get; set; }
        public string CUIT { get; set; } = string.Empty;
        public decimal Total { get; set; }
    }
}
