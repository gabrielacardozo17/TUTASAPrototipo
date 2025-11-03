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
                CuitClienteMaskedText.Focus();
                LimpiarFormulario();
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
                CuitClienteMaskedText.Focus();
                LimpiarFormulario(); 
                return;
            }

            //Valido si el periodo seleccionado es correcto
            if (PeriodoDateTimePicker.Value > DateTime.Now)
            {
                LimpiarFormulario();
                PeriodoDateTimePicker.Focus(); ;
                MessageBox.Show("El período seleccionado no es válido (futuro).",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }


            //valido que el prefijo corresponda a una persona juridica
            if (!Modelo.ValidarPrefijo(cuit))
            {
                CuitClienteMaskedText.Focus();
                LimpiarFormulario();
                MessageBox.Show("El formato de CUIT ingresado es inválido. Verifique los datos.",
                   "Error",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error
                );
            
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
                CuitClienteMaskedText.Focus();
                LimpiarFormulario();
                return;
            }

            //obtengo movimientos del modelo
            var (movimientos, saldo, tieneMovimientos, estaAlDia) = Modelo.ObtenerEstadoCuenta(cuit, año, mes);

            // Update saldo label always (even if no movements)
            SaldoAlCierre.Text = $"Saldo al cierre del período: ${saldo:N2}";

            // No hay movimientos en el período consultado y tiene deuda 
            if (!tieneMovimientos && saldo > 0)
            {
                MessageBox.Show($"El cliente no registra movimientos en el período seleccionado.\nSaldo pendiente a {new DateTime(año, mes, 1):MMMM yyyy}: ${saldo:N2}",
                  "Sin movimientos",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);

                // keep label showing saldo; do not clear it
                MovimientosListView.Items.Clear();
                return; 
            }

            // Si no hay movimientos en el periodo consultado y no tiene deuda
            if (!tieneMovimientos && saldo <= 0)
            {
                MessageBox.Show(
                    $"El cliente no registra movimientos ni deuda pendiente en {new DateTime(año, mes, 1):MMMM yyyy}.",
                    "Sin movimientos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // show saldo (0) but clear list
                MovimientosListView.Items.Clear();
                return;
            }

            // Si hay movimientos, los muestro en la lista
            foreach (var mov in movimientos)
            {
                var item = new ListViewItem(mov.Fecha.ToShortDateString());
                item.SubItems.Add(mov.Descripcion);
                item.SubItems.Add(mov.Debe.ToString("N2"));
                item.SubItems.Add(mov.Haber.ToString("N2"));
                // agregar saldo calculado
                item.SubItems.Add(mov.Saldo.ToString("N2"));
                MovimientosListView.Items.Add(item);
            }

            // actualizo el saldo mostrado (already set above, but keep in case of movements)
            SaldoAlCierre.Text = $"Saldo al cierre del período: ${saldo:N2}";

        }


        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PeriodoDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }


        private void LimpiarFormulario()
        {
            SaldoAlCierre.Text = "Saldo al cierre del período: -";
            MovimientosListView.Items.Clear();
        }
    }
}
