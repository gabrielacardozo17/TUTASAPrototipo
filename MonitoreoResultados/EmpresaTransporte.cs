using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTASAPrototipo.MonitoreoResultados
{  
    internal class EmpresaTransporte
    {
        public string Nombre { get; set; } //nombre de la empresa de transporte 
        public List<CostoMensual> CostoMensual { get; set;  } //costos mensuales asociados a la empresa de transporte
        public List<VentaMensual> VentaMensual { get; set; } //ventas realizadas durante el mes
    }
}
