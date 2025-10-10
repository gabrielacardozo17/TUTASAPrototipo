// TUTASAPrototipo/ConsultarEstado/Enums.cs
namespace TUTASAPrototipo.ConsultarEstado
{
    public enum EstadoGuia
    {
        // Imposición / espera de retiro
        ARetirarEnAgencia = 0,                // lugar: una agencia (impuesta)
        ARetirarPorDomicilio = 1,             // lugar: domicilio del cliente
        Admitida = 2,                         // lugar: CD origen

        // Tramos logísticos
        EnRutaACDOrigen = 10,                 // sin lugar
        EnTransitoACDDestino = 20,            // sin lugar o CD intermedio
        EnCDDestino = 30,                     // lugar: CD
        EnRutaAAgenciaDestino = 31,           // sin lugar
        EnAgenciaDestino = 32,                // lugar: agencia
        EnRutaAlDomicilio = 33,               // sin lugar

        // Finalización
        PendienteDeEntrega = 40,              // lugar: CD o Agencia
        Entregada = 50                        // sin lugar
    }
}
