using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TUTASAPrototipo/ConsultarEstado/Enums.cs
namespace TUTASAPrototipo.ConsultarEstado
{
    // Estados locales (copia para esta pantalla / submundo)
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
