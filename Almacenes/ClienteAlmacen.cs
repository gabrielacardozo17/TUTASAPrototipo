using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTASAPrototipo.Almacenes
{
    static class ClienteAlmacen
    {
        public static List<ClienteEntidad> clientes = new List<ClienteEntidad>();

        static ClienteAlmacen()
        {
            // Preferir la ruta en Datos, mantener compatibilidad con raíz
            if (File.Exists("Datos/Clientes.json"))
            {
                var clienteJson = File.ReadAllText("Datos/Clientes.json");
                clientes = System.Text.Json.JsonSerializer.Deserialize<List<ClienteEntidad>>(clienteJson) ?? new List<ClienteEntidad>();
            }
            else if (File.Exists("Datos\\Clientes.json"))
            {
                var clienteJson = File.ReadAllText("Datos\\Clientes.json");
                clientes = System.Text.Json.JsonSerializer.Deserialize<List<ClienteEntidad>>(clienteJson) ?? new List<ClienteEntidad>();
            }
            else if (File.Exists("Clientes.json"))
            {
                var clienteJson = File.ReadAllText("Clientes.json");
                clientes = System.Text.Json.JsonSerializer.Deserialize<List<ClienteEntidad>>(clienteJson) ?? new List<ClienteEntidad>();
            }
        }

        public static void Grabar()
        {
            var clienteJson = System.Text.Json.JsonSerializer.Serialize(clientes);
            // Grabar siempre bajo Datos
            File.WriteAllText("Datos/Clientes.json", clienteJson);
        }
    }
    
}
