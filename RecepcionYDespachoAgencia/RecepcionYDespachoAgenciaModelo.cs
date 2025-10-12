using System;
using System.Collections.Generic;
using System.Linq;

namespace TUTASAPrototipo.RecepcionYDespachoAgencia
{
    public class RecepcionYDespachoAgenciaModelo
    {
        // ======= Datos de prueba =======
        private readonly List<Fletero> _fleteros = new List<Fletero>
        {
            new Fletero { Dni = 28765432, Nombre = "Juan Pereyra" },
            new Fletero { Dni = 32198765, Nombre = "María Ledesma" }
        };

        // Semilla de guías (mezcla de distribución/retorno)
        private readonly List<Guia> _guias = new List<Guia>
        {
            new Guia { Numero = "104000301", Tamaño = "S",  Destino = "CABA",    Tipo = TipoGuia.Distribucion, Estado = EstadoGuia.Pendiente },
            new Guia { Numero = "104000302", Tamaño = "M",  Destino = "Córdoba", Tipo = TipoGuia.Distribucion, Estado = EstadoGuia.Pendiente },
            new Guia { Numero = "104000401", Tamaño = "L",  Destino = "Rosario", Tipo = TipoGuia.Retiro,       Estado = EstadoGuia.Pendiente },
            new Guia { Numero = "104000402", Tamaño = "XL", Destino = "CABA",    Tipo = TipoGuia.Retiro,       Estado = EstadoGuia.Pendiente }
        };

        // ======= API para el Form =======
        public Fletero? BuscarFleteroPorDni(int dni) => _fleteros.FirstOrDefault(f => f.Dni == dni);

        public (List<Guia> aRecepcionar, List<Guia> aEntregar) GetGuiasPorFletero(int dni)
        {
            // N3: el fletero debe existir
            if (BuscarFleteroPorDni(dni) is null)
                throw new InvalidOperationException("No existe el fletero. Vuelva a intentarlo.");

            // N4: que tenga alguna guía en cualquiera de las listas
            var aRecepcionar = _guias.Where(g => g.Tipo == TipoGuia.Distribucion && g.Estado == EstadoGuia.Pendiente).ToList();
            var aEntregar = _guias.Where(g => g.Tipo == TipoGuia.Retiro && g.Estado == EstadoGuia.Pendiente).ToList();

            if (aRecepcionar.Count == 0 && aEntregar.Count == 0)
                throw new InvalidOperationException("El fletero seleccionado no tiene guías a recibir ni entregar");

            return (aRecepcionar, aEntregar);
        }

        public void ConfirmarOperacion(int dni, List<string> guiasRecepcionadas, List<string> guiasEntregadas)
        {
            // N3: existencia
            if (BuscarFleteroPorDni(dni) is null)
                throw new InvalidOperationException("Debe seleccionar un transportista primero");

            // N4: actualizar estados según marcado en la UI
            foreach (var g in _guias.Where(g => g.Tipo == TipoGuia.Distribucion))
                g.Estado = guiasRecepcionadas.Contains(g.Numero) ? EstadoGuia.Recibida : EstadoGuia.NoProcesada;

            foreach (var g in _guias.Where(g => g.Tipo == TipoGuia.Retiro))
                g.Estado = guiasEntregadas.Contains(g.Numero) ? EstadoGuia.Entregada : EstadoGuia.NoProcesada;
        }
    }
}
