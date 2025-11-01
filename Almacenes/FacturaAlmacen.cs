using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.Almacenes
{
    // Almacén básico de facturas persistido en JSON
    public static class FacturaAlmacen
    {
        private const string Archivo = "Facturas.json";

        public static List<FacturaEntidad> Facturas { get; private set; } = new();

        static FacturaAlmacen()
        {
            try
            {
                if (File.Exists(Archivo))
                {
                    var json = File.ReadAllText(Archivo);
                    Facturas = JsonSerializer.Deserialize<List<FacturaEntidad>>(json) ?? new();
                }
            }
            catch
            {
                Facturas = new();
            }
        }

        public static void Grabar()
        {
            var json = JsonSerializer.Serialize(Facturas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Archivo, json);
        }
    }
}
