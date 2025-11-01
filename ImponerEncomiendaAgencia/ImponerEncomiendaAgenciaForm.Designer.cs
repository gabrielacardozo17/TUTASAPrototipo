namespace TUTASAPrototipo.ImponerEncomiendaAgencia
{
    partial class ImponerEncomiendaAgenciaForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            CancelarButton = new Button();
            ConfirmarImposicionButton = new Button();
            EncomiendasGroupBox = new GroupBox();
            tipoXLNumericUpDown = new NumericUpDown();
            tipoXLLabel = new Label();
            tipoLNumericUpDown = new NumericUpDown();
            tipoLLabel = new Label();
            tipoMNumericUpDown = new NumericUpDown();
            TipoMLabel = new Label();
            tipoSNumericUpDown = new NumericUpDown();
            TipoSLabel = new Label();
            EncomiendasLabel = new Label();
            DestinatarioGroupBox = new GroupBox();
            TelefonoDestinatarioTextBox = new TextBox();
            TelefonoDestinatarioLabel = new Label();
            CentroDistribucionComboBox = new ComboBox();
            CentroLabel = new Label();
            AgenciaComboBox = new ComboBox();
            label1 = new Label();
            LocalidadxProvinciaComboBox = new ComboBox();
            CodigoPostalTextBox = new TextBox();
            CodigoPostalLabel = new Label();
            TipoEntregaLabel = new Label();
            label3 = new Label();
            TipoEntregaComboBox = new ComboBox();
            ProvinciaComboBox = new ComboBox();
            DireccionDestinatarioTextBox = new TextBox();
            DireccionLabel = new Label();
            LocalidadLabel = new Label();
            ProvinciaLabel = new Label();
            label2 = new Label();
            DNIDestinatarioTextBox = new TextBox();
            DNILabel = new Label();
            ApellidoDestinatarioResult = new TextBox();
            ApellidoDestinatarioLabel = new Label();
            NombreDestinatarioTextBox = new TextBox();
            NombreDestinatarioLabel = new Label();
            RemitenteGroupBox = new GroupBox();
            DireccionClienteResult = new Label();
            TelefonoClienteResult = new Label();
            NombreClienteResult = new Label();
            DireccionClienteLabel = new Label();
            TelefonoClienteLabel = new Label();
            NombreClienteLabel = new Label();
            BuscarCuitButton = new Button();
            CUITRemitenteMaskedText = new MaskedTextBox();
            CuitLabel = new Label();
            ImposicionAgenciaLabel = new Label();
            AgenciaLabel = new Label();
            UsuarioLabel = new Label();
            UsuarioResult = new Label();
            AgenciaResult = new Label();
            EncomiendasGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tipoXLNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tipoLNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tipoMNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tipoSNumericUpDown).BeginInit();
            DestinatarioGroupBox.SuspendLayout();
            RemitenteGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // CancelarButton
            // 
            CancelarButton.Location = new Point(651, 973);
            CancelarButton.Margin = new Padding(3, 4, 3, 4);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(96, 39);
            CancelarButton.TabIndex = 21;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            // 
            // ConfirmarImposicionButton
            // 
            ConfirmarImposicionButton.Location = new Point(758, 973);
            ConfirmarImposicionButton.Margin = new Padding(3, 4, 3, 4);
            ConfirmarImposicionButton.Name = "ConfirmarImposicionButton";
            ConfirmarImposicionButton.Size = new Size(99, 39);
            ConfirmarImposicionButton.TabIndex = 20;
            ConfirmarImposicionButton.Text = "Confirmar";
            ConfirmarImposicionButton.UseVisualStyleBackColor = true;
            // 
            // EncomiendasGroupBox
            // 
            EncomiendasGroupBox.Controls.Add(tipoXLNumericUpDown);
            EncomiendasGroupBox.Controls.Add(tipoXLLabel);
            EncomiendasGroupBox.Controls.Add(tipoLNumericUpDown);
            EncomiendasGroupBox.Controls.Add(tipoLLabel);
            EncomiendasGroupBox.Controls.Add(tipoMNumericUpDown);
            EncomiendasGroupBox.Controls.Add(TipoMLabel);
            EncomiendasGroupBox.Controls.Add(tipoSNumericUpDown);
            EncomiendasGroupBox.Controls.Add(TipoSLabel);
            EncomiendasGroupBox.Controls.Add(EncomiendasLabel);
            EncomiendasGroupBox.Location = new Point(72, 797);
            EncomiendasGroupBox.Margin = new Padding(3, 4, 3, 4);
            EncomiendasGroupBox.Name = "EncomiendasGroupBox";
            EncomiendasGroupBox.Padding = new Padding(3, 4, 3, 4);
            EncomiendasGroupBox.Size = new Size(734, 168);
            EncomiendasGroupBox.TabIndex = 19;
            EncomiendasGroupBox.TabStop = false;
            EncomiendasGroupBox.Text = "Detalle de encomiendas";
            // 
            // tipoXLNumericUpDown
            // 
            tipoXLNumericUpDown.Font = new Font("Segoe UI", 8F);
            tipoXLNumericUpDown.Location = new Point(520, 119);
            tipoXLNumericUpDown.Margin = new Padding(3, 4, 3, 4);
            tipoXLNumericUpDown.Name = "tipoXLNumericUpDown";
            tipoXLNumericUpDown.Size = new Size(71, 25);
            tipoXLNumericUpDown.TabIndex = 16;
            // 
            // tipoXLLabel
            // 
            tipoXLLabel.AutoSize = true;
            tipoXLLabel.Font = new Font("Segoe UI", 8.25F);
            tipoXLLabel.Location = new Point(400, 121);
            tipoXLLabel.Name = "tipoXLLabel";
            tipoXLLabel.Size = new Size(104, 19);
            tipoXLLabel.TabIndex = 15;
            tipoXLLabel.Text = "XL (hasta 20kg)";
            // 
            // tipoLNumericUpDown
            // 
            tipoLNumericUpDown.Font = new Font("Segoe UI", 8F);
            tipoLNumericUpDown.Location = new Point(520, 60);
            tipoLNumericUpDown.Margin = new Padding(3, 4, 3, 4);
            tipoLNumericUpDown.Name = "tipoLNumericUpDown";
            tipoLNumericUpDown.Size = new Size(71, 25);
            tipoLNumericUpDown.TabIndex = 14;
            // 
            // tipoLLabel
            // 
            tipoLLabel.AutoSize = true;
            tipoLLabel.Font = new Font("Segoe UI", 8.25F);
            tipoLLabel.Location = new Point(400, 63);
            tipoLLabel.Name = "tipoLLabel";
            tipoLLabel.Size = new Size(96, 19);
            tipoLLabel.TabIndex = 13;
            tipoLLabel.Text = "L (hasta 10kg)";
            // 
            // tipoMNumericUpDown
            // 
            tipoMNumericUpDown.Font = new Font("Segoe UI", 8F);
            tipoMNumericUpDown.Location = new Point(143, 119);
            tipoMNumericUpDown.Margin = new Padding(3, 4, 3, 4);
            tipoMNumericUpDown.Name = "tipoMNumericUpDown";
            tipoMNumericUpDown.Size = new Size(71, 25);
            tipoMNumericUpDown.TabIndex = 12;
            // 
            // TipoMLabel
            // 
            TipoMLabel.AutoSize = true;
            TipoMLabel.Font = new Font("Segoe UI", 8.25F);
            TipoMLabel.Location = new Point(32, 121);
            TipoMLabel.Name = "TipoMLabel";
            TipoMLabel.Size = new Size(95, 19);
            TipoMLabel.TabIndex = 11;
            TipoMLabel.Text = "M (hasta 5Kg)";
            // 
            // tipoSNumericUpDown
            // 
            tipoSNumericUpDown.Font = new Font("Segoe UI", 8F);
            tipoSNumericUpDown.Location = new Point(144, 60);
            tipoSNumericUpDown.Margin = new Padding(3, 4, 3, 4);
            tipoSNumericUpDown.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            tipoSNumericUpDown.Name = "tipoSNumericUpDown";
            tipoSNumericUpDown.Size = new Size(71, 25);
            tipoSNumericUpDown.TabIndex = 10;
            // 
            // TipoSLabel
            // 
            TipoSLabel.AutoSize = true;
            TipoSLabel.Font = new Font("Segoe UI", 8.25F);
            TipoSLabel.Location = new Point(32, 63);
            TipoSLabel.Name = "TipoSLabel";
            TipoSLabel.Size = new Size(99, 19);
            TipoSLabel.TabIndex = 9;
            TipoSLabel.Text = "S (hasta 2.5kg)";
            // 
            // EncomiendasLabel
            // 
            EncomiendasLabel.AutoSize = true;
            EncomiendasLabel.Location = new Point(15, 29);
            EncomiendasLabel.Name = "EncomiendasLabel";
            EncomiendasLabel.Size = new Size(413, 20);
            EncomiendasLabel.TabIndex = 0;
            EncomiendasLabel.Text = "Indique la cantidad de encomiendas de cada tipo a imponer:";
            // 
            // DestinatarioGroupBox
            // 
            DestinatarioGroupBox.Controls.Add(TelefonoDestinatarioTextBox);
            DestinatarioGroupBox.Controls.Add(TelefonoDestinatarioLabel);
            DestinatarioGroupBox.Controls.Add(CentroDistribucionComboBox);
            DestinatarioGroupBox.Controls.Add(CentroLabel);
            DestinatarioGroupBox.Controls.Add(AgenciaComboBox);
            DestinatarioGroupBox.Controls.Add(label1);
            DestinatarioGroupBox.Controls.Add(LocalidadxProvinciaComboBox);
            DestinatarioGroupBox.Controls.Add(CodigoPostalTextBox);
            DestinatarioGroupBox.Controls.Add(CodigoPostalLabel);
            DestinatarioGroupBox.Controls.Add(TipoEntregaLabel);
            DestinatarioGroupBox.Controls.Add(label3);
            DestinatarioGroupBox.Controls.Add(TipoEntregaComboBox);
            DestinatarioGroupBox.Controls.Add(ProvinciaComboBox);
            DestinatarioGroupBox.Controls.Add(DireccionDestinatarioTextBox);
            DestinatarioGroupBox.Controls.Add(DireccionLabel);
            DestinatarioGroupBox.Controls.Add(LocalidadLabel);
            DestinatarioGroupBox.Controls.Add(ProvinciaLabel);
            DestinatarioGroupBox.Controls.Add(label2);
            DestinatarioGroupBox.Controls.Add(DNIDestinatarioTextBox);
            DestinatarioGroupBox.Controls.Add(DNILabel);
            DestinatarioGroupBox.Controls.Add(ApellidoDestinatarioResult);
            DestinatarioGroupBox.Controls.Add(ApellidoDestinatarioLabel);
            DestinatarioGroupBox.Controls.Add(NombreDestinatarioTextBox);
            DestinatarioGroupBox.Controls.Add(NombreDestinatarioLabel);
            DestinatarioGroupBox.Controls.Add(TelefonoDestinatarioTextBox);
            DestinatarioGroupBox.Controls.Add(TelefonoDestinatarioLabel);
            DestinatarioGroupBox.Location = new Point(72, 303);
            DestinatarioGroupBox.Margin = new Padding(3, 4, 3, 4);
            DestinatarioGroupBox.Name = "DestinatarioGroupBox";
            DestinatarioGroupBox.Padding = new Padding(3, 4, 3, 4);
            DestinatarioGroupBox.Size = new Size(734, 487);
            DestinatarioGroupBox.TabIndex = 18;
            DestinatarioGroupBox.TabStop = false;
            DestinatarioGroupBox.Text = "Datos del destinatario";
            // 
            // TelefonoDestinatarioTextBox
            // 
            TelefonoDestinatarioTextBox.Location = new Point(419, 80);
            TelefonoDestinatarioTextBox.Margin = new Padding(3, 4, 3, 4);
            TelefonoDestinatarioTextBox.Name = "TelefonoDestinatarioTextBox";
            TelefonoDestinatarioTextBox.Size = new Size(150, 27);
            TelefonoDestinatarioTextBox.TabIndex = 52;
            // 
            // TelefonoDestinatarioLabel
            // 
            TelefonoDestinatarioLabel.AutoSize = true;
            TelefonoDestinatarioLabel.Location = new Point(342, 84);
            TelefonoDestinatarioLabel.Name = "TelefonoDestinatarioLabel";
            TelefonoDestinatarioLabel.Size = new Size(70, 20);
            TelefonoDestinatarioLabel.TabIndex = 53;
            TelefonoDestinatarioLabel.Text = "Teléfono:";
            // 
            // CentroDistribucionComboBox
            // 
            CentroDistribucionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CentroDistribucionComboBox.FormattingEnabled = true;
            CentroDistribucionComboBox.Location = new Point(419, 429);
            CentroDistribucionComboBox.Margin = new Padding(3, 4, 3, 4);
            CentroDistribucionComboBox.Name = "CentroDistribucionComboBox";
            CentroDistribucionComboBox.Size = new Size(233, 28);
            CentroDistribucionComboBox.TabIndex = 51;
            // 
            // CentroLabel
            // 
            CentroLabel.AutoSize = true;
            CentroLabel.Location = new Point(383, 433);
            CentroLabel.Name = "CentroLabel";
            CentroLabel.Size = new Size(32, 20);
            CentroLabel.TabIndex = 50;
            CentroLabel.Text = "CD:";
            // 
            // AgenciaComboBox
            // 
            AgenciaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            AgenciaComboBox.FormattingEnabled = true;
            AgenciaComboBox.Location = new Point(98, 429);
            AgenciaComboBox.Margin = new Padding(3, 4, 3, 4);
            AgenciaComboBox.Name = "AgenciaComboBox";
            AgenciaComboBox.Size = new Size(219, 28);
            AgenciaComboBox.TabIndex = 49;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 433);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 48;
            label1.Text = "Agencia:";
            // 
            // LocalidadxProvinciaComboBox
            // 
            LocalidadxProvinciaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            LocalidadxProvinciaComboBox.FormattingEnabled = true;
            LocalidadxProvinciaComboBox.Location = new Point(91, 203);
            LocalidadxProvinciaComboBox.Margin = new Padding(3, 4, 3, 4);
            LocalidadxProvinciaComboBox.Name = "LocalidadxProvinciaComboBox";
            LocalidadxProvinciaComboBox.Size = new Size(226, 28);
            LocalidadxProvinciaComboBox.TabIndex = 17;
            // 
            // CodigoPostalTextBox
            // 
            CodigoPostalTextBox.BackColor = SystemColors.ScrollBar;
            CodigoPostalTextBox.Location = new Point(122, 367);
            CodigoPostalTextBox.Margin = new Padding(3, 4, 3, 4);
            CodigoPostalTextBox.Name = "CodigoPostalTextBox";
            CodigoPostalTextBox.Size = new Size(114, 27);
            CodigoPostalTextBox.TabIndex = 16;
            // 
            // CodigoPostalLabel
            // 
            CodigoPostalLabel.AutoSize = true;
            CodigoPostalLabel.Location = new Point(10, 371);
            CodigoPostalLabel.Name = "CodigoPostalLabel";
            CodigoPostalLabel.Size = new Size(106, 20);
            CodigoPostalLabel.TabIndex = 15;
            CodigoPostalLabel.Text = "Código postal:";
            // 
            // TipoEntregaLabel
            // 
            TipoEntregaLabel.AutoSize = true;
            TipoEntregaLabel.Location = new Point(7, 272);
            TipoEntregaLabel.Name = "TipoEntregaLabel";
            TipoEntregaLabel.Size = new Size(192, 20);
            TipoEntregaLabel.TabIndex = 6;
            TipoEntregaLabel.Text = "Tipo de entrega disponible:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(494, 207);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 13;
            // 
            // TipoEntregaComboBox
            // 
            TipoEntregaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            TipoEntregaComboBox.FormattingEnabled = true;
            TipoEntregaComboBox.Items.AddRange(new object[] { "A domicilio", "En agencia", "En centro de distribución" });
            TipoEntregaComboBox.Location = new Point(191, 268);
            TipoEntregaComboBox.Margin = new Padding(3, 4, 3, 4);
            TipoEntregaComboBox.Name = "TipoEntregaComboBox";
            TipoEntregaComboBox.Size = new Size(196, 28);
            TipoEntregaComboBox.TabIndex = 7;
            TipoEntregaComboBox.SelectedIndexChanged += TipoEntregaComboBox_SelectedIndexChanged;
            // 
            // ProvinciaComboBox
            // 
            ProvinciaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ProvinciaComboBox.FormattingEnabled = true;
            ProvinciaComboBox.Location = new Point(91, 152);
            ProvinciaComboBox.Margin = new Padding(3, 4, 3, 4);
            ProvinciaComboBox.Name = "ProvinciaComboBox";
            ProvinciaComboBox.Size = new Size(226, 28);
            ProvinciaComboBox.TabIndex = 4;
            ProvinciaComboBox.SelectedIndexChanged += ProvinciaComboBox_SelectedIndexChanged;
            // 
            // DireccionDestinatarioTextBox
            // 
            DireccionDestinatarioTextBox.BackColor = SystemColors.ScrollBar;
            DireccionDestinatarioTextBox.Location = new Point(122, 319);
            DireccionDestinatarioTextBox.Margin = new Padding(3, 4, 3, 4);
            DireccionDestinatarioTextBox.Name = "DireccionDestinatarioTextBox";
            DireccionDestinatarioTextBox.Size = new Size(210, 27);
            DireccionDestinatarioTextBox.TabIndex = 12;
            // 
            // DireccionLabel
            // 
            DireccionLabel.AutoSize = true;
            DireccionLabel.Location = new Point(10, 323);
            DireccionLabel.Name = "DireccionLabel";
            DireccionLabel.Size = new Size(75, 20);
            DireccionLabel.TabIndex = 11;
            DireccionLabel.Text = "Dirección:";
            // 
            // LocalidadLabel
            // 
            LocalidadLabel.AutoSize = true;
            LocalidadLabel.Location = new Point(17, 207);
            LocalidadLabel.Name = "LocalidadLabel";
            LocalidadLabel.Size = new Size(77, 20);
            LocalidadLabel.TabIndex = 10;
            LocalidadLabel.Text = "Localidad:";
            // 
            // ProvinciaLabel
            // 
            ProvinciaLabel.AutoSize = true;
            ProvinciaLabel.Location = new Point(17, 156);
            ProvinciaLabel.Name = "ProvinciaLabel";
            ProvinciaLabel.Size = new Size(72, 20);
            ProvinciaLabel.TabIndex = 9;
            ProvinciaLabel.Text = "Provincia:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 112);
            label2.Name = "label2";
            label2.Size = new Size(296, 20);
            label2.TabIndex = 8;
            label2.Text = "Indique los detalles para realizar la entrega";
            // 
            // DNIDestinatarioTextBox
            // 
            DNIDestinatarioTextBox.Location = new Point(561, 41);
            DNIDestinatarioTextBox.Margin = new Padding(3, 4, 3, 4);
            DNIDestinatarioTextBox.Name = "DNIDestinatarioTextBox";
            DNIDestinatarioTextBox.Size = new Size(114, 27);
            DNIDestinatarioTextBox.TabIndex = 5;
            // 
            // DNILabel
            // 
            DNILabel.AutoSize = true;
            DNILabel.Location = new Point(520, 45);
            DNILabel.Name = "DNILabel";
            DNILabel.Size = new Size(38, 20);
            DNILabel.TabIndex = 4;
            DNILabel.Text = "DNI:";
            // 
            // ApellidoDestinatarioResult
            // 
            ApellidoDestinatarioResult.Location = new Point(333, 41);
            ApellidoDestinatarioResult.Margin = new Padding(3, 4, 3, 4);
            ApellidoDestinatarioResult.Name = "ApellidoDestinatarioResult";
            ApellidoDestinatarioResult.Size = new Size(156, 27);
            ApellidoDestinatarioResult.TabIndex = 3;
            // 
            // ApellidoDestinatarioLabel
            // 
            ApellidoDestinatarioLabel.AutoSize = true;
            ApellidoDestinatarioLabel.Location = new Point(264, 45);
            ApellidoDestinatarioLabel.Name = "ApellidoDestinatarioLabel";
            ApellidoDestinatarioLabel.Size = new Size(69, 20);
            ApellidoDestinatarioLabel.TabIndex = 2;
            ApellidoDestinatarioLabel.Text = "Apellido:";
            // 
            // NombreDestinatarioTextBox
            // 
            NombreDestinatarioTextBox.Location = new Point(86, 41);
            NombreDestinatarioTextBox.Margin = new Padding(3, 4, 3, 4);
            NombreDestinatarioTextBox.Name = "NombreDestinatarioTextBox";
            NombreDestinatarioTextBox.Size = new Size(143, 27);
            NombreDestinatarioTextBox.TabIndex = 1;
            // 
            // NombreDestinatarioLabel
            // 
            NombreDestinatarioLabel.AutoSize = true;
            NombreDestinatarioLabel.Location = new Point(17, 45);
            NombreDestinatarioLabel.Name = "NombreDestinatarioLabel";
            NombreDestinatarioLabel.Size = new Size(67, 20);
            NombreDestinatarioLabel.TabIndex = 0;
            NombreDestinatarioLabel.Text = "Nombre:";
            // 
            // RemitenteGroupBox
            // 
            RemitenteGroupBox.Controls.Add(DireccionClienteResult);
            RemitenteGroupBox.Controls.Add(TelefonoClienteResult);
            RemitenteGroupBox.Controls.Add(NombreClienteResult);
            RemitenteGroupBox.Controls.Add(DireccionClienteLabel);
            RemitenteGroupBox.Controls.Add(TelefonoClienteLabel);
            RemitenteGroupBox.Controls.Add(NombreClienteLabel);
            RemitenteGroupBox.Controls.Add(BuscarCuitButton);
            RemitenteGroupBox.Controls.Add(CUITRemitenteMaskedText);
            RemitenteGroupBox.Controls.Add(CuitLabel);
            RemitenteGroupBox.Location = new Point(72, 96);
            RemitenteGroupBox.Margin = new Padding(3, 4, 3, 4);
            RemitenteGroupBox.Name = "RemitenteGroupBox";
            RemitenteGroupBox.Padding = new Padding(3, 4, 3, 4);
            RemitenteGroupBox.Size = new Size(734, 177);
            RemitenteGroupBox.TabIndex = 17;
            RemitenteGroupBox.TabStop = false;
            RemitenteGroupBox.Text = "Datos del remitente";
            // 
            // DireccionClienteResult
            // 
            DireccionClienteResult.AutoSize = true;
            DireccionClienteResult.Location = new Point(221, 147);
            DireccionClienteResult.Name = "DireccionClienteResult";
            DireccionClienteResult.Size = new Size(233, 20);
            DireccionClienteResult.TabIndex = 8;
            DireccionClienteResult.Text = "Lorem Ipsum 123, Almagro, CABA";
            // 
            // TelefonoClienteResult
            // 
            TelefonoClienteResult.AutoSize = true;
            TelefonoClienteResult.Location = new Point(221, 113);
            TelefonoClienteResult.Name = "TelefonoClienteResult";
            TelefonoClienteResult.Size = new Size(89, 20);
            TelefonoClienteResult.TabIndex = 7;
            TelefonoClienteResult.Text = "1122334455";
            // 
            // NombreClienteResult
            // 
            NombreClienteResult.AutoSize = true;
            NombreClienteResult.Location = new Point(221, 80);
            NombreClienteResult.Name = "NombreClienteResult";
            NombreClienteResult.Size = new Size(125, 20);
            NombreClienteResult.TabIndex = 6;
            NombreClienteResult.Text = "Distribuidora Sur ";
            // 
            // DireccionClienteLabel
            // 
            DireccionClienteLabel.AutoSize = true;
            DireccionClienteLabel.Location = new Point(152, 147);
            DireccionClienteLabel.Name = "DireccionClienteLabel";
            DireccionClienteLabel.Size = new Size(75, 20);
            DireccionClienteLabel.TabIndex = 5;
            DireccionClienteLabel.Text = "Dirección:";
            // 
            // TelefonoClienteLabel
            // 
            TelefonoClienteLabel.AutoSize = true;
            TelefonoClienteLabel.Location = new Point(152, 113);
            TelefonoClienteLabel.Name = "TelefonoClienteLabel";
            TelefonoClienteLabel.Size = new Size(70, 20);
            TelefonoClienteLabel.TabIndex = 4;
            TelefonoClienteLabel.Text = "Teléfono:";
            // 
            // NombreClienteLabel
            // 
            NombreClienteLabel.AutoSize = true;
            NombreClienteLabel.Location = new Point(152, 80);
            NombreClienteLabel.Name = "NombreClienteLabel";
            NombreClienteLabel.Size = new Size(67, 20);
            NombreClienteLabel.TabIndex = 3;
            NombreClienteLabel.Text = "Nombre:";
            // 
            // BuscarCuitButton
            // 
            BuscarCuitButton.Location = new Point(437, 35);
            BuscarCuitButton.Margin = new Padding(3, 4, 3, 4);
            BuscarCuitButton.Name = "BuscarCuitButton";
            BuscarCuitButton.Size = new Size(86, 31);
            BuscarCuitButton.TabIndex = 2;
            BuscarCuitButton.Text = "Buscar";
            BuscarCuitButton.UseVisualStyleBackColor = true;
            // 
            // CUITRemitenteMaskedText
            // 
            CUITRemitenteMaskedText.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            CUITRemitenteMaskedText.Location = new Point(218, 35);
            CUITRemitenteMaskedText.Margin = new Padding(3, 4, 3, 4);
            CUITRemitenteMaskedText.Mask = "00-00000000-0";
            CUITRemitenteMaskedText.Name = "CUITRemitenteMaskedText";
            CUITRemitenteMaskedText.Size = new Size(199, 27);
            CUITRemitenteMaskedText.TabIndex = 1;
            // 
            // CuitLabel
            // 
            CuitLabel.AutoSize = true;
            CuitLabel.Location = new Point(152, 40);
            CuitLabel.Name = "CuitLabel";
            CuitLabel.Size = new Size(43, 20);
            CuitLabel.TabIndex = 0;
            CuitLabel.Text = "CUIT:";
            // 
            // ImposicionAgenciaLabel
            // 
            ImposicionAgenciaLabel.AutoSize = true;
            ImposicionAgenciaLabel.Font = new Font("Segoe UI", 14F);
            ImposicionAgenciaLabel.Location = new Point(263, 59);
            ImposicionAgenciaLabel.Name = "ImposicionAgenciaLabel";
            ImposicionAgenciaLabel.Size = new Size(356, 32);
            ImposicionAgenciaLabel.TabIndex = 16;
            ImposicionAgenciaLabel.Text = "IMPOSICIÓN DE ENCOMIENDAS";
            // 
            // AgenciaLabel
            // 
            AgenciaLabel.AutoSize = true;
            AgenciaLabel.Location = new Point(621, 12);
            AgenciaLabel.Name = "AgenciaLabel";
            AgenciaLabel.Size = new Size(156, 20);
            AgenciaLabel.TabIndex = 23;
            AgenciaLabel.Text = "Agencia: CABA Centro";
            // 
            // UsuarioLabel
            // 
            UsuarioLabel.AutoSize = true;
            UsuarioLabel.Location = new Point(72, 12);
            UsuarioLabel.Name = "UsuarioLabel";
            UsuarioLabel.Size = new Size(62, 20);
            UsuarioLabel.TabIndex = 22;
            UsuarioLabel.Text = "Usuario:";
            // 
            // UsuarioResult
            // 
            UsuarioResult.AutoSize = true;
            UsuarioResult.Location = new Point(136, 12);
            UsuarioResult.Name = "UsuarioResult";
            UsuarioResult.Size = new Size(77, 20);
            UsuarioResult.TabIndex = 24;
            UsuarioResult.Text = "Juan Perez";
            // 
            // AgenciaResult
            // 
            AgenciaResult.AutoSize = true;
            AgenciaResult.Location = new Point(688, 12);
            AgenciaResult.Name = "AgenciaResult";
            AgenciaResult.Size = new Size(0, 20);
            AgenciaResult.TabIndex = 25;
            AgenciaResult.Click += AgenciaResult_Click;
            // 
            // ImponerEncomiendaAgenciaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(893, 1028);
            Controls.Add(AgenciaResult);
            Controls.Add(UsuarioResult);
            Controls.Add(AgenciaLabel);
            Controls.Add(UsuarioLabel);
            Controls.Add(CancelarButton);
            Controls.Add(ConfirmarImposicionButton);
            Controls.Add(EncomiendasGroupBox);
            Controls.Add(DestinatarioGroupBox);
            Controls.Add(RemitenteGroupBox);
            Controls.Add(ImposicionAgenciaLabel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ImponerEncomiendaAgenciaForm";
            Text = "Imposición de encomiendas en agencia";
            EncomiendasGroupBox.ResumeLayout(false);
            EncomiendasGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tipoXLNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)tipoLNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)tipoMNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)tipoSNumericUpDown).EndInit();
            DestinatarioGroupBox.ResumeLayout(false);
            DestinatarioGroupBox.PerformLayout();
            RemitenteGroupBox.ResumeLayout(false);
            RemitenteGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CancelarButton;
        private Button ConfirmarImposicionButton;
        private GroupBox EncomiendasGroupBox;
        private NumericUpDown tipoXLNumericUpDown;
        private Label tipoXLLabel;
        private NumericUpDown tipoLNumericUpDown;
        private Label tipoLLabel;
        private NumericUpDown tipoMNumericUpDown;
        private Label TipoMLabel;
        private NumericUpDown tipoSNumericUpDown;
        private Label TipoSLabel;
        private Label EncomiendasLabel;
        private GroupBox DestinatarioGroupBox;
        private Label TelefonoDestinatarioLabel;
        private ComboBox CentroDistribucionComboBox;
        private Label CentroLabel;
        private ComboBox AgenciaComboBox;
        private Label label1;
        private ComboBox LocalidadxProvinciaComboBox;
        private TextBox CodigoPostalTextBox;
        private Label CodigoPostalLabel;
        private Label TipoEntregaLabel;
        private Label label3;
        private ComboBox TipoEntregaComboBox;
        private ComboBox ProvinciaComboBox;
        private TextBox DireccionDestinatarioTextBox;
        private Label DireccionLabel;
        private Label LocalidadLabel;
        private Label ProvinciaLabel;
        private Label label2;
        private TextBox DNIDestinatarioTextBox;
        private Label DNILabel;
        private TextBox ApellidoDestinatarioResult;
        private Label ApellidoDestinatarioLabel;
        private TextBox NombreDestinatarioTextBox;
        private Label NombreDestinatarioLabel;
        private TextBox TelefonoDestinatarioTextBox;
        private GroupBox RemitenteGroupBox;
        private Label DireccionClienteResult;
        private Label TelefonoClienteResult;
        private Label NombreClienteResult;
        private Label DireccionClienteLabel;
        private Label TelefonoClienteLabel;
        private Label NombreClienteLabel;
        private Button BuscarCuitButton;
        private MaskedTextBox CUITRemitenteMaskedText;
        private Label CuitLabel;
        private Label ImposicionAgenciaLabel;
        private Label AgenciaLabel;
        private Label UsuarioLabel;
        private Label UsuarioResult;
        private Label AgenciaResult;
    }
}