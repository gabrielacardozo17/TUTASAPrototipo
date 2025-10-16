// TUTASAPrototipo/EmitirFactura/EmitirFacturaModelo.cs  (REEMPLAZO TOTAL)
using System;
using System.Collections.Generic;
using System.Linq;

namespace TUTASAPrototipo.EmitirFactura
{
    public class EmitirFacturaModelo
    {
        // ---------- DATOS DE PRUEBA ----------
        // Clientes (agregados algunos más; CUIT con DV válido)
        private readonly List<Cliente> _clientes = new()
        {
            new Cliente { Cuit="30-12345678-1", RazonSocial="Distribuidora Sur S.A.",           Convenio="General"      },
            new Cliente { Cuit="30-87654321-0", RazonSocial="Mayorista Norte S.R.L.",           Convenio="Preferencial" },
            new Cliente { Cuit="33-33445566-7", RazonSocial="Biotec Litoral S.R.L.",            Convenio="General"      },

            // EXISTENTES (ya agregados anteriormente)
            new Cliente { Cuit="30-10123456-4", RazonSocial="Tecnología Andina S.A.",           Convenio="General"      },
            new Cliente { Cuit="30-33445566-8", RazonSocial="Editorial Horizonte S.A.",         Convenio="General"      },
            new Cliente { Cuit="33-12345678-0", RazonSocial="Farmacorp S.A.",                   Convenio="Preferencial" },

            // NUEVOS (pedidos ahora)
            new Cliente { Cuit="30-22113456-3", RazonSocial="Alimentos Pampeanos S.A.",         Convenio="General"      },
            new Cliente { Cuit="30-24681357-0", RazonSocial="Logística Patagónica S.A.",        Convenio="General"      },
            new Cliente { Cuit="33-22113456-2", RazonSocial="Bodega del Sol S.A.",              Convenio="Preferencial" },
            new Cliente { Cuit="33-24681357-9", RazonSocial="Casa Central Hogar S.A.",          Convenio="General"      }
        };

        // Guías (TLLLNNNNN) con estados aptos para facturación y montos > 0
        private readonly List<Guia> _guias = new()
        {
            // -------- EXISTENTES (ajustadas a formato TLLLNNNNN coherente) --------
            // Cliente 30-12345678-1  — CD Córdoba Capital (0040)
            new Guia { Numero="004000123", CuitCliente="30-12345678-1", FechaAdmision=new(2025,09,09), Origen="CD Córdoba Capital", Destino="Agencia Rosario Centro", Tamano="S",  Importe=2400m, Estado="Entregada" },
            new Guia { Numero="004000124", CuitCliente="30-12345678-1", FechaAdmision=new(2025,09,10), Origen="CD Córdoba Capital", Destino="CD Rosario",              Tamano="M",  Importe=3700m, Estado="Intento de entrega" },

            // Cliente 30-87654321-0  — CD Buenos Aires – La Plata (0010)
            new Guia { Numero="001000781", CuitCliente="30-87654321-0", FechaAdmision=new(2025,09,12), Origen="CD Buenos Aires – La Plata", Destino="CD CABA Sur",     Tamano="L",  Importe=5200m, Estado="Devuelta" },

            // Cliente 33-33445566-7  — CD Buenos Aires – Mar del Plata (0011)
            new Guia { Numero="001100045", CuitCliente="33-33445566-7", FechaAdmision=new(2025,09,05), Origen="CD Buenos Aires – Mar del Plata", Destino="CD Bahía Blanca", Tamano="XL", Importe=4900m, Estado="Entregada" },

            // -------- NUEVAS (anteriores) --------
            // Cliente 30-12345678-1
            new Guia { Numero="004000125", CuitCliente="30-12345678-1", FechaAdmision=new(2025,09,11), Origen="CD Córdoba Capital", Destino="Agencia Rosario Centro", Tamano="S",  Importe=1800m, Estado="Entregada" },
            new Guia { Numero="004000126", CuitCliente="30-12345678-1", FechaAdmision=new(2025,09,12), Origen="CD Córdoba Capital", Destino="CD Rosario",              Tamano="M",  Importe=3100m, Estado="Devuelta" },

            // Cliente 30-87654321-0
            new Guia { Numero="001000782", CuitCliente="30-87654321-0", FechaAdmision=new(2025,09,13), Origen="CD Buenos Aires – La Plata", Destino="Agencia CABA Centro", Tamano="S", Importe=1500m, Estado="Intento de entrega" },
            new Guia { Numero="001000783", CuitCliente="30-87654321-0", FechaAdmision=new(2025,09,14), Origen="CD Buenos Aires – La Plata", Destino="CD CABA Sur",        Tamano="L", Importe=5400m, Estado="Entregada" },

            // Cliente 33-33445566-7
            new Guia { Numero="001100046", CuitCliente="33-33445566-7", FechaAdmision=new(2025,09,06), Origen="CD Buenos Aires – Mar del Plata", Destino="Agencia Bahía Blanca Centro", Tamano="M",  Importe=2600m, Estado="Intento de entrega" },
            new Guia { Numero="001100047", CuitCliente="33-33445566-7", FechaAdmision=new(2025,09,07), Origen="CD Buenos Aires – Mar del Plata", Destino="CD Bahía Blanca",               Tamano="S",  Importe=1900m, Estado="Devuelta" },

            // Cliente 30-10123456-4 — Tecnología Andina
            new Guia { Numero="004000211", CuitCliente="30-10123456-4", FechaAdmision=new(2025,10,02), Origen="CD Córdoba Capital",           Destino="CD Mendoza Capital",        Tamano="L",  Importe=5600m, Estado="Entregada" },
            new Guia { Numero="004000212", CuitCliente="30-10123456-4", FechaAdmision=new(2025,10,03), Origen="CD Córdoba Capital",           Destino="Agencia Mendoza Centro",    Tamano="M",  Importe=3300m, Estado="Intento de entrega" },

            // Cliente 30-33445566-8 — Editorial Horizonte
            new Guia { Numero="005000301", CuitCliente="30-33445566-8", FechaAdmision=new(2025,10,04), Origen="CD Rosario",                   Destino="CD Córdoba Capital",        Tamano="XL", Importe=6200m, Estado="Devuelta" },
            new Guia { Numero="005000302", CuitCliente="30-33445566-8", FechaAdmision=new(2025,10,05), Origen="CD Rosario",                   Destino="Agencia Córdoba Norte",     Tamano="S",  Importe=1700m, Estado="Entregada" },

            // Cliente 33-12345678-0 — Farmacorp
            new Guia { Numero="000100901", CuitCliente="33-12345678-0", FechaAdmision=new(2025,10,06), Origen="CD CABA Oeste",                Destino="CD Buenos Aires – La Plata", Tamano="M", Importe=2950m, Estado="Entregada" },
            new Guia { Numero="000100902", CuitCliente="33-12345678-0", FechaAdmision=new(2025,10,07), Origen="CD CABA Oeste",                Destino="Agencia La Plata",           Tamano="L", Importe=4500m, Estado="Intento de entrega" },

            // -------- NUEVAS (pedidas ahora) --------

            // Cliente 30-22113456-3 — Alimentos Pampeanos (Mendoza)
            new Guia { Numero="010000321", CuitCliente="30-22113456-3", FechaAdmision=new(2025,10,01), Origen="CD Mendoza Capital",           Destino="CD Bahía Blanca",           Tamano="M",  Importe=3800m, Estado="Entregada" },
            new Guia { Numero="010000322", CuitCliente="30-22113456-3", FechaAdmision=new(2025,10,02), Origen="CD Mendoza Capital",           Destino="Agencia Godoy Cruz",         Tamano="S",  Importe=1600m, Estado="Intento de entrega" },
            new Guia { Numero="010000323", CuitCliente="30-22113456-3", FechaAdmision=new(2025,10,03), Origen="CD Mendoza Capital",           Destino="CD Neuquén",                 Tamano="L",  Importe=5200m, Estado="Devuelta" },

            // Cliente 30-24681357-0 — Logística Patagónica (Viedma)
            new Guia { Numero="009000211", CuitCliente="30-24681357-0", FechaAdmision=new(2025,09,30), Origen="CD Viedma",                    Destino="CD Bahía Blanca",           Tamano="S",  Importe=1850m, Estado="Entregada" },
            new Guia { Numero="009000212", CuitCliente="30-24681357-0", FechaAdmision=new(2025,10,01), Origen="CD Viedma",                    Destino="Agencia San Antonio Oeste",  Tamano="M",  Importe=2300m, Estado="Intento de entrega" },

            // Cliente 33-22113456-2 — Bodega del Sol (Cuyo)
            new Guia { Numero="010000411", CuitCliente="33-22113456-2", FechaAdmision=new(2025,10,04), Origen="CD Mendoza Capital",           Destino="CD San Miguel de Tucumán",   Tamano="XL", Importe=6400m, Estado="Devuelta" },
            new Guia { Numero="010000412", CuitCliente="33-22113456-2", FechaAdmision=new(2025,10,05), Origen="CD Mendoza Capital",           Destino="Agencia Mendoza Centro",     Tamano="S",  Importe=1500m, Estado="Entregada" },

            // Cliente 33-24681357-9 — Casa Central Hogar (NOA/Patagonia)
            new Guia { Numero="008000145", CuitCliente="33-24681357-9", FechaAdmision=new(2025,10,05), Origen="CD Neuquén",                    Destino="CD CABA Oeste",             Tamano="M",  Importe=4100m, Estado="Intento de entrega" },
            new Guia { Numero="008000146", CuitCliente="33-24681357-9", FechaAdmision=new(2025,10,06), Origen="CD Neuquén",                    Destino="Agencia Plottier",          Tamano="S",  Importe=1350m, Estado="Entregada" }
        };

        private static int _seqFactura = 1;

        // ---------- HELPERS ----------
        private static string Digits(string s) => new string((s ?? "").Where(char.IsDigit).ToArray());

        // ---------- MÉTODOS ----------
        public (Cliente cliente, List<Guia> guias) BuscarPorCuit(string cuitDigits)
        {
            var digits = Digits(cuitDigits);

            var cliente = _clientes.FirstOrDefault(c => Digits(c.Cuit) == digits);
            if (cliente is null)
                throw new InvalidOperationException("No existe el cliente seleccionado. Vuelva a intentarlo.");

            // “Pendientes” = guías en estados facturables y no facturadas aún
            var pendientes = _guias
                .Where(g => Digits(g.CuitCliente) == digits)
                .Where(g => g.Estado == "Entregada"
                         || g.Estado == "Devuelta"
                         || g.Estado == "Intento de entrega")
                .OrderBy(g => g.FechaAdmision)
                .ToList();

            if (!pendientes.Any())
                throw new InvalidOperationException("No se encontraron ítems pendientes de facturar.");

            return (cliente, pendientes);
        }

        public Factura EmitirFactura(string cuitDigits)
        {
            var (cliente, pendientes) = BuscarPorCuit(cuitDigits);
            var total = pendientes.Sum(g => g.Importe);

            if (total <= 0)
                throw new InvalidOperationException("No es posible emitir una factura por $0.");

            var numero = $"FA-{DateTime.Now:yyyyMM}-{_seqFactura++:00000}";

            var fac = new Factura
            {
                Numero = numero,
                Cliente = cliente,
                GuiasFacturadas = pendientes
            };

            // Marcar como facturadas las guías incluidas
            foreach (var g in pendientes)
                g.Estado = "Facturada";

            return fac;
        }
    }
}
