using System.Collections.Generic;

namespace TUTASAPrototipo.Almacenes
{
    public class ConvenioClienteEntidad
    {
        public int IDConvenio { get; set; }
        public string CUIT { get; set; }
        public Dictionary<ExtrasEnum, decimal> Extras { get; set; }
        public List<TarifaBase> TarifasPorOrigenDestino { get; set; }
    }
}
