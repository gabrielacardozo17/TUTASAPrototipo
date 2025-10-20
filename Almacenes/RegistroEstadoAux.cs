using System;

namespace TUTASAPrototipo.Almacenes
{
    public class RegistroEstadoAux
    {
        public int NumeroGuia { get; set; }
        public EstadoGuiaEnumeracion Estado { get; set; }
        public string UbicacionGuia { get; set; } = string.Empty;
        public DateTime FechaActualizacionEstado { get; set; }
    }
}
