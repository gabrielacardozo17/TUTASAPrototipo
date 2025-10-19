namespace TUTASAPrototipo.Almacenes
{
    public class DestinatarioEntidad
    {
        public int DniDestinatario { get; set; }
        public string NombreDestinatario { get; set; } = string.Empty;
        public string ApellidoDestinatario { get; set; } = string.Empty;
        public string LocalidadDestinatario { get; set; } = string.Empty;
        public string DireccionDestinatario { get; set; } = string.Empty;
        public int CodigoPostalDestinatario { get; set; }
    }
}
