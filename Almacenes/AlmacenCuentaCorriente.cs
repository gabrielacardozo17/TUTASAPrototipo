using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TUTASAPrototipo.Almacenes
{
    public static class AlmacenCuentaCorriente
    {
        private const string Archivo = "CuentasCorrientes.json";

        public static List<CuentaCorrienteEntidad> CuentasCorrientes { get; private set; } = new();

        static AlmacenCuentaCorriente()
        {
            try
            {
                if (File.Exists(Archivo))
                {
                    var json = File.ReadAllText(Archivo);
                    CuentasCorrientes = JsonSerializer.Deserialize<List<CuentaCorrienteEntidad>>(json) ?? new();
                }
            }
            catch
            {
                CuentasCorrientes = new();
            }
        }

        public static void Grabar()
        {
            var json = JsonSerializer.Serialize(CuentasCorrientes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Archivo, json);
        }
    }
}
