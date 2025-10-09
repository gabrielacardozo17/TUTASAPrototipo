namespace TUTASAPrototipo.RecepcionYDespachoLargaDistancia
{
    // *** Clases de Dominio Mínimas ***
    // Se definen clases sencillas para representar las entidades necesarias.

    public class Encomienda
    {
        public string NroGuia { get; set; }
        public string Tamano { get; set; } // S, M, L, XL
        public string Destino { get; set; }
        public string NroServicioAsignado { get; set; }
        public string Estado { get; set; }
    }
}
