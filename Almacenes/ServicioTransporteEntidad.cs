namespace TUTASAPrototipo.Almacenes
{
    public class ServicioTransporteEntidad
    {
        public int IDServicioTransporte { get; set; }
        public string RecorridoServicioTransporte { get; set; } = string.Empty;
        public int CapacidadBodega { get; set; }
        public int IDEmpresaTransporte { get; set; }
    }
}
