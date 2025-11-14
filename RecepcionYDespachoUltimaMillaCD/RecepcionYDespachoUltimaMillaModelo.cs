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
        public CentroDeDistribucionEntidad? CDActual { get; set; }

        public Fletero? BuscarFleteroPorDni(int dni) => FleteroAlmacen.fleteros.Select(f => new Fletero{Dni = f.DNI, Nombre = f.Nombre + " " + f.Apellido}).FirstOrDefault(f => f.Dni == dni);

        //obtengo las guias asignadas al fletero en el CD actual
        public (IEnumerable<Guia> distribucion, IEnumerable<Guia> retiro) GetGuiasPorFletero(int dni)
        {
            // HDRs asignadas al fletero en el CD actual
            var hdrsFletero = HDRAlmacen.HDR
                .Where(h => h.DNIFletero == dni &&
                            (h.CodigoPostalDestino == CDActual.CodigoPostal ||
                             h.CodigoPostalOrigen == CDActual.CodigoPostal))
                .ToList();



            //guías de distribución 
            var distribucion = hdrsFletero.Where(h => h.TipoHDR == TipoHDREnum.Distribucion)
                                          .SelectMany(h => h.Guias.Select(numGuia => new { numGuia, hdrId = h.ID }))
                                          .Join(GuiaAlmacen.guias,
                                            x => x.numGuia,
                                            guia => guia.NumeroGuia,
                                            (x, guia) => new Guia
                                            {
                                               Numero = x.numGuia.ToString(),
                                               NroHDR = x.hdrId,  // ← Usar directamente el ID que ya tienes
                                            })
                                          .Where(g => GuiaAlmacen.guias.First(gu => gu.NumeroGuia.ToString() == g.Numero).Estado == EstadoGuiaEnum.EnRutaAlDomicilioDeEntrega ||
                                                   GuiaAlmacen.guias.First(gu => gu.NumeroGuia.ToString() == g.Numero).Estado == EstadoGuiaEnum.EnRutaAlaAgenciaDestino)
                                            .OrderBy(g => g.Numero)
                                            .ToList();


            // guías de retiro
            var retiro = hdrsFletero.Where(h => h.TipoHDR == TipoHDREnum.Retiro)
                                    .SelectMany(h => h.Guias.Select(numGuia => new { numGuia, hdrId = h.ID }))  // ← Llevar el ID de la HDR
                                    .Join(GuiaAlmacen.guias,
                                    x => x.numGuia,
                                    guia => guia.NumeroGuia,
                                    (x, guia) => new Guia
                                    {
                                        Numero = x.numGuia.ToString(),
                                        NroHDR = x.hdrId,  // ← Usar directamente el ID que ya tienes
                                    })
                                    .Where(g => GuiaAlmacen.guias.First(gu => gu.NumeroGuia.ToString() == g.Numero).Estado == EstadoGuiaEnum.EnRutaACDDeOrigenDesdeAgencia ||
                                            GuiaAlmacen.guias.First(gu => gu.NumeroGuia.ToString() == g.Numero).Estado == EstadoGuiaEnum.EnCaminoARetirarPorDomicilio)
                                    .OrderBy(g => g.Numero)
                                    .ToList();

            return (distribucion, retiro);

        }


        public void ConfirmarRendicion(int dni, List<string> entregasDistribucionMarcadas, List<string> retirosMarcados)
        {
            if (BuscarFleteroPorDni(dni) == null)
                throw new InvalidOperationException("Debe seleccionar un transportista primero.");

            if (CDActual == null)
                throw new InvalidOperationException("Debe seleccionar un Centro de Distribución.");

            _ultimosRetirosMarcados = new List<Guia>();
            string ubicacion = ""; 

            //Procesar guías de distribución marcadas
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
                    guia.Estado = EstadoGuiaEnum.PendienteDeEntrega; //revisar acá 
                    ubicacion = ObtenerDestinoParaDistribucion(guia.NumeroGuia);
                }
                else
                {
                    guia.Estado = EstadoGuiaEnum.Entregada;
                }

                // Guardar historial
                guia.Historial.Add(new RegistroEstadoAux
                {
                    Estado = guia.Estado,
                    UbicacionGuia = ubicacion,
                    FechaActualizacionEstado = DateTime.Now
                });
            }

            // Procesar guías de retiro marcadas
            var guiasRetiro = GuiaAlmacen.guias
                .Where(x => retirosMarcados.Contains(x.NumeroGuia.ToString()))
                .ToList();

            foreach (var guia in guiasRetiro)
            {
                var hdrAnterior = HDRAlmacen.HDR.FirstOrDefault(h => h.Guias.Contains(guia.NumeroGuia));

                // Cambiar estado a Admitida
                guia.Estado = EstadoGuiaEnum.Admitida;
                guia.ImporteAFacturar = CalcularImporte(guia.NumeroGuia);

                // Guardar historial , primero en admitida
                guia.Historial.Add(new RegistroEstadoAux
                {
                    Estado = guia.Estado,
                    UbicacionGuia = CDActual.Nombre,
                    FechaActualizacionEstado = DateTime.Now
                });


                if (guia.CodigoPostalCDDestino == CDActual.CodigoPostal)
                {
                    guia.Estado = EstadoGuiaEnum.EnCDDestino;

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
                                                                                            //Aca Grabamos
                                                                                            GuiaAlmacen.Grabar();
                
                }
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

            var GuiasParaDistribucionSinHDR = GuiaAlmacen.guias.Where(g =>g.CodigoPostalCDDestino == CDActual.CodigoPostal
                                                    && g.Estado == EstadoGuiaEnum.EnCDDestino)
                                                    .Take(5)  // Tomar solo 5 guías de distribución
                                                    .ToList();

            // Agrupar por cliente y generar IDs únicos
            var resultadoDistribucion = new List<Guia>();
            var resultadoRetiro = new List<Guia>();

            // Agrupar guías de distribución por cliente + destino
            var gruposDistribucion = GuiasParaDistribucionSinHDR
                .GroupBy(g => new { g.CUITCliente, g.CodigoPostalCDDestino })
                .ToList();

            foreach (var grupo in gruposDistribucion)
            {
                var codigoOrigen = CDActual.CodigoPostal;
                var codigoDestino = grupo.Key.CodigoPostalCDDestino;
                var idHdr = $"D {codigoOrigen:00000} {secuencia:000000} {codigoDestino:00000}";
                
                foreach (var g in grupo.Take(5))
                {
                    resultadoDistribucion.Add(new Guia
                    {
                        Numero = g.NumeroGuia.ToString(),
                        NroHDR = idHdr,
                        Tamaño = g.Tamano.ToString(),
                        Destino = ObtenerDestinoParaDistribucion(g.NumeroGuia),
                    });
                }
                secuencia++;
            }

            // Agrupar guías de retiro por cliente + origen
            var gruposRetiro = GuiasParaRetiroSinHDR
                .GroupBy(g => new { g.CUITCliente, g.CodigoPostalCDOrigen })
                .ToList();

            foreach (var grupo in gruposRetiro)
            {
                var codigoOrigen = grupo.Key.CodigoPostalCDOrigen;
                var codigoDestino = CDActual.CodigoPostal;
                var idHdr = $"R {codigoOrigen:00000} {secuencia:000000} {codigoDestino:00000}";
                
                foreach (var g in grupo.Take(5))
                {
                    resultadoRetiro.Add(new Guia
                    {
                        Numero = g.NumeroGuia.ToString(),
                        NroHDR = idHdr,
                        Tamaño = g.Tamano.ToString(),
                        Destino = ObtenerDestinoParaRetiro(g.NumeroGuia),
                    });
                }
                secuencia++;
            }

            // Agregar guías a la lista de posibles
            GuiasPosibles.AddRange(GuiasParaRetiroSinHDR.Select(g => g.NumeroGuia));
            GuiasPosibles.AddRange(GuiasParaDistribucionSinHDR.Select(g => g.NumeroGuia));

            return (distribucion: resultadoDistribucion, retiro: resultadoRetiro);
        }

        public void AsignarHDRsPorDireccion(int dni)
        {
            if (CDActual == null)
                throw new InvalidOperationException("Debe seleccionar un Centro de Distribución.");

            var secuencia = HDRAlmacen.HDR.Count + 1;

            // Guías que fueron seleccionadas en el paso anterior
            var guiasReales = GuiaAlmacen.guias
                .Where(g => GuiasPosibles.Contains(g.NumeroGuia))
                .ToList();

            // Separar las de distribución y retiro
            var guiasDistribucion = guiasReales
                .Where(g => g.Estado == EstadoGuiaEnum.Admitida || g.Estado == EstadoGuiaEnum.EnCDDestino)
                .ToList();

            var guiasRetiro = guiasReales
                .Where(g => g.Estado == EstadoGuiaEnum.ARetirarEnAgenciaDeOrigen ||
                            g.Estado == EstadoGuiaEnum.ARetirarPorDomicilioDelCliente)
                .ToList();

            // Agrupar guías de distribución por Cliente (CUIT) + Destino
            var gruposDistribucion = guiasDistribucion
                .GroupBy(g => new { 
                    CUITCliente = g.CUITCliente, 
                    CodigoPostalDestino = g.CodigoPostalCDDestino 
                })
                .ToList();

            // Crear HDRs de distribución (una por cada cliente-destino)
            foreach (var grupo in gruposDistribucion)
            {
                // Tomar máximo 5 guías por HDR
                var guiasDelGrupo = grupo.Take(5).ToList();
            
                var codigoOrigen = CDActual.CodigoPostal;
                var codigoDestino = grupo.Key.CodigoPostalDestino;
                var cuitCliente = grupo.Key.CUITCliente;
            
                var idHdr = $"D {codigoOrigen:00000} {secuencia:000000} {codigoDestino:00000}";

                var hdr = new HDREntidad
                {
                    ID = idHdr,
                    DNIFletero = dni,
                    TipoHDR = TipoHDREnum.Distribucion,
                    CodigoPostalOrigen = codigoOrigen,
                    CodigoPostalDestino = codigoDestino,
                    Guias = guiasDelGrupo.Select(g => g.NumeroGuia).ToList()
                };

                foreach (var guia in guiasDelGrupo)
                    ActualizarEstadoGuia(guia.NumeroGuia, dni);

                HDRAlmacen.HDR.Add(hdr);
                secuencia++;

                // Si el grupo tiene más de 5 guías, crear HDRs adicionales
                var guiasRestantes = grupo.Skip(5).ToList();
                while (guiasRestantes.Any())
                {
                    var siguienteGrupo = guiasRestantes.Take(5).ToList();
                
                    var idHdrAdicional = $"D {codigoOrigen:00000} {secuencia:000000} {codigoDestino:00000}";

                    var hdrAdicional = new HDREntidad
                    {
                        ID = idHdrAdicional,
                        DNIFletero = dni,
                        TipoHDR = TipoHDREnum.Distribucion,
                        CodigoPostalOrigen = codigoOrigen,
                        CodigoPostalDestino = codigoDestino,
                        Guias = siguienteGrupo.Select(g => g.NumeroGuia).ToList()
                    };

                    foreach (var guia in siguienteGrupo)
                        ActualizarEstadoGuia(guia.NumeroGuia, dni);

                    HDRAlmacen.HDR.Add(hdrAdicional);
                    secuencia++;
                
                    guiasRestantes = guiasRestantes.Skip(5).ToList();
                }
            }

            // Agrupar guías de retiro por Cliente (CUIT) + Origen
            var gruposRetiro = guiasRetiro
                .GroupBy(g => new { 
                    CUITCliente = g.CUITCliente, 
                    CodigoPostalOrigen = g.CodigoPostalCDOrigen 
                })
                .ToList();

            // Crear HDRs de retiro (una por cada cliente-origen)
            foreach (var grupo in gruposRetiro)
            {
                // Tomar máximo 5 guías por HDR
                var guiasDelGrupo = grupo.Take(5).ToList();
            
                var codigoOrigen = grupo.Key.CodigoPostalOrigen;
                var codigoDestino = CDActual.CodigoPostal;
                var cuitCliente = grupo.Key.CUITCliente;
            
                var idHdr = $"R {codigoOrigen:00000} {secuencia:000000} {codigoDestino:00000}";

                var hdr = new HDREntidad
                {
                    ID = idHdr,
                    DNIFletero = dni,
                    TipoHDR = TipoHDREnum.Retiro,
                    CodigoPostalOrigen = codigoOrigen,
                    CodigoPostalDestino = codigoDestino,
                    Guias = guiasDelGrupo.Select(g => g.NumeroGuia).ToList()
                };

                foreach (var guía in guiasDelGrupo)
                    ActualizarEstadoGuia(guía.NumeroGuia, dni);

                HDRAlmacen.HDR.Add(hdr);
                secuencia++;

                // Si el grupo tiene más de 5 guías, crear HDRs adicionales
                var guiasRestantes = grupo.Skip(5).ToList();
                while (guiasRestantes.Any())
                {
                    var siguienteGrupo = guiasRestantes.Take(5).ToList();
                
                    var idHdrAdicional = $"R {codigoOrigen:00000} {secuencia:000000} {codigoDestino:00000}";

                    var hdrAdicional = new HDREntidad
                    {
                        ID = idHdrAdicional,
                        DNIFletero = dni,
                        TipoHDR = TipoHDREnum.Retiro,
                        CodigoPostalOrigen = codigoOrigen,
                        CodigoPostalDestino = codigoDestino,
                        Guias = siguienteGrupo.Select(g => g.NumeroGuia).ToList()
                    };

                    foreach (var guia in siguienteGrupo)
                        ActualizarEstadoGuia(guia.NumeroGuia, dni);

                    HDRAlmacen.HDR.Add(hdrAdicional);
                    secuencia++;
                
                    guiasRestantes = guiasRestantes.Skip(5).ToList();
                }
            }

            if (guiasReales.Any())
            {
                                                                                                            //Aca Grabamos
                                                                                                            GuiaAlmacen.Grabar();
                                                                                                            HDRAlmacen.Grabar();
            }
        }

        public void AsegurarHDRsAsignadasParaFletero(int dni) { }

        private void ActualizarEstadoGuia(int NroGuia, int dni)
        {
            // Determinar el nuevo estado según el tipo de guía
            var guia = GuiaAlmacen.guias.First(g => g.NumeroGuia == NroGuia);

            EstadoGuiaEnum nuevoEstado = guia.Estado;
            string Ubicacion = "";
            var AgenciaUbicacion = AgenciaAlmacen.agencias.FirstOrDefault(a => a.ID.Substring(1) == guia.IDAgenciaOrigen);

            switch (guia.Estado)
            {
                case EstadoGuiaEnum.ARetirarPorDomicilioDelCliente:
                    nuevoEstado = EstadoGuiaEnum.EnCaminoARetirarPorDomicilio;
                    Ubicacion = "En domicilio cliente"; 
                    break;

                case EstadoGuiaEnum.ARetirarEnAgenciaDeOrigen:
                    nuevoEstado = EstadoGuiaEnum.EnCaminoARetirarPorAgencia;
                    Ubicacion = AgenciaUbicacion.Nombre;
                    break;

                case EstadoGuiaEnum.Admitida when guia.TipoEntrega == EntregaEnum.Domicilio:
                    nuevoEstado = EstadoGuiaEnum.EnRutaAlDomicilioDeEntrega;
                    Ubicacion = $"En transporte con Fletero DNI: {dni}";
                    break;

                case EstadoGuiaEnum.Admitida when guia.TipoEntrega == EntregaEnum.Agencia:
                    nuevoEstado = EstadoGuiaEnum.EnRutaAlaAgenciaDestino;
                    Ubicacion = $"En transporte con Fletero DNI: {dni}";
                    break;

                case EstadoGuiaEnum.EnCDDestino when guia.TipoEntrega == EntregaEnum.Domicilio:
                    nuevoEstado = EstadoGuiaEnum.EnRutaAlDomicilioDeEntrega;
                    Ubicacion = $"En transporte con Fletero DNI: {dni}";
                    break;

                case EstadoGuiaEnum.EnCDDestino when guia.TipoEntrega == EntregaEnum.Agencia:
                    nuevoEstado = EstadoGuiaEnum.EnRutaAlaAgenciaDestino;
                    Ubicacion = $"En transporte con Fletero DNI: {dni}";
                    break;

                default:
                    return;
            }

            // Actualizar estado y agregar al historial
            guia.Estado = nuevoEstado;
            guia.Historial.Add(new RegistroEstadoAux
            {
                Estado = nuevoEstado,
                UbicacionGuia = Ubicacion,
                FechaActualizacionEstado = DateTime.Now
            });
        }

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
            bool TuvoRetiroDomicilio = guia.Historial.Any(x => x.Estado == EstadoGuiaEnum.ARetirarPorDomicilioDelCliente);


            if (guia.TipoEntrega == EntregaEnum.Domicilio &&
                Convenio.Extras.TryGetValue(ExtrasEnum.ExtraEntregaDomicilio, out decimal EntregaDomicilio))
            {
                Extras += EntregaDomicilio;
            }

            if (guia.TipoEntrega == EntregaEnum.Domicilio &&
              Convenio.Extras.TryGetValue(ExtrasEnum.ExtraEntregaAgencia, out decimal EntregaAgencia))
            {
                Extras += EntregaAgencia;
            }

            if (TuvoRetiroDomicilio && Convenio.Extras.TryGetValue(ExtrasEnum.ExtraEntregaAgencia, out decimal RetiroDomicilio))
            {

                Extras += RetiroDomicilio;
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
                                .FirstOrDefault(a => a.ID.Substring(1) == guia.IDAgenciaDestino);
                return AgenciaEntrega.Nombre;
            }
            else
            {
                var DomicilioEntrega = guia.Destinatario?.Direccion ?? string.Empty;
                return DomicilioEntrega;
            }

        }
    }

}
