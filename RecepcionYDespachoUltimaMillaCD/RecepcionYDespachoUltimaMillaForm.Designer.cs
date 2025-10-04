namespace TUTASAPrototipo.RecepcionYDespachoUltimaMillaCD
{
    partial class RecepcionYDespachoUltimaMillaForm
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
            groupBox2 = new GroupBox();
            checkBox3 = new CheckBox();
            label3 = new Label();
            label2 = new Label();
            listView1 = new ListView();
            NroGuia = new ColumnHeader();
            destinoColumn = new ColumnHeader();
            Cumplida = new ColumnHeader();
            groupBox1 = new GroupBox();
            button1 = new Button();
            GenerarNuevaHDRForm = new Button();
            label1 = new Label();
            SalirButton = new Button();
            ConfirmarRendicionButton = new Button();
            GuiasGroupBox = new GroupBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            NroGuiaColumn = new DataGridViewTextBoxColumn();
            DestinoCloumn = new DataGridViewTextBoxColumn();
            CumplidaColumn = new DataGridViewCheckBoxColumn();
            BusquedaGroupBox = new GroupBox();
            BuscarButton = new Button();
            NumHojaRutaTextBox = new TextBox();
            DNILabel = new Label();
            UsuarioLabel = new Label();
            CDLabel = new Label();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            GuiasGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            BusquedaGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(checkBox3);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(listView1);
            groupBox2.Location = new Point(69, 359);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(658, 170);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Detalle de guías de retiro asignadas:";
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(532, 60);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(15, 14);
            checkBox3.TabIndex = 7;
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(294, 59);
            label3.Name = "label3";
            label3.Size = new Size(124, 15);
            label3.TabIndex = 5;
            label3.Text = "Av. Lorem Ipsum 1013";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(108, 59);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 3;
            label2.Text = "LNS23546";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { NroGuia, destinoColumn, Cumplida });
            listView1.Location = new Point(89, 32);
            listView1.Name = "listView1";
            listView1.Size = new Size(518, 97);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // NroGuia
            // 
            NroGuia.Text = "Nro de Guía";
            NroGuia.Width = 200;
            // 
            // destinoColumn
            // 
            destinoColumn.Text = "Destino";
            destinoColumn.Width = 200;
            // 
            // Cumplida
            // 
            Cumplida.Text = "¿Cumplida?";
            Cumplida.Width = 100;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(GenerarNuevaHDRForm);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(75, 535);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(658, 100);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Crear nueva hoja de ruta";
            // 
            // button1
            // 
            button1.Location = new Point(327, 58);
            button1.Name = "button1";
            button1.Size = new Size(197, 23);
            button1.TabIndex = 6;
            button1.Text = "Generar Hoja de Ruta de Retiro";
            button1.UseVisualStyleBackColor = true;
            // 
            // GenerarNuevaHDRForm
            // 
            GenerarNuevaHDRForm.Location = new Point(83, 58);
            GenerarNuevaHDRForm.Name = "GenerarNuevaHDRForm";
            GenerarNuevaHDRForm.Size = new Size(237, 23);
            GenerarNuevaHDRForm.TabIndex = 1;
            GenerarNuevaHDRForm.Text = "Generar Hoja de Ruta de Distribución";
            GenerarNuevaHDRForm.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 28);
            label1.Name = "label1";
            label1.Size = new Size(371, 15);
            label1.TabIndex = 0;
            label1.Text = "Recuerde generar una nueva hoja de ruta para asignar a esta persona:";
            // 
            // SalirButton
            // 
            SalirButton.Location = new Point(571, 678);
            SalirButton.Name = "SalirButton";
            SalirButton.Size = new Size(75, 23);
            SalirButton.TabIndex = 10;
            SalirButton.Text = "Salir";
            SalirButton.UseVisualStyleBackColor = true;
            // 
            // ConfirmarRendicionButton
            // 
            ConfirmarRendicionButton.Location = new Point(652, 678);
            ConfirmarRendicionButton.Name = "ConfirmarRendicionButton";
            ConfirmarRendicionButton.Size = new Size(75, 23);
            ConfirmarRendicionButton.TabIndex = 9;
            ConfirmarRendicionButton.Text = "Confirmar";
            ConfirmarRendicionButton.UseVisualStyleBackColor = true;
            // 
            // GuiasGroupBox
            // 
            GuiasGroupBox.Controls.Add(checkBox2);
            GuiasGroupBox.Controls.Add(checkBox1);
            GuiasGroupBox.Controls.Add(label7);
            GuiasGroupBox.Controls.Add(label6);
            GuiasGroupBox.Controls.Add(label5);
            GuiasGroupBox.Controls.Add(label4);
            GuiasGroupBox.Controls.Add(dataGridView1);
            GuiasGroupBox.Location = new Point(69, 145);
            GuiasGroupBox.Name = "GuiasGroupBox";
            GuiasGroupBox.Size = new Size(658, 192);
            GuiasGroupBox.TabIndex = 8;
            GuiasGroupBox.TabStop = false;
            GuiasGroupBox.Text = "Detalle de guías de distribución asignadas:";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(532, 83);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(15, 14);
            checkBox2.TabIndex = 6;
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(532, 53);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 5;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = SystemColors.ButtonHighlight;
            label7.Location = new Point(318, 83);
            label7.Name = "label7";
            label7.Size = new Size(118, 15);
            label7.TabIndex = 4;
            label7.Text = "Av. Lorem Ipsum 306";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(318, 53);
            label6.Name = "label6";
            label6.Size = new Size(121, 15);
            label6.TabIndex = 3;
            label6.Text = "Av.Lorem Ipsum 2003";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(148, 82);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 2;
            label5.Text = "LNS36503";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(148, 54);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 1;
            label4.Text = "LNS36582";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { NroGuiaColumn, DestinoCloumn, CumplidaColumn });
            dataGridView1.Location = new Point(53, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(545, 138);
            dataGridView1.TabIndex = 0;
            // 
            // NroGuiaColumn
            // 
            NroGuiaColumn.HeaderText = "Nro de Guía";
            NroGuiaColumn.Name = "NroGuiaColumn";
            NroGuiaColumn.ReadOnly = true;
            NroGuiaColumn.Width = 200;
            // 
            // DestinoCloumn
            // 
            DestinoCloumn.HeaderText = "Destino";
            DestinoCloumn.Name = "DestinoCloumn";
            DestinoCloumn.ReadOnly = true;
            DestinoCloumn.Width = 200;
            // 
            // CumplidaColumn
            // 
            CumplidaColumn.HeaderText = "¿Cumplida?";
            CumplidaColumn.Name = "CumplidaColumn";
            CumplidaColumn.ReadOnly = true;
            // 
            // BusquedaGroupBox
            // 
            BusquedaGroupBox.Controls.Add(BuscarButton);
            BusquedaGroupBox.Controls.Add(NumHojaRutaTextBox);
            BusquedaGroupBox.Controls.Add(DNILabel);
            BusquedaGroupBox.Location = new Point(67, 39);
            BusquedaGroupBox.Name = "BusquedaGroupBox";
            BusquedaGroupBox.Size = new Size(660, 100);
            BusquedaGroupBox.TabIndex = 7;
            BusquedaGroupBox.TabStop = false;
            BusquedaGroupBox.Text = "Búsqueda";
            // 
            // BuscarButton
            // 
            BuscarButton.Location = new Point(434, 44);
            BuscarButton.Name = "BuscarButton";
            BuscarButton.Size = new Size(75, 23);
            BuscarButton.TabIndex = 2;
            BuscarButton.Text = "Buscar";
            BuscarButton.UseVisualStyleBackColor = true;
            // 
            // NumHojaRutaTextBox
            // 
            NumHojaRutaTextBox.Location = new Point(174, 44);
            NumHojaRutaTextBox.Name = "NumHojaRutaTextBox";
            NumHojaRutaTextBox.Size = new Size(228, 23);
            NumHojaRutaTextBox.TabIndex = 1;
            // 
            // DNILabel
            // 
            DNILabel.AutoSize = true;
            DNILabel.Location = new Point(21, 47);
            DNILabel.Name = "DNILabel";
            DNILabel.Size = new Size(147, 15);
            DNILabel.TabIndex = 0;
            DNILabel.Text = "Ingrese el número de DNI :";
            // 
            // UsuarioLabel
            // 
            UsuarioLabel.AutoSize = true;
            UsuarioLabel.Location = new Point(67, 9);
            UsuarioLabel.Name = "UsuarioLabel";
            UsuarioLabel.Size = new Size(50, 15);
            UsuarioLabel.TabIndex = 13;
            UsuarioLabel.Text = "Usuario:";
            // 
            // CDLabel
            // 
            CDLabel.AutoSize = true;
            CDLabel.Location = new Point(549, 9);
            CDLabel.Name = "CDLabel";
            CDLabel.Size = new Size(26, 15);
            CDLabel.TabIndex = 14;
            CDLabel.Text = "CD:";
            // 
            // RecepcionYDespachoUltimaMillaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 741);
            Controls.Add(CDLabel);
            Controls.Add(UsuarioLabel);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(SalirButton);
            Controls.Add(ConfirmarRendicionButton);
            Controls.Add(GuiasGroupBox);
            Controls.Add(BusquedaGroupBox);
            Name = "RecepcionYDespachoUltimaMillaForm";
            Text = "Recepcion y despacho ultima milla";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            GuiasGroupBox.ResumeLayout(false);
            GuiasGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            BusquedaGroupBox.ResumeLayout(false);
            BusquedaGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox2;
        private CheckBox checkBox3;
        private Label label3;
        private Label label2;
        private ListView listView1;
        private ColumnHeader NroGuia;
        private ColumnHeader destinoColumn;
        private ColumnHeader Cumplida;
        private GroupBox groupBox1;
        private Button button1;
        private Button GenerarNuevaHDRForm;
        private Label label1;
        private Button SalirButton;
        private Button ConfirmarRendicionButton;
        private GroupBox GuiasGroupBox;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn NroGuiaColumn;
        private DataGridViewTextBoxColumn DestinoCloumn;
        private DataGridViewCheckBoxColumn CumplidaColumn;
        private GroupBox BusquedaGroupBox;
        private Button BuscarButton;
        private TextBox NumHojaRutaTextBox;
        private Label DNILabel;
        private Label UsuarioLabel;
        private Label CDLabel;
    }
}