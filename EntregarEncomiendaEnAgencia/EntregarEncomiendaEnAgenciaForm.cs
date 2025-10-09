using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TUTASAPrototipo.EntregarEncomiendaEnAgencia
{
    public partial class EntregarEncomiendaEnAgenciaForm : Form
    {
        private EntregarEncomiendaEnAgenciaModelo modelo;

        public EntregarEncomiendaEnAgenciaForm()
        {
            InitializeComponent();
            modelo = new EntregarEncomiendaEnAgenciaModelo();
        }

        private void EntregarEncomiendaEnAgenciaForm_Load(object sender, EventArgs e)
        {
            // Simulación de datos de sesión
            UsuarioResult.Text = "Silvio Caraccia";
            AgenciaResult.Text = "Florida Locutorio"; // Agencia actual
            NombreDestinatarioResult.Text = ""; // CORREGIDO
            ApellidoDestinatarioResult.Text = ""; // CORREGIDO
        }

        // MANEJADORES DE EVENTOS...

        private void BuscarDestinararioButton_Click(object sender, EventArgs e)
        {
            LimpiarCampos();

            if (string.IsNullOrWhiteSpace(DNIDestinatarioTextBox.Text))
            {
                MessageBox.Show("Debe ingresar un número de DNI.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!long.TryParse(DNIDestinatarioTextBox.Text, out _))
            {
                MessageBox.Show("El DNI debe ser un valor numérico.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string dniBuscado = DNIDestinatarioTextBox.Text;
            var destinatario = modelo.BuscarDestinatarioPorDNI(dniBuscado);

            if (destinatario == null)
            {
                MessageBox.Show("No se encontró un destinatario con el DNI ingresado.", "Búsqueda sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            NombreDestinatarioResult.Text = destinatario.Nombre; // CORREGIDO
            ApellidoDestinatarioResult.Text = destinatario.Apellido; // CORREGIDO
            CargarGuiasPendientes(destinatario.DNI);
        }

        private void ConfirmarEntregaButton_Click(object sender, EventArgs e)
        {
            if (GuiasARecepcionarAgenciaListView.Items.Count == 0) // CORREGIDO
            {
                MessageBox.Show("No hay encomiendas seleccionadas para entregar.", "Operación no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var guiasParaEntregar = new List<string>();
            foreach (ListViewItem item in GuiasARecepcionarAgenciaListView.Items) // CORREGIDO
            {
                guiasParaEntregar.Add(item.SubItems[0].Text);
            }

            bool exito = modelo.ConfirmarEntrega(guiasParaEntregar);

            if (exito)
            {
                MessageBox.Show("La entrega se ha registrado correctamente.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormularioCompleto();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al registrar la entrega.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // MÉTODOS AUXILIARES...

        private void CargarGuiasPendientes(string dni)
        {
            string agenciaActual = AgenciaResult.Text;
            var guias = modelo.BuscarGuiasPendientes(dni, agenciaActual);

            if (guias.Count == 0)
            {
                MessageBox.Show("El destinatario no tiene encomiendas pendientes de retiro en esta agencia.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (var guia in guias)
                {
                    ListViewItem item = new ListViewItem(guia.NumeroGuia);
                    item.SubItems.Add(guia.Tamanio.ToString());
                    GuiasARecepcionarAgenciaListView.Items.Add(item); // CORREGIDO
                }
            }
        }

        private void LimpiarCampos()
        {
            NombreDestinatarioResult.Text = ""; // CORREGIDO
            ApellidoDestinatarioResult.Text = ""; // CORREGIDO
            GuiasARecepcionarAgenciaListView.Items.Clear(); // CORREGIDO
        }

        private void LimpiarFormularioCompleto()
        {
            DNIDestinatarioTextBox.Clear();
            LimpiarCampos();
        }
    }
}