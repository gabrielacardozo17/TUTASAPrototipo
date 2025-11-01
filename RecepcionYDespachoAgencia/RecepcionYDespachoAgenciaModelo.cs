using System;
using System.Collections.Generic;
using System.Linq;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.RecepcionYDespachoAgencia
{
    public class RecepcionYDespachoAgenciaModelo
    {
        public FleteroEntidad? BuscarFleteroPorDni(int dni)
        {
            return FleteroAlmacen.Fleteros.FirstOrDefault(f => f.DNI == dni);
        }

        public (List<GuiaEntidad> aRecepcionar, List<GuiaEntidad> aDespachar) GetGuiasPorFletero(int dni, string nombreAgenciaActual)
        {
            var fletero = BuscarFleteroPorDni(dni);
            if (fletero is null)
                throw new InvalidOperationException("No existe el fletero. Vuelva a intentarlo.");

            // Guías para RECEPCIONAR: Vienen de un CD y su destino es la agencia actual.
            var aRecepcionar = GuiaAlmacen.Guias
                .Where(g => g.Estado == EstadoGuiaEnum.EnRutaAlaAgenciaDestino
                            && g.AgenciaDestino != null
                            && g.AgenciaDestino.Nombre == nombreAgenciaActual)
                .ToList();

            // Guías para DESPACHAR: Están en la agencia actual y deben ir al CD de origen.
            var aDespachar = GuiaAlmacen.Guias
                .Where(g => g.Estado == EstadoGuiaEnum.ARetirarEnAgenciaDeOrigen
                            && g.AgenciaOrigen != null
                            && g.AgenciaOrigen.Nombre == nombreAgenciaActual)
                .ToList();

            if (aRecepcionar.Count == 0 && aDespachar.Count == 0)
                throw new InvalidOperationException("El fletero seleccionado no tiene guías a recibir ni entregar en esta agencia.");

            return (aRecepcionar, aDespachar);
        }

        public void ConfirmarOperacion(int dni, List<int> guiasRecepcionadas, List<int> guiasDespachadas, string nombreAgenciaActual)
        {
            var fletero = BuscarFleteroPorDni(dni);
            if (fletero is null)
                throw new InvalidOperationException("Debe seleccionar un transportista primero");

            // Actualizar guías recepcionadas
            foreach (var numeroGuia in guiasRecepcionadas)
            {
                var guia = GuiaAlmacen.Guias.FirstOrDefault(g => g.Numero == numeroGuia);
                if (guia != null)
                {
                    guia.Estado = EstadoGuiaEnum.PendienteDeEntrega; // O el estado que corresponda
                    guia.Ubicacion = nombreAgenciaActual;
                }
            }

            // Actualizar guías despachadas
            foreach (var numeroGuia in guiasDespachadas)
            {
                var guia = GuiaAlmacen.Guias.FirstOrDefault(g => g.Numero == numeroGuia);
                if (guia != null)
                {
                    guia.Estado = EstadoGuiaEnum.EnRutaACdDeOrigenDesdeAgencia;
                    guia.Ubicacion = $"En tránsito hacia {guia.CentroDistribucionOrigen?.Nombre}";
                }
            }

            GuiaAlmacen.Grabar();
        }
    }
}
