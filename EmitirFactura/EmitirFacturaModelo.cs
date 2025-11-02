// TUTASAPrototipo/EmitirFactura/EmitirFacturaModelo.cs (ACTUALIZADO PARA USAR ALMACENES)
using System;
using System.Collections.Generic;
using System.Linq;
using TUTASAPrototipo.Almacenes; // acceso a datos persistidos (archivos JSON)

namespace TUTASAPrototipo.EmitirFactura
{
 public class EmitirFacturaModelo
 {
 /*
 // ---------- DATOS DE PRUEBA (dejados como COMENTARIO) ----------
 // Clientes (agregados algunos más; CUIT con DV válido)
 private readonly List<Cliente> _clientes = new()
 {
 new Cliente { Cuit="30-12345678-1", RazonSocial="Distribuidora Sur S.A.", Convenio="General" },
 new Cliente { Cuit="30-87654321-0", RazonSocial="Mayorista Norte S.R.L.", Convenio="Preferencial" },
 new Cliente { Cuit="33-33445566-7", RazonSocial="Biotec Litoral S.R.L.", Convenio="General" },
 // EXISTENTES
 new Cliente { Cuit="30-10123456-4", RazonSocial="Tecnología Andina S.A.", Convenio="General" },
 new Cliente { Cuit="30-33445566-8", RazonSocial="Editorial Horizonte S.A.", Convenio="General" },
 new Cliente { Cuit="33-12345678-0", RazonSocial="Farmacorp S.A.", Convenio="Preferencial" },
 // NUEVOS
 new Cliente { Cuit="30-22113456-3", RazonSocial="Alimentos Pampeanos S.A.", Convenio="General" },
 new Cliente { Cuit="30-24681357-0", RazonSocial="Logística Patagónica S.A.", Convenio="General" },
 new Cliente { Cuit="33-22113456-2", RazonSocial="Bodega del Sol S.A.", Convenio="Preferencial" },
 new Cliente { Cuit="33-24681357-9", RazonSocial="Casa Central Hogar S.A.", Convenio="General" }
 };

 // Guías (TLLLNNNNN)
 // private readonly List<Guia> _guias = new() { ...datos de prueba... };
 */

 private static int _seqFactura =1; // numerador local simple

 // ---------- HELPERS ----------
 private static string Digits(string s) => new string((s ?? "").Where(char.IsDigit).ToArray());

 // ---------- MÉTODOS ----------
 public (Cliente cliente, List<Guia> guias) BuscarPorCuit(string cuitDigits)
 {
 // Normalizamos a dígitos (la pantalla ya envía solo dígitos, igual reforzamos)
 var digits = Digits(cuitDigits);

 //1) Buscar cliente en almacén
 var cliEntidad = ClienteAlmacen.clientes
 .FirstOrDefault(c => Digits(c.CUIT) == digits);

 if (cliEntidad is null)
 throw new InvalidOperationException("No existe el cliente seleccionado. Vuelva a intentarlo.");

 //2) Guías pendientes del cliente: según CU, solo estado Entregada
 // Tomamos del almacén de guías, filtramos por CUIT y estado
 var pendientesEntidad = GuiaAlmacen.guias
 .Where(g => Digits(g.CUITCliente) == digits)
 .Where(g => g.Estado == EstadoGuiaEnum.Entregada)
 .OrderBy(g => g.FechaAdmision)
 .ToList();

 if (!pendientesEntidad.Any())
 throw new InvalidOperationException("No se encontraron ítems pendientes de facturar.");

 //3) Mapear entidades → clases de pantalla (sin crear métodos nuevos)
 // Origen/Destino: resolvemos nombre de CD o Agencia según datos presentes
 var guiasPantalla = pendientesEntidad
 .Select(g => new Guia
 {
 Numero = g.NumeroGuia.ToString("D9"),
 FechaAdmision = g.FechaAdmision,
 Origen =
 (g.CodigoPostalCDOrigen !=0
 ? (CentroDeDistribucionAlmacen.centrosDeDistribucion
 .FirstOrDefault(cd => cd.CodigoPostal == g.CodigoPostalCDOrigen)?.Nombre ?? $"CD {g.CodigoPostalCDOrigen}")
 : (!string.IsNullOrWhiteSpace(g.IDAgenciaOrigen)
 ? (AgenciaAlmacen.agencias.FirstOrDefault(a => a.ID == g.IDAgenciaOrigen)?.Nombre ?? $"Agencia {g.IDAgenciaOrigen}")
 : "")),
 Destino =
 (g.CodigoPostalCDDestino !=0
 ? (CentroDeDistribucionAlmacen.centrosDeDistribucion
 .FirstOrDefault(cd => cd.CodigoPostal == g.CodigoPostalCDDestino)?.Nombre ?? $"CD {g.CodigoPostalCDDestino}")
 : (!string.IsNullOrWhiteSpace(g.IDAgenciaDestino)
 ? (AgenciaAlmacen.agencias.FirstOrDefault(a => a.ID == g.IDAgenciaDestino)?.Nombre ?? $"Agencia {g.IDAgenciaDestino}")
 : "")),
 Tamano = g.Tamano.ToString(),
 Importe = g.ImporteAFacturar,
 Estado = g.Estado.ToString().Replace("_", " "),
 CuitCliente = cliEntidad.CUIT
 })
 .ToList();

 //4) Devolver cliente mapeado + guías
 var clientePantalla = new Cliente
 {
 Cuit = cliEntidad.CUIT,
 RazonSocial = cliEntidad.RazonSocial,
 Convenio = "General" // sin mapeo de convenios en este modelo
 };

 return (clientePantalla, guiasPantalla);
 }

 public Factura EmitirFactura(string cuitDigits)
 {
 //1) Reutilizar la búsqueda para validar existencia + pendientes
 var (cliente, pendientes) = BuscarPorCuit(cuitDigits);

 //2) Calcular total
 var total = pendientes.Sum(g => g.Importe);
 if (total <=0)
 throw new InvalidOperationException("No es posible emitir una factura por $0.");

 //3) Generar número de factura simple (no persistente)
 var numero = $"FA-{DateTime.Now:yyyyMM}-{_seqFactura++:00000}";

 //4) Registrar factura en almacén (persistencia en archivo JSON)
 var facEntidad = new FacturaEntidad
 {
 ID = numero,
 FechaEmisionFactura = DateTime.Now,
 CUITCliente = cliente.Cuit,
 Total = total,
 GuiasFacturadas = pendientes.Select(p => p.Numero).ToList()
 };
 FacturaAlmacen.facturas.Add(facEntidad);
 FacturaAlmacen.Grabar();

 //5) Registrar movimiento en Cuenta Corriente
 var cc = CuentaCorrienteAlmacen.cuentasCorrientes
 .FirstOrDefault(c => Digits(c.CUITCliente) == Digits(cliente.Cuit));
 if (cc == null)
 {
 cc = new CuentaCorrienteEntidad
 {
 ID = Guid.NewGuid().ToString("N"),
 CUITCliente = cliente.Cuit,
 Movimientos = new List<MovimientoClienteAux>()
 };
 CuentaCorrienteAlmacen.cuentasCorrientes.Add(cc);
 }
 // asegurar lista de movimientos
 cc.Movimientos ??= new List<MovimientoClienteAux>();

 var saldoAnterior = cc.Movimientos.LastOrDefault()?.SaldoActual ??0m;
 var mov = new MovimientoClienteAux
 {
 IDFactura = Math.Abs(numero.GetHashCode()), // entero derivado del número
 Fecha = DateTime.Now,
 Concepto = $"Factura {numero}",
 Debe = total,
 Haber =0m,
 SaldoActual = saldoAnterior + total
 };
 cc.Movimientos.Add(mov);
 CuentaCorrienteAlmacen.Grabar();

 //6) Marcar las guías como Facturadas en el almacén (si existe esa transición)
 foreach (var p in pendientes)
 {
 var num = int.Parse(p.Numero);
 var guia = GuiaAlmacen.guias.FirstOrDefault(g => g.NumeroGuia == num);
 if (guia != null)
 {
 guia.Estado = EstadoGuiaEnum.Facturada;
 }
 }
 GuiaAlmacen.Grabar();

 //7) Devolver factura en el formato que espera la pantalla
 var facPantalla = new Factura
 {
 Numero = numero,
 Fecha = facEntidad.FechaEmisionFactura,
 Cliente = cliente,
 GuiasFacturadas = pendientes
 };

 return facPantalla;
 }
 }
}
