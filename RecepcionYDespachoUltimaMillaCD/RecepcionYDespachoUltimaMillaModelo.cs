using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.RecepcionYDespachoUltimaMillaCD
{
    public class RecepcionYDespachoUltimaMillaCDModelo
    {
        // Guarda la tanda de retiros confirmados para generar sus distribución pendiente
        private List<Guia> _ultimosRetirosMarcados = new();
        private readonly List<Guia> _guias = new();
        private readonly List<HDR> _hdrs = new();
        private List<int> GuiasPosibles = new();


        // Propiedad pública para guardar el CD seleccionado
        public CentroDeDistribucionEntidad? CDActual { get; set; } //obtengo el CD desde el form

        // ================= API (usado por el Form) =================

        public Fletero? BuscarFleteroPorDni(int dni) => FleteroAlmacen.fleteros.Select(f => new Fletero{Dni = f.DNI, Nombre = f.Nombre + " " + f.Apellido}).FirstOrDefault(f => f.Dni == dni);
 

        public (IEnumerable<Guia> distribucion, IEnumerable<Guia> retiro) GetGuiasPorFletero(int dni)
        {
            // HDRs asignadas al fletero en el CD actual
            var hdrsFletero = HDRAlmacen.HDR
                .Where(h => h.DNIFletero == dni &&
                            (h.CodigoPostalDestino == CDActual.CodigoPostal ||
                             h.CodigoPostalOrigen == CDActual.CodigoPostal))
                .ToList();

           

            //guías de distribución 
            var dist = hdrsFletero
                .Where(h => h.TipoHDR == TipoHDREnum.Distribucion)
                .SelectMany(h => h.Guias)
                .Join(GuiaAlmacen.guias,
                    numGuia => numGuia,
                    guia => guia.NumeroGuia,
                    (numGuia, guia) => new Guia
                    {
                        Numero = numGuia.ToString(),
                        NroHDR = HDRAlmacen.HDR.First(h => h.Guias.Contains(numGuia)).ID,
                    })
                .Where(g => GuiaAlmacen.guias.First(gu => gu.NumeroGuia.ToString() == g.Numero).Estado == EstadoGuiaEnum.EnRutaAlDomicilioDeEntrega ||
                            GuiaAlmacen.guias.First(gu => gu.NumeroGuia.ToString() == g.Numero).Estado == EstadoGuiaEnum.EnRutaAlaAgenciaDestino)
                .OrderBy(g => g.Numero)
                .ToList();



            // guías de retiro
            var retiro = hdrsFletero
                .Where(h => h.TipoHDR == TipoHDREnum.Retiro)
                .SelectMany(h => h.Guias)
                .Join(GuiaAlmacen.guias,
                    numGuia => numGuia,
                    guia => guia.NumeroGuia,
                    (numGuia, guia) => new Guia
                    {
                        Numero = numGuia.ToString(),
                        NroHDR = HDRAlmacen.HDR.First(h => h.Guias.Contains(numGuia)).ID,
                    })
                .Where(g => GuiaAlmacen.guias.First(gu => gu.NumeroGuia.ToString() == g.Numero).Estado == EstadoGuiaEnum.EnRutaACDDeOrigenDesdeAgencia ||
                            GuiaAlmacen.guias.First(gu => gu.NumeroGuia.ToString() == g.Numero).Estado == EstadoGuiaEnum.EnCaminoARetirarPorDomicilio)
                .OrderBy(g => g.Numero)
                .ToList();

            return (dist, retiro);

        }
        /// <summary>
        /// N3–N4: Aplica cambios de negocio sobre guías marcadas.
        /// - Distribución marcada → Entregada.
        /// - Retiro marcado → EnRutaACDOrigen + guarda tanda para generar guías de distribución pendientes.
        /// </summary>
        public void ConfirmarRendicion(int dni, List<string> entregasDistribucionMarcadas, List<string> retirosMarcados)
        {
            if (BuscarFleteroPorDni(dni) == null)
                throw new InvalidOperationException("Debe seleccionar un transportista primero.");

            if (CDActual == null)
                throw new InvalidOperationException("Debe seleccionar un Centro de Distribución.");

            _ultimosRetirosMarcados = new List<Guia>();

            // 1. Procesar guías de distribución marcadas
            var guiasDistribucion = GuiaAlmacen.guias
                .Where(x => (x.Estado == EstadoGuiaEnum.EnRutaAlaAgenciaDestino ||
                            x.Estado == EstadoGuiaEnum.EnRutaAlDomicilioDeEntrega) &&
                            entregasDistribucionMarcadas.Contains(x.NumeroGuia.ToString()))
                .ToList();

            foreach (var guia in guiasDistribucion)
            {
                var hdrAnterior = HDRAlmacen.HDR.FirstOrDefault(h => h.Guias.Contains(guia.NumeroGuia));

                // Cambiar estado según el tipo de entrega
                if (guia.TipoEntrega == EntregaEnum.Agencia)
                {
                    guia.Estado = EstadoGuiaEnum.PendienteDeEntrega;
                }
                else
                {
                    guia.Estado = EstadoGuiaEnum.Entregada;
                }

                // Guardar historial
                guia.Historial.Add(new RegistroEstadoAux
                {
                    Estado = guia.Estado,
                    UbicacionGuia = "",
                    FechaActualizacionEstado = DateTime.Now
                });
            }

            // 2. Procesar guías de retiro marcadas
            var guiasRetiro = GuiaAlmacen.guias
                .Where(x => retirosMarcados.Contains(x.NumeroGuia.ToString()))
                .ToList();

            foreach (var guia in guiasRetiro)
            {
                var hdrAnterior = HDRAlmacen.HDR.FirstOrDefault(h => h.Guias.Contains(guia.NumeroGuia));

                // Cambiar estado a Admitida
                guia.Estado = EstadoGuiaEnum.Admitida;
                guia.ImporteAFacturar = CalcularImporte(guia.NumeroGuia);

                // Guardar historial
                guia.Historial.Add(new RegistroEstadoAux
                {
                    Estado = guia.Estado,
                    UbicacionGuia = CDActual.Nombre,
                    FechaActualizacionEstado = DateTime.Now
                });
            }

            // Grabar cambios
            if (guiasDistribucion.Any() || guiasRetiro.Any())
            {
                GuiaAlmacen.Grabar();
                HDRAlmacen.Grabar();
            }
        }
        

        public (IEnumerable<Guia> distribucion, IEnumerable<Guia> retiro) GetNuevasGuiasPorFletero()
        {
            GuiasPosibles = new List<int>();
            var secuencia = HDRAlmacen.HDR.Count + 1;

            //primero traigo las guias ya asignadas a HDR
            var GuiasEnHDR = HDRAlmacen.HDR.Where(h => (h.TipoHDR == TipoHDREnum.Distribucion && h.CodigoPostalDestino == CDActual.CodigoPostal)
                                                    || (h.TipoHDR == TipoHDREnum.Retiro && h.CodigoPostalOrigen == CDActual.CodigoPostal))
                                                    .SelectMany(h => h.Guias).ToList();

            //me fijo cuales no estan en una HDR
            var GuiasParaRetiroSinHDR = GuiaAlmacen.guias.Where(g => !GuiasEnHDR.Contains(g.NumeroGuia)
                                                    && g.CodigoPostalCDOrigen == CDActual.CodigoPostal
                                                    && (g.Estado == EstadoGuiaEnum.ARetirarEnAgenciaDeOrigen
                                                    || g.Estado == EstadoGuiaEnum.ARetirarPorDomicilioDelCliente))
                                                    .Take(5)  // Tomar solo 5 guías de retiro
                                                    .ToList();

            var GuiasParaDistribucionSinHDR = GuiaAlmacen.guias.Where(g => !GuiasEnHDR.Contains(g.NumeroGuia)
                                                        && g.CodigoPostalCDDestino == CDActual.CodigoPostal
                                                        && (g.Estado == EstadoGuiaEnum.Admitida || g.Estado == EstadoGuiaEnum.EnCDDestino))
                                                        .Take(5)  // Tomar solo 5 guías de distribución
                                                        .ToList();

            // Generar IDs de HDR que se usarán
            string idHdrDistribucion = string.Empty;
            if (GuiasParaDistribucionSinHDR.Any())
            {
                var codigoOrigen = CDActual.CodigoPostal;
                var codigoDestino = GuiasParaDistribucionSinHDR.First().CodigoPostalCDDestino;
                idHdrDistribucion = $"D {codigoOrigen:00000} {secuencia:000000} {codigoDestino:00000}";
                secuencia++;
            }

            string idHdrRetiro = string.Empty;
            if (GuiasParaRetiroSinHDR.Any())
            {
                var codigoOrigen = GuiasParaRetiroSinHDR.First().CodigoPostalCDOrigen;
                var codigoDestino = CDActual.CodigoPostal;
                idHdrRetiro = $"R {codigoOrigen:00000} {secuencia:000000} {codigoDestino:00000}";
            }

            // Agregar guías a la lista de posibles
            GuiasPosibles.AddRange(GuiasParaRetiroSinHDR.Select(g => g.NumeroGuia));
            GuiasPosibles.AddRange(GuiasParaDistribucionSinHDR.Select(g => g.NumeroGuia));

            return (
                distribucion: GuiasParaDistribucionSinHDR.Select(g => new Guia
                {
                    Numero = g.NumeroGuia.ToString(),
                    NroHDR = idHdrDistribucion, 
                    Tamaño = g.Tamano.ToString(),
                    Destino = ObtenerDestinoParaDistribucion(g.NumeroGuia),
                }),
                retiro: GuiasParaRetiroSinHDR.Select(g => new Guia
                {
                    Numero = g.NumeroGuia.ToString(),
                    NroHDR = idHdrRetiro,
                    Tamaño = g.Tamano.ToString(),
                    Destino = ObtenerDestinoParaRetiro(g.NumeroGuia),  
                })
            );
        }

        /// <summary>
        /// N3–N4: Adopta guías sin fletero, crea nuevas de distribución post-retiro y asigna HDR por destino (máx 5/ HDR).
        /// </summary>
        public void AsignarHDRsPorDireccion(int dni)
        {
            if (CDActual == null)
                throw new InvalidOperationException("Debe seleccionar un Centro de Distribución.");

            var secuencia = HDRAlmacen.HDR.Count + 1;

            // Guías que fueron seleccionadas en el paso anterior
            var guiasReales = GuiaAlmacen.guias
                .Where(g => GuiasPosibles.Contains(g.NumeroGuia))
                .Take(5) // solo las primeras 5
                .ToList();

            // Separar las de distribución y retiro
            var guiasDistribucion = guiasReales
                .Where(g => g.Estado == EstadoGuiaEnum.Admitida || g.Estado == EstadoGuiaEnum.EnCDDestino)
                .ToList();

            var guiasRetiro = guiasReales
                .Where(g => g.Estado == EstadoGuiaEnum.ARetirarEnAgenciaDeOrigen ||
                            g.Estado == EstadoGuiaEnum.ARetirarPorDomicilioDelCliente)
                .ToList();

            // Crear una HDR de distribución (si corresponde)
            if (guiasDistribucion.Any())
            {
                var codigoOrigen = CDActual.CodigoPostal;
                var codigoDestino = guiasDistribucion.First().CodigoPostalCDDestino;
                var idHdr = $"D {codigoOrigen:00000} {secuencia:000000} {codigoDestino:00000}";

                var hdr = new HDREntidad
                {
                    ID = idHdr,
                    DNIFletero = dni,
                    TipoHDR = TipoHDREnum.Distribucion,
                    CodigoPostalOrigen = codigoOrigen,
                    CodigoPostalDestino = codigoDestino,
                    Guias = guiasDistribucion.Select(g => g.NumeroGuia).ToList()
                };

                foreach (var guia in guiasDistribucion)
                    ActualizarEstadoGuia(guia.NumeroGuia);

                HDRAlmacen.HDR.Add(hdr);
                secuencia++;
            }

            // Crear una HDR de retiro (si corresponde)
            if (guiasRetiro.Any())
            {
                var codigoOrigen = guiasRetiro.First().CodigoPostalCDOrigen;
                var codigoDestino = CDActual.CodigoPostal;
                var idHdr = $"R {codigoOrigen:00000} {secuencia:000000} {codigoDestino:00000}";

                var hdr = new HDREntidad
                {
                    ID = idHdr,
                    DNIFletero = dni,
                    TipoHDR = TipoHDREnum.Retiro,
                    CodigoPostalOrigen = codigoOrigen,
                    CodigoPostalDestino = codigoDestino,
                    Guias = guiasRetiro.Select(g => g.NumeroGuia).ToList()
                };

                foreach (var guia in guiasRetiro)
                    ActualizarEstadoGuia(guia.NumeroGuia);

                HDRAlmacen.HDR.Add(hdr);
            }

            if (guiasReales.Any())
            {
                GuiaAlmacen.Grabar();
                HDRAlmacen.Grabar();
            }
        }

           

        /// <summary>
        /// *** NUEVO (para que en la grilla superior ya se vea HDR):***
        /// Asigna HDR (1 por destino, máx 5 por HDR) a todas las guías activas del fletero que aún no tengan NroHDR.
        /// </summary>
        public void AsegurarHDRsAsignadasParaFletero(int dni)
        {
            /*
                var fecha = DateTime.Now.ToString("yyyyMMdd", CultureInfo.InvariantCulture);

                var activasSinHdr = _guias.Where(g => g.FleteroDni == dni && !string.Equals(g.Estado, "Entregada", StringComparison.OrdinalIgnoreCase) && string.IsNullOrEmpty(g.NroHDR))
                                          .ToList();
                if (activasSinHdr.Count == 0) return;

                foreach (var grp in activasSinHdr.GroupBy(g => NormalizarDestino(g.Destino)))
                {
                    foreach (var chunk in grp.Chunk(5))
                    {
                        string destinoCod = DestinoToLLL(grp.Key);
                        string nroHdr = $"H{ORIGEN_COD}{destinoCod}{fecha}{_seqHdr++:000}";

                        var hdr = new HDR
                        {
                            Numero = nroHdr,
                            Direccion = grp.Key,
                            Tipo = chunk.Any(EsRetiro) ? "Retiro" : "Distribución",
                            Guias = chunk.Select(c => c.Numero).ToList()
                        };
                        _hdrs.Add(hdr);

                        foreach (var g in chunk) g.NroHDR = nroHdr;
                    }
                }
            */
        }

        private void ActualizarEstadoGuia(int NroGuia)
        {
            // Determinar el nuevo estado según el tipo de guía
            var guia = GuiaAlmacen.guias.First(g => g.NumeroGuia == NroGuia);

            EstadoGuiaEnum nuevoEstado = guia.Estado;

            switch (guia.Estado)
            {
                case EstadoGuiaEnum.ARetirarPorDomicilioDelCliente:
                    nuevoEstado = EstadoGuiaEnum.EnCaminoARetirarPorDomicilio;
                    break;

                case EstadoGuiaEnum.ARetirarEnAgenciaDeOrigen:
                    nuevoEstado = EstadoGuiaEnum.EnCaminoARetirarPorAgencia;
                    break;

                case EstadoGuiaEnum.Admitida when guia.TipoEntrega == EntregaEnum.Domicilio:
                    nuevoEstado = EstadoGuiaEnum.EnRutaAlDomicilioDeEntrega;
                    break;

                case EstadoGuiaEnum.Admitida when guia.TipoEntrega == EntregaEnum.Agencia:
                    nuevoEstado = EstadoGuiaEnum.EnRutaAlaAgenciaDestino;
                    break;

                case EstadoGuiaEnum.EnCDDestino when guia.TipoEntrega == EntregaEnum.Domicilio:
                    nuevoEstado = EstadoGuiaEnum.EnRutaAlDomicilioDeEntrega;
                    break;

                case EstadoGuiaEnum.EnCDDestino when guia.TipoEntrega == EntregaEnum.Agencia:
                    nuevoEstado = EstadoGuiaEnum.EnRutaAlaAgenciaDestino;
                    break;

                default:
                    return;
            }

            // Actualizar estado y agregar al historial
            guia.Estado = nuevoEstado;
            guia.Historial.Add(new RegistroEstadoAux
            {
                Estado = nuevoEstado,
                UbicacionGuia = "",
                FechaActualizacionEstado = DateTime.Now
            });
        }

        // Calcula el Importe a Facturar para el cliente (TarifaBase + Extras).
        private decimal CalcularImporte(int NroGuia)
        {
            var guia = GuiaAlmacen.guias.FirstOrDefault(g => g.NumeroGuia == NroGuia);
            if (guia == null)
                throw new ArgumentNullException(nameof(guia));   

            var Convenio = ConvenioClienteAlmacen.convenioClientes
                .FirstOrDefault(c => c.CUITCliente == guia.CUITCliente);

            if (Convenio == null)
            {
                throw new InvalidOperationException($"No se encontró un convenio para el CUIT: {guia.CUITCliente}");
            }

            var TarifaAplicable = Convenio.TarifasPorOrigenDestino
                .FirstOrDefault(t =>
                    t.CodigoPostalOrigen == guia.CodigoPostalCDOrigen &&
                    t.CodigoPostalDestino == guia.CodigoPostalCDDestino);

            if (TarifaAplicable == null)
            {
                throw new InvalidOperationException(
                    $"No se encontró tarifa para Origen: {guia.CodigoPostalCDOrigen}, Destino: {guia.CodigoPostalCDDestino}");
            }

 
            if (!TarifaAplicable.PreciosXTamano.TryGetValue(guia.Tamano, out decimal PrecioBase))
            {
                throw new InvalidOperationException("No se encontró precio para el tamaño");
            }
            decimal Extras = 0;
            if (guia.TipoEntrega == EntregaEnum.Domicilio &&
                Convenio.Extras.TryGetValue(ExtrasEnum.ExtraRetiroDomicilio, out decimal retiro))
            {
                Extras += retiro;
            }

            return PrecioBase + Extras;
        }

        private string ObtenerDestinoParaRetiro(int NroGuia)
        {
            var guia = GuiaAlmacen.guias.FirstOrDefault(g => g.NumeroGuia == NroGuia);
            if (guia.Estado == EstadoGuiaEnum.ARetirarEnAgenciaDeOrigen)
            {
                //nombre de la agencia
                var AgenciaRetiro = AgenciaAlmacen.agencias
                                .FirstOrDefault(a => a.ID == guia.IDAgenciaOrigen);
                return AgenciaRetiro?.Nombre ?? guia.IDAgenciaOrigen;
            }
            else
            {
                //direccion del cliente en donde paso a retirar por domicilio
                var DomicilioRetiro = ClienteAlmacen.clientes
                                .FirstOrDefault(c => c.CUIT == guia.CUITCliente);

                return DomicilioRetiro?.Direccion ?? string.Empty;
            }
        }


        private string ObtenerDestinoParaDistribucion(int NroGuia)
        {
            var guia = GuiaAlmacen.guias.FirstOrDefault(g => g.NumeroGuia == NroGuia);
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
                var DomicilioEntrega = guia.Destinatario?.Direccion ?? string.Empty;
                return DomicilioEntrega;
            }

        }

    }

}





