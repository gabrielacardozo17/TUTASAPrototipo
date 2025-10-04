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
            BuscarEstadoGuiaButton = new Button();
            label5 = new Label();
            NroGuiaLabel = new Label();
            NroGuiaBusquedaTextBox = new TextBox();
            ResultadoComboBox = new GroupBox();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            listView1 = new ListView();
            FechaColumn = new ColumnHeader();
            EstadoColumn = new ColumnHeader();
            UbicacionColumn = new ColumnHeader();
            SalirButton = new Button();
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
            groupBox1.Controls.Add(BuscarEstadoGuiaButton);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(NroGuiaLabel);
            groupBox1.Controls.Add(NroGuiaBusquedaTextBox);
            groupBox1.Location = new Point(61, 36);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(434, 125);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Búsqueda de encomienda";
            // 
            // BuscarEstadoGuiaButton
            // 
            BuscarEstadoGuiaButton.Location = new Point(353, 59);
            BuscarEstadoGuiaButton.Name = "BuscarEstadoGuiaButton";
            BuscarEstadoGuiaButton.Size = new Size(75, 23);
            BuscarEstadoGuiaButton.TabIndex = 6;
            BuscarEstadoGuiaButton.Text = "Buscar";
            BuscarEstadoGuiaButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 62);
            label5.Name = "label5";
            label5.Size = new Size(96, 15);
            label5.TabIndex = 5;
            label5.Text = "Número de guía:";
            // 
            // NroGuiaLabel
            // 
            NroGuiaLabel.AutoSize = true;
            NroGuiaLabel.Location = new Point(6, 28);
            NroGuiaLabel.Name = "NroGuiaLabel";
            NroGuiaLabel.Size = new Size(349, 15);
            NroGuiaLabel.TabIndex = 4;
            NroGuiaLabel.Text = "Ingrese el número de guía de la encomienda que desea consultar";
            NroGuiaLabel.Click += label3_Click;
            // 
            // NroGuiaBusquedaTextBox
            // 
            NroGuiaBusquedaTextBox.Location = new Point(108, 59);
            NroGuiaBusquedaTextBox.Name = "NroGuiaBusquedaTextBox";
            NroGuiaBusquedaTextBox.Size = new Size(233, 23);
            NroGuiaBusquedaTextBox.TabIndex = 3;
            NroGuiaBusquedaTextBox.TextChanged += NroGuiaBusquedaTextBox_TextChanged;
            // 
            // ResultadoComboBox
            // 
            ResultadoComboBox.Controls.Add(label6);
            ResultadoComboBox.Controls.Add(label4);
            ResultadoComboBox.Controls.Add(label3);
            ResultadoComboBox.Controls.Add(listView1);
            ResultadoComboBox.Location = new Point(69, 188);
            ResultadoComboBox.Name = "ResultadoComboBox";
            ResultadoComboBox.Size = new Size(426, 170);
            ResultadoComboBox.TabIndex = 2;
            ResultadoComboBox.TabStop = false;
            ResultadoComboBox.Text = "Resultado de la búsqueda";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(246, 60);
            label6.Name = "label6";
            label6.Size = new Size(65, 15);
            label6.TabIndex = 5;
            label6.Text = "CD Rosario";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(126, 60);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 4;
            label4.Text = "Impuesta";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(29, 60);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 3;
            label3.Text = "09/09/2025";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { FechaColumn, EstadoColumn, UbicacionColumn });
            listView1.Location = new Point(19, 37);
            listView1.Name = "listView1";
            listView1.Size = new Size(387, 97);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // FechaColumn
            // 
            FechaColumn.Text = "Fecha";
            FechaColumn.Width = 100;
            // 
            // EstadoColumn
            // 
            EstadoColumn.Text = "Estado";
            EstadoColumn.Width = 120;
            // 
            // UbicacionColumn
            // 
            UbicacionColumn.Text = "Ubicación";
            UbicacionColumn.Width = 160;
            // 
            // SalirButton
            // 
            SalirButton.Location = new Point(464, 391);
            SalirButton.Name = "SalirButton";
            SalirButton.Size = new Size(75, 28);
            SalirButton.TabIndex = 3;
            SalirButton.Text = "Salir";
            SalirButton.UseVisualStyleBackColor = true;
            // 
            // ConsultarEstadoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(595, 431);
            Controls.Add(SalirButton);
            Controls.Add(ResultadoComboBox);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "ConsultarEstadoForm";
            Text = "Consulta de Encomiendas";
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
        private TextBox NroGuiaBusquedaTextBox;
        private GroupBox ResultadoComboBox;
        private ListView listView1;
        private ColumnHeader FechaColumn;
        private ColumnHeader EstadoColumn;
        private Button SalirButton;
        private Label NroGuiaLabel;
        private Label label4;
        private Label label3;
        private Button BuscarEstadoGuiaButton;
        private Label label5;
        private ColumnHeader UbicacionColumn;
        private Label label6;
    }
}