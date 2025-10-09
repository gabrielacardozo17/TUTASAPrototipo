using System;
using System.Collections.Generic;
using System.Linq;

namespace TUTASAPrototipo.EntregarEncomiendaEnAgencia
{
    // -------------------------------------------------------------------------
    // ENUMS
    // -------------------------------------------------------------------------
    public enum Tamanio
    {
        S,
        M,
        L,
        XL
    }

    // -------------------------------------------------------------------------
    // CLASES DE DOMINIO
    // -------------------------------------------------------------------------
    public class Destinatario
    {
        public required string DNI { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
    }

    public class Guia
    {
        public string NumeroGuia { get; set; }
        public Tamanio Tamanio { get; set; }
        public required string DniDestinatario { get; set; }
        public required string AgenciaDestino { get; set; } // Campo clave para este caso de uso
        public bool Entregada { get; set; }
    }

    // -------------------------------------------------------------------------
    // MODELO DE LA PANTALLA
    // -------------------------------------------------------------------------
    public class EntregarEncomiendaEnAgenciaModelo
    {
        public List<Destinatario> Destinatarios { get; set; }
        public List<Guia> GuiasPendientes { get; set; }

        public EntregarEncomiendaEnAgenciaModelo()
        {
            // Carga de datos de prueba
            InicializarDatos();
        }

        private void InicializarDatos()
        {
            Destinatarios = new List<Destinatario>
    {
            new Destinatario { DNI = "22333444", Nombre = "Ana", Apellido = "Lopez" },
            new Destinatario { DNI = "33444555", Nombre = "Luis", Apellido = "Martinez" },
            new Destinatario { DNI = "12345678", Nombre = "Juan", Apellido = "Perez" }
    };

            GuiasPendientes = new List<Guia>
    {
        // CORREGIDO: Se eliminaron los espacios en blanco de "AgenciaDestino"
            new Guia { NumeroGuia = "AG-101", Tamanio = Tamanio.S, DniDestinatario = "22333444", AgenciaDestino = "FLORES-01", Entregada = false },
            new Guia { NumeroGuia = "AG-102", Tamanio = Tamanio.M, DniDestinatario = "22333444", AgenciaDestino = "FLORES-01", Entregada = false },
            new Guia { NumeroGuia = "AG-103", Tamanio = Tamanio.L, DniDestinatario = "33444555", AgenciaDestino = "BELGRANO-03", Entregada = false },
            new Guia { NumeroGuia = "CD-001", Tamanio = Tamanio.S, DniDestinatario = "12345678", AgenciaDestino = "FLORES-01", Entregada = true }
    };
        }

        // -------------------------------------------------------------------------
        // LÓGICA DE NEGOCIO (VALIDACIONES N3-N4)
        // -------------------------------------------------------------------------

        public Destinatario BuscarDestinatarioPorDNI(string dni)
        {
            return Destinatarios.FirstOrDefault(d => d.DNI == dni);
        }

        public List<Guia> BuscarGuiasPendientes(string dni, string agenciaActual)
        {
            // Busca guías pendientes de entrega para un DNI en la agencia actual.
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
            return true; // Simula éxito en la actualización
        }
    }
}