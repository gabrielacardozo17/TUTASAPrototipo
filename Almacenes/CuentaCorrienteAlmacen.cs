using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTASAPrototipo.Almacenes
{
    static class CuentaCorrienteAlmacen
    {
        public static List<CuentaCorrienteEntidad> cuentasCorrientes = new List<CuentaCorrienteEntidad>();

        static CuentaCorrienteAlmacen()
        {
            if (File.Exists("CuentasCorrientes.json"))
            {
                var cuentaCorrienteJson = File.ReadAllText("CuentaCorrientes.json");
                cuentasCorrientes = System.Text.Json.JsonSerializer.Deserialize<List<CuentaCorrienteEntidad>>(cuentaCorrienteJson) ?? new List<CuentaCorrienteEntidad>();
            }
        }

        public static void Grabar()
        {
            var cuentaCorrienteJson = System.Text.Json.JsonSerializer.Serialize(cuentasCorrientes);
            File.WriteAllText("CuentasCorrientes.json", cuentaCorrienteJson);
        }
    }

}
