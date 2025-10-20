namespace TUTASAPrototipo.Almacenes
{
    // Clase auxiliar para representar la tarifa aplicada a una guía
    public class TarifaXGuiaAux
    {
        public int NumeroGuia { get; set; }
        public string IDFactura { get; set; } = string.Empty;
        public int IDConvenio { get; set; }
        public decimal ImporteGuia { get; set; }
        public bool EsUM { get; set; }
    }
}
