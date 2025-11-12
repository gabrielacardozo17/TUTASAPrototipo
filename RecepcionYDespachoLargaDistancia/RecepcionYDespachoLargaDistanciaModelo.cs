using System.Collections.Generic;
using System.Linq;
using TUTASAPrototipo.Almacenes;
using System; // para DateTime

namespace TUTASAPrototipo.RecepcionYDespachoLargaDistancia
{
    public class RecepcionYDespachoLargaDistanciaModelo
    {
        private List<ServicioTransporte> servicios;
        private List<Guia> guiasPendientesDeAsignacion;
        private readonly Dictionary<int, List<(int nextCd, int servicioId)>> _planesRuta = new();
        private readonly Dictionary<int, int> _indiceHopActual = new();

        public RecepcionYDespachoLargaDistanciaModelo()
        {
            CargarDatosDePrueba();
            MapearDesdeAlmacenes();
        }

        public CentroDeDistribucionEntidad? CDActual { get; set; }
        public void SetCDActual(CentroDeDistribucionEntidad? cd)
        {
            CDActual = cd ?? CentroDeDistribucionAlmacen.CentroDistribucionActual;
            MapearDesdeAlmacenes();
        }

        // =================== NUEVAS VALIDACIONES (solo modelo) ===================
        // Indica si el servicio existe y tiene al menos una guía (recibir o despachar)
        public bool ServicioTieneGuias(string numeroServicio)
        {
            var s = BuscarServicio(numeroServicio);
            return s != null && ((s.GuiasARecibir?.Count ?? 0) > 0 || (s.GuiasADespachar?.Count ?? 0) > 0);
        }

        // Indica si el servicio no tiene guías (recibir ni despachar)
        public bool ServicioSinGuias(string numeroServicio) => !ServicioTieneGuias(numeroServicio);

        // Indica si después de confirmar el servicio quedó sin guías pendientes
        public bool ServicioSinGuiasPostConfirmacion(string numeroServicio)
        {
            var s = BuscarServicio(numeroServicio);
            return s == null || ((s.GuiasARecibir?.Count ?? 0) == 0 && (s.GuiasADespachar?.Count ?? 0) == 0);
        }

        private static int CapacidadPorTamano(TamanoEnum tam) => tam switch
        {
            TamanoEnum.S => 1,
            TamanoEnum.M => 2,
            TamanoEnum.L => 3,
            TamanoEnum.XL => 4,
            _ => 1
        };

        private static int CalcularCapacidadUsadaPorServicio(int idServicio, IEnumerable<HDREntidad> hdrs, IEnumerable<GuiaEntidad> guias)
        {
            var guiasEnHDR = hdrs
                .Where(h => h.IDServicioTransporte == idServicio)
                .SelectMany(h => h.Guias)
                .Join(guias, num => num, g => g.NumeroGuia, (num, g) => g);
            return guiasEnHDR.Sum(g => CapacidadPorTamano(g.Tamano));
        }

        private static void ConstruirGrafoGlobal(IEnumerable<ServicioTransporteEntidad> servicios, out Dictionary<int, List<int>> adj, out Dictionary<(int,int), List<int>> tramoServicios)
        {
            adj = new();
            tramoServicios = new();
            foreach (var s in servicios)
            {
                if (s.Tramos == null) continue;
                foreach (var t in s.Tramos)
                {
                    if (!adj.TryGetValue(t.CodigoPostalOrigen, out var lista))
                    {
                        lista = new List<int>();
                        adj[t.CodigoPostalOrigen] = lista;
                    }
                    if (!lista.Contains(t.CodigoPostalDestino)) lista.Add(t.CodigoPostalDestino);

                    var key = (t.CodigoPostalOrigen, t.CodigoPostalDestino);
                    if (!tramoServicios.TryGetValue(key, out var svcs))
                    {
                        svcs = new List<int>();
                        tramoServicios[key] = svcs;
                    }
                    if (!svcs.Contains(s.ID)) svcs.Add(s.ID);
                }
            }
        }

        private static List<int> CalcularRutaGlobal(int origen, int destino, Dictionary<int, List<int>> adj)
        {
            var ruta = new List<int>();
            if (origen == destino) { ruta.Add(origen); return ruta; }
            var prev = new Dictionary<int,int>();
            var q = new Queue<int>();
            q.Enqueue(origen);
            var visited = new HashSet<int>{origen};
            bool found = false;
            while(q.Count>0 && !found)
            {
                var n = q.Dequeue();
                if (!adj.TryGetValue(n, out var vecinos)) continue;
                foreach(var v in vecinos)
                {
                    if (visited.Add(v))
                    {
                        prev[v]=n;
                        if (v==destino) { found=true; break; }
                        q.Enqueue(v);
                    }
                }
            }
            if (!found) { ruta.Add(origen); ruta.Add(destino); return ruta; }
            int cur=destino; var stack=new Stack<int>(); stack.Push(cur);
            while(prev.ContainsKey(cur)) { cur = prev[cur]; stack.Push(cur); }
            ruta = stack.ToList();
            return ruta;
        }

        private void PlanificarRutaSiNecesaria(GuiaEntidad guia, IEnumerable<ServicioTransporteEntidad> serviciosEnt, int cdActual)
        {
            if (_planesRuta.ContainsKey(guia.NumeroGuia)) return;
            ConstruirGrafoGlobal(serviciosEnt, out var adj, out var tramoServicios);
            var rutaCds = CalcularRutaGlobal(cdActual, guia.CodigoPostalCDDestino, adj);
            if (rutaCds.Count < 2)
            {
                rutaCds = new List<int>{cdActual, guia.CodigoPostalCDDestino};
            }
            var hops = new List<(int nextCd,int servicioId)>();
            for (int i=0;i<rutaCds.Count-1;i++)
            {
                var orig = rutaCds[i];
                var dest = rutaCds[i+1];
                int servicioAsignado = tramoServicios.TryGetValue((orig,dest), out var svcs) ? svcs.First() : 0;
                hops.Add((dest, servicioAsignado));
            }
            _planesRuta[guia.NumeroGuia] = hops;
            _indiceHopActual[guia.NumeroGuia] = 0;
        }

        private int ObtenerProximoHop(int numeroGuia)
        {
            if (!_planesRuta.TryGetValue(numeroGuia, out var hops)) return 0;
            if (!_indiceHopActual.TryGetValue(numeroGuia, out var idx)) return 0;
            if (idx >= hops.Count) return 0;
            return hops[idx].nextCd;
        }

        private void AvanzarHop(int numeroGuia)
        {
            if (_indiceHopActual.ContainsKey(numeroGuia)) _indiceHopActual[numeroGuia]++;
        }

        private void MapearDesdeAlmacenes()
        {
            var serviciosEnt = ServicioTransporteAlmacen.serviciosTransporte ?? new List<ServicioTransporteEntidad>();
            var hdrs = HDRAlmacen.HDR ?? new List<HDREntidad>();
            var guiasAlmacen = GuiaAlmacen.guias ?? new List<GuiaEntidad>();
            var cds = CentroDeDistribucionAlmacen.centrosDeDistribucion ?? new List<CentroDeDistribucionEntidad>();
            int? codigoPostalCDActual = CDActual?.CodigoPostal ?? CentroDeDistribucionAlmacen.CentroDistribucionActual?.CodigoPostal;
            var cdNombreActual = cds.FirstOrDefault(cd => cd.CodigoPostal == codigoPostalCDActual)?.Nombre ?? string.Empty;

            this.servicios = serviciosEnt
                .GroupJoin(hdrs, s => s.ID, h => h.IDServicioTransporte, (s, hdrGroup) => new { s, hdrGroup })
                .Select(x =>
                {
                    var s = x.s;
                    var hdrGroup = x.hdrGroup;
                    int capacidadUsada = CalcularCapacidadUsadaPorServicio(s.ID, hdrs, guiasAlmacen);
                    int capacidadTotal = Math.Max(0, s.CapacidadBodega);
                    int capacidadRestante = Math.Max(0, capacidadTotal - capacidadUsada);

                    var guiasARecibir = hdrGroup
                        .Where(h => codigoPostalCDActual.HasValue && h.CodigoPostalDestino == codigoPostalCDActual.Value)
                        .SelectMany(h => h.Guias.Select(num => guiasAlmacen.FirstOrDefault(g => g.NumeroGuia == num)))
                        .Where(g => g != null)
                        .Select(g => g!)
                        .Where(g => g.Estado == EstadoGuiaEnum.EnTransitoAlCDDestino)
                        .Select(g => new Guia
                        {
                            NroGuia = g.NumeroGuia.ToString(),
                            Tamanio = g.Tamano.ToString(),
                            Destino = cds.FirstOrDefault(cd => cd.CodigoPostal == g.CodigoPostalCDDestino)?.Nombre ?? g.CodigoPostalCDDestino.ToString()
                        })
                        .OrderBy(g => g.NroGuia)
                        .ToList();

                    var guiasADespachar = new List<Guia>();
                    if (codigoPostalCDActual.HasValue && capacidadRestante > 0)
                    {
                        var candidatas = guiasAlmacen
                            .Where(ga => ga.CodigoPostalCDDestino != codigoPostalCDActual.Value &&
                                        ((ga.Estado == EstadoGuiaEnum.Admitida && ga.CodigoPostalCDOrigen == codigoPostalCDActual.Value) ||
                                         (ga.Estado == EstadoGuiaEnum.EnTransitoAlCDDestino && (ga.Historial?.LastOrDefault()?.UbicacionGuia == cdNombreActual))))
                            .OrderBy(ga => ga.NumeroGuia)
                            .ToList();

                        int carga = 0;
                        foreach (var ga in candidatas)
                        {
                            if (!_planesRuta.ContainsKey(ga.NumeroGuia))
                                PlanificarRutaSiNecesaria(ga, serviciosEnt, codigoPostalCDActual.Value);
                            int nextHop = ObtenerProximoHop(ga.NumeroGuia);
                            if (nextHop == 0) continue;

                            bool servicioPuedeHop = s.Tramos != null && s.Tramos.Any(t => t.CodigoPostalOrigen == codigoPostalCDActual.Value && t.CodigoPostalDestino == nextHop);
                            if (!servicioPuedeHop) continue;

                            int costo = CapacidadPorTamano(ga.Tamano);
                            if (carga + costo > capacidadRestante) continue;
                            carga += costo;

                            var nombreFinal = cds.FirstOrDefault(cd => cd.CodigoPostal == ga.CodigoPostalCDDestino)?.Nombre ?? ga.CodigoPostalCDDestino.ToString();
                            var nombreIntermedio = cds.FirstOrDefault(cd => cd.CodigoPostal == nextHop)?.Nombre ?? nextHop.ToString();
                            var destinoMostrar = nextHop == ga.CodigoPostalCDDestino ? nombreFinal : $"CD Intermedio: {nombreIntermedio}";

                            guiasADespachar.Add(new Guia
                            {
                                NroGuia = ga.NumeroGuia.ToString(),
                                Tamanio = ga.Tamano.ToString(),
                                Destino = destinoMostrar
                            });
                            if (carga >= capacidadRestante) break;
                        }
                    }

                    return new ServicioTransporte
                    {
                        NumeroServicio = s.ID.ToString(),
                        GuiasARecibir = guiasARecibir,
                        GuiasADespachar = guiasADespachar
                    };
                })
                .ToList();

            var guiasEnHDRNums = hdrs.SelectMany(h => h.Guias).ToHashSet();
            this.guiasPendientesDeAsignacion = guiasAlmacen
                .Where(g => !guiasEnHDRNums.Contains(g.NumeroGuia) &&
                            g.Estado == EstadoGuiaEnum.EnTransitoAlCDDestino &&
                            codigoPostalCDActual.HasValue &&
                            (g.Historial?.LastOrDefault()?.UbicacionGuia == cdNombreActual) &&
                            g.CodigoPostalCDDestino != codigoPostalCDActual.Value)
                .Select(g => new Guia
                {
                    NroGuia = g.NumeroGuia.ToString(),
                    Tamanio = g.Tamano.ToString(),
                    Destino = cds.FirstOrDefault(cd => cd.CodigoPostal == g.CodigoPostalCDDestino)?.Nombre ?? g.CodigoPostalCDDestino.ToString()
                })
                .ToList();

            this.servicios ??= new List<ServicioTransporte>();
            this.guiasPendientesDeAsignacion ??= new List<Guia>();
        }

        private void CargarDatosDePrueba() { }

        public ServicioTransporte BuscarServicio(string numeroServicio)
        {
            if (string.IsNullOrWhiteSpace(numeroServicio))
                return null;

            MapearDesdeAlmacenes();

            var servicio = servicios.FirstOrDefault(s => s.NumeroServicio == numeroServicio);
            if (servicio == null)
                return null; // solo null si NO existe el servicio

            // Filtrar guías ya procesadas
            servicio.GuiasARecibir = servicio.GuiasARecibir.Where(g => !g.Procesada).ToList();
            servicio.GuiasADespachar = servicio.GuiasADespachar.Where(g => !g.Procesada).ToList();

            // Si no hay guías, devolver igualmente el servicio (para que el form no muestre 'no existe').
            // Las pantallas pueden usar ServicioTieneGuias/ServicioSinGuias si necesitan mensaje específico.
            return servicio;
        }

        public void MarcarGuiasProcesadas(string numeroServicio, List<string> guiasRecibidas, List<string> guiasDespachadas)
        {
            var servicio = servicios.FirstOrDefault(s => s.NumeroServicio == numeroServicio);
            if (servicio == null) return;
            foreach (var guia in servicio.GuiasARecibir)
                if (guiasRecibidas.Contains(guia.NroGuia)) guia.Procesada = true;
            foreach (var guia in servicio.GuiasADespachar)
                if (guiasDespachadas.Contains(guia.NroGuia)) guia.Procesada = true;
        }

        public bool AsignarGuiasPendientes(string numeroServicio)
        {
            var servicio = servicios.FirstOrDefault(s => s.NumeroServicio == numeroServicio);
            if (servicio == null) return false;
            if (guiasPendientesDeAsignacion == null || guiasPendientesDeAsignacion.Count == 0) return false;
            var guiasAAsignar = guiasPendientesDeAsignacion.Take(5).ToList();
            servicio.GuiasADespachar.AddRange(guiasAAsignar);
            foreach (var g in guiasAAsignar) guiasPendientesDeAsignacion.Remove(g);
            return true;
        }
        public int ObtenerCantidadGuiasPendientes() => guiasPendientesDeAsignacion?.Count ?? 0;

        public void ConfirmarRecepcionYDespacho(string numeroServicio, List<string> guiasRecibidas, List<string> guiasDespachadas)
        {
            if ((guiasRecibidas == null || guiasRecibidas.Count == 0) && (guiasDespachadas == null || guiasDespachadas.Count == 0)) return;
            int? codigoPostalCDActual = CDActual?.CodigoPostal ?? CentroDeDistribucionAlmacen.CentroDistribucionActual?.CodigoPostal;
            var fechaNow = DateTime.Now;
            var cdNombreActual = CentroDeDistribucionAlmacen.centrosDeDistribucion.FirstOrDefault(cd => cd.CodigoPostal == codigoPostalCDActual)?.Nombre ?? string.Empty;
            _ = int.TryParse(numeroServicio, out var idServicioActual);

            if (guiasRecibidas != null && guiasRecibidas.Count > 0 && codigoPostalCDActual.HasValue)
            {
                foreach (var nro in guiasRecibidas)
                {
                    if (!int.TryParse(nro, out var n)) continue;
                    var entidad = GuiaAlmacen.guias.FirstOrDefault(g => g.NumeroGuia == n);
                    if (entidad == null) continue;
                    entidad.Historial ??= new List<RegistroEstadoAux>();
                    bool esFinal = entidad.CodigoPostalCDDestino == codigoPostalCDActual.Value;
                    if (esFinal)
                    {
                        entidad.Estado = entidad.TipoEntrega == EntregaEnum.CD ? EstadoGuiaEnum.PendienteDeEntrega : EstadoGuiaEnum.EnCDDestino;
                    }
                    else
                    {
                        entidad.Estado = EstadoGuiaEnum.EnTransitoAlCDDestino;
                        if (_indiceHopActual.ContainsKey(entidad.NumeroGuia)) AvanzarHop(entidad.NumeroGuia);
                        var hdrsDestinoActual = HDRAlmacen.HDR.Where(h => h.CodigoPostalDestino == codigoPostalCDActual.Value && h.Guias.Contains(n)).ToList();
                        foreach (var hdr in hdrsDestinoActual)
                        {
                            hdr.Guias.Remove(n);
                            if (hdr.Guias.Count == 0) HDRAlmacen.HDR.Remove(hdr);
                        }
                    }
                    entidad.Historial.Add(new RegistroEstadoAux
                    {
                        Estado = entidad.Estado,
                        UbicacionGuia = cdNombreActual,
                        FechaActualizacionEstado = fechaNow
                    });
                }
            }

            var guiasDespachadasEntidades = new List<GuiaEntidad>();
            if (guiasDespachadas != null && guiasDespachadas.Count > 0 && codigoPostalCDActual.HasValue)
            {
                var serviciosEnt = ServicioTransporteAlmacen.serviciosTransporte ?? new List<ServicioTransporteEntidad>();
                foreach (var nro in guiasDespachadas)
                {
                    if (!int.TryParse(nro, out var n)) continue;
                    var entidad = GuiaAlmacen.guias.FirstOrDefault(g => g.NumeroGuia == n);
                    if (entidad == null) continue;
                    entidad.Historial ??= new List<RegistroEstadoAux>();
                    if (!_planesRuta.ContainsKey(entidad.NumeroGuia))
                        PlanificarRutaSiNecesaria(entidad, serviciosEnt, codigoPostalCDActual.Value);
                    int nextHop = ObtenerProximoHop(entidad.NumeroGuia);
                    if (nextHop == 0) continue;
                    entidad.Estado = EstadoGuiaEnum.EnTransitoAlCDDestino;
                    entidad.Historial.Add(new RegistroEstadoAux
                    {
                        Estado = EstadoGuiaEnum.EnTransitoAlCDDestino,
                        UbicacionGuia = idServicioActual > 0 ? $"Servicio:{idServicioActual}" : string.Empty,
                        FechaActualizacionEstado = fechaNow
                    });
                    guiasDespachadasEntidades.Add(entidad);
                }
            }

            if (int.TryParse(numeroServicio, out var idServicio) && guiasDespachadasEntidades.Any() && codigoPostalCDActual.HasValue)
            {
                int secuencia = HDRAlmacen.HDR.Count + 1;
                var servicioActual = ServicioTransporteAlmacen.serviciosTransporte.FirstOrDefault(s => s.ID == idServicio);
                var gruposPorHop = guiasDespachadasEntidades
                    .Select(g => new { Guia = g, Hop = ObtenerProximoHop(g.NumeroGuia) })
                    .Where(x => x.Hop != 0 && servicioActual?.Tramos?.Any(t => t.CodigoPostalOrigen == codigoPostalCDActual.Value && t.CodigoPostalDestino == x.Hop) == true)
                    .GroupBy(x => x.Hop);
                foreach (var grupo in gruposPorHop)
                {
                    var idHdr = $"T {codigoPostalCDActual.Value:00000} {secuencia:000000} {grupo.Key:00000}";
                    var hdr = new HDREntidad
                    {
                        ID = idHdr,
                        TipoHDR = TipoHDREnum.Transporte,
                        DNIFletero = 0,
                        IDServicioTransporte = idServicio,
                        CodigoPostalOrigen = codigoPostalCDActual.Value,
                        CodigoPostalDestino = grupo.Key,
                        Guias = grupo.Select(x => x.Guia.NumeroGuia).ToList()
                    };
                    HDRAlmacen.HDR.Add(hdr);
                    secuencia++;
                }
            }
        }
    }
}