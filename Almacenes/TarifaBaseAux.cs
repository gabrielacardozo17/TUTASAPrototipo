using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTASAPrototipo.Almacenes
{
    public class TarifaBaseAux
    {
        public Dictionary<TamanoEnum, decimal> PreciosXTamano { get; set; }
        public int CodigoPostalOrigen { get; set; }
        public int CodigoPostalDestino { get; set; }
    }
}
