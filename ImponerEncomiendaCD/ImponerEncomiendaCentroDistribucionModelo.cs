using System;
using System.Collections.Generic;
using System.Linq;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.ImponerEncomiendaCD
{
    public class ImponerEncomiendaCentroDistribucionModelo
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

        private static readonly Dictionary<string, int> _seqPorUbicacion = new();
        private static string Digits(string s) => new string(s.Where(char.IsDigit).ToArray());

        // === Origen fijo (lo que vas a pasar desde el form): CD Corrientes ===
        private const int ORIGEN_CD_CORRIENTES_ID = 9501;
        private const string ORIGEN_CD_CORRIENTES_NOMBRE = "CD Corrientes";

        // Propiedades para que el form pueda pasar SIEMPRE este origen
        public int OrigenCdFijoId => ORIGEN_CD_CORRIENTES_ID;
        public string OrigenCdFijoNombre => ORIGEN_CD_CORRIENTES_NOMBRE;
        // ====================================================================

        // Nuevo formato: TLLLNNNNN → TLLL = 0001–0999 (CD), 1000+ (Agencia)
        private static readonly Dictionary<int, int> _seqPorOrigen = new();

        private static int NextGuiaCode(bool esCD, int codigo3)
        {
            int codigo4 = esCD ? codigo3 : (1000 + codigo3);
            _seqPorOrigen[codigo4] = _seqPorOrigen.TryGetValue(codigo4, out var s) ? s + 1 : 1;
            return _seqPorOrigen[codigo4];
        }

        // ---------- API ----------
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
            int cdOrigenId, string cdOrigenNombre
        )
        {
            var cliente = ClienteAlmacen.Clientes.FirstOrDefault(c => c.CUIT == cuitRemitente);
            if (cliente == null) throw new Exception("Cliente no encontrado.");

            var cdOrigen = CentroDistribucionAlmacen.CDs.FirstOrDefault(c => c.Id == cdOrigenId);
            if (cdOrigen == null)
            {
                throw new Exception("No se pudo encontrar el CD de origen configurado.");
            }

            var guias = new List<GuiaEntidad>();
            var rand = new Random();

            Action<TamanoEnumeracion, int> crearGuias = (tamano, cantidad) =>
            {
                for (int i = 0; i < cantidad; i++)
                {
                    var nuevaGuia = new GuiaEntidad
                    {
                        Numero = rand.Next(100000, 999999),
                        Estado = EstadoGuiaEnum.Admitida,
                        FechaAdmision = DateTime.Now,
                        Cliente = cliente,
                        Destinatario = new DestinatarioAux
                        {
                            Nombre = destNombre,
                            Apellido = destApellido,
                            DNI = int.Parse(destDni),
                            Localidad = new LocalidadEntidad { Id = localidadId ?? 0, Nombre = localidadNombre ?? "Otras", Provincia = (ProvinciaEnumeracion)provinciaId },
                            Direccion = direccion ?? "",
                            CodigoPostal = int.TryParse(codigoPostal, out var cpInt) ? cpInt : 0
                        },
                        Tamano = tamano,
                        Entrega = (EntregaEnum)Enum.Parse(typeof(EntregaEnum), tipoEntrega, true),
                        AgenciaDestino = agenciaId.HasValue ? new AgenciaEntidad { Id = agenciaId.Value, Nombre = agenciaNombre } : null,
                        CentroDistribucionDestino = cdDestinoId.HasValue ? new CentroDeDistribucionEntidad { Id = cdDestinoId.Value, Nombre = cdDestinoNombre } : null,
                        CentroDistribucionOrigen = cdOrigen,
                        Tarifa = new TarifaBase
                        {
                            PreciosXTamano = new Dictionary<TamanoEnumeracion, decimal> { [tamano] = 100m },
                            CodPostalOrigen = 0,
                            CodPostalDestino = int.TryParse(codigoPostal, out var cp2) ? cp2 : 0
                        }
                    };
                    guias.Add(nuevaGuia);
                    GuiaAlmacen.Guias.Add(nuevaGuia);
                }
            };

            crearGuias(TamanoEnumeracion.S, cantS);
            crearGuias(TamanoEnumeracion.M, cantM);
            crearGuias(TamanoEnumeracion.L, cantL);
            crearGuias(TamanoEnumeracion.XL, cantXL);

            GuiaAlmacen.Grabar();
            return guias;
        }
    }
}
