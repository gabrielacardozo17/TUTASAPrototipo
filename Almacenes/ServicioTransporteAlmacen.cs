using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTASAPrototipo.Almacenes
{
    static class ServicioTransporteAlmacen
    {
        public static List<ServicioTransporteEntidad> serviciosTransporte = new List<ServicioTransporteEntidad>();

        static ServicioTransporteAlmacen()
        {
            if (File.Exists("ServiciosTransporte.json"))
            {
                var servicioTransporteJson = File.ReadAllText("ServiciosTransporte.json");
                serviciosTransporte = System.Text.Json.JsonSerializer.Deserialize<List<ServicioTransporteEntidad>>(servicioTransporteJson) ?? new List<ServicioTransporteEntidad>();
            }
        }

        public static void Grabar()
        {
            var servicioTransporteJson = System.Text.Json.JsonSerializer.Serialize(serviciosTransporte);
            File.WriteAllText("ServiciosTransporte.json", servicioTransporteJson);
        }
    }

}
