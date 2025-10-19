using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TUTASAPrototipo.EmitirFactura
{
    // Almacén básico de facturas persistido en JSON
    public static class AlmacenFacturas
    {
        private const string Archivo = "Facturas.json";

        public static List<Factura> Facturas { get; private set; } = new();

        static AlmacenFacturas()
        {
            try
            {
                if (File.Exists(Archivo))
                {
                    var json = File.ReadAllText(Archivo);
                    Facturas = JsonSerializer.Deserialize<List<Factura>>(json) ?? new();
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
