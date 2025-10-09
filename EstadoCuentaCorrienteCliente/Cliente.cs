using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTASAPrototipo.EstadoCuentaCorrienteCliente
{
    internal class Cliente
    {
        public string Nombre { get; set; }
        public string CUIT { get; set; }
        public List<MovimientoCuenta> Movimientos { get; set; } = new();
    }
}
