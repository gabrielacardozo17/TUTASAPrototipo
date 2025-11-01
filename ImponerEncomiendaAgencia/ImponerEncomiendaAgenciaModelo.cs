using System;
using System.Collections.Generic;
using System.Linq;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.ImponerEncomiendaAgencia
{
    public class ImponerEncomiendaAgenciaModelo
    {
        // ---------- DATOS DE PRUEBA ----------
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

        // === Origen fijo: Agencia CABA Centro (LLL = 001 => TLLL = 1001) ===
        private const int ORIGEN_AGENCIA_CABA_CENTRO_COD3 = 1;
        // ===================================================================

        // correlativo por origen (TLLL)
        private static readonly Dictionary<int, int> _seqPorOrigen = new();

        private static string Digits(string s) => new string(s.Where(char.IsDigit).ToArray());

        // Genera TLLLNNNNN para AGENCIA ⇒ TLLL = 1000 + LLL
        private static int NextGuiaCode_Agencia(int codigo3)
        {
            int codigo4 = 1000 + codigo3; // 1000–1999 = Agencias
            _seqPorOrigen[codigo4] = _seqPorOrigen.TryGetValue(codigo4, out var s) ? s + 1 : 1;
            //return $"{codigo4:D4}{_seqPorOrigen[codigo4]:D5}";
            return _seqPorOrigen[codigo4];
        }

        public ClienteEntidad? BuscarCliente(string cuit)
        {
            var digits = Digits(cuit);
            return ClienteAlmacen.Clientes.FirstOrDefault(c => Digits(c.CUIT) == digits);
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

        // Confirmar: valida y crea UNA guía por cada bulto
        public List<GuiaEntidad> ConfirmarImposicion(
            string cuitRemitente,
            string destNombre, string destApellido, string destDni, string destTelefono,
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

            AgenciaEntidad agenciaDestino = null;
            CentroDeDistribucionEntidad cdDestino = null;
            EntregaEnum entrega;

            switch (tipoEntrega)
            {
                case "A domicilio":
                    if (string.IsNullOrWhiteSpace(direccion) || string.IsNullOrWhiteSpace(codigoPostal))
                        throw new InvalidOperationException("Para entrega a Domicilio debe completar Dirección y Código Postal.");
                    entrega = EntregaEnum.Domicilio;
                    break;

                case "En Agencia":
                    if (!agenciaId.HasValue)
                        throw new InvalidOperationException("Debe seleccionar una Agencia.");
                    agenciaDestino = AgenciaAlmacen.Agencias.FirstOrDefault(a => a.Id == agenciaId.Value);
                    if (agenciaDestino == null) throw new InvalidOperationException("La agencia seleccionada no es válida.");
                    entrega = EntregaEnum.Agencia;
                    break;

                case "En CD":
                    if (!cdDestinoId.HasValue)
                        throw new InvalidOperationException("Debe seleccionar un Centro de Distribución (destino).");
                    cdDestino = CentroDistribucionAlmacen.CDs.FirstOrDefault(c => c.Id == cdDestinoId.Value);
                    if (cdDestino == null) throw new InvalidOperationException("El CD seleccionado no es válido.");
                    entrega = EntregaEnum.CD;
                    break;
                default:
                    throw new InvalidOperationException("Tipo de entrega inválido.");
            }

            var guias = new List<GuiaEntidad>();

            // Helper para crear la entidad Localidad a partir de los datos de prueba
            LocalidadEntidad CrearLocalidad(int provId, int locId, string locNombre)
            {
                var provincia = (ProvinciaEnumeracion)Enum.Parse(typeof(ProvinciaEnumeracion), _provincias[provId].Replace(" ", ""));
                return new LocalidadEntidad { Id = locId, Nombre = locNombre, Provincia = provincia };
            }

            var localidadDestino = localidadId.HasValue ? CrearLocalidad(provinciaId, localidadId.Value, localidadNombre) : null;

            void AgregarGuia(TamanoEnumeracion tamano)
            {
                int lll = ORIGEN_AGENCIA_CABA_CENTRO_COD3;
                var numero = NextGuiaCode_Agencia(codigo3: lll);

                var agenciaOrigen = AgenciaAlmacen.Agencias.FirstOrDefault(a => a.Id == 5001); // Origen Fijo: Agencia CABA Centro

                var guia = new GuiaEntidad
                {
                    Numero = numero,
                    Estado = EstadoGuiaEnum.Admitida,
                    Ubicacion = agenciaOrigen?.Nombre ?? "Agencia Origen",
                    FechaAdmision = DateTime.Now,
                    Entrega = entrega,
                    SolicitaRetiro = false, // Se impone en agencia
                    AgenciaOrigen = agenciaOrigen,
                    CentroDistribucionOrigen = agenciaOrigen?.CentroDeDistribucion,
                    AgenciaDestino = agenciaDestino,
                    CentroDistribucionDestino = cdDestino ?? agenciaDestino?.CentroDeDistribucion,
                    Cliente = cli,
                    Tamano = tamano,
                    Destinatario = new DestinatarioAux
                    {
                        DNI = int.Parse(destDni),
                        Nombre = destNombre,
                        Apellido = destApellido,
                        Localidad = localidadDestino,
                        Direccion = direccion,
                        CodigoPostal = !string.IsNullOrEmpty(codigoPostal) ? int.Parse(codigoPostal) : 0
                    },
                    Tarifa = new TarifaBase() // Tarifa de ejemplo
                };
                guias.Add(guia);
            }

            for (int i = 0; i < cantS; i++) AgregarGuia(TamanoEnumeracion.S);
            for (int i = 0; i < cantM; i++) AgregarGuia(TamanoEnumeracion.M);
            for (int i = 0; i < cantL; i++) AgregarGuia(TamanoEnumeracion.L);
            for (int i = 0; i < cantXL; i++) AgregarGuia(TamanoEnumeracion.XL);

            // Persistir las nuevas guías
            GuiaAlmacen.Guias.AddRange(guias);
            GuiaAlmacen.Grabar();

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
