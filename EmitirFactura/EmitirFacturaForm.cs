// TUTASAPrototipo/EmitirFactura/EmitirFacturaForm.cs  (REEMPLAZO TOTAL)
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TUTASAPrototipo.EmitirFactura
{
    public partial class EmitirFacturaForm : Form
    {
        private readonly EmitirFacturaModelo _modelo = new();

        // Estado de UI (no de negocio)
        private bool _clienteValidado = false;
        private string _cuitValidadoDigits = "";

        // Guards anti doble ejecución
        private bool _busyBuscar = false;
        private bool _busyEmitir = false;

        public EmitirFacturaForm()
        {
            InitializeComponent();

            // Validaciones automáticas desactivadas (hacemos N0–N2 manual)
            this.AutoValidate = AutoValidate.Disable;

            // --- MaskedText CUIT ---
            CuitClienteMaskedText.Mask = "00-00000000-0";
            CuitClienteMaskedText.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // Text solo dígitos
            CuitClienteMaskedText.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            CuitClienteMaskedText.ResetOnPrompt = true;
            CuitClienteMaskedText.ResetOnSpace = true;
            CuitClienteMaskedText.AsciiOnly = true;

            // Si editan el CUIT, se limpia el resultado previo
            CuitClienteMaskedText.TextChanged += (s, e) =>
            {
                _clienteValidado = false;
                _cuitValidadoDigits = "";
                DetalleFacturaciónListView.Items.Clear();
                MontoTotalLabel.Text = "";
            };

            // --- ListView (solo lectura y aspecto) ---
            DetalleFacturaciónListView.FullRowSelect = true;
            DetalleFacturaciónListView.MultiSelect = false;
            DetalleFacturaciónListView.View = View.Details;
            DetalleFacturaciónListView.GridLines = true;
            DetalleFacturaciónListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            // --- Botones ---
            // El Designer YA cablea EmitirFacturaButton.Click → EmitirFacturaButton_Click
            // Para evitar duplicados, NO volvemos a suscribir acá.
            BuscarFacturasButton.Click -= BuscarFacturasButton_Click;
            BuscarFacturasButton.Click += BuscarFacturasButton_Click;

            CancelarButton.Click -= CancelarButton_Click;
            CancelarButton.Click += CancelarButton_Click;

            // Estado inicial limpio
            LimpiarPantalla();

            // Según caso de uso, Emitir debe poder clickease siempre;
            // si no hay cliente validado, mostramos el mensaje correspondiente.
            EmitirFacturaButton.Enabled = true;
        }

        // ----------------- Helpers de UI -----------------
        private static string Digits(string s) => new string((s ?? "").Where(char.IsDigit).ToArray());
        private static bool SoloNumeros(string s) => Regex.IsMatch(s ?? "", @"^\d+$");

        private void LimpiarPantalla()
        {
            _clienteValidado = false;
            _cuitValidadoDigits = "";
            CuitClienteMaskedText.Clear();
            DetalleFacturaciónListView.Items.Clear();
            MontoTotalLabel.Text = "";
        }

        private void CargarLineas(System.Collections.Generic.IEnumerable<Guia> guias)
        {
            DetalleFacturaciónListView.Items.Clear();
            foreach (var g in guias)
            {
                var it = new ListViewItem(g.Numero);
                it.SubItems.Add(g.FechaAdmision.ToString("dd/MM/yyyy"));
                it.SubItems.Add(g.Origen);
                it.SubItems.Add(g.Destino);
                it.SubItems.Add(g.Tamano.ToString());
                it.SubItems.Add($"${g.Importe:N2}");
                DetalleFacturaciónListView.Items.Add(it);
            }
        }

        // ----------------- Buscar (N0–N2 en Form; N3–N4 en Modelo) -----------------
        private void BuscarFacturasButton_Click(object? sender, EventArgs e)
        {
            if (_busyBuscar) return;
            _busyBuscar = true;
            try
            {
                DetalleFacturaciónListView.Items.Clear();
                MontoTotalLabel.Text = "";
                _clienteValidado = false;
                _cuitValidadoDigits = "";

                // Con TextMaskFormat=ExcludePromptAndLiterals, Text trae solo dígitos
                var digits = CuitClienteMaskedText.Text ?? "";

                // N0: requerido
                if (string.IsNullOrWhiteSpace(digits))
                { MessageBox.Show("Debe completar el campo CUIT.", "Validación"); CuitClienteMaskedText.Focus(); return; }

                // N1: numérico
                if (!SoloNumeros(digits))
                { MessageBox.Show("Debe ingresar un numero.", "Validación"); CuitClienteMaskedText.Focus(); return; }

                // N2: exactamente 11 dígitos
                if (digits.Length != 11)
                { MessageBox.Show("El CUIT debe tener 11 dígitos.", "Validación"); CuitClienteMaskedText.Focus(); return; }

                try
                {
                    var (cli, pendientes) = _modelo.BuscarPorCuit(digits);

                    CargarLineas(pendientes);
                    var total = pendientes.Sum(g => g.Importe);
                    MontoTotalLabel.Text = $"${total:N2}";

                    _clienteValidado = true;
                    _cuitValidadoDigits = digits;
                }
                catch (Exception ex)
                {
                    // Mensajes exactos del caso de uso (N3–N4)
                    MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            finally
            {
                _busyBuscar = false;
            }
        }

        // ----------------- Emitir Factura -----------------
        // ATENCIÓN: este método ya está cableado desde el Designer.
        private void EmitirFacturaButton_Click(object? sender, EventArgs e)
        {
            if (_busyEmitir) return;
            _busyEmitir = true;
            EmitirFacturaButton.Enabled = false;
            try
            {
                if (!_clienteValidado)
                {
                    // Caso 6.3 / 6.4 del CU: sin CUIT validado, no se emite
                    MessageBox.Show("Debe ingresar el CUIT del cliente antes de emitir la factura.", "Validación");
                    return;
                }

                try
                {
                    var factura = _modelo.EmitirFactura(_cuitValidadoDigits);

                    MessageBox.Show(
                    $"Operación finalizada con éxito.\nFactura {factura.Numero} emitida y registrada en la cuenta corriente del cliente.",
                     "Emitir Factura",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information
 );

                    LimpiarPantalla();
                }
                catch (Exception ex)
                {
                    // Incluye: “No es posible emitir una factura por $0.”
                    MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            finally
            {
                _busyEmitir = false;
                EmitirFacturaButton.Enabled = true;
            }
        }

        private void CancelarButton_Click(object? sender, EventArgs e)
        {
            LimpiarPantalla();
            Close();
        }
    }
}
