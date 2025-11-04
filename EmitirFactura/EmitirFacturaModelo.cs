using System;
using System.Collections.Generic;
using System.Linq;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.EmitirFactura
{
    public class EmitirFacturaModelo
    {

        private static int _seqFactura = 1; 

        // ---------- HELPERS ----------
        private static string Digits(string s)
        {
            // Normaliza el CUIT a sus11 dígitos (sin guiones). Antes se tomaban8 del medio.
            // Esto evita falsas no-coincidencias y colisiones.
            return new string((s ?? "").Where(char.IsDigit).ToArray());
        }

        // Formato legible del estado (sin crear clases/archivos nuevos)
        private static string EstadoDisplay(EstadoGuiaEnum estado)
        {
            return estado switch
            {
                EstadoGuiaEnum.ARetirarEnAgenciaDeOrigen => "A retirar en agencia de origen",
                EstadoGuiaEnum.ARetirarPorDomicilioDelCliente => "A retirar por domicilio del cliente",
                EstadoGuiaEnum.EnCaminoARetirarPorDomicilio => "En camino a retirar por domicilio",
                EstadoGuiaEnum.EnCaminoARetirarPorAgencia => "En camino a retirar por agencia",
                EstadoGuiaEnum.EnRutaACDDeOrigenDesdeAgencia => "En ruta a CD de origen (desde agencia)",
                EstadoGuiaEnum.Admitida => "Admitida",
                EstadoGuiaEnum.EnTransitoAlCDDestino => "En tránsito al CD destino",
                EstadoGuiaEnum.EnCDDestino => "En CD destino",
                EstadoGuiaEnum.EnRutaAlDomicilioDeEntrega => "En ruta al domicilio de entrega",
                EstadoGuiaEnum.EnRutaAlaAgenciaDestino => "En ruta a la agencia destino",
                EstadoGuiaEnum.PendienteDeEntrega => "Pendiente de entrega",
                EstadoGuiaEnum.Entregada => "Entregada",
                EstadoGuiaEnum.Cancelada => "Cancelada",
                EstadoGuiaEnum.NoEntregada => "No entregada",
                EstadoGuiaEnum.Facturada => "Facturada",
                _ => InsertarEspaciosEnPascalCase(estado.ToString())
            };
        }

        private static string InsertarEspaciosEnPascalCase(string name)
        {
            if (string.IsNullOrEmpty(name)) return name;
            var sb = new System.Text.StringBuilder(name.Length * 2);
            for (int i = 0; i < name.Length; i++)
            {
                var c = name[i];
                if (i > 0 && char.IsUpper(c) && char.IsLower(name[i - 1]))
                    sb.Append(' ');
                sb.Append(c);
            }
            return sb.ToString();
        }

        // ---------- MÉTODOS ----------
        public (Cliente cliente, List<Guia> guias) BuscarPorCuit(string cuitDigits)
        {
            // Normalizamos a dígitos (la pantalla ya envía solo dígitos, igual reforzamos)
            var digits = Digits(cuitDigits);

            // 1) Buscar cliente en almacén
            var cliEntidad = ClienteAlmacen.clientes
                   .FirstOrDefault(c => Digits(c.CUIT) == digits);

            if (cliEntidad is null)
                throw new InvalidOperationException("No existe el cliente seleccionado. Vuelva a intentarlo.");

            // 2) Guías pendientes del cliente: según CU, solo estado Entregada
            // Compatibilidad: si existen datos creados cuando Entregada tenía otro valor,
            // también consideramos PendienteDeEntrega como facturable.
            var estadosFacturables = new HashSet<EstadoGuiaEnum>
        {
            EstadoGuiaEnum.Entregada,
            EstadoGuiaEnum.PendienteDeEntrega // compatibilidad hacia atrás
        };

            // Tomamos del almacén de guías, filtramos por CUIT y estado
            var pendientesEntidad = GuiaAlmacen.guias
         .Where(g => Digits(g.CUITCliente) == digits)
                    .Where(g => estadosFacturables.Contains(g.Estado))
            .OrderBy(g => g.FechaAdmision)
              .ToList();

            if (!pendientesEntidad.Any())
                throw new InvalidOperationException("No se encontraron ítems pendientes de facturar.");

            // 3) Mapear entidades → clases de pantalla (sin crear métodos nuevos)
            // Origen/Destino: resolvemos nombre de CD o Agencia según datos presentes
            var guiasPantalla = pendientesEntidad
            .Select(g => new Guia
            {
                Numero = g.NumeroGuia.ToString("D9"),
                FechaAdmision = g.FechaAdmision,
                Origen =
           (g.CodigoPostalCDOrigen != 0
                ? (CentroDeDistribucionAlmacen.centrosDeDistribucion
    .FirstOrDefault(cd => cd.CodigoPostal == g.CodigoPostalCDOrigen)?.Nombre ?? $"CD {g.CodigoPostalCDOrigen}")
      : (!string.IsNullOrWhiteSpace(g.IDAgenciaOrigen)
          ? (AgenciaAlmacen.agencias.FirstOrDefault(a => a.ID == g.IDAgenciaOrigen)?.Nombre ?? $"Agencia {g.IDAgenciaOrigen}")
           : "")),
                Destino =
        (g.CodigoPostalCDDestino != 0
            ? (CentroDeDistribucionAlmacen.centrosDeDistribucion
              .FirstOrDefault(cd => cd.CodigoPostal == g.CodigoPostalCDDestino)?.Nombre ?? $"CD {g.CodigoPostalCDDestino}")
                 : (!string.IsNullOrWhiteSpace(g.IDAgenciaDestino)
            ? (AgenciaAlmacen.agencias.FirstOrDefault(a => a.ID == g.IDAgenciaDestino)?.Nombre ?? $"Agencia {g.IDAgenciaDestino}")
         : "")),
                Tamano = g.Tamano.ToString(),
                Importe = g.ImporteAFacturar,
                Estado = EstadoDisplay(g.Estado),
                CuitCliente = cliEntidad.CUIT
            })
                    .ToList();

            // 4) Devolver cliente mapeado + guías
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
            // 1) Reutilizar la búsqueda para validar existencia + pendientes
            var (cliente, pendientes) = BuscarPorCuit(cuitDigits);

            // 2) Calcular total
            var total = pendientes.Sum(g => g.Importe);
            if (total <= 0)
                throw new InvalidOperationException("No es posible emitir una factura por $0.");

            // 3) Generar número de factura simple (no persistente)
            var numero = $"FA-{DateTime.Now:yyyyMM}-{_seqFactura++:00000}";

            // 4) Registrar factura en almacén (persistencia en archivo JSON)
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

            // 5) Registrar movimiento en Cuenta Corriente
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

            // Asegurar lista de movimientos
            cc.Movimientos ??= new List<MovimientoClienteAux>();

            var saldoAnterior = cc.Movimientos.LastOrDefault()?.SaldoActual ?? 0m;
            var mov = new MovimientoClienteAux
            {
                IDFactura = Math.Abs(numero.GetHashCode()), // entero derivado del número
                Fecha = DateTime.Now,
                Concepto = $"Factura {numero}",
                Debe = total,
                Haber = 0m,
                SaldoActual = saldoAnterior + total
            };
            cc.Movimientos.Add(mov);
            CuentaCorrienteAlmacen.Grabar();

            // 6) Marcar las guías como Facturadas EN MEMORIA (no persistir en JSON para permitir re-facturación al reiniciar)
            foreach (var p in pendientes)
            {
                var num = int.Parse(p.Numero);
                var guia = GuiaAlmacen.guias.FirstOrDefault(g => g.NumeroGuia == num);
                if (guia != null)
                {
                    guia.Estado = EstadoGuiaEnum.Facturada;
                }
            }
            // NO llamar GuiaAlmacen.Grabar() aquí → el cambio solo persiste en memoria durante la sesión

            // 7) Devolver factura en el formato que espera la pantalla
            var facPantalla = new Factura
            {
                Numero = numero,
                Fecha = facEntidad.FechaEmisionFactura,
                Cliente = cliente,
                GuiasFacturadas = pendientes
            };

            return facPantalla;
        }

        /// <summary>
        /// Postcondición 1: Actualiza los archivos de "Factura" y "Cuenta Corriente"
        /// Este método persiste explícitamente los cambios realizados en la emisión.
        /// </summary>
        public void ActualizarArchivosFacturaYCuentaCorriente()
        {
            FacturaAlmacen.Grabar();
            CuentaCorrienteAlmacen.Grabar();
        }

        /// <summary>
        /// Postcondición 2: Registra nueva deuda en la cuenta corriente del cliente
        /// Valida que el movimiento se haya registrado correctamente.
        /// </summary>
        public MovimientoClienteAux ObtenerUltimoMovimientoCuenta(string cuitDigits)
        {
            var digits = Digits(cuitDigits);
            var cc = CuentaCorrienteAlmacen.cuentasCorrientes
                .FirstOrDefault(c => Digits(c.CUITCliente) == digits);

            if (cc?.Movimientos == null || !cc.Movimientos.Any())
                throw new InvalidOperationException("No se encontraron movimientos en la cuenta corriente.");

            return cc.Movimientos.Last();
        }

        /// <summary>
        /// Postcondición 3: Disponibiliza la factura para consulta interna y entrega al cliente
        /// Retorna los datos de la factura emitida en formato accesible.
        /// </summary>
        public Factura ObtenerFacturaEmitida(string numeroFactura)
        {
            var facEntidad = FacturaAlmacen.facturas
                .FirstOrDefault(f => f.ID == numeroFactura);

            if (facEntidad is null)
                throw new InvalidOperationException($"No se encontró la factura {numeroFactura}.");

            var cliente = ClienteAlmacen.clientes
                .FirstOrDefault(c => Digits(c.CUIT) == Digits(facEntidad.CUITCliente));

            if (cliente is null)
                throw new InvalidOperationException("No se encontró el cliente asociado a la factura.");

            var guiasFacturadas = facEntidad.GuiasFacturadas
                .Select(numGuia =>
                {
                    var guiaNum = int.Parse(numGuia);
                    var guia = GuiaAlmacen.guias.FirstOrDefault(g => g.NumeroGuia == guiaNum);
                    return new Guia
                    {
                        Numero = numGuia,
                        FechaAdmision = guia?.FechaAdmision ?? DateTime.Now,
                        Importe = guia?.ImporteAFacturar ?? 0m,
                        Estado = "Facturada"
                    };
                })
                .ToList();

            return new Factura
            {
                Numero = facEntidad.ID,
                Fecha = facEntidad.FechaEmisionFactura,
                Cliente = new Cliente
                {
                    Cuit = cliente.CUIT,
                    RazonSocial = cliente.RazonSocial
                },
                GuiasFacturadas = guiasFacturadas
            };
        }

        /// <summary>
        /// Postcondición 4: Permite acceso a reportes y auditoría de facturas emitidas
        /// Retorna todas las facturas para reportes internos.
        /// </summary>
        public List<Factura> ObtenerReporteFacturasEmitidas()
        {
            return FacturaAlmacen.facturas
                .Select(f =>
                {
                    var cliente = ClienteAlmacen.clientes
                        .FirstOrDefault(c => Digits(c.CUIT) == Digits(f.CUITCliente));

                    return new Factura
                    {
                        Numero = f.ID,
                        Fecha = f.FechaEmisionFactura,
                        Cliente = new Cliente
                        {
                            Cuit = f.CUITCliente,
                            RazonSocial = cliente?.RazonSocial ?? "Cliente desconocido"
                        },
                        GuiasFacturadas = f.GuiasFacturadas
                            .Select(g => new Guia { Numero = g })
                            .ToList()
                    };
                })
                .OrderByDescending(f => f.Fecha)
                .ToList();
        }

        /// <summary>
        /// Postcondición 5: Limpia la pantalla para iniciar una nueva factura
        /// Retorna los datos necesarios para resetear el formulario.
        /// </summary>
        public void LimpiarFormularioFactura()
        {
            // Este método es principalmente informativo para la vista.
            // La lógica de limpieza real ocurre en la pantalla (vaciar textboxes, listas, etc.)
            // No requiere persistencia aquí.
        }

        /// <summary>
        /// Retorna un objeto vacío para resetear la pantalla después de la emisión.
        /// </summary>
        public (Cliente cliente, List<Guia> guias) ObtenerFormularioVacio()
        {
            return (
                new Cliente { Cuit = string.Empty, RazonSocial = string.Empty, Convenio = string.Empty },
                new List<Guia>()
            );
        }
    }
}


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
