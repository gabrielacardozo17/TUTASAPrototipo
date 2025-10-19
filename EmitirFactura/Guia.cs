using System;

namespace TUTASAPrototipo.EmitirFactura
{
    public class Guia
    {
        public string NumeroGuia { get; set; } = "";
        public DateTime Fecha { get; set; }
        public string Origen { get; set; } = "";
        public string Destino { get; set; } = "";
        public string Tamanio { get; set; } = "";
        public decimal Importe { get; set; }
        public string Estado { get; set; } = "";

        // vínculo con el cliente a facturar
        public string CUIT { get; set; } = "";
    }
}
