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
            BusquedaGroupBox.Location = new Point(47, 37);
            BusquedaGroupBox.Name = "BusquedaGroupBox";
            BusquedaGroupBox.Size = new Size(609, 100);
            BusquedaGroupBox.TabIndex = 1;
            BusquedaGroupBox.TabStop = false;
            BusquedaGroupBox.Text = "Búsqueda";
            // 
            // BuscarServicioButton
            // 
            BuscarServicioButton.Location = new Point(508, 44);
            BuscarServicioButton.Name = "BuscarServicioButton";
            BuscarServicioButton.Size = new Size(75, 23);
            BuscarServicioButton.TabIndex = 2;
            BuscarServicioButton.Text = "Buscar";
            BuscarServicioButton.UseVisualStyleBackColor = true;
            // 
            // NumServicioTextBox
            // 
            NumServicioTextBox.Location = new Point(265, 44);
            NumServicioTextBox.Name = "NumServicioTextBox";
            NumServicioTextBox.Size = new Size(228, 23);
            NumServicioTextBox.TabIndex = 1;
            // 
            // ServicioLabel
            // 
            ServicioLabel.AutoSize = true;
            ServicioLabel.Location = new Point(21, 47);
            ServicioLabel.Name = "ServicioLabel";
            ServicioLabel.Size = new Size(240, 15);
            ServicioLabel.TabIndex = 0;
            ServicioLabel.Text = "Ingrese el número de servicio del transporte:";
            // 
            // GuiasGroupBox
            // 
            GuiasGroupBox.Controls.Add(GuiaxServicioRecibidaListView);
            GuiasGroupBox.Location = new Point(49, 153);
            GuiasGroupBox.Name = "GuiasGroupBox";
            GuiasGroupBox.Size = new Size(607, 140);
            GuiasGroupBox.TabIndex = 2;
            GuiasGroupBox.TabStop = false;
            GuiasGroupBox.Text = "Guías a recibir de este servicio:";
            // 
            // GuiaxServicioRecibidaListView
            // 
            GuiaxServicioRecibidaListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            GuiaxServicioRecibidaListView.Location = new Point(96, 22);
            GuiaxServicioRecibidaListView.Name = "GuiaxServicioRecibidaListView";
            GuiaxServicioRecibidaListView.Size = new Size(407, 97);
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
            GuiasADespacharxServicioListView.Columns.AddRange(new ColumnHeader[] { NroGuiaColumn, TamanioColumn, DestinoColumn });
            GuiasADespacharxServicioListView.Location = new Point(42, 39);
            GuiasADespacharxServicioListView.Name = "GuiasADespacharxServicioListView";
            GuiasADespacharxServicioListView.Size = new Size(513, 97);
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
            GuiasADespacharServicioListView.Location = new Point(49, 318);
            GuiasADespacharServicioListView.Name = "GuiasADespacharServicioListView";
            GuiasADespacharServicioListView.Size = new Size(607, 179);
            GuiasADespacharServicioListView.TabIndex = 3;
            GuiasADespacharServicioListView.TabStop = false;
            GuiasADespacharServicioListView.Text = "Guías a despachar en este servicio";
            // 
            // ConfirmarRecepcionYDespachoButton
            // 
            ConfirmarRecepcionYDespachoButton.Location = new Point(608, 534);
            ConfirmarRecepcionYDespachoButton.Name = "ConfirmarRecepcionYDespachoButton";
            ConfirmarRecepcionYDespachoButton.Size = new Size(83, 26);
            ConfirmarRecepcionYDespachoButton.TabIndex = 4;
            ConfirmarRecepcionYDespachoButton.Text = "Confirmar";
            ConfirmarRecepcionYDespachoButton.UseVisualStyleBackColor = true;
            // 
            // CancelarButton
            // 
            CancelarButton.Location = new Point(518, 534);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(84, 25);
            CancelarButton.TabIndex = 5;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            // 
            // CDLabel
            // 
            CDLabel.AutoSize = true;
            CDLabel.Location = new Point(506, 9);
            CDLabel.Name = "CDLabel";
            CDLabel.Size = new Size(26, 15);
            CDLabel.TabIndex = 16;
            CDLabel.Text = "CD:";
            // 
            // UsuarioLabel
            // 
            UsuarioLabel.AutoSize = true;
            UsuarioLabel.Location = new Point(55, 9);
            UsuarioLabel.Name = "UsuarioLabel";
            UsuarioLabel.Size = new Size(50, 15);
            UsuarioLabel.TabIndex = 15;
            UsuarioLabel.Text = "Usuario:";
            // 
            // UsuarioResult
            // 
            UsuarioResult.AutoSize = true;
            UsuarioResult.Location = new Point(111, 9);
            UsuarioResult.Name = "UsuarioResult";
            UsuarioResult.Size = new Size(62, 15);
            UsuarioResult.TabIndex = 17;
            UsuarioResult.Text = "Juan Perez";
            // 
            // CDResult
            // 
            CDResult.AutoSize = true;
            CDResult.Location = new Point(538, 9);
            CDResult.Name = "CDResult";
            CDResult.Size = new Size(73, 15);
            CDResult.TabIndex = 18;
            CDResult.Text = "Loren Ipsum";
            // 
            // RecepcionYDespachoLargaDistanciaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(740, 578);
            Controls.Add(CDResult);
            Controls.Add(UsuarioResult);
            Controls.Add(CDLabel);
            Controls.Add(UsuarioLabel);
            Controls.Add(CancelarButton);
            Controls.Add(ConfirmarRecepcionYDespachoButton);
            Controls.Add(GuiasADespacharServicioListView);
            Controls.Add(GuiasGroupBox);
            Controls.Add(BusquedaGroupBox);
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
        private Button BuscarServicioButton;
        private TextBox NumServicioTextBox;
        private Label ServicioLabel;
        private GroupBox GuiasGroupBox;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
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
    }
}