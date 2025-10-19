namespace TUTASAPrototipo.ImponerEncomiendaAgencia
{
    public class Guia
    {
        public string NumeroGuia { get; set; } = "";
        public string Estado { get; set; } = string.Empty;

        public string CUIT { get; set; } = "";
        public Destinatario Destinatario { get; set; } = new Destinatario();

        public int CdOrigenId { get; set; }
        public string CdOrigenNombre { get; set; } = "";

        public int ProvinciaId { get; set; }
        public string ProvinciaNombre { get; set; } = "";
        public int? LocalidadId { get; set; }
        public string? LocalidadNombre { get; set; }
        public bool LocalidadEsOtras { get; set; }

        public string TipoEntrega { get; set; } = string.Empty;
        public string? Direccion { get; set; }
        public string? CodigoPostal { get; set; }
        public string? NombreAgencia { get; set; }
        public string? NombreCD { get; set; }

        public int CantPorTamanio { get; set; }
        public string? Tamanio { get; set; }

        public string? Ubicacion { get; set; }
    }
}
