// ===============================
// EntregarEncomiendaCDModelo.cs
// ===============================
using System.Collections.Generic;
using System.Linq;

namespace TUTASAPrototipo.EntregarEncomiendaCD
{
    public class EntregarEncomiendaCDModelo
    {
        // Garantizamos no-nulos al salir del ctor:
        public List<Destinatario> Destinatarios { get; private set; } = new();
        public List<Guia> Guias { get; private set; } = new();

        public EntregarEncomiendaCDModelo()
        {
            InicializarDatos();
        }

        private void InicializarDatos()
        {
            // Catálogo de Destinatarios
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
                new Destinatario { DNI = "30112233", Nombre = "Maximiliano", Apellido = "Rodriguez" }
            };

            Guias = new List<Guia>
{
                new Guia { NumeroGuia = "101000015", Tamanio = "S",  DniDestinatario = "28765432", Estado = "En ruta a CD de origen", Ubicacion = "" },
                new Guia { NumeroGuia = "001004567", Tamanio = "M",  DniDestinatario = "32198765", Estado = "En ruta al domicilio de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "000200001", Tamanio = "L",  DniDestinatario = "30456789", Estado = "En tránsito al CD destino", Ubicacion = "CD intermedio CD Rosario" },
                new Guia { NumeroGuia = "104000011", Tamanio = "XL", DniDestinatario = "25876543", Estado = "Admitida", Ubicacion = "CD Córdoba Capital" },
                new Guia { NumeroGuia = "007000150", Tamanio = "S",  DniDestinatario = "34567890", Estado = "En ruta a la agencia destino", Ubicacion = "" },
                new Guia { NumeroGuia = "101100005", Tamanio = "M",  DniDestinatario = "29876543", Estado = "En espera de retiro en agencia", Ubicacion = "Ag. CABA Flores" },
                new Guia { NumeroGuia = "102400007", Tamanio = "L",  DniDestinatario = "31234567", Estado = "En espera de retiro al cliente", Ubicacion = "Domicilio" },
                new Guia { NumeroGuia = "011000077", Tamanio = "XL", DniDestinatario = "27654321", Estado = "En ruta al domicilio de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "108000023", Tamanio = "S",  DniDestinatario = "33456789", Estado = "Entregada", Ubicacion = "" },
                new Guia { NumeroGuia = "101000016", Tamanio = "M",  DniDestinatario = "26543210", Estado = "En ruta a CD de origen", Ubicacion = "" },
                new Guia { NumeroGuia = "001004568", Tamanio = "L",  DniDestinatario = "35123456", Estado = "En ruta al domicilio de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "000200002", Tamanio = "XL", DniDestinatario = "28987654", Estado = "En tránsito al CD destino", Ubicacion = "CD intermedio CD Rosario" },
                new Guia { NumeroGuia = "104000012", Tamanio = "S",  DniDestinatario = "32765432", Estado = "Admitida", Ubicacion = "CD Córdoba Capital" },
                new Guia { NumeroGuia = "007000151", Tamanio = "M",  DniDestinatario = "29123456", Estado = "En ruta a la agencia destino", Ubicacion = "" },
                new Guia { NumeroGuia = "101100006", Tamanio = "L",  DniDestinatario = "34876543", Estado = "En espera de retiro en agencia", Ubicacion = "Ag. CABA Flores" },
                new Guia { NumeroGuia = "102400008", Tamanio = "XL", DniDestinatario = "30765432", Estado = "En espera de retiro al cliente", Ubicacion = "Domicilio" },
                new Guia { NumeroGuia = "011000078", Tamanio = "S",  DniDestinatario = "27123456", Estado = "En ruta al domicilio de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "108000024", Tamanio = "M",  DniDestinatario = "28765432", Estado = "Entregada", Ubicacion = "" },
                new Guia { NumeroGuia = "009000045", Tamanio = "L",  DniDestinatario = "32198765", Estado = "Admitida", Ubicacion = "CD Viedma" },

                // === Pendientes en CD CABA Oeste (para la pantalla) ===
                new Guia { NumeroGuia = "004000210", Tamanio = "S",  DniDestinatario = "25876543", Estado = "Pendiente de entrega", Ubicacion = "CD CABA Oeste" },
                new Guia { NumeroGuia = "017000021", Tamanio = "M",  DniDestinatario = "25876543", Estado = "Pendiente de entrega", Ubicacion = "CD CABA Oeste" },
                new Guia { NumeroGuia = "107400025", Tamanio = "XL", DniDestinatario = "28765432", Estado = "Pendiente de entrega", Ubicacion = "CD CABA Oeste" },
                new Guia { NumeroGuia = "004000311", Tamanio = "M",  DniDestinatario = "28765432", Estado = "Pendiente de entrega", Ubicacion = "CD CABA Oeste" },
                new Guia { NumeroGuia = "004000312", Tamanio = "S",  DniDestinatario = "30456789", Estado = "Pendiente de entrega", Ubicacion = "CD CABA Oeste" },
                new Guia { NumeroGuia = "004000313", Tamanio = "XL", DniDestinatario = "25876543", Estado = "Pendiente de entrega", Ubicacion = "CD CABA Oeste" },
                new Guia { NumeroGuia = "004000314", Tamanio = "L",  DniDestinatario = "34567890", Estado = "Pendiente de entrega", Ubicacion = "CD CABA Oeste" },
                new Guia { NumeroGuia = "004000315", Tamanio = "M",  DniDestinatario = "29876543", Estado = "Pendiente de entrega", Ubicacion = "CD CABA Oeste" },
                new Guia { NumeroGuia = "004000316", Tamanio = "S",  DniDestinatario = "31234567", Estado = "Pendiente de entrega", Ubicacion = "CD CABA Oeste" },
                new Guia { NumeroGuia = "004000317", Tamanio = "L",  DniDestinatario = "27654321", Estado = "Pendiente de entrega", Ubicacion = "CD CABA Oeste" },
                new Guia { NumeroGuia = "004000318", Tamanio = "M",  DniDestinatario = "33456789", Estado = "Pendiente de entrega", Ubicacion = "CD CABA Oeste" },
                new Guia { NumeroGuia = "004000319", Tamanio = "S",  DniDestinatario = "26543210", Estado = "Pendiente de entrega", Ubicacion = "CD CABA Oeste" },
                new Guia { NumeroGuia = "004000320", Tamanio = "XL", DniDestinatario = "35123456", Estado = "Pendiente de entrega", Ubicacion = "CD CABA Oeste" },
                new Guia { NumeroGuia = "004000321", Tamanio = "L",  DniDestinatario = "28987654", Estado = "Pendiente de entrega", Ubicacion = "CD CABA Oeste" },
                new Guia { NumeroGuia = "004000322", Tamanio = "M",  DniDestinatario = "32765432", Estado = "Pendiente de entrega", Ubicacion = "CD CABA Oeste" },
                new Guia { NumeroGuia = "004000323", Tamanio = "S",  DniDestinatario = "29123456", Estado = "Pendiente de entrega", Ubicacion = "CD CABA Oeste" },
                new Guia { NumeroGuia = "004000324", Tamanio = "XL", DniDestinatario = "34876543", Estado = "Pendiente de entrega", Ubicacion = "CD CABA Oeste" },
                new Guia { NumeroGuia = "004000325", Tamanio = "L",  DniDestinatario = "30765432", Estado = "Pendiente de entrega", Ubicacion = "CD CABA Oeste" },
                new Guia { NumeroGuia = "004000326", Tamanio = "M",  DniDestinatario = "27123456", Estado = "Pendiente de entrega", Ubicacion = "CD CABA Oeste" },
                new Guia { NumeroGuia = "004000327", Tamanio = "S",  DniDestinatario = "30112233", Estado = "Pendiente de entrega", Ubicacion = "CD CABA Oeste" },

                // === Pendiente en otro CD (no debe aparecer si la sesión es CABA Oeste) ===
                new Guia { NumeroGuia = "104400022", Tamanio = "S",  DniDestinatario = "35123456", Estado = "Pendiente de entrega", Ubicacion = "CD Córdoba Capital" },
                new Guia { NumeroGuia = "000100101", Tamanio = "M",  DniDestinatario = "34567890", Estado = "En ruta a la agencia destino", Ubicacion = "" },
                new Guia { NumeroGuia = "102000029", Tamanio = "L",  DniDestinatario = "29876543", Estado = "En espera de retiro al cliente", Ubicacion = "Domicilio" },
                new Guia { NumeroGuia = "010000055", Tamanio = "XL", DniDestinatario = "31234567", Estado = "En ruta al domicilio de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "105200042", Tamanio = "S",  DniDestinatario = "27654321", Estado = "Entregada", Ubicacion = "" },
                new Guia { NumeroGuia = "006000075", Tamanio = "M",  DniDestinatario = "33456789", Estado = "En ruta a CD de origen", Ubicacion = "" },
                new Guia { NumeroGuia = "109500017", Tamanio = "L",  DniDestinatario = "26543210", Estado = "A retirar en agencia de origen", Ubicacion = "Ag. Mendoza Centro" },
                new Guia { NumeroGuia = "004000089", Tamanio = "XL", DniDestinatario = "35123456", Estado = "En ruta al domicilio de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "002000061", Tamanio = "S",  DniDestinatario = "28987654", Estado = "En tránsito al CD destino", Ubicacion = "CD intermedio CD Mar del Plata" },
                new Guia { NumeroGuia = "106000022", Tamanio = "M",  DniDestinatario = "32765432", Estado = "En ruta al domicilio de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "011000081", Tamanio = "L",  DniDestinatario = "29123456", Estado = "Entregada", Ubicacion = "" },
                new Guia { NumeroGuia = "008000065", Tamanio = "XL", DniDestinatario = "34876543", Estado = "En agencia destino", Ubicacion = "Ag. Plottier" },
                new Guia { NumeroGuia = "010000066", Tamanio = "S",  DniDestinatario = "30765432", Estado = "En tránsito al CD destino", Ubicacion = "CD Viedma" },
                new Guia { NumeroGuia = "013000088", Tamanio = "M",  DniDestinatario = "27123456", Estado = "En ruta al domicilio de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "014000054", Tamanio = "L",  DniDestinatario = "28765432", Estado = "Pendiente de entrega", Ubicacion = "Ag. Godoy Cruz" },
                new Guia { NumeroGuia = "015000035", Tamanio = "XL", DniDestinatario = "32198765", Estado = "En ruta a CD de origen", Ubicacion = "" },
                new Guia { NumeroGuia = "016000029", Tamanio = "S",  DniDestinatario = "30456789", Estado = "En tránsito al CD destino", Ubicacion = "CD Rosario" },
                new Guia { NumeroGuia = "019000011", Tamanio = "XL", DniDestinatario = "29876543", Estado = "Entregada", Ubicacion = "" },
                new Guia { NumeroGuia = "101200003", Tamanio = "S",  DniDestinatario = "31234567", Estado = "En espera de retiro en agencia", Ubicacion = "Ag. Parque Patricios" },
                new Guia { NumeroGuia = "101300009", Tamanio = "M",  DniDestinatario = "27654321", Estado = "En espera de retiro al cliente", Ubicacion = "Domicilio" },
                new Guia { NumeroGuia = "104100025", Tamanio = "L",  DniDestinatario = "33456789", Estado = "En ruta a CD de origen", Ubicacion = "" },
                new Guia { NumeroGuia = "104200019", Tamanio = "XL", DniDestinatario = "26543210", Estado = "En tránsito al CD destino", Ubicacion = "CD intermedio CD Rosario" },
                new Guia { NumeroGuia = "105300018", Tamanio = "M",  DniDestinatario = "28987654", Estado = "En ruta al domicilio de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "105400014", Tamanio = "L",  DniDestinatario = "32765432", Estado = "Pendiente de entrega", Ubicacion = "Ag. Pérez" },
                new Guia { NumeroGuia = "105500013", Tamanio = "XL", DniDestinatario = "29123456", Estado = "En ruta a la agencia destino", Ubicacion = "" },
                new Guia { NumeroGuia = "106300011", Tamanio = "S",  DniDestinatario = "34876543", Estado = "En agencia destino", Ubicacion = "Ag. Tucumán Centro" },
                new Guia { NumeroGuia = "107200033", Tamanio = "M",  DniDestinatario = "30765432", Estado = "En espera de retiro en agencia", Ubicacion = "Ag. Ituzaingó" },
                new Guia { NumeroGuia = "107300045", Tamanio = "L",  DniDestinatario = "27123456", Estado = "En tránsito al CD destino", Ubicacion = "CD Corrientes" },
                new Guia { NumeroGuia = "108200029", Tamanio = "XL", DniDestinatario = "34567890", Estado = "En tránsito al CD destino", Ubicacion = "CD Viedma" },
                new Guia { NumeroGuia = "108300037", Tamanio = "S",  DniDestinatario = "29876543", Estado = "En ruta a la agencia destino", Ubicacion = "" },
                new Guia { NumeroGuia = "108400048", Tamanio = "M",  DniDestinatario = "31234567", Estado = "En agencia destino", Ubicacion = "Ag. Plottier" },
                new Guia { NumeroGuia = "108500059", Tamanio = "L",  DniDestinatario = "27654321", Estado = "Pendiente de entrega", Ubicacion = "Ag. Plottier" },
                new Guia { NumeroGuia = "108600067", Tamanio = "XL", DniDestinatario = "33456789", Estado = "Entregada", Ubicacion = "" },
            };

        }

        public Destinatario? BuscarDestinatarioPorDNI(string dni)
            => Destinatarios.FirstOrDefault(d => d.DNI == dni);

        public List<Guia> BuscarGuiasPendientes(string dni, string cdActual)
        {
            return Guias.Where(g =>
                   g.DniDestinatario == dni &&
                   g.Estado == "Pendiente de entrega" &&
                   g.Ubicacion == cdActual).ToList();
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
