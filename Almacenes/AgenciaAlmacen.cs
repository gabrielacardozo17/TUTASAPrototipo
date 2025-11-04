using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTASAPrototipo.Almacenes
{
    static class AgenciaAlmacen
    {
        public static AgenciaEntidad AgenciaActual { get; set; }

        public static List<AgenciaEntidad> agencias = new List<AgenciaEntidad>();

        static AgenciaAlmacen()
        {
            if (File.Exists(@"Datos\Agencias.json"))
            {
                var agenciaJson = File.ReadAllText(@"Datos\Agencias.json");
                agencias = System.Text.Json.JsonSerializer.Deserialize<List<AgenciaEntidad>>(agenciaJson) ?? new List<AgenciaEntidad>();
            }
        }

        public static void Grabar()
        {
            var agenciaJson = System.Text.Json.JsonSerializer.Serialize(agencias);
            File.WriteAllText(@"Datos\Agencias.json", agenciaJson);
        }
    }
    
}
