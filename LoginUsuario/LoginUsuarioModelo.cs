using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TUTASAPrototipo.LoginUsuario
{
    internal class LoginUsuarioModelo
    {
        // Lista de usuarios de prueba (mock)
        private readonly List<Usuario> Usuarios = new() {
            new Usuario{Email="1@1.com", Contrasenia="1" },
            new Usuario{Email="alopez@yahoo.com", Contrasenia="2025Octubre" },
            new Usuario{Email="jperez@gmail.com", Contrasenia="juanAgosto" }
        };


        public Usuario ValidarUsuario(string email, string contraseña)
        {
            // Busca si existe un usuario que coincida con el login y la contraseña
            var usuario = Usuarios.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                u.Contrasenia == contraseña);

            return usuario;
        }
    }
}
