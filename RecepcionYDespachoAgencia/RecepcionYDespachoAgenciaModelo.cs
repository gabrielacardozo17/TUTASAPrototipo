using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using TUTASAPrototipo.Almacenes;


namespace TUTASAPrototipo.RecepcionYDespachoAgencia
{
    public class RecepcionYDespachoAgenciaModelo
    {
        // Nuevo: CD actual tomado desde la selección global del login
        public CentroDeDistribucionEntidad? CDActual { get; set; } = CentroDeDistribucionAlmacen.CentroDistribucionActual;
        public string GetNombreCDActual() => CDActual?.Nombre ?? CentroDeDistribucionAlmacen.CentroDistribucionActual?.Nombre ?? string.Empty;

        private FleteroEntidad? BuscarFleteroPorDni(int dni) => FleteroAlmacen.fleteros.FirstOrDefault(f => f.DNI == dni);

        public (bool existe, string nombre, string apellido) ObtenerDatosFletero(int dni)
        {
            var fletero = BuscarFleteroPorDni(dni);
            if (fletero == null)
                return (false, string.Empty, string.Empty);
            
            return (true, fletero.Nombre, fletero.Apellido);
        }

        private (List<GuiaEntidad> aRecepcionar, List<GuiaEntidad> aEntregar) GetGuiasPorFletero(int dni)
        {
            // N3: el fletero debe existir
            if (BuscarFleteroPorDni(dni) is null)
                throw new InvalidOperationException("No existe el fletero. Vuelva a intentarlo.");

            

            //busco las HDRS asignadas a ese fletero
            var hdrsDeRetiroFletero = HDRAlmacen.HDR.Where(h => h.DNIFletero == dni && h.TipoHDR == TipoHDREnum.Retiro).ToList();
            var hdrsDeDistribucionFletero = HDRAlmacen.HDR.Where(h => h.DNIFletero == dni && h.TipoHDR == TipoHDREnum.Distribucion).ToList();

            //obtengo las guias de esas HDRS
            var guiasDeRetiro = hdrsDeRetiroFletero.SelectMany(h => h.Guias).ToList();
            var guiasDeDistribucion = hdrsDeDistribucionFletero.SelectMany(h => h.Guias).ToList();

            // RECEPCIÓN: deben venir de distribución y estar EnRutaAlaAgenciaDestino
            var aRecepcionar = guiasDeDistribucion
              .Where(g => GuiaAlmacen.guias.FirstOrDefault(gu => gu.NumeroGuia == g)?.Estado == EstadoGuiaEnum.EnRutaAlaAgenciaDestino)
            .Select(g => GuiaAlmacen.guias.FirstOrDefault(gu => gu.NumeroGuia == g))
            .Where(g => g != null)
            .Select(g => g!)
            .ToList();

            // DESPACHO: SOLO considerar EnCaminoARetirarPorAgencia
            // (las que están ARetirarEnAgenciaDeOrigen no son para esta pantalla, 
            // esas esperan que el fletero vaya a buscarlas)
            var aEntregar = guiasDeRetiro
             .Where(g => GuiaAlmacen.guias.FirstOrDefault(gu => gu.NumeroGuia == g)?.Estado == EstadoGuiaEnum.EnCaminoARetirarPorAgencia)
             .Select(g => GuiaAlmacen.guias.FirstOrDefault(gu => gu.NumeroGuia == g))
             .Where(g => g != null)
             .Select(g => g!)
               .ToList();

            if (aRecepcionar.Count == 0 && aEntregar.Count == 0)
                throw new InvalidOperationException("El fletero seleccionado no tiene guías a recibir ni entregar");

            return (aRecepcionar, aEntregar);
        }

        public (List<GuiaDTO> aRecepcionar, List<GuiaDTO> aEntregar) ObtenerGuiasPorFletero(int dni)
        {
            // N3: el fletero debe existir
            if (BuscarFleteroPorDni(dni) is null)
                throw new InvalidOperationException("No existe el fletero. Vuelva a intentarlo.");

            var (guiasRecep, guiasEntreg) = GetGuiasPorFletero(dni);
            
            // Convertir entidades a DTOs
            var recepcionDTO = guiasRecep.Select(g => new GuiaDTO
            {
                NumeroGuia = g.NumeroGuia,
                Tamano = g.Tamano
            }).ToList();

            var entregaDTO = guiasEntreg.Select(g => new GuiaDTO
            {
                NumeroGuia = g.NumeroGuia,
                Tamano = g.Tamano
            }).ToList();

            if (recepcionDTO.Count == 0 && entregaDTO.Count == 0)
                throw new InvalidOperationException("El fletero seleccionado no tiene guías a recibir ni entregar");

            return (recepcionDTO, entregaDTO);
        }

        public void ConfirmarOperacion(int dni, List<string> guiasRecepcionadas, List<string> guiasEntregadas)
        {
            // N3: existencia
            if (BuscarFleteroPorDni(dni) is null)
                throw new InvalidOperationException("Debe indicar a un fletero primero");

            // Normalizar listas a numeros de guía
            var recepSet = new HashSet<int>(
             (guiasRecepcionadas ?? new List<string>())
                .Select(s => int.TryParse(s, out var n) ? n : (int?)null)
                .Where(n => n.HasValue)
                .Select(n => n!.Value)
        );

            var entregSet = new HashSet<int>(
                    (guiasEntregadas ?? new List<string>())
         .Select(s => int.TryParse(s, out var n) ? n : (int?)null)
              .Where(n => n.HasValue)
              .Select(n => n!.Value)
      );

            if (recepSet.Count == 0 && entregSet.Count == 0)
                return; 

            DateTime ahora = DateTime.Now;

            // Reflejar cambios en el almacén global de guías (solo guías)
            if (GuiaAlmacen.guias is not null && GuiaAlmacen.guias.Count > 0)
            {
                foreach (var g in GuiaAlmacen.guias)
                {
                    if (recepSet.Contains(g.NumeroGuia) && g.Estado == EstadoGuiaEnum.EnRutaAlaAgenciaDestino)
                    {
                        g.Estado = EstadoGuiaEnum.PendienteDeEntrega;
                        if (g.Historial == null) g.Historial = new List<RegistroEstadoAux>();
                        g.Historial.Add(new RegistroEstadoAux
                        {
                            Estado = g.Estado,
                            UbicacionGuia = string.IsNullOrWhiteSpace(g.IDAgenciaDestino) ? string.Empty : $"Agencia {g.IDAgenciaDestino}",
                            FechaActualizacionEstado = ahora
                        });
                    }
                    else if (entregSet.Contains(g.NumeroGuia) && g.Estado == EstadoGuiaEnum.EnCaminoARetirarPorAgencia)
                    {
                        g.Estado = EstadoGuiaEnum.EnRutaACDDeOrigenDesdeAgencia;
                        if (g.Historial == null) g.Historial = new List<RegistroEstadoAux>();
                        g.Historial.Add(new RegistroEstadoAux
                        {
                            Estado = g.Estado,
                            UbicacionGuia = $"En transporte con Fletero DNI: {dni}",
                            FechaActualizacionEstado = ahora
                        });
                    }
                }
            }

            // Persistir si corresponde (si grabas al cerrar, puedes quitar esta línea)
            // GuiaAlmacen.Grabar();
        }
    }

                                // PREGUNTAR  DTO para transferir datos de guías sin exponer la entidad completa
                                public class GuiaDTO
                                {
                                    public int NumeroGuia { get; set; }
                                    public TamanoEnum Tamano { get; set; }
                                }
}
