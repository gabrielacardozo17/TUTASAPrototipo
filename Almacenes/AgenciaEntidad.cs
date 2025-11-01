namespace TUTASAPrototipo.Almacenes
{
    public class AgenciaEntidad
    {
        // Alias para coincidir con el diagrama sin romper referencias existentes
        public int ID
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;

        // Nuevos campos según el diagrama
        public int CodigoPostal { get; set; }
        public int CodigoPostalCD { get; set; }

        // Se mantienen para compatibilidad con el resto del proyecto
        public LocalidadEntidad Localidad { get; set; }
        public CentroDeDistribucionEntidad CentroDeDistribucion { get; set; }
    }
}