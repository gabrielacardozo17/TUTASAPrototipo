using System.Collections.Generic;

namespace TUTASAPrototipo.Almacenes
{
    public class CuentaCorrienteEntidad
    {
        // Seg�n diagrama
        public string ID { get; set; }
        public int CUITCliente { get; set; }

        public List<MovimientoCliente> Movimientos { get; set; } = new();
    }
}
