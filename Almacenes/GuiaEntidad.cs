using System;
using System.Collections.Generic;

namespace TUTASAPrototipo.Almacenes
{
    public class GuiaEntidad
    {
        public int NumeroGuia { get; set; }
        public EstadoGuiaEnum Estado { get; set; }
        public DateTime FechaAdmision { get; set; }
        public EntregaEnum TipoEntrega { get; set; }
        public int CodigoPostalCDOrigen { get; set; }
        public int CodigoPostalCDDestino { get; set; }
        public int IDAgenciaOrigen { get; set; }
        public int IDAgenciaDestino { get; set; }
        public string CUITCliente { get; set; } = string.Empty;
        public TamanoEnum Tamano { get; set; }
        public DestinatarioAux Destinatario { get; set; }
        public int IDConvenio { get; set; }
        public decimal ImporteAFacturar { get; set; }
        public decimal ComisionAgenciaOrigen { get; set; }
        public decimal ComisionAgenciaDestino { get; set; }
        public decimal ComisionFleteroOrigen { get; set; }
        public decimal ComisionFleteroDestino { get; set; }
        public List<RegistroEstadoAux> Historial { get; set; }
    }
}
