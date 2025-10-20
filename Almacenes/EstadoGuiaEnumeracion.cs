namespace TUTASAPrototipo.Almacenes
{
    public enum EstadoGuiaEnumeracion
    {
        ARetirarEnAgenciaDeOrigen,
        ARetirarPorDomicilioDelCliente,
        EnCaminoARetirarPorDomicilio,
        EnCaminoARetirarPorAgencia,
        EnRutaACdDeOrigenDesdeAgencia,
        Admitida,
        EnTransitoAlCDDestino,
        EnCdDestino,
        EnRutaAlDomicilioDeEntrega,
        EnRutaAlaAgenciaDestino,
        PendienteDeEntrega,
        Entregada,
        Cancelada,
        NoEntregada,
        Facturada

    }
}
