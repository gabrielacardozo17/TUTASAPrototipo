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
            new Guia { Numero = "101000101", Tamaño = "S",  Destino = "Agencia CABA Centro", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 28765432, UbicacionActual = "" },
            new Guia { Numero = "101000102", Tamaño = "M",  Destino = "Agencia CABA Oeste", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 28765432, UbicacionActual = "" },
            new Guia { Numero = "101000103", Tamaño = "L",  Destino = "Agencia CABA Sur", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 28765432, UbicacionActual = "" },
            new Guia { Numero = "101000104", Tamaño = "XL", Destino = "Agencia CABA Centro", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 28765432, UbicacionActual = "" },
            
            // María Ledesma (DNI: 32198765) - CD CABA Sur
            new Guia { Numero = "102000201", Tamaño = "S",  Destino = "Agencia CABA Flores", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 32198765, UbicacionActual = "" },
            new Guia { Numero = "102000202", Tamaño = "M",  Destino = "Agencia CABA Sur", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 32198765, UbicacionActual = "" },
            new Guia { Numero = "102000203", Tamaño = "L",  Destino = "Agencia La Plata", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 32198765, UbicacionActual = "" },
            new Guia { Numero = "102000204", Tamaño = "S",  Destino = "Agencia CABA Flores", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 32198765, UbicacionActual = "" },
            
            // Luis Ferreyra (DNI: 30456789) - CD La Plata
            new Guia { Numero = "102000301", Tamaño = "M",  Destino = "Agencia La Plata", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 30456789, UbicacionActual = "" },
            new Guia { Numero = "102000302", Tamaño = "XL", Destino = "Agencia Mar del Plata", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 30456789, UbicacionActual = "" },
            new Guia { Numero = "102000303", Tamaño = "S",  Destino = "Agencia Quilmes", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 30456789, UbicacionActual = "" },
            new Guia { Numero = "102000304", Tamaño = "L",  Destino = "Agencia La Plata", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 30456789, UbicacionActual = "" },
            
            // Sofía Bustos (DNI: 29876543) - CD MdP
            new Guia { Numero = "102100401", Tamaño = "M",  Destino = "Agencia Mar del Plata", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 29876543, UbicacionActual = "" },
            new Guia { Numero = "102100402", Tamaño = "S",  Destino = "Agencia Bahía Blanca Centro", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 29876543, UbicacionActual = "" },
            new Guia { Numero = "102100403", Tamaño = "L",  Destino = "Agencia Mar del Plata", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 29876543, UbicacionActual = "" },
            
            // Carlos Maidana (DNI: 30987654) - CD Córdoba
            new Guia { Numero = "104000501", Tamaño = "XL", Destino = "Agencia Nueva Córdoba", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 30987654, UbicacionActual = "" },
            new Guia { Numero = "104000502", Tamaño = "S",  Destino = "Agencia Córdoba Norte", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 30987654, UbicacionActual = "" },
            new Guia { Numero = "104000503", Tamaño = "M",  Destino = "Agencia Villa Allende", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 30987654, UbicacionActual = "" },
            new Guia { Numero = "104000504", Tamaño = "L",  Destino = "Agencia Nueva Córdoba", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 30987654, UbicacionActual = "" },
            
            // Valeria Ríos (DNI: 27654321) - CD Rosario
            new Guia { Numero = "105000601", Tamaño = "S",  Destino = "Agencia Rosario Centro", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 27654321, UbicacionActual = "" },
            new Guia { Numero = "105000602", Tamaño = "M",  Destino = "Agencia Rosario Norte", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 27654321, UbicacionActual = "" },
            new Guia { Numero = "105000603", Tamaño = "L",  Destino = "Agencia Funes", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 27654321, UbicacionActual = "" },
            
            // Gustavo Acuña (DNI: 31234567) - CD Tucumán
            new Guia { Numero = "106000701", Tamaño = "XL", Destino = "Agencia Tucumán Centro", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 31234567, UbicacionActual = "" },
            new Guia { Numero = "106000702", Tamaño = "S",  Destino = "Agencia Yerba Buena", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 31234567, UbicacionActual = "" },
            
            // Paula Benítez (DNI: 29811223) - CD Corrientes
            new Guia { Numero = "107000801", Tamaño = "M",  Destino = "Agencia Corrientes Centro", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 29811223, UbicacionActual = "" },
            new Guia { Numero = "107000802", Tamaño = "L",  Destino = "Agencia Goya", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 29811223, UbicacionActual = "" },
            
            // Nicolás Godoy (DNI: 30123456) - CD Neuquén
            new Guia { Numero = "108000901", Tamaño = "S",  Destino = "Agencia Neuquén Centro", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 30123456, UbicacionActual = "" },
            new Guia { Numero = "108000902", Tamaño = "M",  Destino = "Agencia Plottier", Tipo = "Distribución", Estado = "En ruta a agencia destino", FleteroDni = 30123456, UbicacionActual = "" },
            
            // ========== GUÍAS PARA DESPACHAR (A retirar en agencia origen) ==========
            
            // Juan Pereyra - retira de Agencia CABA Centro
            new Guia { Numero = "101001001", Tamaño = "L",  Destino = "CD CABA Oeste", Tipo = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 28765432, UbicacionActual = "Agencia CABA Centro" },
            new Guia { Numero = "101001002", Tamaño = "S",  Destino = "CD CABA Oeste", Tipo = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 28765432, UbicacionActual = "Agencia CABA Centro" },
            new Guia { Numero = "101001003", Tamaño = "M",  Destino = "CD CABA Oeste", Tipo = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 28765432, UbicacionActual = "Agencia CABA Centro" },
            
            // María Ledesma - retira de Agencia CABA Flores
            new Guia { Numero = "102001101", Tamaño = "XL", Destino = "CD CABA Sur", Tipo = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 32198765, UbicacionActual = "Agencia CABA Flores" },
            new Guia { Numero = "102001102", Tamaño = "M",  Destino = "CD CABA Sur", Tipo = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 32198765, UbicacionActual = "Agencia CABA Flores" },
            new Guia { Numero = "102001103", Tamaño = "S",  Destino = "CD CABA Sur", Tipo = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 32198765, UbicacionActual = "Agencia La Plata" },
            
            // Luis Ferreyra - retira de Agencia La Plata
            new Guia { Numero = "102001201", Tamaño = "L",  Destino = "CD La Plata", Tipo = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 30456789, UbicacionActual = "Agencia La Plata" },
            new Guia { Numero = "102001202", Tamaño = "S",  Destino = "CD La Plata", Tipo = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 30456789, UbicacionActual = "Agencia Quilmes" },
            new Guia { Numero = "102001203", Tamaño = "M",  Destino = "CD La Plata", Tipo = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 30456789, UbicacionActual = "Agencia Mar del Plata" },
            
            // Sofía Bustos - retira de Agencia Mar del Plata
            new Guia { Numero = "102101301", Tamaño = "XL", Destino = "CD MdP", Tipo = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 29876543, UbicacionActual = "Agencia Mar del Plata" },
            new Guia { Numero = "102101302", Tamaño = "S",  Destino = "CD MdP", Tipo = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 29876543, UbicacionActual = "Agencia Bahía Blanca Centro" },
            
            // Carlos Maidana - retira de Agencia Córdoba
            new Guia { Numero = "104001401", Tamaño = "M",  Destino = "CD Córdoba", Tipo = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 30987654, UbicacionActual = "Agencia Nueva Córdoba" },
            new Guia { Numero = "104001402", Tamaño = "L",  Destino = "CD Córdoba", Tipo = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 30987654, UbicacionActual = "Agencia Córdoba Norte" },
            new Guia { Numero = "104001403", Tamaño = "S",  Destino = "CD Córdoba", Tipo = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 30987654, UbicacionActual = "Agencia Villa Allende" },
            
            // Valeria Ríos - retira de Agencia Rosario
            new Guia { Numero = "105001501", Tamaño = "XL", Destino = "CD Rosario", Tipo = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 27654321, UbicacionActual = "Agencia Rosario Centro" },
            new Guia { Numero = "105001502", Tamaño = "M",  Destino = "CD Rosario", Tipo = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 27654321, UbicacionActual = "Agencia Rosario Norte" },
            
            // Gustavo Acuña - retira de Agencia Tucumán
            new Guia { Numero = "106001601", Tamaño = "L",  Destino = "CD Tucumán", Tipo = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 31234567, UbicacionActual = "Agencia Tucumán Centro" },
            new Guia { Numero = "106001602", Tamaño = "S",  Destino = "CD Tucumán", Tipo = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 31234567, UbicacionActual = "Agencia Yerba Buena" },
            
            // Paula Benítez - retira de Agencia Corrientes
            new Guia { Numero = "107001701", Tamaño = "M",  Destino = "CD Corrientes", Tipo = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 29811223, UbicacionActual = "Agencia Corrientes Centro" },
            new Guia { Numero = "107001702", Tamaño = "XL", Destino = "CD Corrientes", Tipo = "Retiro", Estado = "A retirar en agencia de origen", FleteroDni = 29811223, UbicacionActual = "Agencia Goya" }
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
                                                && string.Equals(g.Tipo, "Distribución", StringComparison.OrdinalIgnoreCase)
                                                && string.Equals(g.Estado, "En ruta a agencia destino", StringComparison.OrdinalIgnoreCase)).ToList();
            
            // DESPACHO: Guías a retirar en agencia origen (para entregar al fletero)
            var aEntregar = _guias.Where(g => g.FleteroDni == dni 
                                            && string.Equals(g.Tipo, "Retiro", StringComparison.OrdinalIgnoreCase)
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
            foreach (var g in _guias.Where(g => string.Equals(g.Tipo, "Distribución", StringComparison.OrdinalIgnoreCase)))
                g.Estado = guiasRecepcionadas.Contains(g.Numero) ? "Recibida" : "No procesada";

            foreach (var g in _guias.Where(g => string.Equals(g.Tipo, "Retiro", StringComparison.OrdinalIgnoreCase)))
                g.Estado = guiasEntregadas.Contains(g.Numero) ? "Entregada" : "No procesada";
        }
    }
}
