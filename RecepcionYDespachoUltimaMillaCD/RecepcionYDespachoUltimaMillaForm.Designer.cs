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
            ListViewItem listViewItem1 = new ListViewItem(new string[] { "", "LNS23546" }, -1);
            ListViewItem listViewItem2 = new ListViewItem(new string[] { "LNS54654", "XL", "Av. Lorem Ipsum 102" }, -1);
            ListViewItem listViewItem3 = new ListViewItem(new string[] { "LNS56987", "S", "Distribución", "Av. Lorem Ipsum 56" }, -1);
            ListViewItem listViewItem4 = new ListViewItem("356254");
            ListViewItem listViewItem5 = new ListViewItem("");
            ListViewItem listViewItem6 = new ListViewItem("564524165");
            ListViewItem listViewItem7 = new ListViewItem("45545461");
            ListViewItem listViewItem8 = new ListViewItem("");
            ListViewItem listViewItem9 = new ListViewItem(new string[] { "", "LNS23332" }, -1);
            ListViewItem listViewItem10 = new ListViewItem(new string[] { "LNS54654", "XL", "Av. Lorem Ipsum 102" }, -1);
            ListViewItem listViewItem11 = new ListViewItem(new string[] { "LNS56987", "S", "Distribución", "Av. Lorem Ipsum 56" }, -1);
            groupBox2 = new GroupBox();
            label3 = new Label();
            GuiasRetiroxFleteroListView = new ListView();
            cumplidaRetiroColumn = new ColumnHeader();
            NroGuia = new ColumnHeader();
            GuiasDistribucionProximas = new GroupBox();
            NuevasGuiasDistribucionxFleteroListView = new ListView();
            guiaColumn = new ColumnHeader();
            tamañoADespachar = new ColumnHeader();
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
            groupBox1 = new GroupBox();
            NuevasGuiasRetiroxFleteroListView = new ListView();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            label2 = new Label();
            groupBox2.SuspendLayout();
            GuiasDistribucionProximas.SuspendLayout();
            GuiasGroupBox.SuspendLayout();
            BusquedaGroupBox.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(GuiasRetiroxFleteroListView);
            groupBox2.Location = new Point(70, 302);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(658, 148);
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
            listViewItem1.StateImageIndex = 0;
            GuiasRetiroxFleteroListView.Items.AddRange(new ListViewItem[] { listViewItem1 });
            GuiasRetiroxFleteroListView.Location = new Point(101, 22);
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
            // GuiasDistribucionProximas
            // 
            GuiasDistribucionProximas.Controls.Add(NuevasGuiasDistribucionxFleteroListView);
            GuiasDistribucionProximas.Controls.Add(label1);
            GuiasDistribucionProximas.Location = new Point(73, 467);
            GuiasDistribucionProximas.Name = "GuiasDistribucionProximas";
            GuiasDistribucionProximas.Size = new Size(658, 161);
            GuiasDistribucionProximas.TabIndex = 11;
            GuiasDistribucionProximas.TabStop = false;
            GuiasDistribucionProximas.Text = "La nueva hoja de ruta de distribución asignada a este fletero contiene las siguientes guías:";
            // 
            // NuevasGuiasDistribucionxFleteroListView
            // 
            NuevasGuiasDistribucionxFleteroListView.Columns.AddRange(new ColumnHeader[] { guiaColumn, tamañoADespachar, DestinoDespachar });
            NuevasGuiasDistribucionxFleteroListView.Items.AddRange(new ListViewItem[] { listViewItem2, listViewItem3, listViewItem4, listViewItem5, listViewItem6, listViewItem7, listViewItem8 });
            NuevasGuiasDistribucionxFleteroListView.Location = new Point(55, 37);
            NuevasGuiasDistribucionxFleteroListView.Name = "NuevasGuiasDistribucionxFleteroListView";
            NuevasGuiasDistribucionxFleteroListView.Size = new Size(524, 97);
            NuevasGuiasDistribucionxFleteroListView.TabIndex = 1;
            NuevasGuiasDistribucionxFleteroListView.UseCompatibleStateImageBehavior = false;
            NuevasGuiasDistribucionxFleteroListView.View = View.Details;
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
            SalirButton.Location = new Point(572, 833);
            SalirButton.Name = "SalirButton";
            SalirButton.Size = new Size(75, 23);
            SalirButton.TabIndex = 10;
            SalirButton.Text = "Salir";
            SalirButton.UseVisualStyleBackColor = true;
            // 
            // ConfirmarButton
            // 
            ConfirmarButton.Location = new Point(653, 833);
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
            GuiasGroupBox.Location = new Point(70, 128);
            GuiasGroupBox.Name = "GuiasGroupBox";
            GuiasGroupBox.Size = new Size(658, 158);
            GuiasGroupBox.TabIndex = 8;
            GuiasGroupBox.TabStop = false;
            GuiasGroupBox.Text = "Detalle de guías de distribución asignadas:";
            // 
            // GuiasDistribucionxFleteroListView
            // 
            GuiasDistribucionxFleteroListView.CheckBoxes = true;
            GuiasDistribucionxFleteroListView.Columns.AddRange(new ColumnHeader[] { CumplidaDistribucionColumn, columnHeader1 });
            GuiasDistribucionxFleteroListView.FullRowSelect = true;
            listViewItem9.StateImageIndex = 0;
            GuiasDistribucionxFleteroListView.Items.AddRange(new ListViewItem[] { listViewItem9 });
            GuiasDistribucionxFleteroListView.Location = new Point(101, 32);
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
            BusquedaGroupBox.Size = new Size(660, 83);
            BusquedaGroupBox.TabIndex = 7;
            BusquedaGroupBox.TabStop = false;
            BusquedaGroupBox.Text = "Búsqueda";
            // 
            // BuscarButton
            // 
            BuscarButton.Location = new Point(421, 29);
            BuscarButton.Name = "BuscarButton";
            BuscarButton.Size = new Size(75, 23);
            BuscarButton.TabIndex = 2;
            BuscarButton.Text = "Buscar";
            BuscarButton.UseVisualStyleBackColor = true;
            // 
            // DNIFleteroTextBox
            // 
            DNIFleteroTextBox.Location = new Point(174, 30);
            DNIFleteroTextBox.Name = "DNIFleteroTextBox";
            DNIFleteroTextBox.Size = new Size(228, 23);
            DNIFleteroTextBox.TabIndex = 1;
            // 
            // DNILabel
            // 
            DNILabel.AutoSize = true;
            DNILabel.Location = new Point(21, 33);
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
            // groupBox1
            // 
            groupBox1.Controls.Add(NuevasGuiasRetiroxFleteroListView);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(67, 646);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(658, 161);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "La nueva hoja de ruta de retiro asignada a este fletero contiene las siguientes guías:";
            // 
            // NuevasGuiasRetiroxFleteroListView
            // 
            NuevasGuiasRetiroxFleteroListView.Columns.AddRange(new ColumnHeader[] { columnHeader2, columnHeader3, columnHeader4 });
            NuevasGuiasRetiroxFleteroListView.Items.AddRange(new ListViewItem[] { listViewItem10, listViewItem11 });
            NuevasGuiasRetiroxFleteroListView.Location = new Point(61, 28);
            NuevasGuiasRetiroxFleteroListView.Name = "NuevasGuiasRetiroxFleteroListView";
            NuevasGuiasRetiroxFleteroListView.Size = new Size(506, 97);
            NuevasGuiasRetiroxFleteroListView.TabIndex = 2;
            NuevasGuiasRetiroxFleteroListView.UseCompatibleStateImageBehavior = false;
            NuevasGuiasRetiroxFleteroListView.View = View.Details;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Nro de Guía";
            columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Tamaño";
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Destino";
            columnHeader4.Width = 200;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 28);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 0;
            // 
            // RecepcionYDespachoUltimaMillaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(779, 868);
            Controls.Add(groupBox1);
            Controls.Add(CDLabel);
            Controls.Add(UsuarioLabel);
            Controls.Add(groupBox2);
            Controls.Add(GuiasDistribucionProximas);
            Controls.Add(SalirButton);
            Controls.Add(ConfirmarButton);
            Controls.Add(GuiasGroupBox);
            Controls.Add(BusquedaGroupBox);
            Name = "RecepcionYDespachoUltimaMillaForm";
            Text = "Recepcion y despacho ultima milla";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            GuiasDistribucionProximas.ResumeLayout(false);
            GuiasDistribucionProximas.PerformLayout();
            GuiasGroupBox.ResumeLayout(false);
            BusquedaGroupBox.ResumeLayout(false);
            BusquedaGroupBox.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox2;
        private Label label3;
        private ListView GuiasRetiroxFleteroListView;
        private ColumnHeader NroGuia;
        private ColumnHeader destinoColumn;
        private GroupBox GuiasDistribucionProximas;
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
        private ListView NuevasGuiasDistribucionxFleteroListView;
        private ColumnHeader guiaColumn;
        private ColumnHeader tamañoADespachar;
        private ColumnHeader DestinoDespachar;
        private ListView GuiasDistribucionxFleteroListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader CumplidaDistribucionColumn;
        private ColumnHeader cumplidaRetiroColumn;
        private ColumnHeader columnHeader6;
        private GroupBox groupBox1;
        private Label label2;
        private ListView NuevasGuiasRetiroxFleteroListView;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
    }
}