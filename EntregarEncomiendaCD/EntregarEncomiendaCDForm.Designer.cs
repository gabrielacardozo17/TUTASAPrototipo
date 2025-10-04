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
            ApellidoDestinatario = new Label();
            NombreDestinatario = new Label();
            BuscarDestinararioButton = new Button();
            DNIDestinatarioTextBox = new TextBox();
            DNILabel = new Label();
            label1 = new Label();
            label2 = new Label();
            SalirButton = new Button();
            ConfirmarEntregaButton = new Button();
            EntregaGuiasGroupBox.SuspendLayout();
            BusquedaAgenciaGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // EntregaGuiasGroupBox
            // 
            EntregaGuiasGroupBox.Controls.Add(GuiasAEntregarCDListView);
            EntregaGuiasGroupBox.Location = new Point(70, 204);
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
            BusquedaAgenciaGroupBox.Controls.Add(label2);
            BusquedaAgenciaGroupBox.Controls.Add(label1);
            BusquedaAgenciaGroupBox.Controls.Add(ApellidoDestinatario);
            BusquedaAgenciaGroupBox.Controls.Add(NombreDestinatario);
            BusquedaAgenciaGroupBox.Controls.Add(BuscarDestinararioButton);
            BusquedaAgenciaGroupBox.Controls.Add(DNIDestinatarioTextBox);
            BusquedaAgenciaGroupBox.Controls.Add(DNILabel);
            BusquedaAgenciaGroupBox.Location = new Point(70, 32);
            BusquedaAgenciaGroupBox.Name = "BusquedaAgenciaGroupBox";
            BusquedaAgenciaGroupBox.Size = new Size(660, 151);
            BusquedaAgenciaGroupBox.TabIndex = 6;
            BusquedaAgenciaGroupBox.TabStop = false;
            BusquedaAgenciaGroupBox.Text = "Búsqueda del destinatario";
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(92, 84);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 5;
            label1.Text = "Juan";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(92, 111);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 6;
            label2.Text = "Perez";
            // 
            // SalirButton
            // 
            SalirButton.Location = new Point(570, 408);
            SalirButton.Name = "SalirButton";
            SalirButton.Size = new Size(75, 30);
            SalirButton.TabIndex = 9;
            SalirButton.Text = "Salir";
            SalirButton.UseVisualStyleBackColor = true;
            // 
            // ConfirmarEntregaButton
            // 
            ConfirmarEntregaButton.Location = new Point(655, 408);
            ConfirmarEntregaButton.Name = "ConfirmarEntregaButton";
            ConfirmarEntregaButton.Size = new Size(75, 30);
            ConfirmarEntregaButton.TabIndex = 8;
            ConfirmarEntregaButton.Text = "Confirmar";
            ConfirmarEntregaButton.UseVisualStyleBackColor = true;
            // 
            // EntregarEncomiendaCDForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(775, 450);
            Controls.Add(SalirButton);
            Controls.Add(ConfirmarEntregaButton);
            Controls.Add(EntregaGuiasGroupBox);
            Controls.Add(BusquedaAgenciaGroupBox);
            Name = "EntregarEncomiendaCDForm";
            Text = "Entrega de encomiendas en centro de distribución";
            EntregaGuiasGroupBox.ResumeLayout(false);
            BusquedaAgenciaGroupBox.ResumeLayout(false);
            BusquedaAgenciaGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox EntregaGuiasGroupBox;
        private ListView GuiasAEntregarCDListView;
        private ColumnHeader NroGuiaColumn;
        private ColumnHeader TamanioColumn;
        private GroupBox BusquedaAgenciaGroupBox;
        private Label label2;
        private Label label1;
        private Label ApellidoDestinatario;
        private Label NombreDestinatario;
        private Button BuscarDestinararioButton;
        private TextBox DNIDestinatarioTextBox;
        private Label DNILabel;
        private Button SalirButton;
        private Button ConfirmarEntregaButton;
    }
}