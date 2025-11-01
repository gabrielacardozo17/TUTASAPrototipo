using System.Collections.Generic;

namespace TUTASAPrototipo.Almacenes
{
 public class ConvenioAgenciaEntidad
 {
 public int IDConvenioAgencia { get; set; }
 public Dictionary<TamanoEnum, decimal> PreciosXTamano { get; set; }
 }
}
