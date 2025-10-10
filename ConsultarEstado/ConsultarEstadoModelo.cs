// TUTASAPrototipo/ConsultarEstado/ConsultarEstadoModelo.cs  (VERSIÓN ACTUALIZADA)
using System;
using System.Collections.Generic;
using System.Linq;

namespace TUTASAPrototipo.ConsultarEstado
{
    public class ConsultarEstadoModelo
    {
        // Helper local: solo dígitos
        private static string Digits(string s) => new string((s ?? "").Where(char.IsDigit).ToArray());

        // ─────────────────────────────────────────────────────────────────────────────
        // DATOS DE PRUEBA – coherentes con el flujo logístico y el formato TLLLNNNNN
        // TLLL: código (0001–0999 = CD, 1000+ = Agencia)
        // NNNNN: correlativo por establecimiento
        // ─────────────────────────────────────────────────────────────────────────────
        private readonly List<Guia> _guias = new()
        {
            // 1) Impuesta en agencia → va al CD de origen → queda Admitida en CD
            new Guia
            {
                Numero = "101000111",
                EstadoActual = EstadoGuia.Admitida,
                UbicacionActual = "CD CABA Oeste",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,01), EstadoGuia.ARetirarEnAgencia, "Agencia CABA Centro"),
                    new Guia.Movimiento(new DateTime(2025,09,01), EstadoGuia.EnRutaACDOrigen,   ""), // sin lugar actual
                    new Guia.Movimiento(new DateTime(2025,09,01), EstadoGuia.Admitida,          "CD CABA Oeste"),
                }
            },

            // 2) Inter-CD: CD CABA Sur (0002) → CD Rosario (0050)
            new Guia
            {
                Numero = "000200222",
                EstadoActual = EstadoGuia.EnCDDestino,
                UbicacionActual = "CD Rosario",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,02), EstadoGuia.Admitida,             "CD CABA Sur"),
                    new Guia.Movimiento(new DateTime(2025,09,03), EstadoGuia.EnTransitoACDDestino, ""),
                    new Guia.Movimiento(new DateTime(2025,09,04), EstadoGuia.EnCDDestino,          "CD Rosario"),
                }
            },

            // 3) Del CD destino a Agencia destino
            new Guia
            {
                Numero = "004000333",
                EstadoActual = EstadoGuia.EnAgenciaDestino,
                UbicacionActual = "Agencia Córdoba Norte",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,05), EstadoGuia.EnCDDestino,           "CD Córdoba Capital"),
                    new Guia.Movimiento(new DateTime(2025,09,06), EstadoGuia.EnRutaAAgenciaDestino, ""),
                    new Guia.Movimiento(new DateTime(2025,09,06), EstadoGuia.EnAgenciaDestino,       "Agencia Córdoba Norte"),
                }
            },

            // 4) Última milla → entrega domiciliaria (ruta → pendiente → entregada)
            new Guia
            {
                Numero = "105000444",
                EstadoActual = EstadoGuia.Entregada,
                UbicacionActual = "",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,07), EstadoGuia.EnAgenciaDestino,   "Agencia Rosario Centro"),
                    new Guia.Movimiento(new DateTime(2025,09,07), EstadoGuia.EnRutaAlDomicilio,  ""),
                    new Guia.Movimiento(new DateTime(2025,09,07), EstadoGuia.PendienteDeEntrega, ""),
                    new Guia.Movimiento(new DateTime(2025,09,07), EstadoGuia.Entregada,          ""),
                }
            },

            // 5) Retiro al cliente (logística inversa)
            new Guia
            {
                Numero = "004000555",
                EstadoActual = EstadoGuia.Admitida,
                UbicacionActual = "CD Córdoba Capital",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,08), EstadoGuia.ARetirarPorDomicilio, "Domicilio del cliente (Córdoba)"),
                    new Guia.Movimiento(new DateTime(2025,09,08), EstadoGuia.EnRutaACDOrigen,      ""),
                    new Guia.Movimiento(new DateTime(2025,09,08), EstadoGuia.Admitida,             "CD Córdoba Capital"),
                }
            },

            // 6) En tránsito entre CDs (sin ubicación visible)
            new Guia
            {
                Numero = "000100666",
                EstadoActual = EstadoGuia.EnTransitoACDDestino,
                UbicacionActual = "",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,09), EstadoGuia.Admitida,             "CD CABA Oeste"),
                    new Guia.Movimiento(new DateTime(2025,09,10), EstadoGuia.EnTransitoACDDestino, ""),
                }
            },

            // 7) Recién admitida
            new Guia
            {
                Numero = "000200777",
                EstadoActual = EstadoGuia.Admitida,
                UbicacionActual = "CD CABA Sur",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,10), EstadoGuia.Admitida, "CD CABA Sur"),
                }
            },

            // 8) CD destino → Agencia destino → queda “A retirar en agencia”
            new Guia
            {
                Numero = "001000888",
                EstadoActual = EstadoGuia.ARetirarEnAgencia,
                UbicacionActual = "Agencia La Plata",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,11), EstadoGuia.EnCDDestino,           "CD Buenos Aires – La Plata"),
                    new Guia.Movimiento(new DateTime(2025,09,11), EstadoGuia.EnRutaAAgenciaDestino, ""),
                    new Guia.Movimiento(new DateTime(2025,09,11), EstadoGuia.EnAgenciaDestino,       "Agencia La Plata"),
                    new Guia.Movimiento(new DateTime(2025,09,12), EstadoGuia.ARetirarEnAgencia,     "Agencia La Plata"),
                }
            },

            // ─────── NUEVOS (tomados de tu lista y adaptados) ───────

            // 9) 1010 00015 | 2025-10-02 | 1010→0040 | En ruta a CD de origen → Admitida en CD 0040
            new Guia
            {
                Numero = "101000015",
                EstadoActual = EstadoGuia.Admitida,
                UbicacionActual = "CD Córdoba Capital",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,10,02), EstadoGuia.ARetirarEnAgencia, "Agencia CABA Centro"),
                    new Guia.Movimiento(new DateTime(2025,10,02), EstadoGuia.EnRutaACDOrigen,   ""),
                    new Guia.Movimiento(new DateTime(2025,10,02), EstadoGuia.Admitida,          "CD Córdoba Capital"), // 0040
                }
            },

            // 10) 0010 04567 | 2025-09-29 | 0010→0000 | En ruta al domicilio de entrega
            new Guia
            {
                Numero = "001004567",
                EstadoActual = EstadoGuia.EnRutaAlDomicilio,
                UbicacionActual = "",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,29), EstadoGuia.Admitida,          "CD Buenos Aires – La Plata"),
                    new Guia.Movimiento(new DateTime(2025,09,29), EstadoGuia.EnRutaAlDomicilio, ""),
                }
            },

            // 11) 0002 00001 | 2025-10-01 | 0002→1010 | En tránsito al CD destino | CD intermedio 0050
            new Guia
            {
                Numero = "000200001",
                EstadoActual = EstadoGuia.EnTransitoACDDestino,
                UbicacionActual = "CD intermedio 0050",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,10,01), EstadoGuia.Admitida,             "CD CABA Sur"),
                    new Guia.Movimiento(new DateTime(2025,10,01), EstadoGuia.EnTransitoACDDestino, "CD intermedio 0050"),
                }
            },

            // 12) 1040 00011 | 2025-10-08 | 1040→0040 | Admitida | CD 0040
            new Guia
            {
                Numero = "104000011",
                EstadoActual = EstadoGuia.Admitida,
                UbicacionActual = "CD Córdoba Capital",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,10,08), EstadoGuia.EnRutaACDOrigen, ""), // viene de agencia 1040
                    new Guia.Movimiento(new DateTime(2025,10,08), EstadoGuia.Admitida,        "CD Córdoba Capital"),
                }
            },

            // 13) 0070 00150 | 2025-09-18 | 0070→0000 | En ruta a la agencia de entrega (luego irá a EnAgenciaDestino)
            new Guia
            {
                Numero = "007000150",
                EstadoActual = EstadoGuia.EnRutaAAgenciaDestino,
                UbicacionActual = "",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,18), EstadoGuia.EnCDDestino,           "CD Corrientes"),
                    new Guia.Movimiento(new DateTime(2025,09,18), EstadoGuia.EnRutaAAgenciaDestino, ""),
                }
            },

            // 14) 1011 00005 | 2025-10-03 | 1011→0000 | En espera de retiro en agencia (impuesta)
            new Guia
            {
                Numero = "101100005",
                EstadoActual = EstadoGuia.ARetirarEnAgencia,
                UbicacionActual = "Agencia CABA Flores",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,10,03), EstadoGuia.ARetirarEnAgencia, "Agencia CABA Flores"),
                }
            },

            // 15) 1024 00007 | 2025-10-07 | 1024→0000 | En espera de retiro al cliente (call center)
            new Guia
            {
                Numero = "102400007",
                EstadoActual = EstadoGuia.ARetirarPorDomicilio,
                UbicacionActual = "Domicilio del cliente (Pilar)",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,10,07), EstadoGuia.ARetirarPorDomicilio, "Domicilio del cliente (Pilar)"),
                }
            },
        };

        // ─────────────────────────────────────────────────────────────────────────────
        // API del modelo
        // ─────────────────────────────────────────────────────────────────────────────
        public Guia? ObtenerPorNumero(string input)
        {
            var key = Digits(input);
            if (key.Length != 9) return null;   // nuevo formato: 9 dígitos
            return _guias.FirstOrDefault(g => Digits(g.Numero) == key);
        }
    }
}
