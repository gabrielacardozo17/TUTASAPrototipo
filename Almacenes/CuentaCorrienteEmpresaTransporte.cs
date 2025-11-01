using System.Collections.Generic;

namespace TUTASAPrototipo.Almacenes
{
    public class CuentaCorrienteEmpresaTransporte
    {
        public string ID { get; set; }

        public int IDEmpresaTransporte { get; set; }

        public List<MovimientoEmpresaTransporte> Movimientos { get; set; } = new();
    }
}
