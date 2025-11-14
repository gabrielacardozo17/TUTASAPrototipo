using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TUTASAPrototipo.Almacenes;
using TUTASAPrototipo;

namespace TUTASAPrototipo.EntregarEncomiendaEnAgencia
{
    public partial class EntregarEncomiendaEnAgenciaForm : Form
    {
        // Seguir patrón de otros forms: modelo readonly inicializado inline
        private readonly EntregarEncomiendaEnAgenciaModelo modelo = new EntregarEncomiendaEnAgenciaModelo();

        public EntregarEncomiendaEnAgenciaForm()
        {
            InitializeComponent();

            // Wiring consistente de eventos (igual que en otros forms del proyecto)
            Load -= EntregarEncomiendaEnAgenciaForm_Load;
            Load += EntregarEncomiendaEnAgenciaForm_Load;

            BuscarDestinararioButton.Click -= BuscarDestinararioButton_Click;
            BuscarDestinararioButton.Click += BuscarDestinararioButton_Click;

            ConfirmarEntregaButton.Click -= ConfirmarEntregaButton_Click;
            ConfirmarEntregaButton.Click += ConfirmarEntregaButton_Click;

            CancelarButton.Click -= CancelarButton_Click;
            CancelarButton.Click += CancelarButton_Click;
        }
        private void EntregarEncomiendaEnAgenciaForm_Load(object sender, EventArgs e)
        {
            // Seguir patrón: mostrar usuario de prototipo y tomar agencia desde el almacen global si existe
            UsuarioResult.Text = "Juan Perez";

            // Fuente de verdad para la agencia: primero AgenciaAlmacen, si no usar lo que haya en el label o "N/A"
            AgenciaResult.Text = !string.IsNullOrWhiteSpace(AgenciaAlmacen.AgenciaActual?.Nombre)
                ? AgenciaAlmacen.AgenciaActual!.Nombre
                : (string.IsNullOrWhiteSpace(AgenciaResult.Text) ? "N/A" : AgenciaResult.Text);

            NombreDestinatarioResult.Text = "";
            ApellidoDestinatarioResult.Text = "";
        }

        // EVENTOS

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

            CargarGuiasPendientes(destinatario.DNI);
        }

        private void ConfirmarEntregaButton_Click(object sender, EventArgs e)
        {
            if (GuiasARecepcionarAgenciaListView.Items.Count == 0)
            {
                MessageBox.Show("Debe ingresar un número de DNI.", "Operación no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            // Tomar la agencia desde la fuente de verdad: label o el almacen global como fallback
            string agenciaActual = AgenciaResult.Text;
            if (string.IsNullOrWhiteSpace(agenciaActual) || string.Equals(agenciaActual, "N/A", StringComparison.OrdinalIgnoreCase))
            {
                agenciaActual = AgenciaAlmacen.AgenciaActual?.Nombre ?? agenciaActual;
            }

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

            GuiasARecepcionarAgenciaListView.Items.Clear();
            foreach (var guia in guias)
            {
                ListViewItem item = new ListViewItem(guia.NumeroGuia);
                item.SubItems.Add(guia.Tamanio.ToString());
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
