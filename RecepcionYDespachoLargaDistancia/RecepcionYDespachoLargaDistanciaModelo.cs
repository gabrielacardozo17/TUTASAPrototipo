using System;
using System.Collections.Generic;
using System.Linq;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.RecepcionYDespachoLargaDistancia
{
    public class RecepcionYDespachoLargaDistanciaModelo
    {
        public ServicioTransporteEntidad? BuscarServicio(string numeroServicio)
        {
            if (!int.TryParse(numeroServicio, out int numeroServicioInt))
            {
                return null;
            }
            return ServicioTransporteAlmacen.ServiciosTransporte.FirstOrDefault(s => s.Id == numeroServicioInt);
        }

        public (List<GuiaEntidad> aRecepcionar, List<GuiaEntidad> aDespachar) GetGuiasPorServicio(int numeroServicio, string nombreCdActual)
        {
            var servicio = ServicioTransporteAlmacen.ServiciosTransporte.FirstOrDefault(s => s.Id == numeroServicio);
            if (servicio is null)
                throw new InvalidOperationException("No existe el servicio de transporte. Vuelva a intentarlo.");

            // Guías para RECEPCIONAR: Vienen de otro CD y su destino es el CD actual.
            var aRecepcionar = GuiaAlmacen.Guias
                .Where(g => g.Estado == EstadoGuiaEnum.EnTransitoAlCDDestino
                            && g.CentroDistribucionDestino != null
                            && g.CentroDistribucionDestino.Nombre == nombreCdActual)
                .ToList();

            // Guías para DESPACHAR: Están en el CD actual y deben ir a otro CD.
            var aDespachar = GuiaAlmacen.Guias
                .Where(g => g.Estado == EstadoGuiaEnum.Admitida
                            && g.CentroDistribucionOrigen != null
                            && g.CentroDistribucionOrigen.Nombre == nombreCdActual
                            && g.CentroDistribucionDestino != null
                            && g.CentroDistribucionOrigen.Id != g.CentroDistribucionDestino.Id)
                .ToList();

            if (aRecepcionar.Count == 0 && aDespachar.Count == 0)
                throw new InvalidOperationException("El servicio de transporte no tiene guías a recibir ni despachar en este CD.");

            return (aRecepcionar, aDespachar);
        }

        public void ConfirmarOperacion(int numeroServicio, List<int> guiasRecibidas, List<int> guiasDespachadas, string nombreCdActual)
        {
            var servicio = ServicioTransporteAlmacen.ServiciosTransporte.FirstOrDefault(s => s.Id == numeroServicio);
            if (servicio is null)
                throw new InvalidOperationException("Debe seleccionar un servicio de transporte primero");

            // Actualizar guías recibidas
            foreach (var numeroGuia in guiasRecibidas)
            {
                var guia = GuiaAlmacen.Guias.FirstOrDefault(g => g.Numero == numeroGuia);
                if (guia != null)
                {
                    guia.Estado = EstadoGuiaEnum.EnCdDestino;
                    guia.Ubicacion = nombreCdActual;
                }
            }

            // Actualizar guías despachadas
            foreach (var numeroGuia in guiasDespachadas)
            {
                var guia = GuiaAlmacen.Guias.FirstOrDefault(g => g.Numero == numeroGuia);
                if (guia != null)
                {
                    guia.Estado = EstadoGuiaEnum.EnTransitoAlCDDestino;
                    guia.Ubicacion = $"En tránsito hacia {guia.CentroDistribucionDestino?.Nombre}";
                }
            }

            GuiaAlmacen.Grabar();
        }
    }
}