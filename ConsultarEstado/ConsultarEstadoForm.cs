// TUTASAPrototipo/ConsultarEstado/ConsultarEstadoForm.cs  (REEMPLAZO TOTAL)
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TUTASAPrototipo.ConsultarEstado
{
    public partial class ConsultarEstadoForm : Form
    {
        private readonly ConsultarEstadoModelo _modelo = new();

        public ConsultarEstadoForm()
        {
            InitializeComponent();   // ← sin esto, el form queda vacío

            // Config inicial de la UI
            HistorialGuiaListView.FullRowSelect = true;
            HistorialGuiaListView.MultiSelect = false;
            HistorialGuiaListView.View = View.Details;
            HistorialGuiaListView.GridLines = true;
            HistorialGuiaListView.HideSelection = false;
            HistorialGuiaListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            // Eventos principales
            BuscarEstadoGuiaButton.Click += BuscarEstadoGuiaButton_Click;
            CancelarButton.Click += CancelarButton_Click;

            // Estado inicial limpio
            HistorialGuiaListView.Items.Clear();
            NroGuiaBusquedaGroupBox.Clear();
        }

        // --- Helper ---
        private static string Digits(string s) => new string((s ?? "").Where(char.IsDigit).ToArray());

        // --- EVENTO: BOTÓN BUSCAR ---
        private void BuscarEstadoGuiaButton_Click(object? sender, EventArgs e)
        {
            HistorialGuiaListView.Items.Clear();

            var input = NroGuiaBusquedaGroupBox.Text?.Trim() ?? "";

            // Validaciones N0–N2 (nuevo formato TLLLNNNNN: 9 dígitos)
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Debe ingresar el número de guía.", "Validación");
                NroGuiaBusquedaGroupBox.Focus();
                return;
            }

            var digits = Digits(input);

            // Solo números
            if (!Regex.IsMatch(digits, @"^\d+$"))
            {
                MessageBox.Show("Debe ingresar un número entero positivo.", "Validación");
                return;
            }

            // Exactamente 9 dígitos: TLLLNNNNN
            if (!Regex.IsMatch(digits, @"^\d{9}$"))
            {
                MessageBox.Show("Número de guía inválido (debe tener 9 dígitos TLLLNNNNN).", "Validación");
                return;
            }

            // Buscar guía en el modelo (archivo en memoria)
            var guia = _modelo.ObtenerPorNumero(digits);
            if (guia is null)
            {
                MessageBox.Show("Número de guía no encontrado.", "Información");
                return;
            }

            // Mostrar resultado en el ListView (Fecha, Estado, Ubicación)
            foreach (var mov in guia.Historial.OrderBy(m => m.Fecha))
            {
                var item = new ListViewItem(mov.Fecha.ToString("dd/MM/yyyy"));
                item.SubItems.Add(mov.Estado.ToString());
                item.SubItems.Add(mov.Ubicacion);
                HistorialGuiaListView.Items.Add(item);
            }

            // Si el último movimiento no coincide con el estado actual, lo agrega
            if (guia.Historial.Count == 0
                || guia.Historial.Last().Estado != guia.EstadoActual
                || guia.Historial.Last().Ubicacion != guia.UbicacionActual)
            {
                var actual = new ListViewItem(DateTime.Now.ToString("dd/MM/yyyy"));
                actual.SubItems.Add(guia.EstadoActual.ToString());
                actual.SubItems.Add(guia.UbicacionActual);
                HistorialGuiaListView.Items.Add(actual);
            }
        }

        // --- EVENTO: BOTÓN SALIR / CANCELAR ---
        private void CancelarButton_Click(object? sender, EventArgs e)
        {
            NroGuiaBusquedaGroupBox.Clear();
            HistorialGuiaListView.Items.Clear();
            Close();
        }
    }
}
