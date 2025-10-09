using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TUTASAPrototipo.RecepcionYDespachoUltimaMillaCD
{
    public partial class RecepcionYDespachoUltimaMillaForm : Form
    {
        private readonly RecepcionYDespachoUltimaMillaCDModelo _modelo = new RecepcionYDespachoUltimaMillaCDModelo();

        public RecepcionYDespachoUltimaMillaForm()
        {
            InitializeComponent();

            // Eventos (no duplicamos Confirmar: ya lo engancha el Designer)
            Load += Form_Load;
            BuscarButton.Click += BuscarButton_Click;

            // Si existe Cancelar, solo limpiar la UI (sin cerrar app)
            try { CancelarButton.Click += (s, e) => LimpiarFormulario(); } catch { }

            // Asegurar que los botones no queden detrás de los groupboxes
            try { ConfirmarButton.BringToFront(); CancelarButton.BringToFront(); } catch { }

            LimpiarFormulario();
        }

        // ---------- LOAD ----------
        private void Form_Load(object sender, EventArgs e)
        {
            LimpiarFormulario();

            // Visibilidad/orden y anclado de botones
            try
            {
                ConfirmarButton.Visible = true;
                ConfirmarButton.Enabled = true;
                ConfirmarButton.BringToFront();
                ConfirmarButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                CancelarButton.Visible = true;
                CancelarButton.Enabled = true;
                CancelarButton.BringToFront();
                CancelarButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            }
            catch { }
        }

        // ---------- BUSCAR ----------
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            var dniTexto = DNIFleteroTextBox.Text.Trim();

            // N0–N2: requerido / numérico / longitud
            if (string.IsNullOrWhiteSpace(dniTexto) || !int.TryParse(dniTexto, out int dni))
            {
                MessageBox.Show("Debe ingresar un número entero positivo.", "Validación");
                DNIFleteroTextBox.Clear();   // ✔ CP4.3: limpiar campo ante no numérico
                DNIFleteroTextBox.Focus();
                return;
            }
            if (dniTexto.Length < 7 || dniTexto.Length > 8)
            {
                MessageBox.Show("Debe ingresar un número que contenga entre 7 y 8 caracteres.", "Validación");
                DNIFleteroTextBox.Clear();   // ✔ CP4.4: limpiar campo ante longitud inválida
                DNIFleteroTextBox.Focus();
                return;
            }

            try
            {
                var guias = _modelo.GetGuiasPorFletero(dni); // N3–N4 en el Modelo
                CargarGuiasEnListas(guias);

                var f = _modelo.BuscarFleteroPorDni(dni);
                UsuarioResult.Text = f is null ? "" : $"Usuario: {f.Nombre}";

                // No duplicamos "CD:" (eso lo tiene el label fijo del Designer)
                CDResult.Text = "Córdoba Capital";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación");
                LimpiarFormulario();
            }
        }

        // ---------- CONFIRMAR ----------
        private void ConfirmarButton_Click(object sender, EventArgs e)
        {
            var texto = DNIFleteroTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(texto) || !int.TryParse(texto, out int dni))
            {
                MessageBox.Show("Debe ingresar un DNI válido antes de confirmar.", "Validación");
                DNIFleteroTextBox.Clear();   // Consistencia con CP4.3/4.4
                DNIFleteroTextBox.Focus();
                return;
            }

            var guiasCumplidas = new List<string>();
            foreach (ListViewItem it in GuiasDistribucionxFleteroListView.Items)
                if (it.Checked) guiasCumplidas.Add(it.Text);
            foreach (ListViewItem it in GuiasRetiroxFleteroListView.Items)
                if (it.Checked) guiasCumplidas.Add(it.Text);

            try
            {
                var nuevas = _modelo.ConfirmarRendicion(dni, guiasCumplidas); // N3–N4
                CargarNuevasHDR(nuevas);

                MessageBox.Show(
                    "Rendición confirmada. Se generó el comprobante de rendición y nuevas HDR para el fletero seleccionado.",
                    "Operación exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación");
            }
        }

        // Hook que dejó el Designer (si está enlazado)
        private void GuiasRetiroxFleteroListView_SelectedIndexChanged(object sender, EventArgs e) { /* no-op */ }

        // ---------- HELPERS VISUALES ----------
        private void CargarGuiasEnListas(IEnumerable<Guia> guias)
        {
            GuiasDistribucionxFleteroListView.Items.Clear();
            GuiasRetiroxFleteroListView.Items.Clear();

            foreach (var g in guias)
            {
                var item = new ListViewItem(g.Numero);
                if (g.Tipo == TipoGuia.Distribucion)
                    GuiasDistribucionxFleteroListView.Items.Add(item);
                else
                    GuiasRetiroxFleteroListView.Items.Add(item);
            }
        }

        private void CargarNuevasHDR(IEnumerable<Guia> nuevas)
        {
            NuevasGuiasRetiroxFleteroListView.Items.Clear();
            NuevasGuiasDistribucionxFleteroListView.Items.Clear(); // este prototipo no la usa

            foreach (var g in nuevas)
            {
                var item = new ListViewItem(g.Numero);
                item.SubItems.Add(g.Tamaño);
                item.SubItems.Add(g.Destino);
                NuevasGuiasRetiroxFleteroListView.Items.Add(item);
            }
        }

        private void LimpiarFormulario()
        {
            DNIFleteroTextBox.Clear();
            UsuarioResult.Text = "";
            CDResult.Text = "";

            GuiasDistribucionxFleteroListView.Items.Clear();
            GuiasRetiroxFleteroListView.Items.Clear();
            NuevasGuiasRetiroxFleteroListView.Items.Clear();
            NuevasGuiasDistribucionxFleteroListView.Items.Clear();
        }
    }
}
