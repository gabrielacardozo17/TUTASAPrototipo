using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TUTASAPrototipo.EstadoCuentaCorrienteCliente
{
    public partial class EstadoCuentaCorrienteClienteForm : Form
    {
        private readonly EstadoCuentaCorrienteClienteModelo Modelo = new();
        public EstadoCuentaCorrienteClienteForm()
        {
            InitializeComponent();
            //PeriodoDateTimePicker.MaxDate = DateTime.Today;  // Limitar al mes actual (no permito seleccionar fechas futuras)
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DesdeDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void BuscarClienteButton_Click(object sender, EventArgs e)
        {
            MovimientosListView.Items.Clear();
            string cuit = new string(CuitClienteMaskedText.Text.Where(char.IsDigit).ToArray());
            int año = PeriodoDateTimePicker.Value.Year;
            int mes = PeriodoDateTimePicker.Value.Month;


            // Valido que el usuario ingrese el CUIT
            if (string.IsNullOrWhiteSpace(cuit))
            {
                MessageBox.Show("El campo CUIT es requerido.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                CuitClienteMaskedText.Clear();
                CuitClienteMaskedText.Focus();
                return;
            }

            //valido que el CUIT tenga longitud correcta
            if (cuit.Length != 11)
            {
                MessageBox.Show("El formato de CUIT ingresado es inválido. Verifique los datos.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                CuitClienteMaskedText.Clear();
                CuitClienteMaskedText.Focus();
                return;
            }

            //Valido si el periodo seleccionado es correcto
            if (PeriodoDateTimePicker.Value > DateTime.Now)
            {
                SaldoAlCierre.Text = "Saldo al cierre del período: -";
                MessageBox.Show("El período seleccionado no es válido (futuro).",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }


            //valido que el prefijo corresponda a una persona juridica
            if (!Modelo.ValidarPrefijo(cuit))
            {
                MessageBox.Show("El formato de CUIT ingresado es inválido. Verifique los datos.",
                   "Error",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error
                );
                CuitClienteMaskedText.Clear();
                CuitClienteMaskedText.Focus();
                return;
            }



            // valido si el cliente existe 
            if (!Modelo.ClienteExiste(cuit))
            {
                MessageBox.Show("No se encontró un cliente con el CUIT ingresado.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                CuitClienteMaskedText.Clear();
                CuitClienteMaskedText.Focus();
                return;
            }


            //envío los datos al modelo, para obtener los movimientos
            var movimientos = Modelo.ObtenerMovimientos(cuit, año, mes);

            //Si no hay movimientos en el periodo indicado, muestro mensaje 
            if (movimientos == null || movimientos.Count == 0)
            {
                SaldoAlCierre.Text = "Saldo al cierre del período: -";
                MessageBox.Show("El cliente no registra movimientos en el período seleccionado",
                    "Sin movimientos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CuitClienteMaskedText.Clear();
                
                MovimientosListView.Items.Clear();
                return;
            }


            //si hay movimientos
            foreach (var mov in movimientos)
            {
                var item = new ListViewItem(mov.Fecha.ToShortDateString());
                item.SubItems.Add(mov.Descripcion);
                item.SubItems.Add(mov.Debe.ToString("N2"));
                item.SubItems.Add(mov.Haber.ToString("N2"));
                MovimientosListView.Items.Add(item);
            }


            //obtengo el saldo
            var saldo = Modelo.CalcularSaldoAlCierre(cuit, año, mes);
            SaldoAlCierre.Text = $"Saldo al cierre del período: ${saldo:N2}";
        }
           

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PeriodoDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
