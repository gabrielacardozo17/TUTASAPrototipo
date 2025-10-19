using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.Almacenes
{
    // Almacén básico de movimientos de cuenta corriente (CC) persistido en JSON
    public static class AlmacenMovimientosCC
    {
        private const string Archivo = "MovimientosCuenta.json"; // conservamos el nombre del archivo

        public static List<MovimientoCCEntidad> Movimientos { get; private set; } = new();

        static AlmacenMovimientosCC()
        {
            try
            {
                if (File.Exists(Archivo))
                {
                    var json = File.ReadAllText(Archivo);
                    Movimientos = JsonSerializer.Deserialize<List<MovimientoCCEntidad>>(json) ?? new();
                }
            }
            catch
            {
                Movimientos = new();
            }
        }

        public static void Grabar()
        {
            var json = JsonSerializer.Serialize(Movimientos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Archivo, json);
        }
    }
}
