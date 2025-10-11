using System.Collections.Generic;

namespace TUTASAPrototipo.RecepcionYDespachoUltimaMillaCD
{
    public class HDR
    {
        public string Numero { get; set; } = "";
        public string Direccion { get; set; } = ""; // destino/CD/Agencia textual
        public string Tipo { get; set; } = "";      // "Retiro" o "Distribución"
        public List<string> Guias { get; set; } = new();
    }
}
