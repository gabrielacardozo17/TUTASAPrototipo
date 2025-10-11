namespace TUTASAPrototipo.ImponerEncomiendaCallCenter
{
    // Estados iguales a la versión de CD
    public enum EstadoGuia
    {
        AdmitidaEnCDOrigen = 0,
        PendRetiroDomicilio = 10,
        PendRetiroAgencia = 11,
        EnCaminoRetiroDomicilio = 20,
        EnCaminoRetiroAgencia = 21,
        EnTransito = 30,
        EnCD = 40,
        Entregada = 50,
        SeleccionadaParaRuta = 60
    }
}
