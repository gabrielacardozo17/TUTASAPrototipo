using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace TUTASAPrototipo.Almacenes
{
    static class CuentaCorrienteEmpresaTransporteAlmacen
    {
        public static List<CuentaCorrienteEmpresaTransporteEntidad> cuentaCorrienteEmpresaTransporte = new List<CuentaCorrienteEmpresaTransporteEntidad>();

        static CuentaCorrienteEmpresaTransporteAlmacen()
        {
            Load();
        }

        private static string SanitizeJson(string json)
        {
            if (string.IsNullOrEmpty(json)) return json;
            // remove /* ... */ block comments
            json = Regex.Replace(json, @"/\*.*?\*/", string.Empty, RegexOptions.Singleline);
            // remove // line comments
            json = Regex.Replace(json, @"//.*?$", string.Empty, RegexOptions.Multiline);
            return json;
        }

        public static void Load()
        {
            string json = null;
            if (File.Exists("Datos/CuentaCorrienteEmpresaTransportes.json"))
            {
                json = File.ReadAllText("Datos/CuentaCorrienteEmpresaTransportes.json");
            }
            else if (File.Exists("Datos\\CuentaCorrienteEmpresaTransportes.json"))
            {
                json = File.ReadAllText("Datos\\CuentaCorrienteEmpresaTransportes.json");
            }
            else if (File.Exists("CuentaCorrienteEmpresaTransportes.json"))
            {
                json = File.ReadAllText("CuentaCorrienteEmpresaTransportes.json");
            }

            if (json != null)
            {
                try
                {
                    var sanitized = SanitizeJson(json);
                    cuentaCorrienteEmpresaTransporte = System.Text.Json.JsonSerializer.Deserialize<List<CuentaCorrienteEmpresaTransporteEntidad>>(sanitized) ?? new List<CuentaCorrienteEmpresaTransporteEntidad>();
                    return;
                }
                catch
                {
                    // fallback: try raw deserialize to throw original error later
                    cuentaCorrienteEmpresaTransporte = System.Text.Json.JsonSerializer.Deserialize<List<CuentaCorrienteEmpresaTransporteEntidad>>(json) ?? new List<CuentaCorrienteEmpresaTransporteEntidad>();
                    return;
                }
            }

            cuentaCorrienteEmpresaTransporte = new List<CuentaCorrienteEmpresaTransporteEntidad>();
        }

        public static void Grabar()
        {
            var json = System.Text.Json.JsonSerializer.Serialize(cuentaCorrienteEmpresaTransporte);
            try
            {
                var dir = "Datos";
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                File.WriteAllText(Path.Combine(dir, "CuentaCorrienteEmpresaTransportes.json"), json);
            }
            catch
            {
                File.WriteAllText("CuentaCorrienteEmpresaTransportes.json", json);
            }
        }
    }

}
