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
            DireccionClienteResult = new Label();
            TelefonoClienteResult = new Label();
            NombreClienteResult = new Label();
            DireccionClienteLabel = new Label();
            TelefonoClienteLabel = new Label();
            NombreClienteLabel = new Label();
            BuscarCuitButton = new Button();
            CUITRemitenteMaskedText = new MaskedTextBox();
            CuitLabel = new Label();
            label1 = new Label();
            DestinatarioGroupBox = new GroupBox();
            CentroDistribucionComboBox = new ComboBox();
            DNIDestinatarioTextBox = new TextBox();
            CentroLabel = new Label();
            DNILabel = new Label();
            AgenciaComboBox = new ComboBox();
            LocalidadxProvinciaComboBox = new ComboBox();
            label2 = new Label();
            ApellidoDestinatarioTextBox = new TextBox();
            CodigoPostalTextBox = new TextBox();
            ApellidoDestinatarioLabel = new Label();
            CodigoPostalLabel = new Label();
            NombreDestinatarioTextBox = new TextBox();
            TipoEntregaLabel = new Label();
            NombreDestinatarioLabel = new Label();
            TipoEntregaComboBox = new ComboBox();
            IndicacionLabel = new Label();
            ProvinciaComboBox = new ComboBox();
            ProvinciaLabel = new Label();
            DireccionDestinatarioTextBox = new TextBox();
            LocalidadLabel = new Label();
            DireccionLabel = new Label();
            TelefonoDestinatarioTextBox = new TextBox();
            TelefonoDestinatarioLabel = new Label();
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
            ConfirmarButton = new Button();
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
            CuitLabel.Size = new Size(36, 15);
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
            DestinatarioGroupBox.Controls.Add(LocalidadxProvinciaComboBox);
            DestinatarioGroupBox.Controls.Add(label2);
            DestinatarioGroupBox.Controls.Add(ApellidoDestinatarioTextBox);
            DestinatarioGroupBox.Controls.Add(CodigoPostalTextBox);
            DestinatarioGroupBox.Controls.Add(ApellidoDestinatarioLabel);
            DestinatarioGroupBox.Controls.Add(CodigoPostalLabel);
            DestinatarioGroupBox.Controls.Add(NombreDestinatarioTextBox);
            DestinatarioGroupBox.Controls.Add(TipoEntregaLabel);
            DestinatarioGroupBox.Controls.Add(NombreDestinatarioLabel);
            DestinatarioGroupBox.Controls.Add(TipoEntregaComboBox);
            DestinatarioGroupBox.Controls.Add(IndicacionLabel);
            DestinatarioGroupBox.Controls.Add(ProvinciaComboBox);
            DestinatarioGroupBox.Controls.Add(ProvinciaLabel);
            DestinatarioGroupBox.Controls.Add(DireccionDestinatarioTextBox);
            DestinatarioGroupBox.Controls.Add(LocalidadLabel);
            DestinatarioGroupBox.Controls.Add(DireccionLabel);
            DestinatarioGroupBox.Controls.Add(TelefonoDestinatarioTextBox);
            DestinatarioGroupBox.Controls.Add(TelefonoDestinatarioLabel);
            DestinatarioGroupBox.Location = new Point(82, 201);
            DestinatarioGroupBox.Name = "DestinatarioGroupBox";
            DestinatarioGroupBox.Size = new Size(640, 377);
            DestinatarioGroupBox.TabIndex = 4;
            DestinatarioGroupBox.TabStop = false;
            DestinatarioGroupBox.Text = "Datos del destinatario";
            // 
            // TelefonoDestinatarioTextBox
            // 
            TelefonoDestinatarioTextBox.Location = new Point(374, 60);
            TelefonoDestinatarioTextBox.Name = "TelefonoDestinatarioTextBox";
            TelefonoDestinatarioTextBox.Size = new Size(150, 23);
            TelefonoDestinatarioTextBox.TabIndex = 56;
            // 
            // TelefonoDestinatarioLabel
            // 
            TelefonoDestinatarioLabel.AutoSize = true;
            TelefonoDestinatarioLabel.Location = new Point(312, 64);
            TelefonoDestinatarioLabel.Name = "TelefonoDestinatarioLabel";
            TelefonoDestinatarioLabel.Size = new Size(56, 15);
            TelefonoDestinatarioLabel.TabIndex = 57;
            TelefonoDestinatarioLabel.Text = "Teléfono:";
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
            // CancelarButton
            // 
            CancelarButton.Location = new Point(573, 765);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(84, 29);
            CancelarButton.TabIndex = 13;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
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
            // ImponerEncomiendaCallCenterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 801);
            Controls.Add(CancelarButton);
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
        private Label DireccionClienteResult;
        private Label TelefonoClienteResult;
        private Label NombreClienteResult;
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
        private TextBox ApellidoDestinatarioTextBox;
        private Label ApellidoDestinatarioLabel;
        private TextBox NombreDestinatarioTextBox;
        private Label NombreDestinatarioLabel;
        private TextBox TelefonoDestinatarioTextBox;
        private Label TelefonoDestinatarioLabel;
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
        private Button ConfirmarButton;
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
        private ComboBox CentroDistribucionComboBox;
        private Label CentroLabel;
        private ComboBox AgenciaComboBox;
        private Label label2;
    }
}