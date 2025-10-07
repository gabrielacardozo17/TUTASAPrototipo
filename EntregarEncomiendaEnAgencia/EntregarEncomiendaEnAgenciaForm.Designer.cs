namespace TUTASAPrototipo.EntregarEncomiendaEnAgencia
{
    partial class EntregarEncomiendaEnAgenciaForm
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
            GuiasARecepcionarAgenciaListView = new ListView();
            NroGuiaColumn = new ColumnHeader();
            TamanioColumn = new ColumnHeader();
            BusquedaAgenciaGroupBox = new GroupBox();
            ApellidoDestinatarioResult = new Label();
            NombreDestinatarioResult = new Label();
            ApellidoDestinatario = new Label();
            NombreDestinatario = new Label();
            BuscarDestinararioButton = new Button();
            DNIDestinatarioTextBox = new TextBox();
            DNILabel = new Label();
            ConfirmarEntregaButton = new Button();
            CancelarButton = new Button();
            AgenciaLabel = new Label();
            UsuarioLabel = new Label();
            UsuarioResult = new Label();
            AgenciaResult = new Label();
            EntregaGuiasGroupBox.SuspendLayout();
            BusquedaAgenciaGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // EntregaGuiasGroupBox
            // 
            EntregaGuiasGroupBox.Controls.Add(GuiasARecepcionarAgenciaListView);
            EntregaGuiasGroupBox.Location = new Point(70, 222);
            EntregaGuiasGroupBox.Name = "EntregaGuiasGroupBox";
            EntregaGuiasGroupBox.Size = new Size(660, 140);
            EntregaGuiasGroupBox.TabIndex = 5;
            EntregaGuiasGroupBox.TabStop = false;
            EntregaGuiasGroupBox.Text = "Encomiendas en piso a entregar:";
            // 
            // GuiasARecepcionarAgenciaListView
            // 
            GuiasARecepcionarAgenciaListView.Columns.AddRange(new ColumnHeader[] { NroGuiaColumn, TamanioColumn });
            GuiasARecepcionarAgenciaListView.Location = new Point(69, 22);
            GuiasARecepcionarAgenciaListView.Name = "GuiasARecepcionarAgenciaListView";
            GuiasARecepcionarAgenciaListView.Size = new Size(506, 97);
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
            // BusquedaAgenciaGroupBox
            // 
            BusquedaAgenciaGroupBox.Controls.Add(ApellidoDestinatarioResult);
            BusquedaAgenciaGroupBox.Controls.Add(NombreDestinatarioResult);
            BusquedaAgenciaGroupBox.Controls.Add(ApellidoDestinatario);
            BusquedaAgenciaGroupBox.Controls.Add(NombreDestinatario);
            BusquedaAgenciaGroupBox.Controls.Add(BuscarDestinararioButton);
            BusquedaAgenciaGroupBox.Controls.Add(DNIDestinatarioTextBox);
            BusquedaAgenciaGroupBox.Controls.Add(DNILabel);
            BusquedaAgenciaGroupBox.Location = new Point(70, 65);
            BusquedaAgenciaGroupBox.Name = "BusquedaAgenciaGroupBox";
            BusquedaAgenciaGroupBox.Size = new Size(660, 151);
            BusquedaAgenciaGroupBox.TabIndex = 4;
            BusquedaAgenciaGroupBox.TabStop = false;
            BusquedaAgenciaGroupBox.Text = "Búsqueda del destinatario";
            // 
            // ApellidoDestinatarioResult
            // 
            ApellidoDestinatarioResult.AutoSize = true;
            ApellidoDestinatarioResult.Location = new Point(81, 111);
            ApellidoDestinatarioResult.Name = "ApellidoDestinatarioResult";
            ApellidoDestinatarioResult.Size = new Size(38, 15);
            ApellidoDestinatarioResult.TabIndex = 6;
            ApellidoDestinatarioResult.Text = "label1";
            // 
            // NombreDestinatarioResult
            // 
            NombreDestinatarioResult.AutoSize = true;
            NombreDestinatarioResult.Location = new Point(81, 84);
            NombreDestinatarioResult.Name = "NombreDestinatarioResult";
            NombreDestinatarioResult.Size = new Size(38, 15);
            NombreDestinatarioResult.TabIndex = 5;
            NombreDestinatarioResult.Text = "label1";
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
            BuscarDestinararioButton.Location = new Point(434, 44);
            BuscarDestinararioButton.Name = "BuscarDestinararioButton";
            BuscarDestinararioButton.Size = new Size(75, 23);
            BuscarDestinararioButton.TabIndex = 2;
            BuscarDestinararioButton.Text = "Buscar";
            BuscarDestinararioButton.UseVisualStyleBackColor = true;
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
            // ConfirmarEntregaButton
            // 
            ConfirmarEntregaButton.Location = new Point(655, 402);
            ConfirmarEntregaButton.Name = "ConfirmarEntregaButton";
            ConfirmarEntregaButton.Size = new Size(75, 30);
            ConfirmarEntregaButton.TabIndex = 6;
            ConfirmarEntregaButton.Text = "Confirmar";
            ConfirmarEntregaButton.UseVisualStyleBackColor = true;
            // 
            // CancelarButton
            // 
            CancelarButton.Location = new Point(570, 402);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 30);
            CancelarButton.TabIndex = 7;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            // 
            // AgenciaLabel
            // 
            AgenciaLabel.AutoSize = true;
            AgenciaLabel.Location = new Point(550, 22);
            AgenciaLabel.Name = "AgenciaLabel";
            AgenciaLabel.Size = new Size(53, 15);
            AgenciaLabel.TabIndex = 25;
            AgenciaLabel.Text = "Agencia:";
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
            // AgenciaResult
            // 
            AgenciaResult.AutoSize = true;
            AgenciaResult.Location = new Point(607, 22);
            AgenciaResult.Name = "AgenciaResult";
            AgenciaResult.Size = new Size(73, 15);
            AgenciaResult.TabIndex = 27;
            AgenciaResult.Text = "Loren Ipsum";
            // 
            // EntregarEncomiendaEnAgenciaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 445);
            Controls.Add(AgenciaResult);
            Controls.Add(UsuarioResult);
            Controls.Add(AgenciaLabel);
            Controls.Add(UsuarioLabel);
            Controls.Add(CancelarButton);
            Controls.Add(ConfirmarEntregaButton);
            Controls.Add(EntregaGuiasGroupBox);
            Controls.Add(BusquedaAgenciaGroupBox);
            Name = "EntregarEncomiendaEnAgenciaForm";
            Text = "Entrega de encomiendas en agencia";
            EntregaGuiasGroupBox.ResumeLayout(false);
            BusquedaAgenciaGroupBox.ResumeLayout(false);
            BusquedaAgenciaGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox EntregaGuiasGroupBox;
        private ListView GuiasARecepcionarAgenciaListView;
        private ColumnHeader NroGuiaColumn;
        private ColumnHeader TamanioColumn;
        private GroupBox BusquedaAgenciaGroupBox;
        private Label ApellidoDestinatario;
        private Label NombreDestinatario;
        private Button BuscarDestinararioButton;
        private TextBox DNIDestinatarioTextBox;
        private Label DNILabel;
        private Button ConfirmarEntregaButton;
        private Button CancelarButton;
        private Label ApellidoDestinatarioResult;
        private Label NombreDestinatarioResult;
        private Label AgenciaLabel;
        private Label UsuarioLabel;
        private Label UsuarioResult;
        private Label AgenciaResult;
    }
}