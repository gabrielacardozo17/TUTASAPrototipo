namespace TUTASAPrototipo.Almacenes
{
    public class ClienteEntidad
    {
        public string CUIT { get; set; } = string.Empty;
        public string RazonSocial { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public int IDConvenio { get; set; }
        public int CodigoPostal { get; set; }
    }
}
