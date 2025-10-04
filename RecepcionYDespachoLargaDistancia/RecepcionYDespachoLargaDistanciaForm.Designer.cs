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
            GuiasRecibidasServicioListView = new ListView();
            NroGuiaColumn = new ColumnHeader();
            TamanioColumn = new ColumnHeader();
            DestinoColumn = new ColumnHeader();
            GuiasADespacharServicioListView = new GroupBox();
            ConfirmarRecepcionYDespachoButton = new Button();
            SalirButton = new Button();
            CDLabel = new Label();
            UsuarioLabel = new Label();
            BusquedaGroupBox.SuspendLayout();
            GuiasGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // BusquedaGroupBox
            // 
            BusquedaGroupBox.Controls.Add(BuscarServicioButton);
            BusquedaGroupBox.Controls.Add(NumServicioTextBox);
            BusquedaGroupBox.Controls.Add(ServicioLabel);
            BusquedaGroupBox.Location = new Point(47, 37);
            BusquedaGroupBox.Name = "BusquedaGroupBox";
            BusquedaGroupBox.Size = new Size(660, 100);
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
            GuiasGroupBox.Controls.Add(GuiasRecibidasServicioListView);
            GuiasGroupBox.Location = new Point(49, 153);
            GuiasGroupBox.Name = "GuiasGroupBox";
            GuiasGroupBox.Size = new Size(658, 140);
            GuiasGroupBox.TabIndex = 2;
            GuiasGroupBox.TabStop = false;
            GuiasGroupBox.Text = "Guías a recibir de este servicio:";
            // 
            // GuiasRecibidasServicioListView
            // 
            GuiasRecibidasServicioListView.Columns.AddRange(new ColumnHeader[] { NroGuiaColumn, TamanioColumn, DestinoColumn });
            GuiasRecibidasServicioListView.Location = new Point(59, 22);
            GuiasRecibidasServicioListView.Name = "GuiasRecibidasServicioListView";
            GuiasRecibidasServicioListView.Size = new Size(513, 97);
            GuiasRecibidasServicioListView.TabIndex = 7;
            GuiasRecibidasServicioListView.UseCompatibleStateImageBehavior = false;
            GuiasRecibidasServicioListView.View = View.Details;
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
            GuiasADespacharServicioListView.Location = new Point(49, 318);
            GuiasADespacharServicioListView.Name = "GuiasADespacharServicioListView";
            GuiasADespacharServicioListView.Size = new Size(658, 227);
            GuiasADespacharServicioListView.TabIndex = 3;
            GuiasADespacharServicioListView.TabStop = false;
            GuiasADespacharServicioListView.Text = "Crear nueva hoja de ruta:";
            // 
            // ConfirmarRecepcionYDespachoButton
            // 
            ConfirmarRecepcionYDespachoButton.Location = new Point(662, 563);
            ConfirmarRecepcionYDespachoButton.Name = "ConfirmarRecepcionYDespachoButton";
            ConfirmarRecepcionYDespachoButton.Size = new Size(83, 26);
            ConfirmarRecepcionYDespachoButton.TabIndex = 4;
            ConfirmarRecepcionYDespachoButton.Text = "Confirmar";
            ConfirmarRecepcionYDespachoButton.UseVisualStyleBackColor = true;
            // 
            // SalirButton
            // 
            SalirButton.Location = new Point(572, 564);
            SalirButton.Name = "SalirButton";
            SalirButton.Size = new Size(84, 25);
            SalirButton.TabIndex = 5;
            SalirButton.Text = "Salir";
            SalirButton.UseVisualStyleBackColor = true;
            // 
            // CDLabel
            // 
            CDLabel.AutoSize = true;
            CDLabel.Location = new Point(537, 9);
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
            // RecepcionYDespachoLargaDistanciaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(776, 601);
            Controls.Add(CDLabel);
            Controls.Add(UsuarioLabel);
            Controls.Add(SalirButton);
            Controls.Add(ConfirmarRecepcionYDespachoButton);
            Controls.Add(GuiasADespacharServicioListView);
            Controls.Add(GuiasGroupBox);
            Controls.Add(BusquedaGroupBox);
            Name = "RecepcionYDespachoLargaDistanciaForm";
            Text = "Recepcion y despacho de servicios de larga distancia";
            BusquedaGroupBox.ResumeLayout(false);
            BusquedaGroupBox.PerformLayout();
            GuiasGroupBox.ResumeLayout(false);
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
        private ListView GuiasRecibidasServicioListView;
        private ColumnHeader NroGuiaColumn;
        private ColumnHeader TamanioColumn;
        private ColumnHeader DestinoColumn;
        private GroupBox GuiasADespacharServicioListView;
        private Button ConfirmarRecepcionYDespachoButton;
        private Button SalirButton;
        private Label CDLabel;
        private Label UsuarioLabel;
    }
}