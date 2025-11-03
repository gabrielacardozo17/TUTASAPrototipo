using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TUTASAPrototipo.Almacenes
{
    static class CuentaCorrienteAlmacen
    {
        public static List<CuentaCorrienteEntidad> cuentasCorrientes = new List<CuentaCorrienteEntidad>();

        static CuentaCorrienteAlmacen()
        {
            Load();
        }

        public static void Load()
        {
            // Preferir la ruta en Datos, mantener compatibilidad con raíz
            if (File.Exists("Datos/CuentasCorrientes.json"))
            {
                var cuentaCorrienteJson = File.ReadAllText("Datos/CuentasCorrientes.json");
                cuentasCorrientes = System.Text.Json.JsonSerializer.Deserialize<List<CuentaCorrienteEntidad>>(cuentaCorrienteJson) ?? new List<CuentaCorrienteEntidad>();
                return;
            }
            if (File.Exists("Datos\\CuentasCorrientes.json"))
            {
                var cuentaCorrienteJson = File.ReadAllText("Datos\\CuentasCorrientes.json");
                cuentasCorrientes = System.Text.Json.JsonSerializer.Deserialize<List<CuentaCorrienteEntidad>>(cuentaCorrienteJson) ?? new List<CuentaCorrienteEntidad>();
                return;
            }
            if (File.Exists("CuentasCorrientes.json"))
            {
                var cuentaCorrienteJson = File.ReadAllText("CuentasCorrientes.json");
                cuentasCorrientes = System.Text.Json.JsonSerializer.Deserialize<List<CuentaCorrienteEntidad>>(cuentaCorrienteJson) ?? new List<CuentaCorrienteEntidad>();
                return;
            }

            // fallback: keep empty list
            cuentasCorrientes = new List<CuentaCorrienteEntidad>();
        }

        public static void Grabar()
        {
            var cuentaCorrienteJson = System.Text.Json.JsonSerializer.Serialize(cuentasCorrientes);
            // Grabar en Datos si existe la carpeta o crearla
            try
            {
                var dir = "Datos";
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                File.WriteAllText(Path.Combine(dir, "CuentasCorrientes.json"), cuentaCorrienteJson);
            }
            catch
            {
                // fallback to current directory
                File.WriteAllText("CuentasCorrientes.json", cuentaCorrienteJson);
            }
        }
    }

}
