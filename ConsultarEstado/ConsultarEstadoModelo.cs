
using System;
using System.Collections.Generic;
using System.Linq;
using TUTASAPrototipo.Almacenes; // Agregado para acceder a los almacenes

namespace TUTASAPrototipo.ConsultarEstado
{
    public class ConsultarEstadoModelo
    {
        /*
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
                EstadoActual = "Admitida",
                UbicacionActual = "CD CABA Oeste",
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
                Numero = "000200222",
                EstadoActual = "En CD destino",
                UbicacionActual = "CD Rosario",
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
                Numero = "004000333",
                EstadoActual = "En agencia destino",
                UbicacionActual = "Agencia Córdoba Norte",
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
                Numero = "105000444",
                EstadoActual = "Entregada",
                UbicacionActual = "",
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
                Numero = "004000555",
                EstadoActual = "Admitida",
                UbicacionActual = "CD Córdoba Capital",
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
                Numero = "000100666",
                EstadoActual = "En tránsito a CD destino",
                UbicacionActual = "",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,09), "Admitida",                 "CD CABA Oeste"),
                    new Guia.Movimiento(new DateTime(2025,09,10), "En tránsito a CD destino", ""),
                }
            },

            // 7) Recién admitida
            new Guia
            {
                Numero = "000200777",
                EstadoActual = "Admitida",
                UbicacionActual = "CD CABA Sur",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,10), "Admitida", "CD CABA Sur"),
                }
            },

            // 8) CD destino → Agencia destino → queda “A retirar en agencia”
            new Guia
            {
                Numero = "001000888",
                EstadoActual = "A retirar en agencia",
                UbicacionActual = "Agencia La Plata",
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
                Numero = "101000015",
                EstadoActual = "Admitida",
                UbicacionActual = "CD Córdoba Capital",
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
                Numero = "001004567",
                EstadoActual = "En ruta al domicilio",
                UbicacionActual = "",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,29), "Admitida",             "CD Buenos Aires – La Plata"),
                    new Guia.Movimiento(new DateTime(2025,09,29), "En ruta al domicilio", ""),
                }
            },

            // 11) 0002 00001 | 2025-10-01 | 0002→1010 | En tránsito al CD destino | CD intermedio 0050
            new Guia
            {
                Numero = "000200001",
                EstadoActual = "En tránsito a CD destino",
                UbicacionActual = "CD intermedio 0050",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,10,01), "Admitida",                 "CD CABA Sur"),
                    new Guia.Movimiento(new DateTime(2025,10,01), "En tránsito a CD destino", "CD intermedio 0050"),
                }
            },

            // 12) 1040 00011 | 2025-10-08 | 1040→0040 | Admitida | CD 0040
            new Guia
            {
                Numero = "104000011",
                EstadoActual = "Admitida",
                UbicacionActual = "CD Córdoba Capital",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,10,08), "En ruta a CD de origen", ""), // viene de agencia 1040
                    new Guia.Movimiento(new DateTime(2025,10,08), "Admitida",                 "CD Córdoba Capital"),
                }
            },

            // 13) 0070 00150 | 2025-09-18 | 0070→0000 | En ruta a la agencia de entrega (luego irá a EnAgenciaDestino)
            new Guia
            {
                Numero = "007000150",
                EstadoActual = "En ruta a agencia destino",
                UbicacionActual = "",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,09,18), "En CD destino",             "CD Corrientes"),
                    new Guia.Movimiento(new DateTime(2025,09,18), "En ruta a agencia destino", ""),
                }
            },

            // 14) 1011 00005 | 2025-10-03 | 1011→0000 | En espera de retiro en agencia (impuesta)
            new Guia
            {
                Numero = "101100005",
                EstadoActual = "A retirar en agencia",
                UbicacionActual = "Agencia CABA Flores",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,10,03), "A retirar en agencia", "Agencia CABA Flores"),
                }
            },

            // 15) 1024 00007 | 2025-10-07 | 1024→0000 | En espera de retiro al cliente (call center)
            new Guia
            {
                Numero = "102400007",
                EstadoActual = "A retirar por domicilio",
                UbicacionActual = "Domicilio del cliente (Pilar)",
                Historial = new()
                {
                    new Guia.Movimiento(new DateTime(2025,10,07), "A retirar por domicilio", "Domicilio del cliente (Pilar)"),
                }
            },
        };
        */

        // --- PASO 1: CONEXIÓN CON LA CAPA DE DATOS (Almacenes) ---
        // No se necesita una instancia de GuiaAlmacen porque es una clase estática.
        // Se accederá directamente a sus miembros estáticos (ej: GuiaAlmacen.guias).

        // --- PASO 2: IMPLEMENTACIÓN DE LA LÓGICA DE BÚSQUEDA ---
        // Este método es el corazón del caso de uso. Recibe el número de guía desde la pantalla,
        // lo valida, busca la guía en el almacén y devuelve el resultado.
        public Guia? ObtenerPorNumero(string input)
        {
            // Validaciones defensivas (la pantalla ya valida, esto es respaldo)
            if (string.IsNullOrWhiteSpace(input)) return null;
            if (!input.All(char.IsDigit)) return null;
            if (input.Length !=9) return null;

            // Buscar en el almacén por NumeroGuia (int)
            var numeroGuiaBuscado = int.Parse(input);
            var guiaEntidad = GuiaAlmacen.guias.FirstOrDefault(g => g.NumeroGuia == numeroGuiaBuscado);
            if (guiaEntidad == null) return null;

            // Seleccionar ubicación actual: si el último registro tiene ubicación, usarla; si no, "No disponible"
            var historial = guiaEntidad.Historial ?? new List<RegistroEstadoAux>();
            var ultimo = historial.LastOrDefault();
            var ubicacionActual = string.IsNullOrWhiteSpace(ultimo?.UbicacionGuia) ? "No disponible" : ultimo!.UbicacionGuia;

            // Mapear a la clase que usa la pantalla
            var guiaParaPantalla = new Guia
            {
                Numero = guiaEntidad.NumeroGuia.ToString("D9"),
                EstadoActual = guiaEntidad.Estado.ToString().Replace("_", " "),
                UbicacionActual = ubicacionActual,
                Historial = historial
                .Select(h => new Guia.Movimiento(
                    h.FechaActualizacionEstado,
                    h.Estado.ToString().Replace("_", " "),
                    h.UbicacionGuia
                ))
                .OrderBy(m => m.Fecha)
                .ToList()
            };

            return guiaParaPantalla;
        }
    }
}
