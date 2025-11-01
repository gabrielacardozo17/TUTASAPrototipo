using System;
using System.Collections.Generic;
using System.Linq;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.RecepcionYDespachoUltimaMillaCD
{
    public class RecepcionYDespachoUltimaMillaCDModelo
    {
        private static int _seqHdr = 1;

        public FleteroEntidad? BuscarFleteroPorDni(int dni)
        {
            return FleteroAlmacen.Fleteros.FirstOrDefault(f => f.DNI == dni);
        }

        public (List<GuiaEntidad> distribucion, List<GuiaEntidad> retiro) GetGuiasPorFletero(int dni, string nombreCdActual)
        {
            var fletero = BuscarFleteroPorDni(dni);
            if (fletero is null)
                throw new InvalidOperationException("No existe el fletero. Vuelva a intentarlo.");

            // Guías de DISTRIBUCIÓN: Las que están en el CD actual, listas para salir a reparto (última milla).
            var distribucion = GuiaAlmacen.Guias
                .Where(g => g.Estado == EstadoGuiaEnum.EnCdDestino
                            && g.CentroDistribucionDestino != null
                            && g.CentroDistribucionDestino.Nombre == nombreCdActual)
                .ToList();

            // Guías de RETIRO: Las que el fletero debe ir a buscar a un domicilio.
            var retiro = GuiaAlmacen.Guias
                .Where(g => g.Estado == EstadoGuiaEnum.ARetirarPorDomicilioDelCliente)
                .ToList();

            if (distribucion.Count == 0 && retiro.Count == 0)
                throw new InvalidOperationException("El fletero no tiene guías de distribución ni de retiro asignadas en este CD.");

            return (distribucion, retiro);
        }

        public void ConfirmarRendicionYAsignarHDR(int dni, List<int> guiasDistribucionEntregadas, List<int> guiasRetiradas, string nombreCdActual)
        {
            var fletero = BuscarFleteroPorDni(dni);
            if (fletero is null)
                throw new InvalidOperationException("Debe seleccionar un transportista primero.");

            var cdActual = CentroDistribucionAlmacen.CDs.FirstOrDefault(cd => cd.Nombre == nombreCdActual);
            if (cdActual == null)
                throw new InvalidOperationException("El Centro de Distribución actual no es válido.");

            // 1. Procesar guías de DISTRIBUCIÓN rendidas como entregadas
            foreach (var numeroGuia in guiasDistribucionEntregadas)
            {
                var guia = GuiaAlmacen.Guias.FirstOrDefault(g => g.Numero == numeroGuia);
                if (guia != null)
                {
                    guia.Estado = EstadoGuiaEnum.Entregada;
                    guia.Ubicacion = "Entregado";
                }
            }

            // 2. Procesar guías de RETIRO rendidas como recolectadas
            foreach (var numeroGuia in guiasRetiradas)
            {
                var guia = GuiaAlmacen.Guias.FirstOrDefault(g => g.Numero == numeroGuia);
                if (guia != null)
                {
                    guia.Estado = EstadoGuiaEnum.Admitida;
                    guia.Ubicacion = nombreCdActual;
                    guia.CentroDistribucionOrigen = cdActual; // Se formaliza el origen
                }
            }

            // 3. Asignar nuevas Hojas de Ruta (HDR) para lo que queda
            var guiasParaDistribuir = GuiaAlmacen.Guias
                .Where(g => g.Estado == EstadoGuiaEnum.EnCdDestino && g.CentroDistribucionDestino?.Nombre == nombreCdActual)
                .ToList();

            var guiasParaRetirar = GuiaAlmacen.Guias
                .Where(g => g.Estado == EstadoGuiaEnum.ARetirarPorDomicilioDelCliente)
                .ToList();

            // Ultima milla a domicilio
            var guiasPorDomicilio = guiasParaDistribuir
                .Where(g => g.Entrega == EntregaEnum.Domicilio)
                .GroupBy(g => g.Destinatario.Direccion);
            foreach (var grupo in guiasPorDomicilio)
            {
                HojasDeRuta.Add(new HDREntidad
                {
                    ID = ($"D{_seqHdr++:D6}"),
                    TipoHDR = TipoHDREnumeracion.UltimaMilla,
                    DNIFletero = dni,
                    IDServicioTransporte = 0,
                    Guias = grupo.Select(g => g.Numero).ToList(),
                    CodPostalOrigen = 0,
                    CodPostalDestino = grupo.FirstOrDefault()?.Destinatario.CodigoPostal ?? 0
                });
            }

            // Despacho a agencia (desde CD destino a agencia)
            var guiasPorAgencia = guiasParaDistribuir
                .Where(g => g.Entrega == EntregaEnum.Agencia)
                .GroupBy(g => g.AgenciaDestino);
            foreach (var grupo in guiasPorAgencia)
            {
                HojasDeRuta.Add(new HDREntidad
                {
                    ID = ($"A{_seqHdr++:D6}"),
                    TipoHDR = TipoHDREnumeracion.DespachoAgencia,
                    DNIFletero = dni,
                    IDServicioTransporte = 0,
                    Guias = grupo.Select(g => g.Numero).ToList(),
                    CodPostalOrigen = 0,
                    CodPostalDestino = grupo.Key?.CentroDeDistribucion?.Localidad?.Id ?? 0
                });
            }
        }

        public List<HDREntidad> HojasDeRuta { get; private set; } = new();

        public void CargarGuias()
        {
            var nombreCdActual = "CD Corrientes"; // Properties.Settings.Default.CD;
            var cdActual = CentroDistribucionAlmacen.CDs.FirstOrDefault(cd => cd.Nombre == nombreCdActual);
            if (cdActual == null) return;

            var guiasParaEntrega = GuiaAlmacen.Guias
                .Where(g => g.CentroDistribucionDestino?.Id == cdActual.Id && g.Estado == EstadoGuiaEnum.EnCdDestino)
                .ToList();

            // Ultima milla a domicilio
            var guiasPorDomicilio = guiasParaEntrega
                .Where(g => g.Entrega == EntregaEnum.Domicilio)
                .GroupBy(g => g.Destinatario.Direccion);

            foreach (var grupo in guiasPorDomicilio)
            {
                HojasDeRuta.Add(new HDREntidad
                {
                    ID = ($"D{_seqHdr++:D6}"),
                    TipoHDR = TipoHDREnumeracion.UltimaMilla,
                    DNIFletero = 0,
                    IDServicioTransporte = 0,
                    Guias = grupo.Select(g => g.Numero).ToList(),
                    CodPostalOrigen = 0,
                    CodPostalDestino = grupo.FirstOrDefault()?.Destinatario.CodigoPostal ?? 0
                });
            }

            // Despacho a agencia
            var guiasPorAgencia = guiasParaEntrega
                .Where(g => g.Entrega == EntregaEnum.Agencia)
                .GroupBy(g => g.AgenciaDestino);

            foreach (var grupo in guiasPorAgencia)
            {
                HojasDeRuta.Add(new HDREntidad
                {
                    ID = ($"A{_seqHdr++:D6}"),
                    TipoHDR = TipoHDREnumeracion.DespachoAgencia,
                    DNIFletero = 0,
                    IDServicioTransporte = 0,
                    Guias = grupo.Select(g => g.Numero).ToList(),
                    CodPostalOrigen = 0,
                    CodPostalDestino = grupo.Key?.CentroDeDistribucion?.Localidad?.Id ?? 0
                });
            }
        }
    }
}
