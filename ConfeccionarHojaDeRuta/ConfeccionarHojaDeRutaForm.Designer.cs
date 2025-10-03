namespace TUTASAPrototipo.ConfeccionarHojaDeRuta

{
    partial class ConfeccionarHojaDeRutaForm
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
            ColumnHeader GuiaColumn;
            label1 = new Label();
            comboBox1 = new ComboBox();
            SeleccionTipoHDRCombobox = new GroupBox();
            groupBox1 = new GroupBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            checkBox1 = new CheckBox();
            dataGridView1 = new DataGridView();
            AgregarCheck = new DataGridViewCheckBoxColumn();
            NroGuiaColumn = new DataGridViewTextBoxColumn();
            DomicilioColumn = new DataGridViewTextBoxColumn();
            TamañoColumn = new DataGridViewTextBoxColumn();
            label2 = new Label();
            textBox1 = new TextBox();
            groupBox2 = new GroupBox();
            comboBox2 = new ComboBox();
            label7 = new Label();
            checkBox2 = new CheckBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            listView1 = new ListView();
            DomicilioVisitaHeader = new ColumnHeader();
            TipoEncomienda = new ColumnHeader();
            DestinoFinalColumn = new ColumnHeader();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            GuiaColumn = new ColumnHeader();
            SeleccionTipoHDRCombobox.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // GuiaColumn
            // 
            GuiaColumn.Tag = "";
            GuiaColumn.Text = "Nro de Guía";
            GuiaColumn.Width = 200;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 44);
            label1.Name = "label1";
            label1.Size = new Size(267, 15);
            label1.TabIndex = 0;
            label1.Text = "Indique el tipo de hoja de ruta que desea generar:";
            label1.Click += label1_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Retiro", "Distribución", "Transporte" });
            comboBox1.Location = new Point(341, 41);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(265, 23);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // SeleccionTipoHDRCombobox
            // 
            SeleccionTipoHDRCombobox.Controls.Add(label1);
            SeleccionTipoHDRCombobox.Controls.Add(comboBox1);
            SeleccionTipoHDRCombobox.Location = new Point(121, 65);
            SeleccionTipoHDRCombobox.Name = "SeleccionTipoHDRCombobox";
            SeleccionTipoHDRCombobox.Size = new Size(1028, 131);
            SeleccionTipoHDRCombobox.TabIndex = 2;
            SeleccionTipoHDRCombobox.TabStop = false;
            SeleccionTipoHDRCombobox.Text = "Selección";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(121, 223);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1028, 262);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Planificación";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(667, 78);
            label6.Name = "label6";
            label6.Size = new Size(13, 15);
            label6.TabIndex = 5;
            label6.Text = "L";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(440, 79);
            label5.Name = "label5";
            label5.Size = new Size(92, 15);
            label5.TabIndex = 4;
            label5.Text = "Lorem Ipsum 56";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(241, 78);
            label4.Name = "label4";
            label4.Size = new Size(76, 15);
            label4.TabIndex = 3;
            label4.Text = "LNS36987452";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(128, 79);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 2;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { AgregarCheck, NroGuiaColumn, DomicilioColumn, TamañoColumn });
            dataGridView1.Location = new Point(59, 47);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(745, 147);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // AgregarCheck
            // 
            AgregarCheck.HeaderText = "Añadir";
            AgregarCheck.Name = "AgregarCheck";
            AgregarCheck.ReadOnly = true;
            // 
            // NroGuiaColumn
            // 
            NroGuiaColumn.HeaderText = "Nro de Guía";
            NroGuiaColumn.Name = "NroGuiaColumn";
            NroGuiaColumn.ReadOnly = true;
            NroGuiaColumn.Width = 200;
            // 
            // DomicilioColumn
            // 
            DomicilioColumn.HeaderText = "Domicilio a visitar";
            DomicilioColumn.Name = "DomicilioColumn";
            DomicilioColumn.ReadOnly = true;
            DomicilioColumn.Width = 200;
            // 
            // TamañoColumn
            // 
            TamañoColumn.HeaderText = "Tamaño de encomienda";
            TamañoColumn.Name = "TamañoColumn";
            TamañoColumn.ReadOnly = true;
            TamañoColumn.Width = 200;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 29);
            label2.Name = "label2";
            label2.Size = new Size(394, 15);
            label2.TabIndex = 0;
            label2.Text = "Del siguiente cuadro, seleccione las guias que integrarán esta hoja de ruta";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(85, 71);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(719, 23);
            textBox1.TabIndex = 7;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox2);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(checkBox2);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(listView1);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(121, 505);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1028, 254);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Planificación";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Plusmar 21:00hs", "FlechaBus 23:00hs" });
            comboBox2.Location = new Point(326, 204);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(210, 23);
            comboBox2.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(19, 207);
            label7.Name = "label7";
            label7.Size = new Size(301, 15);
            label7.TabIndex = 8;
            label7.Text = "Indique en que servicio va a despachar las encomiendas";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(780, 90);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(15, 14);
            checkBox2.TabIndex = 7;
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = SystemColors.ButtonHighlight;
            label10.Location = new Point(635, 92);
            label10.Name = "label10";
            label10.Size = new Size(13, 15);
            label10.TabIndex = 6;
            label10.Text = "L";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = SystemColors.ButtonHighlight;
            label9.Location = new Point(318, 92);
            label9.Name = "label9";
            label9.Size = new Size(144, 15);
            label9.TabIndex = 5;
            label9.Text = "Lorem Ipsum 56, Cordoba";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = SystemColors.ButtonHighlight;
            label8.Location = new Point(81, 92);
            label8.Name = "label8";
            label8.Size = new Size(76, 15);
            label8.TabIndex = 4;
            label8.Text = "LNS36987452";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { GuiaColumn, DomicilioVisitaHeader, TipoEncomienda, DestinoFinalColumn });
            listView1.Location = new Point(45, 59);
            listView1.Name = "listView1";
            listView1.Size = new Size(844, 121);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // DomicilioVisitaHeader
            // 
            DomicilioVisitaHeader.Text = "Destino";
            DomicilioVisitaHeader.Width = 300;
            // 
            // TipoEncomienda
            // 
            TipoEncomienda.Text = "Tamaño de encomienda";
            TipoEncomienda.Width = 200;
            // 
            // DestinoFinalColumn
            // 
            DestinoFinalColumn.Text = "¿CD Final?";
            DestinoFinalColumn.Width = 100;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 30);
            label3.Name = "label3";
            label3.Size = new Size(388, 15);
            label3.TabIndex = 0;
            label3.Text = "Las siguientes guías fueron seleccionadas para integrar esta hoja de ruta:";
            // 
            // button1
            // 
            button1.Location = new Point(1155, 765);
            button1.Name = "button1";
            button1.Size = new Size(80, 29);
            button1.TabIndex = 5;
            button1.Text = "Confirmar";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(1069, 765);
            button2.Name = "button2";
            button2.Size = new Size(80, 29);
            button2.TabIndex = 6;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // ConfeccionarHojaDeRutaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1303, 806);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(SeleccionTipoHDRCombobox);
            Name = "ConfeccionarHojaDeRutaForm";
            Text = "Confección de Hojas de Ruta";
            Load += ConfeccionarHojaDeRuta_Load;
            SeleccionTipoHDRCombobox.ResumeLayout(false);
            SeleccionTipoHDRCombobox.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private GroupBox SeleccionTipoHDRCombobox;
        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private Label label2;
        private GroupBox groupBox2;
        private ListView listView1;
        private Label label3;
        private ColumnHeader DomicilioVisitaHeader;
        private ColumnHeader TipoEncomienda;
        private ColumnHeader DestinoFinalColumn;
        private Button button1;
        private Button button2;
        private CheckBox checkBox1;
        private Label label4;
        private TextBox textBox1;
        private Label label6;
        private Label label5;
        private Label label9;
        private Label label8;
        private Label label10;
        private DataGridViewCheckBoxColumn AgregarCheck;
        private DataGridViewTextBoxColumn NroGuiaColumn;
        private DataGridViewTextBoxColumn DomicilioColumn;
        private DataGridViewTextBoxColumn TamañoColumn;
        private CheckBox checkBox2;
        private ComboBox comboBox2;
        private Label label7;
    }
}