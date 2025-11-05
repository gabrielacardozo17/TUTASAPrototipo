using System;
using System.Collections.Generic;
using System.Linq;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.RecepcionYDespachoUltimaMillaCD
{
    public class RecepcionYDespachoUltimaMillaCDModelo
    {
        private int _seqHdr = 1;
        private int _seqGuia = 10000;

        // Propiedad pública para guardar el CD seleccionado
        public CentroDeDistribucionEntidad? CDActual { get; set; } //obtengo el CD desde el form

        // ================= API (usado por el Form) =================

        public FleteroEntidad? BuscarFleteroPorDni(int dni) => FleteroAlmacen.fleteros.FirstOrDefault(f => f.DNI == dni);

        // Devuelve guías que pertenecen a la HDR asignada al fletero
        public (IEnumerable<(GuiaEntidad guia, string hdrId)> distribucion, IEnumerable<(GuiaEntidad guia, string hdrId)> retiro) GetGuiasPorFletero(int dni)
        {
            var hdrsFletero = HDRAlmacen.HDR.Where(h => h.DNIFletero == dni).ToList();

            var guiasDistribucion = hdrsFletero
                .Where(h => h.TipoHDR == TipoHDREnum.Distribucion)
                .SelectMany(h => h.Guias.Select(g => (guia: g, hdrId: h.ID)))
                .Where(x => x.guia.Estado == EstadoGuiaEnum.EnRutaAlDomicilioDeEntrega
                         || x.guia.Estado == EstadoGuiaEnum.EnRutaAlaAgenciaDestino)
                .OrderBy(x => x.guia.NumeroGuia)
                .ToList();

            var guiasRetiro = hdrsFletero
                .Where(h => h.TipoHDR == TipoHDREnum.Retiro)
                .SelectMany(h => h.Guias.Select(g => (guia: g, hdrId: h.ID)))
                .Where(x => x.guia.Estado == EstadoGuiaEnum.EnCaminoARetirarPorDomicilio
                         || x.guia.Estado == EstadoGuiaEnum.EnRutaACDDeOrigenDesdeAgencia)
                .OrderBy(x => x.guia.NumeroGuia)
                .ToList();

            return (guiasDistribucion, guiasRetiro);
        }


        //Busco guias para asignarle al fletero
        public (IEnumerable<(GuiaEntidad guia, string hdrId)> distribucion, IEnumerable<(GuiaEntidad guia, string hdrId)> retiro) AsignarNuevasHDRsPorFletero(int dni, bool grabar)
        {

            if (CDActual == null)
                throw new InvalidOperationException("No se ha asignado un CD.");

           // busco guias que no esten en ninguna HDR
           var guiasPendientes = GuiaAlmacen.guias.Where(g =>!HDRAlmacen.HDR.SelectMany(h => h.Guias)
                                                    .Any(hg => hg.NumeroGuia == g.NumeroGuia)).ToList();


            // para distribucion
            var guiasDistribucion = guiasPendientes.Where(g => g.CodigoPostalCDDestino == CDActual.CodigoPostal 
                                    && (g.Estado == EstadoGuiaEnum.EnCDDestino || g.Estado == EstadoGuiaEnum.Admitida)) // estado para tomar nuevas  guias a distribuir
                                    .OrderBy(g => g.FechaAdmision)
                                    .ToList();

            //para retiro
            var guiasRetiro = guiasPendientes.Where(g => (g.Estado == EstadoGuiaEnum.ARetirarEnAgenciaDeOrigen || g.Estado == EstadoGuiaEnum.ARetirarPorDomicilioDelCliente)
                              && (g.CodigoPostalCDOrigen == CDActual.CodigoPostal))   // condiciones para tomar nuevas guias a retirar
                              .ToList();


            //guardamos las guias en una nueva HDRB
            var nuevasHDRs = new List<HDREntidad>();
            int secuencia = HDRAlmacen.HDR.Count + 1;

            // --- Crear HDRs de Distribución ---
            foreach (var bloque in guiasDistribucion.Chunk(5))
            {

                // Si el destino es domicilio, usamos 00000
                var destino = bloque.First().Destinatario?.CodigoPostal ?? 0;
                var codigoDestino = destino == 0 ? 00000 : destino;
                var codigoOrigen = bloque.First().CodigoPostalCDOrigen;

                var idHdr = $"D {codigoOrigen:00000} {secuencia:000000} {codigoDestino:00000}";

                var hdr = new HDREntidad
                {
                    ID = idHdr,
                    TipoHDR = TipoHDREnum.Distribucion,
                    DNIFletero = dni,
                    Guias = bloque.ToList()
                };

                nuevasHDRs.Add(hdr);
                secuencia++;
            }

            // --- Crear HDRs de Retiro ---
            foreach (var bloque in guiasRetiro.Chunk(5))
            {
                var destino = bloque.First().Destinatario?.CodigoPostal ?? 0;
                var codigoDestino = destino == 0 ? 00000 : destino;
                var codigoOrigen = bloque.First().CodigoPostalCDOrigen;

                var idHdr = $"R {codigoOrigen:00000} {secuencia:000000} {codigoDestino:00000}";

                var hdr = new HDREntidad
                {
                    ID = idHdr,
                    TipoHDR = TipoHDREnum.Retiro,
                    DNIFletero = dni,
                    Guias = bloque.ToList()
                };

                nuevasHDRs.Add(hdr);
                secuencia++;
            }

            //Preparamos los datos a devolver al form
            var distribucion = nuevasHDRs
                .Where(h => h.TipoHDR == TipoHDREnum.Distribucion)
                .SelectMany(h => h.Guias.Select(g => (guia: g, hdrId: h.ID)))
                .OrderBy(x => x.guia.NumeroGuia)
                .ToList();

            var retiro = nuevasHDRs
                .Where(h => h.TipoHDR == TipoHDREnum.Retiro)
                .SelectMany(h => h.Guias.Select(g => (guia: g, hdrId: h.ID)))
                .OrderBy(x => x.guia.NumeroGuia)
                .ToList();


            if (grabar)
            {
                HDRAlmacen.HDR.AddRange(nuevasHDRs);
                HDRAlmacen.Grabar();
                ActualizarNuevaAsignacion(distribucion, retiro);
            }
            return (distribucion, retiro);
        }

        //grabo SOLO SI di click a confirmar
        public void ConfirmarHDRsGeneradas(List<HDREntidad> hdrsAGrabar)
        {
            if (hdrsAGrabar == null || !hdrsAGrabar.Any())
                throw new InvalidOperationException("No hay HDRs para confirmar.");

            HDRAlmacen.HDR.AddRange(hdrsAGrabar);
            HDRAlmacen.Grabar();
        }

        /*
        // Devuelve guías que aún NO están en HDR (para nuevos cuadros)
        public List<GuiaEntidad> GetGuiasPendientes()
        {
            var guiasAsignadas = HDRAlmacen.HDR
                .SelectMany(h => h.Guias)
                .Select(g => g.NumeroGuia)
                .ToHashSet();

            return GuiaAlmacen.guias
                .Where(g => !guiasAsignadas.Contains(g.NumeroGuia)
                            && g.Estado != EstadoGuiaEnum.Entregada
                            && g.Estado != EstadoGuiaEnum.Cancelada
                            && g.Estado != EstadoGuiaEnum.NoEntregada
                            && g.Estado != EstadoGuiaEnum.Facturada)
                .OrderBy(g => g.NumeroGuia)
                .ToList();
        }*/

        // Confirma entrega o retiro de guías en HDR asignadas al fletero, actualiza el estado de las guias marcadas en el checkbox
        public void ConfirmarRendicion(int dni, List<string> entregasDistribucionMarcadas, List<string> retirosMarcados)
        {
            //grabo en Guias y el historial de guias

            var hdrsFletero = HDRAlmacen.HDR.Where(h => h.DNIFletero == dni).ToList();

            foreach (var hdr in hdrsFletero)
            {
                foreach (var g in hdr.Guias)
                {
                    // Distribución
                    if (hdr.TipoHDR == TipoHDREnum.Distribucion && entregasDistribucionMarcadas.Contains(g.NumeroGuia.ToString()))
                    {
                        EstadoGuiaEnum nuevoEstado = g.Estado;
                        switch (g.Estado)
                        {
                            case EstadoGuiaEnum.EnRutaAlaAgenciaDestino:      
                                g.Estado = EstadoGuiaEnum.PendienteDeEntrega;
                                nuevoEstado = EstadoGuiaEnum.PendienteDeEntrega;
                                break;
                            case EstadoGuiaEnum.EnRutaAlDomicilioDeEntrega:      
                                g.Estado = EstadoGuiaEnum.PendienteDeEntrega;
                                nuevoEstado = EstadoGuiaEnum.PendienteDeEntrega;
                                break;
                        }

                        // Guardar historial
                        g.Historial.Add(new RegistroEstadoAux
                        {
                            Estado = g.Estado,
                            UbicacionGuia = "", //a revisar
                            FechaActualizacionEstado = DateTime.Now
                        });

                        // Cambiar estado actual
                        g.Estado = nuevoEstado;
                    }

                    // Retiro
                    if (hdr.TipoHDR == TipoHDREnum.Retiro && retirosMarcados.Contains(g.NumeroGuia.ToString()))
                    {
                     
                        g.Estado = EstadoGuiaEnum.Admitida;
                        // Guardar historial
                        g.Historial.Add(new RegistroEstadoAux
                        {
                            Estado = g.Estado,
                            UbicacionGuia = CDActual.Nombre,
                            FechaActualizacionEstado = DateTime.Now
                        });  

                    }
                }
            }

            HDRAlmacen.Grabar();
        }

        //actualizo el estado de las nuevas guias asignadas
        public void ActualizarNuevaAsignacion(List<(GuiaEntidad guia, string IdHdr)> distribucion, List<(GuiaEntidad guia, string IdHdr)> retiro) 
        {
            foreach(var(guia, hdrId) in distribucion)
    {
                // Cambiar estado según regla
                if (guia.Estado == EstadoGuiaEnum.Admitida || guia.Estado == EstadoGuiaEnum.EnCDDestino)
                {
                    switch (guia.TipoEntrega) {
                        case EntregaEnum.Agencia:
                            guia.Estado = EstadoGuiaEnum.EnRutaAlaAgenciaDestino; 
                            break;

                        case EntregaEnum.Domicilio:
                            guia.Estado = EstadoGuiaEnum.EnRutaAlDomicilioDeEntrega;
                            break;
                    }
                }
                   
                // Guardar en historial
                guia.Historial.Add(new RegistroEstadoAux
                {
                    Estado = guia.Estado,
                    UbicacionGuia = "", //falta
                    FechaActualizacionEstado = DateTime.Now
                });
            }

            foreach (var (guia, hdrId) in retiro)
            {
                if (guia.Estado == EstadoGuiaEnum.ARetirarEnAgenciaDeOrigen)
                {
                    guia.Estado = EstadoGuiaEnum.EnCaminoARetirarPorAgencia;
                }
                else
                {
                    guia.Estado = EstadoGuiaEnum.EnCaminoARetirarPorDomicilio;
                }


                guia.Historial.Add(new RegistroEstadoAux
                {
                    Estado = guia.Estado,
                    UbicacionGuia = "" , //falta
                    FechaActualizacionEstado = DateTime.Now
                }); 
            }
            GuiaAlmacen.Grabar();
        }
        // Asigna nuevas HDRs por dirección (solo guías que aún no están en HDR)
        /*
         public void AsignarHDRsPorDireccion(int dni)
         {
             var guiasPendientes = GetGuiasPendientes();

             foreach (var grp in guiasPendientes.GroupBy(g => NormalizarDestino(g.Destinatario?.Direccion ?? "")))
             {
                 foreach (var chunk in grp.Chunk(5))
                 {
                     var nroHdr = $"H{_seqHdr++:000}";
                     var tipoHdr = chunk.Any(g => EsRetiro(g.Estado)) ? TipoHDREnum.Retiro : TipoHDREnum.Distribucion;

                     var hdr = new HDREntidad
                     {
                         ID = nroHdr,
                         TipoHDR = tipoHdr,
                         DNIFletero = dni,
                         Guias = chunk.ToList()
                     };

                     HDRAlmacen.HDR.Add(hdr);
                 }
             }

             HDRAlmacen.Grabar();
         }
        */

        //obtener los destinos para mostrar en los cuadros
        public string ObtenerDestinoParaRetiro(GuiaEntidad guia)
        {
            if (guia.Estado == EstadoGuiaEnum.ARetirarEnAgenciaDeOrigen)
            {
                // quiero obtener el nombre de la agencia
                var AgenciaRetiro = AgenciaAlmacen.agencias
                                .FirstOrDefault(a => a.ID == guia.IDAgenciaOrigen);
                return AgenciaRetiro?.Nombre ?? guia.IDAgenciaOrigen;
            }
            else
            {
                // quiero obtener la direccion del cliente en donde paso a retirar por domicilio
                var DomicilioRetiro = ClienteAlmacen.clientes
                                .FirstOrDefault(c => c.CUIT == guia.CUITCliente);

                return DomicilioRetiro?.Direccion ?? string.Empty;
            }
        }


        public string ObtenerDestinoParaDistribucion(GuiaEntidad guia)
        {
            //evaluo por el tipo de entrega
            if (guia.TipoEntrega == EntregaEnum.Agencia)
            {
                // quiero obtener el nombre de la agencia
                var AgenciaEntrega = AgenciaAlmacen.agencias
                                .FirstOrDefault(a => a.ID == guia.IDAgenciaOrigen);
                return AgenciaEntrega?.Nombre ?? guia.IDAgenciaOrigen;
            }

            else 
            {
                // quiero obtener la direccion del destinario en donde paso a entregar por domicilio
                var DomicilioEntrega = guia.Destinatario?.Direccion ?? string.Empty;
                return DomicilioEntrega;
            }
          
        }

        // ================= Helpers =================

        private static bool EsRetiro(EstadoGuiaEnum estado) =>
            estado == EstadoGuiaEnum.ARetirarEnAgenciaDeOrigen ||
            estado == EstadoGuiaEnum.ARetirarPorDomicilioDelCliente;

        private static readonly HashSet<EstadoGuiaEnum> EstadosDistribucionAsignables = new()
        {
            EstadoGuiaEnum.Admitida,
            EstadoGuiaEnum.PendienteDeEntrega,
            EstadoGuiaEnum.EnCDDestino,
            EstadoGuiaEnum.EnRutaAlDomicilioDeEntrega,
            EstadoGuiaEnum.EnRutaAlaAgenciaDestino
        };

        private static string NormalizarDestino(string destino) =>
            string.IsNullOrWhiteSpace(destino) ? "DOMICILIO" : destino.Trim().ToUpperInvariant();

        private int NextGuiaNumber() => _seqGuia++;


      /*  public (List<GuiaEntidad> enCDDestino, List<GuiaEntidad> pendientesRetiro) GetGuiasNoAsignadasPorEstado()
{

    // Filtrar las guías que NO están en HDR y que siguen activas
    var guiasNoAsignadas = GuiaAlmacen.guias
        .Where(g => g.Estado !=EstadoGuiaEnum.Entregada
                    && g.Estado != EstadoGuiaEnum.Cancelada
                    && g.Estado != EstadoGuiaEnum.NoEntregada
                    && g.Estado != EstadoGuiaEnum.Facturada)
        .ToList();

    // Cuadro 3: guías en estado EnCDDestino
    var enCDDestino = guiasNoAsignadas
        .Where(g => g.Estado == EstadoGuiaEnum.EnCDDestino)
        .OrderBy(g => g.NumeroGuia)
        .ToList();

    // Cuadro 4: guías pendientes de retiro (usando helper EsRetiro)
    var pendientesRetiro = guiasNoAsignadas
        .Where(g => EsRetiro(g.Estado))
        .OrderBy(g => g.NumeroGuia)
        .ToList();

    return (enCDDestino, pendientesRetiro);
}
      */

    }
}
