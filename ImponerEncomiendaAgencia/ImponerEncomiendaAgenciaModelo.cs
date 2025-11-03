using System;
using System.Collections.Generic;
using System.Linq;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.ImponerEncomiendaAgencia
{
    public class ImponerEncomiendaAgenciaModelo
    {
        // ---------- DATOS DE PRUEBA (COMENTADO) ----------
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

        // CDs por provincia
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
        // == NUEVO: CARGA DESDE ALMACENES (ACTIVO) ====================
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
        // CDs por provincia
        private readonly Dictionary<int, List<(int id, string nombre, string direccion)>> _cdsPorProv;
        // Código LLL para numeración
        private readonly Dictionary<int, int> _codigoCD3;

        // === Origen fijo: Agencia CABA Centro (LLL = 001 => TLLL = 1001) ===
        private const int ORIGEN_AGENCIA_CABA_CENTRO_COD3 = 1;
        // ===================================================================

        // correlativo por origen (TLLL)
        private static readonly Dictionary<int, int> _seqPorOrigen = new();

        // Genera TLLLNNNNN para AGENCIA ⇒ TLLL = 1000 + LLL
        private static string NextGuiaCode_Agencia(int codigo3)
        {
            int codigo4 = 1000 + codigo3; // 1000–1999 = Agencias
            _seqPorOrigen[codigo4] = _seqPorOrigen.TryGetValue(codigo4, out var s) ? s + 1 : 1;
            return $"{codigo4:D4}{_seqPorOrigen[codigo4]:D5}";
        }

        public ImponerEncomiendaAgenciaModelo()
        {
            // Localidades por provincia (id prov = CP del CD)
            _localidadesPorProv = new Dictionary<int, List<(int id, string nombre, bool tieneAgencia)>>();
            foreach (var prov in _provincias.Keys)
            {
                var provEnum = LocalidadAlmacen.localidades.FirstOrDefault(l => l.CodigoPostal == prov)?.Provincia;
                var lista = new List<(int id, string nombre, bool tieneAgencia)>();
                foreach (var loc in LocalidadAlmacen.localidades.Where(l => l.Provincia.Equals(provEnum)))
                {
                    bool tieneAgencia = AgenciaAlmacen.agencias.Any(a => a.CodigoPostal == loc.CodigoPostal);
                    bool esLocalidadDelCD = loc.CodigoPostal == prov;
                    if (tieneAgencia || esLocalidadDelCD)
                    { lista.Add((loc.CodigoPostal, loc.Nombre ?? string.Empty, tieneAgencia)); }
                }
                var ordenada = lista.GroupBy(t => t.id).Select(g => g.First()).OrderBy(t => t.nombre).ToList();
                _localidadesPorProv[prov] = ordenada;
            }

            // Agencias por localidad
            _agenciasPorLoc = new Dictionary<int, List<(int id, string nombre, string direccion)>>();
            foreach (var ag in AgenciaAlmacen.agencias)
            {
                var cp = ag.CodigoPostal;
                var idDigits = Digits(ag.ID ?? string.Empty);
                int.TryParse(idDigits, out var idNum);
                var item = (id: idNum, nombre: ag.Nombre ?? string.Empty, direccion: ag.Direccion ?? string.Empty);
                if (!_agenciasPorLoc.TryGetValue(cp, out var list))
                {
                    list = new List<(int, string, string)>();
                    _agenciasPorLoc[cp] = list;
                }
                list.Add(item);
            }
            foreach (var k in _agenciasPorLoc.Keys.ToList())
            { _agenciasPorLoc[k] = _agenciasPorLoc[k].OrderBy(t => t.nombre).ToList(); }

            // CDs por provincia (clave = CP del CD)
            _cdsPorProv = new Dictionary<int, List<(int id, string nombre, string direccion)>>();
            foreach (var cd in CentroDeDistribucionAlmacen.centrosDeDistribucion)
            {
                var key = cd.CodigoPostal;
                var item = (id: cd.CodigoPostal, nombre: cd.Nombre ?? $"CD {cd.CodigoPostal}", direccion: cd.Direccion ?? string.Empty);
                if (!_cdsPorProv.TryGetValue(key, out var list))
                {
                    list = new List<(int, string, string)>();
                    _cdsPorProv[key] = list;
                }
                list.Add(item);
            }
            foreach (var k in _cdsPorProv.Keys.ToList())
            { _cdsPorProv[k] = _cdsPorProv[k].OrderBy(t => t.nombre).ToList(); }

            // Código LLL por CP del CD
            _codigoCD3 = new Dictionary<int, int>();
            foreach (var cd in CentroDeDistribucionAlmacen.centrosDeDistribucion)
            {
                var key = cd.CodigoPostal;
                var last3 = Math.Abs(key) % 1000;
                var lll = last3 == 0 ? 1 : last3;
                if (!_codigoCD3.ContainsKey(key)) _codigoCD3[key] = lll;
            }
        }

        public Cliente? BuscarCliente(string cuit)
        {
            var digits = Digits(cuit);
            return _clientes.FirstOrDefault(c => Digits(c.Cuit) == digits);
        }

        public IEnumerable<KeyValuePair<int, string>> GetProvincias() => _provincias;

        public IEnumerable<(int id, string nombre, bool tieneAgencia)> GetLocalidades(int provinciaId)
        {
            var list = _localidadesPorProv.TryGetValue(provinciaId, out var locs) ? new List<(int, string, bool)>(locs) : new();
            list.Add((-1, "Otras", false));
            return list;
        }

        public IEnumerable<KeyValuePair<int, string>> GetAgencias(int localidadId)
        {
            if (localidadId == -1) return Array.Empty<KeyValuePair<int, string>>();
            return (_agenciasPorLoc.TryGetValue(localidadId, out var ags)
                ? ags.Select(a => new KeyValuePair<int, string>(a.id, a.nombre))
                : Enumerable.Empty<KeyValuePair<int, string>>());
        }

        public IEnumerable<KeyValuePair<int, string>> GetCDs(int provinciaId)
        {
            return (_cdsPorProv.TryGetValue(provinciaId, out var cds)
                ? cds.Select(c => new KeyValuePair<int, string>(c.id, c.nombre))
                : Enumerable.Empty<KeyValuePair<int, string>>());
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

        // Confirmar: valida y crea UNA guía por cada bulto (SIN persistencia a almacenes)
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
            // Lógica original intacta (usa las colecciones ya cargadas desde almacenes)
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

            var guias = new List<Guia>();

            void AgregarGuia(int s, int m, int l, int xl)
            {
                int lll = ORIGEN_AGENCIA_CABA_CENTRO_COD3;
                var numero = NextGuiaCode_Agencia(codigo3: lll);
                guias.Add(new Guia
                {
                    Numero = numero,
                    Estado = "A retirar en agencia de origen",
                    CuitRemitente = Digits(cuitRemitente),
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

            return guias;
        }

        public int? GetCDIdPorNombre(string nombreCD)
        {
            if (string.IsNullOrWhiteSpace(nombreCD)) return null;

            var cd = _cdsPorProv.Values
                .SelectMany(v => v)
                .FirstOrDefault(c => string.Equals(c.nombre?.Trim(), nombreCD.Trim(), StringComparison.OrdinalIgnoreCase));

            return cd.id != 0 ? cd.id : (int?)null;
        }
    }
}
