using System;
using System.Collections.Generic;

namespace TUTASAPrototipo.Almacenes
{
    public class FacturaEntidad
    {
        public string ID { get; set; }
        public DateTime FechaEmisionFactura { get; set; }
        public string CUITCliente { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public List<int> GuiasFacturadas { get; set; }
    }
}