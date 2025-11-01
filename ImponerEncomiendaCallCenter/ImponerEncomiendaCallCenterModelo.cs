// Modelo 

using System;
using System.Collections.Generic;
using System.Linq;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.ImponerEncomiendaCallCenter
{
 public class ImponerEncomiendaCallCenterModelo
 {
 // ---------- DATOS DE PRUEBA ----------
 private readonly Dictionary<int, string> _provincias = new()
 {
 {1, "CABA" }, {2, "Buenos Aires" }, {3, "Córdoba" }, {4, "Santa Fe" },
 {5, "Tucumán" }, {6, "Corrientes" }, {7, "Neuquén" }, {8, "Río Negro" }, {9, "Mendoza" }
 };

 private readonly Dictionary<int, List<(int id, string nombre, bool tieneAgencia)>> _localidadesPorProv = new()
 {
 {1, new() { (101,"CABA", true) } },
 {2, new() { (201,"La Plata", true), (202,"Mar del Plata", true), (203,"Bahía Blanca", true), (1001,"San Isidro", true), (1002,"Quilmes", true), (1003,"Pilar", true) } },
 {3, new() { (301,"Río Cuarto", true), (302,"Córdoba Capital", true), (303,"Villa Allende", true) } },
 {4, new() { (401,"Rosario", true), (402,"Funes", true) } },
 {5, new() { (501,"San Miguel de Tucumán", true), (502,"Yerba Buena", true) } },
 {6, new() { (601,"Corrientes", true), (602,"Goya", true) } },
 {7, new() { (701,"Neuquén", true), (702,"Plottier", true) } },
 {8, new() { (801,"Viedma", true), (802,"San Antonio Oeste", true) } },
 {9, new() { (901,"Mendoza", true), (902,"Godoy Cruz", true) } }
 };

 private readonly Dictionary<int, List<(int id, string nombre, string direccion)>> _agenciasPorLoc = new()
 {
 {101, new() { (5001,"Agencia CABA Centro","Av. Corrientes1000"), (5002,"Agencia CABA Flores","Av. Rivadavia7100") } },
 {201, new() { (5101,"Agencia La Plata","Calle8123"), (5104,"Agencia Quilmes","Av. Calchaquí3950"), (5106,"Agencia San Isidro","Av. Centenario1100"), (5105,"Agencia Pilar","Panamericana Km50") } },
 {202, new() { (5102,"Agencia Mar del Plata","Av. Colón5000") } },
 {203, new() { (5103,"Agencia Bahía Blanca Centro","Av. Alem100") } },
 {301, new() { (5201,"Agencia Nueva Córdoba","Bv. Chacabuco1050") } },
 {302, new() { (5202,"Agencia Córdoba Norte","Av. P. Cabrera5000") } },
 {303, new() { (5203,"Agencia Villa Allende","Av. Goycochea50") } },
 {401, new() { (5301,"Agencia Rosario Centro","Córdoba1400"), (5302,"Agencia Rosario Norte","Bv. Rondeau2500") } },
 {402, new() { (5303,"Agencia Funes","San José1200") } },
 {501, new() { (5401,"Agencia Tucumán Centro","24 de Septiembre500"), (5402,"Agencia Yerba Buena","Av. Aconquija1500") } },
 {601, new() { (5501,"Agencia Corrientes Centro","Junín850") } },
 {602, new() { (5502,"Agencia Goya","Colón850") } },
 {701, new() { (5601,"Agencia Neuquén Centro","Av. Argentina1200"), (5602,"Agencia Plottier","San Martín300") } },
 {801, new() { (5701,"Agencia Viedma Centro","25 de Mayo400") } },
 {802, new() { (5702,"Agencia San Antonio Oeste","Mitre200") } },
 {901, new() { (5801,"Agencia Mendoza Centro","Av. San Martín1200") } },
 {902, new() { (5802,"Agencia Godoy Cruz","San Martín Sur1800") } }
 };

 private readonly Dictionary<int, List<(int id, string nombre, string direccion)>> _cdsPorProv = new()
 {
 {1, new() { (9001,"CD CABA Oeste","Av. Warnes200"), (9002,"CD CABA Sur","Av. Rondeau300") } },
 {2, new() { (9101,"CD Buenos Aires – La Plata","Av.520 y25"), (9102,"CD Buenos Aires – Mar del Plata","Av. J. B. Justo9000"), (9901,"CD Bahía Blanca","Drago1900") } },
 {3, new() { (9201,"CD Córdoba Capital","Av. Sabattini3000") } },
 {4, new() { (9301,"CD Rosario","Cafferata702") } },
 {5, new() { (9401,"CD San Miguel de Tucumán","Av. Brígido Terán250") } },
 {6, new() { (9501,"CD Corrientes","Av. Maipú2700") } },
 {7, new() { (9601,"CD Neuquén","Anaya3005") } },
 {8, new() { (9701,"CD Viedma","Av. F. de Viedma1400") } },
 {9, new() { (9801,"CD Mendoza Capital","Acceso Este y Costanera") } }
 };

 private readonly Dictionary<int, int> _codigoCD3 = new()
 {
 {9001,001 }, {9002,002 }, {9101,010 }, {9102,011 }, {9201,040 },
 {9301,050 }, {9401,060 }, {9501,070 }, {9601,080 }, {9701,090 },
 {9801,100 }, {9901,110 }
 };

 private static readonly Dictionary<string, int> _seqPorUbicacion = new();
 private static string Digits(string s) => new string(s.Where(char.IsDigit).ToArray());

 private static readonly Dictionary<int, int> _seqPorOrigen = new();

 private static int NextGuiaCode(bool esCD, int codigo3)
 {
 int codigo4 = esCD ? codigo3 : (1000 + codigo3);
 _seqPorOrigen[codigo4] = _seqPorOrigen.TryGetValue(codigo4, out var s) ? s +1 :1;
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
 && ags.Count >0)
 { tipos.Add("En Agencia"); }

 if (_cdsPorProv.TryGetValue(provinciaId, out var cds) && cds.Count >0)
 { tipos.Add("En CD"); }

 return tipos.ToArray();
 }

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
 int cdOrigenId =0, string cdOrigenNombre = ""
 )
 {
 var cli = BuscarCliente(cuitRemitente);
 if (cli is null) throw new InvalidOperationException("CUIT inexistente.");

 if ((cantS + cantM + cantL + cantXL) ==0)
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

 LocalidadEntidad CrearLocalidad(int provId, int locId, string locNombre)
 {
 var provincia = (ProvinciaEnumeracion)Enum.Parse(typeof(ProvinciaEnumeracion), _provincias[provId].Replace(" ", ""));
 return new LocalidadEntidad { Id = locId, Nombre = locNombre, Provincia = provincia };
 }

 var localidadDestino = localidadId.HasValue ? CrearLocalidad(provinciaId, localidadId.Value, localidadNombre) : null;

 void AgregarGuia(TamanoEnumeracion tamano)
 {
 int lll = _codigoCD3.TryGetValue(cdOrigenId, out var code3)
 ? code3
 : (_cdsPorProv.TryGetValue(provinciaId, out var cdsProv) && cdsProv.Count >0
 ? (_codigoCD3.TryGetValue(cdsProv[0].id, out var c3) ? c3 :1)
 :1);

 var numero = NextGuiaCode(esCD: true, codigo3: lll);

 var guia = new GuiaEntidad
 {
 Numero = numero,
 Estado = EstadoGuiaEnum.ARetirarPorDomicilioDelCliente,
 Ubicacion = cli.Direccion,
 FechaAdmision = DateTime.Now,
 Entrega = entrega,
 SolicitaRetiro = true, // Call center siempre solicita retiro
 AgenciaOrigen = null, // Se define en la recolección
 CentroDistribucionOrigen = null, // Se define en la recolección
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
 CodigoPostal = !string.IsNullOrEmpty(codigoPostal) ? int.Parse(codigoPostal) :0
 },
 Tarifa = new TarifaBase() // Tarifa de ejemplo
 };
 guias.Add(guia);
 }

 for (int i =0; i < cantS; i++) AgregarGuia(TamanoEnumeracion.S);
 for (int i =0; i < cantM; i++) AgregarGuia(TamanoEnumeracion.M);
 for (int i =0; i < cantL; i++) AgregarGuia(TamanoEnumeracion.L);
 for (int i =0; i < cantXL; i++) AgregarGuia(TamanoEnumeracion.XL);

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

 return cd.id !=0 ? cd.id : (int?)null;
 }
 }
}
