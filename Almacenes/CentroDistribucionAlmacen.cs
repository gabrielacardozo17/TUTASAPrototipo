using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TUTASAPrototipo.Almacenes
{
    public static class CentroDistribucionAlmacen
    {
        private const string Archivo = "CDs.json";

        public static List<CentroDeDistribucionEntidad> CDs { get; private set; } = new();

        static CentroDistribucionAlmacen()
        {
            try
            {
                if (File.Exists(Archivo))
                {
                    var json = File.ReadAllText(Archivo);
                    CDs = JsonSerializer.Deserialize<List<CentroDeDistribucionEntidad>>(json) ?? new();
                }
            }
            catch
            {
                CDs = new();
            }
        }

        public static void Grabar()
        {
            var json = JsonSerializer.Serialize(CDs, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Archivo, json);
        }
    }
}
