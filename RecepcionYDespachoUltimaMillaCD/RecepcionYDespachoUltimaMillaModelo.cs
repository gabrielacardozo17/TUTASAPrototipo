using System;
using System.Collections.Generic;
using System.Linq;

namespace TUTASAPrototipo.RecepcionYDespachoUltimaMillaCD
{
    public class RecepcionYDespachoUltimaMillaCDModelo
    {
        // ========= Datos de prueba =========
        private readonly List<Fletero> _fleteros = new List<Fletero>
        {
            new Fletero { Nombre = "Juan Pereyra",  Dni = 28765432 },
            new Fletero { Nombre = "María Ledesma", Dni = 32198765 }
        };

        private readonly List<Guia> _guias = new List<Guia>
        {
            new Guia { Numero = "104000123", Destino = "CABA",     Tamaño = "S", Tipo = TipoGuia.Distribucion, Estado = EstadoGuia.Pendiente },
            new Guia { Numero = "104000124", Destino = "CABA",     Tamaño = "M", Tipo = TipoGuia.Retiro,       Estado = EstadoGuia.Pendiente },
            new Guia { Numero = "104000125", Destino = "Córdoba",  Tamaño = "L", Tipo = TipoGuia.Distribucion, Estado = EstadoGuia.Pendiente },
            new Guia { Numero = "104000126", Destino = "Rosario",  Tamaño = "S", Tipo = TipoGuia.Retiro,       Estado = EstadoGuia.Pendiente }
        };

        // ========= API para el Form =========
        public Fletero? BuscarFleteroPorDni(int dni) =>
            _fleteros.FirstOrDefault(f => f.Dni == dni);

        public IEnumerable<Guia> GetGuiasPorFletero(int dni)
        {
            // N3: el fletero debe existir
            if (BuscarFleteroPorDni(dni) is null)
                throw new InvalidOperationException("No existe el fletero. Vuelva a intentarlo.");

            // N4: debe haber guías pendientes
            var asignadas = _guias.Where(g => g.Estado == EstadoGuia.Pendiente).ToList();
            if (asignadas.Count == 0)
                throw new InvalidOperationException("El fletero seleccionado no posee guías asignadas ni nuevas HDR disponibles.");

            return asignadas;
        }

        public List<Guia> ConfirmarRendicion(int dni, List<string> guiasCumplidas)
        {
            // N3: existencia fletero
            var fletero = BuscarFleteroPorDni(dni);
            if (fletero is null)
                throw new InvalidOperationException("No existe el fletero. Vuelva a intentarlo.");

            // N4: actualizar estado según selección del usuario
            foreach (var g in _guias)
            {
                if (guiasCumplidas.Contains(g.Numero))
                    g.Estado = EstadoGuia.Cumplida;
                else if (g.Estado == EstadoGuia.Pendiente)
                    g.Estado = EstadoGuia.NoCumplida;
            }

            // Generar nuevas HDR (simuladas) de RETIRO
            return GenerarNuevasHDR();
        }

        // ========= Helpers =========
        private static int _seq = 200;
        private static string NextGuiaNumber() => $"104{_seq++:000000}";

        // No usa estado de instancia => static
        private static List<Guia> GenerarNuevasHDR() => new List<Guia>
        {
            new Guia { Numero = NextGuiaNumber(), Destino = "Córdoba", Tamaño = "S", Tipo = TipoGuia.Retiro, Estado = EstadoGuia.Pendiente },
            new Guia { Numero = NextGuiaNumber(), Destino = "Rosario", Tamaño = "M", Tipo = TipoGuia.Retiro, Estado = EstadoGuia.Pendiente }
        };
    }
}
