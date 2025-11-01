using System.Collections.Generic;

namespace TUTASAPrototipo.Almacenes
{
    public class ConvenioClienteEntidad
    {
        public int ID { get; set; }
        public string CUITCliente { get; set; } = string.Empty;
        public Dictionary<ExtrasEnum, decimal> Extras { get; set; }
        public List<TarifaBaseAux> TarifasPorOrigenDestino { get; set; }
    }
}
