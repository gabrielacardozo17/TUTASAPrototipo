using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TUTASAPrototipo.Almacenes
{
    public static class AlmacenConvenioCliente
    {
        private const string Archivo = "ConveniosCliente.json";

        public static List<ConvenioClienteEntidad> ConveniosCliente { get; private set; } = new();

        static AlmacenConvenioCliente()
        {
            try
            {
                if (File.Exists(Archivo))
                {
                    var json = File.ReadAllText(Archivo);
                    ConveniosCliente = JsonSerializer.Deserialize<List<ConvenioClienteEntidad>>(json) ?? new();
                }
            }
            catch
            {
                ConveniosCliente = new();
            }
        }

        public static void Grabar()
        {
            var json = JsonSerializer.Serialize(ConveniosCliente, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Archivo, json);
        }
    }
}
