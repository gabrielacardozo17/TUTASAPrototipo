using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTASAPrototipo.Almacenes
{
    static class LocalidadAlmacen
    {
        public static List<LocalidadEntidad> localidades = new List<LocalidadEntidad>();

        static LocalidadAlmacen()
        {
            if (File.Exists(@"Datos\Localidades.json"))
            {
                var localidadJson = File.ReadAllText(@"Datos\Localidades.json");
                localidades = System.Text.Json.JsonSerializer.Deserialize<List<LocalidadEntidad>>(localidadJson) ?? new List<LocalidadEntidad>();
            }
        }

        public static void Grabar()
        {
            var localidadJson = System.Text.Json.JsonSerializer.Serialize(localidades);
            File.WriteAllText(@"Datos\Localidades.json", localidadJson);
        }
    }
    
}
