using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TUTASAPrototipo.RecepcionAgencia
{
    public partial class RecepcionAgenciaForm1 : Form
    {
        private readonly RecepcionAgenciaModelo _modelo = new RecepcionAgenciaModelo();

        public RecepcionAgenciaForm1()
        {
            InitializeComponent();

            // No duplicamos eventos que ya cablea el Designer:
            // BuscarxDNIFleteroButton.Click += BuscarxDNIFleteroButton_Click;
            // ConfirmarButton.Click += ConfirmarButton_Click;

            // Solo agregamos Cancelar si existe:
            try { CancelarButton.Click += (s, e) => LimpiarFormulario(); } catch { }

            // Fix visual (por si quedan detrás de groupboxes)
            try { ConfirmarButton.BringToFront(); CancelarButton.BringToFront(); } catch { }

            LimpiarFormulario();
        }

        // ---------- LOAD ----------
        private void RecepcionAgenciaForm1_Load(object? sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        // ---------- CLICK USUARIO (Designer lo exige) ----------
        private void UsuarioLabel_Click(object? sender, EventArgs e)
        {
            // no-op (stub para satisfacer el hook del Designer)
        }

        // ---------- BUSCAR ----------
        private void BuscarxDNIFleteroButton_Click(object? sender, EventArgs e)
        {
            var dniTexto = DNIFleteroTextBox.Text.Trim();

            // N0–N2: requerido, numérico, longitud (7–8)
            if (string.IsNullOrWhiteSpace(dniTexto) || !int.TryParse(dniTexto, out int dni))
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
                // N3–N4 en el Modelo
                var (aRecepcionar, aEntregar) = _modelo.GetGuiasPorFletero(dni);
                CargarListas(aRecepcionar, aEntregar);

                var f = _modelo.BuscarFleteroPorDni(dni);
                NombreUsuarioLabel.Text = f is null ? "" : f.Nombre;

                // Texto fijo de agencia (solo visual del TP)
                NombreAgenciaLabel.Text = "Agencia Córdoba Norte";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación");
                LimpiarFormulario();
            }
        }

        // ---------- CONFIRMAR ----------
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

            // Tomar marcadas (CheckBoxes) en cada lista
            var recibidas = new List<string>();
            foreach (ListViewItem it in GuiasARecepcionarAgenciaListView.Items)
                if (it.Checked) recibidas.Add(it.Text);

            var entregadas = new List<string>();
            foreach (ListViewItem it in GuiasAEntregarListView.Items)
                if (it.Checked) entregadas.Add(it.Text);

            try
            {
                _modelo.ConfirmarOperacion(dni, recibidas, entregadas);

                MessageBox.Show("Operación confirmada. Estados actualizados.", "Recepción en Agencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación");
            }
        }

        // ---------- HELPERS VISUALES ----------
        private void CargarListas(IEnumerable<Guia> aRecepcionar, IEnumerable<Guia> aEntregar)
        {
            // Asegurar que el usuario pueda "marcar" lo que procesó
            GuiasARecepcionarAgenciaListView.CheckBoxes = true;
            GuiasAEntregarListView.CheckBoxes = true;
            GuiasARecepcionarAgenciaListView.FullRowSelect = true;
            GuiasAEntregarListView.FullRowSelect = true;

            GuiasARecepcionarAgenciaListView.Items.Clear();
            GuiasAEntregarListView.Items.Clear();

            foreach (var g in aRecepcionar)
            {
                var li = new ListViewItem(g.Numero); // Col 0: Nro Guía
                li.SubItems.Add(g.Tamaño);           // Col 1: Tamaño
                GuiasARecepcionarAgenciaListView.Items.Add(li);
            }

            foreach (var g in aEntregar)
            {
                var li = new ListViewItem(g.Numero);
                li.SubItems.Add(g.Tamaño);
                // No hay columna Destino en el designer; si querés lo agregamos en Tag:
                li.Tag = g.Destino;
                GuiasAEntregarListView.Items.Add(li);
            }
        }

        private void LimpiarFormulario()
        {
            DNIFleteroTextBox.Clear();
            NombreUsuarioLabel.Text = "";
            // Dejá "Agencia:" fijo en AgenciaLabel; NombreAgenciaLabel arranca vacío
            NombreAgenciaLabel.Text = "";

            GuiasARecepcionarAgenciaListView.Items.Clear();
            GuiasAEntregarListView.Items.Clear();

            // Visibilidad/orden y anclado de botones
            try
            {
                ConfirmarButton.Visible = true; ConfirmarButton.Enabled = true; ConfirmarButton.BringToFront();
                CancelarButton.Visible = true; CancelarButton.Enabled = true; CancelarButton.BringToFront();

                ConfirmarButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                CancelarButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            }
            catch { }
        }
    }
}
