using System;
using System.Collections.Generic;
using System.Linq;
using TUTASAPrototipo.Domain;

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
            { 1, "CABA" }, { 2, "Buenos Aires" }, { 3, "Córdoba" }
        };

        // Localidades por Provincia: (id, nombre, tieneAgencia)
        private readonly Dictionary<int, List<(int id, string nombre, bool tieneAgencia)>> _localidadesPorProv
            = new()
        {
            { 1, new() { (101,"CABA", true) } }, // CABA tiene agencias
            { 2, new() { (201,"La Plata", true), (202,"Mar del Plata", true) } },
            { 3, new() { (301,"Río Cuarto", true) } }
        };

        // Agencias por Localidad: (id, nombre, direccion)
        private readonly Dictionary<int, List<(int id, string nombre, string direccion)>> _agenciasPorLoc
            = new()
        {
            { 101, new() { (5001, "Agencia CABA Centro", "Av. Corrientes 1000") } },
            { 201, new() { (5101, "Agencia La Plata", "Calle 8 #123") } },
            { 202, new() { (5102, "Agencia MdP", "Av. Colón 5000") } },
            { 301, new() { (5201, "Agencia Río Cuarto", "Belgrano 900") } }
        };

        // CDs por Provincia: (id, nombre, direccion)
        private readonly Dictionary<int, List<(int id, string nombre, string direccion)>> _cdsPorProv
            = new()
        {
            { 1, new() { (9001, "CD CABA Oeste", "Warnes 200"), (9002, "CD CABA Sur", "Rondeau 300") } },
            { 2, new() { (9101, "CD Buenos Aires - La Plata", "520 y 25"), (9102, "CD Buenos Aires - MdP", "Juan B. Justo 9000") } },
            { 3, new() { (9201, "CD Córdoba Capital", "Av. Sabattini 3000") } }
        };

        // Secuencia de guías
        private static int _seq = 100000;

        // ---------- API DEL MODELO (usada por el Form) ----------

        public Cliente? BuscarCliente(string cuit)
        {
            var digits = new string(cuit.Where(char.IsDigit).ToArray());
            return _clientes.FirstOrDefault(c => new string(c.Cuit.Where(char.IsDigit).ToArray()) == digits);
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
            // ----- Validaciones N3/N4 (idénticas a las que ya tenías) -----
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

            // ----- Crear N guías (UNA POR BULT0) -----
            var guias = new List<Guia>();

            void AgregarGuia(int s, int m, int l, int xl)
            {
                var numero = $"G-{DateTime.Now:yyyy}-{_seq++:000000}";
                guias.Add(new Guia
                {
                    Numero = numero,
                    Estado = EstadoGuia.AdmitidaEnCDOrigen,
                    CuitRemitente = new string(cuitRemitente.Where(char.IsDigit).ToArray()),
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

    }
}
