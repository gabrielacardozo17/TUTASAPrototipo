using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TUTASAPrototipo.ImponerEncomiendaAgencia
{
    public partial class ImponerEncomiendaAgenciaForm : Form
    {
        private ImponerEncomiendaAgenciaModelo modelo;
        private Cliente clienteSeleccionado;

        public ImponerEncomiendaAgenciaForm()
        {
            InitializeComponent();
            modelo = new ImponerEncomiendaAgenciaModelo();
        }

        private void ImponerEncomiendaAgenciaForm_Load(object sender, EventArgs e)
        {
            UsuarioResult.Text = "f.martinez";
            AgenciaResult.Text = "CABA - Flores";
            LimpiarFormulario();

            ProvinciaComboBox.Items.Clear();
            ProvinciaComboBox.Items.AddRange(modelo.GetProvinciasConCD().ToArray());
        }

        // --- MANEJADORES DE LÓGICA DINÁMICA ---

        private void ProvinciaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocalidadxProvinciaComboBox.Items.Clear();
            LocalidadxProvinciaComboBox.Text = "";
            TipoEntregaComboBox.Items.Clear();
            TipoEntregaComboBox.Text = "";
            OcultarTodosLosDestinos();

            if (ProvinciaComboBox.SelectedItem != null)
            {
                string provinciaSeleccionada = ProvinciaComboBox.SelectedItem.ToString();
                var localidades = modelo.GetLocalidadesConAgencia(provinciaSeleccionada);
                LocalidadxProvinciaComboBox.Items.AddRange(localidades.ToArray());
                LocalidadxProvinciaComboBox.Items.Add("Otras");
            }
        }

        private void LocalidadxProvinciaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoEntregaComboBox.Items.Clear();
            TipoEntregaComboBox.Text = "";
            OcultarTodosLosDestinos();

            if (LocalidadxProvinciaComboBox.SelectedItem != null)
            {
                string localidadSeleccionada = LocalidadxProvinciaComboBox.SelectedItem.ToString();
                if (localidadSeleccionada == "Otras")
                {
                    TipoEntregaComboBox.Items.Add("A domicilio");
                    TipoEntregaComboBox.Items.Add("En Centro de Distribución");
                }
                else
                {
                    TipoEntregaComboBox.Items.Add("A domicilio");
                    TipoEntregaComboBox.Items.Add("En Agencia");
                    TipoEntregaComboBox.Items.Add("En Centro de Distribución");
                }
            }
        }

        private void TipoEntregaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OcultarTodosLosDestinos();
            if (TipoEntregaComboBox.SelectedItem != null)
            {
                string tipoEntrega = TipoEntregaComboBox.SelectedItem.ToString();
                switch (tipoEntrega)
                {
                    case "A domicilio":
                        DireccionDestinatarioTextBox.Visible = true;
                        DireccionLabel.Visible = true;
                        CodigoPostalTextBox.Visible = true;
                        CodigoPostalLabel.Visible = true;
                        break;
                    case "En Agencia":
                        AgenciaComboBox.Visible = true;
                        label1.Visible = true; // "Agencia:"
                        string localidad = LocalidadxProvinciaComboBox.SelectedItem.ToString();
                        AgenciaComboBox.Items.Clear();
                        AgenciaComboBox.Items.AddRange(modelo.GetAgenciasPorLocalidad(localidad).ToArray());
                        break;
                    case "En Centro de Distribución":
                        CentroDistribucionComboBox.Visible = true;
                        CentroLabel.Visible = true; // "CD:"
                        string provincia = ProvinciaComboBox.SelectedItem.ToString();
                        CentroDistribucionComboBox.Items.Clear();
                        CentroDistribucionComboBox.Items.AddRange(modelo.GetCDsPorProvincia(provincia).ToArray());
                        break;
                }
            }
        }

        // --- MANEJADORES DE BOTONES ---

        private void BuscarCuitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CUITRemitenteMaskedText.Text) || !CUITRemitenteMaskedText.MaskCompleted)
            {
                MessageBox.Show("Debe ingresar un CUIT completo y válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clienteSeleccionado = modelo.BuscarClientePorCUIT(CUITRemitenteMaskedText.Text);
            if (clienteSeleccionado == null)
            {
                MessageBox.Show("No se encontró un cliente con el CUIT ingresado.", "Búsqueda sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarDatosCliente();
            }
            else
            {
                NombreClienteResult.Text = clienteSeleccionado.NombreRazonSocial;
                TelefonoClienteResult.Text = clienteSeleccionado.Telefono;
                DireccionClienteResult.Text = clienteSeleccionado.Direccion;
            }
        }

        private void ConfirmarImposicionButton_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
            {
                return;
            }

            var destinatario = new Destinatario
            {
                Nombre = NombreDestinatarioTextBox.Text,
                Apellido = ApellidoDestinatarioResult.Text,
                DNI = DNIDestinatarioTextBox.Text,
                Direccion = DireccionDestinatarioTextBox.Text
            };

            var cantidades = new Dictionary<Tamanio, int>
            {
                { Tamanio.S, (int)tipoSNumericUpDown.Value },
                { Tamanio.M, (int)tipoMNumericUpDown.Value },
                { Tamanio.L, (int)tipoLNumericUpDown.Value },
                { Tamanio.XL, (int)tipoXLNumericUpDown.Value }
            };

            string codigoAgencia = "011";

            var guiasGeneradas = modelo.GenerarGuias(clienteSeleccionado.CUIT, destinatario, cantidades, codigoAgencia);

            var sb = new StringBuilder();
            sb.AppendLine("Imposición confirmada. Se generaron las siguientes guías (Estado: Impuesto):");
            foreach (var guia in guiasGeneradas)
            {
                sb.AppendLine($"- {guia.NumeroGuia} (Tamaño: {guia.Tamanio})");
            }
            MessageBox.Show(sb.ToString(), "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarFormulario();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- MÉTODOS AUXILIARES ---

        private bool ValidarFormulario()
        {
            if (clienteSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un cliente válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(NombreDestinatarioTextBox.Text) || string.IsNullOrWhiteSpace(ApellidoDestinatarioResult.Text) || string.IsNullOrWhiteSpace(DNIDestinatarioTextBox.Text))
            {
                MessageBox.Show("Debe completar los datos personales del destinatario.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tipoSNumericUpDown.Value + tipoMNumericUpDown.Value + tipoLNumericUpDown.Value + tipoXLNumericUpDown.Value == 0)
            {
                MessageBox.Show("Debe ingresar al menos una encomienda.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void LimpiarDatosCliente()
        {
            NombreClienteResult.Text = "";
            TelefonoClienteResult.Text = "";
            DireccionClienteResult.Text = "";
            clienteSeleccionado = null;
        }

        private void LimpiarFormulario()
        {
            CUITRemitenteMaskedText.Clear();
            LimpiarDatosCliente();
            NombreDestinatarioTextBox.Clear();
            ApellidoDestinatarioResult.Clear();
            DNIDestinatarioTextBox.Clear();
            DireccionDestinatarioTextBox.Clear();
            tipoSNumericUpDown.Value = 0;
            tipoMNumericUpDown.Value = 0;
            tipoLNumericUpDown.Value = 0;
            tipoXLNumericUpDown.Value = 0;

            ProvinciaComboBox.SelectedIndex = -1;
            LocalidadxProvinciaComboBox.Items.Clear();
            LocalidadxProvinciaComboBox.Text = "";
            TipoEntregaComboBox.Items.Clear();
            TipoEntregaComboBox.Text = "";
            OcultarTodosLosDestinos();
        }

        private void OcultarTodosLosDestinos()
        {
            DireccionDestinatarioTextBox.Visible = false;
            DireccionLabel.Visible = false;
            CodigoPostalTextBox.Visible = false;
            CodigoPostalLabel.Visible = false;
            AgenciaComboBox.Visible = false;
            label1.Visible = false;
            CentroDistribucionComboBox.Visible = false;
            CentroLabel.Visible = false;
        }

        private void DNIDestinatarioTextBox_TextChanged(object sender, EventArgs e) { }
    }
}