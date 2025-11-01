namespace TUTASAPrototipo.Almacenes
{
    public enum EstadoGuiaEnum
    {
        ARetirarEnAgenciaDeOrigen,

        ARetirarPorDomicilioDelCliente,

        EnCaminoARetirarPorDomicilio,

        EnCaminoARetirarPorAgencia,

        EnRutaACDDeOrigenDesdeAgencia,

        Admitida,
    
        EnTransitoAlCDDestino,

        EnCDDestino,

        EnRutaAlDomicilioDeEntrega,

        EnRutaAlaAgenciaDestino,

        PendienteDeEntrega,

        Entregada,

        Cancelada,

        NoEntregada,

        Facturada

    }
}
