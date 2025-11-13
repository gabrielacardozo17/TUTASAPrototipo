using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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

        // 1) DATOS TRAIDOS DESDE ALMACENES

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

        // Provincias desde CDs
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

        // Localidades por provincia
        private readonly Dictionary<int, List<(int id, string nombre, bool tieneAgencia)>> _localidadesPorProv;
        // Agencias por localidad
        private readonly Dictionary<int, List<(int id, string nombre, string direccion)>> _agenciasPorLoc;
        // CDs por provincia
        private readonly Dictionary<int, List<(int id, string nombre, string direccion)>> _cdsPorProv;

        // correlativo por CD origen
        private static readonly Dictionary<int, int> _seqPorCDOrigen = new();

        public ImponerEncomiendaCentroDistribucionModelo()
        {
            // Localidades por provincia
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

            // Agencias por localidad
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

            // CDs por provincia
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
        }

        // 2) CONSULTAS Y HELPERS PARA LA UI

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

        // 3) CREACION DE LA GUIA

        private static EntregaEnum MapEntregaEnum(string tipoEntrega)
        {
            if (string.Equals(tipoEntrega, "A domicilio", StringComparison.OrdinalIgnoreCase)) return EntregaEnum.Domicilio;
            if (string.Equals(tipoEntrega, "En Agencia", StringComparison.OrdinalIgnoreCase)) return EntregaEnum.Agencia;
            return EntregaEnum.CD;
        }

        private static TamanoEnum MapTamanoEnum(int s, int m, int l, int xl)
        {
            if (s == 1) return TamanoEnum.S;
            if (m == 1) return TamanoEnum.M;
            if (l == 1) return TamanoEnum.L;
            return TamanoEnum.XL;
        }

        // Calcular importe de la guia según convenio del cliente
        private static decimal CalcularImporteDesdeConvenio(string cuitCliente, TamanoEnum tamano)
        {
            var digits = new string((cuitCliente ?? string.Empty).Where(char.IsDigit).ToArray());
            var convenio = ConvenioClienteAlmacen.convenioClientes
                .FirstOrDefault(c => new string((c.CUITCliente ?? string.Empty).Where(char.IsDigit).ToArray()) == digits);

            var tarifa = convenio?.TarifasPorOrigenDestino?.FirstOrDefault();
            if (tarifa?.PreciosXTamano == null) return 0m;
            return tarifa.PreciosXTamano.TryGetValue(tamano, out var precio) ? precio : 0m;
        }

        // Inicializa correlativo desde almacén
        private static void EnsureSeqForCD(int cpCD)
        {
            if (_seqPorCDOrigen.ContainsKey(cpCD)) return;
            int maxSeq = 0;
            foreach (var g in GuiaAlmacen.guias)
            {
                if (!string.IsNullOrWhiteSpace(g.IDAgenciaOrigen)) continue; // solo CD
                if (g.CodigoPostalCDOrigen != cpCD) continue;
                var s = g.NumeroGuia.ToString("D9");
                if (s.Length >= 9 && int.TryParse(s[^5..], out var seq))
                    if (seq > maxSeq) maxSeq = seq;
            }
            _seqPorCDOrigen[cpCD] = maxSeq;
        }

        // Numeración: prefijo del CD + correlativo de 5 dígitos
        private static string NextGuiaCodeCD(int cpCDOrigen)
        {
            EnsureSeqForCD(cpCDOrigen);
            _seqPorCDOrigen[cpCDOrigen] = _seqPorCDOrigen[cpCDOrigen] + 1;
            return $"{cpCDOrigen:D4}{_seqPorCDOrigen[cpCDOrigen]:D5}";
        }

        // Crea GuiaEntidad, devuelve número y tamaño, y persiste
        public List<(string numero, TamanoEnum tamano)> ConfirmarImposicion(
            string cuitRemitente,
            string destNombre, string destApellido, string destDni,
            int provinciaId, string provinciaNombre,
            int? localidadId, string? localidadNombre, bool localidadEsOtras,
            string tipoEntrega,
            string? direccion, string? codigoPostal,
            int? agenciaId, string? agenciaNombre,
            int? cdDestinoId, string? cdDestinoNombre,
            int cantS, int cantM, int cantL, int cantXL
        )
        {
            var cli = BuscarCliente(cuitRemitente);
            if (cli is null)
            { MessageBox.Show("CUIT inexistente.", "Validación"); return new List<(string, TamanoEnum)>(); }

            // Convenio y CUIT del cliente
            var cuitDigits = Digits(cuitRemitente);
            var clienteEntidad = ClienteAlmacen.clientes.FirstOrDefault(e => Digits(e.CUIT) == cuitDigits);
            int idConvenio = clienteEntidad?.IDConvenio ?? 0;
            string cuitParaGuia = clienteEntidad?.CUIT ?? cli.Cuit;

            var creadas = new List<(string, TamanoEnum)>();


            int cpOrigen = 0;
            var cdActual = CentroDeDistribucionAlmacen.CentroDistribucionActual;
            var nombreCd = cdActual?.Nombre ?? string.Empty;
            if (cdActual != null && !string.Equals(nombreCd, "No aplica", StringComparison.OrdinalIgnoreCase))
            {
                cpOrigen = cdActual.CodigoPostal;
            }
            else if (_cdsPorProv.TryGetValue(provinciaId, out var cdsProv) && cdsProv.Count > 0)
            {
                cpOrigen = cdsProv[0].id;
            }

            // Destino
            int CodigoPostalDestino()
            {
                if (string.Equals(tipoEntrega, "En CD", StringComparison.OrdinalIgnoreCase) && cdDestinoId.HasValue)
                    return cdDestinoId.Value;
                return provinciaId;
            }

            // Buscar tarifa exacta (solo origen/destino)
            var convenio = ConvenioClienteAlmacen.convenioClientes.FirstOrDefault(c => c.CUITCliente == cuitParaGuia);
            var tarifaOrigenDestino = convenio?.TarifasPorOrigenDestino
                .FirstOrDefault(t => t.CodigoPostalOrigen == cpOrigen && t.CodigoPostalDestino == CodigoPostalDestino());
            if (tarifaOrigenDestino == null)
            {
                MessageBox.Show($"No se encontró tarifa para Origen: {cpOrigen}, Destino: {CodigoPostalDestino()}", "Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new List<(string numero, TamanoEnum tamano)>();
            }

            string IdAgenciaDestinoStr()
            {
                if (!string.Equals(tipoEntrega, "En Agencia", StringComparison.OrdinalIgnoreCase) || !agenciaId.HasValue)
                    return string.Empty;
                return agenciaId.Value.ToString("D4");
            }

            string NextNumero() => NextGuiaCodeCD(cpOrigen);

            void CrearYAgregar(int s, int m, int l, int xl)
            {
                var numeroStr = NextNumero();
                var numeroInt = int.Parse(numeroStr);
                var tam = MapTamanoEnum(s, m, l, xl);

                tarifaOrigenDestino.PreciosXTamano.TryGetValue(tam, out var importe);

                var ge = new GuiaEntidad
                {
                    NumeroGuia = numeroInt,
                    Estado = EstadoGuiaEnum.Admitida,
                    FechaAdmision = DateTime.Now,
                    TipoEntrega = MapEntregaEnum(tipoEntrega),
                    CodigoPostalCDOrigen = cpOrigen,
                    CodigoPostalCDDestino = CodigoPostalDestino(),
                    IDAgenciaOrigen = string.Empty,
                    IDAgenciaDestino = IdAgenciaDestinoStr(),
                    CUITCliente = cuitParaGuia,
                    Tamano = tam,
                    Destinatario = new DestinatarioAux
                    {
                        DNI = int.TryParse(destDni, out var dniInt) ? dniInt : 0,
                        Nombre = destNombre,
                        Apellido = destApellido,
                        Direccion = direccion ?? string.Empty,
                        CodigoPostal = int.TryParse(codigoPostal, out var cpInt)
                                        ? cpInt
                                        : (localidadId ?? CodigoPostalDestino())
                    },
                    IDConvenio = idConvenio,
                    ImporteAFacturar = importe,
                    ComisionAgenciaOrigen = 0,
                    ComisionAgenciaDestino = 0,
                    ComisionFleteroOrigen = 0,
                    ComisionFleteroDestino = 0,
                    Historial = new List<RegistroEstadoAux>
                    {
                        new RegistroEstadoAux
                        {
                            Estado = EstadoGuiaEnum.Admitida,
                            UbicacionGuia = CentroDeDistribucionAlmacen.CentroDistribucionActual?.Nombre ?? string.Empty,
                            FechaActualizacionEstado = DateTime.Now
                        }
                    }
                };

                GuiaAlmacen.guias.Add(ge);
                creadas.Add((numeroStr, tam));
            }

            for (int i = 0; i < cantS; i++) CrearYAgregar(1, 0, 0, 0);
            for (int i = 0; i < cantM; i++) CrearYAgregar(0, 1, 0, 0);
            for (int i = 0; i < cantL; i++) CrearYAgregar(0, 0, 1, 0);
            for (int i = 0; i < cantXL; i++) CrearYAgregar(0, 0, 0, 1);


            return creadas; 
        }
    }
}
