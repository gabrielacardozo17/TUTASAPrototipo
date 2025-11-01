using System.Collections.Generic;

namespace TUTASAPrototipo.Almacenes
{
    public class CuentaCorrienteEmpresaTransporte
    {
        public string ID { get; set; } = string.Empty;
        public int IDEmpresaTransporte { get; set; }
        public List<MovimientoEmpresaTransporte> Movimientos { get; set; }
    }
}
