using System;
using System.Collections.Generic;
using System.Linq;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.ImponerEncomiendaCD
{
    public class ImponerEncomiendaCentroDistribucionModelo
    {
        // ---------- DATOS DE PRUEBA ----------
        /*
        private readonly List<Cliente> _clientes = new()
        {
            new Cliente { Cuit = "30-12345678-1", Nombre = "Distribuidora Sur", Telefono = "1122334455", Direccion = "Av. Siempre Viva 742, CABA" },
            new Cliente { Cuit = "20-11111111-2", Nombre = "Mayorista Norte", Telefono = "1144556677", Direccion = "San Martín 1200, La Plata" },
            new Cliente { Cuit = "30-22223333-3", Nombre = "Logística Pampeana", Telefono = "1133665599", Direccion = "Ruta 5 km 320, Santa Rosa" },
            new Cliente { Cuit = "27-44445555-6", Nombre = "Agroexport SRL", Telefono = "1147891234", Direccion = "Av. Mitre 2300, Rosario" },
            new Cliente { Cuit = "33-55556666-7", Nombre = "Transportes del Litoral", Telefono = "1125873645", Direccion = "Av. Maipú 2700, Corrientes" },
            new Cliente { Cuit = "20-77778888-9", Nombre = "Comercial Andina", Telefono = "2614567890", Direccion = "San Martín 1800, Mendoza" },
            new Cliente { Cuit = "23-99990000-1", Nombre = "Depósito Patagónico", Telefono = "2994672301", Direccion = "Anaya 3005, Neuquén" }
        };

        // Provincias con CD
        private readonly Dictionary<int, string> _provincias = new()
        {
            { 1, "CABA" }, { 2, "Buenos Aires" }, { 3, "Córdoba" }, { 4, "Santa Fe" },
            { 5, "Tucumán" }, { 6, "Corrientes" }, { 7, "Neuquén" }, { 8, "Río Negro" }, { 9, "Mendoza" }
        };

        // Localidades por Provincia: (id, nombre, tieneAgencia)
        private readonly Dictionary<int, List<(int id, string nombre, bool tieneAgencia)>> _localidadesPorProv = new()
        {
            { 1, new() { (101,"CABA", true) } },
            { 2, new() { (201,"La Plata", true), (202,"Mar del Plata", true), (203,"Bahía Blanca", true), (1001,"San Isidro", true), (1002,"Quilmes", true), (1003,"Pilar", true) } },
            { 3, new() { (301,"Río Cuarto", true), (302,"Córdoba Capital", true), (303,"Villa Allende", true) } },
            { 4, new() { (401,"Rosario", true), (402,"Funes", true) } },
            { 5, new() { (501,"San Miguel de Tucumán", true), (502,"Yerba Buena", true) } },
            { 6, new() { (601,"Corrientes", true), (602,"Goya", true) } },
            { 7, new() { (701,"Neuquén", true), (702,"Plottier", true) } },
            { 8, new() { (801,"Viedma", true), (802,"San Antonio Oeste", true) } },
            { 9, new() { (901,"Mendoza", true), (902,"Godoy Cruz", true) } }
        };

        // Agencias por Localidad
        private readonly Dictionary<int, List<(int id, string nombre, string direccion)>> _agenciasPorLoc = new()
        {
            { 101, new() { (5001,"Agencia CABA Centro","Av. Corrientes 1000"), (5002,"Agencia CABA Flores","Av. Rivadavia 7100") } },
            { 201, new() { (5101,"Agencia La Plata","Calle 8 123"), (5104,"Agencia Quilmes","Av. Calchaquí 3950"), (5106,"Agencia San Isidro","Av. Centenario 1100"), (5105,"Agencia Pilar","Panamericana Km 50") } },
            { 202, new() { (5102,"Agencia Mar del Plata","Av. Colón 5000") } },
            { 203, new() { (5103,"Agencia Bahía Blanca Centro","Av. Alem 100") } },
            { 301, new() { (5201,"Agencia Nueva Córdoba","Bv. Chacabuco 1050") } },
            { 302, new() { (5202,"Agencia Córdoba Norte","Av. P. Cabrera 5000") } },
            { 303, new() { (5203,"Agencia Villa Allende","Av. Goycochea 50") } },
            { 401, new() { (5301,"Agencia Rosario Centro","Córdoba 1400"), (5302,"Agencia Rosario Norte","Bv. Rondeau 2500") } },
            { 402, new() { (5303,"Agencia Funes","San José 1200") } },
            { 501, new() { (5401,"Agencia Tucumán Centro","24 de Septiembre 500"), (5402,"Agencia Yerba Buena","Av. Aconquija 1500") } },
            { 601, new() { (5501,"Agencia Corrientes Centro","Junín 850") } },
            { 602, new() { (5502,"Agencia Goya","Colón 850") } },
            { 701, new() { (5601,"Agencia Neuquén Centro","Av. Argentina 1200"), (5602,"Agencia Plottier","San Martín 300") } },
            { 801, new() { (5701,"Agencia Viedma Centro","25 de Mayo 400") } },
            { 802, new() { (5702,"Agencia San Antonio Oeste","Mitre 200") } },
            { 901, new() { (5801,"Agencia Mendoza Centro","Av. San Martín 1200") } },
            { 902, new() { (5802,"Agencia Godoy Cruz","San Martín Sur 1800") } }
        };

        // CDs por Provincia
        private readonly Dictionary<int, List<(int id, string nombre, string direccion)>> _cdsPorProv = new()
        {
            { 1, new() { (9001,"CD CABA Oeste","Av. Warnes 200"), (9002,"CD CABA Sur","Av. Rondeau 300") } },
            { 2, new() { (9101,"CD Buenos Aires – La Plata","Av. 520 y 25"), (9102,"CD Buenos Aires – Mar del Plata","Av. J. B. Justo 9000"), (9901,"CD Bahía Blanca","Drago 1900") } },
            { 3, new() { (9201,"CD Córdoba Capital","Av. Sabattini 3000") } },
            { 4, new() { (9301,"CD Rosario","Cafferata 702") } },
            { 5, new() { (9401,"CD San Miguel de Tucumán","Av. Brígido Terán 250") } },
            { 6, new() { (9501,"CD Corrientes","Av. Maipú 2700") } },
            { 7, new() { (9601,"CD Neuquén","Anaya 3005") } },
            { 8, new() { (9701,"CD Viedma","Av. F. de Viedma 1400") } },
            { 9, new() { (9801,"CD Mendoza Capital","Acceso Este y Costanera") } }
        };

        // --- Numeración TLLLNNNNN ---
        private readonly Dictionary<int, int> _codigoCD3 = new()
        {
            { 9001, 001 }, { 9002, 002 }, { 9101, 010 }, { 9102, 011 }, { 9201, 040 },
            { 9301, 050 }, { 9401, 060 }, { 9501, 070 }, { 9601, 080 }, { 9701, 090 },
            { 9801, 100 }, { 9901, 110 }
        };
        */

        // =============================================================
        // 1) DATOS TRAIDOS DESDE ALMACENES
        // =============================================================

        private static string Digits(string s) => new string(s.Where(char.IsDigit).ToArray());

        // Clientes desde almacén
        private readonly List<Cliente> _clientes =
            ClienteAlmacen.clientes
                .Select(c => new Cliente
                {
                    Cuit = c.CUIT ?? string.Empty,
                    Nombre = c.RazonSocial ?? string.Empty,
                    Telefono = c.Telefono ?? string.Empty,
                    Direccion = c.Direccion ?? string.Empty
                })
                .ToList();

        // Provincias desde CDs (id = CP del CD; nombre = sin prefijo "CD ")
        private readonly Dictionary<int, string> _provincias =
            CentroDeDistribucionAlmacen.centrosDeDistribucion
                .Select(cd => new
                {
                    cd.CodigoPostal,
                    Nombre = (cd.Nombre ?? $"CD {cd.CodigoPostal}")
                                .Replace("CD ", string.Empty, StringComparison.OrdinalIgnoreCase)
                                .Trim()
                })
                .GroupBy(x => x.CodigoPostal)
                .ToDictionary(g => g.Key, g => g.First().Nombre);

        // Localidades por provincia (construidas en ctor)
        private readonly Dictionary<int, List<(int id, string nombre, bool tieneAgencia)>> _localidadesPorProv;
        // Agencias por localidad
        private readonly Dictionary<int, List<(int id, string nombre, string direccion)>> _agenciasPorLoc;
        // CDs por provincia (clave = CP del CD)
        private readonly Dictionary<int, List<(int id, string nombre, string direccion)>> _cdsPorProv;
        // Código LLL para numeración (por CP del CD)
        private readonly Dictionary<int, int> _codigoCD3;

        // Origen fijo para CD (expuesto directo, sin const duplicados)
        public int OrigenCdFijoId => 9501;
        public string OrigenCdFijoNombre => "CD Corrientes";

        // Numeración TLLLNNNNN → CD: 0001–0999, Agencia: 1000+
        private static readonly Dictionary<int, int> _seqPorOrigen = new();
        private static string NextGuiaCode(bool esCD, int codigo3)
        {
            int codigo4 = esCD ? codigo3 : (1000 + codigo3);
            _seqPorOrigen[codigo4] = _seqPorOrigen.TryGetValue(codigo4, out var s) ? s + 1 : 1;
            return $"{codigo4:D4}{_seqPorOrigen[codigo4]:D5}";
        }

        public ImponerEncomiendaCentroDistribucionModelo()
        {
            // Localidades por provincia (LINQ)
            _localidadesPorProv = _provincias.Keys
                .Select(prov => new
                {
                    prov,
                    provEnum = LocalidadAlmacen.localidades.FirstOrDefault(l => l.CodigoPostal == prov)?.Provincia
                })
                .ToDictionary(
                    x => x.prov,
                    x => LocalidadAlmacen.localidades
                            .Where(l => l.Provincia.Equals(x.provEnum))
                            .Select(l => new
                            {
                                id = l.CodigoPostal,
                                nombre = l.Nombre ?? string.Empty,
                                tieneAgencia = AgenciaAlmacen.agencias.Any(a => a.CodigoPostal == l.CodigoPostal),
                                esLocalidadDelCD = l.CodigoPostal == x.prov
                            })
                            .Where(t => t.tieneAgencia || t.esLocalidadDelCD)
                            .GroupBy(t => t.id)
                            .Select(g => g.First())
                            .OrderBy(t => t.nombre)
                            .Select(t => (t.id, t.nombre, t.tieneAgencia))
                            .ToList()
                );

            // Agencias por localidad (LINQ)
            _agenciasPorLoc = AgenciaAlmacen.agencias
                .GroupBy(a => a.CodigoPostal)
                .ToDictionary(
                    g => g.Key,
                    g => g
                        .Select(ag =>
                        {
                            var idDigits = Digits(ag.ID ?? string.Empty);
                            int.TryParse(idDigits, out var idNum);
                            return (id: idNum, nombre: ag.Nombre ?? string.Empty, direccion: ag.Direccion ?? string.Empty);
                        })
                        .OrderBy(t => t.nombre)
                        .ToList()
                );

            // CDs por provincia (LINQ)
            _cdsPorProv = CentroDeDistribucionAlmacen.centrosDeDistribucion
                .GroupBy(cd => cd.CodigoPostal)
                .ToDictionary(
                    g => g.Key,
                    g => g
                        .Select(cd => (id: cd.CodigoPostal,
                                       nombre: cd.Nombre ?? $"CD {cd.CodigoPostal}",
                                       direccion: cd.Direccion ?? string.Empty))
                        .OrderBy(t => t.nombre)
                        .ToList()
                );

            // Código LLL por CP del CD (LINQ)
            _codigoCD3 = CentroDeDistribucionAlmacen.centrosDeDistribucion
                .GroupBy(cd => cd.CodigoPostal)
                .ToDictionary(
                    g => g.Key,
                    g =>
                    {
                        var key = g.Key;
                        var last3 = Math.Abs(key) % 1000;
                        return last3 == 0 ? 1 : last3;
                    }
                );
        }

        // =============================================================
        // 2) FUNCIONES DEL MODELO
        // =============================================================

        public Cliente? BuscarCliente(string cuit)
        {
            var digits = Digits(cuit);
            return _clientes.FirstOrDefault(c => Digits(c.Cuit) == digits);
        }

        public List<KeyValuePair<int, string>> GetProvincias() => _provincias.ToList();

        public List<(int id, string nombre, bool tieneAgencia)> GetLocalidades(int provinciaId)
        {
            var list = _localidadesPorProv.TryGetValue(provinciaId, out var locs) ? new List<(int, string, bool)>(locs) : new();
            list.Add((-1, "Otras", false));
            return list;
        }

        public List<KeyValuePair<int, string>> GetAgencias(int localidadId)
        {
            if (localidadId == -1) return new List<KeyValuePair<int, string>>();
            return _agenciasPorLoc.TryGetValue(localidadId, out var ags)
                ? ags.Select(a => new KeyValuePair<int, string>(a.id, a.nombre)).ToList()
                : new List<KeyValuePair<int, string>>();
        }

        public List<KeyValuePair<int, string>> GetCDs(int provinciaId)
        {
            return _cdsPorProv.TryGetValue(provinciaId, out var cds)
                ? cds.Select(c => new KeyValuePair<int, string>(c.id, c.nombre)).ToList()
                : new List<KeyValuePair<int, string>>();
        }

        public string[] GetTiposEntregaDisponibles(int provinciaId, int localidadId)
        {
            if (localidadId == -1) return new[] { "A domicilio" };

            var tipos = new List<string> { "A domicilio" };

            if (_localidadesPorProv.TryGetValue(provinciaId, out var locs)
                && locs.Any(l => l.id == localidadId && l.tieneAgencia)
                && _agenciasPorLoc.TryGetValue(localidadId, out var ags)
                && ags.Count > 0)
            { tipos.Add("En Agencia"); }

            if (_cdsPorProv.TryGetValue(provinciaId, out var cds) && cds.Count > 0)
            { tipos.Add("En CD"); }

            return tipos.ToArray();
        }

        // =============================================================
        // 3) CREACION DE LA GUIA
        // =============================================================

        // Confirmar: valida y crea UNA guía por cada bulto (sin persistencia)
        public List<Guia> ConfirmarImposicion(
            string cuitRemitente,
            string destNombre, string destApellido, string destDni,
            int provinciaId, string provinciaNombre,
            int? localidadId, string? localidadNombre, bool localidadEsOtras,
            string tipoEntrega,
            string? direccion, string? codigoPostal,
            int? agenciaId, string? agenciaNombre,
            int? cdDestinoId, string? cdDestinoNombre,
            int cantS, int cantM, int cantL, int cantXL,
            int cdOrigenId = 0, string cdOrigenNombre = ""
        )
        {
            var cli = BuscarCliente(cuitRemitente);
            if (cli is null) throw new InvalidOperationException("CUIT inexistente.");

            if ((cantS + cantM + cantL + cantXL) == 0)
                throw new InvalidOperationException("Debe indicar al menos una encomienda (S/M/L/XL).");

            if (!_provincias.ContainsKey(provinciaId))
                throw new InvalidOperationException("Provincia inválida.");

            if (!localidadEsOtras && localidadId.HasValue)
            {
                var ok = _localidadesPorProv.TryGetValue(provinciaId, out var locs) && locs.Any(l => l.id == localidadId.Value);
                if (!ok) throw new InvalidOperationException("La localidad no pertenece a la provincia seleccionada.");
            }

            switch (tipoEntrega)
            {
                case "A domicilio":
                    if (string.IsNullOrWhiteSpace(direccion))
                        throw new InvalidOperationException("Para entrega a Domicilio debe completar Dirección.");
                    break;

                case "En Agencia":
                    if (!agenciaId.HasValue)
                        throw new InvalidOperationException("Debe seleccionar una Agencia.");
                    var agOk = localidadId.HasValue
                               && _agenciasPorLoc.TryGetValue(localidadId.Value, out var ags)
                               && ags.Any(a => a.id == agenciaId.Value);
                    if (!agOk) throw new InvalidOperationException("La agencia no pertenece a la localidad seleccionada.");
                    break;

                case "En CD":
                    if (!cdDestinoId.HasValue)
                        throw new InvalidOperationException("Debe seleccionar un Centro de Distribución (destino).");
                    var cdOk = _cdsPorProv.TryGetValue(provinciaId, out var cds)
                               && cds.Any(c => c.id == cdDestinoId.Value);
                    if (!cdOk) throw new InvalidOperationException("El CD seleccionado no pertenece a la provincia.");
                    break;
                default:
                    throw new InvalidOperationException("Tipo de entrega inválido.");
            }

            // Origen fijo
            if (cdOrigenId != OrigenCdFijoId)
            {
                cdOrigenId = OrigenCdFijoId;
                cdOrigenNombre = OrigenCdFijoNombre;
            }
            if (string.IsNullOrWhiteSpace(cdOrigenNombre))
                cdOrigenNombre = OrigenCdFijoNombre;

            var guias = new List<Guia>();
            var cuitDigits = Digits(cuitRemitente);

            void AgregarGuia(int s, int m, int l, int xl)
            {
                // We'll set Numero later after creating entity to ensure uniqueness
                guias.Add(new Guia
                {
                    Numero = string.Empty,
                    Estado = "Admitida",
                    CuitRemitente = cuitDigits,
                    Destinatario = new Destinatario { Nombre = destNombre, Apellido = destApellido, Dni = destDni },
                    CdOrigenId = cdOrigenId,
                    CdOrigenNombre = cdOrigenNombre,
                    ProvinciaId = provinciaId,
                    ProvinciaNombre = provinciaNombre,
                    LocalidadId = localidadId,
                    LocalidadNombre = localidadNombre,
                    LocalidadEsOtras = localidadEsOtras,
                    TipoEntrega = tipoEntrega,
                    Direccion = direccion,
                    CodigoPostal = codigoPostal,
                    AgenciaId = agenciaId,
                    AgenciaNombre = agenciaNombre,
                    CDId = cdDestinoId,
                    CDNombre = cdDestinoNombre,
                    CantS = s,
                    CantM = m,
                    CantL = l,
                    CantXL = xl
                });
            }

            for (int i = 0; i < cantS; i++) AgregarGuia(1, 0, 0, 0);
            for (int i = 0; i < cantM; i++) AgregarGuia(0, 1, 0, 0);
            for (int i = 0; i < cantL; i++) AgregarGuia(0, 0, 1, 0);
            for (int i = 0; i < cantXL; i++) AgregarGuia(0, 0, 0, 1);

            // Compute a global starting number > any existing NumeroGuia loaded from JSON
            int nextGlobal = 1;
            if (GuiaAlmacen.guias.Any())
            {
                var maxExisting = GuiaAlmacen.guias.Max(g => g.NumeroGuia);
                nextGlobal = maxExisting + 1;
            }

            // Mapear y registrar en el almacen en memoria (no persistir en disco)
            foreach (var g in guias)
            {
                // Determinar tamano (uno de los 4 debe ser 1)
                TamanoEnum tam = TamanoEnum.S;
                if (g.CantM == 1) tam = TamanoEnum.M;
                else if (g.CantL == 1) tam = TamanoEnum.L;
                else if (g.CantXL == 1) tam = TamanoEnum.XL;

                // Calcular importe simple por tamaño (valor prototipo)
                decimal importe = tam switch
                {
                    TamanoEnum.S => 100m,
                    TamanoEnum.M => 150m,
                    TamanoEnum.L => 200m,
                    TamanoEnum.XL => 300m,
                    _ => 0m
                };

                // Resolver ID Agencia destino (string) si existe
                string idAgDestino = string.Empty;
                if (g.AgenciaId.HasValue)
                {
                    var found = AgenciaAlmacen.agencias.FirstOrDefault(a =>
                    {
                        var digits = new string((a.ID ?? string.Empty).Where(char.IsDigit).ToArray());
                        return int.TryParse(digits, out var n) && n == g.AgenciaId.Value;
                    });
                    idAgDestino = found?.ID ?? g.AgenciaId.Value.ToString();
                }

                // Generate unique global number (guaranteed > any loaded from JSON)
                var numeroInt = nextGlobal++;
                var numeroStr = numeroInt.ToString("D9");
                g.Numero = numeroStr;

                var entidad = new GuiaEntidad
                {
                    NumeroGuia = numeroInt,
                    Estado = EstadoGuiaEnum.Admitida,
                    FechaAdmision = DateTime.Now,
                    TipoEntrega = string.Equals(g.TipoEntrega, "En CD", StringComparison.OrdinalIgnoreCase) ? EntregaEnum.CD :
                                  string.Equals(g.TipoEntrega, "En Agencia", StringComparison.OrdinalIgnoreCase) ? EntregaEnum.Agencia : EntregaEnum.Domicilio,
                    CodigoPostalCDOrigen = g.CdOrigenId,
                    CodigoPostalCDDestino = g.CDId ?? 0,
                    IDAgenciaOrigen = string.Empty,
                    IDAgenciaDestino = idAgDestino,
                    CUITCliente = g.CuitRemitente ?? string.Empty,
                    Tamano = tam,
                    Destinatario = new DestinatarioAux
                    {
                        DNI = int.TryParse(g.Destinatario.Dni, out var dniVal) ? dniVal : 0,
                        Nombre = g.Destinatario.Nombre ?? string.Empty,
                        Apellido = g.Destinatario.Apellido ?? string.Empty,
                        Direccion = g.Direccion ?? string.Empty,
                        CodigoPostal = g.CodigoPostal != null && int.TryParse(g.CodigoPostal, out var cp) ? cp : 0
                    },
                    IDConvenio = 0,
                    ImporteAFacturar = importe,
                    ComisionAgenciaOrigen = 0m,
                    ComisionAgenciaDestino = 0m,
                    ComisionFleteroOrigen = 0m,
                    ComisionFleteroDestino = 0m,
                    Historial = new List<RegistroEstadoAux>
                    {
                        new RegistroEstadoAux
                        {
                            Estado = EstadoGuiaEnum.Admitida,
                            UbicacionGuia = CentroDeDistribucionAlmacen.centrosDeDistribucion
                                .FirstOrDefault(cd => cd.CodigoPostal == g.CdOrigenId)?.Nombre ?? string.Empty,
                            FechaActualizacionEstado = DateTime.Now
                        }
                    }
                };

                // Always add a new entity
                GuiaAlmacen.guias.Add(entidad);
            }

            return guias;
        }

        /// <summary>
        /// Verifica y marca una guía existente en memoria como Admitida. Calcula importe si faltara.
        /// No persiste a disco.
        /// </summary>
        public GuiaEntidad? VerificarYAdmitirGuia(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero)) return null;
            var digits = new string(numero.Where(char.IsDigit).ToArray());
            if (!int.TryParse(digits, out var num)) return null;

            var guia = GuiaAlmacen.guias.FirstOrDefault(g => g.NumeroGuia == num);
            if (guia == null) return null;

            // Calcular importe si es 0
            if (guia.ImporteAFacturar <= 0m)
            {
                guia.ImporteAFacturar = guia.Tamano switch
                {
                    TamanoEnum.S => 100m,
                    TamanoEnum.M => 150m,
                    TamanoEnum.L => 200m,
                    TamanoEnum.XL => 300m,
                    _ => 0m
                };
            }

            // Evitar duplicar un registro 'Admitida' si ya existe uno en el historial con la misma ubicación
            guia.Historial ??= new List<RegistroEstadoAux>();
            var ubic = CentroDeDistribucionAlmacen.centrosDeDistribucion
                        .FirstOrDefault(cd => cd.CodigoPostal == guia.CodigoPostalCDOrigen)?.Nombre ?? string.Empty;

            bool yaAdmitida = guia.Estado == EstadoGuiaEnum.Admitida && guia.Historial.Any(h => h.Estado == EstadoGuiaEnum.Admitida && h.UbicacionGuia == ubic);
            if (!yaAdmitida)
            {
                // Actualizar estado y anotar en historial
                guia.Estado = EstadoGuiaEnum.Admitida;
                guia.Historial.Add(new RegistroEstadoAux
                {
                    Estado = EstadoGuiaEnum.Admitida,
                    UbicacionGuia = ubic,
                    FechaActualizacionEstado = DateTime.Now
                });
            }

            // No persistir (no llamar GuiaAlmacen.Grabar())
            return guia;
        }
    }
}
