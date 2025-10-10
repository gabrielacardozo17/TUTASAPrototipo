using System.Collections.Generic;
using System.Linq;

namespace TUTASAPrototipo.RecepcionYDespachoLargaDistancia
{
    public class RecepcionYDespachoLargaDistanciaModelo
    {
        public List<ServicioTransporte> Servicios { get; set; }
        public List<Guia> Guias { get; set; }

        public RecepcionYDespachoLargaDistanciaModelo()
        {
            InicializarDatos();
        }

        private void InicializarDatos()
        {
            // Datos de prueba para Servicios de Transporte
            Servicios = new List<ServicioTransporte>
            {
                new ServicioTransporte { Numero = "1234567", Empresa = "Andesmar" },
                new ServicioTransporte { Numero = "8765432", Empresa = "FlechaBus" }
            };

            // Catálogo completo de Guías, con algunas asignadas a los servicios de prueba
            Guias = new List<Guia>
            {
                // -- Guías A DESPACHAR desde CABA Oeste en el servicio 1234567 --
                new Guia { NroGuia = "104000011", Tamano = "XL", Destino = "CD Córdoba Capital", Estado = "Admitido", ServicioAsignado = "1234567" },
                new Guia { NroGuia = "104000012", Tamano = "S", Destino = "CD Córdoba Capital", Estado = "Admitido", ServicioAsignado = "1234567" },
                
                // -- Guías A RECIBIR en CABA Oeste desde el servicio 1234567 --
                new Guia { NroGuia = "000200001", Tamano = "L", Destino = "CD CABA Oeste", Estado = "En tránsito al CD destino", ServicioAsignado = "1234567" },
                new Guia { NroGuia = "000200002", Tamano = "XL", Destino = "CD CABA Oeste", Estado = "En tránsito al CD destino", ServicioAsignado = "1234567" },

                // -- Guías para el servicio 8765432 --
                new Guia { NroGuia = "009000045", Tamano = "L", Destino = "CD Tucumán", Estado = "Admitido", ServicioAsignado = "8765432" },
                new Guia { NroGuia = "108200029", Tamano = "XL", Destino = "CD CABA Oeste", Estado = "En tránsito al CD destino", ServicioAsignado = "8765432" },

                // -- Resto del catálogo de guías (no asignadas a estos servicios) --
                new Guia { NroGuia = "101000015", Tamano = "S", Destino = "CD 0040", Estado = "En ruta a CD de origen", ServicioAsignado = null },
                new Guia { NroGuia = "001004567", Tamano = "M", Destino = "Domicilio", Estado = "En ruta al domicilio de entrega", ServicioAsignado = null },
                new Guia { NroGuia = "007000150", Tamano = "S", Destino = "Ag. 1011", Estado = "En ruta a la agencia de entrega", ServicioAsignado = null },
                new Guia { NroGuia = "101100005", Tamano = "M", Destino = "Ag. 1011", Estado = "En espera de retiro en agencia", ServicioAsignado = null },
                new Guia { NroGuia = "102400007", Tamano = "L", Destino = "Domicilio", Estado = "En espera de retiro al cliente", ServicioAsignado = null },
                new Guia { NroGuia = "011000077", Tamano = "XL", Destino = "Domicilio", Estado = "En ruta al domicilio de entrega", ServicioAsignado = null },
                new Guia { NroGuia = "108000023", Tamano = "S", Destino = "", Estado = "Entregada", ServicioAsignado = null },
                new Guia { NroGuia = "101000016", Tamano = "M", Destino = "CD 0040", Estado = "En ruta a CD de origen", ServicioAsignado = null },
                new Guia { NroGuia = "001004568", Tamano = "L", Destino = "Domicilio", Estado = "En ruta al domicilio de entrega", ServicioAsignado = null },
                new Guia { NroGuia = "007000151", Tamano = "M", Destino = "Ag. 1011", Estado = "En ruta a la agencia de entrega", ServicioAsignado = null },
                new Guia { NroGuia = "101100006", Tamano = "L", Destino = "Ag. 1011", Estado = "En espera de retiro en agencia", ServicioAsignado = null },
                new Guia { NroGuia = "108000024", Tamano = "M", Destino = "", Estado = "Entregada", ServicioAsignado = null }
                // ... (se puede continuar pegando el resto de la lista de guías aquí si es necesario)
            };
        }

        // Reemplazar este método en RecepcionYDespachoLargaDistanciaModelo.cs

        public bool ExisteServicio(string nroServicio)
        {
            // Normaliza el input y los datos del modelo para comparar correctamente
            string servicioLimpio = nroServicio.Trim().ToUpper();
            return Servicios.Any(s => s.Numero.Trim().ToUpper() == servicioLimpio);
        }

        // Reemplazar este método en RecepcionYDespachoLargaDistanciaModelo.cs

        public ResultadoBusquedaServicio BuscarGuiasPorServicio(string nroServicio)
        {
            var resultado = new ResultadoBusquedaServicio();
            string cdActual = "CD CABA Oeste";
            string servicioLimpio = nroServicio.Trim(); // Limpiamos el número de servicio

            // Buscamos guías donde el servicio coincida EXACTAMENTE después de limpiarlo.
            resultado.aRecibir = Guias.Where(e => e.ServicioAsignado.Trim() == servicioLimpio &&
                                                   e.Estado == "En tránsito al CD destino" &&
                                                   e.Destino == cdActual).ToList();

            resultado.aDespachar = Guias.Where(e => e.ServicioAsignado.Trim() == servicioLimpio &&
                                                    e.Estado == "Admitido").ToList();

            return resultado;
        }

        public void ActualizarEstadoGuia(string nroGuia, string nuevoEstado)
        {
            var guia = Guias.FirstOrDefault(g => g.NroGuia == nroGuia);
            if (guia != null)
            {
                guia.Estado = nuevoEstado;
            }
        }
    }
}