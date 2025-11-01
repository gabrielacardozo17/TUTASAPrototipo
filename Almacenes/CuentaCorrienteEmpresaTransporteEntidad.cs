using System.Collections.Generic;

namespace TUTASAPrototipo.Almacenes
{
    public class CuentaCorrienteEmpresaTransporteEntidad
    {
        public string ID { get; set; } = string.Empty;
        public int IDEmpresaTransporte { get; set; }
        public List<MovimientoEmpresaTransporteAux> Movimientos { get; set; }
    }
}
