// ===============================
// EntregarEncomiendaEnAgenciaModelo.cs
// ===============================

using System.Collections.Generic;
using System.Linq;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.EntregarEncomiendaEnAgencia
{
    public class EntregarEncomiendaEnAgenciaModelo
    {
        public DestinatarioAux? BuscarDestinatarioPorDNI(string dni)
        {
            if (!int.TryParse(dni, out int dniInt))
            {
                return null;
            }
            // La búsqueda de destinatario ahora se hace a través de las guías,
            // ya que no hay un almacén central de destinatarios.
            return GuiaAlmacen.Guias
                .Select(g => g.Destinatario)
                .FirstOrDefault(d => d.DNI == dniInt);
        }

        public List<GuiaEntidad> BuscarGuiasPendientes(string dni, string nombreAgenciaActual)
        {
            if (!int.TryParse(dni, out int dniInt))
            {
                return new List<GuiaEntidad>();
            }

            return GuiaAlmacen.Guias
                .Where(g => g.Destinatario.DNI == dniInt
                            && g.Estado == EstadoGuiaEnum.ARetirarEnAgenciaDeOrigen // O el estado que corresponda
                            && g.AgenciaDestino != null
                            && g.AgenciaDestino.Nombre == nombreAgenciaActual)
                .ToList();
        }

        public bool ConfirmarEntrega(List<int> numerosDeGuia)
        {
            var guiasAEntregar = GuiaAlmacen.Guias.Where(g => numerosDeGuia.Contains(g.Numero)).ToList();

            if (guiasAEntregar.Count != numerosDeGuia.Count)
            {
                // No se encontraron todas las guías, podría ser un error.
                return false;
            }

            foreach (var guia in guiasAEntregar)
            {
                guia.Estado = EstadoGuiaEnum.Entregada;
                guia.Ubicacion = string.Empty; // Sin ubicación cuando está entregada
            }

            GuiaAlmacen.Grabar();
            return true;
        }
    }
}
