namespace TUTASAPrototipo.RecepcionYDespachoAgencia
{
    partial class RecepcionYDespachoAgenciaForm1
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
            CancelarButton = new Button();
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
            BusquedaAgenciaGroupBox.Location = new Point(64, 40);
            BusquedaAgenciaGroupBox.Margin = new Padding(3, 4, 3, 4);
            BusquedaAgenciaGroupBox.Name = "BusquedaAgenciaGroupBox";
            BusquedaAgenciaGroupBox.Padding = new Padding(3, 4, 3, 4);
            BusquedaAgenciaGroupBox.Size = new Size(754, 133);
            BusquedaAgenciaGroupBox.TabIndex = 1;
            BusquedaAgenciaGroupBox.TabStop = false;
            BusquedaAgenciaGroupBox.Text = "Búsqueda";
            // 
            // BuscarxDNIFleteroButton
            // 
            BuscarxDNIFleteroButton.Location = new Point(496, 59);
            BuscarxDNIFleteroButton.Margin = new Padding(3, 4, 3, 4);
            BuscarxDNIFleteroButton.Name = "BuscarxDNIFleteroButton";
            BuscarxDNIFleteroButton.Size = new Size(86, 31);
            BuscarxDNIFleteroButton.TabIndex = 2;
            BuscarxDNIFleteroButton.Text = "Buscar";
            BuscarxDNIFleteroButton.UseVisualStyleBackColor = true;
            BuscarxDNIFleteroButton.Click += BuscarxDNIFleteroButton_Click;
            // 
            // DNIFleteroTextBox
            // 
            DNIFleteroTextBox.Location = new Point(199, 59);
            DNIFleteroTextBox.Margin = new Padding(3, 4, 3, 4);
            DNIFleteroTextBox.Name = "DNIFleteroTextBox";
            DNIFleteroTextBox.Size = new Size(260, 27);
            DNIFleteroTextBox.TabIndex = 1;
            // 
            // DNILabel
            // 
            DNILabel.AutoSize = true;
            DNILabel.Location = new Point(24, 63);
            DNILabel.Name = "DNILabel";
            DNILabel.Size = new Size(186, 20);
            DNILabel.TabIndex = 0;
            DNILabel.Text = "Ingrese el número de DNI :";
            // 
            // GuiasARecepcionarGroupBox
            // 
            GuiasARecepcionarGroupBox.Controls.Add(GuiasARecepcionarAgenciaListView);
            GuiasARecepcionarGroupBox.Location = new Point(64, 181);
            GuiasARecepcionarGroupBox.Margin = new Padding(3, 4, 3, 4);
            GuiasARecepcionarGroupBox.Name = "GuiasARecepcionarGroupBox";
            GuiasARecepcionarGroupBox.Padding = new Padding(3, 4, 3, 4);
            GuiasARecepcionarGroupBox.Size = new Size(754, 187);
            GuiasARecepcionarGroupBox.TabIndex = 3;
            GuiasARecepcionarGroupBox.TabStop = false;
            GuiasARecepcionarGroupBox.Text = "Guías a recibir:";
            // 
            // GuiasARecepcionarAgenciaListView
            // 
            GuiasARecepcionarAgenciaListView.Columns.AddRange(new ColumnHeader[] { NroGuiaColumn, TamanioColumn });
            GuiasARecepcionarAgenciaListView.Location = new Point(199, 29);
            GuiasARecepcionarAgenciaListView.Margin = new Padding(3, 4, 3, 4);
            GuiasARecepcionarAgenciaListView.Name = "GuiasARecepcionarAgenciaListView";
            GuiasARecepcionarAgenciaListView.Size = new Size(348, 128);
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
            ConfirmarButton.Location = new Point(781, 647);
            ConfirmarButton.Margin = new Padding(3, 4, 3, 4);
            ConfirmarButton.Name = "ConfirmarButton";
            ConfirmarButton.Size = new Size(86, 31);
            ConfirmarButton.TabIndex = 4;
            ConfirmarButton.Text = "Confirmar";
            ConfirmarButton.UseVisualStyleBackColor = true;
            ConfirmarButton.Click += ConfirmarButton_Click;
            // 
            // CancelarButton
            // 
            CancelarButton.Location = new Point(688, 647);
            CancelarButton.Margin = new Padding(3, 4, 3, 4);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(86, 31);
            CancelarButton.TabIndex = 5;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            // 
            // GuiasAEntregarGroupBox
            // 
            GuiasAEntregarGroupBox.Controls.Add(GuiasAEntregarListView);
            GuiasAEntregarGroupBox.Location = new Point(64, 401);
            GuiasAEntregarGroupBox.Margin = new Padding(3, 4, 3, 4);
            GuiasAEntregarGroupBox.Name = "GuiasAEntregarGroupBox";
            GuiasAEntregarGroupBox.Padding = new Padding(3, 4, 3, 4);
            GuiasAEntregarGroupBox.Size = new Size(754, 187);
            GuiasAEntregarGroupBox.TabIndex = 6;
            GuiasAEntregarGroupBox.TabStop = false;
            GuiasAEntregarGroupBox.Text = "Guías a entregar al fletero:";
            // 
            // GuiasAEntregarListView
            // 
            GuiasAEntregarListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            GuiasAEntregarListView.Location = new Point(199, 29);
            GuiasAEntregarListView.Margin = new Padding(3, 4, 3, 4);
            GuiasAEntregarListView.Name = "GuiasAEntregarListView";
            GuiasAEntregarListView.Size = new Size(353, 128);
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
            AgenciaLabel.Location = new Point(560, 16);
            AgenciaLabel.Name = "AgenciaLabel";
            AgenciaLabel.Size = new Size(66, 20);
            AgenciaLabel.TabIndex = 25;
            AgenciaLabel.Text = "Agencia:";
            // 
            // UsuarioLabel
            // 
            UsuarioLabel.AutoSize = true;
            UsuarioLabel.Location = new Point(64, 12);
            UsuarioLabel.Name = "UsuarioLabel";
            UsuarioLabel.Size = new Size(62, 20);
            UsuarioLabel.TabIndex = 24;
            UsuarioLabel.Text = "Usuario:";
            UsuarioLabel.Click += UsuarioLabel_Click;
            // 
            // NombreUsuarioLabel
            // 
            NombreUsuarioLabel.AutoSize = true;
            NombreUsuarioLabel.Location = new Point(128, 12);
            NombreUsuarioLabel.Name = "NombreUsuarioLabel";
            NombreUsuarioLabel.Size = new Size(77, 20);
            NombreUsuarioLabel.TabIndex = 26;
            NombreUsuarioLabel.Text = "Juan Perez";
            // 
            // NombreAgenciaLabel
            // 
            NombreAgenciaLabel.AutoSize = true;
            NombreAgenciaLabel.Location = new Point(627, 16);
            NombreAgenciaLabel.Name = "NombreAgenciaLabel";
            NombreAgenciaLabel.Size = new Size(95, 20);
            NombreAgenciaLabel.TabIndex = 27;
            NombreAgenciaLabel.Text = "Lorem Ipsum";
            // 
            // RecepcionYDespachoAgenciaForm1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 693);
            Controls.Add(NombreAgenciaLabel);
            Controls.Add(NombreUsuarioLabel);
            Controls.Add(AgenciaLabel);
            Controls.Add(UsuarioLabel);
            Controls.Add(GuiasAEntregarGroupBox);
            Controls.Add(CancelarButton);
            Controls.Add(ConfirmarButton);
            Controls.Add(GuiasARecepcionarGroupBox);
            Controls.Add(BusquedaAgenciaGroupBox);
            Margin = new Padding(3, 4, 3, 4);
            Name = "RecepcionYDespachoAgenciaForm1";
            Text = "Recepcion y despacho en Agencia";
            Load += RecepcionYDespachoAgenciaForm1_Load;
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
        private Button CancelarButton;
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