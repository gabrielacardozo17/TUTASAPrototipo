using System;

namespace TUTASAPrototipo.Almacenes
{
    public class GuiaEntidad
    {
        public int NumeroGuia { get; set; }
        public EstadoGuia Estado { get; set; }
        public string Ubicacion { get; set; } = string.Empty;
        public DateTime FechaAdmision { get; set; }
        public TipoEntrega TipoEntrega { get; set; }
        public bool LocalidadEsOtras { get; set; }
        public int IdCDOrigen { get; set; }
        public int IdCDDestino { get; set; }
        public int IdAgenciaOrigen { get; set; }
        public int IdAgenciaDestino { get; set; }
        public string CUIT { get; set; } = string.Empty;
        public Tamano Tamano { get; set; }
        public int DniDestinatario { get; set; }
        public string IdHDR { get; set; } = string.Empty;
    }
}
