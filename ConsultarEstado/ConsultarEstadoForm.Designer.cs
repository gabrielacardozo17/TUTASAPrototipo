namespace TUTASAPrototipo.ConsultarEstado
{
    partial class ConsultarEstadoForm
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
            label1 = new Label();
            groupBox1 = new GroupBox();
            NroGuiaLabel = new Label();
            NroGuiaBusquedaTextBox = new TextBox();
            DesplegableConsultaComboBox = new ComboBox();
            ConsultaLabel = new Label();
            label2 = new Label();
            ResultadoComboBox = new GroupBox();
            listView1 = new ListView();
            FechaColumn = new ColumnHeader();
            EstadoColumn = new ColumnHeader();
            SalirButton = new Button();
            label3 = new Label();
            label4 = new Label();
            groupBox1.SuspendLayout();
            ResultadoComboBox.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(293, 49);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(NroGuiaLabel);
            groupBox1.Controls.Add(NroGuiaBusquedaTextBox);
            groupBox1.Controls.Add(DesplegableConsultaComboBox);
            groupBox1.Controls.Add(ConsultaLabel);
            groupBox1.Location = new Point(61, 36);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(434, 115);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Criterios de búsqueda";
            // 
            // NroGuiaLabel
            // 
            NroGuiaLabel.AutoSize = true;
            NroGuiaLabel.Location = new Point(17, 72);
            NroGuiaLabel.Name = "NroGuiaLabel";
            NroGuiaLabel.Size = new Size(54, 15);
            NroGuiaLabel.TabIndex = 4;
            NroGuiaLabel.Text = "Número:";
            NroGuiaLabel.Click += label3_Click;
            // 
            // NroGuiaBusquedaTextBox
            // 
            NroGuiaBusquedaTextBox.Location = new Point(123, 69);
            NroGuiaBusquedaTextBox.Name = "NroGuiaBusquedaTextBox";
            NroGuiaBusquedaTextBox.Size = new Size(233, 23);
            NroGuiaBusquedaTextBox.TabIndex = 3;
            // 
            // DesplegableConsultaComboBox
            // 
            DesplegableConsultaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            DesplegableConsultaComboBox.FormattingEnabled = true;
            DesplegableConsultaComboBox.Items.AddRange(new object[] { "Guía", "Hoja de Ruta" });
            DesplegableConsultaComboBox.Location = new Point(123, 35);
            DesplegableConsultaComboBox.Name = "DesplegableConsultaComboBox";
            DesplegableConsultaComboBox.Size = new Size(233, 23);
            DesplegableConsultaComboBox.TabIndex = 1;
            // 
            // ConsultaLabel
            // 
            ConsultaLabel.AutoSize = true;
            ConsultaLabel.Location = new Point(17, 38);
            ConsultaLabel.Name = "ConsultaLabel";
            ConsultaLabel.Size = new Size(82, 15);
            ConsultaLabel.TabIndex = 0;
            ConsultaLabel.Text = "Consultar por:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(179, 0);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 2;
            label2.Text = "Número de Guía:";
            // 
            // ResultadoComboBox
            // 
            ResultadoComboBox.Controls.Add(label4);
            ResultadoComboBox.Controls.Add(label3);
            ResultadoComboBox.Controls.Add(listView1);
            ResultadoComboBox.Controls.Add(label2);
            ResultadoComboBox.Location = new Point(69, 188);
            ResultadoComboBox.Name = "ResultadoComboBox";
            ResultadoComboBox.Size = new Size(426, 197);
            ResultadoComboBox.TabIndex = 2;
            ResultadoComboBox.TabStop = false;
            ResultadoComboBox.Text = "Resultado de la búsqueda";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { FechaColumn, EstadoColumn });
            listView1.Location = new Point(9, 40);
            listView1.Name = "listView1";
            listView1.Size = new Size(411, 97);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // FechaColumn
            // 
            FechaColumn.Text = "Fecha";
            FechaColumn.Width = 200;
            // 
            // EstadoColumn
            // 
            EstadoColumn.Text = "Estado";
            EstadoColumn.Width = 200;
            // 
            // SalirButton
            // 
            SalirButton.Location = new Point(439, 416);
            SalirButton.Name = "SalirButton";
            SalirButton.Size = new Size(75, 28);
            SalirButton.TabIndex = 3;
            SalirButton.Text = "Salir";
            SalirButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(26, 60);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 3;
            label3.Text = "09/09/2025";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(220, 60);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 4;
            label4.Text = "Impuesta";
            // 
            // ConsultarEstadoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(545, 456);
            Controls.Add(SalirButton);
            Controls.Add(ResultadoComboBox);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "ConsultarEstadoForm";
            Text = "Consulta de Estado";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResultadoComboBox.ResumeLayout(false);
            ResultadoComboBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Label ConsultaLabel;
        private Label label2;
        private ComboBox DesplegableConsultaComboBox;
        private TextBox NroGuiaBusquedaTextBox;
        private GroupBox ResultadoComboBox;
        private ListView listView1;
        private ColumnHeader FechaColumn;
        private ColumnHeader EstadoColumn;
        private Button SalirButton;
        private Label NroGuiaLabel;
        private Label label4;
        private Label label3;
    }
}