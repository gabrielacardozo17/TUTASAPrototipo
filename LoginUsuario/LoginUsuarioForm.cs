using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUTASAPrototipo.MonitoreoResultados;

namespace TUTASAPrototipo.LoginUsuario
{
    public partial class LoginUsuarioForm : Form
    {
        private readonly LoginUsuarioModelo Modelo = new(); // accedemos al modelo
        public LoginUsuarioForm()
        {
            InitializeComponent();
        }

        private void IngresarButton_Click(object sender, EventArgs e)
        {
            string email = EmailTextBox.Text.Trim();
            string contraseña = ContraseniaTextBox.Text.Trim();

            // 1️⃣ Validar que ambos campos estén completos
            if (string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Debe ingresar su correo electrónico y contraseña.",
                                "Campos requeridos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                EmailTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Debe ingresar su correo electrónico.",
                                "Campo requerido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                LimpiarFormulario();
                EmailTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Debe ingresar su contraseña.",
                                "Campo requerido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                LimpiarFormulario();
                ContraseniaTextBox.Focus();
                return;
            }

            // 2️⃣ Validar formato del correo electrónico (básico)
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("El formato del correo electrónico es inválido.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                LimpiarFormulario();
                EmailTextBox.Focus();
                return;
            }

            var UsuarioValido = Modelo.ValidarUsuario(email, contraseña);

            if (UsuarioValido == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                LimpiarFormulario();
            }


            if(UsuarioValido != null)
            {
                LimpiarFormulario(); 
                MessageBox.Show("Usuario autenticado correctamente.",
                               "Acceso concedido",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            }
        }

         private void LimpiarFormulario()
        {
            EmailTextBox.Clear();
            ContraseniaTextBox.Clear();
            
        }
    }
}
