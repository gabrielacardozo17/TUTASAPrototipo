namespace TUTASAPrototipo.RecepcionAgencia
{
    public enum EstadoGuia
    {
        Pendiente,
        Recibida,     // recepción en agencia
        Entregada,    // entregada al fletero
        NoProcesada   // quedó sin marcar
    }

    public enum TipoGuia
    {
        Distribucion, // viene del CD -> se recibe en la agencia
        Retiro        // se entregará al fletero desde la agencia
    }
}
