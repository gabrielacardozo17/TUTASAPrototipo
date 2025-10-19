// TUTASAPrototipo/ConsultarEstado/Guia.cs
using System;
using System.Collections.Generic;

namespace TUTASAPrototipo.ConsultarEstado
{
    public class Guia
    {
        // Identificación: TLLLNNNNN  (exactamente 9 dígitos)
        public string NumeroGuia { get; set; } = "";

        // Estado/Ubicación vigentes
        public string Estado { get; set; } = "";
        public string Ubicacion { get; set; } = "";

        // Historial mostrado en la grilla (Fecha, Estado, Ubicación)
        public List<Movimiento> Historial { get; set; } = new();

        // Tipo anidado para no crear otro archivo
        public record Movimiento(DateTime Fecha, string Estado, string Ubicacion);
    }
}
