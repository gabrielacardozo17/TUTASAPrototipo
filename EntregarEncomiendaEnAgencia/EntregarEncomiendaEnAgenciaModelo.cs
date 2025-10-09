using System.Collections.Generic;
using System.Linq;
using TUTASAPrototipo.EntregarEncomiendaCD;

namespace TUTASAPrototipo.EntregarEncomiendaEnAgencia
{
    public class EntregarEncomiendaEnAgenciaModelo
    {
        public List<Destinatario> Destinatarios { get; set; }
        public List<Guia> GuiasPendientes { get; set; }

        public EntregarEncomiendaEnAgenciaModelo()
        {
            InicializarDatos();
        }
        private void InicializarDatos()
        {
            Destinatarios = new List<Destinatario>
    {
        // Datos de prueba mejorados
            new Destinatario { DNI = "32987654", Nombre = "Julieta", Apellido = "Gomez" },
            new Destinatario { DNI = "35432109", Nombre = "Matias", Apellido = "Fernandez" },
            new Destinatario { DNI = "27123456", Nombre = "Pedro", Apellido = "Rodriguez" }
    };

            GuiasPendientes = new List<Guia>
    {
        // CORREGIDO: Nombres de agencias y datos de prueba actualizados
            new Guia { NumeroGuia = "001100101", Tamanio = Tamanio.S, DniDestinatario = "32987654", AgenciaDestino = "CABA - Flores", Entregada = false },
            new Guia { NumeroGuia = "001100102", Tamanio = Tamanio.M, DniDestinatario = "32987654", AgenciaDestino = "CABA - Flores", Entregada = false },
            new Guia { NumeroGuia = "001200103", Tamanio = Tamanio.L, DniDestinatario = "35432109", AgenciaDestino = "CABA - Belgrano", Entregada = false },
            new Guia { NumeroGuia = "100300001", Tamanio = Tamanio.S, DniDestinatario = "27123456", AgenciaDestino = "Rosario", Entregada = true } // Guía para otro destino y ya entregada
    };
        }

        public Destinatario BuscarDestinatarioPorDNI(string dni)
        {
            return Destinatarios.FirstOrDefault(d => d.DNI == dni);
        }

        public List<Guia> BuscarGuiasPendientes(string dni, string agenciaActual)
        {
            return GuiasPendientes.Where(g => g.DniDestinatario == dni && g.AgenciaDestino == agenciaActual && !g.Entregada).ToList();
        }

        public bool ConfirmarEntrega(List<string> numerosDeGuia)
        {
            foreach (var numeroGuia in numerosDeGuia)
            {
                var guia = GuiasPendientes.FirstOrDefault(g => g.NumeroGuia == numeroGuia);
                if (guia != null)
                {
                    guia.Entregada = true;
                }
            }
            return true;
        }
    }
}