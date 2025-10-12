namespace TUTASAPrototipo.RecepcionYDespachoAgencia
{
    public enum EstadoGuia
    {
        // Estados para recepción (guías que llegan a la agencia)
        EnRutaAAgenciaDestino,    // En camino a la agencia - para recepcionar
        Recibida,                 // recepción en agencia confirmada
        
        // Estados para despacho (guías que salen de la agencia)
        ARetirarEnAgenciaOrigen,  // Lista para ser retirada por fletero
        Entregada,                // entregada al fletero
        
        // Estado auxiliar
        NoProcesada               // quedó sin marcar
    }
}
