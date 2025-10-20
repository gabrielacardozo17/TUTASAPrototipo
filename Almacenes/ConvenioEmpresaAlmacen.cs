using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TUTASAPrototipo.Almacenes
{
    public static class ConvenioEmpresaAlmacen
    {
        private const string Archivo = "ConveniosEmpresa.json";

        public static List<ConvenioEmpresaEntidad> ConveniosEmpresa { get; private set; } = new();

        static ConvenioEmpresaAlmacen()
        {
            try
            {
                if (File.Exists(Archivo))
                {
                    var json = File.ReadAllText(Archivo);
                    ConveniosEmpresa = JsonSerializer.Deserialize<List<ConvenioEmpresaEntidad>>(json) ?? new();
                }
            }
            catch
            {
                ConveniosEmpresa = new();
            }
        }

        public static void Grabar()
        {
            var json = JsonSerializer.Serialize(ConveniosEmpresa, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Archivo, json);
        }
    }
}
