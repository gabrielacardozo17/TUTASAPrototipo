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
            new Cliente { CUIT="30-12345678-1", RazonSocial="Distribuidora Sur S.A.",           Convenio="General"      },
            new Cliente { CUIT="30-87654321-0", RazonSocial="Mayorista Norte S.R.L.",           Convenio="Preferencial" },
            new Cliente { CUIT="33-33445566-7", RazonSocial="Biotec Litoral S.R.L.",            Convenio="General"      },

            // EXISTENTES (ya agregados anteriormente)
            new Cliente { CUIT="30-10123456-4", RazonSocial="Tecnología Andina S.A.",           Convenio="General"      },
            new Cliente { CUIT="30-33445566-8", RazonSocial="Editorial Horizonte S.A.",         Convenio="General"      },
            new Cliente { CUIT="33-12345678-0", RazonSocial="Farmacorp S.A.",                   Convenio="Preferencial" },

            // NUEVOS (pedidos ahora)
            new Cliente { CUIT="30-22113456-3", RazonSocial="Alimentos Pampeanos S.A.",         Convenio="General"      },
            new Cliente { CUIT="30-24681357-0", RazonSocial="Logística Patagónica S.A.",        Convenio="General"      },
            new Cliente { CUIT="33-22113456-2", RazonSocial="Bodega del Sol S.A.",              Convenio="Preferencial" },
            new Cliente { CUIT="33-24681357-9", RazonSocial="Casa Central Hogar S.A.",          Convenio="General"      }
        };

        // Guías (TLLLNNNNN) con estados aptos para facturación y montos > 0
        private readonly List<Guia> _guias = new()
        {
            // -------- EXISTENTES (ajustadas a formato TLLLNNNNN coherente) --------
            // Cliente 30-12345678-1  — CD Córdoba Capital (0040)
            new Guia { NumeroGuia="004000123", CUIT="30-12345678-1", Fecha=new(2025,09,09), Origen="CD Córdoba Capital", Destino="Agencia Rosario Centro", Tamanio="S",  Importe=2400m, Estado="Entregada" },
            new Guia { NumeroGuia="004000124", CUIT="30-12345678-1", Fecha=new(2025,09,10), Origen="CD Córdoba Capital", Destino="CD Rosario",              Tamanio="M",  Importe=3700m, Estado="Intento de entrega" },

            // Cliente 30-87654321-0  — CD Buenos Aires – La Plata (0010)
            new Guia { NumeroGuia="001000781", CUIT="30-87654321-0", Fecha=new(2025,09,12), Origen="CD Buenos Aires – La Plata", Destino="CD CABA Sur",     Tamanio="L",  Importe=5200m, Estado="Devuelta" },

            // Cliente 33-33445566-7  — CD Buenos Aires – Mar del Plata (0011)
            new Guia { NumeroGuia="001100045", CUIT="33-33445566-7", Fecha=new(2025,09,05), Origen="CD Buenos Aires – Mar del Plata", Destino="CD Bahía Blanca", Tamanio="XL", Importe=4900m, Estado="Entregada" },

            // -------- NUEVAS (anteriores) --------
            // Cliente 30-12345678-1
            new Guia { NumeroGuia="004000125", CUIT="30-12345678-1", Fecha=new(2025,09,11), Origen="CD Córdoba Capital", Destino="Agencia Rosario Centro", Tamanio="S",  Importe=1800m, Estado="Entregada" },
            new Guia { NumeroGuia="004000126", CUIT="30-12345678-1", Fecha=new(2025,09,12), Origen="CD Córdoba Capital", Destino="CD Rosario",              Tamanio="M",  Importe=3100m, Estado="Devuelta" },

            // Cliente 30-87654321-0
            new Guia { NumeroGuia="001000782", CUIT="30-87654321-0", Fecha=new(2025,09,13), Origen="CD Buenos Aires – La Plata", Destino="Agencia CABA Centro", Tamanio="S", Importe=1500m, Estado="Intento de entrega" },
            new Guia { NumeroGuia="001000783", CUIT="30-87654321-0", Fecha=new(2025,09,14), Origen="CD Buenos Aires – La Plata", Destino="CD CABA Sur",        Tamanio="L", Importe=5400m, Estado="Entregada" },

            // Cliente 33-33445566-7
            new Guia { NumeroGuia="001100046", CUIT="33-33445566-7", Fecha=new(2025,09,06), Origen="CD Buenos Aires – Mar del Plata", Destino="Agencia Bahía Blanca Centro", Tamanio="M",  Importe=2600m, Estado="Intento de entrega" },
            new Guia { NumeroGuia="001100047", CUIT="33-33445566-7", Fecha=new(2025,09,07), Origen="CD Buenos Aires – Mar del Plata", Destino="CD Bahía Blanca",               Tamanio="S",  Importe=1900m, Estado="Devuelta" },

            // Cliente 30-10123456-4 — Tecnología Andina
            new Guia { NumeroGuia="004000211", CUIT="30-10123456-4", Fecha=new(2025,10,02), Origen="CD Córdoba Capital",           Destino="CD Mendoza Capital",        Tamanio="L",  Importe=5600m, Estado="Entregada" },
            new Guia { NumeroGuia="004000212", CUIT="30-10123456-4", Fecha=new(2025,10,03), Origen="CD Córdoba Capital",           Destino="Agencia Mendoza Centro",    Tamanio="M",  Importe=3300m, Estado="Intento de entrega" },

            // Cliente 30-33445566-8 — Editorial Horizonte
            new Guia { NumeroGuia="005000301", CUIT="30-33445566-8", Fecha=new(2025,10,04), Origen="CD Rosario",                   Destino="CD Córdoba Capital",        Tamanio="XL", Importe=6200m, Estado="Devuelta" },
            new Guia { NumeroGuia="005000302", CUIT="30-33445566-8", Fecha=new(2025,10,05), Origen="CD Rosario",                   Destino="Agencia Córdoba Norte",     Tamanio="S",  Importe=1700m, Estado="Entregada" },

            // Cliente 33-12345678-0 — Farmacorp
            new Guia { NumeroGuia="000100901", CUIT="33-12345678-0", Fecha=new(2025,10,06), Origen="CD CABA Oeste",                Destino="CD Buenos Aires – La Plata", Tamanio="M", Importe=2950m, Estado="Entregada" },
            new Guia { NumeroGuia="000100902", CUIT="33-12345678-0", Fecha=new(2025,10,07), Origen="CD CABA Oeste",                Destino="Agencia La Plata",           Tamanio="L", Importe=4500m, Estado="Intento de entrega" },

            // -------- NUEVAS (pedidas ahora) --------

            // Cliente 30-22113456-3 — Alimentos Pampeanos (Mendoza)
            new Guia { NumeroGuia="010000321", CUIT="30-22113456-3", Fecha=new(2025,10,01), Origen="CD Mendoza Capital",           Destino="CD Bahía Blanca",           Tamanio="M",  Importe=3800m, Estado="Entregada" },
            new Guia { NumeroGuia="010000322", CUIT="30-22113456-3", Fecha=new(2025,10,02), Origen="CD Mendoza Capital",           Destino="Agencia Godoy Cruz",         Tamanio="S",  Importe=1600m, Estado="Intento de entrega" },
            new Guia { NumeroGuia="010000323", CUIT="30-22113456-3", Fecha=new(2025,10,03), Origen="CD Mendoza Capital",           Destino="CD Neuquén",                 Tamanio="L",  Importe=5200m, Estado="Devuelta" },

            // Cliente 30-24681357-0 — Logística Patagónica (Viedma)
            new Guia { NumeroGuia="009000211", CUIT="30-24681357-0", Fecha=new(2025,09,30), Origen="CD Viedma",                    Destino="CD Bahía Blanca",           Tamanio="S",  Importe=1850m, Estado="Entregada" },
            new Guia { NumeroGuia="009000212", CUIT="30-24681357-0", Fecha=new(2025,10,01), Origen="CD Viedma",                    Destino="Agencia San Antonio Oeste",  Tamanio="M",  Importe=2300m, Estado="Intento de entrega" },

            // Cliente 33-22113456-2 — Bodega del Sol (Cuyo)
            new Guia { NumeroGuia="010000411", CUIT="33-22113456-2", Fecha=new(2025,10,04), Origen="CD Mendoza Capital",           Destino="CD San Miguel de Tucumán",   Tamanio="XL", Importe=6400m, Estado="Devuelta" },
            new Guia { NumeroGuia="010000412", CUIT="33-22113456-2", Fecha=new(2025,10,05), Origen="CD Mendoza Capital",           Destino="Agencia Mendoza Centro",     Tamanio="S",  Importe=1500m, Estado="Entregada" },

            // Cliente 33-24681357-9 — Casa Central Hogar (NOA/Patagonia)
            new Guia { NumeroGuia="008000145", CUIT="33-24681357-9", Fecha=new(2025,10,05), Origen="CD Neuquén",                    Destino="CD CABA Oeste",             Tamanio="M",  Importe=4100m, Estado="Intento de entrega" },
            new Guia { NumeroGuia="008000146", CUIT="33-24681357-9", Fecha=new(2025,10,06), Origen="CD Neuquén",                    Destino="Agencia Plottier",          Tamanio="S",  Importe=1350m, Estado="Entregada" }
        };

        private static int _seqFactura = 1;

        // ---------- HELPERS ----------
        private static string Digits(string s) => new string((s ?? "").Where(char.IsDigit).ToArray());

        // ---------- MÉTODOS ----------
        public (Cliente cliente, List<Guia> guias) BuscarPorCuit(string cuitDigits)
        {
            var digits = Digits(cuitDigits);

            var cliente = _clientes.FirstOrDefault(c => Digits(c.CUIT) == digits);
            if (cliente is null)
                throw new InvalidOperationException("No existe el cliente seleccionado. Vuelva a intentarlo.");

            // “Pendientes” = guías en estados facturables y no facturadas aún
            var pendientes = _guias
                .Where(g => Digits(g.CUIT) == digits)
                .Where(g => g.Estado == "Entregada"
                         || g.Estado == "Devuelta"
                         || g.Estado == "Intento de entrega")
                .OrderBy(g => g.Fecha)
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
