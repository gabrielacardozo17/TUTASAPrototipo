namespace TUTASAPrototipo.Almacenes
{
    public class ServicioTransporteEntidad
    {
        public int IdServicioTransporte { get; set; }
        public string RecorridoServicioTransporte { get; set; } = string.Empty;
        public int CapacidadBodega { get; set; }
        public int IdEmpresaTransporte { get; set; }
    }
}
