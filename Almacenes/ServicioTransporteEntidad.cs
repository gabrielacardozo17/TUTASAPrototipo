using System.Collections.Generic;

namespace TUTASAPrototipo.Almacenes
{
    public class ServicioTransporteEntidad
    {
        // Backing para compatibilidad entre Id (código existente) e ID (diagrama)
        private int _id;

        // Nuevo según diagrama
        public int ID
        {
            get => _id;
            set => _id = value;
        }

        // Compatibilidad con código existente (sigue funcionando s.Id)
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public int CapacidadBodega { get; set; }

        // Nuevo según diagrama: referencia por ID en vez de navegación
        public int IDEmpresaTransporte { get; set; }

        // Nuevo según diagrama: lista de tramos del servicio
        public List<Tramo> Tramos { get; set; } = new();
    }
}
