// TUTASAPrototipo/EmitirFactura/EmitirFacturaModelo.cs  (REEMPLAZO TOTAL)
using System;
using System.Collections.Generic;
using System.Linq;

namespace TUTASAPrototipo.EmitirFactura
{
    public class EmitirFacturaModelo
    {
        // ---------- DATOS DE PRUEBA (clientes locales a esta pantalla) ----------
        private readonly List<Cliente> _clientes = new()
        {
            new Cliente { Cuit="30-12345678-1", RazonSocial="Distribuidora Sur S.A.", Convenio="General" },
            new Cliente { Cuit="30-87654321-0", RazonSocial="Mayorista Norte S.R.L.", Convenio="Preferencial" },
            new Cliente { Cuit="33-33445566-7", RazonSocial="Biotec Litoral S.R.L.",   Convenio="General" },
            new Cliente { Cuit="27-99999999-3", RazonSocial="Transporte Pampeano SRL", Convenio="Corporativo" },
            new Cliente { Cuit="20-44556677-4", RazonSocial="Servicios del Oeste",     Convenio="General" }
        };

        // ---------- DATOS DE PRUEBA (guías) ----------
        // Formato de Numero: T(0/1) + LLL(3) + NNNNN(5) => 9 dígitos, ej: 104000123
        // Códigos usados (ejemplos del prototipo):
        // 001=CD CABA Oeste, 011=CD BA–Mar del Plata, 040=CD Córdoba, 110=CD Bahía Blanca
        // 010=Agencia CABA Centro
        private readonly List<Guia> _guias = new()
        {
            // CLIENTE 1: 30-12345678-1 (tres pendientes facturables: Entregada / Intento / Devuelta)
            new Guia { Numero="104000101", CuitCliente="30-12345678-1", FechaAdmision=new(2025,09,09), Origen="CD Córdoba",         Destino="Chivilcoy",     Tamano=TamanoGuia.S,  Importe=2000m, Estado=EstadoGuia.Entregada },
            new Guia { Numero="001000055", CuitCliente="30-12345678-1", FechaAdmision=new(2025,09,10), Origen="CD CABA Oeste",      Destino="Bahía Blanca",  Tamano=TamanoGuia.M,  Importe=3500m, Estado=EstadoGuia.IntentoEntrega },
            new Guia { Numero="104000102", CuitCliente="30-12345678-1", FechaAdmision=new(2025,09,15), Origen="CD Córdoba",         Destino="Luján",         Tamano=TamanoGuia.L,  Importe=1800m, Estado=EstadoGuia.Devuelta },

            // CLIENTE 2: 30-87654321-0 (una devuelta facturable)
            new Guia { Numero="101100781", CuitCliente="30-87654321-0", FechaAdmision=new(2025,09,12), Origen="CD BA - MdP",       Destino="La Plata",      Tamano=TamanoGuia.L,  Importe=5200m, Estado=EstadoGuia.Devuelta },

            // CLIENTE 3: 33-33445566-7 (ya facturada → no debe aparecer en pendientes)
            new Guia { Numero="105000123", CuitCliente="33-33445566-7", FechaAdmision=new(2025,09,05), Origen="CD Rosario",         Destino="Córdoba",       Tamano=TamanoGuia.XL, Importe=4800m, Estado=EstadoGuia.Facturada },

            // CLIENTE 4: 27-99999999-3 (dos facturables)
            new Guia { Numero="110000045", CuitCliente="27-99999999-3", FechaAdmision=new(2025,10,01), Origen="CD Bahía Blanca",    Destino="Bahía Blanca",  Tamano=TamanoGuia.M,  Importe=6000m, Estado=EstadoGuia.IntentoEntrega },
            new Guia { Numero="110000046", CuitCliente="27-99999999-3", FechaAdmision=new(2025,10,02), Origen="CD Bahía Blanca",    Destino="Córdoba",       Tamano=TamanoGuia.L,  Importe=8200m, Estado=EstadoGuia.Entregada },

            // CLIENTE 5: 20-44556677-4 (importe 0 → para forzar error 6.1 “$0” al emitir)
            new Guia { Numero="001000099", CuitCliente="20-44556677-4", FechaAdmision=new(2025,10,04), Origen="CD CABA Oeste",      Destino="Ituzaingó",     Tamano=TamanoGuia.S,  Importe=0m,    Estado=EstadoGuia.Entregada }
        };

        private static int _seqFactura = 1;

        // ---------- HELPERS (locales a este módulo) ----------
        private static string Digits(string s) => new string((s ?? "").Where(char.IsDigit).ToArray());

        // ---------- API PARA EL FORM ----------
        // Devuelve cliente + sus guías pendientes de facturar (Entregada/Devuelta/IntentoEntrega)
        public (Cliente cliente, List<Guia> guias) BuscarPorCuit(string cuitDigits)
        {
            var digits = Digits(cuitDigits);

            var cliente = _clientes.FirstOrDefault(c => Digits(c.Cuit) == digits);
            if (cliente is null)
                throw new InvalidOperationException("No existe el cliente seleccionado. Vuelva a intentarlo.");

            var pendientes = _guias
                .Where(g => Digits(g.CuitCliente) == digits)
                .Where(g => g.Estado == EstadoGuia.Entregada
                         || g.Estado == EstadoGuia.Devuelta
                         || g.Estado == EstadoGuia.IntentoEntrega)
                .OrderBy(g => g.FechaAdmision)
                .ToList();

            if (!pendientes.Any())
                throw new InvalidOperationException("No se encontraron ítems pendientes de facturar.");

            return (cliente, pendientes);
        }

        // Emite la factura y marca las guías como Facturada
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

            foreach (var g in pendientes)
                g.Estado = EstadoGuia.Facturada;

            return fac;
        }
    }
}
