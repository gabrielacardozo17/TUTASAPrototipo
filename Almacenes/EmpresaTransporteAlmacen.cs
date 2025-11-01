using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTASAPrototipo.Almacenes
{
    static class EmpresaTransporteAlmacen
    {
        public static List<EmpresaTransporteEntidad> empresasTransporte = new List<EmpresaTransporteEntidad>();

        static EmpresaTransporteAlmacen()
        {
            if (File.Exists("EmpresasTransporte.json"))
            {
                var empresaTransporteJson = File.ReadAllText("EmpresasTransporte.json");
                empresasTransporte = System.Text.Json.JsonSerializer.Deserialize<List<EmpresaTransporteEntidad>>(empresaTransporteJson) ?? new List<EmpresaTransporteEntidad>();
            }
        }

        public static void Grabar()
        {
            var empresaTransporteJson = System.Text.Json.JsonSerializer.Serialize(empresasTransporte);
            File.WriteAllText("EmpresasTransporte.json", empresaTransporteJson);
        }
    }

}
