using System.Collections.Generic;

namespace TUTASAPrototipo.Almacenes
{
    public class ServicioTransporteEntidad
    {

        public int ID { get; set; }
        public int CapacidadBodega { get; set; }
        public int IDEmpresaTransporte { get; set; }
        public List<TramoAux> Tramos { get; set; }
    }
}
