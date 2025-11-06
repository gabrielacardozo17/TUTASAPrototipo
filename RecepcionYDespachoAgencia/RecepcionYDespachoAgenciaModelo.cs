using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Text.Json;
using TUTASAPrototipo.Almacenes;


namespace TUTASAPrototipo.RecepcionYDespachoAgencia
{
    public class RecepcionYDespachoAgenciaModelo
    {
        public FleteroEntidad? BuscarFleteroPorDni(int dni) => FleteroAlmacen.fleteros.FirstOrDefault(f => f.DNI == dni);

        public (List<GuiaEntidad> aRecepcionar, List<GuiaEntidad> aEntregar) GetGuiasPorFletero(int dni)
        {
            // N3: el fletero debe existir
            if (BuscarFleteroPorDni(dni) is null)
                throw new InvalidOperationException("No existe el fletero. Vuelva a intentarlo.");

            // string idAgencia = UsuarioAlmacen.usuarioActual!.IDAgencia; //la agencia en donde está el usuario ahora.
            string idAgencia = "01406";

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
                return; // nada para hacer

            DateTime ahora = DateTime.Now;

            // Helper local para asegurar historial
            static void AsegurarHistorial(GuiaEntidad g)
            {
                if (g.Historial == null)
                    g.Historial = new List<RegistroEstadoAux>();
            }

            // Afectar HDRs del fletero
            var hdrsDelFletero = HDRAlmacen.HDR.Where(h => h.DNIFletero == dni).ToList();
            foreach (var hdr in hdrsDelFletero)
            {
                foreach (var g in hdr.Guias.Select(g => GuiaAlmacen.guias.FirstOrDefault(gu => gu.NumeroGuia == g)).Where(x => x != null).Select(x => x!).ToList())
                {
                    // Recepción: EnRutaAlaAgenciaDestino -> PendienteDeEntrega
                    if (recepSet.Contains(g.NumeroGuia) && g.Estado == EstadoGuiaEnum.EnRutaAlaAgenciaDestino)
                    {
                        g.Estado = EstadoGuiaEnum.PendienteDeEntrega;
                        AsegurarHistorial(g);
                        g.Historial.Add(new RegistroEstadoAux
                        {
                            Estado = g.Estado,
                            UbicacionGuia = string.IsNullOrWhiteSpace(g.IDAgenciaDestino) ? string.Empty : $"Agencia {g.IDAgenciaDestino}",
                            FechaActualizacionEstado = ahora
                        });
                    }

                    // Despacho: SOLO EnCaminoARetirarPorAgencia -> EnRutaACDDeOrigenDesdeAgencia
                    if (entregSet.Contains(g.NumeroGuia) && g.Estado == EstadoGuiaEnum.EnCaminoARetirarPorAgencia)
                    {
                        g.Estado = EstadoGuiaEnum.EnRutaACDDeOrigenDesdeAgencia;
                        AsegurarHistorial(g);
                        g.Historial.Add(new RegistroEstadoAux
                        {
                            Estado = g.Estado,
                            UbicacionGuia = string.Empty, // sin ubicación en tránsito
                            FechaActualizacionEstado = ahora
                        });
                    }
                }
            }

            // Reflejar cambios también en el almacén global de guías (si existen allí)
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
                            UbicacionGuia = string.Empty,
                            FechaActualizacionEstado = ahora
                        });
                    }
                }
            }

            // IMPORTANTE: Primero persistir cambios en almacenes
            HDRAlmacen.Grabar();
            GuiaAlmacen.Grabar();

            // Sincronizar JSON: incorporar guías en HDR que no estén en Guias.json y actualizar estados
            SincronizarGuiasDesdeHDR(actualizarEstados: true);

            // NUEVO: Recargar los almacenes desde el JSON actualizado
            RecargarHDRAlmacen();
            RecargarGuiaAlmacen();
        }

        // ===================== Recarga del almacén HDRAlmacen =====================
        private static void RecargarHDRAlmacen()
        {
            var hdrPath = Path.Combine("Datos", "HDR.json");
            if (File.Exists(hdrPath))
            {
                var hdrJson = File.ReadAllText(hdrPath);
                var hdrsCargas = JsonSerializer.Deserialize<List<HDREntidad>>(hdrJson);
                if (hdrsCargas != null)
                {
                    HDRAlmacen.HDR.Clear();
                    HDRAlmacen.HDR.AddRange(hdrsCargas);
                }
            }
        }

        // ===================== Recarga del almacén GuiaAlmacen =====================
        private static void RecargarGuiaAlmacen()
        {
            var guiasPath = Path.Combine("Datos", "Guias.json");
            if (File.Exists(guiasPath))
            {
                var guiaJson = File.ReadAllText(guiasPath);
                var guiasCargadas = JsonSerializer.Deserialize<List<GuiaEntidad>>(guiaJson);
                if (guiasCargadas != null)
                {
                    GuiaAlmacen.guias.Clear();
                    GuiaAlmacen.guias.AddRange(guiasCargadas);
                }
            }
        }

        // ===================== Sincronización solo por JSON (sin tocar Almacenes) =====================
        private static int SincronizarGuiasDesdeHDR(bool actualizarEstados)
        {
            var guiasPath = Path.Combine("Datos", "Guias.json");
            var hdrPath = Path.Combine("Datos", "HDR.json");

            // Cargar actuales
            var guiasJson = File.Exists(guiasPath) ? File.ReadAllText(guiasPath) : "[]";
            var guias = JsonSerializer.Deserialize<List<GuiaEntidad>>(guiasJson) ?? new List<GuiaEntidad>();

            var hdrJson = File.Exists(hdrPath) ? File.ReadAllText(hdrPath) : "[]";
            var hdrs = JsonSerializer.Deserialize<List<HDREntidad>>(hdrJson) ?? new List<HDREntidad>();

            // CORREGIDO: Usar TryAdd en lugar de Add directo
            var index = new Dictionary<int, GuiaEntidad>();
            foreach (var g in guias)
            {
                // Solo agregamos si no existe (evita duplicados en el diccionario)
                if (!index.ContainsKey(g.NumeroGuia))
                    index[g.NumeroGuia] = g;
            }

            int agregadas = 0;

            foreach (var g in hdrs.SelectMany(h => h.Guias.Select(g => GuiaAlmacen.guias.FirstOrDefault(gu => gu.NumeroGuia == g))).Where(x => x != null).Select(x => x!))
            {
                if (!index.ContainsKey(g.NumeroGuia))
                {
                    guias.Add(g);
                    index[g.NumeroGuia] = g;
                    agregadas++;
                }
                else if (actualizarEstados)
                {
                    var destino = index[g.NumeroGuia];
                    destino.Estado = g.Estado;
                    destino.TipoEntrega = g.TipoEntrega;
                    destino.CodigoPostalCDOrigen = g.CodigoPostalCDOrigen;
                    destino.CodigoPostalCDDestino = g.CodigoPostalCDDestino;
                    destino.IDAgenciaOrigen = g.IDAgenciaOrigen;
                    destino.IDAgenciaDestino = g.IDAgenciaDestino;
                    destino.Tamano = g.Tamano;
                    destino.Destinatario = g.Destinatario;
                    destino.ImporteAFacturar = g.ImporteAFacturar;
                    destino.IDConvenio = g.IDConvenio;
                    destino.ComisionAgenciaOrigen = g.ComisionAgenciaOrigen;
                    destino.ComisionAgenciaDestino = g.ComisionAgenciaDestino;
                    destino.ComisionFleteroOrigen = g.ComisionFleteroOrigen;
                    destino.ComisionFleteroDestino = g.ComisionFleteroDestino;

                    // Simplificación: reemplazar historial por el de HDR
                    destino.Historial = g.Historial;
                }
            }

            // Guardar solo si hubo cambios
            if (agregadas > 0 || actualizarEstados)
            {
                var salida = JsonSerializer.Serialize(guias);
                File.WriteAllText(guiasPath, salida);
            }

            return agregadas;
        }
    }
}
