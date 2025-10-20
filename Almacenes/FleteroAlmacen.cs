using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TUTASAPrototipo.Almacenes
{
    public static class FleteroAlmacen
    {
        private const string Archivo = "Fleteros.json";

        public static List<FleteroEntidad> Fleteros { get; private set; } = new();

        static FleteroAlmacen()
        {
            try
            {
                if (File.Exists(Archivo))
                {
                    var json = File.ReadAllText(Archivo);
                    Fleteros = JsonSerializer.Deserialize<List<FleteroEntidad>>(json) ?? new();
                }
            }
            catch
            {
                Fleteros = new();
            }
        }

        public static void Grabar()
        {
            var json = JsonSerializer.Serialize(Fleteros, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Archivo, json);
        }
    }
}
