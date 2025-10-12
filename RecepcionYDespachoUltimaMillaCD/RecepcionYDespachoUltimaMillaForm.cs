using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TUTASAPrototipo.RecepcionYDespachoUltimaMillaCD
{
    public partial class RecepcionYDespachoUltimaMillaForm : Form
    {
        private readonly RecepcionYDespachoUltimaMillaCDModelo _modelo = new();
        private bool _enRevision = false;
        private int? _dniEnRevision = null;

        public RecepcionYDespachoUltimaMillaForm()
        {
            InitializeComponent();

            // Evitar doble cableado si el Designer ya lo tenía
            Load -= RecepcionYDespachoUltimaMillaForm_Load;
            Load += RecepcionYDespachoUltimaMillaForm_Load;

            BuscarButton.Click -= BuscarButton_Click;
            BuscarButton.Click += BuscarButton_Click;

            ConfirmarButton.Click -= ConfirmarButton_Click;
            ConfirmarButton.Click += ConfirmarButton_Click;

            CancelarButton.Click -= CancelarButton_Click;
            CancelarButton.Click += CancelarButton_Click;

            UsuarioResult.Text = "Juan Perez";
            CDResult.Text = "Buenos Aires";

            // Renombrar groupboxes según negocio (texto provisto)
            try
            {
                // Textos exactos pedidos
                GuiasGroupBox.Text = "Detalle de guias de HDR de distribucion asignadas:";
                groupBox2.Text = "Detalle de guias de HDR de retiro asignadas: ";
            }
            catch { }
            PrepararListViews();
        }

        // ====== LOAD ======
        private void RecepcionYDespachoUltimaMillaForm_Load(object sender, EventArgs e)
        {
            _enRevision = false;
            _dniEnRevision = null;
            LimpiarPantalla(total: true);
            MostrarSeccionBusquedaYListasSuperiores(true);

            if (FindLabel("FleteroResult") is Label fle)
            {
                fle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                fle.Text = string.Empty;
            }
        }

        // ====== BUSCAR ======
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            _enRevision = false;
            _dniEnRevision = null;

            var dniTxt = (DNIFleteroTextBox.Text ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(dniTxt))
            { MessageBox.Show("Debe seleccionar un transportista primero", "Validación"); DNIFleteroTextBox.Focus(); return; }
            if (!dniTxt.All(char.IsDigit))
            { MessageBox.Show("Debe ingresar un número entero positivo", "Validación"); DNIFleteroTextBox.Clear(); DNIFleteroTextBox.Focus(); return; }
            if (dniTxt.Length < 7 || dniTxt.Length > 8)
            { MessageBox.Show("Debe ingresar un número que contenga entre 7 y 8 caracteres", "Validación"); DNIFleteroTextBox.Clear(); DNIFleteroTextBox.Focus(); return; }

            int dni = int.Parse(dniTxt);
            var fletero = _modelo.BuscarFleteroPorDni(dni);
            if (fletero is null)
            {
                MessageBox.Show("No existe el fletero. Vuelva a intentarlo", "Validación");
                DNIFleteroTextBox.Clear(); DNIFleteroTextBox.Focus();
                LimpiarListas(); PintarNombreFletero(string.Empty);
                return;
            }

            PintarNombreFletero(fletero.Nombre);

            // Asegurar HDRs para que las grillas muestren HDR ya al terminar la búsqueda
            _modelo.AsegurarHDRsAsignadasParaFletero(dni);

            // Cargar guías asignadas (listas superiores) y también las "nuevas" (resumen HDR) para que se vean inmediatamente
            CargarAsignadas(dni);
            CargarResumenPosterior(dni);

            MostrarSeccionBusquedaYListasSuperiores(true);
        }

        // ====== CONFIRMAR (ahora 1 paso: aplica y muestra popup) ======
        private void ConfirmarButton_Click(object sender, EventArgs e)
        {
            var dniTxt = (DNIFleteroTextBox.Text ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(dniTxt) || !dniTxt.All(char.IsDigit) || dniTxt.Length < 7 || dniTxt.Length > 8)
            {
                MessageBox.Show("Debe seleccionar un transportista primero", "Validación"); DNIFleteroTextBox.Focus(); return;
            }

            int dni = int.Parse(dniTxt);

            // Capturar ANTES de modificar el modelo: guías seleccionadas por HDR (para mostrar en el popup)
            var recibidasDistPorHdr  = SeleccionadasPorHDR(GuiasDistribucionxFleteroListView);
            var recibidasRetiroPorHdr = SeleccionadasPorHDR(GuiasRetiroxFleteroListView);

            // Listas planas para confirmar en el modelo
            var marcadasDistrib = recibidasDistPorHdr.SelectMany(kv => kv.Value).ToList();
            var marcadasRetiro  = recibidasRetiroPorHdr.SelectMany(kv => kv.Value).ToList();

            try
            {
                _modelo.ConfirmarRendicion(dni, marcadasDistrib, marcadasRetiro);
                _modelo.AsignarHDRsPorDireccion(dni);
                _modelo.AsegurarHDRsAsignadasParaFletero(dni);

                // Recargar para que las secciones de "asignadas" reflejen la situación final
                CargarAsignadas(dni);
                CargarResumenPosterior(dni);

                // Construir el mensaje EXACTO solicitado
                string msg =
                    "Operacion exitosa. Rendicion confirmada." + Environment.NewLine +
                    Environment.NewLine +
                    "HDR de distribucion recibidas: " + Environment.NewLine +
                    FormatearGrupos(recibidasDistPorHdr) + Environment.NewLine + Environment.NewLine +
                    "HDR de retiro recibidas: " + Environment.NewLine +
                    FormatearGrupos(recibidasRetiroPorHdr) + Environment.NewLine + Environment.NewLine +
                    "HDR de distribucion asignadas: " + Environment.NewLine +
                    ConstruirAsignadasSoloLineas(NuevasGuiasDistribucionxFleteroListView) + Environment.NewLine + Environment.NewLine +
                    "HDR de retiro asignadas: " + Environment.NewLine +
                    ConstruirAsignadasSoloLineas(NuevasGuiasRetiroxFleteroListView);

                MessageBox.Show(msg, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _enRevision = false;
                _dniEnRevision = null;
                LimpiarPantalla(total: true);
                MostrarSeccionBusquedaYListasSuperiores(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación");
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e) => Close();

        // ====== CARGA DE LISTAS ======
        private void CargarAsignadas(int dni)
        {
            AsegurarColumnaHDR(GuiasDistribucionxFleteroListView);
            AsegurarColumnaHDR(GuiasRetiroxFleteroListView);

            GuiasDistribucionxFleteroListView.Items.Clear();
            GuiasRetiroxFleteroListView.Items.Clear();

            var t = _modelo.GetGuiasPorFletero(dni);
            foreach (var g in t.distribucion)
            {
                var it = new ListViewItem("") { Checked = false };
                it.SubItems.Add(g.Numero);
                it.SubItems.Add(g.NroHDR ?? "");
                GuiasDistribucionxFleteroListView.Items.Add(it);
            }
            foreach (var g in t.retiro)
            {
                var it = new ListViewItem("") { Checked = false };
                it.SubItems.Add(g.Numero);
                it.SubItems.Add(g.NroHDR ?? "");
                GuiasRetiroxFleteroListView.Items.Add(it);
            }
        }

        private void CargarResumenPosterior(int dni)
        {
            AsegurarColumnasNuevas(NuevasGuiasRetiroxFleteroListView);
            AsegurarColumnasNuevas(NuevasGuiasDistribucionxFleteroListView);

            NuevasGuiasRetiroxFleteroListView.Items.Clear();
            NuevasGuiasDistribucionxFleteroListView.Items.Clear();

            var t = _modelo.GetGuiasPorFletero(dni);
            foreach (var g in t.retiro)
            {
                var it = new ListViewItem(g.Numero);
                it.SubItems.Add(g.Tamaño);
                it.SubItems.Add(g.Destino);
                it.SubItems.Add(g.NroHDR ?? "");
                NuevasGuiasRetiroxFleteroListView.Items.Add(it);
            }
            foreach (var g in t.distribucion)
            {
                var it = new ListViewItem(g.Numero);
                it.SubItems.Add(g.Tamaño);
                it.SubItems.Add(g.Destino);
                it.SubItems.Add(g.NroHDR ?? "");
                NuevasGuiasDistribucionxFleteroListView.Items.Add(it);
            }
        }

        // ====== HELPERS UI ======
        private void PrepararListViews()
        {
            GuiasDistribucionxFleteroListView.CheckBoxes = true;
            GuiasRetiroxFleteroListView.CheckBoxes = true;

            AsegurarColumnaHDR(GuiasDistribucionxFleteroListView);
            AsegurarColumnaHDR(GuiasRetiroxFleteroListView);

            AsegurarColumnasNuevas(NuevasGuiasRetiroxFleteroListView);
            AsegurarColumnasNuevas(NuevasGuiasDistribucionxFleteroListView);
        }

        private static void AsegurarColumnaHDR(ListView lv)
        {
            if (!lv.Columns.Cast<ColumnHeader>().Any(c => c.Text.Equals("HDR", StringComparison.OrdinalIgnoreCase)))
                lv.Columns.Add(new ColumnHeader { Text = "HDR", Width = 160 });
        }

        private static void AsegurarColumnasNuevas(ListView lv)
        {
            if (lv.Columns.Count < 3)
            {
                lv.Columns.Clear();
                lv.Columns.Add(new ColumnHeader { Text = "Nro de Guía", Width = 200 });
                lv.Columns.Add(new ColumnHeader { Text = "Tamaño", Width = 80 });
                lv.Columns.Add(new ColumnHeader { Text = "Destino", Width = 220 });
            }
            if (!lv.Columns.Cast<ColumnHeader>().Any(c => c.Text.Equals("HDR", StringComparison.OrdinalIgnoreCase)))
                lv.Columns.Add(new ColumnHeader { Text = "HDR", Width = 200 });
        }

        private static List<string> GuiasMarcadas(ListView lv)
        {
            var res = new List<string>();
            foreach (ListViewItem it in lv.Items)
                if (it.Checked && it.SubItems.Count > 1)
                    res.Add(it.SubItems[1].Text);
            return res;
        }

        // ====== HELPERS (popup) ======

        // Recibidas: toma SOLO las marcadas en los listviews superiores y agrupa por HDR (columna 2)
        private static string ConstruirSeccionRecibidasPorHDR(ListView lv, string titulo)
        {
            var grupos = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

            foreach (ListViewItem it in lv.Items)
            {
                if (!it.Checked) continue;
                // superiores: [0]=chk, [1]=Guia, [2]=HDR
                string guia = it.SubItems.Count > 1 ? it.SubItems[1].Text?.Trim() ?? "" : "";
                string hdr = it.SubItems.Count > 2 ? it.SubItems[2].Text?.Trim() ?? "" : "";
                if (string.IsNullOrEmpty(guia)) continue;
                if (string.IsNullOrWhiteSpace(hdr)) hdr = "(sin HDR)";
                if (!grupos.TryGetValue(hdr, out var lst)) { lst = new List<string>(); grupos[hdr] = lst; }
                lst.Add(guia);
            }

            var lineas = new List<string> { titulo };
            foreach (var kv in grupos.OrderBy(k => k.Key))
                lineas.Add($"- HDR {kv.Key} con guías {(kv.Value.Count == 0 ? "(sin guías)" : string.Join(", ", kv.Value))}");
            return string.Join(Environment.NewLine, lineas);
        }

        // Asignadas: usa los listviews inferiores ya cargados con NroGuia,Tamaño,Destino,HDR (HDR en subíndice 3)
        private static string ConstruirSeccionAsignadasPorHDR(ListView lv, string titulo)
        {
            var grupos = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

            foreach (ListViewItem it in lv.Items)
            {
                // inferiores: [0]=Guia, [1]=Tamaño, [2]=Destino, [3]=HDR
                if (it.SubItems.Count < 4) continue;
                string guia = it.SubItems[0].Text?.Trim() ?? "";
                string hdr = it.SubItems[3].Text?.Trim() ?? "";
                if (string.IsNullOrEmpty(guia)) continue;
                if (string.IsNullOrWhiteSpace(hdr)) hdr = "(sin HDR)";
                if (!grupos.TryGetValue(hdr, out var lst)) { lst = new List<string>(); grupos[hdr] = lst; }
                lst.Add(guia);
            }

            var lineas = new List<string> { titulo };
            foreach (var kv in grupos.OrderBy(k => k.Key))
                lineas.Add($"- HDR {kv.Key} con guías {(kv.Value.Count == 0 ? "(sin guías)" : string.Join(", ", kv.Value))}");
            return string.Join(Environment.NewLine, lineas);
        }

        // Helper: agrupa las guías seleccionadas (checked) por HDR usando las listas superiores.
        private static Dictionary<string, List<string>> SeleccionadasPorHDR(ListView lv)
        {
            var grupos = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            foreach (ListViewItem it in lv.Items)
            {
                if (!it.Checked) continue;                       // solo las marcadas como recibidas
                string guia = it.SubItems.Count > 1 ? it.SubItems[1].Text?.Trim() ?? "" : "";
                string hdr  = it.SubItems.Count > 2 ? it.SubItems[2].Text?.Trim() ?? "" : "";
                if (string.IsNullOrEmpty(guia)) continue;
                if (string.IsNullOrWhiteSpace(hdr)) hdr = "(sin HDR)";
                if (!grupos.TryGetValue(hdr, out var lst)) { lst = new List<string>(); grupos[hdr] = lst; }
                lst.Add(guia);
            }
            return grupos;
        }

        // Helper: formatea grupos HDR -> guías como líneas "- HDR X con guías ..."
        private static string FormatearGrupos(Dictionary<string, List<string>> grupos)
        {
            if (grupos.Count == 0) return "(ninguna)";
            var lineas = new List<string>();
            foreach (var kv in grupos.OrderBy(k => k.Key))
                lineas.Add($"- HDR {kv.Key} con guías {(kv.Value.Count == 0 ? "(sin guías)" : string.Join(", ", kv.Value))}");
            return string.Join(Environment.NewLine, lineas);
        }

        // Helper: para las listas inferiores (asignadas) devuelve solo líneas agrupadas por HDR
        private static string ConstruirAsignadasSoloLineas(ListView lv)
        {
            var grupos = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            foreach (ListViewItem it in lv.Items)
            {
                if (it.SubItems.Count < 4) continue;             // [0]=Guía,[1]=Tamaño,[2]=Destino,[3]=HDR
                string guia = it.SubItems[0].Text?.Trim() ?? "";
                string hdr  = it.SubItems[3].Text?.Trim() ?? "";
                if (string.IsNullOrEmpty(guia)) continue;
                if (string.IsNullOrWhiteSpace(hdr)) hdr = "(sin HDR)";
                if (!grupos.TryGetValue(hdr, out var lst)) { lst = new List<string>(); grupos[hdr] = lst; }
                lst.Add(guia);
            }
            return FormatearGrupos(grupos);
        }

        private void LimpiarListas()
        {
            GuiasDistribucionxFleteroListView.Items.Clear();
            GuiasRetiroxFleteroListView.Items.Clear();
            NuevasGuiasRetiroxFleteroListView.Items.Clear();
            NuevasGuiasDistribucionxFleteroListView.Items.Clear();
        }

        private void LimpiarPantalla(bool total)
        {
            LimpiarListas();
            if (total)
            {
                DNIFleteroTextBox.Clear();
                PintarNombreFletero(string.Empty);
            }
        }

        private void MostrarSeccionBusquedaYListasSuperiores(bool visible)
        {
            BusquedaGroupBox.Visible = visible;
            GuiasGroupBox.Visible = visible;
            groupBox2.Visible = visible;
        }

        private void PintarNombreFletero(string nombre)
        {
            var lbl = FindLabel("FleteroResult");
            if (lbl != null)
            {
                lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                lbl.Text = string.IsNullOrWhiteSpace(nombre) ? string.Empty : $"Fletero: {nombre}";
            }
        }

        private Label? FindLabel(string name) =>
            this.Controls.Find(name, true).FirstOrDefault() as Label;

        private void GuiasRetiroxFleteroListView_SelectedIndexChanged(object sender, EventArgs e) { /* no-op */ }
    }
}
