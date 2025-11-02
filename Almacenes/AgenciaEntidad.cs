namespace TUTASAPrototipo.Almacenes
{
    public class AgenciaEntidad
    {
        public string ID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public int CodigoPostal { get; set; }
        public int CodigoPostalCD { get; set; }
    }
}