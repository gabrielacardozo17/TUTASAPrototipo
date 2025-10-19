namespace TUTASAPrototipo.Almacenes
{
    public class ClienteEntidad
    {
        public string Cuit { get; set; } = string.Empty;
        public string RazonSocial { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public int IdConvenio { get; set; }
    }
}
