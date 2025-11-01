using System.Collections.Generic;

namespace TUTASAPrototipo.Almacenes
{
    public class ServicioTransporteEntidad
    {
        // Backing para compatibilidad entre Id (c�digo existente) e ID (diagrama)
        private int _id;

        // Nuevo seg�n diagrama
        public int ID
        {
            get => _id;
            set => _id = value;
        }

        // Compatibilidad con c�digo existente (sigue funcionando s.Id)
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public int CapacidadBodega { get; set; }

        // Nuevo seg�n diagrama: referencia por ID en vez de navegaci�n
        public int IDEmpresaTransporte { get; set; }

        // Nuevo seg�n diagrama: lista de tramos del servicio
        public List<Tramo> Tramos { get; set; } = new();
    }
}
