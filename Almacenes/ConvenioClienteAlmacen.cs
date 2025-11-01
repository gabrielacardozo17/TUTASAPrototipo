using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTASAPrototipo.Almacenes
{
    static class ConvenioClienteAlmacen
    {
        public static List<ConvenioClienteEntidad> convenioClientes = new List<ConvenioClienteEntidad>();

        static ConvenioClienteAlmacen()
        {
            if (File.Exists("ConvenioClientes.json"))
            {
                var convenioClienteJson = File.ReadAllText("ConvenioClientes.json");
                convenioClientes = System.Text.Json.JsonSerializer.Deserialize<List<ConvenioClienteEntidad>>(convenioClienteJson) ?? new List<ConvenioClienteEntidad>();
            }
        }

        public static void Grabar()
        {
            var convenioClienteJson = System.Text.Json.JsonSerializer.Serialize(convenioClientes);
            File.WriteAllText("ConvenioClientes.json", convenioClienteJson);
        }
    }

}
