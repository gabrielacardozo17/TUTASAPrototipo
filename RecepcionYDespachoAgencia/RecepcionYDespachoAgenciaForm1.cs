using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TUTASAPrototipo.Almacenes;
using TUTASAPrototipo;

namespace TUTASAPrototipo.RecepcionYDespachoAgencia
{
    public partial class RecepcionYDespachoAgenciaForm1 : Form
    {
        private readonly RecepcionYDespachoAgenciaModelo _modelo = new RecepcionYDespachoAgenciaModelo();

        public RecepcionYDespachoAgenciaForm1()
        {
            InitializeComponent();

            // Fix visual
            try { ConfirmarButton.BringToFront(); CancelarButton.BringToFront(); } catch { }

            // Encabezado dinámico
            NombreUsuarioLabel.Text = "Juan Perez"; // usuario mock
            var agenciaNombre = AgenciaAlmacen.AgenciaActual?.Nombre
                                 ?? AgenciaAlmacen.agencias.FirstOrDefault(a => a.CodigoPostalCD == CentroDeDistribucionAlmacen.CentroDistribucionActual?.CodigoPostal)?.Nombre
                                 ?? "Agencia N/A";
            NombreAgenciaLabel.Text = agenciaNombre; // nombre de agencia, no del CD

            // Inicializar labels de búsqueda como vacíos
            NombreResultLabel.Text = "";
            ApellidoResultLabel.Text = "";

            LimpiarFormulario();
        }
        private void BuscarxDNIFleteroButton_Click(object? sender, EventArgs e)
        {
            var dniTexto = DNIFleteroTextBox.Text.Trim();

            // N0–N2: requerido, numérico, longitud (7–8)
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
                // N3: Buscar fletero 
                var (existe, nombre, apellido) = _modelo.ObtenerDatosFletero(dni);
                if (!existe)
                {
                    MessageBox.Show("No existe el fletero. Vuelva a intentarlo.", "Validación");
                    DNIFleteroTextBox.Clear();
                    DNIFleteroTextBox.Focus();
                    NombreResultLabel.Text = "";
                    ApellidoResultLabel.Text = "";
                    return;
                }

                // Mostrar nombre y apellido del fletero en los labels
                NombreResultLabel.Text = nombre;
                ApellidoResultLabel.Text = apellido;

                // N4: Obtener guías del fletero 
                var (aRecepcionar, aEntregar) = _modelo.ObtenerGuiasPorFletero(dni);
                CargarListas(aRecepcionar, aEntregar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación");
                LimpiarFormulario();
            }
        }

        //  CONFIRMAR 
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

            // Tomar TODAS las guías listadas en cada lista (sin checkboxes)
            var recibidas = new List<string>();
            foreach (ListViewItem it in GuiasARecepcionarAgenciaListView.Items)
                recibidas.Add(it.Text);

            var entregadas = new List<string>();
            foreach (ListViewItem it in GuiasAEntregarListView.Items)
                entregadas.Add(it.Text);

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

        // -
        private void CargarListas(IEnumerable<GuiaDTO> aRecepcionar, IEnumerable<GuiaDTO> aEntregar)
        {
            GuiasARecepcionarAgenciaListView.FullRowSelect = true;
            GuiasAEntregarListView.FullRowSelect = true;

            GuiasARecepcionarAgenciaListView.Items.Clear();
            GuiasAEntregarListView.Items.Clear();

            // RECEPCIÓN: solo número y tamaño (ubicación actual está vacía porque están en ruta)
            foreach (var g in aRecepcionar)
            {
                var li = new ListViewItem(g.NumeroGuia.ToString());
                li.SubItems.Add(g.Tamano.ToString());
                GuiasARecepcionarAgenciaListView.Items.Add(li);
            }

            // DESPACHO: número, tamaño y ubicación actual (donde está físicamente la guía)
            foreach (var g in aEntregar)
            {
                var li = new ListViewItem(g.NumeroGuia.ToString());
                li.SubItems.Add(g.Tamano.ToString());
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

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
