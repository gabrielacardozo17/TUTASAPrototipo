namespace TUTASAPrototipo.RecepcionYDespachoUltimaMillaCD
{
    public enum EstadoGuia
    {
        // RETIRO
        ARetirarEnAgenciaOrigen,
        ARetirarPorDomicilioCliente,
        EnEsperaDeRetiroEnAgencia,
        EnEsperaDeRetiroAlCliente,
        EnRutaACDOrigen,

        // DISTRIBUCIÓN
        Admitida,
        EnTransitoAlCDDestino,
        EnCDDestino,
        EnRutaADomicilioEntrega,
        EnRutaALaAgenciaEntrega,
        PendienteDeEntrega,

        // FINAL
        Entregada,

        // Auxiliar
        PendienteDeAsignar
    }
}
