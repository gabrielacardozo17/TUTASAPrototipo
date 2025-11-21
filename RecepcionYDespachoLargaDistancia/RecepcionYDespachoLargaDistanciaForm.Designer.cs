namespace TUTASAPrototipo.RecepcionYDespachoLargaDistancia
{
    partial class RecepcionYDespachoLargaDistanciaForm
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
            BuscarServicioButton = new Button();
            NumServicioTextBox = new TextBox();
            ServicioLabel = new Label();
            GuiasGroupBox = new GroupBox();
            GuiaxServicioRecibidaListView = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            GuiasADespacharxServicioListView = new ListView();
            NroGuiaColumn = new ColumnHeader();
            TamanioColumn = new ColumnHeader();
            DestinoColumn = new ColumnHeader();
            GuiasADespacharServicioListView = new GroupBox();
            ConfirmarRecepcionYDespachoButton = new Button();
            CancelarButton = new Button();
            CDLabel = new Label();
            UsuarioLabel = new Label();
            UsuarioResult = new Label();
            CDResult = new Label();
            BusquedaGroupBox.SuspendLayout();
            GuiasGroupBox.SuspendLayout();
            GuiasADespacharServicioListView.SuspendLayout();
            SuspendLayout();
            // 
            // BusquedaGroupBox
            // 
            BusquedaGroupBox.Controls.Add(BuscarServicioButton);
            BusquedaGroupBox.Controls.Add(NumServicioTextBox);
            BusquedaGroupBox.Controls.Add(ServicioLabel);
            BusquedaGroupBox.Location = new Point(54, 49);
            BusquedaGroupBox.Margin = new Padding(3, 4, 3, 4);
            BusquedaGroupBox.Name = "BusquedaGroupBox";
            BusquedaGroupBox.Padding = new Padding(3, 4, 3, 4);
            BusquedaGroupBox.Size = new Size(718, 133);
            BusquedaGroupBox.TabIndex = 1;
            BusquedaGroupBox.TabStop = false;
            BusquedaGroupBox.Text = "Búsqueda";
            BusquedaGroupBox.Enter += BusquedaGroupBox_Enter;
            // 
            // BuscarServicioButton
            // 
            BuscarServicioButton.Location = new Point(591, 59);
            BuscarServicioButton.Margin = new Padding(3, 4, 3, 4);
            BuscarServicioButton.Name = "BuscarServicioButton";
            BuscarServicioButton.Size = new Size(86, 31);
            BuscarServicioButton.TabIndex = 2;
            BuscarServicioButton.Text = "Buscar";
            BuscarServicioButton.UseVisualStyleBackColor = true;
            BuscarServicioButton.Click += BuscarServicioButton_Click;
            // 
            // NumServicioTextBox
            // 
            NumServicioTextBox.Location = new Point(325, 61);
            NumServicioTextBox.Margin = new Padding(3, 4, 3, 4);
            NumServicioTextBox.Name = "NumServicioTextBox";
            NumServicioTextBox.Size = new Size(260, 27);
            NumServicioTextBox.TabIndex = 1;
            NumServicioTextBox.TextChanged += NumServicioTextBox_TextChanged;
            // 
            // ServicioLabel
            // 
            ServicioLabel.AutoSize = true;
            ServicioLabel.Location = new Point(24, 63);
            ServicioLabel.Name = "ServicioLabel";
            ServicioLabel.Size = new Size(303, 20);
            ServicioLabel.TabIndex = 0;
            ServicioLabel.Text = "Ingrese el número de servicio del transporte:";
            // 
            // GuiasGroupBox
            // 
            GuiasGroupBox.Controls.Add(GuiaxServicioRecibidaListView);
            GuiasGroupBox.Location = new Point(56, 204);
            GuiasGroupBox.Margin = new Padding(3, 4, 3, 4);
            GuiasGroupBox.Name = "GuiasGroupBox";
            GuiasGroupBox.Padding = new Padding(3, 4, 3, 4);
            GuiasGroupBox.Size = new Size(716, 187);
            GuiasGroupBox.TabIndex = 2;
            GuiasGroupBox.TabStop = false;
            GuiasGroupBox.Text = "Guías a recibir de este servicio:";
            // 
            // GuiaxServicioRecibidaListView
            // 
            GuiaxServicioRecibidaListView.CheckBoxes = true;
            GuiaxServicioRecibidaListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            GuiaxServicioRecibidaListView.Location = new Point(129, 28);
            GuiaxServicioRecibidaListView.Margin = new Padding(3, 4, 3, 4);
            GuiaxServicioRecibidaListView.Name = "GuiaxServicioRecibidaListView";
            GuiaxServicioRecibidaListView.Size = new Size(465, 128);
            GuiaxServicioRecibidaListView.TabIndex = 8;
            GuiaxServicioRecibidaListView.UseCompatibleStateImageBehavior = false;
            GuiaxServicioRecibidaListView.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Nro de Guía";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Tamaño";
            columnHeader2.Width = 200;
            // 
            // GuiasADespacharxServicioListView
            // 
            GuiasADespacharxServicioListView.CheckBoxes = true;
            GuiasADespacharxServicioListView.Columns.AddRange(new ColumnHeader[] { NroGuiaColumn, TamanioColumn, DestinoColumn });
            GuiasADespacharxServicioListView.Location = new Point(63, 53);
            GuiasADespacharxServicioListView.Margin = new Padding(3, 4, 3, 4);
            GuiasADespacharxServicioListView.Name = "GuiasADespacharxServicioListView";
            GuiasADespacharxServicioListView.Size = new Size(586, 128);
            GuiasADespacharxServicioListView.TabIndex = 7;
            GuiasADespacharxServicioListView.UseCompatibleStateImageBehavior = false;
            GuiasADespacharxServicioListView.View = View.Details;
            // 
            // NroGuiaColumn
            // 
            NroGuiaColumn.Text = "Nro de Guía";
            NroGuiaColumn.Width = 200;
            // 
            // TamanioColumn
            // 
            TamanioColumn.Text = "Tamaño";
            TamanioColumn.Width = 100;
            // 
            // DestinoColumn
            // 
            DestinoColumn.Text = "Destino";
            DestinoColumn.Width = 200;
            // 
            // GuiasADespacharServicioListView
            // 
            GuiasADespacharServicioListView.Controls.Add(GuiasADespacharxServicioListView);
            GuiasADespacharServicioListView.Location = new Point(56, 424);
            GuiasADespacharServicioListView.Margin = new Padding(3, 4, 3, 4);
            GuiasADespacharServicioListView.Name = "GuiasADespacharServicioListView";
            GuiasADespacharServicioListView.Padding = new Padding(3, 4, 3, 4);
            GuiasADespacharServicioListView.Size = new Size(716, 239);
            GuiasADespacharServicioListView.TabIndex = 3;
            GuiasADespacharServicioListView.TabStop = false;
            GuiasADespacharServicioListView.Text = "Guías a despachar en este servicio";
            // 
            // ConfirmarRecepcionYDespachoButton
            // 
            ConfirmarRecepcionYDespachoButton.Location = new Point(680, 690);
            ConfirmarRecepcionYDespachoButton.Margin = new Padding(3, 4, 3, 4);
            ConfirmarRecepcionYDespachoButton.Name = "ConfirmarRecepcionYDespachoButton";
            ConfirmarRecepcionYDespachoButton.Size = new Size(92, 33);
            ConfirmarRecepcionYDespachoButton.TabIndex = 4;
            ConfirmarRecepcionYDespachoButton.Text = "Confirmar";
            ConfirmarRecepcionYDespachoButton.UseVisualStyleBackColor = true;
            ConfirmarRecepcionYDespachoButton.Click += ConfirmarRecepcionYDespachoButton_Click;
            // 
            // CancelarButton
            // 
            CancelarButton.Location = new Point(578, 690);
            CancelarButton.Margin = new Padding(3, 4, 3, 4);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(96, 33);
            CancelarButton.TabIndex = 5;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            CancelarButton.Click += SalirButton_Click;
            // 
            // CDLabel
            // 
            CDLabel.AutoSize = true;
            CDLabel.Location = new Point(578, 12);
            CDLabel.Name = "CDLabel";
            CDLabel.Size = new Size(32, 20);
            CDLabel.TabIndex = 16;
            CDLabel.Text = "CD:";
            // 
            // UsuarioLabel
            // 
            UsuarioLabel.AutoSize = true;
            UsuarioLabel.Location = new Point(63, 12);
            UsuarioLabel.Name = "UsuarioLabel";
            UsuarioLabel.Size = new Size(62, 20);
            UsuarioLabel.TabIndex = 15;
            UsuarioLabel.Text = "Usuario:";
            // 
            // UsuarioResult
            // 
            UsuarioResult.AutoSize = true;
            UsuarioResult.Location = new Point(127, 12);
            UsuarioResult.Name = "UsuarioResult";
            UsuarioResult.Size = new Size(77, 20);
            UsuarioResult.TabIndex = 17;
            UsuarioResult.Text = "Juan Perez";
            // 
            // CDResult
            // 
            CDResult.AutoSize = true;
            CDResult.Location = new Point(615, 12);
            CDResult.Name = "CDResult";
            CDResult.Size = new Size(90, 20);
            CDResult.TabIndex = 18;
            CDResult.Text = "Loren Ipsum";
            // 
            // RecepcionYDespachoLargaDistanciaForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(890, 728);
            Controls.Add(CDResult);
            Controls.Add(UsuarioResult);
            Controls.Add(CDLabel);
            Controls.Add(UsuarioLabel);
            Controls.Add(CancelarButton);
            Controls.Add(ConfirmarRecepcionYDespachoButton);
            Controls.Add(GuiasADespacharServicioListView);
            Controls.Add(GuiasGroupBox);
            Controls.Add(BusquedaGroupBox);
            Margin = new Padding(3, 4, 3, 4);
            Name = "RecepcionYDespachoLargaDistanciaForm";
            Text = "Recepcion y despacho de servicios de larga distancia";
            BusquedaGroupBox.ResumeLayout(false);
            BusquedaGroupBox.PerformLayout();
            GuiasGroupBox.ResumeLayout(false);
            GuiasADespacharServicioListView.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox BusquedaGroupBox;
        private TextBox NumServicioTextBox;
        private Label ServicioLabel;
        private GroupBox GuiasGroupBox;
        private ListView GuiasADespacharxServicioListView;
        private ColumnHeader NroGuiaColumn;
        private ColumnHeader TamanioColumn;
        private ColumnHeader DestinoColumn;
        private GroupBox GuiasADespacharServicioListView;
        private Button ConfirmarRecepcionYDespachoButton;
        private Button CancelarButton;
        private Label CDLabel;
        private Label UsuarioLabel;
        private ListView GuiaxServicioRecibidaListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Label UsuarioResult;
        private Label CDResult;
        private Button BuscarServicioButton;

        private void SalirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BusquedaGroupBox_Enter(object sender, EventArgs e)
        {
            // Event handler stub for designer. Logic is in main form file.
        }

        private void NumServicioTextBox_TextChanged(object sender, EventArgs e)
        {
            // Event handler stub for designer. Logic is in main form file.
        }
    }
}