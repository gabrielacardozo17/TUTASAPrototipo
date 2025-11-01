using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTASAPrototipo.Almacenes
{
    static class FleteroAlmacen
    {
        public static List<FleteroEntidad> fleteros = new List<FleteroEntidad>();

        static FleteroAlmacen()
        {
            if (File.Exists("Fleteros.json"))
            {
                var fleteroJson = File.ReadAllText("Fleteros.json");
                fleteros = System.Text.Json.JsonSerializer.Deserialize<List<FleteroEntidad>>(fleteroJson) ?? new List<FleteroEntidad>();
            }
        }

        public static void Grabar()
        {
            var fleteroJson = System.Text.Json.JsonSerializer.Serialize(fleteros);
            File.WriteAllText("Fleteros.json", fleteroJson);
        }
    }
    
}
