namespace TUTASAPrototipo.ImponerEncomiendaCallCenter
{
    public class Guia
    {
        // Identificación TLLLNNNNN
        public string Numero { get; set; } = "";

        // Estado
        public string Estado { get; set; } = "Admitida en CD de origen";

        // Remitente
        public string CuitRemitente { get; set; } = "";

        // Destinatario
        public Destinatario Destinatario { get; set; } = new Destinatario();

        // Origen (en CallCenter queda en 0/“”)
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
        public int? AgenciaId { get; set; }          // solo si En Agencia
        public string? AgenciaNombre { get; set; }   // solo si En Agencia
        public int? CDId { get; set; }               // solo si En CD
        public string? CDNombre { get; set; }        // solo si En CD

        // Bultos (esta guía representa 1 bulto de una talla)
        public int CantS { get; set; }
        public int CantM { get; set; }
        public int CantL { get; set; }
        public int CantXL { get; set; }

        // (Opcional)
        public string? UbicacionActualTipo { get; set; }
        public int? UbicacionActualId { get; set; }
        public string? Tamano { get; set; }
    }
}
