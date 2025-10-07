using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TUTASAPrototipo.Domain;

namespace TUTASAPrototipo.ImponerEncomiendaCD
{
    public partial class ImponerEncomiendaCentroDistribucionForm : Form
    {
        private readonly ImponerEncomiendaCentroDistribucionModelo _modelo = new();
        private readonly Dictionary<int, bool> _tieneAgenciaPorLocalidad = new();

        public ImponerEncomiendaCentroDistribucionForm()
        {
            InitializeComponent();

            // Eventos
            Load += Form_Load;
            BuscarClienteButton.Click += BuscarClienteButton_Click;
            ProvinciaComboBox.SelectedIndexChanged += ProvinciaComboBox_SelectedIndexChanged;
            LocalidadxProvinciaComboBox.SelectedIndexChanged += LocalidadComboBox_SelectedIndexChanged;
            TipoEntregaComboBox.SelectedIndexChanged += TipoEntregaComboBox_SelectedIndexChanged;
            ConfirmarImposicionButton.Click += ConfirmarImposicionButton_Click;
            CancelarButton.Click += (s, e) => Close();

            // Estado inicial de campos dependientes
            HabilitarCamposEntrega(null);
        }

        // ----- Satisface el handler que dejó el Designer -----
        private void RemitenteGroupBox_Enter(object sender, EventArgs e) { /* no-op */ }

        // ---------- CARGA INICIAL ----------
        private void Form_Load(object? sender, EventArgs e)
        {
            ProvinciaComboBox.DisplayMember = "Value";
            ProvinciaComboBox.ValueMember = "Key";
            ProvinciaComboBox.DataSource = _modelo.GetProvincias().ToList();

            LocalidadxProvinciaComboBox.DataSource = null;
            TipoEntregaComboBox.Items.Clear();
            AgenciaComboBox.DataSource = null;
            CDComboBox.DataSource = null;

            tipoSNumericUpDown.Minimum = 0;
            tipoMNumericUpDown.Minimum = 0;
            tipoLNumericUpDown.Minimum = 0;
            tipoXLNumericUpDown.Minimum = 0;
        }

        // ---------- BUSCAR CLIENTE ----------
        private void BuscarClienteButton_Click(object? sender, EventArgs e)
        {
            var cuit = CUITRemitenteMaskedText.Text.Trim();
            if (!CuitFormatoOk(cuit) || !CuitDvOk(cuit))
            {
                MessageBox.Show("Ingresá un CUIT válido (NN-NNNNNNNN-N).", "Validación");
                CUITRemitenteMaskedText.Focus();
                return;
            }

            var cli = _modelo.BuscarCliente(cuit);
            if (cli is null)
            {
                MessageBox.Show("CUIT inexistente.", "Validación");
                NombreClienteResult.Text = TelefonoClienteResult.Text = DireccionClienteResult.Text = "";
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
                CDComboBox.DataSource = null;
                HabilitarCamposEntrega(null);
                return;
            }

            // Traigo tuplas (id, nombre, tieneAgencia)
            var locsTuplas = _modelo.GetLocalidades(provId).ToList();

            // Guardo si tiene agencia
            _tieneAgenciaPorLocalidad.Clear();
            foreach (var (id, _, tieneAgencia) in locsTuplas)
                _tieneAgenciaPorLocalidad[id] = tieneAgencia;

            // CONVERSIÓN a KeyValuePair para el ComboBox (evita que muestre "(id, nombre, bool)")
            var locsKvp = locsTuplas
                .Select(l => new KeyValuePair<int, string>(l.id, l.nombre))
                .ToList();

            LocalidadxProvinciaComboBox.DisplayMember = "Value"; // nombre
            LocalidadxProvinciaComboBox.ValueMember = "Key";     // id
            LocalidadxProvinciaComboBox.DataSource = locsKvp;

            // Reset dependientes
            TipoEntregaComboBox.Items.Clear();
            AgenciaComboBox.DataSource = null;
            CDComboBox.DataSource = null;
            HabilitarCamposEntrega(null);
        }


        // ---------- LOCALIDAD ----------
        private void LocalidadComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            TipoEntregaComboBox.Items.Clear();

            if (LocalidadxProvinciaComboBox.SelectedValue is not int locId)
            {
                HabilitarCamposEntrega(null);
                return;
            }

            var esOtras = (locId == -1);
            var tieneAg = !esOtras && _tieneAgenciaPorLocalidad.TryGetValue(locId, out var t) && t;

            // Provincia ya tiene CD (por diseño). Si "Otras" => Domicilio + CD. Si tiene agencia => Domicilio + Agencia + CD.
            if (tieneAg)
                TipoEntregaComboBox.Items.AddRange(new object[] { "A domicilio", "En Agencia", "En CD" });
            else
                TipoEntregaComboBox.Items.AddRange(new object[] { "A domicilio", "En CD" });

            TipoEntregaComboBox.SelectedIndex = -1;
            HabilitarCamposEntrega(null);
        }


        // ---------- TIPO DE ENTREGA ----------
        private void TipoEntregaComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            TipoEntrega? tipo = TipoEntregaComboBox.SelectedItem as string switch
            {
                "A domicilio" => TipoEntrega.Domicilio,
                "En Agencia" => TipoEntrega.Agencia,
                "En CD" => TipoEntrega.CD,
                _ => (TipoEntrega?)null
            };

            HabilitarCamposEntrega(tipo);

            if (tipo is TipoEntrega.Agencia)
            {
                if (LocalidadxProvinciaComboBox.SelectedValue is int locId)
                {
                    AgenciaComboBox.DisplayMember = "Value";
                    AgenciaComboBox.ValueMember = "Key";
                    AgenciaComboBox.DataSource = _modelo.GetAgencias(locId).ToList();
                }
                else AgenciaComboBox.DataSource = null;
            }
            else if (tipo is TipoEntrega.CD)
            {
                if (ProvinciaComboBox.SelectedItem is KeyValuePair<int, string> { Key: var provId })
                {
                    CDComboBox.DisplayMember = "Value";
                    CDComboBox.ValueMember = "Key";
                    CDComboBox.DataSource = _modelo.GetCDs(provId).ToList();
                }
                else CDComboBox.DataSource = null;
            }
            else
            {
                AgenciaComboBox.DataSource = null;
                CDComboBox.DataSource = null;
            }
        }


        private void HabilitarCamposEntrega(TipoEntrega? tipo)
        {
            var esDom = tipo is TipoEntrega.Domicilio;
            var esAge = tipo is TipoEntrega.Agencia;
            var esCd = tipo is TipoEntrega.CD;

            DireccionDestinatarioTextBox.Enabled = esDom;
            CodigoPostalTextBox.Enabled = esDom;

            AgenciaComboBox.Enabled = esAge;
            CDComboBox.Enabled = esCd;
        }

        // ---------- CONFIRMAR ----------
        private void ConfirmarImposicionButton_Click(object? sender, EventArgs e)
        {
            // N0–N2
            var cuit = CUITRemitenteMaskedText.Text.Trim();
            if (!CuitFormatoOk(cuit) || !CuitDvOk(cuit))
            { MessageBox.Show("Ingresá un CUIT válido (NN-NNNNNNNN-N).", "Validación"); return; }

            if (string.IsNullOrWhiteSpace(NombreDestinatarioTextBox.Text) ||
                string.IsNullOrWhiteSpace(ApellidoDestinatarioTextBox.Text) ||
                string.IsNullOrWhiteSpace(DNIDestinatarioTextBox.Text) ||
                !DniOk(DNIDestinatarioTextBox.Text))
            { MessageBox.Show("Completá Nombre, Apellido y un DNI válido (7–8 dígitos).", "Validación"); return; }

            if (ProvinciaComboBox.SelectedItem is not KeyValuePair<int, string> { Key: var provId, Value: var provNombre })
            { MessageBox.Show("Seleccioná una Provincia.", "Validación"); return; }

            if (LocalidadxProvinciaComboBox.SelectedValue is not int locId)
            { MessageBox.Show("Seleccioná una Localidad.", "Validación"); return; }

            if (TipoEntregaComboBox.SelectedItem is not string tipoSel)
            { MessageBox.Show("Seleccioná el Tipo de entrega.", "Validación"); return; }

            var cantS = (int)tipoSNumericUpDown.Value;
            var cantM = (int)tipoMNumericUpDown.Value;
            var cantL = (int)tipoLNumericUpDown.Value;
            var cantXL = (int)tipoXLNumericUpDown.Value;
            if (cantS + cantM + cantL + cantXL == 0)
            { MessageBox.Show("Indicá al menos una encomienda (S/M/L/XL).", "Validación"); return; }

            // Mapear selección
            var locNombre = LocalidadxProvinciaComboBox.Text;
            var esOtras = (locId == -1);

            var tipo = tipoSel switch
            {
                "A domicilio" => TipoEntrega.Domicilio,
                "En Agencia" => TipoEntrega.Agencia,
                "En CD" => TipoEntrega.CD,
                _ => TipoEntrega.Domicilio
            };

            string? direccion = null, cp = null, agenciaNombre = null, cdDestinoNombre = null;
            int? agenciaId = null, cdDestinoId = null;

            if (tipo is TipoEntrega.Domicilio)
            {
                direccion = DireccionDestinatarioTextBox.Text.Trim();
                cp = CodigoPostalTextBox.Text.Trim();
            }
            else if (tipo is TipoEntrega.Agencia
                  && AgenciaComboBox.SelectedItem is KeyValuePair<int, string> { Key: var agId, Value: var agNom })
            {
                agenciaId = agId; agenciaNombre = agNom;
            }
            else if (tipo is TipoEntrega.CD
                  && CDComboBox.SelectedItem is KeyValuePair<int, string> { Key: var cdId, Value: var cdNom })
            {
                cdDestinoId = cdId; cdDestinoNombre = cdNom;
            }

            try
            {
                var cdOrigenNombre = (CDLabel?.Text ?? "").Replace("CD:", "").Trim();

                var guias = _modelo.ConfirmarImposicion(
        cuit,
        NombreDestinatarioTextBox.Text.Trim(),
        ApellidoDestinatarioTextBox.Text.Trim(),
        DNIDestinatarioTextBox.Text.Trim(),
        provId, provNombre,
        esOtras ? (int?)null : locId,
        esOtras ? null : locNombre,
        esOtras,
        tipo,
        direccion, cp,
        agenciaId, agenciaNombre,
        cdDestinoId, cdDestinoNombre,
        cantS, cantM, cantL, cantXL,
        0, cdOrigenNombre
    );

                // Mostrar listado de guías generadas
                var numeros = guias.Select(g => g.Numero).ToList();
                string listado = numeros.Count <= 5
                    ? string.Join(", ", numeros)
                    : $"{numeros.First()} … {numeros.Last()}";

                MessageBox.Show(
                    $"Operación finalizada con éxito.\nSe generaron {numeros.Count} guías:\n{listado}",
                    "Imposición",
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

        private void LimpiarFormulario()
        {
            NombreClienteResult.Text = TelefonoClienteResult.Text = DireccionClienteResult.Text = "";

            NombreDestinatarioTextBox.Text = "";
            ApellidoDestinatarioTextBox.Text = "";
            DNIDestinatarioTextBox.Text = "";

            ProvinciaComboBox.SelectedIndex = -1;
            LocalidadxProvinciaComboBox.DataSource = null;
            TipoEntregaComboBox.Items.Clear();
            DireccionDestinatarioTextBox.Text = "";
            CodigoPostalTextBox.Text = "";
            AgenciaComboBox.DataSource = null;
            CDComboBox.DataSource = null;
            HabilitarCamposEntrega(null);

            tipoSNumericUpDown.Value = 0;
            tipoMNumericUpDown.Value = 0;
            tipoLNumericUpDown.Value = 0;
            tipoXLNumericUpDown.Value = 0;
        }

        // ---------- HELPERS (estáticos) ----------
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
    }
}


