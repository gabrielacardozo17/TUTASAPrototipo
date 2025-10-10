using System.Collections.Generic;
using System.Linq;

namespace TUTASAPrototipo.EntregarEncomiendaCD
{
    public class EntregarEncomiendaCDModelo
    {
        public List<Destinatario> Destinatarios { get; set; }
        public List<Guia> Guias { get; set; }

        public EntregarEncomiendaCDModelo()
        {
            InicializarDatos();
        }

        private void InicializarDatos()
        {
            // Catálogo completo de Fleteros/Destinatarios extraído del PDF
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

            // Catálogo completo de Guías proporcionado
            Guias = new List<Guia>
            {
                new Guia { NumeroGuia = "101000015", Tamanio = Tamanio.S, DniDestinatario = "28765432", Estado = "En ruta a CD de origen", Ubicacion = "" },
                new Guia { NumeroGuia = "001004567", Tamanio = Tamanio.M, DniDestinatario = "32198765", Estado = "En ruta al domicilio de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "000200001", Tamanio = Tamanio.L, DniDestinatario = "30456789", Estado = "En tránsito al CD destino", Ubicacion = "CD intermedio 0050" },
                new Guia { NumeroGuia = "104000011", Tamanio = Tamanio.XL, DniDestinatario = "25876543", Estado = "Admitida", Ubicacion = "CD 0040" },
                new Guia { NumeroGuia = "007000150", Tamanio = Tamanio.S, DniDestinatario = "34567890", Estado = "En ruta a la agencia de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "101100005", Tamanio = Tamanio.M, DniDestinatario = "29876543", Estado = "En espera de retiro en agencia", Ubicacion = "Ag. 1011" },
                new Guia { NumeroGuia = "102400007", Tamanio = Tamanio.L, DniDestinatario = "31234567", Estado = "En espera de retiro al cliente", Ubicacion = "Domicilio" },
                new Guia { NumeroGuia = "011000077", Tamanio = Tamanio.XL, DniDestinatario = "27654321", Estado = "En ruta al domicilio de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "108000023", Tamanio = Tamanio.S, DniDestinatario = "33456789", Estado = "Entregada", Ubicacion = "" },
                new Guia { NumeroGuia = "101000016", Tamanio = Tamanio.M, DniDestinatario = "26543210", Estado = "En ruta a CD de origen", Ubicacion = "" },
                new Guia { NumeroGuia = "001004568", Tamanio = Tamanio.L, DniDestinatario = "35123456", Estado = "En ruta al domicilio de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "000200002", Tamanio = Tamanio.XL, DniDestinatario = "28987654", Estado = "En tránsito al CD destino", Ubicacion = "CD intermedio 0050" },
                new Guia { NumeroGuia = "104000012", Tamanio = Tamanio.S, DniDestinatario = "32765432", Estado = "Admitida", Ubicacion = "CD 0040" },
                new Guia { NumeroGuia = "007000151", Tamanio = Tamanio.M, DniDestinatario = "29123456", Estado = "En ruta a la agencia de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "101100006", Tamanio = Tamanio.L, DniDestinatario = "34876543", Estado = "En espera de retiro en agencia", Ubicacion = "Ag. 1011" },
                new Guia { NumeroGuia = "102400008", Tamanio = Tamanio.XL, DniDestinatario = "30765432", Estado = "En espera de retiro al cliente", Ubicacion = "Domicilio" },
                new Guia { NumeroGuia = "011000078", Tamanio = Tamanio.S, DniDestinatario = "27123456", Estado = "En ruta al domicilio de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "108000024", Tamanio = Tamanio.M, DniDestinatario = "28765432", Estado = "Entregada", Ubicacion = "" },
                new Guia { NumeroGuia = "009000045", Tamanio = Tamanio.L, DniDestinatario = "32198765", Estado = "Admitida", Ubicacion = "CD 0090" },
                new Guia { NumeroGuia = "105000031", Tamanio = Tamanio.XL, DniDestinatario = "30456789", Estado = "Pendiente de entrega", Ubicacion = "Ag. 1050" },
                new Guia { NumeroGuia = "004000210", Tamanio = Tamanio.S, DniDestinatario = "25876543", Estado = "En CD destino", Ubicacion = "CD CABA Oeste" }, // Relevante para la prueba
                new Guia { NumeroGuia = "000100101", Tamanio = Tamanio.M, DniDestinatario = "34567890", Estado = "En ruta a la agencia de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "102000029", Tamanio = Tamanio.L, DniDestinatario = "29876543", Estado = "En espera de retiro al cliente", Ubicacion = "Domicilio" },
                new Guia { NumeroGuia = "010000055", Tamanio = Tamanio.XL, DniDestinatario = "31234567", Estado = "En ruta al domicilio de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "105200042", Tamanio = Tamanio.S, DniDestinatario = "27654321", Estado = "Entregada", Ubicacion = "" },
                new Guia { NumeroGuia = "006000075", Tamanio = Tamanio.M, DniDestinatario = "33456789", Estado = "En ruta a CD de origen", Ubicacion = "" },
                new Guia { NumeroGuia = "109500017", Tamanio = Tamanio.L, DniDestinatario = "26543210", Estado = "A retirar en agencia de origen", Ubicacion = "Ag. 1095" },
                new Guia { NumeroGuia = "004000089", Tamanio = Tamanio.XL, DniDestinatario = "35123456", Estado = "En ruta al domicilio de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "002000061", Tamanio = Tamanio.S, DniDestinatario = "28987654", Estado = "En tránsito al CD destino", Ubicacion = "CD intermedio 0011" },
                new Guia { NumeroGuia = "106000022", Tamanio = Tamanio.M, DniDestinatario = "32765432", Estado = "En ruta al domicilio de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "011000081", Tamanio = Tamanio.L, DniDestinatario = "29123456", Estado = "Entregada", Ubicacion = "" },
                new Guia { NumeroGuia = "008000065", Tamanio = Tamanio.XL, DniDestinatario = "34876543", Estado = "En agencia destino", Ubicacion = "Ag. 1081" },
                new Guia { NumeroGuia = "010000066", Tamanio = Tamanio.S, DniDestinatario = "30765432", Estado = "En tránsito al CD destino", Ubicacion = "CD 0090" },
                new Guia { NumeroGuia = "013000088", Tamanio = Tamanio.M, DniDestinatario = "27123456", Estado = "En ruta al domicilio de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "014000054", Tamanio = Tamanio.L, DniDestinatario = "28765432", Estado = "Pendiente de entrega", Ubicacion = "Ag. 1096" },
                new Guia { NumeroGuia = "015000035", Tamanio = Tamanio.XL, DniDestinatario = "32198765", Estado = "En ruta a CD de origen", Ubicacion = "" },
                new Guia { NumeroGuia = "016000029", Tamanio = Tamanio.S, DniDestinatario = "30456789", Estado = "En tránsito al CD destino", Ubicacion = "CD 0050" },
                new Guia { NumeroGuia = "017000021", Tamanio = Tamanio.M, DniDestinatario = "25876543", Estado = "En CD destino", Ubicacion = "CD CABA Oeste" }, // Relevante para la prueba
                new Guia { NumeroGuia = "018000010", Tamanio = Tamanio.L, DniDestinatario = "34567890", Estado = "En ruta al domicilio de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "019000011", Tamanio = Tamanio.XL, DniDestinatario = "29876543", Estado = "Entregada", Ubicacion = "" },
                new Guia { NumeroGuia = "101200003", Tamanio = Tamanio.S, DniDestinatario = "31234567", Estado = "En espera de retiro en agencia", Ubicacion = "Ag. 1012" },
                new Guia { NumeroGuia = "101300009", Tamanio = Tamanio.M, DniDestinatario = "27654321", Estado = "En espera de retiro al cliente", Ubicacion = "Domicilio" },
                new Guia { NumeroGuia = "104100025", Tamanio = Tamanio.L, DniDestinatario = "33456789", Estado = "En ruta a CD de origen", Ubicacion = "" },
                new Guia { NumeroGuia = "104200019", Tamanio = Tamanio.XL, DniDestinatario = "26543210", Estado = "En tránsito al CD destino", Ubicacion = "CD intermedio 0050" },
                new Guia { NumeroGuia = "104400022", Tamanio = Tamanio.S, DniDestinatario = "35123456", Estado = "En CD destino", Ubicacion = "CD Córdoba Capital" },
                new Guia { NumeroGuia = "105300018", Tamanio = Tamanio.M, DniDestinatario = "28987654", Estado = "En ruta al domicilio de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "105400014", Tamanio = Tamanio.L, DniDestinatario = "32765432", Estado = "Pendiente de entrega", Ubicacion = "Ag. 1054" },
                new Guia { NumeroGuia = "105500013", Tamanio = Tamanio.XL, DniDestinatario = "29123456", Estado = "En ruta a la agencia de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "106300011", Tamanio = Tamanio.S, DniDestinatario = "34876543", Estado = "En agencia destino", Ubicacion = "Ag. 1060" },
                new Guia { NumeroGuia = "107200033", Tamanio = Tamanio.M, DniDestinatario = "30765432", Estado = "En espera de retiro en agencia", Ubicacion = "Ag. 1072" },
                new Guia { NumeroGuia = "107300045", Tamanio = Tamanio.L, DniDestinatario = "27123456", Estado = "En tránsito al CD destino", Ubicacion = "CD 0070" },
                new Guia { NumeroGuia = "107400025", Tamanio = Tamanio.XL, DniDestinatario = "28765432", Estado = "En CD destino", Ubicacion = "CD CABA Oeste" }, // Relevante para la prueba
                new Guia { NumeroGuia = "107500031", Tamanio = Tamanio.S, DniDestinatario = "32198765", Estado = "En ruta al domicilio de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "107600042", Tamanio = Tamanio.M, DniDestinatario = "30456789", Estado = "Pendiente de entrega", Ubicacion = "Ag. 1076" },
                new Guia { NumeroGuia = "107700019", Tamanio = Tamanio.L, DniDestinatario = "25876543", Estado = "Entregada", Ubicacion = "" },
                new Guia { NumeroGuia = "108200029", Tamanio = Tamanio.XL, DniDestinatario = "34567890", Estado = "En tránsito al CD destino", Ubicacion = "CD 0090" },
                new Guia { NumeroGuia = "108300037", Tamanio = Tamanio.S, DniDestinatario = "29876543", Estado = "En ruta a la agencia de entrega", Ubicacion = "" },
                new Guia { NumeroGuia = "108400048", Tamanio = Tamanio.M, DniDestinatario = "31234567", Estado = "En agencia destino", Ubicacion = "Ag. 1081" },
                new Guia { NumeroGuia = "108500059", Tamanio = Tamanio.L, DniDestinatario = "27654321", Estado = "Pendiente de entrega", Ubicacion = "Ag. 1081" },
                new Guia { NumeroGuia = "108600067", Tamanio = Tamanio.XL, DniDestinatario = "33456789", Estado = "Entregada", Ubicacion = "" }
            };
        }

        public Destinatario BuscarDestinatarioPorDNI(string dni)
        {
            return Destinatarios.FirstOrDefault(d => d.DNI == dni);
        }

        public List<Guia> BuscarGuiasPendientes(string dni, string cdActual)
        {
            return Guias.Where(g => g.DniDestinatario == dni &&
                                    g.Estado == "En CD destino" &&
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
                    guia.Ubicacion = "Entregado";
                }
            }
            return true;
        }
    }
}