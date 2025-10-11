// ===============================
// EntregarEncomiendaEnAgenciaModelo.cs
// ===============================

using System.Collections.Generic;
using System.Linq;

namespace TUTASAPrototipo.EntregarEncomiendaEnAgencia
{
    public class EntregarEncomiendaEnAgenciaModelo
    {
        // Inicializadas para no quedar null al salir del ctor
        public List<Destinatario> Destinatarios { get; private set; } = new();
        public List<Guia> Guias { get; private set; } = new();

        public EntregarEncomiendaEnAgenciaModelo()
        {
            InicializarDatos();
        }

        private void InicializarDatos()
        {
            // (tus datos de prueba exactamente como los tenías)
            Destinatarios = new List<Destinatario>
            {
                new Destinatario { DNI = "28765432", Nombre = "Juan", Apellido = "Pereyra" },
                new Destinatario { DNI = "32198765", Nombre = "María", Apellido = "Ledesma" },
                new Destinatario { DNI = "30456789", Nombre = "Luis", Apellido = "Ferreyra" },
                new Destinatario { DNI = "25876543", Nombre = "Carlos", Apellido = "Gómez" },
                new Destinatario { DNI = "34567890", Nombre = "Ana", Apellido = "Rodríguez" },
                new Destinatario { DNI = "29876543", Nombre = "Pedro", Apellido = "Martínez" },
                new Destinatario { DNI = "31234567", Nombre = "Laura", Apellido = "Sánchez" },
                new Destinatario { DNI = "27654321", Nombre = "Miguel", Apellido = "Torres" },
                new Destinatario { DNI = "33456789", Nombre = "Sofía", Apellido = "Ramírez" },
                new Destinatario { DNI = "26543210", Nombre = "Diego", Apellido = "Flores" },
                new Destinatario { DNI = "35123456", Nombre = "Valeria", Apellido = "Acosta" },
                new Destinatario { DNI = "28987654", Nombre = "Jorge", Apellido = "Benítez" },
                new Destinatario { DNI = "32765432", Nombre = "Camila", Apellido = "Medina" },
                new Destinatario { DNI = "29123456", Nombre = "Matías", Apellido = "Herrera" },
                new Destinatario { DNI = "34876543", Nombre = "Luciana", Apellido = "Aguirre" },
                new Destinatario { DNI = "30765432", Nombre = "Facundo", Apellido = "Pereyra" },
                new Destinatario { DNI = "27123456", Nombre = "Lionel", Apellido = "Messi" },
                new Destinatario { DNI = "28765432", Nombre = "Angel", Apellido = "Di Maria" },
                new Destinatario { DNI = "30112233", Nombre = "Maximiliano", Apellido = "Rodriguez" }
            };

            Guias = new List<Guia>
            {
                // Tránsitos / Domicilio / Entregadas (no deben listarse)
                new Guia { NumeroGuia = "201000015", Tamanio = Tamanio.S,  DniDestinatario = "28765432", Estado = "En ruta a CD de origen", Ubicacion = "" },
                new Guia { NumeroGuia = "201000016", Tamanio = Tamanio.M,  DniDestinatario = "32198765", Estado = "En ruta al domicilio de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "201000017", Tamanio = Tamanio.L,  DniDestinatario = "30456789", Estado = "En tránsito al CD destino", Ubicacion = "CD intermedio CD Rosario" },
                new Guia { NumeroGuia = "201000018", Tamanio = Tamanio.XL, DniDestinatario = "25876543", Estado = "Admitida", Ubicacion = "CD Córdoba Capital" },
                new Guia { NumeroGuia = "201000019", Tamanio = Tamanio.S,  DniDestinatario = "31234567", Estado = "En espera de retiro al cliente", Ubicacion = "Domicilio" },
                new Guia { NumeroGuia = "201000020", Tamanio = Tamanio.M,  DniDestinatario = "33456789", Estado = "Entregada", Ubicacion = "" },

                // === PENDIENTES EN Ag. CABA Flores (sesión) ===
                new Guia { NumeroGuia = "301100001", Tamanio = Tamanio.S,  DniDestinatario = "28765432", Estado = "Pendiente de entrega", Ubicacion = "Ag. CABA Flores" },
                new Guia { NumeroGuia = "301100002", Tamanio = Tamanio.M,  DniDestinatario = "29876543", Estado = "Pendiente de entrega", Ubicacion = "Ag. CABA Flores" },
                new Guia { NumeroGuia = "301100003", Tamanio = Tamanio.L,  DniDestinatario = "34876543", Estado = "Pendiente de entrega", Ubicacion = "Ag. CABA Flores" },
                new Guia { NumeroGuia = "301100004", Tamanio = Tamanio.XL, DniDestinatario = "31234567", Estado = "Pendiente de entrega", Ubicacion = "Ag. CABA Flores" },
                new Guia { NumeroGuia = "301100005", Tamanio = Tamanio.S,  DniDestinatario = "26543210", Estado = "Pendiente de entrega", Ubicacion = "Ag. CABA Flores" },
                new Guia { NumeroGuia = "301100006", Tamanio = Tamanio.M,  DniDestinatario = "35123456", Estado = "Pendiente de entrega", Ubicacion = "Ag. CABA Flores" },
                new Guia { NumeroGuia = "301100007", Tamanio = Tamanio.L,  DniDestinatario = "28987654", Estado = "Pendiente de entrega", Ubicacion = "Ag. CABA Flores" },
                new Guia { NumeroGuia = "301100008", Tamanio = Tamanio.XL, DniDestinatario = "32765432", Estado = "Pendiente de entrega", Ubicacion = "Ag. CABA Flores" },
                new Guia { NumeroGuia = "301100009", Tamanio = Tamanio.S,  DniDestinatario = "29123456", Estado = "Pendiente de entrega", Ubicacion = "Ag. CABA Flores" },
                new Guia { NumeroGuia = "301100010", Tamanio = Tamanio.M,  DniDestinatario = "33456789", Estado = "Pendiente de entrega", Ubicacion = "Ag. CABA Flores" },
                new Guia { NumeroGuia = "301100011", Tamanio = Tamanio.L,  DniDestinatario = "27654321", Estado = "Pendiente de entrega", Ubicacion = "Ag. CABA Flores" },
                new Guia { NumeroGuia = "301100012", Tamanio = Tamanio.XL, DniDestinatario = "30765432", Estado = "Pendiente de entrega", Ubicacion = "Ag. CABA Flores" },
                new Guia { NumeroGuia = "301100013", Tamanio = Tamanio.S,  DniDestinatario = "27123456", Estado = "Pendiente de entrega", Ubicacion = "Ag. CABA Flores" },
                new Guia { NumeroGuia = "301100014", Tamanio = Tamanio.M,  DniDestinatario = "30112233", Estado = "Pendiente de entrega", Ubicacion = "Ag. CABA Flores" },

                // === Pendientes en otras Agencias (NO deben listarse si la sesión es CABA Flores) ===
                new Guia { NumeroGuia = "305000031", Tamanio = Tamanio.XL, DniDestinatario = "30456789", Estado = "Pendiente de entrega", Ubicacion = "Ag. Rosario Centro" }, // 1050
                new Guia { NumeroGuia = "305400014", Tamanio = Tamanio.L,  DniDestinatario = "32765432", Estado = "Pendiente de entrega", Ubicacion = "Ag. Pérez" },         // 1054
                new Guia { NumeroGuia = "307600042", Tamanio = Tamanio.M,  DniDestinatario = "30456789", Estado = "Pendiente de entrega", Ubicacion = "Ag. Esquina" },       // 1076
                new Guia { NumeroGuia = "308500059", Tamanio = Tamanio.L,  DniDestinatario = "27654321", Estado = "Pendiente de entrega", Ubicacion = "Ag. Plottier" },      // 1081
                new Guia { NumeroGuia = "301200003", Tamanio = Tamanio.S,  DniDestinatario = "31234567", Estado = "Pendiente de entrega", Ubicacion = "Ag. Parque Patricios" },// 1012
                new Guia { NumeroGuia = "301000101", Tamanio = Tamanio.M,  DniDestinatario = "34567890", Estado = "Pendiente de entrega", Ubicacion = "Ag. CABA Centro" },    // 1010
                new Guia { NumeroGuia = "302300021", Tamanio = Tamanio.S,  DniDestinatario = "28987654", Estado = "Pendiente de entrega", Ubicacion = "Ag. Quilmes" },        // 1023
                new Guia { NumeroGuia = "302400019", Tamanio = Tamanio.XL, DniDestinatario = "26543210", Estado = "Pendiente de entrega", Ubicacion = "Ag. Pilar" },          // 1024
                new Guia { NumeroGuia = "302500017", Tamanio = Tamanio.M,  DniDestinatario = "35123456", Estado = "Pendiente de entrega", Ubicacion = "Ag. San Isidro" },     // 1025
                new Guia { NumeroGuia = "309500017", Tamanio = Tamanio.L,  DniDestinatario = "26543210", Estado = "Pendiente de entrega", Ubicacion = "Ag. Mendoza Centro" }, // 1095
                new Guia { NumeroGuia = "309600013", Tamanio = Tamanio.M,  DniDestinatario = "28765432", Estado = "Pendiente de entrega", Ubicacion = "Ag. Godoy Cruz" },     // 1096
                new Guia { NumeroGuia = "308100021", Tamanio = Tamanio.S,  DniDestinatario = "27123456", Estado = "Pendiente de entrega", Ubicacion = "Ag. Neuquén Centro" }, // 1080

                // === En agencia destino / espera en agencia (si los estás incluyendo en filtro “amplio”) ===
                new Guia { NumeroGuia = "401000065", Tamanio = Tamanio.XL, DniDestinatario = "34876543", Estado = "En agencia destino", Ubicacion = "Ag. Plottier" },
                new Guia { NumeroGuia = "407200033", Tamanio = Tamanio.M,  DniDestinatario = "30765432", Estado = "En espera de retiro en agencia", Ubicacion = "Ag. Ituzaingó" },

                // === En CD (no aplica a esta pantalla) ===
                new Guia { NumeroGuia = "404400022", Tamanio = Tamanio.S,  DniDestinatario = "35123456", Estado = "En CD destino", Ubicacion = "CD Córdoba Capital" },
            };


        }

        // <- CAMBIO DE FIRMA para evitar "Possible null reference return"
        public Destinatario? BuscarDestinatarioPorDNI(string dni)
        {
            return Destinatarios.FirstOrDefault(d => d.DNI == dni);
        }

        public List<Guia> BuscarGuiasPendientes(string dni, string agenciaActual)
        {
            // Igual criterio que CD: solo "Pendiente de entrega" y solo en la ubicación actual
            return Guias
                .Where(g => g.DniDestinatario == dni
                            && g.Estado == "Pendiente de entrega"
                            && g.Ubicacion == agenciaActual)
                .ToList();
        }

        public bool ConfirmarEntrega(List<string> numerosDeGuia)
        {
            foreach (var numeroGuia in numerosDeGuia)
            {
                var guia = Guias.FirstOrDefault(g => g.NumeroGuia == numeroGuia);
                if (guia != null)
                {
                    guia.Estado = "Entregada";
                    guia.Ubicacion = string.Empty; // sin ubicación cuando está entregada
                }
            }
            return true;
        }
    }
}
