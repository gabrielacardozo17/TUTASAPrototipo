// ===============================
// EntregarEncomiendaEnAgenciaForm.cs
// Pantalla: Entrega de encomiendas en Agencia
// Flujo: igual a CD pero filtrando por Agencia actual y estado "Pendiente de entrega"
// ===============================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TUTASAPrototipo.Almacenes;

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
            UsuarioResult.Text = "Juan Perez";
            AgenciaResult.Text = "Ag. CABA Flores"; // Debe coincidir EXACTAMENTE con la Ubicacion en los datos
            NombreDestinatarioResult.Text = "";
            ApellidoDestinatarioResult.Text = "";
        }

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

            NombreDestinatarioResult.Text = destinatario.Nombre;
            ApellidoDestinatarioResult.Text = destinatario.Apellido;

            CargarGuiasPendientes(destinatario.DNI.ToString());
        }

        private void ConfirmarEntregaButton_Click(object sender, EventArgs e)
        {
            if (GuiasARecepcionarAgenciaListView.Items.Count == 0)
            {
                MessageBox.Show("No hay guías para entregar.", "Operación no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var guiasParaEntregar = new List<int>();
            foreach (ListViewItem item in GuiasARecepcionarAgenciaListView.Items)
            {
                if (int.TryParse(item.SubItems[0].Text, out int numeroGuia))
                {
                    guiasParaEntregar.Add(numeroGuia);
                }
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

        private void CargarGuiasPendientes(string dni)
        {
            string agenciaActual = AgenciaResult.Text;
            var guias = modelo.BuscarGuiasPendientes(dni, agenciaActual);

            if (guias.Count == 0)
            {
                MessageBox.Show("El destinatario no tiene encomiendas pendientes de entrega en esta agencia.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NombreDestinatarioResult.Text = "";
                ApellidoDestinatarioResult.Text = "";
                GuiasARecepcionarAgenciaListView.Items.Clear();
                DNIDestinatarioTextBox.Select();
                DNIDestinatarioTextBox.Focus();
                return;
            }

            foreach (var guia in guias)
            {
                ListViewItem item = new ListViewItem(guia.Numero.ToString());
                item.SubItems.Add(guia.Tamano.ToString());
                GuiasARecepcionarAgenciaListView.Items.Add(item);
            }
        }

        private void LimpiarCampos()
        {
            NombreDestinatarioResult.Text = "";
            ApellidoDestinatarioResult.Text = "";
            GuiasARecepcionarAgenciaListView.Items.Clear();
        }

        private void LimpiarFormularioCompleto()
        {
            DNIDestinatarioTextBox.Clear();
            LimpiarCampos();
        }
    }
}
