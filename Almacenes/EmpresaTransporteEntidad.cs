namespace TUTASAPrototipo.Almacenes
{
    public class EmpresaTransporteEntidad
    {
        public int ID { get; set; }
        public int IDConvenioEmpresa { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public Dictionary<BodegaEnum, decimal> PrecioPorBodegaFijoPorMes { get; set; }
    }
}
