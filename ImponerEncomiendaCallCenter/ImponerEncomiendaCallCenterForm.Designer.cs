namespace TUTASAPrototipo.ImponerEncomiendaCallCenter
{
    partial class ImponerEncomiendaCallCenterForm
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
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            DireccionClienteLabel = new Label();
            TelefonoClienteLabel = new Label();
            NombreClienteLabel = new Label();
            BuscarCuitButton = new Button();
            CUITRemitenteMaskedText = new MaskedTextBox();
            CuitLabel = new Label();
            label1 = new Label();
            DestinatarioGroupBox = new GroupBox();
            DNIDestinatarioTextBox = new TextBox();
            DNILabel = new Label();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            CodigoPostalTextBox = new TextBox();
            ApellidoDestinatarioLabel = new Label();
            CodigoPostalLabel = new Label();
            NombreDestinatarioTextBox = new TextBox();
            TipoEntregaLabel = new Label();
            NombreDestinatarioLabel = new Label();
            TipoEntregaComboBox = new ComboBox();
            label3 = new Label();
            ProvinciaComboBox = new ComboBox();
            ProvinciaLabel = new Label();
            DireccionDestinatarioTextBox = new TextBox();
            LocalidadLabel = new Label();
            DireccionLabel = new Label();
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
            SalirButton = new Button();
            ConfirmarButton = new Button();
            CentroDistribucionComboBox = new ComboBox();
            CentroLabel = new Label();
            AgenciaComboBox = new ComboBox();
            label2 = new Label();
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
            RemitenteGroupBox.Controls.Add(label6);
            RemitenteGroupBox.Controls.Add(label5);
            RemitenteGroupBox.Controls.Add(label4);
            RemitenteGroupBox.Controls.Add(DireccionClienteLabel);
            RemitenteGroupBox.Controls.Add(TelefonoClienteLabel);
            RemitenteGroupBox.Controls.Add(NombreClienteLabel);
            RemitenteGroupBox.Controls.Add(BuscarCuitButton);
            RemitenteGroupBox.Controls.Add(CUITRemitenteMaskedText);
            RemitenteGroupBox.Controls.Add(CuitLabel);
            RemitenteGroupBox.Location = new Point(82, 46);
            RemitenteGroupBox.Name = "RemitenteGroupBox";
            RemitenteGroupBox.Size = new Size(642, 133);
            RemitenteGroupBox.TabIndex = 3;
            RemitenteGroupBox.TabStop = false;
            RemitenteGroupBox.Text = "Datos del remitente";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(193, 110);
            label6.Name = "label6";
            label6.Size = new Size(187, 15);
            label6.TabIndex = 8;
            label6.Text = "Lorem Ipsum 123, Almagro, CABA";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(193, 85);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 7;
            label5.Text = "1122334455";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(193, 60);
            label4.Name = "label4";
            label4.Size = new Size(98, 15);
            label4.TabIndex = 6;
            label4.Text = "Distribuidora Sur ";
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
            TelefonoClienteLabel.Size = new Size(55, 15);
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
            // BuscarCuitButton
            // 
            BuscarCuitButton.Location = new Point(382, 26);
            BuscarCuitButton.Name = "BuscarCuitButton";
            BuscarCuitButton.Size = new Size(75, 23);
            BuscarCuitButton.TabIndex = 2;
            BuscarCuitButton.Text = "Buscar";
            BuscarCuitButton.UseVisualStyleBackColor = true;
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
            CuitLabel.Size = new Size(35, 15);
            CuitLabel.TabIndex = 0;
            CuitLabel.Text = "CUIT:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(255, 9);
            label1.Name = "label1";
            label1.Size = new Size(282, 25);
            label1.TabIndex = 2;
            label1.Text = "IMPOSICIÓN DE ENCOMIENDAS";
            // 
            // DestinatarioGroupBox
            // 
            DestinatarioGroupBox.Controls.Add(CentroDistribucionComboBox);
            DestinatarioGroupBox.Controls.Add(DNIDestinatarioTextBox);
            DestinatarioGroupBox.Controls.Add(CentroLabel);
            DestinatarioGroupBox.Controls.Add(DNILabel);
            DestinatarioGroupBox.Controls.Add(AgenciaComboBox);
            DestinatarioGroupBox.Controls.Add(comboBox1);
            DestinatarioGroupBox.Controls.Add(label2);
            DestinatarioGroupBox.Controls.Add(textBox1);
            DestinatarioGroupBox.Controls.Add(CodigoPostalTextBox);
            DestinatarioGroupBox.Controls.Add(ApellidoDestinatarioLabel);
            DestinatarioGroupBox.Controls.Add(CodigoPostalLabel);
            DestinatarioGroupBox.Controls.Add(NombreDestinatarioTextBox);
            DestinatarioGroupBox.Controls.Add(TipoEntregaLabel);
            DestinatarioGroupBox.Controls.Add(NombreDestinatarioLabel);
            DestinatarioGroupBox.Controls.Add(TipoEntregaComboBox);
            DestinatarioGroupBox.Controls.Add(label3);
            DestinatarioGroupBox.Controls.Add(ProvinciaComboBox);
            DestinatarioGroupBox.Controls.Add(ProvinciaLabel);
            DestinatarioGroupBox.Controls.Add(DireccionDestinatarioTextBox);
            DestinatarioGroupBox.Controls.Add(LocalidadLabel);
            DestinatarioGroupBox.Controls.Add(DireccionLabel);
            DestinatarioGroupBox.Location = new Point(82, 201);
            DestinatarioGroupBox.Name = "DestinatarioGroupBox";
            DestinatarioGroupBox.Size = new Size(640, 377);
            DestinatarioGroupBox.TabIndex = 4;
            DestinatarioGroupBox.TabStop = false;
            DestinatarioGroupBox.Text = "Datos del destinatario";
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
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(87, 158);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(198, 23);
            comboBox1.TabIndex = 30;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(291, 31);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(137, 23);
            textBox1.TabIndex = 3;
            // 
            // CodigoPostalTextBox
            // 
            CodigoPostalTextBox.BackColor = SystemColors.ScrollBar;
            CodigoPostalTextBox.Location = new Point(114, 281);
            CodigoPostalTextBox.Name = "CodigoPostalTextBox";
            CodigoPostalTextBox.Size = new Size(100, 23);
            CodigoPostalTextBox.TabIndex = 29;
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
            // CodigoPostalLabel
            // 
            CodigoPostalLabel.AutoSize = true;
            CodigoPostalLabel.Location = new Point(16, 284);
            CodigoPostalLabel.Name = "CodigoPostalLabel";
            CodigoPostalLabel.Size = new Size(84, 15);
            CodigoPostalLabel.TabIndex = 28;
            CodigoPostalLabel.Text = "Código postal:";
            // 
            // NombreDestinatarioTextBox
            // 
            NombreDestinatarioTextBox.Location = new Point(75, 31);
            NombreDestinatarioTextBox.Name = "NombreDestinatarioTextBox";
            NombreDestinatarioTextBox.Size = new Size(126, 23);
            NombreDestinatarioTextBox.TabIndex = 1;
            // 
            // TipoEntregaLabel
            // 
            TipoEntregaLabel.AutoSize = true;
            TipoEntregaLabel.Location = new Point(13, 210);
            TipoEntregaLabel.Name = "TipoEntregaLabel";
            TipoEntregaLabel.Size = new Size(150, 15);
            TipoEntregaLabel.TabIndex = 21;
            TipoEntregaLabel.Text = "Tipo de entrega disponible:";
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
            // TipoEntregaComboBox
            // 
            TipoEntregaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            TipoEntregaComboBox.FormattingEnabled = true;
            TipoEntregaComboBox.Items.AddRange(new object[] { "A domicilio", "En agencia", "En centro de distribución" });
            TipoEntregaComboBox.Location = new Point(174, 207);
            TipoEntregaComboBox.Name = "TipoEntregaComboBox";
            TipoEntregaComboBox.Size = new Size(172, 23);
            TipoEntregaComboBox.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 90);
            label3.Name = "label3";
            label3.Size = new Size(229, 15);
            label3.TabIndex = 23;
            label3.Text = "Indique los detalles para realizar la entrega";
            // 
            // ProvinciaComboBox
            // 
            ProvinciaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ProvinciaComboBox.FormattingEnabled = true;
            ProvinciaComboBox.Items.AddRange(new object[] { "Buenos Aires", "Catamarca", "Chaco", "Chubut", "Ciudad Autónoma de Buenos Aires (CABA)", "Córdoba", "Corrientes", "Entre Ríos", "Formosa", "Jujuy", "La Pampa", "La Rioja", "Mendoza", "Misiones", "Neuquén", "Río Negro", "Salta", "San Juan", "San Luis", "Santa Cruz", "Santa Fe", "Santiago del Estero", "Tierra del Fuego", "Tucumán" });
            ProvinciaComboBox.Location = new Point(87, 120);
            ProvinciaComboBox.Name = "ProvinciaComboBox";
            ProvinciaComboBox.Size = new Size(198, 23);
            ProvinciaComboBox.TabIndex = 20;
            // 
            // ProvinciaLabel
            // 
            ProvinciaLabel.AutoSize = true;
            ProvinciaLabel.Location = new Point(22, 123);
            ProvinciaLabel.Name = "ProvinciaLabel";
            ProvinciaLabel.Size = new Size(59, 15);
            ProvinciaLabel.TabIndex = 24;
            ProvinciaLabel.Text = "Provincia:";
            // 
            // DireccionDestinatarioTextBox
            // 
            DireccionDestinatarioTextBox.BackColor = SystemColors.ScrollBar;
            DireccionDestinatarioTextBox.Location = new Point(114, 245);
            DireccionDestinatarioTextBox.Name = "DireccionDestinatarioTextBox";
            DireccionDestinatarioTextBox.Size = new Size(184, 23);
            DireccionDestinatarioTextBox.TabIndex = 27;
            // 
            // LocalidadLabel
            // 
            LocalidadLabel.AutoSize = true;
            LocalidadLabel.Location = new Point(22, 161);
            LocalidadLabel.Name = "LocalidadLabel";
            LocalidadLabel.Size = new Size(61, 15);
            LocalidadLabel.TabIndex = 25;
            LocalidadLabel.Text = "Localidad:";
            // 
            // DireccionLabel
            // 
            DireccionLabel.AutoSize = true;
            DireccionLabel.Location = new Point(16, 248);
            DireccionLabel.Name = "DireccionLabel";
            DireccionLabel.Size = new Size(60, 15);
            DireccionLabel.TabIndex = 26;
            DireccionLabel.Text = "Dirección:";
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
            EncomiendasGroupBox.Location = new Point(82, 604);
            EncomiendasGroupBox.Name = "EncomiendasGroupBox";
            EncomiendasGroupBox.Size = new Size(642, 126);
            EncomiendasGroupBox.TabIndex = 5;
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
            // SalirButton
            // 
            SalirButton.Location = new Point(573, 765);
            SalirButton.Name = "SalirButton";
            SalirButton.Size = new Size(84, 29);
            SalirButton.TabIndex = 13;
            SalirButton.Text = "Salir";
            SalirButton.UseVisualStyleBackColor = true;
            // 
            // ConfirmarButton
            // 
            ConfirmarButton.Location = new Point(663, 765);
            ConfirmarButton.Name = "ConfirmarButton";
            ConfirmarButton.Size = new Size(87, 29);
            ConfirmarButton.TabIndex = 12;
            ConfirmarButton.Text = "Confirmar";
            ConfirmarButton.UseVisualStyleBackColor = true;
            // 
            // CentroDistribucionComboBox
            // 
            CentroDistribucionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CentroDistribucionComboBox.FormattingEnabled = true;
            CentroDistribucionComboBox.Location = new Point(374, 330);
            CentroDistribucionComboBox.Name = "CentroDistribucionComboBox";
            CentroDistribucionComboBox.Size = new Size(204, 23);
            CentroDistribucionComboBox.TabIndex = 55;
            // 
            // CentroLabel
            // 
            CentroLabel.AutoSize = true;
            CentroLabel.Location = new Point(342, 333);
            CentroLabel.Name = "CentroLabel";
            CentroLabel.Size = new Size(26, 15);
            CentroLabel.TabIndex = 54;
            CentroLabel.Text = "CD:";
            // 
            // AgenciaComboBox
            // 
            AgenciaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            AgenciaComboBox.FormattingEnabled = true;
            AgenciaComboBox.Location = new Point(93, 330);
            AgenciaComboBox.Name = "AgenciaComboBox";
            AgenciaComboBox.Size = new Size(192, 23);
            AgenciaComboBox.TabIndex = 53;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 333);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 52;
            label2.Text = "Agencia:";
            // 
            // ImponerEncomiendaCallCenterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 801);
            Controls.Add(SalirButton);
            Controls.Add(ConfirmarButton);
            Controls.Add(EncomiendasGroupBox);
            Controls.Add(DestinatarioGroupBox);
            Controls.Add(RemitenteGroupBox);
            Controls.Add(label1);
            Name = "ImponerEncomiendaCallCenterForm";
            Text = "Imposición de encomiendas";
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
        private Label label6;
        private Label label5;
        private Label label4;
        private Label DireccionClienteLabel;
        private Label TelefonoClienteLabel;
        private Label NombreClienteLabel;
        private Button BuscarCuitButton;
        private MaskedTextBox CUITRemitenteMaskedText;
        private Label CuitLabel;
        private Label label1;
        private GroupBox DestinatarioGroupBox;
        private TextBox DNIDestinatarioTextBox;
        private Label DNILabel;
        private TextBox textBox1;
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
        private Button SalirButton;
        private Button ConfirmarButton;
        private ComboBox comboBox1;
        private TextBox CodigoPostalTextBox;
        private Label CodigoPostalLabel;
        private Label TipoEntregaLabel;
        private ComboBox TipoEntregaComboBox;
        private Label label3;
        private ComboBox ProvinciaComboBox;
        private Label ProvinciaLabel;
        private TextBox DireccionDestinatarioTextBox;
        private Label LocalidadLabel;
        private Label DireccionLabel;
        private ComboBox CentroDistribucionComboBox;
        private Label CentroLabel;
        private ComboBox AgenciaComboBox;
        private Label label2;
    }
}