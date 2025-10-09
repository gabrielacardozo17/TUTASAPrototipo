using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TUTASAPrototipo.ImponerEncomiendaCallCenter
{
    public partial class ImponerEncomiendaCallCenterForm : Form
    {
        private ImponerEncomiendaCallCenterModelo modelo;

        public ImponerEncomiendaCallCenterForm()
        {
            InitializeComponent();
            modelo = new ImponerEncomiendaCallCenterModelo();
        }

        // CORREGIDO: El designer espera un método para el evento Load, lo añadimos.
        private void ImponerEncomiendaCallCenterForm_Load(object sender, EventArgs e)
        {
            LimpiarFormulario();
            PoblarProvincias();
        }

        private void BuscarCuitButton_Click(object sender, EventArgs e)
        {
            if (!CUITRemitenteMaskedText.MaskCompleted)
            {
                MessageBox.Show("Debe ingresar un CUIT completo.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var cliente = modelo.BuscarClientePorCUIT(CUITRemitenteMaskedText.Text);
            if (cliente != null)
            {
                NombreClienteResult.Text = cliente.Nombre;
                TelefonoClienteResult.Text = cliente.Telefono;
                DireccionClienteResult.Text = cliente.Direccion;
            }
            else
            {
                MessageBox.Show("Cliente no encontrado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NombreClienteResult.Text = "";
                TelefonoClienteResult.Text = "";
                DireccionClienteResult.Text = "";
            }
        }

        // CORREGIDO: El designer espera métodos vacíos para estos eventos, aunque no hagamos nada con ellos.
        private void tipoSNumericUpDown_ValueChanged(object sender, EventArgs e) { }
        private void tipoXLNumericUpDown_ValueChanged(object sender, EventArgs e) { }
        private void CodigoPostalTextBox_TextChanged(object sender, EventArgs e) { }
        private void ApellidoDestinatarioLabel_Click(object sender, EventArgs e) { }
        private void DNIDestinatarioTextBox_TextChanged(object sender, EventArgs e) { }


        private void ProvinciaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PoblarLocalidades();
        }

        private void LocalidadxProvinciaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PoblarTiposDeEntrega();
        }

        private void TipoEntregaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarVisibilidadControlesEntrega();
        }

        private void ConfirmarButton_Click(object sender, EventArgs e)
        {
            if (tipoSNumericUpDown.Value == 0 && tipoMNumericUpDown.Value == 0 && tipoLNumericUpDown.Value == 0 && tipoXLNumericUpDown.Value == 0)
            {
                MessageBox.Show("Debe imponer al menos una encomienda.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Imposición registrada correctamente. El estado de la guía es 'Impuesta'.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PoblarProvincias()
        {
            ProvinciaComboBox.Items.Clear();
            // El designer ya carga las provincias, por lo que no es necesario volver a cargarlas desde el modelo.
            // Si quisieras que se carguen desde el modelo, deberías quitar los Items del ComboBox en el diseñador.
        }

        private void PoblarLocalidades()
        {
            LocalidadxProvinciaComboBox.Items.Clear();
            if (ProvinciaComboBox.SelectedItem is string provinciaSeleccionada)
            {
                if (modelo.LocalidadesPorProvincia.ContainsKey(provinciaSeleccionada))
                {
                    LocalidadxProvinciaComboBox.Items.AddRange(modelo.LocalidadesPorProvincia[provinciaSeleccionada].ToArray());
                }
                LocalidadxProvinciaComboBox.Items.Add("Otras");
            }
            PoblarTiposDeEntrega();
        }

        private void PoblarTiposDeEntrega()
        {
            TipoEntregaComboBox.Items.Clear();
            if (LocalidadxProvinciaComboBox.SelectedItem is string localidadSeleccionada)
            {
                if (localidadSeleccionada == "Otras")
                {
                    TipoEntregaComboBox.Items.Add("A domicilio");
                    TipoEntregaComboBox.Items.Add("En CD");
                }
                else
                {
                    TipoEntregaComboBox.Items.Add("A domicilio");
                    TipoEntregaComboBox.Items.Add("En Agencia");
                    TipoEntregaComboBox.Items.Add("En CD");
                }
            }
            ActualizarVisibilidadControlesEntrega();
        }

        private void ActualizarVisibilidadControlesEntrega()
        {
            DireccionDestinatarioTextBox.Visible = false;
            CodigoPostalTextBox.Visible = false;
            AgenciaComboBox.Visible = false;
            CentroDistribucionComboBox.Visible = false;

            DireccionLabel.Visible = false;
            CodigoPostalLabel.Visible = false;
            label2.Visible = false; // Label de Agencia
            CentroLabel.Visible = false;

            switch (TipoEntregaComboBox.SelectedItem as string)
            {
                case "A domicilio":
                    DireccionDestinatarioTextBox.Visible = true;
                    CodigoPostalTextBox.Visible = true;
                    DireccionLabel.Visible = true;
                    CodigoPostalLabel.Visible = true;
                    break;
                case "En Agencia":
                    AgenciaComboBox.Visible = true;
                    label2.Visible = true;
                    PoblarAgencias();
                    break;
                case "En CD":
                    CentroDistribucionComboBox.Visible = true;
                    CentroLabel.Visible = true;
                    PoblarCDs();
                    break;
            }
        }

        private void PoblarAgencias()
        {
            AgenciaComboBox.Items.Clear();
            if (LocalidadxProvinciaComboBox.SelectedItem is string localidad)
            {
                if (modelo.AgenciasPorLocalidad.ContainsKey(localidad))
                {
                    AgenciaComboBox.Items.AddRange(modelo.AgenciasPorLocalidad[localidad].ToArray());
                }
            }
        }

        private void PoblarCDs()
        {
            CentroDistribucionComboBox.Items.Clear();
            if (ProvinciaComboBox.SelectedItem is string provincia)
            {
                if (modelo.CDsPorProvincia.ContainsKey(provincia))
                {
                    CentroDistribucionComboBox.Items.AddRange(modelo.CDsPorProvincia[provincia].ToArray());
                }
            }
        }

        private void LimpiarFormulario()
        {
            CUITRemitenteMaskedText.Clear();
            NombreClienteResult.Text = "";
            TelefonoClienteResult.Text = "";
            DireccionClienteResult.Text = "";

            NombreDestinatarioTextBox.Clear();
            ApellidoDestinatarioTextBox.Clear();
            DNIDestinatarioTextBox.Clear();

            ProvinciaComboBox.SelectedIndex = -1;
            LocalidadxProvinciaComboBox.Items.Clear();
            TipoEntregaComboBox.Items.Clear();
            AgenciaComboBox.Items.Clear();
            CentroDistribucionComboBox.Items.Clear();

            DireccionDestinatarioTextBox.Clear();
            CodigoPostalTextBox.Clear();

            ActualizarVisibilidadControlesEntrega();

            tipoSNumericUpDown.Value = 0;
            tipoMNumericUpDown.Value = 0;
            tipoLNumericUpDown.Value = 0;
            tipoXLNumericUpDown.Value = 0;
        }
    }
}