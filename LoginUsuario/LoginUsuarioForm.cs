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

            // Validar selección: debe haber AL MENOS un item seleccionado explícitamente en uno de los combos.
            // Aceptamos que el usuario seleccione "N/A" en uno de ellos; no persistimos nada.
            var selectedCd = CdActualCombo.SelectedItem as CentroDeDistribucionEntidad;
            var selectedAg = AgenciaActualCombo.SelectedItem as AgenciaEntidad;

            bool cdSelected = selectedCd != null;
            bool agSelected = selectedAg != null;

            if (!cdSelected && !agSelected)
            {
                MessageBox.Show("Debe seleccionar al menos un Centro de Distribución o una Agencia (o marcar N/A en uno de ellos).",
                               "Selección requerida",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return;
            }

            // Setear globals solo si hay selección; si no, no se setea
            if (selectedCd != null && !string.Equals(selectedCd.Nombre, "N/A", StringComparison.OrdinalIgnoreCase))
                CentroDeDistribucionAlmacen.CentroDistribucionActual = selectedCd;
            if (selectedAg != null && !string.Equals(selectedAg.Nombre, "N/A", StringComparison.OrdinalIgnoreCase))
                AgenciaAlmacen.AgenciaActual = selectedAg;

            LimpiarFormulario();
            MessageBox.Show("Usuario autenticado correctamente.",
                           "Acceso concedido",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);

            // Abrir menú principal pasando la selección (sin persistir en ningún almacen)
            using var menu = new MenuPrincipalForm(selectedCd, selectedAg);
            menu.ShowDialog();
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

            // Agregar N/A como opción - sin tocar almacenes ni guardar nada
            var cds = new List<object> { new CentroDeDistribucionEntidad { CodigoPostal = 0, Nombre = "N/A", Direccion = string.Empty } };
            cds.AddRange(CentroDeDistribucionAlmacen.centrosDeDistribucion.OrderBy(c => c.Nombre));
            CdActualCombo.Items.AddRange(cds.ToArray());

            // Inicialmente mostrar todas las agencias + N/A
            var ags = new List<object> { new AgenciaEntidad { ID = "N/A", Nombre = "N/A", Direccion = string.Empty, CodigoPostal = 0, CodigoPostalCD = 0 } };
            ags.AddRange(AgenciaAlmacen.agencias.OrderBy(a => a.Nombre));
            AgenciaActualCombo.Items.AddRange(ags.ToArray());

            // Por defecto dejar sin selección (el usuario elegirá)
            CdActualCombo.SelectedIndex = -1;
            AgenciaActualCombo.SelectedIndex = -1;

            // Wire up event to filter agencies when a CD is selected
            CdActualCombo.SelectedIndexChanged += CdActualCombo_SelectedIndexChanged;
        }

        private void CdActualCombo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // Obtener CD seleccionado (puede ser null o la opción N/A)
            var selectedCd = CdActualCombo.SelectedItem as CentroDeDistribucionEntidad;

            // Preparar lista inicial con la opción N/A
            var agenciasItems = new List<object> { new AgenciaEntidad { ID = "N/A", Nombre = "N/A", Direccion = string.Empty, CodigoPostal = 0, CodigoPostalCD = 0 } };

            if (selectedCd == null)
            {
                // No hay CD seleccionado -> mostrar todas las agencias
                agenciasItems.AddRange(AgenciaAlmacen.agencias.OrderBy(a => a.Nombre));
            }
            else if (selectedCd.Nombre == "N/A")
            {
                // Si seleccionó N/A en CD, dejamos solo N/A en agencias
                // (si prefieres mostrar todas, cambia esta rama para agregar todas).
            }
            else
            {
                // Filtrar agencias por CodigoPostalCD == CodigoPostal del CD seleccionado
                var filtradas = AgenciaAlmacen.agencias
                    .Where(a => a.CodigoPostalCD == selectedCd.CodigoPostal)
                    .OrderBy(a => a.Nombre)
                    .Cast<object>()
                    .ToList();

                if (filtradas.Any())
                {
                    agenciasItems.AddRange(filtradas);
                }
                // Si no hay agencias para ese CD, dejamos solo N/A (puedes cambiar a mostrar todas si lo prefieres)
            }

            // Replegar el combo con las agencias filtradas
            AgenciaActualCombo.Items.Clear();
            AgenciaActualCombo.Items.AddRange(agenciasItems.ToArray());
            AgenciaActualCombo.SelectedIndex = -1;
        }
    }
}
