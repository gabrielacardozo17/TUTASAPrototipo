namespace TUTASAPrototipo.ImponerEncomiendaCD
{
    // Para usar como propiedad en Guía y en otras pantallas
    public enum TipoEntrega
    {
        Domicilio = 0,
        Agencia = 1,
        CD = 2
    }

    // Estados generales (pantalla de admision va a usar el primero)
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

    public enum TamanoBulto { S, M, L, XL }

}
