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
            CriteriosBusquedaGroupBox = new GroupBox();
            IngresoLabel = new Label();
            EmpresasTransporteComboBox = new ComboBox();
            BuscarEmpresaButton = new Button();
            ResultadoGroupBox = new GroupBox();
            listView1 = new ListView();
            CostoMensualColumn = new ColumnHeader();
            VentasMensualesColumn = new ColumnHeader();
            ResultadoColumn = new ColumnHeader();
            SalirButton = new Button();
            CriteriosBusquedaGroupBox.SuspendLayout();
            ResultadoGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // CriteriosBusquedaGroupBox
            // 
            CriteriosBusquedaGroupBox.Controls.Add(BuscarEmpresaButton);
            CriteriosBusquedaGroupBox.Controls.Add(EmpresasTransporteComboBox);
            CriteriosBusquedaGroupBox.Controls.Add(IngresoLabel);
            CriteriosBusquedaGroupBox.Location = new Point(26, 29);
            CriteriosBusquedaGroupBox.Name = "CriteriosBusquedaGroupBox";
            CriteriosBusquedaGroupBox.Size = new Size(718, 100);
            CriteriosBusquedaGroupBox.TabIndex = 0;
            CriteriosBusquedaGroupBox.TabStop = false;
            CriteriosBusquedaGroupBox.Text = "Criterio de búsqueda";
            // 
            // IngresoLabel
            // 
            IngresoLabel.AutoSize = true;
            IngresoLabel.Location = new Point(6, 40);
            IngresoLabel.Name = "IngresoLabel";
            IngresoLabel.Size = new Size(199, 15);
            IngresoLabel.TabIndex = 0;
            IngresoLabel.Text = "Seleccione la empresa de transporte:";
            // 
            // EmpresasTransporteComboBox
            // 
            EmpresasTransporteComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            EmpresasTransporteComboBox.FormattingEnabled = true;
            EmpresasTransporteComboBox.Items.AddRange(new object[] { "Plusmar", "FlechaBus", "Chevallier" });
            EmpresasTransporteComboBox.Location = new Point(211, 37);
            EmpresasTransporteComboBox.Name = "EmpresasTransporteComboBox";
            EmpresasTransporteComboBox.Size = new Size(245, 23);
            EmpresasTransporteComboBox.TabIndex = 1;
            // 
            // BuscarEmpresaButton
            // 
            BuscarEmpresaButton.Location = new Point(476, 37);
            BuscarEmpresaButton.Name = "BuscarEmpresaButton";
            BuscarEmpresaButton.Size = new Size(75, 23);
            BuscarEmpresaButton.TabIndex = 2;
            BuscarEmpresaButton.Text = "Buscar";
            BuscarEmpresaButton.UseVisualStyleBackColor = true;
            // 
            // ResultadoGroupBox
            // 
            ResultadoGroupBox.Controls.Add(listView1);
            ResultadoGroupBox.Location = new Point(32, 159);
            ResultadoGroupBox.Name = "ResultadoGroupBox";
            ResultadoGroupBox.Size = new Size(710, 177);
            ResultadoGroupBox.TabIndex = 1;
            ResultadoGroupBox.TabStop = false;
            ResultadoGroupBox.Text = "Resultado de búsqueda";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { CostoMensualColumn, VentasMensualesColumn, ResultadoColumn });
            listView1.Location = new Point(91, 22);
            listView1.Name = "listView1";
            listView1.Size = new Size(454, 97);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
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
            // MonitoreoResultadosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 402);
            Controls.Add(SalirButton);
            Controls.Add(ResultadoGroupBox);
            Controls.Add(CriteriosBusquedaGroupBox);
            Name = "MonitoreoResultadosForm";
            Text = "Monitoreo de resultados";
            CriteriosBusquedaGroupBox.ResumeLayout(false);
            CriteriosBusquedaGroupBox.PerformLayout();
            ResultadoGroupBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox CriteriosBusquedaGroupBox;
        private ComboBox EmpresasTransporteComboBox;
        private Label IngresoLabel;
        private Button BuscarEmpresaButton;
        private GroupBox ResultadoGroupBox;
        private ListView listView1;
        private ColumnHeader CostoMensualColumn;
        private ColumnHeader VentasMensualesColumn;
        private ColumnHeader ResultadoColumn;
        private Button SalirButton;
    }
}