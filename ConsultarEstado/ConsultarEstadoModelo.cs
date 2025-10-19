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
                NumeroGuia = "101000111",
                Estado = "Admitida",
                Ubicacion = "CD CABA Oeste",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,01), "A retirar en agencia", "Agencia CABA Centro"),
                    new Guia.Movimiento(new DateTime(2025,09,01), "En ruta a CD de origen",   ""), // sin lugar actual
                    new Guia.Movimiento(new DateTime(2025,09,01), "Admitida",                 "CD CABA Oeste"),
                }
            },

            // 2) Inter-CD: CD CABA Sur (0002) → CD Rosario (0050)
            new Guia
            {
                NumeroGuia = "000200222",
                Estado = "En CD destino",
                Ubicacion = "CD Rosario",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,02), "Admitida",                 "CD CABA Sur"),
                    new Guia.Movimiento(new DateTime(2025,09,03), "En tránsito a CD destino", ""),
                    new Guia.Movimiento(new DateTime(2025,09,04), "En CD destino",            "CD Rosario"),
                }
            },

            // 3) Del CD destino a Agencia destino
            new Guia
            {
                NumeroGuia = "004000333",
                Estado = "En agencia destino",
                Ubicacion = "Agencia Córdoba Norte",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,05), "En CD destino",             "CD Córdoba Capital"),
                    new Guia.Movimiento(new DateTime(2025,09,06), "En ruta a agencia destino", ""),
                    new Guia.Movimiento(new DateTime(2025,09,06), "En agencia destino",        "Agencia Córdoba Norte"),
                }
            },

            // 4) Última milla → entrega domiciliaria (ruta → pendiente → entregada)
            new Guia
            {
                NumeroGuia = "105000444",
                Estado = "Entregada",
                Ubicacion = "",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,07), "En agencia destino",   "Agencia Rosario Centro"),
                    new Guia.Movimiento(new DateTime(2025,09,07), "En ruta al domicilio",  ""),
                    new Guia.Movimiento(new DateTime(2025,09,07), "Pendiente de entrega", ""),
                    new Guia.Movimiento(new DateTime(2025,09,07), "Entregada",             ""),
                }
            },

            // 5) Retiro al cliente (logística inversa)
            new Guia
            {
                NumeroGuia = "004000555",
                Estado = "Admitida",
                Ubicacion = "CD Córdoba Capital",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,08), "A retirar por domicilio", "Domicilio del cliente (Córdoba)"),
                    new Guia.Movimiento(new DateTime(2025,09,08), "En ruta a CD de origen",  ""),
                    new Guia.Movimiento(new DateTime(2025,09,08), "Admitida",                 "CD Córdoba Capital"),
                }
            },

            // 6) En tránsito entre CDs (sin ubicación visible)
            new Guia
            {
                NumeroGuia = "000100666",
                Estado = "En tránsito a CD destino",
                Ubicacion = "",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,09), "Admitida",                 "CD CABA Oeste"),
                    new Guia.Movimiento(new DateTime(2025,09,10), "En tránsito a CD destino", ""),
                }
            },

            // 7) Recién admitida
            new Guia
            {
                NumeroGuia = "000200777",
                Estado = "Admitida",
                Ubicacion = "CD CABA Sur",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,10), "Admitida", "CD CABA Sur"),
                }
            },

            // 8) CD destino → Agencia destino → queda “A retirar en agencia”
            new Guia
            {
                NumeroGuia = "001000888",
                Estado = "A retirar en agencia",
                Ubicacion = "Agencia La Plata",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,11), "En CD destino",             "CD Buenos Aires – La Plata"),
                    new Guia.Movimiento(new DateTime(2025,09,11), "En ruta a agencia destino", ""),
                    new Guia.Movimiento(new DateTime(2025,09,11), "En agencia destino",        "Agencia La Plata"),
                    new Guia.Movimiento(new DateTime(2025,09,12), "A retirar en agencia",     "Agencia La Plata"),
                }
            },

            // ─────── NUEVOS (tomados de tu lista y adaptados) ───────

            // 9) 1010 00015 | 2025-10-02 | 1010→0040 | En ruta a CD de origen → Admitida en CD 0040
            new Guia
            {
                NumeroGuia = "101000015",
                Estado = "Admitida",
                Ubicacion = "CD Córdoba Capital",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,10,02), "A retirar en agencia",   "Agencia CABA Centro"),
                    new Guia.Movimiento(new DateTime(2025,10,02), "En ruta a CD de origen", ""),
                    new Guia.Movimiento(new DateTime(2025,10,02), "Admitida",                 "CD Córdoba Capital"), // 0040
                }
            },

            // 10) 0010 04567 | 2025-09-29 | 0010→0000 | En ruta al domicilio de entrega
            new Guia
            {
                NumeroGuia = "001004567",
                Estado = "En ruta al domicilio",
                Ubicacion = "",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,29), "Admitida",             "CD Buenos Aires – La Plata"),
                    new Guia.Movimiento(new DateTime(2025,09,29), "En ruta al domicilio", ""),
                }
            },

            // 11) 0002 00001 | 2025-10-01 | 0002→1010 | En tránsito al CD destino | CD intermedio 0050
            new Guia
            {
                NumeroGuia = "000200001",
                Estado = "En tránsito a CD destino",
                Ubicacion = "CD intermedio 0050",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,10,01), "Admitida",                 "CD CABA Sur"),
                    new Guia.Movimiento(new DateTime(2025,10,01), "En tránsito a CD destino", "CD intermedio 0050"),
                }
            },

            // 12) 1040 00011 | 2025-10-08 | 1040→0040 | Admitida | CD 0040
            new Guia
            {
                NumeroGuia = "104000011",
                Estado = "Admitida",
                Ubicacion = "CD Córdoba Capital",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,10,08), "En ruta a CD de origen", ""), // viene de agencia 1040
                    new Guia.Movimiento(new DateTime(2025,10,08), "Admitida",                 "CD Córdoba Capital"),
                }
            },

            // 13) 0070 00150 | 2025-09-18 | 0070→0000 | En ruta a la agencia de entrega (luego irá a EnAgenciaDestino)
            new Guia
            {
                NumeroGuia = "007000150",
                Estado = "En ruta a agencia destino",
                Ubicacion = "",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,18), "En CD destino",             "CD Corrientes"),
                    new Guia.Movimiento(new DateTime(2025,09,18), "En ruta a agencia destino", ""),
                }
            },

            // 14) 1011 00005 | 2025-10-03 | 1011→0000 | En espera de retiro en agencia (impuesta)
            new Guia
            {
                NumeroGuia = "101100005",
                Estado = "A retirar en agencia",
                Ubicacion = "Agencia CABA Flores",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,10,03), "A retirar en agencia", "Agencia CABA Flores"),
                }
            },

            // 15) 1024 00007 | 2025-10-07 | 1024→0000 | En espera de retiro al cliente (call center)
            new Guia
            {
                NumeroGuia = "102400007",
                Estado = "A retirar por domicilio",
                Ubicacion = "Domicilio del cliente (Pilar)",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,10,07), "A retirar por domicilio", "Domicilio del cliente (Pilar)"),
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
            return _guias.FirstOrDefault(g => Digits(g.NumeroGuia) == key);
        }
    }
}
