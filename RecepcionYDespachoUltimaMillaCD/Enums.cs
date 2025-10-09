using System;

namespace TUTASAPrototipo.RecepcionYDespachoUltimaMillaCD
{
    // Estados de una guía en última milla
    public enum EstadoGuia
    {
        Pendiente,
        Cumplida,
        NoCumplida
    }

    // Tipo de guía en última milla
    public enum TipoGuia
    {
        Distribucion,
        Retiro
    }
}
