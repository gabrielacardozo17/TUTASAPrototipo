using System;
using System.Collections.Generic;
using System.Linq;

namespace TUTASAPrototipo.EmitirFactura
{
    public class Factura
    {
        public string Numero { get; set; } = "";
        public DateTime Fecha { get; set; } = DateTime.Now;
        public Cliente Cliente { get; set; } = new();
        public List<Guia> GuiasFacturadas { get; set; } = new();
        public decimal Total => GuiasFacturadas.Sum(g => g.Importe);
    }
}
