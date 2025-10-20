using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TUTASAPrototipo.Almacenes
{
    // Almacén básico de destinatarios persistido en JSON
    public static class DestinatarioAlmacen
    {
        private const string Archivo = "Destinatarios.json";

        public static List<DestinatarioEntidad> Destinatarios { get; private set; } = new();

        static DestinatarioAlmacen()
        {
            try
            {
                if (File.Exists(Archivo))
                {
                    var json = File.ReadAllText(Archivo);
                    Destinatarios = JsonSerializer.Deserialize<List<DestinatarioEntidad>>(json) ?? new();
                }
            }
            catch
            {
                Destinatarios = new();
            }
        }

        public static void Grabar()
        {
            var json = JsonSerializer.Serialize(Destinatarios, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Archivo, json);
        }
    }
}
