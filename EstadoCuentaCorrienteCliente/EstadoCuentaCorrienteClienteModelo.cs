using System;
using System.Collections.Generic;
using System.Linq;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.EstadoCuentaCorrienteCliente
{
    internal class EstadoCuentaCorrienteClienteModelo
    {
        private static string Digits(string s) => new string((s ?? "").Where(char.IsDigit).ToArray());

        //Valido que el prefijo ingresado corresponda a una persona juridica
        public bool ValidarPrefijo(string cuit)
        {
            if (string.IsNullOrWhiteSpace(cuit) || cuit.Length < 2) return false;
            string prefijo = cuit.Substring(0, 2);
            string[] prefijosValidos = { "30", "33", "34" };
            return prefijosValidos.Contains(prefijo);
        }

        //Valido que el cliente exista
        public bool ClienteExiste(string cuit)
        {
            if (string.IsNullOrWhiteSpace(cuit)) return false;
            var cuitDigits = Digits(cuit);
            // Asegurarse que los datos están cargados
            ClienteAlmacen.Load();
            return ClienteAlmacen.clientes.Any(c => Digits(c.CUIT) == cuitDigits);
        }

        //  calcula estado completo (saldo + movimientos + deuda)
        public (List<MovimientoCuenta> Movimientos, decimal SaldoAlCierre, bool TieneMovimientos, bool EstaAlDia)
           ObtenerEstadoCuenta(string cuit, int año, int mes)
        {
            var cuitDigits = Digits(cuit);
            if (!ClienteExiste(cuitDigits))
                return (new List<MovimientoCuenta>(), 0, false, true);

            // Asegurarse que los datos están cargados
            CuentaCorrienteAlmacen.Load();
            var cuentaCorriente = CuentaCorrienteAlmacen.cuentasCorrientes
                .FirstOrDefault(cc => Digits(cc.CUITCliente) == cuitDigits);

            if (cuentaCorriente == null || cuentaCorriente.Movimientos == null)
            {
                return (new List<MovimientoCuenta>(), 0, false, true);
            }

            // Movimientos del mes
            var movimientosDelMes = cuentaCorriente.Movimientos
                .Where(m => m.Fecha.Year == año && m.Fecha.Month == mes)
                .OrderBy(m => m.Fecha)
                .ToList();

            // Calcular neto del mes: suma de Debe - Haber solamente del periodo solicitado
            var netoDelMes = movimientosDelMes.Sum(m => m.Debe - m.Haber);

            var movimientos = new List<MovimientoCuenta>();
            var saldoAcumuladoMes = 0m; // acumulado solo dentro del mes

            foreach (var mov in movimientosDelMes)
            {
                // Calcular neto del movimiento (siempre usar Debe - Haber)
                var debe = mov.Debe;
                var haber = mov.Haber;

                saldoAcumuladoMes += debe - haber; // actualizar saldo acumulado del mes sin persistir

                movimientos.Add(new MovimientoCuenta
                {
                    Fecha = mov.Fecha,
                    Descripcion = mov.Concepto,
                    Debe = debe,
                    Haber = haber,
                    Saldo = saldoAcumuladoMes
                });
            }

            var saldoAlCierre = netoDelMes; // ahora es el neto del mes, no incluye saldo inicial
            bool estaAlDia = saldoAlCierre <= 0;

            return (movimientos, saldoAlCierre, movimientos.Any(), estaAlDia);
        }
    }
}

