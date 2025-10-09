namespace TUTASAPrototipo.EntregarEncomiendaCD
{
    partial class EntregarEncomiendaCDForm
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
            EntregaGuiasGroupBox = new GroupBox();
            GuiasAEntregarCDListView = new ListView();
            NroGuiaColumn = new ColumnHeader();
            TamanioColumn = new ColumnHeader();
            BusquedaAgenciaGroupBox = new GroupBox();
            ApellidoResultLabel = new Label();
            NombreResultLabel = new Label();
            ApellidoDestinatario = new Label();
            NombreDestinatario = new Label();
            BuscarDestinararioButton = new Button();
            DNIDestinatarioTextBox = new TextBox();
            DNILabel = new Label();
            CancelarButton = new Button();
            ConfirmarEntregaButton = new Button();
            CDLabel = new Label();
            UsuarioLabel = new Label();
            UsuarioResult = new Label();
            CDResult = new Label();
            EntregaGuiasGroupBox.SuspendLayout();
            BusquedaAgenciaGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // EntregaGuiasGroupBox
            // 
            EntregaGuiasGroupBox.Controls.Add(GuiasAEntregarCDListView);
            EntregaGuiasGroupBox.Location = new Point(70, 231);
            EntregaGuiasGroupBox.Name = "EntregaGuiasGroupBox";
            EntregaGuiasGroupBox.Size = new Size(660, 140);
            EntregaGuiasGroupBox.TabIndex = 7;
            EntregaGuiasGroupBox.TabStop = false;
            EntregaGuiasGroupBox.Text = "Encomiendas en piso a entregar:";
            // 
            // GuiasAEntregarCDListView
            // 
            GuiasAEntregarCDListView.Columns.AddRange(new ColumnHeader[] { NroGuiaColumn, TamanioColumn });
            GuiasAEntregarCDListView.Location = new Point(69, 22);
            GuiasAEntregarCDListView.Name = "GuiasAEntregarCDListView";
            GuiasAEntregarCDListView.Size = new Size(506, 97);
            GuiasAEntregarCDListView.TabIndex = 7;
            GuiasAEntregarCDListView.UseCompatibleStateImageBehavior = false;
            GuiasAEntregarCDListView.View = View.Details;
            GuiasAEntregarCDListView.SelectedIndexChanged += EntregarEncomiendaCDForm_Load;
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
            // BusquedaAgenciaGroupBox
            // 
            BusquedaAgenciaGroupBox.Controls.Add(ApellidoResultLabel);
            BusquedaAgenciaGroupBox.Controls.Add(NombreResultLabel);
            BusquedaAgenciaGroupBox.Controls.Add(ApellidoDestinatario);
            BusquedaAgenciaGroupBox.Controls.Add(NombreDestinatario);
            BusquedaAgenciaGroupBox.Controls.Add(BuscarDestinararioButton);
            BusquedaAgenciaGroupBox.Controls.Add(DNIDestinatarioTextBox);
            BusquedaAgenciaGroupBox.Controls.Add(DNILabel);
            BusquedaAgenciaGroupBox.Location = new Point(70, 65);
            BusquedaAgenciaGroupBox.Name = "BusquedaAgenciaGroupBox";
            BusquedaAgenciaGroupBox.Size = new Size(660, 151);
            BusquedaAgenciaGroupBox.TabIndex = 6;
            BusquedaAgenciaGroupBox.TabStop = false;
            BusquedaAgenciaGroupBox.Text = "Búsqueda del destinatario";
            // 
            // ApellidoResultLabel
            // 
            ApellidoResultLabel.AutoSize = true;
            ApellidoResultLabel.Location = new Point(92, 111);
            ApellidoResultLabel.Name = "ApellidoResultLabel";
            ApellidoResultLabel.Size = new Size(35, 15);
            ApellidoResultLabel.TabIndex = 6;
            ApellidoResultLabel.Text = "Perez";
            // 
            // NombreResultLabel
            // 
            NombreResultLabel.AutoSize = true;
            NombreResultLabel.Location = new Point(92, 84);
            NombreResultLabel.Name = "NombreResultLabel";
            NombreResultLabel.Size = new Size(31, 15);
            NombreResultLabel.TabIndex = 5;
            NombreResultLabel.Text = "Juan";
            // 
            // ApellidoDestinatario
            // 
            ApellidoDestinatario.AutoSize = true;
            ApellidoDestinatario.Location = new Point(21, 111);
            ApellidoDestinatario.Name = "ApellidoDestinatario";
            ApellidoDestinatario.Size = new Size(54, 15);
            ApellidoDestinatario.TabIndex = 4;
            ApellidoDestinatario.Text = "Apellido:";
            // 
            // NombreDestinatario
            // 
            NombreDestinatario.AutoSize = true;
            NombreDestinatario.Location = new Point(21, 84);
            NombreDestinatario.Name = "NombreDestinatario";
            NombreDestinatario.Size = new Size(54, 15);
            NombreDestinatario.TabIndex = 3;
            NombreDestinatario.Text = "Nombre:";
            // 
            // BuscarDestinararioButton
            // 
            BuscarDestinararioButton.Location = new Point(425, 44);
            BuscarDestinararioButton.Name = "BuscarDestinararioButton";
            BuscarDestinararioButton.Size = new Size(75, 23);
            BuscarDestinararioButton.TabIndex = 2;
            BuscarDestinararioButton.Text = "Buscar";
            BuscarDestinararioButton.UseVisualStyleBackColor = true;
            BuscarDestinararioButton.Click += BuscarDestinararioButton_Click;
            // 
            // DNIDestinatarioTextBox
            // 
            DNIDestinatarioTextBox.Location = new Point(174, 44);
            DNIDestinatarioTextBox.Name = "DNIDestinatarioTextBox";
            DNIDestinatarioTextBox.Size = new Size(228, 23);
            DNIDestinatarioTextBox.TabIndex = 1;
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
            // CancelarButton
            // 
            CancelarButton.Location = new Point(570, 408);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 30);
            CancelarButton.TabIndex = 9;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // ConfirmarEntregaButton
            // 
            ConfirmarEntregaButton.Location = new Point(655, 408);
            ConfirmarEntregaButton.Name = "ConfirmarEntregaButton";
            ConfirmarEntregaButton.Size = new Size(75, 30);
            ConfirmarEntregaButton.TabIndex = 8;
            ConfirmarEntregaButton.Text = "Confirmar";
            ConfirmarEntregaButton.UseVisualStyleBackColor = true;
            ConfirmarEntregaButton.Click += ConfirmarEntregaButton_Click;
            // 
            // CDLabel
            // 
            CDLabel.AutoSize = true;
            CDLabel.Location = new Point(550, 22);
            CDLabel.Name = "CDLabel";
            CDLabel.Size = new Size(26, 15);
            CDLabel.TabIndex = 25;
            CDLabel.Text = "CD:";
            // 
            // UsuarioLabel
            // 
            UsuarioLabel.AutoSize = true;
            UsuarioLabel.Location = new Point(70, 22);
            UsuarioLabel.Name = "UsuarioLabel";
            UsuarioLabel.Size = new Size(50, 15);
            UsuarioLabel.TabIndex = 24;
            UsuarioLabel.Text = "Usuario:";
            // 
            // UsuarioResult
            // 
            UsuarioResult.AutoSize = true;
            UsuarioResult.Location = new Point(126, 22);
            UsuarioResult.Name = "UsuarioResult";
            UsuarioResult.Size = new Size(62, 15);
            UsuarioResult.TabIndex = 26;
            UsuarioResult.Text = "Juan Perez";
            // 
            // CDResult
            // 
            CDResult.AutoSize = true;
            CDResult.Location = new Point(582, 22);
            CDResult.Name = "CDResult";
            CDResult.Size = new Size(73, 15);
            CDResult.TabIndex = 27;
            CDResult.Text = "Loren Ipsum";
            // 
            // EntregarEncomiendaCDForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(775, 450);
            Controls.Add(CDResult);
            Controls.Add(UsuarioResult);
            Controls.Add(CDLabel);
            Controls.Add(UsuarioLabel);
            Controls.Add(CancelarButton);
            Controls.Add(ConfirmarEntregaButton);
            Controls.Add(EntregaGuiasGroupBox);
            Controls.Add(BusquedaAgenciaGroupBox);
            Name = "EntregarEncomiendaCDForm";
            Text = "Entrega de encomiendas en centro de distribución";
            Load += EntregarEncomiendaCDForm_Load;
            EntregaGuiasGroupBox.ResumeLayout(false);
            BusquedaAgenciaGroupBox.ResumeLayout(false);
            BusquedaAgenciaGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private GroupBox EntregaGuiasGroupBox;
        private ListView GuiasAEntregarCDListView;
        private ColumnHeader NroGuiaColumn;
        private ColumnHeader TamanioColumn;
        private GroupBox BusquedaAgenciaGroupBox;
        private Label ApellidoResultLabel;
        private Label NombreResultLabel;
        private Label ApellidoDestinatario;
        private Label NombreDestinatario;
        private Button BuscarDestinararioButton;
        private TextBox DNIDestinatarioTextBox;
        private Label DNILabel;
        private Button CancelarButton;
        private Button ConfirmarEntregaButton;
        private Label CDLabel;
        private Label UsuarioLabel;
        private Label UsuarioResult;
        private Label CDResult;
    }
}