using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TUTASAPrototipo.Almacenes
{
    // Almacén de clientes persistido en JSON
    public static class ClienteAlmacen
    {
        private const string Archivo = "Clientes.json";

        public static List<ClienteEntidad> Clientes { get; private set; } = new();

        static ClienteAlmacen()
        {
            try
            {
                if (File.Exists(Archivo))
                {
                    var json = File.ReadAllText(Archivo);
                    Clientes = JsonSerializer.Deserialize<List<ClienteEntidad>>(json) ?? new();
                }
            }
            catch
            {
                Clientes = new();
            }
        }

        public static void Grabar()
        {
            var json = JsonSerializer.Serialize(Clientes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Archivo, json);
        }
    }
}
