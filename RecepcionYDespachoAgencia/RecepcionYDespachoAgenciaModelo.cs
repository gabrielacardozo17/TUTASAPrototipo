using System;
using System.Collections.Generic;
using System.Linq;

namespace TUTASAPrototipo.RecepcionYDespachoAgencia
{
    public class RecepcionYDespachoAgenciaModelo
    {
        // ======= Datos de prueba =======
        private readonly List<Fletero> _fleteros = new List<Fletero>
        {
            new Fletero { Dni = 28765432, Nombre = "Juan", Apellido = "Pereyra" },
            new Fletero { Dni = 32198765, Nombre = "María", Apellido = "Ledesma" },
            new Fletero { Dni = 30456789, Nombre = "Luis", Apellido = "Ferreyra" },
            new Fletero { Dni = 29876543, Nombre = "Sofía", Apellido = "Bustos" },
            new Fletero { Dni = 30987654, Nombre = "Carlos", Apellido = "Maidana" },
            new Fletero { Dni = 27654321, Nombre = "Valeria", Apellido = "Ríos" },
            new Fletero { Dni = 31234567, Nombre = "Gustavo", Apellido = "Acuña" },
            new Fletero { Dni = 29811223, Nombre = "Paula", Apellido = "Benítez" },
            new Fletero { Dni = 30123456, Nombre = "Nicolás", Apellido = "Godoy" },
            new Fletero { Dni = 28456712, Nombre = "Carla", Apellido = "Mansilla" }
        };

        // Semilla de guías (mezcla de recepción y despacho)
        private readonly List<Guia> _guias = new List<Guia>
        {
            // ========== GUÍAS PARA RECEPCIONAR (En ruta a agencia destino) ==========
            
            // Juan Pereyra (DNI: 28765432) - CD CABA Oeste
            new Guia { NumeroGuia = "101000101", Tamanio = "S",  Destino = "Agencia CABA Centro", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 28765432, Ubicacion = "" },
            new Guia { NumeroGuia = "101000102", Tamanio = "M",  Destino = "Agencia CABA Oeste", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 28765432, Ubicacion = "" },
            new Guia { NumeroGuia = "101000103", Tamanio = "L",  Destino = "Agencia CABA Sur", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 28765432, Ubicacion = "" },
            new Guia { NumeroGuia = "101000104", Tamanio = "XL", Destino = "Agencia CABA Centro", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 28765432, Ubicacion = "" },
            
            // María Ledesma (DNI: 32198765) - CD CABA Sur
            new Guia { NumeroGuia = "102000201", Tamanio = "S",  Destino = "Agencia CABA Flores", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 32198765, Ubicacion = "" },
            new Guia { NumeroGuia = "102000202", Tamanio = "M",  Destino = "Agencia CABA Sur", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 32198765, Ubicacion = "" },
            new Guia { NumeroGuia = "102000203", Tamanio = "L",  Destino = "Agencia La Plata", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 32198765, Ubicacion = "" },
            new Guia { NumeroGuia = "102000204", Tamanio = "S",  Destino = "Agencia CABA Flores", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 32198765, Ubicacion = "" },
            
            // Luis Ferreyra (DNI: 30456789) - CD La Plata
            new Guia { NumeroGuia = "102000301", Tamanio = "M",  Destino = "Agencia La Plata", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 30456789, Ubicacion = "" },
            new Guia { NumeroGuia = "102000302", Tamanio = "XL", Destino = "Agencia Mar del Plata", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 30456789, Ubicacion = "" },
            new Guia { NumeroGuia = "102000303", Tamanio = "S",  Destino = "Agencia Quilmes", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 30456789, Ubicacion = "" },
            new Guia { NumeroGuia = "102000304", Tamanio = "L",  Destino = "Agencia La Plata", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 30456789, Ubicacion = "" },
            
            // Sofía Bustos (DNI: 29876543) - CD MdP
            new Guia { NumeroGuia = "102100401", Tamanio = "M",  Destino = "Agencia Mar del Plata", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 29876543, Ubicacion = "" },
            new Guia { NumeroGuia = "102100402", Tamanio = "S",  Destino = "Agencia Bahía Blanca Centro", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 29876543, Ubicacion = "" },
            new Guia { NumeroGuia = "102100403", Tamanio = "L",  Destino = "Agencia Mar del Plata", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 29876543, Ubicacion = "" },
            
            // Carlos Maidana (DNI: 30987654) - CD Córdoba
            new Guia { NumeroGuia = "104000501", Tamanio = "XL", Destino = "Agencia Nueva Córdoba", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 30987654, Ubicacion = "" },
            new Guia { NumeroGuia = "104000502", Tamanio = "S",  Destino = "Agencia Córdoba Norte", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 30987654, Ubicacion = "" },
            new Guia { NumeroGuia = "104000503", Tamanio = "M",  Destino = "Agencia Villa Allende", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 30987654, Ubicacion = "" },
            new Guia { NumeroGuia = "104000504", Tamanio = "L",  Destino = "Agencia Nueva Córdoba", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 30987654, Ubicacion = "" },
            
            // Valeria Ríos (DNI: 27654321) - CD Rosario
            new Guia { NumeroGuia = "105000601", Tamanio = "S",  Destino = "Agencia Rosario Centro", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 27654321, Ubicacion = "" },
            new Guia { NumeroGuia = "105000602", Tamanio = "M",  Destino = "Agencia Rosario Norte", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 27654321, Ubicacion = "" },
            new Guia { NumeroGuia = "105000603", Tamanio = "L",  Destino = "Agencia Funes", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 27654321, Ubicacion = "" },
            
            // Gustavo Acuña (DNI: 31234567) - CD Tucumán
            new Guia { NumeroGuia = "106000701", Tamanio = "XL", Destino = "Agencia Tucumán Centro", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 31234567, Ubicacion = "" },
            new Guia { NumeroGuia = "106000702", Tamanio = "S",  Destino = "Agencia Yerba Buena", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 31234567, Ubicacion = "" },
            
            // Paula Benítez (DNI: 29811223) - CD Corrientes
            new Guia { NumeroGuia = "107000801", Tamanio = "M",  Destino = "Agencia Corrientes Centro", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 29811223, Ubicacion = "" },
            new Guia { NumeroGuia = "107000802", Tamanio = "L",  Destino = "Agencia Goya", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 29811223, Ubicacion = "" },
            
            // Nicolás Godoy (DNI: 30123456) - CD Neuquén
            new Guia { NumeroGuia = "108000901", Tamanio = "S",  Destino = "Agencia Neuquén Centro", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 30123456, Ubicacion = "" },
            new Guia { NumeroGuia = "108000902", Tamanio = "M",  Destino = "Agencia Plottier", TipoEntrega = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 30123456, Ubicacion = "" },
            
            // ========== GUÍAS PARA DESPACHAR (A retirar en agencia origen) ==========
            
            // Juan Pereyra - retira de Agencia CABA Centro
            new Guia { NumeroGuia = "101001001", Tamanio = "L",  Destino = "CD CABA Oeste", TipoEntrega = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 28765432, Ubicacion = "Agencia CABA Centro" },
            new Guia { NumeroGuia = "101001002", Tamanio = "S",  Destino = "CD CABA Oeste", TipoEntrega = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 28765432, Ubicacion = "Agencia CABA Centro" },
            new Guia { NumeroGuia = "101001003", Tamanio = "M",  Destino = "CD CABA Oeste", TipoEntrega = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 28765432, Ubicacion = "Agencia CABA Centro" },
            
            // María Ledesma - retira de Agencia CABA Flores
            new Guia { NumeroGuia = "102001101", Tamanio = "XL", Destino = "CD CABA Sur", TipoEntrega = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 32198765, Ubicacion = "Agencia CABA Flores" },
            new Guia { NumeroGuia = "102001102", Tamanio = "M",  Destino = "CD CABA Sur", TipoEntrega = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 32198765, Ubicacion = "Agencia CABA Flores" },
            new Guia { NumeroGuia = "102001103", Tamanio = "S",  Destino = "CD CABA Sur", TipoEntrega = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 32198765, Ubicacion = "Agencia La Plata" },
            
            // Luis Ferreyra - retira de Agencia La Plata
            new Guia { NumeroGuia = "102001201", Tamanio = "L",  Destino = "CD La Plata", TipoEntrega = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 30456789, Ubicacion = "Agencia La Plata" },
            new Guia { NumeroGuia = "102001202", Tamanio = "S",  Destino = "CD La Plata", TipoEntrega = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 30456789, Ubicacion = "Agencia Quilmes" },
            new Guia { NumeroGuia = "102001203", Tamanio = "M",  Destino = "CD La Plata", TipoEntrega = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 30456789, Ubicacion = "Agencia Mar del Plata" },
            
            // Sofía Bustos - retira de Agencia Mar del Plata
            new Guia { NumeroGuia = "102101301", Tamanio = "XL", Destino = "CD MdP", TipoEntrega = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 29876543, Ubicacion = "Agencia Mar del Plata" },
            new Guia { NumeroGuia = "102101302", Tamanio = "S",  Destino = "CD MdP", TipoEntrega = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 29876543, Ubicacion = "Agencia Bahía Blanca Centro" },
            
            // Carlos Maidana - retira de Agencia Córdoba
            new Guia { NumeroGuia = "104001401", Tamanio = "M",  Destino = "CD Córdoba", TipoEntrega = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 30987654, Ubicacion = "Agencia Nueva Córdoba" },
            new Guia { NumeroGuia = "104001402", Tamanio = "L",  Destino = "CD Córdoba", TipoEntrega = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 30987654, Ubicacion = "Agencia Córdoba Norte" },
            new Guia { NumeroGuia = "104001403", Tamanio = "S",  Destino = "CD Córdoba", TipoEntrega = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 30987654, Ubicacion = "Agencia Villa Allende" },
            
            // Valeria Ríos - retira de Agencia Rosario
            new Guia { NumeroGuia = "105001501", Tamanio = "XL", Destino = "CD Rosario", TipoEntrega = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 27654321, Ubicacion = "Agencia Rosario Centro" },
            new Guia { NumeroGuia = "105001502", Tamanio = "M",  Destino = "CD Rosario", TipoEntrega = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 27654321, Ubicacion = "Agencia Rosario Norte" },
            
            // Gustavo Acuña - retira de Agencia Tucumán
            new Guia { NumeroGuia = "106001601", Tamanio = "L",  Destino = "CD Tucumán", TipoEntrega = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 31234567, Ubicacion = "Agencia Tucumán Centro" },
            new Guia { NumeroGuia = "106001602", Tamanio = "S",  Destino = "CD Tucumán", TipoEntrega = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 31234567, Ubicacion = "Agencia Yerba Buena" },
            
            // Paula Benítez - retira de Agencia Corrientes
            new Guia { NumeroGuia = "107001701", Tamanio = "M",  Destino = "CD Corrientes", TipoEntrega = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 29811223, Ubicacion = "Agencia Corrientes Centro" },
            new Guia { NumeroGuia = "107001702", Tamanio = "XL", Destino = "CD Corrientes", TipoEntrega = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 29811223, Ubicacion = "Agencia Goya" }
        };

        // ======= API para el Form =======
        public Fletero? BuscarFleteroPorDni(int dni) => _fleteros.FirstOrDefault(f => f.Dni == dni);

        public (List<Guia> aRecepcionar, List<Guia> aEntregar) GetGuiasPorFletero(int dni)
        {
            // N3: el fletero debe existir
            if (BuscarFleteroPorDni(dni) is null)
                throw new InvalidOperationException("No existe el fletero. Vuelva a intentarlo.");

            // N4: Filtrar guías por fletero y estado
            // RECEPCIÓN: Guías en ruta a agencia destino (para recepcionar)
            var aRecepcionar = _guias.Where(g => g.FleteroDni == dni 
                                                && string.Equals(g.TipoEntrega, "Distribución", StringComparison.OrdinalIgnoreCase)
                                                && string.Equals(g.Estado, "En ruta a agencia destino", StringComparison.OrdinalIgnoreCase)).ToList();
            
            // DESPACHO: Guías a retirar en agencia origen (para entregar al fletero)
            var aEntregar = _guias.Where(g => g.FleteroDni == dni 
                                            && string.Equals(g.TipoEntrega, "Retiro", StringComparison.OrdinalIgnoreCase)
                                            && string.Equals(g.Estado, "A retirar en agencia de origen", StringComparison.OrdinalIgnoreCase)).ToList();

            if (aRecepcionar.Count == 0 && aEntregar.Count == 0)
                throw new InvalidOperationException("El fletero seleccionado no tiene guías a recibir ni entregar");

            return (aRecepcionar, aEntregar);
        }

        public void ConfirmarOperacion(int dni, List<string> guiasRecepcionadas, List<string> guiasEntregadas)
        {
            // N3: existencia
            if (BuscarFleteroPorDni(dni) is null)
                throw new InvalidOperationException("Debe seleccionar un transportista primero");

            // N4: actualizar estados según marcado en la UI
            foreach (var g in _guias.Where(g => string.Equals(g.TipoEntrega, "Distribución", StringComparison.OrdinalIgnoreCase)))
                g.Estado = guiasRecepcionadas.Contains(g.NumeroGuia) ? "Recibida" : "No procesada";

            foreach (var g in _guias.Where(g => string.Equals(g.TipoEntrega, "Retiro", StringComparison.OrdinalIgnoreCase)))
                g.Estado = guiasEntregadas.Contains(g.NumeroGuia) ? "Entregada" : "No procesada";
        }
    }
}
