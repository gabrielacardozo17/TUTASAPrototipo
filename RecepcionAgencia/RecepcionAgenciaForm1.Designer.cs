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
            BuscarFleteroButton = new Button();
            DNIFleteroTextBox = new TextBox();
            DNILabel = new Label();
            GuiasGroupBox = new GroupBox();
            GuiasARecepcionarAgenciaListView = new ListView();
            NroGuiaColumn = new ColumnHeader();
            TamanioColumn = new ColumnHeader();
            RecibidaColumn = new ColumnHeader();
            ConfirmarButton = new Button();
            SalirButton = new Button();
            groupBox1 = new GroupBox();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            BusquedaAgenciaGroupBox.SuspendLayout();
            GuiasGroupBox.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // BusquedaAgenciaGroupBox
            // 
            BusquedaAgenciaGroupBox.Controls.Add(BuscarFleteroButton);
            BusquedaAgenciaGroupBox.Controls.Add(DNIFleteroTextBox);
            BusquedaAgenciaGroupBox.Controls.Add(DNILabel);
            BusquedaAgenciaGroupBox.Location = new Point(56, 30);
            BusquedaAgenciaGroupBox.Name = "BusquedaAgenciaGroupBox";
            BusquedaAgenciaGroupBox.Size = new Size(660, 100);
            BusquedaAgenciaGroupBox.TabIndex = 1;
            BusquedaAgenciaGroupBox.TabStop = false;
            BusquedaAgenciaGroupBox.Text = "Búsqueda";
            // 
            // BuscarFleteroButton
            // 
            BuscarFleteroButton.Location = new Point(434, 44);
            BuscarFleteroButton.Name = "BuscarFleteroButton";
            BuscarFleteroButton.Size = new Size(75, 23);
            BuscarFleteroButton.TabIndex = 2;
            BuscarFleteroButton.Text = "Buscar";
            BuscarFleteroButton.UseVisualStyleBackColor = true;
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
            // GuiasGroupBox
            // 
            GuiasGroupBox.Controls.Add(GuiasARecepcionarAgenciaListView);
            GuiasGroupBox.Location = new Point(56, 136);
            GuiasGroupBox.Name = "GuiasGroupBox";
            GuiasGroupBox.Size = new Size(660, 140);
            GuiasGroupBox.TabIndex = 3;
            GuiasGroupBox.TabStop = false;
            GuiasGroupBox.Text = "Guías a recibir:";
            // 
            // GuiasARecepcionarAgenciaListView
            // 
            GuiasARecepcionarAgenciaListView.Columns.AddRange(new ColumnHeader[] { NroGuiaColumn, TamanioColumn, RecibidaColumn });
            GuiasARecepcionarAgenciaListView.Location = new Point(71, 22);
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
            // RecibidaColumn
            // 
            RecibidaColumn.Text = "¿Recibida?";
            RecibidaColumn.Width = 200;
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
            // groupBox1
            // 
            groupBox1.Controls.Add(listView1);
            groupBox1.Location = new Point(56, 301);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(660, 140);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Guías a entregar al fletero:";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listView1.Location = new Point(71, 22);
            listView1.Name = "listView1";
            listView1.Size = new Size(506, 97);
            listView1.TabIndex = 7;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
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
            // columnHeader3
            // 
            columnHeader3.Text = "¿Entregada?";
            columnHeader3.Width = 200;
            // 
            // RecepcionAgenciaForm1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 520);
            Controls.Add(groupBox1);
            Controls.Add(SalirButton);
            Controls.Add(ConfirmarButton);
            Controls.Add(GuiasGroupBox);
            Controls.Add(BusquedaAgenciaGroupBox);
            Name = "RecepcionAgenciaForm1";
            Text = "Recepcion en Agencia";
            BusquedaAgenciaGroupBox.ResumeLayout(false);
            BusquedaAgenciaGroupBox.PerformLayout();
            GuiasGroupBox.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox BusquedaAgenciaGroupBox;
        private Button BuscarFleteroButton;
        private TextBox DNIFleteroTextBox;
        private Label DNILabel;
        private GroupBox GuiasGroupBox;
        private ListView GuiasARecepcionarAgenciaListView;
        private ColumnHeader NroGuiaColumn;
        private ColumnHeader TamanioColumn;
        private ColumnHeader RecibidaColumn;
        private Button ConfirmarButton;
        private Button SalirButton;
        private GroupBox groupBox1;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
    }
}