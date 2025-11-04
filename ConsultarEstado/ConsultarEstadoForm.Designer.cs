namespace TUTASAPrototipo.ConsultarEstado
{
    partial class ConsultarEstadoForm
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
            label1 = new Label();
            groupBox1 = new GroupBox();
            BuscarEstadoGuiaButton = new Button();
            NumGuiaLabel = new Label();
            NroGuiaLabel = new Label();
            NroGuiaBusquedaGroupBox = new TextBox();
            ResultadoGroupBox = new GroupBox();
            label6 = new Label();
            label3 = new Label();
            HistorialGuiaListView = new ListView();
            FechaColumn = new ColumnHeader();
            EstadoColumn = new ColumnHeader();
            UbicacionColumn = new ColumnHeader();
            CancelarButton = new Button();
            groupBox1.SuspendLayout();
            ResultadoGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(302, 67);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BuscarEstadoGuiaButton);
            groupBox1.Controls.Add(NumGuiaLabel);
            groupBox1.Controls.Add(NroGuiaLabel);
            groupBox1.Controls.Add(NroGuiaBusquedaGroupBox);
            groupBox1.Location = new Point(58, 51);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(717, 167);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Búsqueda de encomienda";
            // 
            // BuscarEstadoGuiaButton
            // 
            BuscarEstadoGuiaButton.Location = new Point(421, 98);
            BuscarEstadoGuiaButton.Margin = new Padding(3, 4, 3, 4);
            BuscarEstadoGuiaButton.Name = "BuscarEstadoGuiaButton";
            BuscarEstadoGuiaButton.Size = new Size(86, 31);
            BuscarEstadoGuiaButton.TabIndex = 6;
            BuscarEstadoGuiaButton.Text = "Buscar";
            BuscarEstadoGuiaButton.UseVisualStyleBackColor = true;
            // 
            // NumGuiaLabel
            // 
            NumGuiaLabel.AutoSize = true;
            NumGuiaLabel.Location = new Point(9, 101);
            NumGuiaLabel.Name = "NumGuiaLabel";
            NumGuiaLabel.Size = new Size(120, 20);
            NumGuiaLabel.TabIndex = 5;
            NumGuiaLabel.Text = "Número de guía:";
            // 
            // NroGuiaLabel
            // 
            NroGuiaLabel.AutoSize = true;
            NroGuiaLabel.Location = new Point(9, 55);
            NroGuiaLabel.Name = "NroGuiaLabel";
            NroGuiaLabel.Size = new Size(441, 20);
            NroGuiaLabel.TabIndex = 4;
            NroGuiaLabel.Text = "Ingrese el número de guía de la encomienda que desea consultar";
            // 
            // NroGuiaBusquedaGroupBox
            // 
            NroGuiaBusquedaGroupBox.Location = new Point(135, 98);
            NroGuiaBusquedaGroupBox.Margin = new Padding(3, 4, 3, 4);
            NroGuiaBusquedaGroupBox.Name = "NroGuiaBusquedaGroupBox";
            NroGuiaBusquedaGroupBox.Size = new Size(266, 27);
            NroGuiaBusquedaGroupBox.TabIndex = 3;
            // 
            // ResultadoGroupBox
            // 
            ResultadoGroupBox.Controls.Add(label6);
            ResultadoGroupBox.Controls.Add(label3);
            ResultadoGroupBox.Controls.Add(HistorialGuiaListView);
            ResultadoGroupBox.Location = new Point(58, 250);
            ResultadoGroupBox.Margin = new Padding(3, 4, 3, 4);
            ResultadoGroupBox.Name = "ResultadoGroupBox";
            ResultadoGroupBox.Padding = new Padding(3, 4, 3, 4);
            ResultadoGroupBox.Size = new Size(717, 227);
            ResultadoGroupBox.TabIndex = 2;
            ResultadoGroupBox.TabStop = false;
            ResultadoGroupBox.Text = "Resultado de la búsqueda";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(281, 80);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(33, 80);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 3;
            // 
            // HistorialGuiaListView
            // 
            HistorialGuiaListView.Columns.AddRange(new ColumnHeader[] { FechaColumn, EstadoColumn, UbicacionColumn });
            HistorialGuiaListView.Location = new Point(22, 49);
            HistorialGuiaListView.Margin = new Padding(3, 4, 3, 4);
            HistorialGuiaListView.Name = "HistorialGuiaListView";
            HistorialGuiaListView.Size = new Size(670, 128);
            HistorialGuiaListView.TabIndex = 0;
            HistorialGuiaListView.UseCompatibleStateImageBehavior = false;
            HistorialGuiaListView.View = View.Details;
            // 
            // FechaColumn
            // 
            FechaColumn.Text = "Fecha";
            FechaColumn.Width = 130;
            // 
            // EstadoColumn
            // 
            EstadoColumn.Text = "Estado";
            EstadoColumn.Width = 280;
            // 
            // UbicacionColumn
            // 
            UbicacionColumn.Text = "Ubicación";
            UbicacionColumn.Width = 200;
            // 
            // CancelarButton
            // 
            CancelarButton.Location = new Point(689, 501);
            CancelarButton.Margin = new Padding(3, 4, 3, 4);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(86, 37);
            CancelarButton.TabIndex = 3;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            // 
            // ConsultarEstadoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(822, 561);
            Controls.Add(CancelarButton);
            Controls.Add(ResultadoGroupBox);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ConsultarEstadoForm";
            Text = "Consulta de Encomiendas";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResultadoGroupBox.ResumeLayout(false);
            ResultadoGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private TextBox NroGuiaBusquedaGroupBox;
        private GroupBox ResultadoGroupBox;
        private ListView HistorialGuiaListView;
        private ColumnHeader FechaColumn;
        private ColumnHeader EstadoColumn;
        private Button CancelarButton;
        private Label NroGuiaLabel;
        private Label label3;
        private Button BuscarEstadoGuiaButton;
        private Label NumGuiaLabel;
        private ColumnHeader UbicacionColumn;
        private Label label6;
    }
}