using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUTASAPrototipo.Almacenes;
using TUTASAPrototipo.MenuPrincipal;
using TUTASAPrototipo.MonitoreoResultados;

namespace TUTASAPrototipo.LoginUsuario
{
    public partial class LoginUsuarioForm : Form
    {
        private readonly LoginUsuarioModelo Modelo = new(); // accedemos al modelo
        public LoginUsuarioForm()
        {
            InitializeComponent();
            // Conectar eventos que no están cableados en el diseñador
            CdActualCombo.SelectedIndexChanged += CdActualCombo_SelectedIndexChanged;
            this.FormClosing += LoginUsuarioForm_FormClosing;
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
                return;
            }

            LimpiarFormulario();
            MessageBox.Show("Usuario autenticado correctamente.",
                           "Acceso concedido",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);

            AgenciaAlmacen.AgenciaActual = AgenciaActualCombo.SelectedItem as AgenciaEntidad;
            CentroDeDistribucionAlmacen.CentroDistribucionActual = CdActualCombo.SelectedItem as CentroDeDistribucionEntidad;

            // Abrir el formulario del menú principal sin ocultar el login
            MenuPrincipalForm menuPrincipal = new MenuPrincipalForm();
            menuPrincipal.Show();
        }

        private void LimpiarFormulario()
        {
            EmailTextBox.Clear();
            ContraseniaTextBox.Clear();

        }

        private void LoginUsuarioForm_Load(object sender, EventArgs e)
        {
            CdActualCombo.DisplayMember = "Nombre";
            AgenciaActualCombo.DisplayMember = "Nombre";

            // Cargar los Centros de Distribución
            var cds = Modelo.ObtenerCentrosDeDistribucion();
            var cdItems = new List<object> { new CentroDeDistribucionEntidad { Nombre = "N/A" } };
            cdItems.AddRange(cds.OrderBy(c => c.Nombre).ToArray());
            CdActualCombo.Items.Clear();
            CdActualCombo.Items.AddRange(cdItems.ToArray());
        }

        private void CdActualCombo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // Obtener CD seleccionado (puede ser null o la opción N/A)
            var selectedCd = CdActualCombo.SelectedItem as CentroDeDistribucionEntidad;

            // Limpiar y preparar el combo de agencias
            AgenciaActualCombo.Items.Clear();
            var agenciasItems = new List<object> { new AgenciaEntidad { ID = "N/A", Nombre = "N/A" } };

            if (selectedCd != null && selectedCd.Nombre != "N/A")
            {
                // Filtrar agencias por el CD seleccionado usando el modelo
                var filtradas = Modelo.ObtenerAgenciasPorCD(selectedCd.CodigoPostal);
                if (filtradas.Any())
                {
                    agenciasItems.AddRange(filtradas.OrderBy(a => a.Nombre).Cast<object>().ToArray());
                }
            }

            // Replegar el combo con las agencias filtradas (o solo N/A)
            AgenciaActualCombo.Items.AddRange(agenciasItems.ToArray());
            AgenciaActualCombo.SelectedIndex = -1; // permitir seleccionar
        }

        private void LoginUsuarioForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
