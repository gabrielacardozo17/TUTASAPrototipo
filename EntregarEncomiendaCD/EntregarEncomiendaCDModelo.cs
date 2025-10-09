using System;
using System.Collections.Generic;
using System.Linq;

namespace TUTASAPrototipo.EntregarEncomiendaCD
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
        public required string NumeroGuia { get; set; }
        public Tamanio Tamanio { get; set; }
        public required string DniDestinatario { get; set; }
        public required string CDDestino { get; set; }
        public bool Entregada { get; set; }
    }

    // -------------------------------------------------------------------------
    // MODELO DE LA PANTALLA
    // -------------------------------------------------------------------------
    public class EntregarEncomiendaCDModelo
    {
        public List<Destinatario> Destinatarios { get; set; }
        public List<Guia> GuiasPendientes { get; set; }

        public EntregarEncomiendaCDModelo()
        {
            // Carga de datos de prueba
            InicializarDatos();
        }
        private void InicializarDatos()
        {
            Destinatarios = new List<Destinatario>
    {
        new Destinatario { DNI = "12345678", Nombre = "Juan", Apellido = "Perez" },
        new Destinatario { DNI = "87654321", Nombre = "Maria", Apellido = "Gomez" },
        new Destinatario { DNI = "11223344", Nombre = "Carlos", Apellido = "Rodriguez" }
    };

            GuiasPendientes = new List<Guia>
    {
        // CORREGIDO: Números de guía con formato T LLL NNNNN
        // T=1 (CD), LLL=001 (CABA OESTE)
        new Guia { NumeroGuia = "100100001", Tamanio = Tamanio.S, DniDestinatario = "12345678", CDDestino = "CABA OESTE", Entregada = false },
        new Guia { NumeroGuia = "100100002", Tamanio = Tamanio.M, DniDestinatario = "12345678", CDDestino = "CABA OESTE", Entregada = false },
        new Guia { NumeroGuia = "100100003", Tamanio = Tamanio.L, DniDestinatario = "87654321", CDDestino = "CABA OESTE", Entregada = false },
        // T=1 (CD), LLL=002 (CABA SUR)
        new Guia { NumeroGuia = "100200004", Tamanio = Tamanio.XL, DniDestinatario = "11223344", CDDestino = "CABA SUR", Entregada = false }
    };
        }

        // -------------------------------------------------------------------------
        // LÓGICA DE NEGOCIO (VALIDACIONES N3-N4)
        // -------------------------------------------------------------------------

        public Destinatario BuscarDestinatarioPorDNI(string dni)
        {
            // Simula la búsqueda de un destinatario en la base de datos.
            return Destinatarios.FirstOrDefault(d => d.DNI == dni);
        }

        public List<Guia> BuscarGuiasPendientes(string dni, string cdActual)
        {
            // Busca guías pendientes de entrega para un DNI en el CD actual.
            return GuiasPendientes.Where(g => g.DniDestinatario == dni && g.CDDestino == cdActual && !g.Entregada).ToList();
        }

        public bool ConfirmarEntrega(List<string> numerosDeGuia)
        {
            // Simula la actualización del estado de las guías a "Entregada".
            foreach (var numeroGuia in numerosDeGuia)
            {
                var guia = GuiasPendientes.FirstOrDefault(g => g.NumeroGuia == numeroGuia);
                if (guia != null)
                {
                    guia.Entregada = true;
                }
            }
            // En un caso real, aquí se guardaría en la base de datos.
            // Retorna true si la operación fue exitosa.
            return true;
        }
    }
}