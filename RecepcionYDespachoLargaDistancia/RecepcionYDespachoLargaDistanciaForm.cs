using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.RecepcionYDespachoLargaDistancia
{
    public partial class RecepcionYDespachoLargaDistanciaForm : Form
    {
        private RecepcionYDespachoLargaDistanciaModelo modelo;

        public RecepcionYDespachoLargaDistanciaForm()
        {
            InitializeComponent();
            modelo = new RecepcionYDespachoLargaDistanciaModelo();
            InicializarFormulario();
        }

        private void InicializarFormulario()
        {
            // Establecemos valores fijos para el prototipo
            UsuarioResult.Text = "Juan Perez";
            CDResult.Text = "CD Córdoba Capital"; // CD de la sesión

            // Deshabilitamos los controles que dependen de una búsqueda exitosa
            GuiasGroupBox.Enabled = false;
            GuiasADespacharServicioListView.Enabled = false;
            ConfirmarRecepcionYDespachoButton.Enabled = false;
            NumServicioTextBox.Clear();
            LimpiarListViews();
            NumServicioTextBox.Focus();
            GuiaxServicioRecibidaListView.CheckBoxes = true;
            GuiasADespacharxServicioListView.CheckBoxes = true;
        }

        private void BuscarServicioButton_Click(object sender, EventArgs e)
        {
            // Validación Nivel 0-2: Entrada del usuario en el Form
            string numeroServicio = NumServicioTextBox.Text.Trim();

            if (string.IsNullOrEmpty(numeroServicio))
            {
                MessageBox.Show("Debe ingresar el número de servicio.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Llamamos al modelo para realizar la búsqueda
                var servicioEncontrado = modelo.BuscarServicio(numeroServicio);

                if (servicioEncontrado == null)
                {
                    MessageBox.Show("No se encontró un servicio con el número ingresado. Vuelva a intentarlo.", "Búsqueda sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InicializarFormulario();
                    return;
                }

                var (aRecepcionar, aDespachar) = modelo.GetGuiasPorServicio(servicioEncontrado.Id, CDResult.Text);
                PoblarListViews(aRecepcionar, aDespachar);

                // Habilitamos controles después de una búsqueda exitosa
                GuiasGroupBox.Enabled = true;
                GuiasADespacharServicioListView.Enabled = true; // Habilitamos el GroupBox de "Acciones"
                ConfirmarRecepcionYDespachoButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InicializarFormulario();
            }
        }

        private void PoblarListViews(List<GuiaEntidad> aRecepcionar, List<GuiaEntidad> aDespachar)
        {
            LimpiarListViews();

            // Llenar ListView de Guías a Recibir (nombre del designer: GuiaxServicioRecibidaListView)
            foreach (var guia in aRecepcionar)
            {
                var item = new ListViewItem(guia.Numero.ToString());
                item.SubItems.Add(guia.Tamano.ToString());
                GuiaxServicioRecibidaListView.Items.Add(item);
            }

            // Llenar ListView de Guías a Despachar (nombre del designer: GuiasADespacharxServicioListView)
            foreach (var guia in aDespachar)
            {
                var item = new ListViewItem(guia.Numero.ToString());
                item.SubItems.Add(guia.Tamano.ToString());
                item.SubItems.Add(guia.CentroDistribucionDestino?.Nombre ?? "N/A");
                GuiasADespacharxServicioListView.Items.Add(item);
            }
        }

        private void LimpiarListViews()
        {
            GuiaxServicioRecibidaListView.Items.Clear();
            GuiasADespacharxServicioListView.Items.Clear();
        }

        private void ConfirmarRecepcionYDespachoButton_Click(object sender, EventArgs e)
        {
            string numeroServicioStr = NumServicioTextBox.Text.Trim();
            if (!int.TryParse(numeroServicioStr, out int numeroServicio))
            {
                MessageBox.Show("El número de servicio no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var guiasRecibidas = GuiaxServicioRecibidaListView.CheckedItems.Cast<ListViewItem>().Select(item => int.Parse(item.Text)).ToList();
            var guiasDespachadas = GuiasADespacharxServicioListView.CheckedItems.Cast<ListViewItem>().Select(item => int.Parse(item.Text)).ToList();

            if (guiasRecibidas.Count == 0 && guiasDespachadas.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ninguna encomienda para recibir o despachar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Confirmar operaciones de recepción y despacho
                modelo.ConfirmarOperacion(numeroServicio, guiasRecibidas, guiasDespachadas, CDResult.Text);
                MessageBox.Show("Recepción y despacho confirmados con éxito.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InicializarFormulario(); // Reiniciamos el formulario a su estado inicial
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}