// TUTASAPrototipo/EmitirFactura/EmitirFacturaModelo.cs  (REEMPLAZO TOTAL)
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
        private static string Digits(string s) => new string((s ?? "").Where(char.IsDigit).ToArray());

        // ---------- MÉTODOS ----------
        public (ClienteEntidad cliente, List<GuiaEntidad> guias) BuscarPorCuit(string cuitDigits)
        {
            var digits = Digits(cuitDigits);

            var cliente = ClienteAlmacen.Clientes.FirstOrDefault(c => Digits(c.CUIT) == digits);
            if (cliente is null)
                throw new InvalidOperationException("No existe el cliente seleccionado. Vuelva a intentarlo.");

            // “Pendientes” = guías en estados facturables y no facturadas aún
            var pendientes = GuiaAlmacen.Guias
                .Where(g => g.Cliente.CUIT == cliente.CUIT)
                .Where(g => g.Estado == EstadoGuiaEnum.Entregada
                         || g.Estado == EstadoGuiaEnum.NoEntregada // Asumo que "Devuelta" y "Intento de entrega" ahora son "NoEntregada"
                         || g.Estado == EstadoGuiaEnum.Cancelada) // Opcional: incluir canceladas si se facturan
                .OrderBy(g => g.FechaAdmision)
                .ToList();

            if (!pendientes.Any())
                throw new InvalidOperationException("No se encontraron ítems pendientes de facturar.");

            return (cliente, pendientes);
        }

        public FacturaEntidad EmitirFactura(string cuitDigits)
        {
            var (cliente, pendientes) = BuscarPorCuit(cuitDigits);
            
            // El cálculo del total ahora dependerá de la lógica de negocio y las tarifas.
            // Por ahora, asignamos un total simbólico.
            decimal total = pendientes.Count *1000m; // Ejemplo: $1000 por guía

            if (total <= 0)
                throw new InvalidOperationException("No es posible emitir una factura por $0.");

            var id = (_seqFactura++).ToString();

            var fac = new FacturaEntidad
            {
                ID = id,
                CUITCliente = cliente.CUIT,
                GuiasFacturadas = pendientes.Select(g => g.Numero).ToList(),
                FechaEmisionFactura = DateTime.Now,
                Total = total
            };

            // Marcar como facturadas las guías incluidas
            foreach (var g in pendientes)
                g.Estado = EstadoGuiaEnum.Facturada;

            // Guardar la factura y actualizar las guías
            FacturaAlmacen.Facturas.Add(fac);
            FacturaAlmacen.Grabar();
            GuiaAlmacen.Grabar();

            return fac;
        }
    }
}
