using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TUTASAPrototipo.Almacenes
{
    public static class RegistroMovimientosCCAlmacen
    {
        private const string Archivo = "MovimientosCuenta.json";

        public static List<MovimientoCCEntidad> Movimientos { get; private set; } = new();

        static RegistroMovimientosCCAlmacen()
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
