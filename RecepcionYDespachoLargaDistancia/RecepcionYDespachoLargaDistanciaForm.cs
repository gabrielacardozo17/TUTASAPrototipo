using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TUTASAPrototipo.RecepcionYDespachoLargaDistancia
{
    public partial class RecepcionYDespachoLargaDistanciaForm : Form
    {
        private readonly RecepcionYDespachoLargaDistanciaModelo _modelo = new();

        // Reemplazar el constructor en RecepcionYDespachoLargaDistanciaForm.cs

        public RecepcionYDespachoLargaDistanciaForm()
        {
            InitializeComponent();

            // NOTA: Eliminamos las asignaciones manuales de eventos aquí.
            // La conexión debe realizarse ÚNICAMENTE en la ventana de propiedades del Diseñador.

            CDResult.Text = "CD CABA Oeste";
            UsuarioResult.Text = "p.gonzalez";

            // Configuraciones visuales
            GuiaxServicioRecibidaListView.CheckBoxes = true;
            GuiasADespacharxServicioListView.CheckBoxes = true;
        }

        // Reemplazar este método en RecepcionYDespachoLargaDistanciaForm.cs

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            LimpiarPantalla();
            string nroServicio = NumServicioTextBox.Text.Trim(); // .Trim() para limpiar espacios del input

            if (string.IsNullOrWhiteSpace(nroServicio))
            {
                MessageBox.Show("Debe ingresar el número de servicio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // El modelo ahora es tolerante al buscar
            if (!_modelo.ExisteServicio(nroServicio))
            {
                MessageBox.Show("No existe ese servicio. Vuelva a intentarlo.", "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MostrarResultados(nroServicio);
        }

        private void MostrarResultados(string nroServicio)
        {
            var resultados = _modelo.BuscarGuiasPorServicio(nroServicio);

            foreach (var guia in resultados.aRecibir)
            {
                var item = new ListViewItem(guia.NroGuia);
                item.SubItems.Add(guia.Tamano);
                GuiaxServicioRecibidaListView.Items.Add(item);
            }

            foreach (var guia in resultados.aDespachar)
            {
                var item = new ListViewItem(guia.NroGuia);
                item.SubItems.Add(guia.Tamano);
                item.SubItems.Add(guia.Destino);
                GuiasADespacharxServicioListView.Items.Add(item);
            }
        }

        private void ConfirmarButton_Click(object sender, EventArgs e)
        {
            if (GuiaxServicioRecibidaListView.Items.Count == 0 && GuiasADespacharxServicioListView.Items.Count == 0)
            {
                MessageBox.Show("No hay guías cargadas para procesar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (ListViewItem item in GuiaxServicioRecibidaListView.Items)
            {
                _modelo.ActualizarEstadoGuia(item.Text, item.Checked ? "En CD destino" : "No Recibida");
            }

            foreach (ListViewItem item in GuiasADespacharxServicioListView.Items)
            {
                _modelo.ActualizarEstadoGuia(item.Text, item.Checked ? "En tránsito al CD destino" : "No Despachada");
            }

            MessageBox.Show("Operación finalizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarPantalla();
        }

        private void SalirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarPantalla()
        {
            NumServicioTextBox.Clear();
            GuiaxServicioRecibidaListView.Items.Clear();
            GuiasADespacharxServicioListView.Items.Clear();
        }

        private void NumServicioTextBox_TextChanged(object sender, EventArgs e) { }
    }
}