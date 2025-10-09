using System.Collections.Generic;
using System.Linq;

namespace TUTASAPrototipo.EntregarEncomiendaCD
{
    public class EntregarEncomiendaCDModelo
    {
        public List<Destinatario> Destinatarios { get; set; }
        public List<Guia> GuiasPendientes { get; set; }

        public EntregarEncomiendaCDModelo()
        {
            InicializarDatos();
        }

// Reemplazar este método en EntregarEncomiendaCDModelo.cs

private void InicializarDatos()
{
    Destinatarios = new List<Destinatario>
    {
        // He actualizado los datos para que sean más realistas, como pedía el profesor.
        new Destinatario { DNI = "27123456", Nombre = "Roberto", Apellido = "Fontanarrosa" },
        new Destinatario { DNI = "28765432", Nombre = "Omar", Apellido = "Palma" },
        new Destinatario { DNI = "30112233", Nombre = "Carlos", Apellido = "Maslaton" }
    };

    GuiasPendientes = new List<Guia>
    {
        // CORREGIDO: CDDestino actualizado a "Rosario" para que coincida con el Form.
        new Guia { NumeroGuia = "100300001", Tamanio = Tamanio.S, DniDestinatario = "27123456", CDDestino = "Rosario", Entregada = false },
        new Guia { NumeroGuia = "100300002", Tamanio = Tamanio.M, DniDestinatario = "27123456", CDDestino = "Rosario", Entregada = false },
        new Guia { NumeroGuia = "100300003", Tamanio = Tamanio.L, DniDestinatario = "28765432", CDDestino = "Rosario", Entregada = false },
        new Guia { NumeroGuia = "100200004", Tamanio = Tamanio.XL, DniDestinatario = "30112233", CDDestino = "CABA SUR", Entregada = false } // Este DNI no tendrá guías en Rosario.
    };
}

        public Destinatario BuscarDestinatarioPorDNI(string dni)
        {
            return Destinatarios.FirstOrDefault(d => d.DNI == dni);
        }

        public List<Guia> BuscarGuiasPendientes(string dni, string cdActual)
        {
            return GuiasPendientes.Where(g => g.DniDestinatario == dni && g.CDDestino == cdActual && !g.Entregada).ToList();
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