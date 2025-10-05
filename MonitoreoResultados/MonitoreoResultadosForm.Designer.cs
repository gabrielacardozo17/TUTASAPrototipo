namespace TUTASAPrototipo.MonitoreoResultados
{
    partial class MonitoreoResultadosForm
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
            ResultadoGroupBox = new GroupBox();
            ResultadosxEmpresaListView = new ListView();
            CostoMensualColumn = new ColumnHeader();
            VentasMensualesColumn = new ColumnHeader();
            ResultadoColumn = new ColumnHeader();
            SalirButton = new Button();
            empresaTransporteColumn = new ColumnHeader();
            PeriodoLabel = new Label();
            comboBox1 = new ComboBox();
            ResultadoGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // ResultadoGroupBox
            // 
            ResultadoGroupBox.Controls.Add(comboBox1);
            ResultadoGroupBox.Controls.Add(PeriodoLabel);
            ResultadoGroupBox.Controls.Add(ResultadosxEmpresaListView);
            ResultadoGroupBox.Location = new Point(12, 39);
            ResultadoGroupBox.Name = "ResultadoGroupBox";
            ResultadoGroupBox.Size = new Size(710, 276);
            ResultadoGroupBox.TabIndex = 1;
            ResultadoGroupBox.TabStop = false;
            ResultadoGroupBox.Text = "Resultados por empresa";
            // 
            // ResultadosxEmpresaListView
            // 
            ResultadosxEmpresaListView.Columns.AddRange(new ColumnHeader[] { empresaTransporteColumn, CostoMensualColumn, VentasMensualesColumn, ResultadoColumn });
            ResultadosxEmpresaListView.Location = new Point(41, 112);
            ResultadosxEmpresaListView.Name = "ResultadosxEmpresaListView";
            ResultadosxEmpresaListView.Size = new Size(608, 97);
            ResultadosxEmpresaListView.TabIndex = 0;
            ResultadosxEmpresaListView.UseCompatibleStateImageBehavior = false;
            ResultadosxEmpresaListView.View = View.Details;
            // 
            // CostoMensualColumn
            // 
            CostoMensualColumn.Text = "Costo mensual";
            CostoMensualColumn.Width = 150;
            // 
            // VentasMensualesColumn
            // 
            VentasMensualesColumn.Text = "Ventas mensuales";
            VentasMensualesColumn.Width = 150;
            // 
            // ResultadoColumn
            // 
            ResultadoColumn.Text = "Resultado";
            ResultadoColumn.Width = 150;
            // 
            // SalirButton
            // 
            SalirButton.Location = new Point(636, 369);
            SalirButton.Name = "SalirButton";
            SalirButton.Size = new Size(75, 23);
            SalirButton.TabIndex = 2;
            SalirButton.Text = "Salir";
            SalirButton.UseVisualStyleBackColor = true;
            // 
            // empresaTransporteColumn
            // 
            empresaTransporteColumn.Text = "Empresa de Transporte";
            empresaTransporteColumn.Width = 150;
            // 
            // PeriodoLabel
            // 
            PeriodoLabel.AutoSize = true;
            PeriodoLabel.Location = new Point(6, 36);
            PeriodoLabel.Name = "PeriodoLabel";
            PeriodoLabel.Size = new Size(163, 15);
            PeriodoLabel.TabIndex = 1;
            PeriodoLabel.Text = "Indique el periodo a visualizar";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(175, 33);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 2;
            // 
            // MonitoreoResultadosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 402);
            Controls.Add(SalirButton);
            Controls.Add(ResultadoGroupBox);
            Name = "MonitoreoResultadosForm";
            Text = "Monitoreo de resultados";
            ResultadoGroupBox.ResumeLayout(false);
            ResultadoGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox ResultadoGroupBox;
        private ListView ResultadosxEmpresaListView;
        private ColumnHeader CostoMensualColumn;
        private ColumnHeader VentasMensualesColumn;
        private ColumnHeader ResultadoColumn;
        private Button SalirButton;
        private ColumnHeader empresaTransporteColumn;
        private ComboBox comboBox1;
        private Label PeriodoLabel;
    }
}