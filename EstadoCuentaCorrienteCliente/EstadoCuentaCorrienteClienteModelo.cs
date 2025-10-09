using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTASAPrototipo.EstadoCuentaCorrienteCliente
{
    internal class EstadoCuentaCorrienteClienteModelo
    {
        private readonly Dictionary<string, List<MovimientoCuenta>> MovimientosPorCliente = new()
        {
            {
                "30123456789", new List<MovimientoCuenta>
                {
                    new MovimientoCuenta { Fecha = new DateTime(2025, 8, 1), Descripcion = "Factura N° F0001-00001234", Debe = 15000, Haber = 0 },
                    new MovimientoCuenta { Fecha = new DateTime(2025, 8, 15), Descripcion = "Factura N° F0001-00001278", Debe = 18000, Haber = 0 },
                    new MovimientoCuenta { Fecha = new DateTime(2025, 8, 28), Descripcion = "Pago recibido", Debe = 0, Haber = 20000 },
                    new MovimientoCuenta { Fecha = new DateTime(2025, 8, 3), Descripcion = "Factura N° F0001-00001321", Debe = 22000, Haber = 0 },
                    new MovimientoCuenta { Fecha = new DateTime(2025, 9, 18), Descripcion = "Pago recibido", Debe = 0, Haber = 15000 }
                }
            },
            {
                "30876543210", new List<MovimientoCuenta>
                {
                    new MovimientoCuenta { Fecha = new DateTime(2025, 9, 5), Descripcion = "Factura N° F0002-00001501", Debe = 12000, Haber = 0 },
                    new MovimientoCuenta { Fecha = new DateTime(2025, 9, 25), Descripcion = "Pago recibido", Debe = 0, Haber = 8000 },
                    new MovimientoCuenta { Fecha = new DateTime(2025, 9, 10), Descripcion = "Factura N° F0002-00001565", Debe = 16000, Haber = 0 },
                    new MovimientoCuenta { Fecha = new DateTime(2025, 9, 29), Descripcion = "Pago recibido", Debe = 0, Haber = 10000 }
                }
            }
        };


        //Valido que el prefijo ingresado corresponda a una persona juridica
        public bool ValidarPrefijo(string cuit)
        {
            string prefijo = cuit.Substring(0, 2);
            string[] prefijosValidos = { "30", "33", "34" };
            return prefijosValidos.Contains(prefijo);
        }

        //Valido que el cliente exista
        public bool ClienteExiste(string cuit)
        {
            if (string.IsNullOrWhiteSpace(cuit)) return false;
            return MovimientosPorCliente.ContainsKey(cuit.Trim());
        }

        // Devuelve los movimientos del período
        public List<MovimientoCuenta> ObtenerMovimientos(string cuit, int año, int mes)
        {
            if (!MovimientosPorCliente.ContainsKey(cuit))
                return new List<MovimientoCuenta>();

            return MovimientosPorCliente[cuit]
                .Where(m => m.Fecha.Year == año && m.Fecha.Month == mes)
                .OrderBy(m => m.Fecha)
                .ToList();
        }

        // Calcula el saldo total hasta el cierre del período
        public decimal CalcularSaldoAlCierre(string cuit, int año, int mes)
        {
            if (!MovimientosPorCliente.ContainsKey(cuit))
                return 0;

            return MovimientosPorCliente[cuit]
                .Where(m => m.Fecha.Year < año || (m.Fecha.Year == año && m.Fecha.Month <= mes))
                .Sum(m => m.Debe - m.Haber);
        }


        // Calcula el saldo anterior a la fecha desde seleccionada
        public decimal CalcularSaldoAnterior(string cuit, int año, int mes)
        {
            if (!MovimientosPorCliente.ContainsKey(cuit))
                return 0;

            // Determinar el mes anterior
            int mesAnterior = mes - 1;
            int añoAnterior = año;

            if (mesAnterior == 0)
            {
                mesAnterior = 12;
                añoAnterior--;
            }

            return MovimientosPorCliente[cuit]
                .Where(m => m.Fecha.Year == añoAnterior && m.Fecha.Month == mesAnterior)
                .Sum(m => m.Debe - m.Haber);
        }
    }
}
