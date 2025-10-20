using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TUTASAPrototipo.Almacenes
{
    public static class AgenciaAlmacen
    {
        private const string Archivo = "Agencias.json";

        public static List<AgenciaEntidad> Agencias { get; private set; } = new();

        static AgenciaAlmacen()
        {
            try
            {
                if (File.Exists(Archivo))
                {
                    var json = File.ReadAllText(Archivo);
                    Agencias = JsonSerializer.Deserialize<List<AgenciaEntidad>>(json) ?? new();
                }
            }
            catch
            {
                Agencias = new();
            }
        }

        public static void Grabar()
        {
            var json = JsonSerializer.Serialize(Agencias, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Archivo, json);
        }
    }
}
