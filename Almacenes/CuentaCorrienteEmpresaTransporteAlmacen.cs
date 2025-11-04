using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTASAPrototipo.Almacenes
{
    static class CuentaCorrienteEmpresaTransporteAlmacen
    {
        public static List<CuentaCorrienteEmpresaTransporteEntidad> cuentaCorrienteEmpresaTransporte = new List<CuentaCorrienteEmpresaTransporteEntidad>();

        static CuentaCorrienteEmpresaTransporteAlmacen()
        {
            if (File.Exists(@"Datos\CuentaCorrienteEmpresaTransportes.json"))
            {
                var cuentaCorrienteEmpresaTransporteJson = File.ReadAllText(@"Datos\CuentaCorrienteEmpresaTransportes.json");
                cuentaCorrienteEmpresaTransporte = System.Text.Json.JsonSerializer.Deserialize<List<CuentaCorrienteEmpresaTransporteEntidad>>(cuentaCorrienteEmpresaTransporteJson) ?? new List<CuentaCorrienteEmpresaTransporteEntidad>();
            }
        }

        public static void Grabar()
        {
            var cuentaCorrienteEmpresaTransporteJson = System.Text.Json.JsonSerializer.Serialize(cuentaCorrienteEmpresaTransporte);
            File.WriteAllText(@"Datos\CuentaCorrienteEmpresaTransporte.json", cuentaCorrienteEmpresaTransporteJson);
        }
    }

}
