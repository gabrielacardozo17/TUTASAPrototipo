namespace TUTASAPrototipo.Domain
{
    public class Guia
    {
        // Identificación
        public string Numero { get; set; } = "";

        // Estado (enum definido en Enums.cs)
        public EstadoGuia Estado { get; set; } = EstadoGuia.AdmitidaEnCDOrigen;

        // Remitente
        public string CuitRemitente { get; set; } = "";

        // Destinatario (tu clase ya creada)
        public Destinatario Destinatario { get; set; } = new Destinatario();

        // Origen (CD donde se impone)
        public int CdOrigenId { get; set; }
        public string CdOrigenNombre { get; set; } = "";

        // Destino (sin crear más clases)
        public int ProvinciaId { get; set; }
        public string ProvinciaNombre { get; set; } = "";
        public int? LocalidadId { get; set; }
        public string? LocalidadNombre { get; set; }
        public bool LocalidadEsOtras { get; set; }

        // Tipo de entrega (enum definido en Enums.cs)
        public TipoEntrega TipoEntrega { get; set; }

        // Campos según tipo de entrega
        public string? Direccion { get; set; }       // solo si Domicilio
        public string? CodigoPostal { get; set; }    // solo si Domicilio
        public int? AgenciaId { get; set; }          // solo si En Agencia
        public string? AgenciaNombre { get; set; }   // solo si En Agencia
        public int? CDId { get; set; }               // solo si En CD
        public string? CDNombre { get; set; }        // solo si En CD

        // Bultos (tallas)
        public int CantS { get; set; }
        public int CantM { get; set; }
        public int CantL { get; set; }
        public int CantXL { get; set; }

        // (Opcional para futuro tracking, no usado aún)
        public string? UbicacionActualTipo { get; set; } // "CD" / "Agencia" / "Fletero" / "Omnibus"
        public int? UbicacionActualId { get; set; }

        //
        public TamanoBulto? Tamano { get; set; }   // tamaño de esta guía (1 bulto)

    }
}
