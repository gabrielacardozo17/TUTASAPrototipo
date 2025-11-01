namespace TUTASAPrototipo.Almacenes
{
    public enum EstadoGuiaEnum
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
