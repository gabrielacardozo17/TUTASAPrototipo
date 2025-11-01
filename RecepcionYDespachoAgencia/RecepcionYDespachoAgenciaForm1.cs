using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.RecepcionYDespachoAgencia
{
    public partial class RecepcionYDespachoAgenciaForm1 : Form
    {
        private readonly RecepcionYDespachoAgenciaModelo _modelo = new RecepcionYDespachoAgenciaModelo();

        public RecepcionYDespachoAgenciaForm1()
        {
            InitializeComponent();
            try { ConfirmarButton.BringToFront(); CancelarButton.BringToFront(); } catch { }
            NombreUsuarioLabel.Text = "Juan Perez";
            NombreAgenciaLabel.Text = "Agencia CABA Centro"; // Agencia de la sesión
            NombreResultLabel.Text = "";
            ApellidoResultLabel.Text = "";
            LimpiarFormulario();
        }

        private void RecepcionAgenciaForm1_Load(object? sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void UsuarioLabel_Click(object? sender, EventArgs e) { }

        private void BuscarxDNIFleteroButton_Click(object? sender, EventArgs e)
        {
            var dniTexto = DNIFleteroTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(dniTexto))
            {
                MessageBox.Show("Debe ingresar un número de DNI", "Validación");
                DNIFleteroTextBox.Clear();
                DNIFleteroTextBox.Focus();
                return;
            }

            if (!int.TryParse(dniTexto, out int dni))
            {
                MessageBox.Show("Debe ingresar un número entero positivo", "Validación");
                DNIFleteroTextBox.Clear();
                DNIFleteroTextBox.Focus();
                return;
            }
            if (dniTexto.Length < 7 || dniTexto.Length > 8)
            {
                MessageBox.Show("Debe ingresar un número que contenga entre 7 y 8 caracteres", "Validación");
                DNIFleteroTextBox.Clear();
                DNIFleteroTextBox.Focus();
                return;
            }

            try
            {
                var fletero = _modelo.BuscarFleteroPorDni(dni);
                if (fletero == null)
                {
                    MessageBox.Show("No existe el fletero. Vuelva a intentarlo.", "Validación");
                    DNIFleteroTextBox.Clear();
                    DNIFleteroTextBox.Focus();
                    NombreResultLabel.Text = "";
                    ApellidoResultLabel.Text = "";
                    return;
                }

                NombreResultLabel.Text = fletero.Nombre;
                ApellidoResultLabel.Text = fletero.Apellido;

                var (aRecepcionar, aDespachar) = _modelo.GetGuiasPorFletero(dni, NombreAgenciaLabel.Text);
                CargarListas(aRecepcionar, aDespachar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación");
                LimpiarFormulario();
            }
        }

        private void ConfirmarButton_Click(object? sender, EventArgs e)
        {
            var dniTexto = DNIFleteroTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(dniTexto) || !int.TryParse(dniTexto, out int dni))
            {
                MessageBox.Show("Debe seleccionar un transportista primero", "Validación");
                DNIFleteroTextBox.Clear();
                DNIFleteroTextBox.Focus();
                return;
            }

            var recibidas = new List<int>();
            foreach (ListViewItem it in GuiasARecepcionarAgenciaListView.Items)
                if (it.Checked) recibidas.Add(int.Parse(it.Text));

            var despachadas = new List<int>();
            foreach (ListViewItem it in GuiasAEntregarListView.Items)
                if (it.Checked) despachadas.Add(int.Parse(it.Text));

            try
            {
                _modelo.ConfirmarOperacion(dni, recibidas, despachadas, NombreAgenciaLabel.Text);
                MessageBox.Show("Operación confirmada. Estados actualizados.", "Recepción en Agencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación");
            }
        }

        private void CargarListas(IEnumerable<GuiaEntidad> aRecepcionar, IEnumerable<GuiaEntidad> aDespachar)
        {
            GuiasARecepcionarAgenciaListView.FullRowSelect = true;
            GuiasAEntregarListView.FullRowSelect = true;

            GuiasARecepcionarAgenciaListView.Items.Clear();
            GuiasAEntregarListView.Items.Clear();

            foreach (var g in aRecepcionar)
            {
                var li = new ListViewItem(g.Numero.ToString());
                li.SubItems.Add(g.Tamano.ToString());
                GuiasARecepcionarAgenciaListView.Items.Add(li);
            }

            foreach (var g in aDespachar)
            {
                var li = new ListViewItem(g.Numero.ToString());
                li.SubItems.Add(g.Tamano.ToString());
                li.SubItems.Add(g.Ubicacion);
                GuiasAEntregarListView.Items.Add(li);
            }
        }

        private void LimpiarFormulario()
        {
            DNIFleteroTextBox.Clear();
            NombreResultLabel.Text = "";
            ApellidoResultLabel.Text = "";
            GuiasARecepcionarAgenciaListView.Items.Clear();
            GuiasAEntregarListView.Items.Clear();
            try
            {
                ConfirmarButton.Visible = true; ConfirmarButton.Enabled = true; ConfirmarButton.BringToFront();
                CancelarButton.Visible = true; CancelarButton.Enabled = true; CancelarButton.BringToFront();
                ConfirmarButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                CancelarButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            }
            catch { }
        }

        private void RecepcionYDespachoAgenciaForm1_Load(object sender, EventArgs e) { }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GuiasAEntregarListView_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
