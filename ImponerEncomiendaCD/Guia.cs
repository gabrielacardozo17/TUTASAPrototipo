namespace TUTASAPrototipo.ImponerEncomiendaCD
{
    public class Guia
    {
        // Identificación TLLLNNNNN
        public string NumeroGuia { get; set; } = "";

        // Estado
        public string Estado { get; set; } = "Admitida en CD de origen";

        // Remitente
        public string CUIT { get; set; } = "";

        // Destinatario
        public Destinatario Destinatario { get; set; } = new Destinatario();

        // Origen (CD donde se impone)
        public int CdOrigenId { get; set; }
        public string CdOrigenNombre { get; set; } = "";

        // Destino
        public int ProvinciaId { get; set; }
        public string ProvinciaNombre { get; set; } = "";
        public int? LocalidadId { get; set; }
        public string? LocalidadNombre { get; set; }
        public bool LocalidadEsOtras { get; set; }

        // Tipo de entrega
        public string TipoEntrega { get; set; } = string.Empty;

        // Campos según tipo de entrega
        public string? Direccion { get; set; }       // solo si Domicilio
        public string? CodigoPostal { get; set; }    // solo si Domicilio
        public string? NombreAgencia { get; set; }   // solo si En Agencia
        public string? NombreCD { get; set; }        // solo si En CD

        // Bultos (esta guía representa 1 bulto de una talla)
        public int CantPorTamanio { get; set; }
        public string? Tamanio { get; set; }

        // (Opcional para futuro tracking)
        public string? Ubicacion { get; set; } // "CD"/"Agencia"/"Fletero"/"Omnibus"
    }
}
