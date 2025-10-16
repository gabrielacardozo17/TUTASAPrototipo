using System;
using System.Drawing;           // SystemColors
using System.Linq;
using System.Windows.Forms;
using CD = TUTASAPrototipo.ImponerEncomiendaCD; // reutiliza el modelo del módulo CD

namespace TUTASAPrototipo.ImponerEncomiendaAgencia
{
    public partial class ImponerEncomiendaAgenciaForm : Form
    {
        // Reutilizamos el mismo modelo de CD para tener idéntico comportamiento
        private readonly CD.ImponerEncomiendaCentroDistribucionModelo _modelo = new();

        public ImponerEncomiendaAgenciaForm()
        {
            InitializeComponent();

            // Ciclo de vida
            Load += Form_Load;
            FormClosing += Form_FormClosing;

            // Interacción (nombres según tu diseñador de Agencia)
            BuscarCuitButton.Click += BuscarCuitButton_Click;
            ProvinciaComboBox.SelectedIndexChanged += ProvinciaComboBox_SelectedIndexChanged;
            LocalidadxProvinciaComboBox.SelectedIndexChanged += LocalidadComboBox_SelectedIndexChanged;
            TipoEntregaComboBox.SelectedIndexChanged += TipoEntregaComboBox_SelectedIndexChanged;
            ConfirmarImposicionButton.Click += ConfirmarImposicionButton_Click;
            CancelarButton.Click += (s, e) => Close();

            // Estado inicial de dependientes
            HabilitarCamposEntrega(null);

            // Al escribir CUIT, limpiar datos de remitente
            CUITRemitenteMaskedText.TextChanged += (s, e) =>
            {
                NombreClienteResult.Text = "";
                TelefonoClienteResult.Text = "";
                DireccionClienteResult.Text = "";
            };
        }

        // ---------- CARGA INICIAL ----------
        private void Form_Load(object? sender, EventArgs e)
        {
            // Máscara CUIT
            CUITRemitenteMaskedText.Mask = "00-00000000-0";
            CUITRemitenteMaskedText.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            CUITRemitenteMaskedText.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            CUITRemitenteMaskedText.ResetOnPrompt = true;
            CUITRemitenteMaskedText.ResetOnSpace = true;
            CUITRemitenteMaskedText.AsciiOnly = true;

            // Provincias (solo con CD)
            ProvinciaComboBox.DisplayMember = "Value";
            ProvinciaComboBox.ValueMember = "Key";
            ProvinciaComboBox.DataSource = _modelo.GetProvincias().ToList();
            ProvinciaComboBox.SelectedIndex = -1;
            ProvinciaComboBox.Text = "";

            // Limpiar dependientes
            LocalidadxProvinciaComboBox.DataSource = null;
            TipoEntregaComboBox.Items.Clear();
            AgenciaComboBox.DataSource = null;
            CentroDistribucionComboBox.DataSource = null;

            // NumericUpDowns (permiten 0)
            tipoSNumericUpDown.Minimum = 0;
            tipoMNumericUpDown.Minimum = 0;
            tipoLNumericUpDown.Minimum = 0;
            tipoXLNumericUpDown.Minimum = 0;

            LimpiarRemitente();
        }

        // ---------- CONFIRMACIÓN DE SALIDA ----------
        private void Form_FormClosing(object? sender, FormClosingEventArgs e)
        {
            bool hayDatos =
                !string.IsNullOrWhiteSpace(CUITRemitenteMaskedText.Text) ||
                !string.IsNullOrWhiteSpace(NombreDestinatarioTextBox.Text) ||
                !string.IsNullOrWhiteSpace(ApellidoDestinatarioResult.Text) ||
                !string.IsNullOrWhiteSpace(DNIDestinatarioTextBox.Text) ||
                ProvinciaComboBox.SelectedIndex >= 0 ||
                LocalidadxProvinciaComboBox.SelectedIndex >= 0 ||
                TipoEntregaComboBox.SelectedIndex >= 0 ||
                tipoSNumericUpDown.Value + tipoMNumericUpDown.Value +
                tipoLNumericUpDown.Value + tipoXLNumericUpDown.Value > 0;

            if (hayDatos)
            {
                var r = MessageBox.Show(
                    "Si sale se eliminarán los datos ingresados. ¿Salir?",
                    "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.No) e.Cancel = true;
            }
        }

        // ---------- BUSCAR CLIENTE ----------
        private void BuscarCuitButton_Click(object? sender, EventArgs e)
        {
            var cuit = CUITRemitenteMaskedText.Text.Trim();

            if (!CuitFormatoOk(cuit) || !CuitDvOk(cuit))
            {
                LimpiarRemitente();
                MessageBox.Show("Ingresá un CUIT válido (NN-NNNNNNNN-N).", "Validación");
                CUITRemitenteMaskedText.Focus();
                return;
            }

            var cli = _modelo.BuscarCliente(cuit);
            if (cli is null)
            {
                LimpiarRemitente();
                MessageBox.Show("CUIT inexistente.", "Validación");
                return;
            }

            NombreClienteResult.Text = cli.Nombre;
            TelefonoClienteResult.Text = cli.Telefono;
            DireccionClienteResult.Text = cli.Direccion;
        }

        // ---------- PROVINCIA ----------
        private void ProvinciaComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (ProvinciaComboBox.SelectedItem is not KeyValuePair<int, string> { Key: var provId })
            {
                LocalidadxProvinciaComboBox.DataSource = null;
                TipoEntregaComboBox.Items.Clear();
                AgenciaComboBox.DataSource = null;
                CentroDistribucionComboBox.DataSource = null;
                HabilitarCamposEntrega(null);
                LimpiarCamposEntrega();
                return;
            }

            var locsKvp = _modelo.GetLocalidades(provId)
                                 .Select(l => new KeyValuePair<int, string>(l.id, l.nombre))
                                 .ToList();

            LocalidadxProvinciaComboBox.DisplayMember = "Value";
            LocalidadxProvinciaComboBox.ValueMember = "Key";
            LocalidadxProvinciaComboBox.DataSource = locsKvp;
            LocalidadxProvinciaComboBox.SelectedIndex = -1;

            TipoEntregaComboBox.Items.Clear();
            AgenciaComboBox.DataSource = null;
            CentroDistribucionComboBox.DataSource = null;
            HabilitarCamposEntrega(null);
            LimpiarCamposEntrega();
        }

        // ---------- LOCALIDAD ----------
        private void LocalidadComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            TipoEntregaComboBox.Items.Clear();

            if (ProvinciaComboBox.SelectedItem is not KeyValuePair<int, string> { Key: var provId })
            { HabilitarCamposEntrega(null); LimpiarCamposEntrega(); return; }

            if (LocalidadxProvinciaComboBox.SelectedValue is not int locId)
            { HabilitarCamposEntrega(null); LimpiarCamposEntrega(); return; }

            var tipos = _modelo.GetTiposEntregaDisponibles(provId, locId);
            TipoEntregaComboBox.Items.AddRange(tipos);
            TipoEntregaComboBox.SelectedIndex = -1;

            HabilitarCamposEntrega(null);
            LimpiarCamposEntrega();
        }

        // ---------- TIPO DE ENTREGA ----------
        private void TipoEntregaComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // Siempre que cambia el tipo, limpiamos Dirección/CP y selecciones de Agencia/CD
            LimpiarCamposEntrega();

            var tipoStr = TipoEntregaComboBox.SelectedItem as string;
            HabilitarCamposEntrega(tipoStr);

            if (string.Equals(tipoStr, "En Agencia", StringComparison.OrdinalIgnoreCase))
            {
                AgenciaComboBox.DisplayMember = "Value";
                AgenciaComboBox.ValueMember = "Key";

                if (LocalidadxProvinciaComboBox.SelectedValue is int locId)
                {
                    var agencias = _modelo.GetAgencias(locId).ToList();
                    if (agencias.Count == 0)
                    {
                        AgenciaComboBox.DataSource = null;
                        AgenciaComboBox.Enabled = false;
                        TipoEntregaComboBox.SelectedIndex = -1;
                        MessageBox.Show("La localidad seleccionada no tiene agencias. Elegí otro tipo de entrega.", "Validación");
                        return;
                    }

                    AgenciaComboBox.DataSource = agencias;
                    AgenciaComboBox.Enabled = true;
                    AgenciaComboBox.SelectedIndex = -1;
                }
                else
                {
                    AgenciaComboBox.DataSource = null;
                    AgenciaComboBox.Enabled = false;
                }
            }
            else if (string.Equals(tipoStr, "En CD", StringComparison.OrdinalIgnoreCase))
            {
                if (ProvinciaComboBox.SelectedItem is KeyValuePair<int, string> { Key: var provId })
                {
                    CentroDistribucionComboBox.DisplayMember = "Value";
                    CentroDistribucionComboBox.ValueMember = "Key";
                    CentroDistribucionComboBox.DataSource = _modelo.GetCDs(provId).ToList();
                    CentroDistribucionComboBox.Enabled = true;
                    CentroDistribucionComboBox.SelectedIndex = -1;
                }
                else
                {
                    CentroDistribucionComboBox.DataSource = null;
                    CentroDistribucionComboBox.Enabled = false;
                }
            }
            else
            {
                AgenciaComboBox.DataSource = null;
                CentroDistribucionComboBox.DataSource = null;
            }
        }

        // Habilita/Deshabilita campos según tipo de entrega y “grisado” visual
        private void HabilitarCamposEntrega(string? tipo)
        {
            var esDom = string.Equals(tipo, "A domicilio", StringComparison.OrdinalIgnoreCase);
            var esAge = string.Equals(tipo, "En Agencia", StringComparison.OrdinalIgnoreCase);
            var esCd = string.Equals(tipo, "En CD", StringComparison.OrdinalIgnoreCase);

            // Dirección / CP
            DireccionDestinatarioTextBox.Enabled = esDom;
            DireccionDestinatarioTextBox.BackColor = esDom ? SystemColors.Window : SystemColors.Control;

            CodigoPostalTextBox.Enabled = esDom;
            CodigoPostalTextBox.BackColor = esDom ? SystemColors.Window : SystemColors.Control;

            // Agencia
            AgenciaComboBox.Enabled = esAge;
            AgenciaComboBox.BackColor = esAge ? SystemColors.Window : SystemColors.Control;

            // CD
            CentroDistribucionComboBox.Enabled = esCd;
            CentroDistribucionComboBox.BackColor = esCd ? SystemColors.Window : SystemColors.Control;
        }

        // Limpieza de campos dependientes
        private void LimpiarCamposEntrega()
        {
            DireccionDestinatarioTextBox.Text = "";
            CodigoPostalTextBox.Text = "";

            if (AgenciaComboBox.DataSource != null) AgenciaComboBox.SelectedIndex = -1;
            else AgenciaComboBox.Items.Clear();

            if (CentroDistribucionComboBox.DataSource != null) CentroDistribucionComboBox.SelectedIndex = -1;
            else CentroDistribucionComboBox.Items.Clear();
        }

        // ---------- CONFIRMAR ----------
        private void ConfirmarImposicionButton_Click(object? sender, EventArgs e)
        {
            var cuit = CUITRemitenteMaskedText.Text.Trim();
            if (!CuitFormatoOk(cuit) || !CuitDvOk(cuit))
            { MessageBox.Show("Ingresá un CUIT válido (NN-NNNNNNNN-N).", "Validación"); return; }

            var cli = _modelo.BuscarCliente(cuit);
            if (cli is null)
            { MessageBox.Show("CUIT inexistente.", "Validación"); return; }

            // Nombre / Apellido
            var nombre = (NombreDestinatarioTextBox.Text ?? "").Trim();
            var apellido = (ApellidoDestinatarioResult.Text ?? "").Trim();

            bool nombreOk =
                !string.IsNullOrWhiteSpace(nombre) &&
                nombre.Any(char.IsLetter) &&
                nombre.All(c => char.IsLetter(c) || c == ' ' || c == '\'' || c == '-');

            bool apellidoOk =
                !string.IsNullOrWhiteSpace(apellido) &&
                apellido.Any(char.IsLetter) &&
                apellido.All(c => char.IsLetter(c) || c == ' ' || c == '\'' || c == '-');

            if (!nombreOk || !apellidoOk)
            { MessageBox.Show("Nombre y Apellido deben ser válidos (solo letras, espacios, ' y -).", "Validación"); return; }

            // DNI
            var dni = (DNIDestinatarioTextBox.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(dni) || !DniOk(dni))
            { MessageBox.Show("Ingresá un DNI válido (7–8 dígitos).", "Validación"); return; }

            if (ProvinciaComboBox.SelectedItem is not KeyValuePair<int, string> { Key: var provId, Value: var provNombre })
            { MessageBox.Show("Seleccioná una Provincia.", "Validación"); return; }

            if (LocalidadxProvinciaComboBox.SelectedValue is not int locId)
            { MessageBox.Show("Seleccioná una Localidad.", "Validación"); return; }

            if (TipoEntregaComboBox.SelectedItem is not string tipoSel)
            { MessageBox.Show("Seleccioná el Tipo de entrega.", "Validación"); return; }

            // Cantidades
            var cantS = (int)tipoSNumericUpDown.Value;
            var cantM = (int)tipoMNumericUpDown.Value;
            var cantL = (int)tipoLNumericUpDown.Value;
            var cantXL = (int)tipoXLNumericUpDown.Value;
            if (cantS + cantM + cantL + cantXL == 0)
            { MessageBox.Show("Indicá al menos una encomienda (S/M/L/XL).", "Validación"); return; }

            var locNombre = LocalidadxProvinciaComboBox.Text;
            var esOtras = (locId == -1);

            var tipo = tipoSel; // Usamos string

            string? direccion = null, cp = null, agenciaNombre = null, cdDestinoNombre = null;
            int? agenciaId = null, cdDestinoId = null;

            if (string.Equals(tipo, "A domicilio", StringComparison.OrdinalIgnoreCase))
            {
                direccion = (DireccionDestinatarioTextBox.Text ?? "").Trim();
                cp = (CodigoPostalTextBox.Text ?? "").Trim();

                bool direccionOk = !string.IsNullOrWhiteSpace(direccion) && direccion.Length >= 3;
                bool cpOk = (cp.Length == 4) && cp.All(char.IsDigit) && cp != "0000";

                if (!direccionOk) { MessageBox.Show("Ingresá una dirección válida (no vacía).", "Validación"); return; }
                if (!cpOk) { MessageBox.Show("El Código Postal debe tener 4 dígitos numéricos.", "Validación"); return; }
            }
            else if (string.Equals(tipo, "En Agencia", StringComparison.OrdinalIgnoreCase)
                  && AgenciaComboBox.SelectedItem is KeyValuePair<int, string> { Key: var agId, Value: var agNom })
            {
                agenciaId = agId; agenciaNombre = agNom;
            }
            else if (string.Equals(tipo, "En CD", StringComparison.OrdinalIgnoreCase)
                  && CentroDistribucionComboBox.SelectedItem is KeyValuePair<int, string> { Key: var cdId, Value: var cdNom })
            {
                cdDestinoId = cdId; cdDestinoNombre = cdNom;
            }
            else
            {
                MessageBox.Show("Completá el dato requerido del tipo de entrega elegido.", "Validación");
                return;
            }

            try
            {
                // Tomamos la agencia de origen del label superior (si existe)
                var agenciaOrigenNombre = (AgenciaResult?.Text ?? "").Replace("Agencia:", "").Trim();

                // El modelo no requiere ID de agencia de origen; mantenemos CD de origen vacío
                int cdOrigenId = 0;
                string cdOrigenNombre = "";

                var guias = _modelo.ConfirmarImposicion(
                    cuit,
                    nombre,
                    apellido,
                    dni,
                    provId, provNombre,
                    esOtras ? (int?)null : locId,
                    esOtras ? null : locNombre,
                    esOtras,
                    tipo,
                    direccion, cp,
                    agenciaId, agenciaNombre,
                    cdDestinoId, cdDestinoNombre,
                    cantS, cantM, cantL, cantXL,
                    cdOrigenId, cdOrigenNombre
                );

                // (Opcional) Si querés forzar estado inicial distinto, podés setearlo acá.
                // foreach (var g in guias) g.Estado = CD.EstadoGuia.PendRetiroDomicilio;

                var lineas = guias.Select(g =>
                {
                    string tam = g.CantS == 1 ? "S"
                               : g.CantM == 1 ? "M"
                               : g.CantL == 1 ? "L"
                               : g.CantXL == 1 ? "XL"
                               : "?";
                    return $"- {g.Numero} (Tamaño: {tam})";
                });

                var cuerpo = string.Join(Environment.NewLine, lineas);

                MessageBox.Show(
                    $"Imposición confirmada. Se generaron {guias.Count} guías (Estado: A retirar en agencia de origen):{Environment.NewLine}{cuerpo}",
                    "Operación Exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ---------- LIMPIEZAS ----------
        private void LimpiarFormulario()
        {
            LimpiarRemitente();

            NombreDestinatarioTextBox.Text = "";
            ApellidoDestinatarioResult.Text = "";
            DNIDestinatarioTextBox.Text = "";

            ProvinciaComboBox.SelectedIndex = -1;
            ProvinciaComboBox.Text = "";

            LocalidadxProvinciaComboBox.DataSource = null;
            TipoEntregaComboBox.Items.Clear();
            TipoEntregaComboBox.SelectedIndex = -1;

            DireccionDestinatarioTextBox.Text = "";
            CodigoPostalTextBox.Text = "";

            AgenciaComboBox.DataSource = null;
            CentroDistribucionComboBox.DataSource = null;

            HabilitarCamposEntrega(null);
            LimpiarCamposEntrega();

            tipoSNumericUpDown.Value = 0;
            tipoMNumericUpDown.Value = 0;
            tipoLNumericUpDown.Value = 0;
            tipoXLNumericUpDown.Value = 0;
        }

        private void LimpiarRemitente()
        {
            CUITRemitenteMaskedText.Clear();
            NombreClienteResult.Text = "";
            TelefonoClienteResult.Text = "";
            DireccionClienteResult.Text = "";
        }

        // ---------- HELPERS ----------
        private static bool CuitFormatoOk(string cuit)
        {
            var d = new string(cuit.Where(char.IsDigit).ToArray());
            return d.Length == 11;
        }

        private static bool CuitDvOk(string cuit)
        {
            var d = new string(cuit.Where(char.IsDigit).ToArray());
            if (d.Length != 11) return false;
            int[] pesos = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            int suma = 0; for (int i = 0; i < 10; i++) suma += (d[i] - '0') * pesos[i];
            int resto = suma % 11;
            int dv = resto == 0 ? 0 : resto == 1 ? 9 : 11 - resto;
            return dv == (d[10] - '0');
        }

        private static bool DniOk(string dni) => dni.All(char.IsDigit) && dni.Length is >= 7 and <= 8;

        private void AgenciaResult_Click(object sender, EventArgs e)
        {

        }
    }
}
