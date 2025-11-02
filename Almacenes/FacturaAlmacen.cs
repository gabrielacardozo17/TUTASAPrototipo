using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTASAPrototipo.Almacenes
{
    static class FacturaAlmacen
    {
        public static List<FacturaEntidad> facturas = new List<FacturaEntidad>();

        static FacturaAlmacen()
        {
            // Preferir la ruta en Datos, mantener compatibilidad con raíz
            if (File.Exists("Datos/Facturas.json"))
            {
                var facturaJson = File.ReadAllText("Datos/Facturas.json");
                facturas = System.Text.Json.JsonSerializer.Deserialize<List<FacturaEntidad>>(facturaJson) ?? new List<FacturaEntidad>();
            }
            else if (File.Exists("Datos\\Facturas.json"))
            {
                var facturaJson = File.ReadAllText("Datos\\Facturas.json");
                facturas = System.Text.Json.JsonSerializer.Deserialize<List<FacturaEntidad>>(facturaJson) ?? new List<FacturaEntidad>();
            }
            else if (File.Exists("Facturas.json"))
            {
                var facturaJson = File.ReadAllText("Facturas.json");
                facturas = System.Text.Json.JsonSerializer.Deserialize<List<FacturaEntidad>>(facturaJson) ?? new List<FacturaEntidad>();
            }
        }

        public static void Grabar()
        {
            var facturaJson = System.Text.Json.JsonSerializer.Serialize(facturas);
            // Grabar siempre bajo Datos
            File.WriteAllText("Datos/Facturas.json", facturaJson);
        }
    }

}
