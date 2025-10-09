using System.Collections.Generic;

namespace TUTASAPrototipo.ImponerEncomiendaAgencia
{
    // Clase para representar una Provincia y sus localidades con agencias
    public class Provincia
    {
        public string Nombre { get; set; }
        public List<string> LocalidadesConAgencia { get; set; }
    }

    // Clase para representar una Agencia
    public class Agencia
    {
        public string Nombre { get; set; }
        public string Localidad { get; set; }
    }

    // Clase para representar un Centro de Distribución
    public class CentroDistribucion
    {
        public string Nombre { get; set; }
        public string Provincia { get; set; }
    }
}
