// TUTASAPrototipo/ConsultarEstado/ConsultarEstadoForm.cs  (REEMPLAZO TOTAL)
using System;
using System.Linq;
using System.Windows.Forms;
using TUTASAPrototipo.Almacenes;

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

            // Validaciones
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Debe ingresar un número de guía.", "Validación");
                NroGuiaBusquedaGroupBox.Focus();
                return;
            }

            // Buscar guía en el modelo
            var guia = _modelo.ObtenerPorNumero(input);
            if (guia is null)
            {
                MessageBox.Show("Número de guía no encontrado.", "Información");
                return;
            }

            // Por ahora, solo mostramos el estado actual.
            // El historial de movimientos no está implementado en el nuevo modelo.
            var item = new ListViewItem(guia.FechaAdmision.ToString("dd/MM/yyyy"));
            item.SubItems.Add(guia.Estado.ToString());
            item.SubItems.Add(guia.Ubicacion);
            HistorialGuiaListView.Items.Add(item);
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
