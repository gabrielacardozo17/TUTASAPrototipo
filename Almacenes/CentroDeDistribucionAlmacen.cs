using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTASAPrototipo.Almacenes
{
    static class CentroDeDistribucionAlmacen
    {
        public static List<CentroDeDistribucionEntidad> centrosDeDistribucion = new List<CentroDeDistribucionEntidad>();

        static CentroDeDistribucionAlmacen()
        {
            if (File.Exists("Datos/CentrosDeDistribucion.json"))
            {
                var centroDeDistribucionJson = File.ReadAllText("Datos/CentrosDeDistribucion.json");
                centrosDeDistribucion = System.Text.Json.JsonSerializer.Deserialize<List<CentroDeDistribucionEntidad>>(centroDeDistribucionJson) ?? new List<CentroDeDistribucionEntidad>();
            }
        }

        public static void Grabar()
        {
            var centroDeDistribucionJson = System.Text.Json.JsonSerializer.Serialize(centrosDeDistribucion);
            File.WriteAllText("CentrosDeDistribucion.json", centroDeDistribucionJson);
        }
    }

}
