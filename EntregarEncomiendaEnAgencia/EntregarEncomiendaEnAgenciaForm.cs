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
            UsuarioResult.Text = "f.martinez";
            AgenciaResult.Text = "Ag. 1011";
            // CORREGIDO: Usando los nombres de control que existen en tu diseñador.
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

            // CORRECCIÓN FINAL Y DEFINITIVA: Usando los nombres de control que existen en tu diseñador.
            NombreDestinatarioResult.Text = destinatario.Nombre;
            ApellidoDestinatarioResult.Text = destinatario.Apellido;

            CargarGuiasPendientes(destinatario.DNI);
        }

        private void ConfirmarEntregaButton_Click(object sender, EventArgs e)
        {
            // CORREGIDO: Usando el nombre correcto del ListView: GuiasARecepcionarAgenciaListView
            if (GuiasARecepcionarAgenciaListView.Items.Count == 0)
            {
                MessageBox.Show("No hay encomiendas seleccionadas para entregar.", "Operación no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var guiasParaEntregar = new List<string>();
            foreach (ListViewItem item in GuiasARecepcionarAgenciaListView.Items)
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
                    // CORREGIDO: Usando el nombre correcto del ListView
                    GuiasARecepcionarAgenciaListView.Items.Add(item);
                }
            }
        }

        private void LimpiarCampos()
        {
            // CORREGIDO: Usando los nombres de control correctos que existen en tu diseñador.
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