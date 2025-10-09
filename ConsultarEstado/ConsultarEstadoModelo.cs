// TUTASAPrototipo/ConsultarEstado/ConsultarEstadoModelo.cs  (REEMPLAZO TOTAL)
using System;
using System.Collections.Generic;
using System.Linq;

namespace TUTASAPrototipo.ConsultarEstado
{
    public class ConsultarEstadoModelo
    {
        // "Archivo" en memoria (datos de prueba) — solo esta pantalla
        private readonly List<Guia> _guias = new()
        {
            // 1) CD Córdoba (LLL=040) — Numero: 1 040 00045  → En CD Córdoba
            new Guia
            {
                Numero = "104000045",
                EstadoActual = EstadoGuia.EnCD,
                UbicacionActual = "CD Córdoba Capital",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,10), EstadoGuia.AdmitidaEnCDOrigen, "CD CABA Oeste"),
                    new Guia.Movimiento(new DateTime(2025,09,11), EstadoGuia.EnTransito,            "Corredor A"),
                    new Guia.Movimiento(new DateTime(2025,09,12), EstadoGuia.EnCD,                  "CD Córdoba Capital"), // ← último = actual
                }
            },

            // 2) Agencia CABA Centro (LLL=010) — Numero: 0 010 00155 → Pendiente de retiro en Agencia
            new Guia
            {
                Numero = "001000155",
                EstadoActual = EstadoGuia.PendRetiroAgencia,
                UbicacionActual = "Agencia CABA Centro",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,08), EstadoGuia.EnCD,                "CD CABA Oeste"),
                    new Guia.Movimiento(new DateTime(2025,09,09), EstadoGuia.PendRetiroAgencia,   "Agencia CABA Centro"), // ← último = actual
                }
            },

            // 3) CD Buenos Aires – Mar del Plata (LLL=011) — Numero: 1 011 00007 → En tránsito
            new Guia
            {
                Numero = "101100007",
                EstadoActual = EstadoGuia.EnTransito,
                UbicacionActual = "Ruta 2 (a CD Mar del Plata)",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,14), EstadoGuia.AdmitidaEnCDOrigen, "CD CABA Sur"),
                    new Guia.Movimiento(new DateTime(2025,09,15), EstadoGuia.EnTransito,         "Ruta 2 (a CD Mar del Plata)"), // ← último = actual
                }
            },

            // 4) CD CABA Oeste (LLL=001) — Numero: 1 001 00003 → Entregada (último es Entregada)
            new Guia
            {
                Numero = "100100003",
                EstadoActual = EstadoGuia.Entregada,
                UbicacionActual = "Domicilio del destinatario",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,05), EstadoGuia.EnCD,      "CD CABA Oeste"),
                    new Guia.Movimiento(new DateTime(2025,09,06), EstadoGuia.EnTransito, "UM CABA"),
                    new Guia.Movimiento(new DateTime(2025,09,06), EstadoGuia.Entregada,  "Domicilio del destinatario"), // ← último = actual
                }
            },

            // 5) CD Córdoba (LLL=040) — Numero: 1 040 00123 → En camino a retirar en Domicilio
            new Guia
            {
                Numero = "104000123",
                EstadoActual = EstadoGuia.EnCaminoRetiroDomicilio,
                UbicacionActual = "Fletero asignado (CBA)",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,01), EstadoGuia.PendRetiroDomicilio,       "Solicitud de retiro"),
                    new Guia.Movimiento(new DateTime(2025,09,02), EstadoGuia.EnCaminoRetiroDomicilio,   "Fletero asignado (CBA)"), // ← último = actual
                }
            }
        };

        // Helper (local a este submundo)
        private static string Digits(string s) => new string((s ?? "").Where(char.IsDigit).ToArray());

        // Única operación del modelo: consulta por número (el Form hace N0–N2)
        public Guia? ObtenerPorNumero(string input)
        {
            var key = Digits(input);
            return _guias.FirstOrDefault(g => Digits(g.Numero) == key);
        }
    }
}
