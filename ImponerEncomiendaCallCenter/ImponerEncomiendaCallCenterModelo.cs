// Modelo 

using System;
using System.Collections.Generic;
using System.Linq;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.ImponerEncomiendaCallCenter
{
    public class ImponerEncomiendaCallCenterModelo
    {
        // =============================================================
        // 1) DATOS TRAIDOS DESDE ALMACENES (LINQ y caches)
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

        public ImponerEncomiendaCallCenterModelo()
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

            // CDs por provincia (clave = CP del CD) (LINQ)
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
        // 2) CONSULTAS Y HELPERS PARA LA UI
        // =============================================================

        public Cliente BuscarCliente(string cuit)
        {
            var digits = Digits(cuit);
            var cliente = _clientes.FirstOrDefault(c => Digits(c.Cuit) == digits);
            if (cliente is null)
                throw new InvalidOperationException("CUIT inexistente.");
            return cliente;
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

        public int? GetCDIdPorNombre(string nombreCD)
        {
            if (string.IsNullOrWhiteSpace(nombreCD)) return null;

            var cd = _cdsPorProv.Values
                .SelectMany(v => v)
                .FirstOrDefault(c => string.Equals(c.nombre?.Trim(), nombreCD.Trim(), StringComparison.OrdinalIgnoreCase));

            return cd.id != 0 ? cd.id : (int?)null;
        }

        // =============================================================
        // 3) CREACION DE LA GUIA (mapeos, numeración y persistencia)
        // =============================================================

        // Mapeos
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

        // Numeración (CD: prefijo de 4 dígitos = CP del CD; correlativo 5 dígitos)
        private static readonly Dictionary<int, int> _seqPorOrigen = new();
        private static string NextGuiaCodeCD(int cpCD)
        {
            int prefijo4 = cpCD; // 4 dígitos del CD
            _seqPorOrigen[prefijo4] = _seqPorOrigen.TryGetValue(prefijo4, out var s) ? s + 1 : 1;
            return $"{prefijo4:D4}{_seqPorOrigen[prefijo4]:D5}";
        }

        // Devuelve datos mínimos para UI (número 4+5 y tamaño), creando sólo GuiaEntidad y grabando JSON.
        public List<(string numero, TamanoEnum tamano)> ConfirmarImposicion(
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
            // Validaciones contra almacenes en el modelo
            var cli = BuscarCliente(cuitRemitente); // lanza si no existe

            var creadas = new List<(string, TamanoEnum)>();
            var cuitDigits = Digits(cuitRemitente);

            // Determinar CD de origen como el CD en la misma provincia que el cliente
            int cpCliente = ClienteAlmacen.clientes.FirstOrDefault(e => Digits(e.CUIT) == cuitDigits)?.CodigoPostal ?? 0;
            int cpCDOrigen = 0;
            var locCliente = LocalidadAlmacen.localidades.FirstOrDefault(l => l.CodigoPostal == cpCliente);
            if (locCliente != null)
            {
                var provCli = locCliente.Provincia;
                var cdProv = CentroDeDistribucionAlmacen.centrosDeDistribucion.FirstOrDefault(cd =>
                {
                    var locCd = LocalidadAlmacen.localidades.FirstOrDefault(l => l.CodigoPostal == cd.CodigoPostal);
                    return locCd != null && locCd.Provincia.Equals(provCli);
                });
                cpCDOrigen = cdProv?.CodigoPostal ?? 0;
            }
            if (cpCDOrigen == 0 && _cdsPorProv.TryGetValue(provinciaId, out var cdsProv) && cdsProv.Count > 0)
            {
                cpCDOrigen = cdsProv[0].id; // fallback a CD de la provincia seleccionada
            }

            // Destino CD
            int CodigoPostalDestino()
            {
                if (string.Equals(tipoEntrega, "En CD", StringComparison.OrdinalIgnoreCase) && cdDestinoId.HasValue)
                    return cdDestinoId.Value;
                return provinciaId; // para agencia/domicilio usamos CP del CD de la provincia destino
            }

            // Generador de número de guía CD (prefijo 4 + correlativo 5)
            string NextNumero() => NextGuiaCodeCD(cpCDOrigen);

            // Obtener cliente de almacén para IDConvenio y CUIT
            var clienteEntidad = ClienteAlmacen.clientes.FirstOrDefault(e => Digits(e.CUIT) == cuitDigits);
            int idConvenio = clienteEntidad?.IDConvenio ?? 0;
            string cuitParaGuia = clienteEntidad?.CUIT ?? cli.Cuit;

            // IDAgenciaDestino: cuando es "En Agencia" debe ser CP (4 dígitos)
            string IdAgenciaDestinoStr()
            {
                if (!string.Equals(tipoEntrega, "En Agencia", StringComparison.OrdinalIgnoreCase) || !agenciaId.HasValue)
                    return string.Empty;
                return agenciaId.Value.ToString("D4");
            }

            void CrearYAgregar(int s, int m, int l, int xl)
            {
                var numeroStr = NextNumero();
                var numeroInt = int.Parse(numeroStr);
                var tam = MapTamanoEnum(s, m, l, xl);

                var ge = new GuiaEntidad
                {
                    NumeroGuia = numeroInt,
                    Estado = EstadoGuiaEnum.ARetirarPorDomicilioDelCliente,
                    FechaAdmision = DateTime.Now,
                    TipoEntrega = MapEntregaEnum(tipoEntrega),
                    CodigoPostalCDOrigen = cpCDOrigen,
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
                    ImporteAFacturar = 0,
                    ComisionAgenciaOrigen = 0,
                    ComisionAgenciaDestino = 0,
                    ComisionFleteroOrigen = 0,
                    ComisionFleteroDestino = 0,
                    Historial = new List<RegistroEstadoAux>
                    {
                        new RegistroEstadoAux
                        {
                            Estado = EstadoGuiaEnum.ARetirarPorDomicilioDelCliente,
                            UbicacionGuia = string.Empty,
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

            // Persistir JSON
            GuiaAlmacen.Grabar();

            return creadas;
        }
    }
}
