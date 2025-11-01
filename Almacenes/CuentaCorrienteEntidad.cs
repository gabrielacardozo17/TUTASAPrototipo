using System.Collections.Generic;

namespace TUTASAPrototipo.Almacenes
{
    public class CuentaCorrienteEntidad
    {
        // Según diagrama
        public string ID { get; set; } = string.Empty;
        public int CUITCliente { get; set; }
        public List<MovimientoCliente> Movimientos { get; set; }
    }
}
