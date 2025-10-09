using System;
using System.Collections.Generic;
using System.Linq;

namespace TUTASAPrototipo.ImponerEncomiendaCD
{
    public class ImponerEncomiendaCentroDistribucionModelo
    {
        // ---------- DATOS DE PRUEBA (en memoria) ----------
        // Clientes
        private readonly List<Cliente> _clientes = new()
        {
            new Cliente { Cuit="30-12345678-1", Nombre="Distribuidora Sur", Telefono="1122334455", Direccion="Av. Siempre Viva 742, CABA" },
            new Cliente { Cuit="20-11111111-2", Nombre="Mayorista Norte",   Telefono="1144556677", Direccion="San Martín 1200, La Plata" }
        };


        // Provincias con CD: Id -> Nombre
        private readonly Dictionary<int, string> _provincias = new()
        {
            { 1, "CABA" },
            { 2, "Buenos Aires" },
            { 3, "Córdoba" },
            { 4, "Santa Fe" },
            { 5, "Tucumán" },
            { 6, "Corrientes" },
            { 7, "Neuquén" },
            { 8, "Río Negro" },
            { 9, "Mendoza" }
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

        // Agencias por Localidad: (id, nombre, direccion)
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

        // CDs por Provincia: (id, nombre, direccion)
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

        // Secuencia de guías
        private static int _seq = 100000;

        // Genera el próximo número de guía (ej: G-2025-100123)
        private static string NextGuiaNumber() => $"G-{DateTime.Now:yyyy}-{_seq++:000000}";

        // ---------- API DEL MODELO (usada por el Form) ----------
        private static string Digits(string s) => new string(s.Where(char.IsDigit).ToArray());


        // Mapas LLL (id interno -> código de 3 dígitos)
        private readonly Dictionary<int, int> _codigoCD3 = new()
        {
            { 9001, 001 }, { 9002, 002 }, { 9101, 010 }, { 9102, 011 }, { 9201, 040 },
            { 9301, 050 }, { 9401, 060 }, { 9501, 070 }, { 9601, 080 }, { 9701, 090 },
            { 9801, 100 }, { 9901, 110 }
        };

        private readonly Dictionary<int, int> _codigoAgencia3 = new()
        {
            { 5001, 010 }, { 5002, 011 }, { 5101, 020 }, { 5102, 021 }, { 5103, 022 },
            { 5201, 040 }, { 5202, 041 }, { 5301, 050 }, { 5302, 051 }, { 5401, 060 },
            { 5501, 070 }, { 5601, 080 }, { 5701, 090 }, { 5801, 100 }, { 5802, 101 },
            { 5104, 023 }, { 5105, 024 }, { 5203, 042 }, { 5303, 052 }, { 5402, 061 },
            { 5502, 071 }, { 5602, 081 }, { 5702, 091 }, { 5106, 025 }
        };

        // Secuencia por establecimiento (T+LLL) para guías
        private static readonly Dictionary<string, int> _seqPorUbicacion = new();
        // Genera código de guía: T(1=CD/0=Agencia) + LLL + NNNNN
        private static string NextGuiaCode(bool esCD, int codigo3)
        {
            var t = esCD ? '1' : '0';
            var key = $"{t}{codigo3:D3}";
            _seqPorUbicacion[key] = _seqPorUbicacion.TryGetValue(key, out var s) ? s + 1 : 1;
            return $"{t}{codigo3:D3}{_seqPorUbicacion[key]:D5}";
        }


        public Cliente? BuscarCliente(string cuit)
        {
            var digits = Digits(cuit);
            return _clientes.FirstOrDefault(c => Digits(c.Cuit) == digits);
        }


        public IEnumerable<KeyValuePair<int, string>> GetProvincias()
            => _provincias; // Key=Id, Value=Nombre

        // Devuelve las localidades de la provincia + la opción "Otras" con id = -1
        public IEnumerable<(int id, string nombre, bool tieneAgencia)> GetLocalidades(int provinciaId)
        {
            var list = _localidadesPorProv.TryGetValue(provinciaId, out var locs) ? new List<(int, string, bool)>(locs) : new();
            list.Add((-1, "Otras", false)); // “Otras” no tiene agencia
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


        // Confirmar imposición: aplica validaciones N3/N4 y crea la Guía
        public List<Guia> ConfirmarImposicion(
            // remitente
            string cuitRemitente,
            // destinatario
            string destNombre, string destApellido, string destDni,
            // ámbito
            int provinciaId, string provinciaNombre,
            int? localidadId, string? localidadNombre, bool localidadEsOtras,
            // entrega
            TipoEntrega tipoEntrega,
            string? direccion, string? codigoPostal,
            int? agenciaId, string? agenciaNombre,
            int? cdDestinoId, string? cdDestinoNombre,
            // bultos
            int cantS, int cantM, int cantL, int cantXL,
            // CD Origen (opcional)
            int cdOrigenId = 0, string cdOrigenNombre = ""
        )
        {
            // ----- Validaciones N3/N4 -----
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
                case TipoEntrega.Domicilio:
                    if (string.IsNullOrWhiteSpace(direccion) || string.IsNullOrWhiteSpace(codigoPostal))
                        throw new InvalidOperationException("Para entrega a Domicilio debe completar Dirección y Código Postal.");
                    break;

                case TipoEntrega.Agencia:
                    if (!agenciaId.HasValue)
                        throw new InvalidOperationException("Debe seleccionar una Agencia.");
                    var agOk = localidadId.HasValue
                               && _agenciasPorLoc.TryGetValue(localidadId.Value, out var ags)
                               && ags.Any(a => a.id == agenciaId.Value);
                    if (!agOk) throw new InvalidOperationException("La agencia no pertenece a la localidad seleccionada.");
                    break;

                case TipoEntrega.CD:
                    if (!cdDestinoId.HasValue)
                        throw new InvalidOperationException("Debe seleccionar un Centro de Distribución (destino).");
                    var cdOk = _cdsPorProv.TryGetValue(provinciaId, out var cds)
                               && cds.Any(c => c.id == cdDestinoId.Value);
                    if (!cdOk) throw new InvalidOperationException("El CD seleccionado no pertenece a la provincia.");
                    break;
            }

            // ----- Crear N guías (UNA POR BULTO) -----
            var guias = new List<Guia>();

            void AgregarGuia(int s, int m, int l, int xl)
            {
                // si no llega un cdOrigenId válido, elegimos el primer CD de la provincia como fallback
                int lll = _codigoCD3.TryGetValue(cdOrigenId, out var code3)
                          ? code3
                          : (_cdsPorProv.TryGetValue(provinciaId, out var cdsProv) && cdsProv.Count > 0
                                ? (_codigoCD3.TryGetValue(cdsProv[0].id, out var c3) ? c3 : 1)
                                : 1);

                var numero = NextGuiaCode(esCD: true, codigo3: lll);

                guias.Add(new Guia
                {
                    Numero = numero,
                    Estado = EstadoGuia.AdmitidaEnCDOrigen,
                    CuitRemitente = Digits(cuitRemitente), // ← tu helper "Digits" ya creado
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

                    // esta guía representa 1 solo bulto de una talla
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

        // ¿La localidad tiene agencia? (según provincia y localidad)
        public bool LocalidadTieneAgencia(int provinciaId, int localidadId)
        {
            if (localidadId == -1) return false; // "Otras"
            return _localidadesPorProv.TryGetValue(provinciaId, out var locs)
                   && locs.Any(l => l.id == localidadId && l.tieneAgencia);
        }

        // Tipos de entrega disponibles para la selección actual
        public string[] GetTiposEntregaDisponibles(int provinciaId, int localidadId)
        {
            // Si el usuario eligió "Otras" (sin CD ni Agencia), SOLO a domicilio
            if (localidadId == -1) return new[] { "A domicilio" };

            var tipos = new List<string> { "A domicilio" };

            // ¿Hay agencias en esa localidad?
            if (LocalidadTieneAgencia(provinciaId, localidadId)
                && _agenciasPorLoc.TryGetValue(localidadId, out var ags)
                && ags.Count > 0)
            {
                tipos.Add("En Agencia");
            }

            // ¿La provincia tiene al menos un CD disponible como destino?
            if (_cdsPorProv.TryGetValue(provinciaId, out var cds) && cds.Count > 0)
            {
                tipos.Add("En CD");
            }

            return tipos.ToArray();
        }


        // --- Helpers de consulta (públicos) ---

        public int? GetCDIdPorNombre(string nombreCD)
        {
            if (string.IsNullOrWhiteSpace(nombreCD)) return null;

            // Busco en todos los CDs cargados (de todas las provincias)
            var cd = _cdsPorProv
                .Values                         // IEnumerable<List<(id, nombre, dir)>>
                .SelectMany(v => v)             // a IEnumerable<(id, nombre, dir)>
                .FirstOrDefault(c =>
                    string.Equals(c.nombre?.Trim(), nombreCD.Trim(),
                                  StringComparison.OrdinalIgnoreCase));

            return cd.id != 0 ? cd.id : (int?)null;
        }

    }
}
