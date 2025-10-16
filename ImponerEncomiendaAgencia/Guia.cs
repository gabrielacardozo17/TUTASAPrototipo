namespace TUTASAPrototipo.ImponerEncomiendaAgencia
{
    public class Guia
    {
        public string Numero { get; set; } = "";
        public string Estado { get; set; } = string.Empty;

        public string CuitRemitente { get; set; } = "";
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
        public int? AgenciaId { get; set; }
        public string? AgenciaNombre { get; set; }
        public int? CDId { get; set; }
        public string? CDNombre { get; set; }

        public int CantS { get; set; }
        public int CantM { get; set; }
        public int CantL { get; set; }
        public int CantXL { get; set; }

        public string? UbicacionActualTipo { get; set; }
        public int? UbicacionActualId { get; set; }
        public string? Tamano { get; set; }
    }
}
