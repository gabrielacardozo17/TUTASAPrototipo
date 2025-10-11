// ===============================
// Destinatario.cs
// ===============================

namespace TUTASAPrototipo.EntregarEncomiendaEnAgencia
{
    public class Destinatario
    {
        // Inicializados para cumplir no-nullable
        public string DNI { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
    }
}
