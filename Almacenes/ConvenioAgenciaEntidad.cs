using System.Collections.Generic;

namespace TUTASAPrototipo.Almacenes
{
 public class ConvenioAgenciaEntidad
 {
 public int IDConvenioAgencia { get; set; }
 public Dictionary<TamanoEnumeracion, decimal> PreciosXTamano { get; set; }
 }
}
