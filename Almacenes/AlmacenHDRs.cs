using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TUTASAPrototipo.Almacenes
{
    public static class AlmacenHDRs
    {
        private const string Archivo = "HDRs.json";

        public static List<HDREntidad> HDRs { get; private set; } = new();

        static AlmacenHDRs()
        {
            try
            {
                if (File.Exists(Archivo))
                {
                    var json = File.ReadAllText(Archivo);
                    HDRs = JsonSerializer.Deserialize<List<HDREntidad>>(json) ?? new();
                }
            }
            catch
            {
                HDRs = new();
            }
        }

        public static void Grabar()
        {
            var json = JsonSerializer.Serialize(HDRs, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Archivo, json);
        }
    }
}
