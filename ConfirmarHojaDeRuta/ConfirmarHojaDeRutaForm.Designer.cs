namespace TUTASAPrototipo.ConfirmarHojaDeRuta
{
    partial class ConfirmarHojaDeRutaForm
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
            BusquedaGroupBox = new GroupBox();
            BuscarHDRButton = new Button();
            IdHDRTextBox = new TextBox();
            InstruccionLabel = new Label();
            ResultadoGroupBox = new GroupBox();
            label1 = new Label();
            ConfirmarHDRButton = new Button();
            VolverMenuButton = new Button();
            checkBox1 = new CheckBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            checkBox2 = new CheckBox();
            label6 = new Label();
            TamañoColumn = new DataGridViewTextBoxColumn();
            DestinoColumn = new DataGridViewTextBoxColumn();
            NroGuiaColumn = new DataGridViewTextBoxColumn();
            EnBodegaCheck = new DataGridViewCheckBoxColumn();
            dataGridView1 = new DataGridView();
            label7 = new Label();
            BusquedaGroupBox.SuspendLayout();
            ResultadoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // BusquedaGroupBox
            // 
            BusquedaGroupBox.Controls.Add(BuscarHDRButton);
            BusquedaGroupBox.Controls.Add(IdHDRTextBox);
            BusquedaGroupBox.Controls.Add(InstruccionLabel);
            BusquedaGroupBox.Location = new Point(58, 55);
            BusquedaGroupBox.Name = "BusquedaGroupBox";
            BusquedaGroupBox.Size = new Size(809, 87);
            BusquedaGroupBox.TabIndex = 1;
            BusquedaGroupBox.TabStop = false;
            BusquedaGroupBox.Text = "Búsqueda ";
            // 
            // BuscarHDRButton
            // 
            BuscarHDRButton.Location = new Point(523, 32);
            BuscarHDRButton.Name = "BuscarHDRButton";
            BuscarHDRButton.Size = new Size(75, 23);
            BuscarHDRButton.TabIndex = 2;
            BuscarHDRButton.Text = "Buscar";
            BuscarHDRButton.UseVisualStyleBackColor = true;
            // 
            // IdHDRTextBox
            // 
            IdHDRTextBox.Location = new Point(306, 32);
            IdHDRTextBox.Name = "IdHDRTextBox";
            IdHDRTextBox.Size = new Size(199, 23);
            IdHDRTextBox.TabIndex = 1;
            // 
            // InstruccionLabel
            // 
            InstruccionLabel.AutoSize = true;
            InstruccionLabel.Location = new Point(6, 35);
            InstruccionLabel.Name = "InstruccionLabel";
            InstruccionLabel.Size = new Size(283, 15);
            InstruccionLabel.TabIndex = 0;
            InstruccionLabel.Text = "Ingrese el Id de la Hoja de Ruta que desea confirmar:";
            // 
            // ResultadoGroupBox
            // 
            ResultadoGroupBox.Controls.Add(label7);
            ResultadoGroupBox.Controls.Add(label6);
            ResultadoGroupBox.Controls.Add(checkBox2);
            ResultadoGroupBox.Controls.Add(label5);
            ResultadoGroupBox.Controls.Add(label4);
            ResultadoGroupBox.Controls.Add(label3);
            ResultadoGroupBox.Controls.Add(label2);
            ResultadoGroupBox.Controls.Add(checkBox1);
            ResultadoGroupBox.Controls.Add(label1);
            ResultadoGroupBox.Controls.Add(dataGridView1);
            ResultadoGroupBox.Location = new Point(58, 170);
            ResultadoGroupBox.Name = "ResultadoGroupBox";
            ResultadoGroupBox.Size = new Size(809, 234);
            ResultadoGroupBox.TabIndex = 2;
            ResultadoGroupBox.TabStop = false;
            ResultadoGroupBox.Text = "Confirmación";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 30);
            label1.Name = "label1";
            label1.Size = new Size(631, 15);
            label1.TabIndex = 3;
            label1.Text = "Seleccione las guías que corresponden a las encomiendas que han ingresado correctamente en la bodega del omnibús";
            // 
            // ConfirmarHDRButton
            // 
            ConfirmarHDRButton.Font = new Font("Segoe UI", 9F);
            ConfirmarHDRButton.Location = new Point(793, 456);
            ConfirmarHDRButton.Name = "ConfirmarHDRButton";
            ConfirmarHDRButton.Size = new Size(86, 30);
            ConfirmarHDRButton.TabIndex = 7;
            ConfirmarHDRButton.Text = "Confirmar ";
            ConfirmarHDRButton.UseVisualStyleBackColor = true;
            ConfirmarHDRButton.Click += ActualizarEstadoButton_Click;
            // 
            // VolverMenuButton
            // 
            VolverMenuButton.Font = new Font("Segoe UI", 9F);
            VolverMenuButton.Location = new Point(708, 456);
            VolverMenuButton.Name = "VolverMenuButton";
            VolverMenuButton.Size = new Size(79, 30);
            VolverMenuButton.TabIndex = 8;
            VolverMenuButton.Text = "Salir";
            VolverMenuButton.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(121, 91);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 4;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(225, 90);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 9;
            label2.Text = "LNS566548";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(441, 90);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 10;
            label3.Text = "Córdoba";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(653, 91);
            label4.Name = "label4";
            label4.Size = new Size(13, 15);
            label4.TabIndex = 11;
            label4.Text = "L";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(225, 115);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 12;
            label5.Text = "LNS562366";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(121, 116);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(15, 14);
            checkBox2.TabIndex = 13;
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(441, 115);
            label6.Name = "label6";
            label6.Size = new Size(53, 15);
            label6.TabIndex = 14;
            label6.Text = "Córdoba";
            // 
            // TamañoColumn
            // 
            TamañoColumn.HeaderText = "Tamaño de encomienda";
            TamañoColumn.Name = "TamañoColumn";
            TamañoColumn.ReadOnly = true;
            TamañoColumn.Width = 160;
            // 
            // DestinoColumn
            // 
            DestinoColumn.HeaderText = "Destino";
            DestinoColumn.Name = "DestinoColumn";
            DestinoColumn.ReadOnly = true;
            DestinoColumn.Width = 200;
            // 
            // NroGuiaColumn
            // 
            NroGuiaColumn.HeaderText = "Nro de Guía";
            NroGuiaColumn.Name = "NroGuiaColumn";
            NroGuiaColumn.ReadOnly = true;
            NroGuiaColumn.Width = 200;
            // 
            // EnBodegaCheck
            // 
            EnBodegaCheck.HeaderText = "¿Ingresada?";
            EnBodegaCheck.Name = "EnBodegaCheck";
            EnBodegaCheck.ReadOnly = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { EnBodegaCheck, NroGuiaColumn, DestinoColumn, TamañoColumn });
            dataGridView1.Location = new Point(51, 59);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(703, 147);
            dataGridView1.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = SystemColors.ButtonHighlight;
            label7.Location = new Point(653, 115);
            label7.Name = "label7";
            label7.Size = new Size(13, 15);
            label7.TabIndex = 15;
            label7.Text = "S";
            // 
            // ConfirmarHojaDeRutaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 499);
            Controls.Add(VolverMenuButton);
            Controls.Add(ConfirmarHDRButton);
            Controls.Add(ResultadoGroupBox);
            Controls.Add(BusquedaGroupBox);
            Name = "ConfirmarHojaDeRutaForm";
            Text = "Confirmación de Hojas de Ruta";
            BusquedaGroupBox.ResumeLayout(false);
            BusquedaGroupBox.PerformLayout();
            ResultadoGroupBox.ResumeLayout(false);
            ResultadoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox BusquedaGroupBox;
        private Label InstruccionLabel;
        private Button BuscarHDRButton;
        private TextBox IdHDRTextBox;
        private GroupBox ResultadoGroupBox;
        private Button ConfirmarHDRButton;
        private Button VolverMenuButton;
        private Label label1;
        private Label label3;
        private Label label2;
        private CheckBox checkBox1;
        private Label label4;
        private Label label7;
        private Label label6;
        private CheckBox checkBox2;
        private Label label5;
        private DataGridView dataGridView1;
        private DataGridViewCheckBoxColumn EnBodegaCheck;
        private DataGridViewTextBoxColumn NroGuiaColumn;
        private DataGridViewTextBoxColumn DestinoColumn;
        private DataGridViewTextBoxColumn TamañoColumn;
    }
}