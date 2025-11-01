using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTASAPrototipo.Almacenes
{
    public class TarifaBase
    {
        public Dictionary<TamanoEnumeracion, decimal> PreciosXTamano { get; set; }
        public int CodPostalOrigen { get; set; }
        public int CodPostalDestino { get; set; }
    }
}
