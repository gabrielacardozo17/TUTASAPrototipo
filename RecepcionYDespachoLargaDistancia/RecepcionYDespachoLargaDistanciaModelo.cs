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
        private readonly Dictionary<int, List<(int proximoCd, int servicioId)>> _planesRuta = new();
        private readonly Dictionary<int, int> _indiceCdIntermedioActual = new();

        public RecepcionYDespachoLargaDistanciaModelo()
        {
            CargarDatosDePrueba();
            CDActual = CentroDeDistribucionAlmacen.CentroDistribucionActual;
            MapearDesdeAlmacenes();
        }

        public CentroDeDistribucionEntidad? CDActual { get; set; }
        public void SetCDActual(CentroDeDistribucionEntidad? cd)
        {
            CDActual = cd ?? CentroDeDistribucionAlmacen.CentroDistribucionActual;
            MapearDesdeAlmacenes();
        }

        public string GetNombreCDActual() => CDActual?.Nombre ?? CentroDeDistribucionAlmacen.CentroDistribucionActual?.Nombre ?? string.Empty;

        public bool ServicioTieneGuias(string numeroServicio)
        {
            var s = BuscarServicio(numeroServicio);
            return s != null && ((s.GuiasARecibir?.Count ?? 0) > 0 || (s.GuiasADespachar?.Count ?? 0) > 0);
        }

        public bool ServicioSinGuias(string numeroServicio) => !ServicioTieneGuias(numeroServicio);

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
            var visited = new HashSet<int> { origen };
            bool found = false;
            while (q.Count > 0 && !found)
            {
                var n = q.Dequeue();
                if (!adj.TryGetValue(n, out var vecinos)) continue;
                foreach (var v in vecinos)
                {
                    if (visited.Add(v))
                    {
                        prev[v] = n;
                        if (v == destino) { found = true; break; }
                        q.Enqueue(v);
                    }
                }
            }
            if (!found) { ruta.Add(origen); ruta.Add(destino); return ruta; }
            int cur = destino; var stack = new Stack<int>(); stack.Push(cur);
            while (prev.ContainsKey(cur)) { cur = prev[cur]; stack.Push(cur); }
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
                rutaCds = new List<int> { cdActual, guia.CodigoPostalCDDestino };
            }

            var cdsIntermedios = new List<(int proximoCd, int servicioId)>();
            for (int i = 0; i < rutaCds.Count - 1; i++)
            {
                var orig = rutaCds[i];
                var dest = rutaCds[i + 1];
                if (!tramoServicios.TryGetValue((orig, dest), out var svcs) || svcs == null || svcs.Count == 0)
                {
                    cdsIntermedios.Add((dest, 0));
                }
                else
                {
                    int servicioAsignado = svcs.First();
                    cdsIntermedios.Add((dest, servicioAsignado));
                }
            }

            _planesRuta[guia.NumeroGuia] = cdsIntermedios;
            _indiceCdIntermedioActual[guia.NumeroGuia] = 0;
        }

        private int ObtenerProximoCdIntermedio(int numeroGuia)
        {
            if (!_planesRuta.TryGetValue(numeroGuia, out var cdsIntermedios)) return 0;
            if (!_indiceCdIntermedioActual.TryGetValue(numeroGuia, out var idx)) return 0;
            if (idx >= cdsIntermedios.Count) return 0;
            return cdsIntermedios[idx].proximoCd;
        }

        private void AvanzarCdIntermedio(int numeroGuia)
        {
            if (_indiceCdIntermedioActual.ContainsKey(numeroGuia)) _indiceCdIntermedioActual[numeroGuia]++;
        }

        // NUEVO: Verifica si un servicio tiene un tramo directo desde origen hasta destino final (sin intermedios)
        private bool ServicioTieneTramoDirecto(ServicioTransporteEntidad servicio, int origen, int destinoFinal)
        {
            if (servicio.Tramos == null) return false;
            
            // Verificar si existe un camino directo en el servicio
            // El servicio puede tener múltiples tramos, pero debe poder ir de origen a destino sin bajarse
            var tramosPorOrigen = servicio.Tramos.ToLookup(t => t.CodigoPostalOrigen);
            
            var visitados = new HashSet<int>();
            var cola = new Queue<int>();
            cola.Enqueue(origen);
            visitados.Add(origen);
            
            while (cola.Count > 0)
            {
                var actual = cola.Dequeue();
                if (actual == destinoFinal) return true;
                
                foreach (var tramo in tramosPorOrigen[actual])
                {
                    if (visitados.Add(tramo.CodigoPostalDestino))
                    {
                        cola.Enqueue(tramo.CodigoPostalDestino);
                    }
                }
            }
            
            return false;
        }

        private void MapearDesdeAlmacenes()
        {
            List<ServicioTransporteEntidad> serviciosEnt = ServicioTransporteAlmacen.serviciosTransporte ?? new List<ServicioTransporteEntidad>();
            var hdrs = HDRAlmacen.HDR ?? new List<HDREntidad>();
            var guiasAlmacen = GuiaAlmacen.guias ?? new List<GuiaEntidad>();
            var cds = CentroDeDistribucionAlmacen.centrosDeDistribucion ?? new List<CentroDeDistribucionEntidad>();
            int? codigoPostalCDActual = CDActual?.CodigoPostal ?? CentroDeDistribucionAlmacen.CentroDistribucionActual?.CodigoPostal;
            var cdNombreActual = cds.FirstOrDefault(cd => cd.CodigoPostal == codigoPostalCDActual)?.Nombre ?? string.Empty;

            this.servicios = serviciosEnt
                .GroupJoin(hdrs, (ServicioTransporteEntidad s) => s.ID, h => h.IDServicioTransporte, (s, hdrGroup) => new { s, hdrGroup })
                .Select(x =>
                {
                    var sEntidad = x.s;
                    var hdrGroup = x.hdrGroup;
                    int capacidadUsada = CalcularCapacidadUsadaPorServicio(sEntidad.ID, hdrs, guiasAlmacen);
                    int capacidadTotal = Math.Max(0, sEntidad.CapacidadBodega);
                    int capacidadRestante = Math.Max(0, capacidadTotal - capacidadUsada);

                    // Guías a recibir: solo si el destino de la HDR es este CD Y el destino final de la guía es este CD
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

                            // Verificar si este servicio puede llevar la guía directo al destino final
                            bool esTramoDirecto = ServicioTieneTramoDirecto(sEntidad, codigoPostalCDActual.Value, ga.CodigoPostalCDDestino);
                            
                            if (esTramoDirecto)
                            {
                                // Caso directo: mostrar destino final
                                int costo = CapacidadPorTamano(ga.Tamano);
                                if (carga + costo > capacidadRestante) continue;
                                carga += costo;

                                var nombreFinal = cds.FirstOrDefault(cd => cd.CodigoPostal == ga.CodigoPostalCDDestino)?.Nombre ?? ga.CodigoPostalCDDestino.ToString();

                                guiasADespachar.Add(new Guia
                                {
                                    NroGuia = ga.NumeroGuia.ToString(),
                                    Tamanio = ga.Tamano.ToString(),
                                    Destino = nombreFinal
                                });
                            }
                            else
                            {
                                // Caso con intermedios: mostrar próximo CD intermedio
                                int proximoCd = ObtenerProximoCdIntermedio(ga.NumeroGuia);
                                if (proximoCd == 0) continue;

                                bool servicioPuedeRealizar = sEntidad.Tramos != null && sEntidad.Tramos.Any(t => t.CodigoPostalOrigen == codigoPostalCDActual.Value && t.CodigoPostalDestino == proximoCd);
                                if (!servicioPuedeRealizar) continue;

                                int costo = CapacidadPorTamano(ga.Tamano);
                                if (carga + costo > capacidadRestante) continue;
                                carga += costo;

                                var nombreFinal = cds.FirstOrDefault(cd => cd.CodigoPostal == ga.CodigoPostalCDDestino)?.Nombre ?? ga.CodigoPostalCDDestino.ToString();
                                var nombreIntermedio = cds.FirstOrDefault(cd => cd.CodigoPostal == proximoCd)?.Nombre ?? proximoCd.ToString();
                                var destinoMostrar = proximoCd == ga.CodigoPostalCDDestino ? nombreFinal : $"CD Intermedio: {nombreIntermedio}";

                                guiasADespachar.Add(new Guia
                                {
                                    NroGuia = ga.NumeroGuia.ToString(),
                                    Tamanio = ga.Tamano.ToString(),
                                    Destino = destinoMostrar
                                });
                            }
                            
                            if (carga >= capacidadRestante) break;
                        }
                    }

                    return new ServicioTransporte
                    {
                        NumeroServicio = sEntidad.ID.ToString(),
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
                return null;

            servicio.GuiasARecibir = servicio.GuiasARecibir.Where(g => !g.Procesada).ToList();
            servicio.GuiasADespachar = servicio.GuiasADespachar.Where(g => !g.Procesada).ToList();

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
                        if (_indiceCdIntermedioActual.ContainsKey(entidad.NumeroGuia)) AvanzarCdIntermedio(entidad.NumeroGuia);
                        var hdrsDestinoActual = HDRAlmacen.HDR.Where(h => h.CodigoPostalDestino == codigoPostalCDActual.Value && h.Guias.Contains(n)).ToList();
                        foreach (var hdr in hdrsDestinoActual)
                        {
                            hdr.Guias.Remove(n);
                            if (hdr.Guias.Count == 0)
                            {
                                hdr.Guias = hdr.Guias ?? new List<int>();
                            }
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
                var ultimoIdTransporte = HDRAlmacen.HDR
                    .Where(h => h.TipoHDR == TipoHDREnum.Transporte)
                    .Select(h => {
                        var parts = h.ID.Split(' ');
                        return int.TryParse(parts.Length > 2 ? parts[2] : string.Empty, out var seq) ? seq : 0;
                    })
                    .DefaultIfEmpty(0)
                    .Max();
                int secuencia = ultimoIdTransporte + 1;

                var servicioActual = ServicioTransporteAlmacen.serviciosTransporte.FirstOrDefault(s => s.ID == idServicio);
                
                // Separar guías en dos grupos: directas e intermedias
                var guiasDirectas = new List<GuiaEntidad>();
                var guiasConIntermedios = new List<GuiaEntidad>();
                
                foreach (var guia in guiasDespachadasEntidades)
                {
                    bool esDirecta = servicioActual != null && ServicioTieneTramoDirecto(servicioActual, codigoPostalCDActual.Value, guia.CodigoPostalCDDestino);
                    if (esDirecta)
                        guiasDirectas.Add(guia);
                    else
                        guiasConIntermedios.Add(guia);
                }

                // Caso 1: Guías directas - crear HDR con destino final
                if (guiasDirectas.Any())
                {
                    var gruposPorDestinoFinal = guiasDirectas.GroupBy(g => g.CodigoPostalCDDestino);
                    
                    foreach (var grupo in gruposPorDestinoFinal)
                    {
                        var destinoFinal = grupo.Key;
                        var guiasNums = grupo.Select(g => g.NumeroGuia).ToList();

                        var existentesEnMismoServicio = HDRAlmacen.HDR
                            .Where(h => h.TipoHDR == TipoHDREnum.Transporte
                                        && h.CodigoPostalOrigen == codigoPostalCDActual.Value
                                        && h.CodigoPostalDestino == destinoFinal
                                        && h.IDServicioTransporte == idServicio)
                            .SelectMany(h => h.Guias)
                            .ToHashSet();

                        var nuevos = guiasNums.Where(n => !existentesEnMismoServicio.Contains(n)).ToList();
                        if (nuevos.Count == 0) continue;

                        var idHdr = $"T {codigoPostalCDActual.Value:00000} {secuencia:000000} {destinoFinal:00000}";
                        var hdr = new HDREntidad
                        {
                            ID = idHdr,
                            TipoHDR = TipoHDREnum.Transporte,
                            DNIFletero = 0,
                            IDServicioTransporte = idServicio,
                            CodigoPostalOrigen = codigoPostalCDActual.Value,
                            CodigoPostalDestino = destinoFinal,
                            Guias = nuevos
                        };

                        HDRAlmacen.HDR.Add(hdr);
                        secuencia++;
                    }
                }

                // Caso 2: Guías con intermedios - crear HDR por tramo intermedio
                if (guiasConIntermedios.Any())
                {
                    var gruposPorCdIntermedio = guiasConIntermedios
                        .Select(g => new { Guia = g, CdIntermedio = ObtenerProximoCdIntermedio(g.NumeroGuia) })
                        .Where(x => x.CdIntermedio != 0 && servicioActual?.Tramos?.Any(t => t.CodigoPostalOrigen == codigoPostalCDActual.Value && t.CodigoPostalDestino == x.CdIntermedio) == true)
                        .GroupBy(x => x.CdIntermedio);
                    
                    foreach (var grupo in gruposPorCdIntermedio)
                    {
                        var destinoHop = grupo.Key;
                        var guiasNums = grupo.Select(x => x.Guia.NumeroGuia).ToList();
                        
                        var existentesEnMismoServicio = HDRAlmacen.HDR
                            .Where(h => h.TipoHDR == TipoHDREnum.Transporte
                                        && h.CodigoPostalOrigen == codigoPostalCDActual.Value
                                        && h.CodigoPostalDestino == destinoHop
                                        && h.IDServicioTransporte == idServicio)
                            .SelectMany(h => h.Guias)
                            .ToHashSet();

                        var nuevos = guiasNums.Where(n => !existentesEnMismoServicio.Contains(n)).ToList();
                        if (nuevos.Count == 0) continue;

                        var idHdr = $"T {codigoPostalCDActual.Value:00000} {secuencia:000000} {destinoHop:00000}";
                        var hdr = new HDREntidad
                        {
                            ID = idHdr,
                            TipoHDR = TipoHDREnum.Transporte,
                            DNIFletero = 0,
                            IDServicioTransporte = idServicio,
                            CodigoPostalOrigen = codigoPostalCDActual.Value,
                            CodigoPostalDestino = destinoHop,
                            Guias = nuevos
                        };

                        HDRAlmacen.HDR.Add(hdr);
                        secuencia++;
                    }
                }
            }

            HDRAlmacen.Grabar();
            GuiaAlmacen.Grabar();
        }
    }
}