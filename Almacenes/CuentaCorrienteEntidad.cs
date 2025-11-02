using System.Collections.Generic;

namespace TUTASAPrototipo.Almacenes
{
    public class CuentaCorrienteEntidad
    {
        // Según diagrama
        public string ID { get; set; } = string.Empty;
        public string CUITCliente { get; set; }
        public List<MovimientoClienteAux> Movimientos { get; set; }
    }
}
