// TUTASAPrototipo/ConsultarEstado/Guia.cs
using System;
using System.Collections.Generic;

namespace TUTASAPrototipo.ConsultarEstado
{
    public class Guia
    {
        // Identificación: TLLLNNNNN  (exactamente 9 dígitos)
        public string Numero { get; set; } = "";

        // Estado/Ubicación vigentes
        public EstadoGuia EstadoActual { get; set; }
        public string UbicacionActual { get; set; } = "";

        // Historial mostrado en la grilla (Fecha, Estado, Ubicación)
        public List<Movimiento> Historial { get; set; } = new();

        // Tipo anidado para no crear otro archivo
        public record Movimiento(DateTime Fecha, EstadoGuia Estado, string Ubicacion);
    }
}
