using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TUTASAPrototipo.Almacenes
{
    public static class AlmacenServicioTransporte
    {
        private const string Archivo = "ServiciosTransporte.json";

        public static List<ServicioTransporteEntidad> ServiciosTransporte { get; private set; } = new();

        static AlmacenServicioTransporte()
        {
            try
            {
                if (File.Exists(Archivo))
                {
                    var json = File.ReadAllText(Archivo);
                    ServiciosTransporte = JsonSerializer.Deserialize<List<ServicioTransporteEntidad>>(json) ?? new();
                }
            }
            catch
            {
                ServiciosTransporte = new();
            }
        }

        public static void Grabar()
        {
            var json = JsonSerializer.Serialize(ServiciosTransporte, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Archivo, json);
        }
    }
}
