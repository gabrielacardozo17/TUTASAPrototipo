namespace TUTASAPrototipo.AdmitirEncomienda
{
    partial class AdmitirEncomiendaForm
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
            BusquedaGuiaGroupBox = new GroupBox();
            BuscarGuiaButton = new Button();
            NumGuiaTextBox = new TextBox();
            NumGuiaLabel = new Label();
            IndicacionLabel = new Label();
            ResultadoGroupBox = new GroupBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            OrigenLabel = new Label();
            DestinoLabel = new Label();
            TipoEntregaLabel = new Label();
            TipoEncomiendaLabel = new Label();
            checkBox1 = new CheckBox();
            TamanioLabel = new Label();
            ValidacionesGroupBox = new GroupBox();
            label1 = new Label();
            AdmitirGuiaButton = new Button();
            SalirButton = new Button();
            label7 = new Label();
            BusquedaGuiaGroupBox.SuspendLayout();
            ResultadoGroupBox.SuspendLayout();
            ValidacionesGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // BusquedaGuiaGroupBox
            // 
            BusquedaGuiaGroupBox.Controls.Add(BuscarGuiaButton);
            BusquedaGuiaGroupBox.Controls.Add(NumGuiaTextBox);
            BusquedaGuiaGroupBox.Controls.Add(NumGuiaLabel);
            BusquedaGuiaGroupBox.Controls.Add(IndicacionLabel);
            BusquedaGuiaGroupBox.Location = new Point(29, 71);
            BusquedaGuiaGroupBox.Name = "BusquedaGuiaGroupBox";
            BusquedaGuiaGroupBox.Size = new Size(737, 100);
            BusquedaGuiaGroupBox.TabIndex = 0;
            BusquedaGuiaGroupBox.TabStop = false;
            BusquedaGuiaGroupBox.Text = "Búsqueda de Guía";
            // 
            // BuscarGuiaButton
            // 
            BuscarGuiaButton.Location = new Point(392, 57);
            BuscarGuiaButton.Name = "BuscarGuiaButton";
            BuscarGuiaButton.Size = new Size(75, 22);
            BuscarGuiaButton.TabIndex = 3;
            BuscarGuiaButton.Text = "Buscar";
            BuscarGuiaButton.UseVisualStyleBackColor = true;
            // 
            // NumGuiaTextBox
            // 
            NumGuiaTextBox.Location = new Point(108, 57);
            NumGuiaTextBox.Name = "NumGuiaTextBox";
            NumGuiaTextBox.Size = new Size(246, 23);
            NumGuiaTextBox.TabIndex = 2;
            // 
            // NumGuiaLabel
            // 
            NumGuiaLabel.AutoSize = true;
            NumGuiaLabel.Location = new Point(6, 60);
            NumGuiaLabel.Name = "NumGuiaLabel";
            NumGuiaLabel.Size = new Size(96, 15);
            NumGuiaLabel.TabIndex = 1;
            NumGuiaLabel.Text = "Número de guía:";
            // 
            // IndicacionLabel
            // 
            IndicacionLabel.AutoSize = true;
            IndicacionLabel.Location = new Point(6, 29);
            IndicacionLabel.Name = "IndicacionLabel";
            IndicacionLabel.Size = new Size(338, 15);
            IndicacionLabel.TabIndex = 0;
            IndicacionLabel.Text = "Ingrese el número de guía de la encomienda que desea admitir";
            // 
            // ResultadoGroupBox
            // 
            ResultadoGroupBox.Controls.Add(label6);
            ResultadoGroupBox.Controls.Add(label5);
            ResultadoGroupBox.Controls.Add(label4);
            ResultadoGroupBox.Controls.Add(label3);
            ResultadoGroupBox.Controls.Add(OrigenLabel);
            ResultadoGroupBox.Controls.Add(DestinoLabel);
            ResultadoGroupBox.Controls.Add(TipoEntregaLabel);
            ResultadoGroupBox.Controls.Add(TipoEncomiendaLabel);
            ResultadoGroupBox.Location = new Point(29, 193);
            ResultadoGroupBox.Name = "ResultadoGroupBox";
            ResultadoGroupBox.Size = new Size(737, 100);
            ResultadoGroupBox.TabIndex = 1;
            ResultadoGroupBox.TabStop = false;
            ResultadoGroupBox.Text = "Datos de imposición de la guía ingresada ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 8F);
            label6.Location = new Point(540, 56);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(52, 13);
            label6.TabIndex = 17;
            label6.Text = "Chivilcoy";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 8F);
            label5.Location = new Point(540, 31);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(37, 13);
            label5.TabIndex = 16;
            label5.Text = "Lanús";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 8F);
            label4.Location = new Point(163, 56);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(64, 13);
            label4.TabIndex = 15;
            label4.Text = "En Agencia";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8F);
            label3.Location = new Point(163, 31);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(77, 13);
            label3.TabIndex = 14;
            label3.Text = "L (hasta 10kg)";
            // 
            // OrigenLabel
            // 
            OrigenLabel.AutoSize = true;
            OrigenLabel.Font = new Font("Segoe UI", 8F);
            OrigenLabel.Location = new Point(479, 31);
            OrigenLabel.Margin = new Padding(4, 0, 4, 0);
            OrigenLabel.Name = "OrigenLabel";
            OrigenLabel.Size = new Size(46, 13);
            OrigenLabel.TabIndex = 13;
            OrigenLabel.Text = "Origen:";
            // 
            // DestinoLabel
            // 
            DestinoLabel.AutoSize = true;
            DestinoLabel.Font = new Font("Segoe UI", 8F);
            DestinoLabel.Location = new Point(479, 56);
            DestinoLabel.Margin = new Padding(4, 0, 4, 0);
            DestinoLabel.Name = "DestinoLabel";
            DestinoLabel.Size = new Size(53, 13);
            DestinoLabel.TabIndex = 12;
            DestinoLabel.Text = "Destino: ";
            // 
            // TipoEntregaLabel
            // 
            TipoEntregaLabel.AutoSize = true;
            TipoEntregaLabel.Font = new Font("Segoe UI", 8F);
            TipoEntregaLabel.Location = new Point(9, 56);
            TipoEntregaLabel.Margin = new Padding(4, 0, 4, 0);
            TipoEntregaLabel.Name = "TipoEntregaLabel";
            TipoEntregaLabel.Size = new Size(92, 13);
            TipoEntregaLabel.TabIndex = 11;
            TipoEntregaLabel.Text = "Tipo de entrega:";
            // 
            // TipoEncomiendaLabel
            // 
            TipoEncomiendaLabel.AutoSize = true;
            TipoEncomiendaLabel.Font = new Font("Segoe UI", 8F);
            TipoEncomiendaLabel.Location = new Point(9, 31);
            TipoEncomiendaLabel.Margin = new Padding(4, 0, 4, 0);
            TipoEncomiendaLabel.Name = "TipoEncomiendaLabel";
            TipoEncomiendaLabel.Size = new Size(118, 13);
            TipoEncomiendaLabel.TabIndex = 10;
            TipoEncomiendaLabel.Text = "Tipo de encomienda: ";
            TipoEncomiendaLabel.Click += TipoEncomiendaLabel_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 8F);
            checkBox1.Location = new Point(212, 57);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 19;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // TamanioLabel
            // 
            TamanioLabel.AutoSize = true;
            TamanioLabel.Font = new Font("Segoe UI", 8F);
            TamanioLabel.Location = new Point(9, 28);
            TamanioLabel.Name = "TamanioLabel";
            TamanioLabel.Size = new Size(573, 13);
            TamanioLabel.TabIndex = 18;
            TamanioLabel.Text = "En caso de que el tipo de encomienda no coincida con los datos impuestos, realice las correcciones necesarias";
            // 
            // ValidacionesGroupBox
            // 
            ValidacionesGroupBox.Controls.Add(label1);
            ValidacionesGroupBox.Controls.Add(checkBox1);
            ValidacionesGroupBox.Controls.Add(TamanioLabel);
            ValidacionesGroupBox.Location = new Point(38, 318);
            ValidacionesGroupBox.Name = "ValidacionesGroupBox";
            ValidacionesGroupBox.Size = new Size(728, 135);
            ValidacionesGroupBox.TabIndex = 20;
            ValidacionesGroupBox.TabStop = false;
            ValidacionesGroupBox.Text = "Validaciones";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 56);
            label1.Name = "label1";
            label1.Size = new Size(177, 15);
            label1.TabIndex = 19;
            label1.Text = "¿Modificar tipo de encomienda?";
            // 
            // AdmitirGuiaButton
            // 
            AdmitirGuiaButton.Location = new Point(685, 493);
            AdmitirGuiaButton.Name = "AdmitirGuiaButton";
            AdmitirGuiaButton.Size = new Size(93, 26);
            AdmitirGuiaButton.TabIndex = 21;
            AdmitirGuiaButton.Text = "Admitir";
            AdmitirGuiaButton.UseVisualStyleBackColor = true;
            AdmitirGuiaButton.Click += AdmitirGuiaButton_Click;
            // 
            // SalirButton
            // 
            SalirButton.Location = new Point(569, 493);
            SalirButton.Name = "SalirButton";
            SalirButton.Size = new Size(93, 26);
            SalirButton.TabIndex = 22;
            SalirButton.Text = "Salir";
            SalirButton.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F);
            label7.Location = new Point(250, 32);
            label7.Name = "label7";
            label7.Size = new Size(265, 25);
            label7.TabIndex = 23;
            label7.Text = "ADMISIÓN DE ENCOMIENDAS";
            // 
            // AdmitirEncomiendaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 531);
            Controls.Add(label7);
            Controls.Add(SalirButton);
            Controls.Add(AdmitirGuiaButton);
            Controls.Add(ValidacionesGroupBox);
            Controls.Add(ResultadoGroupBox);
            Controls.Add(BusquedaGuiaGroupBox);
            Name = "AdmitirEncomiendaForm";
            Text = "Admisión de encomiendas";
            BusquedaGuiaGroupBox.ResumeLayout(false);
            BusquedaGuiaGroupBox.PerformLayout();
            ResultadoGroupBox.ResumeLayout(false);
            ResultadoGroupBox.PerformLayout();
            ValidacionesGroupBox.ResumeLayout(false);
            ValidacionesGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox BusquedaGuiaGroupBox;
        private Label IndicacionLabel;
        private Button BuscarGuiaButton;
        private TextBox NumGuiaTextBox;
        private Label NumGuiaLabel;
        private GroupBox ResultadoGroupBox;
        private CheckBox checkBox1;
        private Label TamanioLabel;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label OrigenLabel;
        private Label DestinoLabel;
        private Label TipoEntregaLabel;
        private Label TipoEncomiendaLabel;
        private GroupBox ValidacionesGroupBox;
        private Label label1;
        private Button AdmitirGuiaButton;
        private Button SalirButton;
        private Label label7;
    }
}