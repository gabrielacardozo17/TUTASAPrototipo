using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TUTASAPrototipo.Almacenes
{
    static class EmpresaTransporteAlmacen
    {
        public static List<EmpresaTransporteEntidad> empresasTransporte = new List<EmpresaTransporteEntidad>();

        static EmpresaTransporteAlmacen()
        {
            Load();
        }

        public static void Load()
        {
            // Preferir la ruta en Datos, mantener compatibilidad con raíz
            if (File.Exists("Datos/EmpresasTransporte.json"))
            {
                var empresaTransporteJson = File.ReadAllText("Datos/EmpresasTransporte.json");
                empresasTransporte = System.Text.Json.JsonSerializer.Deserialize<List<EmpresaTransporteEntidad>>(empresaTransporteJson) ?? new List<EmpresaTransporteEntidad>();
                return;
            }
            else if (File.Exists("Datos\\EmpresasTransporte.json"))
            {
                var empresaTransporteJson = File.ReadAllText("Datos\\EmpresasTransporte.json");
                empresasTransporte = System.Text.Json.JsonSerializer.Deserialize<List<EmpresaTransporteEntidad>>(empresaTransporteJson) ?? new List<EmpresaTransporteEntidad>();
                return;
            }
            else if (File.Exists("EmpresasTransporte.json"))
            {
                var empresaTransporteJson = File.ReadAllText("EmpresasTransporte.json");
                empresasTransporte = System.Text.Json.JsonSerializer.Deserialize<List<EmpresaTransporteEntidad>>(empresaTransporteJson) ?? new List<EmpresaTransporteEntidad>();
                return;
            }

            empresasTransporte = new List<EmpresaTransporteEntidad>();
        }

        public static void Grabar()
        {
            var empresaTransporteJson = System.Text.Json.JsonSerializer.Serialize(empresasTransporte);
            try
            {
                var dir = "Datos";
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                File.WriteAllText(Path.Combine(dir, "EmpresasTransporte.json"), empresaTransporteJson);
            }
            catch
            {
                File.WriteAllText("EmpresasTransporte.json", empresaTransporteJson);
            }
        }
    }

}
