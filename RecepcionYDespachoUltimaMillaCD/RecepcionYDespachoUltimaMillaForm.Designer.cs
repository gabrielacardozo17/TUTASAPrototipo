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
            ListViewItem listViewItem5 = new ListViewItem(new string[] { "", "LNS23546" }, -1);
            ListViewItem listViewItem6 = new ListViewItem(new string[] { "LNS54654", "XL", "Retiro", "Av. Lorem Ipsum 102" }, -1);
            ListViewItem listViewItem7 = new ListViewItem(new string[] { "LNS56987", "S", "Distribución", "Av. Lorem Ipsum 56" }, -1);
            ListViewItem listViewItem8 = new ListViewItem(new string[] { "", "LNS23332" }, -1);
            groupBox2 = new GroupBox();
            label3 = new Label();
            GuiasRetiroxFleteroListView = new ListView();
            cumplidaRetiroColumn = new ColumnHeader();
            NroGuia = new ColumnHeader();
            groupBox1 = new GroupBox();
            NuevasGuiasFleteroListView = new ListView();
            guiaColumn = new ColumnHeader();
            tamañoADespachar = new ColumnHeader();
            accionARealizar = new ColumnHeader();
            DestinoDespachar = new ColumnHeader();
            label1 = new Label();
            SalirButton = new Button();
            ConfirmarButton = new Button();
            GuiasGroupBox = new GroupBox();
            GuiasDistribucionxFleteroListView = new ListView();
            CumplidaDistribucionColumn = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            BusquedaGroupBox = new GroupBox();
            BuscarButton = new Button();
            DNIFleteroTextBox = new TextBox();
            DNILabel = new Label();
            UsuarioLabel = new Label();
            CDLabel = new Label();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            GuiasGroupBox.SuspendLayout();
            BusquedaGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(GuiasRetiroxFleteroListView);
            groupBox2.Location = new Point(69, 335);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(658, 160);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Detalle de guías de retiro asignadas:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(294, 59);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 5;
            // 
            // GuiasRetiroxFleteroListView
            // 
            GuiasRetiroxFleteroListView.CheckBoxes = true;
            GuiasRetiroxFleteroListView.Columns.AddRange(new ColumnHeader[] { cumplidaRetiroColumn, NroGuia });
            GuiasRetiroxFleteroListView.FullRowSelect = true;
            listViewItem5.StateImageIndex = 0;
            GuiasRetiroxFleteroListView.Items.AddRange(new ListViewItem[] { listViewItem5 });
            GuiasRetiroxFleteroListView.Location = new Point(112, 39);
            GuiasRetiroxFleteroListView.Name = "GuiasRetiroxFleteroListView";
            GuiasRetiroxFleteroListView.Size = new Size(404, 97);
            GuiasRetiroxFleteroListView.TabIndex = 0;
            GuiasRetiroxFleteroListView.UseCompatibleStateImageBehavior = false;
            GuiasRetiroxFleteroListView.View = View.Details;
            GuiasRetiroxFleteroListView.SelectedIndexChanged += GuiasRetiroxFleteroListView_SelectedIndexChanged;
            // 
            // cumplidaRetiroColumn
            // 
            cumplidaRetiroColumn.Text = "¿Cumplida?";
            cumplidaRetiroColumn.Width = 100;
            // 
            // NroGuia
            // 
            NroGuia.Text = "Nro de Guía";
            NroGuia.Width = 300;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(NuevasGuiasFleteroListView);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(69, 514);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(658, 161);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Guías a entregar a este fletero:";
            // 
            // NuevasGuiasFleteroListView
            // 
            NuevasGuiasFleteroListView.Columns.AddRange(new ColumnHeader[] { guiaColumn, tamañoADespachar, accionARealizar, DestinoDespachar });
            NuevasGuiasFleteroListView.Items.AddRange(new ListViewItem[] { listViewItem6, listViewItem7 });
            NuevasGuiasFleteroListView.Location = new Point(13, 39);
            NuevasGuiasFleteroListView.Name = "NuevasGuiasFleteroListView";
            NuevasGuiasFleteroListView.Size = new Size(604, 97);
            NuevasGuiasFleteroListView.TabIndex = 1;
            NuevasGuiasFleteroListView.UseCompatibleStateImageBehavior = false;
            NuevasGuiasFleteroListView.View = View.Details;
            // 
            // guiaColumn
            // 
            guiaColumn.Text = "Nro de Guía";
            guiaColumn.Width = 200;
            // 
            // tamañoADespachar
            // 
            tamañoADespachar.Text = "Tamaño";
            tamañoADespachar.Width = 100;
            // 
            // accionARealizar
            // 
            accionARealizar.Text = "Acción";
            accionARealizar.Width = 100;
            // 
            // DestinoDespachar
            // 
            DestinoDespachar.Text = "Destino";
            DestinoDespachar.Width = 200;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 28);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 0;
            // 
            // SalirButton
            // 
            SalirButton.Location = new Point(582, 691);
            SalirButton.Name = "SalirButton";
            SalirButton.Size = new Size(75, 23);
            SalirButton.TabIndex = 10;
            SalirButton.Text = "Salir";
            SalirButton.UseVisualStyleBackColor = true;
            // 
            // ConfirmarButton
            // 
            ConfirmarButton.Location = new Point(663, 691);
            ConfirmarButton.Name = "ConfirmarButton";
            ConfirmarButton.Size = new Size(75, 23);
            ConfirmarButton.TabIndex = 9;
            ConfirmarButton.Text = "Confirmar";
            ConfirmarButton.UseVisualStyleBackColor = true;
            ConfirmarButton.Click += ConfirmarButton_Click;
            // 
            // GuiasGroupBox
            // 
            GuiasGroupBox.Controls.Add(GuiasDistribucionxFleteroListView);
            GuiasGroupBox.Location = new Point(69, 145);
            GuiasGroupBox.Name = "GuiasGroupBox";
            GuiasGroupBox.Size = new Size(658, 171);
            GuiasGroupBox.TabIndex = 8;
            GuiasGroupBox.TabStop = false;
            GuiasGroupBox.Text = "Detalle de guías de distribución asignadas:";
            // 
            // GuiasDistribucionxFleteroListView
            // 
            GuiasDistribucionxFleteroListView.CheckBoxes = true;
            GuiasDistribucionxFleteroListView.Columns.AddRange(new ColumnHeader[] { CumplidaDistribucionColumn, columnHeader1 });
            GuiasDistribucionxFleteroListView.FullRowSelect = true;
            listViewItem8.StateImageIndex = 0;
            GuiasDistribucionxFleteroListView.Items.AddRange(new ListViewItem[] { listViewItem8 });
            GuiasDistribucionxFleteroListView.Location = new Point(112, 32);
            GuiasDistribucionxFleteroListView.Name = "GuiasDistribucionxFleteroListView";
            GuiasDistribucionxFleteroListView.Size = new Size(404, 97);
            GuiasDistribucionxFleteroListView.TabIndex = 1;
            GuiasDistribucionxFleteroListView.UseCompatibleStateImageBehavior = false;
            GuiasDistribucionxFleteroListView.View = View.Details;
            // 
            // CumplidaDistribucionColumn
            // 
            CumplidaDistribucionColumn.Text = "¿Cumplida?";
            CumplidaDistribucionColumn.Width = 100;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Nro de Guía";
            columnHeader1.Width = 300;
            // 
            // BusquedaGroupBox
            // 
            BusquedaGroupBox.Controls.Add(BuscarButton);
            BusquedaGroupBox.Controls.Add(DNIFleteroTextBox);
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
            // DNIFleteroTextBox
            // 
            DNIFleteroTextBox.Location = new Point(174, 44);
            DNIFleteroTextBox.Name = "DNIFleteroTextBox";
            DNIFleteroTextBox.Size = new Size(228, 23);
            DNIFleteroTextBox.TabIndex = 1;
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
            ClientSize = new Size(800, 725);
            Controls.Add(CDLabel);
            Controls.Add(UsuarioLabel);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(SalirButton);
            Controls.Add(ConfirmarButton);
            Controls.Add(GuiasGroupBox);
            Controls.Add(BusquedaGroupBox);
            Name = "RecepcionYDespachoUltimaMillaForm";
            Text = "Recepcion y despacho ultima milla";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            GuiasGroupBox.ResumeLayout(false);
            BusquedaGroupBox.ResumeLayout(false);
            BusquedaGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox2;
        private Label label3;
        private ListView GuiasRetiroxFleteroListView;
        private ColumnHeader NroGuia;
        private ColumnHeader destinoColumn;
        private GroupBox groupBox1;
        private Label label1;
        private Button SalirButton;
        private Button ConfirmarButton;
        private GroupBox GuiasGroupBox;
        private GroupBox BusquedaGroupBox;
        private Button BuscarButton;
        private TextBox DNIFleteroTextBox;
        private Label DNILabel;
        private Label UsuarioLabel;
        private Label CDLabel;
        private ListView NuevasGuiasFleteroListView;
        private ColumnHeader guiaColumn;
        private ColumnHeader tamañoADespachar;
        private ColumnHeader DestinoDespachar;
        private ListView GuiasDistribucionxFleteroListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader accionARealizar;
        private ColumnHeader CumplidaDistribucionColumn;
        private ColumnHeader cumplidaRetiroColumn;
        private ListView listView1;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
    }
}