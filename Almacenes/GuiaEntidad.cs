using System;

namespace TUTASAPrototipo.Almacenes
{
    public class GuiaEntidad
    {
        public int NumeroGuia { get; set; }
        public EstadoGuiaEnumeracion Estado { get; set; }
        public string Ubicacion { get; set; } = string.Empty;
        public DateTime FechaAdmision { get; set; }
        public EntregaEnumeracion Entrega { get; set; }
        public bool LocalidadEsOtras { get; set; }
        public int IDCDOrigen { get; set; }
        public int IDCDDestino { get; set; }
        public int IDAgenciaOrigen { get; set; }
        public int IDAgenciaDestino { get; set; }
        public string CUITCliente { get; set; } = string.Empty;
        public TamanoEnumeracion Tamano { get; set; }
        public int DNIDestinatario { get; set; }
        public string IDHDR { get; set; } = string.Empty;
    }
}
