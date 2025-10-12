using System;
using System.Windows.Forms;

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
            CDResult.Text = "Cordoba";

            // Deshabilitamos los controles que dependen de una búsqueda exitosa
            GuiasGroupBox.Enabled = false;
            // NOTA: Este control es un GroupBox aunque su nombre sugiera ser una ListView. Lo usamos tal cual está en el Designer.
            GuiasADespacharServicioListView.Enabled = false;
            ConfirmarRecepcionYDespachoButton.Enabled = false;
            NumServicioTextBox.Clear();
            LimpiarListViews();
            NumServicioTextBox.Focus();

            // Deshabilitar checkboxes en los ListView
            GuiaxServicioRecibidaListView.CheckBoxes = false;
            GuiasADespacharxServicioListView.CheckBoxes = false;
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

            // Llamamos al modelo para realizar la búsqueda
            var servicioEncontrado = modelo.BuscarServicio(numeroServicio);

            if (servicioEncontrado != null)
            {
                PoblarListViews(servicioEncontrado);
                // Habilitamos controles después de una búsqueda exitosa
                GuiasGroupBox.Enabled = true;
                GuiasADespacharServicioListView.Enabled = true; // Habilitamos el GroupBox de "Acciones"
                ConfirmarRecepcionYDespachoButton.Enabled = true;
            }
            else
            {
                MessageBox.Show("No se encontró un servicio con el número ingresado. Vuelva a intentarlo.", "Búsqueda sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Deshabilitamos los controles y limpiamos si la búsqueda falla
                InicializarFormulario();
            }
        }

        private void PoblarListViews(ServicioTransporte servicio)
        {
            LimpiarListViews();

            // Llenar ListView de Guías a Recibir (nombre del designer: GuiaxServicioRecibidaListView)
            foreach (var guia in servicio.GuiasARecibir)
            {
                var item = new ListViewItem(guia.NroGuia);
                item.SubItems.Add(guia.Tamanio);
                GuiaxServicioRecibidaListView.Items.Add(item);
            }

            // Llenar ListView de Guías a Despachar (nombre del designer: GuiasADespacharxServicioListView)
            foreach (var guia in servicio.GuiasADespachar)
            {
                var item = new ListViewItem(guia.NroGuia);
                item.SubItems.Add(guia.Tamanio);
                item.SubItems.Add(guia.Destino);
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
            string numeroServicio = NumServicioTextBox.Text.Trim();

            if (GuiaxServicioRecibidaListView.Items.Count == 0 && GuiasADespacharxServicioListView.Items.Count == 0)
            {
                MessageBox.Show("No hay encomiendas para recibir o despachar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var guiasRecibidas = GuiaxServicioRecibidaListView.Items.Cast<ListViewItem>().Select(item => item.Text).ToList();
            var guiasDespachadas = GuiasADespacharxServicioListView.Items.Cast<ListViewItem>().Select(item => item.Text).ToList();

            // Marcar guías como procesadas en el modelo
            modelo.MarcarGuiasProcesadas(numeroServicio, guiasRecibidas, guiasDespachadas);

            // Asignar automáticamente guías pendientes si hay disponibles
            int cantidadPendientes = modelo.ObtenerCantidadGuiasPendientes();
            if (cantidadPendientes > 0)
            {
                modelo.AsignarGuiasPendientes(numeroServicio);
            }

            MessageBox.Show("Recepción y despacho confirmados con éxito.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            InicializarFormulario(); // Reiniciamos el formulario a su estado inicial
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrepararListViews()
        {
            GuiaxServicioRecibidaListView.CheckBoxes = false;
            GuiasADespacharxServicioListView.CheckBoxes = false;
        }
    }
}