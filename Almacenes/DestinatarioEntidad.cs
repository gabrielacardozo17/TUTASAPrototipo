namespace TUTASAPrototipo.Almacenes
{
    public class DestinatarioAux
    {
        public int DNI { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public LocalidadEntidad Localidad { get; set; }
        public string Direccion { get; set; } = string.Empty;
        public int CodigoPostal { get; set; }
    }
}
