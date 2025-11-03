using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTASAPrototipo.EstadoCuentaCorrienteCliente
{
    internal class MovimientoCuenta
    {
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        // Saldo acumulado después del movimiento
        public decimal Saldo { get; set; }
    }
}
