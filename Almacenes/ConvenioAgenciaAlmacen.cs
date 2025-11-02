using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTASAPrototipo.Almacenes
{
    static class ConvenioAgenciaAlmacen
    {
        public static List<ConvenioAgenciaEntidad> convenioAgencias = new List<ConvenioAgenciaEntidad>();

        static ConvenioAgenciaAlmacen()
        {
            if (File.Exists("ConvenioAgencias.json"))
            {
                var convenioAgenciaJson = File.ReadAllText("ConvenioAgencias.json");
                convenioAgencias = System.Text.Json.JsonSerializer.Deserialize<List<ConvenioAgenciaEntidad>>(convenioAgenciaJson) ?? new List<ConvenioAgenciaEntidad>();
            }
        }

        public static void Grabar()
        {
            var convenioAgenciaJson = System.Text.Json.JsonSerializer.Serialize(convenioAgencias);
            File.WriteAllText("ConvenioAgencias.json", convenioAgenciaJson);
        }
    }

}
