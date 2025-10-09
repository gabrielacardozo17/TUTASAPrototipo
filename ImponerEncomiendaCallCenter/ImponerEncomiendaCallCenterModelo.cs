using System.Collections.Generic;
using System.Linq;

namespace TUTASAPrototipo.ImponerEncomiendaCallCenter
{
    public class ImponerEncomiendaCallCenterModelo
    {
        public List<Cliente> Clientes { get; private set; }
        public List<string> ProvinciasConCD { get; private set; }
        public Dictionary<string, List<string>> LocalidadesPorProvincia { get; private set; }
        public Dictionary<string, List<string>> AgenciasPorLocalidad { get; private set; }
        public Dictionary<string, List<string>> CDsPorProvincia { get; private set; }

        public ImponerEncomiendaCallCenterModelo()
        {
            InicializarDatos();
        }

        private void InicializarDatos()
        {
            Clientes = new List<Cliente>
            {
                new Cliente { CUIT = "30-12345678-5", Nombre = "TecnoMundo S.R.L.", Telefono = "11-4567-8901", Direccion = "Av. Corrientes 1234, CABA" },
                new Cliente { CUIT = "30-87654321-9", Nombre = "Logística Austral S.A.", Telefono = "11-2345-6789", Direccion = "Florida 555, CABA" }
            };

            ProvinciasConCD = new List<string> { "Buenos Aires", "Santa Fe" };

            LocalidadesPorProvincia = new Dictionary<string, List<string>>
            {
                { "Buenos Aires", new List<string> { "Flores", "Belgrano" } },
                { "Santa Fe", new List<string>() }
            };

            AgenciasPorLocalidad = new Dictionary<string, List<string>>
            {
                { "Flores", new List<string> { "CABA - Flores" } },
                { "Belgrano", new List<string> { "CABA - Belgrano" } }
            };

            CDsPorProvincia = new Dictionary<string, List<string>>
            {
                { "Buenos Aires", new List<string> { "CABA OESTE" } },
                { "Santa Fe", new List<string> { "Rosario" } }
            };
        }

        public Cliente BuscarClientePorCUIT(string cuit)
        {
            return Clientes.FirstOrDefault(c => c.CUIT == cuit);
        }
    }
}
