using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTASAPrototipo.MonitoreoResultados
{
    internal class CostoMensual
    { 
        public int Año { get; set; } //año 
        public int Mes {  get; set; } //mes
        public decimal Monto { get; set; } //costo asociado a dicho mes y año 
    }
}
