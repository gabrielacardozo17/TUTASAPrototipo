// Modelo 

using System;
using System.Collections.Generic;
using System.Linq;
// NUEVO: linkeo a almacenes (JSON cargados por las clases estáticas)
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.ImponerEncomiendaCallCenter
{
    public class ImponerEncomiendaCallCenterModelo
    {
        /* Datos de prueba comentados: ver bloque original al inicio si se quiere volver */

        // LINQ desde almacenes (activo)
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

        private readonly Dictionary<int, List<(int id, string nombre, bool tieneAgencia)>> _localidadesPorProv;
        private readonly Dictionary<int, List<(int id, string nombre, string direccion)>> _agenciasPorLoc;
        private readonly Dictionary<int, List<(int id, string nombre, string direccion)>> _cdsPorProv;
        private readonly Dictionary<int, int> _codigoCD3;

        private static readonly Dictionary<string, int> _seqPorUbicacion = new();
        private static string Digits(string s) => new string(s.Where(char.IsDigit).ToArray());

        private static string NextGuiaCode(bool esCD, int codigo3)
        {
            var t = esCD ? '0' : '1';
            var key = $"{t}{codigo3:D3}";
            _seqPorUbicacion[key] = _seqPorUbicacion.TryGetValue(key, out var s) ? s + 1 : 1;
            return $"{t}{codigo3:D3}{_seqPorUbicacion[key]:D5}";
        }

        public ImponerEncomiendaCallCenterModelo()
        {
            // Localidades por provincia
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
                    {
                        lista.Add((loc.CodigoPostal, loc.Nombre ?? string.Empty, tieneAgencia));
                    }
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

        public IEnumerable<KeyValuePair<int, string>> GetProvincias() => _provincias.OrderBy(kvp => kvp.Value);

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
            var tipos = new List<string> { "A domicilio" };
            if (localidadId == -1) return tipos.ToArray();

            if (_agenciasPorLoc.TryGetValue(localidadId, out var ags) && ags.Count > 0)
            { tipos.Add("En Agencia"); }

            if (_cdsPorProv.TryGetValue(provinciaId, out var cds) && cds.Count > 0)
            { tipos.Add("En CD"); }

            return tipos.ToArray();
        }

        // Crea guías simples (sin persistencia) como en CD/Agencia
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

            if (!localidadEsOtras && !localidadId.HasValue)
                throw new InvalidOperationException("Seleccioná una Localidad.");

            // Validaciones por tipo de entrega (sin CP)
            if (string.Equals(tipoEntrega, "A domicilio", StringComparison.OrdinalIgnoreCase))
            {
                if (string.IsNullOrWhiteSpace(direccion) || direccion.Trim().Length < 3)
                    throw new InvalidOperationException("Para entrega a Domicilio debe completar Dirección.");
            }
            else if (string.Equals(tipoEntrega, "En Agencia", StringComparison.OrdinalIgnoreCase))
            {
                if (!agenciaId.HasValue)
                    throw new InvalidOperationException("Debe seleccionar una Agencia.");
                var okAg = localidadId.HasValue
                           && _agenciasPorLoc.TryGetValue(localidadId.Value, out var ags)
                           && ags.Any(a => a.id == agenciaId.Value);
                if (!okAg) throw new InvalidOperationException("La agencia no pertenece a la localidad seleccionada.");
            }
            else if (string.Equals(tipoEntrega, "En CD", StringComparison.OrdinalIgnoreCase))
            {
                if (!cdDestinoId.HasValue)
                    throw new InvalidOperationException("Debe seleccionar un Centro de Distribución (destino).");
                var okCd = _cdsPorProv.TryGetValue(provinciaId, out var cds)
                           && cds.Any(c => c.id == cdDestinoId.Value);
                if (!okCd) throw new InvalidOperationException("El CD seleccionado no pertenece a la provincia.");
            }
            else
            {
                throw new InvalidOperationException("Tipo de entrega inválido.");
            }

            var guias = new List<Guia>();
            var cuitDigits = Digits(cuitRemitente);

            void AgregarGuia(int s, int m, int l, int xl)
            {
                // Determinar LLL (si no hay origen informado, usamos el primer CD de la provincia para numeración)
                int lll = _codigoCD3.TryGetValue(cdOrigenId, out var c3)
                          ? c3
                          : (_cdsPorProv.TryGetValue(provinciaId, out var cdsProv) && cdsProv.Count > 0
                                ? (_codigoCD3.TryGetValue(cdsProv[0].id, out var c3alt) ? c3alt : 1)
                                : 1);

                var numero = NextGuiaCode(esCD: true, codigo3: lll);

                guias.Add(new Guia
                {
                    Numero = numero,
                    Estado = string.Equals(tipoEntrega, "A domicilio", StringComparison.OrdinalIgnoreCase)
                                ? "Pendiente de retiro en domicilio"
                                : (string.Equals(tipoEntrega, "En Agencia", StringComparison.OrdinalIgnoreCase)
                                    ? "A retirar en agencia de origen"
                                    : "Pendiente de entrega"),
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
