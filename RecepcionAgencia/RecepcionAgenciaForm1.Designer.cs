namespace TUTASAPrototipo.RecepcionAgencia
{
    partial class RecepcionAgenciaForm1
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
            BusquedaAgenciaGroupBox = new GroupBox();
            BuscarxDNIFleteroButton = new Button();
            DNIFleteroTextBox = new TextBox();
            DNILabel = new Label();
            GuiasARecepcionarGroupBox = new GroupBox();
            GuiasARecepcionarAgenciaListView = new ListView();
            NroGuiaColumn = new ColumnHeader();
            TamanioColumn = new ColumnHeader();
            ConfirmarButton = new Button();
            SalirButton = new Button();
            GuiasAEntregarGroupBox = new GroupBox();
            GuiasAEntregarListView = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            AgenciaLabel = new Label();
            UsuarioLabel = new Label();
            NombreUsuarioLabel = new Label();
            NombreAgenciaLabel = new Label();
            BusquedaAgenciaGroupBox.SuspendLayout();
            GuiasARecepcionarGroupBox.SuspendLayout();
            GuiasAEntregarGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // BusquedaAgenciaGroupBox
            // 
            BusquedaAgenciaGroupBox.Controls.Add(BuscarxDNIFleteroButton);
            BusquedaAgenciaGroupBox.Controls.Add(DNIFleteroTextBox);
            BusquedaAgenciaGroupBox.Controls.Add(DNILabel);
            BusquedaAgenciaGroupBox.Location = new Point(56, 30);
            BusquedaAgenciaGroupBox.Name = "BusquedaAgenciaGroupBox";
            BusquedaAgenciaGroupBox.Size = new Size(660, 100);
            BusquedaAgenciaGroupBox.TabIndex = 1;
            BusquedaAgenciaGroupBox.TabStop = false;
            BusquedaAgenciaGroupBox.Text = "Búsqueda";
            // 
            // BuscarxDNIFleteroButton
            // 
            BuscarxDNIFleteroButton.Location = new Point(434, 44);
            BuscarxDNIFleteroButton.Name = "BuscarxDNIFleteroButton";
            BuscarxDNIFleteroButton.Size = new Size(75, 23);
            BuscarxDNIFleteroButton.TabIndex = 2;
            BuscarxDNIFleteroButton.Text = "Buscar";
            BuscarxDNIFleteroButton.UseVisualStyleBackColor = true;
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
            // GuiasARecepcionarGroupBox
            // 
            GuiasARecepcionarGroupBox.Controls.Add(GuiasARecepcionarAgenciaListView);
            GuiasARecepcionarGroupBox.Location = new Point(56, 136);
            GuiasARecepcionarGroupBox.Name = "GuiasARecepcionarGroupBox";
            GuiasARecepcionarGroupBox.Size = new Size(660, 140);
            GuiasARecepcionarGroupBox.TabIndex = 3;
            GuiasARecepcionarGroupBox.TabStop = false;
            GuiasARecepcionarGroupBox.Text = "Guías a recibir:";
            // 
            // GuiasARecepcionarAgenciaListView
            // 
            GuiasARecepcionarAgenciaListView.Columns.AddRange(new ColumnHeader[] { NroGuiaColumn, TamanioColumn });
            GuiasARecepcionarAgenciaListView.Location = new Point(174, 22);
            GuiasARecepcionarAgenciaListView.Name = "GuiasARecepcionarAgenciaListView";
            GuiasARecepcionarAgenciaListView.Size = new Size(305, 97);
            GuiasARecepcionarAgenciaListView.TabIndex = 7;
            GuiasARecepcionarAgenciaListView.UseCompatibleStateImageBehavior = false;
            GuiasARecepcionarAgenciaListView.View = View.Details;
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
            // ConfirmarButton
            // 
            ConfirmarButton.Location = new Point(683, 485);
            ConfirmarButton.Name = "ConfirmarButton";
            ConfirmarButton.Size = new Size(75, 23);
            ConfirmarButton.TabIndex = 4;
            ConfirmarButton.Text = "Confirmar";
            ConfirmarButton.UseVisualStyleBackColor = true;
            // 
            // SalirButton
            // 
            SalirButton.Location = new Point(602, 485);
            SalirButton.Name = "SalirButton";
            SalirButton.Size = new Size(75, 23);
            SalirButton.TabIndex = 5;
            SalirButton.Text = "Salir";
            SalirButton.UseVisualStyleBackColor = true;
            // 
            // GuiasAEntregarGroupBox
            // 
            GuiasAEntregarGroupBox.Controls.Add(GuiasAEntregarListView);
            GuiasAEntregarGroupBox.Location = new Point(56, 301);
            GuiasAEntregarGroupBox.Name = "GuiasAEntregarGroupBox";
            GuiasAEntregarGroupBox.Size = new Size(660, 140);
            GuiasAEntregarGroupBox.TabIndex = 6;
            GuiasAEntregarGroupBox.TabStop = false;
            GuiasAEntregarGroupBox.Text = "Guías a entregar al fletero:";
            // 
            // GuiasAEntregarListView
            // 
            GuiasAEntregarListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            GuiasAEntregarListView.Location = new Point(174, 22);
            GuiasAEntregarListView.Name = "GuiasAEntregarListView";
            GuiasAEntregarListView.Size = new Size(309, 97);
            GuiasAEntregarListView.TabIndex = 7;
            GuiasAEntregarListView.UseCompatibleStateImageBehavior = false;
            GuiasAEntregarListView.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Nro de Guía";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Tamaño";
            columnHeader2.Width = 100;
            // 
            // AgenciaLabel
            // 
            AgenciaLabel.AutoSize = true;
            AgenciaLabel.Location = new Point(490, 12);
            AgenciaLabel.Name = "AgenciaLabel";
            AgenciaLabel.Size = new Size(53, 15);
            AgenciaLabel.TabIndex = 25;
            AgenciaLabel.Text = "Agencia:";
            // 
            // UsuarioLabel
            // 
            UsuarioLabel.AutoSize = true;
            UsuarioLabel.Location = new Point(56, 9);
            UsuarioLabel.Name = "UsuarioLabel";
            UsuarioLabel.Size = new Size(50, 15);
            UsuarioLabel.TabIndex = 24;
            UsuarioLabel.Text = "Usuario:";
            UsuarioLabel.Click += UsuarioLabel_Click;
            // 
            // NombreUsuarioLabel
            // 
            NombreUsuarioLabel.AutoSize = true;
            NombreUsuarioLabel.Location = new Point(112, 9);
            NombreUsuarioLabel.Name = "NombreUsuarioLabel";
            NombreUsuarioLabel.Size = new Size(62, 15);
            NombreUsuarioLabel.TabIndex = 26;
            NombreUsuarioLabel.Text = "Juan Perez";
            // 
            // NombreAgenciaLabel
            // 
            NombreAgenciaLabel.AutoSize = true;
            NombreAgenciaLabel.Location = new Point(549, 12);
            NombreAgenciaLabel.Name = "NombreAgenciaLabel";
            NombreAgenciaLabel.Size = new Size(77, 15);
            NombreAgenciaLabel.TabIndex = 27;
            NombreAgenciaLabel.Text = "Lorem Ipsum";
            // 
            // RecepcionAgenciaForm1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 520);
            Controls.Add(NombreAgenciaLabel);
            Controls.Add(NombreUsuarioLabel);
            Controls.Add(AgenciaLabel);
            Controls.Add(UsuarioLabel);
            Controls.Add(GuiasAEntregarGroupBox);
            Controls.Add(SalirButton);
            Controls.Add(ConfirmarButton);
            Controls.Add(GuiasARecepcionarGroupBox);
            Controls.Add(BusquedaAgenciaGroupBox);
            Name = "RecepcionAgenciaForm1";
            Text = "Recepcion en Agencia";
            BusquedaAgenciaGroupBox.ResumeLayout(false);
            BusquedaAgenciaGroupBox.PerformLayout();
            GuiasARecepcionarGroupBox.ResumeLayout(false);
            GuiasAEntregarGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox BusquedaAgenciaGroupBox;
        private Button BuscarxDNIFleteroButton;
        private TextBox DNIFleteroTextBox;
        private Label DNILabel;
        private GroupBox GuiasARecepcionarGroupBox;
        private ListView GuiasARecepcionarAgenciaListView;
        private ColumnHeader NroGuiaColumn;
        private ColumnHeader TamanioColumn;
        private Button ConfirmarButton;
        private Button SalirButton;
        private GroupBox GuiasAEntregarGroupBox;
        private ListView GuiasAEntregarListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Label AgenciaLabel;
        private Label UsuarioLabel;
        private Label NombreUsuarioLabel;
        private Label NombreAgenciaLabel;
    }
}