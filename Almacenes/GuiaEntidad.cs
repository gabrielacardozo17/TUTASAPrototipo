using System;
using System.Collections.Generic;

namespace TUTASAPrototipo.Almacenes
{
    public class GuiaEntidad
    {
        // Backing fields para mantener compatibilidad entre "Numero" y "NumeroGuia",
        // y entre "Entrega" y "TipoEntrega" según el nuevo diagrama.
        private int _numeroGuia;
        private EntregaEnum _tipoEntrega;

        // Nuevo según diagrama
        public int NumeroGuia
        {
            get => _numeroGuia;
            set => _numeroGuia = value;
        }

        public EstadoGuiaEnum Estado { get; set; }
        public DateTime FechaAdmision { get; set; }

        public EntregaEnum TipoEntrega
        {
            get => _tipoEntrega;
            set => _tipoEntrega = value;
        }

        public int CodPostalCDOrigen { get; set; }
        public int CodPostalCDDestino { get; set; }
        public int IDAgenciaOrigen { get; set; }
        public int IDAgenciaDestino { get; set; }
        public string CUITCliente { get; set; } = string.Empty;
        public TamanoEnumeracion Tamano { get; set; }
        public DestinatarioAux Destinatario { get; set; }
        public int IDConvenio { get; set; }
        public decimal ImporteAFacturar { get; set; }
        public decimal ComisionAgenciaOrigen { get; set; }
        public decimal ComisionAgenciaDestino { get; set; }
        public decimal ComisionFleteroOrigen { get; set; }
        public decimal ComisionFleteroDestino { get; set; }
        public List<RegistroEstadoAux> Historial { get; set; } = new();

        // --------- Propiedades existentes (compatibilidad con el código actual) ---------
        // Se mantienen para no romper otras pantallas; apuntan a los mismos backing fields donde aplica.
        public int Numero
        {
            get => _numeroGuia;
            set => _numeroGuia = value;
        }

        public string Ubicacion { get; set; } = string.Empty;

        // Alias de "TipoEntrega"
        public EntregaEnum Entrega
        {
            get => _tipoEntrega;
            set => _tipoEntrega = value;
        }

        public bool SolicitaRetiro { get; set; }
        public CentroDeDistribucionEntidad? CentroDistribucionOrigen { get; set; }
        public CentroDeDistribucionEntidad? CentroDistribucionDestino { get; set; }
        public AgenciaEntidad? AgenciaOrigen { get; set; }
        public AgenciaEntidad? AgenciaDestino { get; set; }
        public ClienteEntidad Cliente { get; set; }
        public TarifaBase Tarifa { get; set; }
    }
}
