using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.ImponerEncomiendaCD
{
    public class ImponerEncomiendaCentroDistribucionModelo
    {
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

        public List<KeyValuePair<int, string>> GetProvincias() =>
            _provincias
                .OrderBy(kv => kv.Value, StringComparer.CurrentCulture)
                .ToList();

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

        // Importe = base por tamaño (tarifa exacta origen/destino) + extra según tipo de entrega
        private static decimal CalcularImporteDesdeConvenio(string cuitCliente, TamanoEnum tamano, EntregaEnum entrega, int cpOrigen, int cpDestino)
        {
            string Dig(string s) => new string((s ?? string.Empty).Where(char.IsDigit).ToArray());
            var convenio = ConvenioClienteAlmacen.convenioClientes
                .FirstOrDefault(c => Dig(c.CUITCliente) == Dig(cuitCliente));

            var tarifa = convenio?.TarifasPorOrigenDestino?
                .FirstOrDefault(t => t.CodigoPostalOrigen == cpOrigen && t.CodigoPostalDestino == cpDestino);

            decimal basePrecio = 0m;
            if (tarifa?.PreciosXTamano != null)
                tarifa.PreciosXTamano.TryGetValue(tamano, out basePrecio);

            decimal extra = 0m;
            if (convenio?.Extras != null)
            {
                if (entrega == EntregaEnum.Domicilio && convenio.Extras.TryGetValue(ExtrasEnum.ExtraEntregaDomicilio, out var exDom)) extra = exDom;
                else if (entrega == EntregaEnum.Agencia && convenio.Extras.TryGetValue(ExtrasEnum.ExtraEntregaAgencia, out var exAge)) extra = exAge;
            }
            return basePrecio + extra;
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
                var entrega = MapEntregaEnum(tipoEntrega);
                var importe = CalcularImporteDesdeConvenio(cuitParaGuia, tam, entrega, cpOrigen, CodigoPostalDestino());

                // Comision destino solo si se entrega en agencia: buscar convenio de agencia por CP (agenciaId sin el 0 inicial)
                decimal comisionAgenciaDestino = 0m;
                if (entrega == EntregaEnum.Agencia && agenciaId.HasValue)
                {
                    var convAg = ConvenioAgenciaAlmacen.convenioAgencias
                        .FirstOrDefault(ca => ca.IDConvenioAgencia == agenciaId.Value);
                    if (convAg?.PreciosXTamano != null && convAg.PreciosXTamano.TryGetValue(tam, out var com))
                        comisionAgenciaDestino = com;
                }

                var ge = new GuiaEntidad
                {
                    NumeroGuia = numeroInt,
                    Estado = EstadoGuiaEnum.Admitida,
                    FechaAdmision = DateTime.Now,
                    TipoEntrega = entrega,
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
                        CodigoPostal = int.TryParse(codigoPostal, out var cpInt) ? cpInt : (localidadId ?? CodigoPostalDestino())
                    },
                    IDConvenio = idConvenio,
                    ImporteAFacturar = importe,
                    ComisionAgenciaOrigen = 0,
                    ComisionAgenciaDestino = comisionAgenciaDestino,
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
