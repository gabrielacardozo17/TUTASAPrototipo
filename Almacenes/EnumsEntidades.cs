namespace TUTASAPrototipo.Almacenes
{
    public enum EstadoGuia
    {
        EnEsperaRetiroEnAgencia,
        EnEsperaRetiroAlCliente,
        EnRutaACDOrigen,
        Admitida,
        EnTransitoAlCDDestino,
        EnCDDestino,
        EnRutaAlDomicilioDeEntrega,
        EnRutaALaAgenciaDeEntrega,
        EnAgenciaDestino,
        PendienteDeEntrega,
        Entregada
    }

    public enum TipoEntrega
    {
        Retiro,
        Distribucion
    }

    public enum Tamano
    {
        S,
        M,
        L,
        XL
    }
}
