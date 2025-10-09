using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTASAPrototipo.MonitoreoResultados
{
    internal class MonitoreoResultadosModelo
    {

        private readonly List<EmpresaTransporte> EmpresasTransporte = new() {
           
            //test data 1
            new EmpresaTransporte { Nombre = "Patagonia Bus",
                CostoMensual = new List<CostoMensual>
                {
                    new CostoMensual{Año=2025, Mes=8, Monto=500000}, //mes de agosto
                    new CostoMensual{Año=2025, Mes=9, Monto=800000},
                },
                VentaMensual = new List<VentaMensual>
                {
                    new VentaMensual {Año=2025, Mes=8, Monto=1_500_000},
                    new VentaMensual {Año=2025, Mes=9, Monto = 1_700_000}
                }

            },
            
            //test data 2
            new EmpresaTransporte { Nombre = "Expreso Andino S.A",
                CostoMensual = new List<CostoMensual>
                {
                    new CostoMensual{Año=2025, Mes=8, Monto=800000}, //mes de agosto
                    new CostoMensual{Año=2025, Mes=9, Monto=600000},
                },
                VentaMensual = new List<VentaMensual>
                {
                    new VentaMensual {Año=2025, Mes=8, Monto=1_000_000},
                    new VentaMensual {Año=2025, Mes=9, Monto = 1_200_000}
                }
            },

            //test data 3
            new EmpresaTransporte { Nombre = "Expreso del Litoral",
                CostoMensual = new List<CostoMensual>
                {
                    new CostoMensual{Año=2025, Mes=8, Monto=700000}, //mes de agosto
                    new CostoMensual{Año=2025, Mes=9, Monto=500000},
                },
                VentaMensual = new List<VentaMensual>
                {
                    new VentaMensual {Año=2025, Mes=8, Monto=900000},
                    new VentaMensual {Año=2025, Mes=9, Monto = 1_000_000}
                }

            },

            //test data 4
            new EmpresaTransporte { Nombre = "Noreste Express",
                CostoMensual = new List<CostoMensual>
                {
                    new CostoMensual{Año=2025, Mes=8, Monto=500000}, //mes de agosto
                    new CostoMensual{Año=2025, Mes=9, Monto=500000},
                },
                VentaMensual = new List<VentaMensual>
                {
                    new VentaMensual {Año=2025, Mes=8, Monto=1_100_000},
                    new VentaMensual {Año=2025, Mes=9, Monto = 400000}
                }
           },

        };



        //metodo para obtener los resultados (Ventas-Costos)
        public List<(string Empresa, decimal Costo, decimal Venta, decimal Resultado)> ObtenerResultados(int año, int mes)
        {
            var resultados = EmpresasTransporte.Select(e =>
            {
                var costo = e.CostoMensual.FirstOrDefault(c => c.Año == año && c.Mes == mes)?.Monto ?? 0;
                var venta = e.VentaMensual.FirstOrDefault(v => v.Año == año && v.Mes == mes)?.Monto ?? 0;
                var resultado = venta - costo;

                return (e.Nombre, costo, venta, resultado);
            }).ToList();

            return resultados;
        }

    }
}
