using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TUTASAPrototipo.Almacenes
{
    // Almacén básico de guías persistido en JSON
    public static class AlmacenGuias
    {
        private const string Archivo = "Guias.json";

        public static List<GuiaEntidad> Guias { get; private set; } = new();

        static AlmacenGuias()
        {
            try
            {
                if (File.Exists(Archivo))
                {
                    var json = File.ReadAllText(Archivo);
                    Guias = JsonSerializer.Deserialize<List<GuiaEntidad>>(json) ?? new();
                }
            }
            catch
            {
                Guias = new();
            }
        }

        public static void Grabar()
        {
            var json = JsonSerializer.Serialize(Guias, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Archivo, json);
        }
    }
}
