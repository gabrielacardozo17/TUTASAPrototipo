using System;
using System.Collections.Generic;
using System.Linq;

namespace TUTASAPrototipo.ImponerEncomiendaAgencia
{
    public class ImponerEncomiendaAgenciaModelo
    {
        // --- Listas de Datos de Prueba ---
        private List<Cliente> clientes;
        public List<Guia> guiasGeneradas;

        // --- Nuevas estructuras de datos para la lógica de UI ---
        private List<Provincia> provinciasConServicio;
        private List<Agencia> agencias;
        private List<CentroDistribucion> centrosDeDistribucion;

        private int proximoNumeroSecuencial = 200;

        public ImponerEncomiendaAgenciaModelo()
        {
            InicializarDatos();
            guiasGeneradas = new List<Guia>();
        }

        private void InicializarDatos()
        {
            // --- Clientes de prueba ---
            clientes = new List<Cliente>
            {
                new Cliente { CUIT = "30-12345678-5", NombreRazonSocial = "Tech Solutions S.A.", Telefono = "11-4555-6789", Direccion = "Av. Corrientes 1234" },
                new Cliente { CUIT = "27-22333444-9", NombreRazonSocial = "Librería El Ateneo", Telefono = "11-4812-3456", Direccion = "Av. Santa Fe 1860" },
                new Cliente { CUIT = "30-87654321-1", NombreRazonSocial = "Kiosco El Sol", Telefono = "11-4999-0011", Direccion = "Av. Rivadavia 5500" }
            };

            // --- Estructura Geográfica de TUTASA (para la UI) ---

            // 1. Definimos todos los CDs
            centrosDeDistribucion = new List<CentroDistribucion>
            {
                new CentroDistribucion { Nombre = "CABA OESTE", Provincia = "CABA" },
                new CentroDistribucion { Nombre = "CABA SUR", Provincia = "CABA" },
                new CentroDistribucion { Nombre = "Rosario", Provincia = "Santa Fe" },
                new CentroDistribucion { Nombre = "Córdoba Capital", Provincia = "Córdoba" }
            };

            // 2. Definimos todas las Agencias
            agencias = new List<Agencia>
            {
                new Agencia { Nombre = "CABA - Flores", Localidad = "Flores" },
                new Agencia { Nombre = "CABA - Belgrano", Localidad = "Belgrano" },
                new Agencia { Nombre = "La Plata - Centro", Localidad = "La Plata" },
                new Agencia { Nombre = "Rosario - Norte", Localidad = "Rosario" }
            };

            // 3. Construimos la lista de Provincias con sus localidades que tienen agencia
            provinciasConServicio = new List<Provincia>
            {
                new Provincia { Nombre = "CABA", LocalidadesConAgencia = new List<string> { "Flores", "Belgrano" } },
                new Provincia { Nombre = "Buenos Aires", LocalidadesConAgencia = new List<string> { "La Plata" } },
                new Provincia { Nombre = "Santa Fe", LocalidadesConAgencia = new List<string> { "Rosario" } },
                new Provincia { Nombre = "Córdoba", LocalidadesConAgencia = new List<string>() } // Córdoba tiene CD pero no agencias en esta data
            };
        }

        // --- Métodos de consulta para el Formulario ---

        public List<string> GetProvinciasConCD()
        {
            // Devuelve solo los nombres de las provincias que tienen al menos un CD.
            return centrosDeDistribucion.Select(cd => cd.Provincia).Distinct().ToList();
        }

        public List<string> GetLocalidadesConAgencia(string provincia)
        {
            var p = provinciasConServicio.FirstOrDefault(p => p.Nombre == provincia);
            // Devuelve la lista de localidades para la provincia, o una lista vacía si no se encuentra.
            return p?.LocalidadesConAgencia ?? new List<string>();
        }

        public List<string> GetAgenciasPorLocalidad(string localidad)
        {
            return agencias.Where(a => a.Localidad == localidad).Select(a => a.Nombre).ToList();
        }

        public List<string> GetCDsPorProvincia(string provincia)
        {
            return centrosDeDistribucion.Where(cd => cd.Provincia == provincia).Select(cd => cd.Nombre).ToList();
        }

        public Cliente BuscarClientePorCUIT(string cuit)
        {
            return clientes.FirstOrDefault(c => c.CUIT == cuit);
        }

        public List<Guia> GenerarGuias(string cuitRemitente, Destinatario destinatario, Dictionary<Tamanio, int> cantidades, string codigoAgencia)
        {
            var nuevasGuias = new List<Guia>();
            string tipoEstablecimiento = "0"; // 0 para Agencia

            foreach (var item in cantidades)
            {
                for (int i = 0; i < item.Value; i++)
                {
                    proximoNumeroSecuencial++;
                    string numeroSecuencial = proximoNumeroSecuencial.ToString("D5");

                    var nuevaGuia = new Guia
                    {
                        NumeroGuia = $"{tipoEstablecimiento}{codigoAgencia}{numeroSecuencial}",
                        Tamanio = item.Key,
                        DniDestinatario = destinatario.DNI,
                        DireccionDestino = destinatario.Direccion,
                        CuitRemitente = cuitRemitente
                    };
                    nuevasGuias.Add(nuevaGuia);
                }
            }
            guiasGeneradas.AddRange(nuevasGuias);
            return nuevasGuias;
        }
    }
}