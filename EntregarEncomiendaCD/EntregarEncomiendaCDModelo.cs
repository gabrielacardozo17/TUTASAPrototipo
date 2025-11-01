// ===============================
// EntregarEncomiendaCDModelo.cs
// ===============================
using System.Collections.Generic;
using System.Linq;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.EntregarEncomiendaCD
{
    public class EntregarEncomiendaCDModelo
    {
        public DestinatarioAux? BuscarDestinatarioPorDNI(string dni)
        {
            if (!int.TryParse(dni, out int dniInt))
            {
                return null;
            }
            return GuiaAlmacen.Guias
                .Select(g => g.Destinatario)
                .FirstOrDefault(d => d.DNI == dniInt);
        }

        public List<GuiaEntidad> BuscarGuiasPendientes(string dni, string nombreCdActual)
        {
            if (!int.TryParse(dni, out int dniInt))
            {
                return new List<GuiaEntidad>();
            }

            return GuiaAlmacen.Guias
                .Where(g => g.Destinatario.DNI == dniInt
                            && g.Estado == EstadoGuiaEnum.EnCdDestino // O el estado que corresponda para retiro en CD
                            && g.CentroDistribucionDestino != null
                            && g.CentroDistribucionDestino.Nombre == nombreCdActual)
                .ToList();
        }

        public bool ConfirmarEntrega(List<int> numerosDeGuia)
        {
            var guiasAEntregar = GuiaAlmacen.Guias.Where(g => numerosDeGuia.Contains(g.Numero)).ToList();

            if (guiasAEntregar.Count != numerosDeGuia.Count)
            {
                return false;
            }

            foreach (var guia in guiasAEntregar)
            {
                guia.Estado = EstadoGuiaEnum.Entregada;
                guia.Ubicacion = string.Empty;
            }

            GuiaAlmacen.Grabar();
            return true;
        }
    }
}
