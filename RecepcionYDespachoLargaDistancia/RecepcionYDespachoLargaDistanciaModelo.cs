namespace TUTASAPrototipo.RecepcionYDespachoLargaDistancia
{
    // *** Clases de Dominio Mínimas ***
    // Se definen clases sencillas para representar las entidades necesarias.

    public class Encomienda
    {
        public string NroGuia { get; set; }
        public string Tamano { get; set; } // S, M, L, XL
        public string Destino { get; set; }
        public string NroServicioAsignado { get; set; }
        public string Estado { get; set; }
    }

    public class ServicioTransporte
    {
        public string NroServicio { get; set; }
        public string Empresa { get; set; }
    }


    // *** Clase Modelo de la Pantalla (Datos de Prueba y Lógica N3-N4) ***
    public class RecepcionYDespachoLargaDistanciaModelo
    {
        // Datos de prueba para Encomiendas y Servicios de Transporte (Simulación de BD)
        private List<Encomienda> _encomiendas;
        private List<ServicioTransporte> _servicios;

        public RecepcionYDespachoLargaDistanciaModelo()
        {
            CargarDatosDePrueba();
        }

        private void CargarDatosDePrueba()
        {
            // Se definen servicios de prueba (NroServicio de 8 caracteres, cumpliendo N2)
            _servicios = new List<ServicioTransporte>
            {
                // Servicio 1: Mixto (Recibir y Despachar)
                new ServicioTransporte { NroServicio = "10010101", Empresa = "Empresa A - CABA/ROS"},
                // Servicio 2: Mixto (Más carga)
                new ServicioTransporte { NroServicio = "10020202", Empresa = "Empresa B - CABA/LAP"},
                // Servicio 3: Solo Despachar 
                new ServicioTransporte { NroServicio = "20030303", Empresa = "Empresa C - ROS/TUC"},
                // Servicio 4: Solo Recibir 
                new ServicioTransporte { NroServicio = "30040404", Empresa = "Empresa D - NEU/CABA"},
                // Servicio 5: Existe pero sin guías asignadas
                new ServicioTransporte { NroServicio = "50000000", Empresa = "Empresa Z - Empty"}
            };

            // Simulación de encomiendas
            _encomiendas = new List<Encomienda>
            {
                // --- Servicio 10010101 (Mixto Original) ---
                // A RECIBIR (Estado: En Viaje)
                new Encomienda { NroGuia = "T0010001", Tamano = "L", Destino = "CD CABA", NroServicioAsignado = "10010101", Estado = "En Viaje"},
                new Encomienda { NroGuia = "T0010002", Tamano = "M", Destino = "CD CABA", NroServicioAsignado = "10010101", Estado = "En Viaje"},
                // A DESPACHAR (Estado: En CD Origen)
                new Encomienda { NroGuia = "T0020005", Tamano = "S", Destino = "CD Rosario", NroServicioAsignado = "10010101", Estado = "En CD Origen"},
                new Encomienda { NroGuia = "T0020006", Tamano = "XL", Destino = "CD Rosario", NroServicioAsignado = "10010101", Estado = "En CD Origen"},
                
                // --- Servicio 10020202 (Mixto Ampliado) ---
                // A RECIBIR (Estado: En Viaje)
                new Encomienda { NroGuia = "T0030010", Tamano = "XL", Destino = "CD La Plata", NroServicioAsignado = "10020202", Estado = "En Viaje"},
                // A DESPACHAR (Estado: En CD Origen)
                new Encomienda { NroGuia = "T0030011", Tamano = "M", Destino = "CD La Plata", NroServicioAsignado = "10020202", Estado = "En CD Origen"},
                
                // --- Servicio 20030303 (Solo Despachar) ---
                // A DESPACHAR (Estado: En CD Origen)
                new Encomienda { NroGuia = "T0050015", Tamano = "S", Destino = "CD Tucumán", NroServicioAsignado = "20030303", Estado = "En CD Origen"},
                new Encomienda { NroGuia = "T0050016", Tamano = "L", Destino = "CD Tucumán", NroServicioAsignado = "20030303", Estado = "En CD Origen"},

                // --- Servicio 30040404 (Solo Recibir) ---
                // A RECIBIR (Estado: En Viaje)
                new Encomienda { NroGuia = "T0060020", Tamano = "M", Destino = "CD CABA", NroServicioAsignado = "30040404", Estado = "En Viaje"},
                new Encomienda { NroGuia = "T0060021", Tamano = "XL", Destino = "CD CABA", NroServicioAsignado = "30040404", Estado = "En Viaje"}
                
                // NOTA: El Servicio 50000000 no tiene guías asignadas aquí para probar el caso de "cero resultados".
            };
        }

        // *** Lógica de Negocio y Validaciones N3-N4 ***

        /// <summary>
        /// Valida si el número de servicio existe (Nivel 3).
        /// </summary>
        public bool ExisteServicio(string nroServicio)
        {
            return _servicios.Any(s => s.NroServicio == nroServicio);
        }

        /// <summary>
        /// Recupera las guías a recibir ("En Viaje") y a despachar ("En CD Origen").
        /// </summary>
        public (List<Encomienda> aRecibir, List<Encomienda> aDespachar) BuscarGuiasPorServicio(string nroServicio)
        {
            var aRecibir = _encomiendas
                .Where(e => e.NroServicioAsignado == nroServicio && e.Estado == "En Viaje")
                .ToList();

            var aDespachar = _encomiendas
                .Where(e => e.NroServicioAsignado == nroServicio && e.Estado == "En CD Origen")
                .ToList();

            return (aRecibir, aDespachar);
        }

        /// <summary>
        /// Lógica para confirmar la operación: actualiza el estado de las encomiendas (N4).
        /// </summary>
        public void ConfirmarOperacion(string nroServicio)
        {
            // Las que se reciben (En Viaje) pasan a un estado de destino
            foreach (var enc in _encomiendas.Where(e => e.NroServicioAsignado == nroServicio && e.Estado == "En Viaje"))
            {
                enc.Estado = "Recibida en CD Destino";
            }

            // Las que se despachan (En CD Origen) pasan a En Viaje
            foreach (var enc in _encomiendas.Where(e => e.NroServicioAsignado == nroServicio && e.Estado == "En CD Origen"))
            {
                enc.Estado = "En Viaje";
            }
        }
    }
}
