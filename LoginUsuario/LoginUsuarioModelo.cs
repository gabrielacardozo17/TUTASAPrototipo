using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUTASAPrototipo.Almacenes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TUTASAPrototipo.LoginUsuario
{
    internal class LoginUsuarioModelo
    {
        private readonly List<Usuario> Usuarios = new() {
            new Usuario{Email="1@1.com", Contrasenia="1" },
            new Usuario{Email="alopez@yahoo.com", Contrasenia="2025Octubre" },
            new Usuario{Email="jperez@gmail.com", Contrasenia="juanAgosto" }
        };


        public Usuario ValidarUsuario(string email, string contraseña)
        {
            var usuario = Usuarios.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                u.Contrasenia == contraseña);

            return usuario;
        }

        public List<CentroDeDistribucionEntidad> ObtenerCentrosDeDistribucion()
        {
            return CentroDeDistribucionAlmacen.centrosDeDistribucion;
        }

        public List<AgenciaEntidad> ObtenerAgenciasPorCD(int codigoPostalCD)
        {
            return AgenciaAlmacen.agencias.Where(a => a.CodigoPostalCD == codigoPostalCD).ToList();
        }
    }
}
