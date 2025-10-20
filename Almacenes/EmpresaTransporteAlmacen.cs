using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TUTASAPrototipo.Almacenes
{
    public static class EmpresaTransporteAlmacen
    {
        private const string Archivo = "Transportes.json";

        public static List<EmpresaTransporteEntidad> Transportes { get; private set; } = new();

        static EmpresaTransporteAlmacen()
        {
            try
            {
                if (File.Exists(Archivo))
                {
                    var json = File.ReadAllText(Archivo);
                    Transportes = JsonSerializer.Deserialize<List<EmpresaTransporteEntidad>>(json) ?? new();
                }
            }
            catch
            {
                Transportes = new();
            }
        }

        public static void Grabar()
        {
            var json = JsonSerializer.Serialize(Transportes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Archivo, json);
        }
    }
}
