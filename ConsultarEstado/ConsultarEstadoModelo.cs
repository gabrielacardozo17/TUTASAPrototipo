// TUTASAPrototipo/ConsultarEstado/ConsultarEstadoModelo.cs  (VERSIÓN ACTUALIZADA)
using System;
using System.Collections.Generic;
using System.Linq;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.ConsultarEstado
{
    public class ConsultarEstadoModelo
    {
        // Helper local: solo dígitos
        private static string Digits(string s) => new string((s ?? "").Where(char.IsDigit).ToArray());

        public GuiaEntidad? ObtenerPorNumero(string input)
        {
            if (!int.TryParse(input, out int numeroGuia))
            {
                return null;
            }
            return GuiaAlmacen.Guias.FirstOrDefault(g => g.Numero == numeroGuia);
        }
    }
}
