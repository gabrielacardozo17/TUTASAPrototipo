namespace TUTASAPrototipo.ImponerEncomiendaCD
{
    partial class ImponerEncomiendaCentroDistribucionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            RemitenteGroupBox = new GroupBox();
            DireccionClienteResult = new Label();
            TelefonoClienteResult = new Label();
            NombreClienteResult = new Label();
            DireccionClienteLabel = new Label();
            TelefonoClienteLabel = new Label();
            NombreClienteLabel = new Label();
            BuscarClienteButton = new Button();
            CUITRemitenteMaskedText = new MaskedTextBox();
            CuitLabel = new Label();
            label1 = new Label();
            DestinatarioGroupBox = new GroupBox();
            CDComboBox = new ComboBox();
            CentroLabel = new Label();
            AgenciaComboBox = new ComboBox();
            label2 = new Label();
            LocalidadxProvinciaComboBox = new ComboBox();
            CodigoPostalTextBox = new TextBox();
            CodigoPostalLabel = new Label();
            TipoEntregaLabel = new Label();
            TipoEntregaComboBox = new ComboBox();
            IndicacionLabel = new Label();
            ProvinciaComboBox = new ComboBox();
            ProvinciaLabel = new Label();
            DireccionDestinatarioTextBox = new TextBox();
            LocalidadLabel = new Label();
            DireccionLabel = new Label();
            DNIDestinatarioTextBox = new TextBox();
            DNILabel = new Label();
            ApellidoDestinatarioTextBox = new TextBox();
            ApellidoDestinatarioLabel = new Label();
            NombreDestinatarioTextBox = new TextBox();
            NombreDestinatarioLabel = new Label();
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
            CancelarButton = new Button();
            ConfirmarImposicionButton = new Button();
            CDLabel = new Label();
            UsuarioLabel = new Label();
            UsuarioResult = new Label();
            CDResult = new Label();
            RemitenteGroupBox.SuspendLayout();
            DestinatarioGroupBox.SuspendLayout();
            EncomiendasGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tipoXLNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tipoLNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tipoMNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tipoSNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // RemitenteGroupBox
            // 
            RemitenteGroupBox.Controls.Add(DireccionClienteResult);
            RemitenteGroupBox.Controls.Add(TelefonoClienteResult);
            RemitenteGroupBox.Controls.Add(NombreClienteResult);
            RemitenteGroupBox.Controls.Add(DireccionClienteLabel);
            RemitenteGroupBox.Controls.Add(TelefonoClienteLabel);
            RemitenteGroupBox.Controls.Add(NombreClienteLabel);
            RemitenteGroupBox.Controls.Add(BuscarClienteButton);
            RemitenteGroupBox.Controls.Add(CUITRemitenteMaskedText);
            RemitenteGroupBox.Controls.Add(CuitLabel);
            RemitenteGroupBox.Location = new Point(80, 88);
            RemitenteGroupBox.Name = "RemitenteGroupBox";
            RemitenteGroupBox.Size = new Size(642, 133);
            RemitenteGroupBox.TabIndex = 5;
            RemitenteGroupBox.TabStop = false;
            RemitenteGroupBox.Text = "Datos del remitente";
            RemitenteGroupBox.Enter += RemitenteGroupBox_Enter;
            // 
            // DireccionClienteResult
            // 
            DireccionClienteResult.AutoSize = true;
            DireccionClienteResult.Location = new Point(193, 110);
            DireccionClienteResult.Name = "DireccionClienteResult";
            DireccionClienteResult.Size = new Size(187, 15);
            DireccionClienteResult.TabIndex = 8;
            DireccionClienteResult.Text = "Lorem Ipsum 123, Almagro, CABA";
            // 
            // TelefonoClienteResult
            // 
            TelefonoClienteResult.AutoSize = true;
            TelefonoClienteResult.Location = new Point(193, 85);
            TelefonoClienteResult.Name = "TelefonoClienteResult";
            TelefonoClienteResult.Size = new Size(67, 15);
            TelefonoClienteResult.TabIndex = 7;
            TelefonoClienteResult.Text = "1122334455";
            // 
            // NombreClienteResult
            // 
            NombreClienteResult.AutoSize = true;
            NombreClienteResult.Location = new Point(193, 60);
            NombreClienteResult.Name = "NombreClienteResult";
            NombreClienteResult.Size = new Size(98, 15);
            NombreClienteResult.TabIndex = 6;
            NombreClienteResult.Text = "Distribuidora Sur ";
            // 
            // DireccionClienteLabel
            // 
            DireccionClienteLabel.AutoSize = true;
            DireccionClienteLabel.Location = new Point(133, 110);
            DireccionClienteLabel.Name = "DireccionClienteLabel";
            DireccionClienteLabel.Size = new Size(60, 15);
            DireccionClienteLabel.TabIndex = 5;
            DireccionClienteLabel.Text = "Dirección:";
            // 
            // TelefonoClienteLabel
            // 
            TelefonoClienteLabel.AutoSize = true;
            TelefonoClienteLabel.Location = new Point(133, 85);
            TelefonoClienteLabel.Name = "TelefonoClienteLabel";
            TelefonoClienteLabel.Size = new Size(56, 15);
            TelefonoClienteLabel.TabIndex = 4;
            TelefonoClienteLabel.Text = "Teléfono:";
            // 
            // NombreClienteLabel
            // 
            NombreClienteLabel.AutoSize = true;
            NombreClienteLabel.Location = new Point(133, 60);
            NombreClienteLabel.Name = "NombreClienteLabel";
            NombreClienteLabel.Size = new Size(54, 15);
            NombreClienteLabel.TabIndex = 3;
            NombreClienteLabel.Text = "Nombre:";
            // 
            // BuscarClienteButton
            // 
            BuscarClienteButton.Location = new Point(382, 26);
            BuscarClienteButton.Name = "BuscarClienteButton";
            BuscarClienteButton.Size = new Size(75, 23);
            BuscarClienteButton.TabIndex = 2;
            BuscarClienteButton.Text = "Buscar";
            BuscarClienteButton.UseVisualStyleBackColor = true;
            // 
            // CUITRemitenteMaskedText
            // 
            CUITRemitenteMaskedText.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            CUITRemitenteMaskedText.Location = new Point(191, 26);
            CUITRemitenteMaskedText.Mask = "00-00000000-0";
            CUITRemitenteMaskedText.Name = "CUITRemitenteMaskedText";
            CUITRemitenteMaskedText.Size = new Size(175, 23);
            CUITRemitenteMaskedText.TabIndex = 1;
            // 
            // CuitLabel
            // 
            CuitLabel.AutoSize = true;
            CuitLabel.Location = new Point(133, 30);
            CuitLabel.Name = "CuitLabel";
            CuitLabel.Size = new Size(36, 15);
            CuitLabel.TabIndex = 0;
            CuitLabel.Text = "CUIT:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(254, 60);
            label1.Name = "label1";
            label1.Size = new Size(282, 25);
            label1.TabIndex = 4;
            label1.Text = "IMPOSICIÓN DE ENCOMIENDAS";
            // 
            // DestinatarioGroupBox
            // 
            DestinatarioGroupBox.Controls.Add(CDComboBox);
            DestinatarioGroupBox.Controls.Add(CentroLabel);
            DestinatarioGroupBox.Controls.Add(AgenciaComboBox);
            DestinatarioGroupBox.Controls.Add(label2);
            DestinatarioGroupBox.Controls.Add(LocalidadxProvinciaComboBox);
            DestinatarioGroupBox.Controls.Add(CodigoPostalTextBox);
            DestinatarioGroupBox.Controls.Add(CodigoPostalLabel);
            DestinatarioGroupBox.Controls.Add(TipoEntregaLabel);
            DestinatarioGroupBox.Controls.Add(TipoEntregaComboBox);
            DestinatarioGroupBox.Controls.Add(IndicacionLabel);
            DestinatarioGroupBox.Controls.Add(ProvinciaComboBox);
            DestinatarioGroupBox.Controls.Add(ProvinciaLabel);
            DestinatarioGroupBox.Controls.Add(DireccionDestinatarioTextBox);
            DestinatarioGroupBox.Controls.Add(LocalidadLabel);
            DestinatarioGroupBox.Controls.Add(DireccionLabel);
            DestinatarioGroupBox.Controls.Add(DNIDestinatarioTextBox);
            DestinatarioGroupBox.Controls.Add(DNILabel);
            DestinatarioGroupBox.Controls.Add(ApellidoDestinatarioTextBox);
            DestinatarioGroupBox.Controls.Add(ApellidoDestinatarioLabel);
            DestinatarioGroupBox.Controls.Add(NombreDestinatarioTextBox);
            DestinatarioGroupBox.Controls.Add(NombreDestinatarioLabel);
            DestinatarioGroupBox.Location = new Point(80, 227);
            DestinatarioGroupBox.Name = "DestinatarioGroupBox";
            DestinatarioGroupBox.Size = new Size(642, 356);
            DestinatarioGroupBox.TabIndex = 6;
            DestinatarioGroupBox.TabStop = false;
            DestinatarioGroupBox.Text = "Datos del destinatario";
            // 
            // CDComboBox
            // 
            CDComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CDComboBox.FormattingEnabled = true;
            CDComboBox.Location = new Point(374, 310);
            CDComboBox.Name = "CDComboBox";
            CDComboBox.Size = new Size(204, 23);
            CDComboBox.TabIndex = 47;
            // 
            // CentroLabel
            // 
            CentroLabel.AutoSize = true;
            CentroLabel.Location = new Point(342, 313);
            CentroLabel.Name = "CentroLabel";
            CentroLabel.Size = new Size(26, 15);
            CentroLabel.TabIndex = 46;
            CentroLabel.Text = "CD:";
            // 
            // AgenciaComboBox
            // 
            AgenciaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            AgenciaComboBox.FormattingEnabled = true;
            AgenciaComboBox.Location = new Point(93, 310);
            AgenciaComboBox.Name = "AgenciaComboBox";
            AgenciaComboBox.Size = new Size(192, 23);
            AgenciaComboBox.TabIndex = 45;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 313);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 44;
            label2.Text = "Agencia:";
            // 
            // LocalidadxProvinciaComboBox
            // 
            LocalidadxProvinciaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            LocalidadxProvinciaComboBox.FormattingEnabled = true;
            LocalidadxProvinciaComboBox.Location = new Point(87, 142);
            LocalidadxProvinciaComboBox.Name = "LocalidadxProvinciaComboBox";
            LocalidadxProvinciaComboBox.Size = new Size(198, 23);
            LocalidadxProvinciaComboBox.TabIndex = 43;
            // 
            // CodigoPostalTextBox
            // 
            CodigoPostalTextBox.BackColor = SystemColors.ScrollBar;
            CodigoPostalTextBox.Location = new Point(114, 265);
            CodigoPostalTextBox.Name = "CodigoPostalTextBox";
            CodigoPostalTextBox.Size = new Size(100, 23);
            CodigoPostalTextBox.TabIndex = 42;
            // 
            // CodigoPostalLabel
            // 
            CodigoPostalLabel.AutoSize = true;
            CodigoPostalLabel.Location = new Point(16, 268);
            CodigoPostalLabel.Name = "CodigoPostalLabel";
            CodigoPostalLabel.Size = new Size(84, 15);
            CodigoPostalLabel.TabIndex = 41;
            CodigoPostalLabel.Text = "Código postal:";
            // 
            // TipoEntregaLabel
            // 
            TipoEntregaLabel.AutoSize = true;
            TipoEntregaLabel.Location = new Point(13, 194);
            TipoEntregaLabel.Name = "TipoEntregaLabel";
            TipoEntregaLabel.Size = new Size(151, 15);
            TipoEntregaLabel.TabIndex = 34;
            TipoEntregaLabel.Text = "Tipo de entrega disponible:";
            // 
            // TipoEntregaComboBox
            // 
            TipoEntregaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            TipoEntregaComboBox.FormattingEnabled = true;
            TipoEntregaComboBox.Items.AddRange(new object[] { "A domicilio", "En agencia", "En centro de distribución" });
            TipoEntregaComboBox.Location = new Point(174, 191);
            TipoEntregaComboBox.Name = "TipoEntregaComboBox";
            TipoEntregaComboBox.Size = new Size(172, 23);
            TipoEntregaComboBox.TabIndex = 35;
            // 
            // IndicacionLabel
            // 
            IndicacionLabel.AutoSize = true;
            IndicacionLabel.Location = new Point(13, 74);
            IndicacionLabel.Name = "IndicacionLabel";
            IndicacionLabel.Size = new Size(229, 15);
            IndicacionLabel.TabIndex = 36;
            IndicacionLabel.Text = "Indique los detalles para realizar la entrega";
            // 
            // ProvinciaComboBox
            // 
            ProvinciaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ProvinciaComboBox.FormattingEnabled = true;
            ProvinciaComboBox.Items.AddRange(new object[] { "Buenos Aires", "Catamarca", "Chaco", "Chubut", "Ciudad Autónoma de Buenos Aires (CABA)", "Córdoba", "Corrientes", "Entre Ríos", "Formosa", "Jujuy", "La Pampa", "La Rioja", "Mendoza", "Misiones", "Neuquén", "Río Negro", "Salta", "San Juan", "San Luis", "Santa Cruz", "Santa Fe", "Santiago del Estero", "Tierra del Fuego", "Tucumán" });
            ProvinciaComboBox.Location = new Point(87, 104);
            ProvinciaComboBox.Name = "ProvinciaComboBox";
            ProvinciaComboBox.Size = new Size(198, 23);
            ProvinciaComboBox.TabIndex = 33;
            // 
            // ProvinciaLabel
            // 
            ProvinciaLabel.AutoSize = true;
            ProvinciaLabel.Location = new Point(22, 107);
            ProvinciaLabel.Name = "ProvinciaLabel";
            ProvinciaLabel.Size = new Size(59, 15);
            ProvinciaLabel.TabIndex = 37;
            ProvinciaLabel.Text = "Provincia:";
            // 
            // DireccionDestinatarioTextBox
            // 
            DireccionDestinatarioTextBox.BackColor = SystemColors.ScrollBar;
            DireccionDestinatarioTextBox.Location = new Point(114, 229);
            DireccionDestinatarioTextBox.Name = "DireccionDestinatarioTextBox";
            DireccionDestinatarioTextBox.Size = new Size(184, 23);
            DireccionDestinatarioTextBox.TabIndex = 40;
            // 
            // LocalidadLabel
            // 
            LocalidadLabel.AutoSize = true;
            LocalidadLabel.Location = new Point(22, 145);
            LocalidadLabel.Name = "LocalidadLabel";
            LocalidadLabel.Size = new Size(61, 15);
            LocalidadLabel.TabIndex = 38;
            LocalidadLabel.Text = "Localidad:";
            // 
            // DireccionLabel
            // 
            DireccionLabel.AutoSize = true;
            DireccionLabel.Location = new Point(16, 232);
            DireccionLabel.Name = "DireccionLabel";
            DireccionLabel.Size = new Size(60, 15);
            DireccionLabel.TabIndex = 39;
            DireccionLabel.Text = "Dirección:";
            // 
            // DNIDestinatarioTextBox
            // 
            DNIDestinatarioTextBox.Location = new Point(491, 31);
            DNIDestinatarioTextBox.Name = "DNIDestinatarioTextBox";
            DNIDestinatarioTextBox.Size = new Size(100, 23);
            DNIDestinatarioTextBox.TabIndex = 5;
            // 
            // DNILabel
            // 
            DNILabel.AutoSize = true;
            DNILabel.Location = new Point(455, 34);
            DNILabel.Name = "DNILabel";
            DNILabel.Size = new Size(30, 15);
            DNILabel.TabIndex = 4;
            DNILabel.Text = "DNI:";
            // 
            // ApellidoDestinatarioTextBox
            // 
            ApellidoDestinatarioTextBox.Location = new Point(291, 31);
            ApellidoDestinatarioTextBox.Name = "ApellidoDestinatarioTextBox";
            ApellidoDestinatarioTextBox.Size = new Size(137, 23);
            ApellidoDestinatarioTextBox.TabIndex = 3;
            // 
            // ApellidoDestinatarioLabel
            // 
            ApellidoDestinatarioLabel.AutoSize = true;
            ApellidoDestinatarioLabel.Location = new Point(231, 34);
            ApellidoDestinatarioLabel.Name = "ApellidoDestinatarioLabel";
            ApellidoDestinatarioLabel.Size = new Size(54, 15);
            ApellidoDestinatarioLabel.TabIndex = 2;
            ApellidoDestinatarioLabel.Text = "Apellido:";
            // 
            // NombreDestinatarioTextBox
            // 
            NombreDestinatarioTextBox.Location = new Point(75, 31);
            NombreDestinatarioTextBox.Name = "NombreDestinatarioTextBox";
            NombreDestinatarioTextBox.Size = new Size(126, 23);
            NombreDestinatarioTextBox.TabIndex = 1;
            // 
            // NombreDestinatarioLabel
            // 
            NombreDestinatarioLabel.AutoSize = true;
            NombreDestinatarioLabel.Location = new Point(15, 34);
            NombreDestinatarioLabel.Name = "NombreDestinatarioLabel";
            NombreDestinatarioLabel.Size = new Size(54, 15);
            NombreDestinatarioLabel.TabIndex = 0;
            NombreDestinatarioLabel.Text = "Nombre:";
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
            EncomiendasGroupBox.Location = new Point(80, 589);
            EncomiendasGroupBox.Name = "EncomiendasGroupBox";
            EncomiendasGroupBox.Size = new Size(642, 126);
            EncomiendasGroupBox.TabIndex = 7;
            EncomiendasGroupBox.TabStop = false;
            EncomiendasGroupBox.Text = "Detalle de encomiendas";
            // 
            // tipoXLNumericUpDown
            // 
            tipoXLNumericUpDown.Font = new Font("Segoe UI", 8F);
            tipoXLNumericUpDown.Location = new Point(455, 89);
            tipoXLNumericUpDown.Name = "tipoXLNumericUpDown";
            tipoXLNumericUpDown.Size = new Size(62, 22);
            tipoXLNumericUpDown.TabIndex = 16;
            // 
            // tipoXLLabel
            // 
            tipoXLLabel.AutoSize = true;
            tipoXLLabel.Font = new Font("Segoe UI", 8.25F);
            tipoXLLabel.Location = new Point(350, 91);
            tipoXLLabel.Name = "tipoXLLabel";
            tipoXLLabel.Size = new Size(83, 13);
            tipoXLLabel.TabIndex = 15;
            tipoXLLabel.Text = "XL (hasta 20kg)";
            // 
            // tipoLNumericUpDown
            // 
            tipoLNumericUpDown.Font = new Font("Segoe UI", 8F);
            tipoLNumericUpDown.Location = new Point(455, 45);
            tipoLNumericUpDown.Name = "tipoLNumericUpDown";
            tipoLNumericUpDown.Size = new Size(62, 22);
            tipoLNumericUpDown.TabIndex = 14;
            // 
            // tipoLLabel
            // 
            tipoLLabel.AutoSize = true;
            tipoLLabel.Font = new Font("Segoe UI", 8.25F);
            tipoLLabel.Location = new Point(350, 47);
            tipoLLabel.Name = "tipoLLabel";
            tipoLLabel.Size = new Size(77, 13);
            tipoLLabel.TabIndex = 13;
            tipoLLabel.Text = "L (hasta 10kg)";
            // 
            // tipoMNumericUpDown
            // 
            tipoMNumericUpDown.Font = new Font("Segoe UI", 8F);
            tipoMNumericUpDown.Location = new Point(125, 89);
            tipoMNumericUpDown.Name = "tipoMNumericUpDown";
            tipoMNumericUpDown.Size = new Size(62, 22);
            tipoMNumericUpDown.TabIndex = 12;
            // 
            // TipoMLabel
            // 
            TipoMLabel.AutoSize = true;
            TipoMLabel.Font = new Font("Segoe UI", 8.25F);
            TipoMLabel.Location = new Point(28, 91);
            TipoMLabel.Name = "TipoMLabel";
            TipoMLabel.Size = new Size(76, 13);
            TipoMLabel.TabIndex = 11;
            TipoMLabel.Text = "M (hasta 5Kg)";
            // 
            // tipoSNumericUpDown
            // 
            tipoSNumericUpDown.Font = new Font("Segoe UI", 8F);
            tipoSNumericUpDown.Location = new Point(126, 45);
            tipoSNumericUpDown.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            tipoSNumericUpDown.Name = "tipoSNumericUpDown";
            tipoSNumericUpDown.Size = new Size(62, 22);
            tipoSNumericUpDown.TabIndex = 10;
            // 
            // TipoSLabel
            // 
            TipoSLabel.AutoSize = true;
            TipoSLabel.Font = new Font("Segoe UI", 8.25F);
            TipoSLabel.Location = new Point(28, 47);
            TipoSLabel.Name = "TipoSLabel";
            TipoSLabel.Size = new Size(81, 13);
            TipoSLabel.TabIndex = 9;
            TipoSLabel.Text = "S (hasta 2.5kg)";
            // 
            // EncomiendasLabel
            // 
            EncomiendasLabel.AutoSize = true;
            EncomiendasLabel.Location = new Point(13, 22);
            EncomiendasLabel.Name = "EncomiendasLabel";
            EncomiendasLabel.Size = new Size(326, 15);
            EncomiendasLabel.TabIndex = 0;
            EncomiendasLabel.Text = "Indique la cantidad de encomiendas de cada tipo a imponer:";
            // 
            // CancelarButton
            // 
            CancelarButton.Location = new Point(571, 721);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(84, 29);
            CancelarButton.TabIndex = 15;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            // 
            // ConfirmarImposicionButton
            // 
            ConfirmarImposicionButton.Location = new Point(661, 721);
            ConfirmarImposicionButton.Name = "ConfirmarImposicionButton";
            ConfirmarImposicionButton.Size = new Size(87, 29);
            ConfirmarImposicionButton.TabIndex = 14;
            ConfirmarImposicionButton.Text = "Confirmar";
            ConfirmarImposicionButton.UseVisualStyleBackColor = true;
            // 
            // CDLabel
            // 
            CDLabel.AutoSize = true;
            CDLabel.Location = new Point(562, 23);
            CDLabel.Name = "CDLabel";
            CDLabel.Size = new Size(26, 15);
            CDLabel.TabIndex = 17;
            CDLabel.Text = "CD:";
            // 
            // UsuarioLabel
            // 
            UsuarioLabel.AutoSize = true;
            UsuarioLabel.Location = new Point(80, 23);
            UsuarioLabel.Name = "UsuarioLabel";
            UsuarioLabel.Size = new Size(50, 15);
            UsuarioLabel.TabIndex = 16;
            UsuarioLabel.Text = "Usuario:";
            // 
            // UsuarioResult
            // 
            UsuarioResult.AutoSize = true;
            UsuarioResult.Location = new Point(136, 23);
            UsuarioResult.Name = "UsuarioResult";
            UsuarioResult.Size = new Size(62, 15);
            UsuarioResult.TabIndex = 18;
            UsuarioResult.Text = "Juan Perez";
            // 
            // CDResult
            // 
            CDResult.AutoSize = true;
            CDResult.Location = new Point(594, 23);
            CDResult.Name = "CDResult";
            CDResult.Size = new Size(73, 15);
            CDResult.TabIndex = 19;
            CDResult.Text = "Loren Ipsum";
            // 
            // ImponerEncomiendaCentroDistribucionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 762);
            Controls.Add(CDResult);
            Controls.Add(UsuarioResult);
            Controls.Add(CDLabel);
            Controls.Add(UsuarioLabel);
            Controls.Add(CancelarButton);
            Controls.Add(ConfirmarImposicionButton);
            Controls.Add(EncomiendasGroupBox);
            Controls.Add(DestinatarioGroupBox);
            Controls.Add(RemitenteGroupBox);
            Controls.Add(label1);
            Name = "ImponerEncomiendaCentroDistribucionForm";
            Text = "Imposición de encomiendas en centro de distribución";
            RemitenteGroupBox.ResumeLayout(false);
            RemitenteGroupBox.PerformLayout();
            DestinatarioGroupBox.ResumeLayout(false);
            DestinatarioGroupBox.PerformLayout();
            EncomiendasGroupBox.ResumeLayout(false);
            EncomiendasGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tipoXLNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)tipoLNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)tipoMNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)tipoSNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox RemitenteGroupBox;
        private Label DireccionClienteResult;
        private Label TelefonoClienteResult;
        private Label NombreClienteResult;
        private Label DireccionClienteLabel;
        private Label TelefonoClienteLabel;
        private Label NombreClienteLabel;
        private Button BuscarClienteButton;
        private MaskedTextBox CUITRemitenteMaskedText;
        private Label CuitLabel;
        private Label label1;
        private GroupBox DestinatarioGroupBox;
        private TextBox DNIDestinatarioTextBox;
        private Label DNILabel;
        private TextBox ApellidoDestinatarioTextBox;
        private Label ApellidoDestinatarioLabel;
        private TextBox NombreDestinatarioTextBox;
        private Label NombreDestinatarioLabel;
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
        private Button CancelarButton;
        private Button ConfirmarImposicionButton;
        private ComboBox AgenciaComboBox;
        private Label label2;
        private ComboBox LocalidadxProvinciaComboBox;
        private TextBox CodigoPostalTextBox;
        private Label CodigoPostalLabel;
        private Label TipoEntregaLabel;
        private ComboBox TipoEntregaComboBox;
        private Label IndicacionLabel;
        private ComboBox ProvinciaComboBox;
        private Label ProvinciaLabel;
        private TextBox DireccionDestinatarioTextBox;
        private Label LocalidadLabel;
        private Label DireccionLabel;
        private Label CDLabel;
        private Label UsuarioLabel;
        private ComboBox CDComboBox;
        private Label CentroLabel;
        private Label UsuarioResult;
        private Label CDResult;
    }
}