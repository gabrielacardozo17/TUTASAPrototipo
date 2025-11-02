using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTASAPrototipo.Almacenes
{
    static class HDRAlmacen
    {
        public static List<HDREntidad> HDR = new List<HDREntidad>();

        static HDRAlmacen()
        {
            if (File.Exists("Datos/HDR.json"))
            {
                var HDRJson = File.ReadAllText("Datos/HDR.json");
                HDR = System.Text.Json.JsonSerializer.Deserialize<List<HDREntidad>>(HDRJson) ?? new List<HDREntidad>();
            }
        }

        public static void Grabar()
        {
            var HDRJson = System.Text.Json.JsonSerializer.Serialize(HDR);
            File.WriteAllText("HDR.json", HDRJson);
        }
    }

}
