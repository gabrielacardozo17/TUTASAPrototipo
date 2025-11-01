using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.RecepcionYDespachoUltimaMillaCD
{
    public partial class RecepcionYDespachoUltimaMillaForm : Form
    {
        private readonly RecepcionYDespachoUltimaMillaCDModelo _modelo = new();

        public RecepcionYDespachoUltimaMillaForm()
        {
            InitializeComponent();
            Load += RecepcionYDespachoUltimaMillaForm_Load;
            BuscarButton.Click += BuscarButton_Click;
            ConfirmarButton.Click += ConfirmarButton_Click;
            CancelarButton.Click += (s, e) => Close();
        }

        private void RecepcionYDespachoUltimaMillaForm_Load(object sender, EventArgs e)
        {
            LimpiarPantalla();
            UsuarioResult.Text = "Juan Perez";
            CDResult.Text = "CD Córdoba Capital"; // CD de la sesión
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            LimpiarListas();
            FleteroResult.Text = "";

            if (!int.TryParse(DNIFleteroTextBox.Text, out int dni))
            {
                MessageBox.Show("El DNI debe ser un valor numérico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var fletero = _modelo.BuscarFleteroPorDni(dni);
                if (fletero == null)
                {
                    MessageBox.Show("No existe el fletero. Vuelva a intentarlo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                FleteroResult.Text = $"Fletero: {fletero.Nombre} {fletero.Apellido}";

                var (distribucion, retiro) = _modelo.GetGuiasPorFletero(dni, CDResult.Text);
                CargarListas(distribucion, retiro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ConfirmarButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(DNIFleteroTextBox.Text, out int dni))
            {
                MessageBox.Show("Debe seleccionar un transportista primero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var guiasDistribucionEntregadas = GuiasDistribucionxFleteroListView.CheckedItems.Cast<ListViewItem>().Select(item => int.Parse(item.SubItems[1].Text)).ToList();
            var guiasRetiradas = GuiasRetiroxFleteroListView.CheckedItems.Cast<ListViewItem>().Select(item => int.Parse(item.SubItems[1].Text)).ToList();

            if (guiasDistribucionEntregadas.Count == 0 && guiasRetiradas.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ninguna guía para confirmar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _modelo.ConfirmarRendicionYAsignarHDR(dni, guiasDistribucionEntregadas, guiasRetiradas, CDResult.Text);
                MessageBox.Show("Operación exitosa. Rendición confirmada y nuevas Hojas de Ruta asignadas.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarPantalla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarListas(List<GuiaEntidad> distribucion, List<GuiaEntidad> retiro)
        {
            LimpiarListas();

            // Cargar guías de distribución (las que están en el CD para salir a reparto)
            foreach (var guia in distribucion)
            {
                var item = new ListViewItem(""); // Para el checkbox
                item.SubItems.Add(guia.Numero.ToString());
                GuiasDistribucionxFleteroListView.Items.Add(item);
            }

            // Cargar guías de retiro (las que el fletero debe ir a buscar)
            foreach (var guia in retiro)
            {
                var item = new ListViewItem(""); // Para el checkbox
                item.SubItems.Add(guia.Numero.ToString());
                GuiasRetiroxFleteroListView.Items.Add(item);
            }

            // Las listas inferiores que mostraban las "nuevas" HDR ya no son necesarias
            // con el flujo simplificado. Se pueden ocultar o eliminar del diseñador.
            GuiasDistribucionProximas.Visible = false;
            groupBox1.Visible = false;
        }

        private void LimpiarListas()
        {
            GuiasDistribucionxFleteroListView.Items.Clear();
            GuiasRetiroxFleteroListView.Items.Clear();
            NuevasGuiasDistribucionxFleteroListView.Items.Clear();
            NuevasGuiasRetiroxFleteroListView.Items.Clear();
        }

        private void LimpiarPantalla()
        {
            DNIFleteroTextBox.Clear();
            FleteroResult.Text = "";
            LimpiarListas();
        }

        private void GuiasRetiroxFleteroListView_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
