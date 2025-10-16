using System;

namespace TUTASAPrototipo.EmitirFactura
{
    public class Guia
    {
        public string Numero { get; set; } = "";
        public DateTime FechaAdmision { get; set; }
        public string Origen { get; set; } = "";
        public string Destino { get; set; } = "";
        public string Tamano { get; set; } = "";
        public decimal Importe { get; set; }
        public string Estado { get; set; } = "";

        // vínculo con el cliente a facturar
        public string CuitCliente { get; set; } = "";
    }
}
