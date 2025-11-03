using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TUTASAPrototipo.Almacenes
{
    static class ServicioTransporteAlmacen
    {
        public static List<ServicioTransporteEntidad> serviciosTransporte = new List<ServicioTransporteEntidad>();

        static ServicioTransporteAlmacen()
        {
            Load();
        }

        public static void Load()
        {
            if (File.Exists("Datos/ServiciosTransporte.json"))
            {
                var servicioTransporteJson = File.ReadAllText("Datos/ServiciosTransporte.json");
                serviciosTransporte = System.Text.Json.JsonSerializer.Deserialize<List<ServicioTransporteEntidad>>(servicioTransporteJson) ?? new List<ServicioTransporteEntidad>();
                return;
            }
            else if (File.Exists("Datos\\ServiciosTransporte.json"))
            {
                var servicioTransporteJson = File.ReadAllText("Datos\\ServiciosTransporte.json");
                serviciosTransporte = System.Text.Json.JsonSerializer.Deserialize<List<ServicioTransporteEntidad>>(servicioTransporteJson) ?? new List<ServicioTransporteEntidad>();
                return;
            }
            else if (File.Exists("ServiciosTransporte.json"))
            {
                var servicioTransporteJson = File.ReadAllText("ServiciosTransporte.json");
                serviciosTransporte = System.Text.Json.JsonSerializer.Deserialize<List<ServicioTransporteEntidad>>(servicioTransporteJson) ?? new List<ServicioTransporteEntidad>();
                return;
            }

            serviciosTransporte = new List<ServicioTransporteEntidad>();
        }

        public static void Grabar()
        {
            var servicioTransporteJson = System.Text.Json.JsonSerializer.Serialize(serviciosTransporte);
            try
            {
                var dir = "Datos";
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                File.WriteAllText(Path.Combine(dir, "ServiciosTransporte.json"), servicioTransporteJson);
            }
            catch
            {
                File.WriteAllText("ServiciosTransporte.json", servicioTransporteJson);
            }
        }
    }
}
