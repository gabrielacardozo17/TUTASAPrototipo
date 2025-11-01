using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TUTASAPrototipo.Almacenes;

namespace TUTASAPrototipo.EntregarEncomiendaCD
{
    public partial class EntregarEncomiendaCDForm : Form
    {
        private EntregarEncomiendaCDModelo modelo;

        public EntregarEncomiendaCDForm()
        {
            InitializeComponent();
            modelo = new EntregarEncomiendaCDModelo();
        }

        private void EntregarEncomiendaCDForm_Load(object sender, EventArgs e)
        {
            // Simulación de datos de sesión con nombres realistas y consistentes con el Modelo
            UsuarioResult.Text = "Juan Perez";
            CDResult.Text = "CD CABA Oeste"; // CORREGIDO: Debe coincidir EXACTAMENTE con la Ubicacion en los datos
            NombreResultLabel.Text = "";
            ApellidoResultLabel.Text = "";
        }

        // -------------------------------------------------------------------------
        // MANEJADORES DE EVENTOS
        // -------------------------------------------------------------------------

        private void BuscarDestinararioButton_Click(object sender, EventArgs e)
        {
            // Limpiar resultados anteriores
            LimpiarCampos();

            // Validación N0: Campo requerido
            if (string.IsNullOrWhiteSpace(DNIDestinatarioTextBox.Text))
            {
                MessageBox.Show("Debe ingresar un número de DNI.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación N1: Formato (numérico)
            if (!int.TryParse(DNIDestinatarioTextBox.Text, out _))
            {
                MessageBox.Show("El DNI debe ser un valor numérico.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener datos del modelo
            string dniBuscado = DNIDestinatarioTextBox.Text;
            var destinatario = modelo.BuscarDestinatarioPorDNI(dniBuscado);

            if (destinatario == null)
            {
                MessageBox.Show("No se encontró un destinatario con el DNI ingresado.", "Búsqueda sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mostrar datos del destinatario
            NombreResultLabel.Text = destinatario.Nombre;     // CORREGIDO: Usando NombreResultLabel
            ApellidoResultLabel.Text = destinatario.Apellido; // CORREGIDO: Usando ApellidoResultLabel

            // Buscar y mostrar guías pendientes
            CargarGuiasPendientes(destinatario.DNI.ToString());
        }

        private void ConfirmarEntregaButton_Click(object sender, EventArgs e)
        {
            // Validación N2: Consistencia (debe haber guías para entregar)
            if (GuiasAEntregarCDListView.Items.Count == 0)
            {
                MessageBox.Show("No hay guías para entregar.", "Operación no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Recopilar los números de guía a entregar
            var guiasParaEntregar = new List<int>();
            foreach (ListViewItem item in GuiasAEntregarCDListView.Items)
            {
                if (int.TryParse(item.SubItems[0].Text, out int numeroGuia))
                {
                    guiasParaEntregar.Add(numeroGuia);
                }
            }

            // Confirmar entrega en el modelo
            bool exito = modelo.ConfirmarEntrega(guiasParaEntregar);

            if (exito)
            {
                MessageBox.Show("La entrega se ha registrado correctamente.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormularioCompleto(); // Esto ya limpia DNI, nombre, apellido y el listado
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
            string cdActual = CDResult.Text;
            var guias = modelo.BuscarGuiasPendientes(dni, cdActual);

            if (guias.Count == 0)
            {
                MessageBox.Show("El destinatario no tiene encomiendas pendientes de entrega en este CD.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpieza adicional solicitada cuando no hay resultados
                NombreResultLabel.Text = "";
                ApellidoResultLabel.Text = "";
                GuiasAEntregarCDListView.Items.Clear();

                // Dejar el foco en el DNI para que el usuario intente otro
                DNIDestinatarioTextBox.Select();
                DNIDestinatarioTextBox.Focus();
                return;
            }

            foreach (var guia in guias)
            {
                ListViewItem item = new ListViewItem(guia.Numero.ToString());
                item.SubItems.Add(guia.Tamano.ToString());
                GuiasAEntregarCDListView.Items.Add(item);
            }
        }


        private void LimpiarCampos()
        {
            NombreResultLabel.Text = "";   // CORREGIDO: Limpiando el label correcto
            ApellidoResultLabel.Text = ""; // CORREGIDO: Limpiando el label correcto
            GuiasAEntregarCDListView.Items.Clear();
        }

        private void LimpiarFormularioCompleto()
        {
            DNIDestinatarioTextBox.Clear();
            LimpiarCampos();
        }

        // Se ha eliminado el evento duplicado UsuarioLabel_Click que aparecía en el Designer.cs
    }
}