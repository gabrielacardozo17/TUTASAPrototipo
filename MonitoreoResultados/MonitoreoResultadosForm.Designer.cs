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
            empresaTransporteColumn = new ColumnHeader();
            CostoMensualColumn = new ColumnHeader();
            VentasMensualesColumn = new ColumnHeader();
            ResultadoColumn = new ColumnHeader();
            PeriodoLabel = new Label();
            CancelarButton = new Button();
            PeriodoDateTimePicker = new DateTimePicker();
            SeleccionPeriodoGroupBox = new GroupBox();
            BuscarResultadosxPeriodoButton = new Button();
            ResultadoGroupBox.SuspendLayout();
            SeleccionPeriodoGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // ResultadoGroupBox
            // 
            ResultadoGroupBox.Controls.Add(ResultadosxEmpresaListView);
            ResultadoGroupBox.Location = new Point(12, 123);
            ResultadoGroupBox.Name = "ResultadoGroupBox";
            ResultadoGroupBox.Size = new Size(649, 254);
            ResultadoGroupBox.TabIndex = 1;
            ResultadoGroupBox.TabStop = false;
            ResultadoGroupBox.Text = "Resultados";
            // 
            // ResultadosxEmpresaListView
            // 
            ResultadosxEmpresaListView.Columns.AddRange(new ColumnHeader[] { empresaTransporteColumn, CostoMensualColumn, VentasMensualesColumn, ResultadoColumn });
            ResultadosxEmpresaListView.Location = new Point(9, 22);
            ResultadosxEmpresaListView.Name = "ResultadosxEmpresaListView";
            ResultadosxEmpresaListView.Size = new Size(634, 218);
            ResultadosxEmpresaListView.TabIndex = 0;
            ResultadosxEmpresaListView.UseCompatibleStateImageBehavior = false;
            ResultadosxEmpresaListView.View = View.Details;
            // 
            // empresaTransporteColumn
            // 
            empresaTransporteColumn.Text = "Empresa de Transporte";
            empresaTransporteColumn.Width = 200;
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
            ResultadoColumn.Width = 130;
            // 
            // PeriodoLabel
            // 
            PeriodoLabel.AutoSize = true;
            PeriodoLabel.Font = new Font("Segoe UI", 9F);
            PeriodoLabel.Location = new Point(6, 45);
            PeriodoLabel.Name = "PeriodoLabel";
            PeriodoLabel.Size = new Size(281, 15);
            PeriodoLabel.TabIndex = 1;
            PeriodoLabel.Text = "Indique el periodo cuyos resultados desea visualizar:";
            // 
            // CancelarButton
            // 
            CancelarButton.Location = new Point(564, 403);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 23);
            CancelarButton.TabIndex = 2;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // PeriodoDateTimePicker
            // 
            PeriodoDateTimePicker.CustomFormat = "MMMM yyyy";
            PeriodoDateTimePicker.Format = DateTimePickerFormat.Custom;
            PeriodoDateTimePicker.Location = new Point(293, 41);
            PeriodoDateTimePicker.MaxDate = new DateTime(2209, 12, 31, 0, 0, 0, 0);
            PeriodoDateTimePicker.Name = "PeriodoDateTimePicker";
            PeriodoDateTimePicker.ShowUpDown = true;
            PeriodoDateTimePicker.Size = new Size(163, 23);
            PeriodoDateTimePicker.TabIndex = 11;
            PeriodoDateTimePicker.Value = new DateTime(2025, 10, 7, 0, 0, 0, 0);
            // 
            // SeleccionPeriodoGroupBox
            // 
            SeleccionPeriodoGroupBox.Controls.Add(BuscarResultadosxPeriodoButton);
            SeleccionPeriodoGroupBox.Controls.Add(PeriodoDateTimePicker);
            SeleccionPeriodoGroupBox.Controls.Add(PeriodoLabel);
            SeleccionPeriodoGroupBox.Location = new Point(12, 12);
            SeleccionPeriodoGroupBox.Name = "SeleccionPeriodoGroupBox";
            SeleccionPeriodoGroupBox.Size = new Size(649, 96);
            SeleccionPeriodoGroupBox.TabIndex = 3;
            SeleccionPeriodoGroupBox.TabStop = false;
            SeleccionPeriodoGroupBox.Text = "Selección";
            // 
            // BuscarResultadosxPeriodoButton
            // 
            BuscarResultadosxPeriodoButton.Location = new Point(474, 41);
            BuscarResultadosxPeriodoButton.Name = "BuscarResultadosxPeriodoButton";
            BuscarResultadosxPeriodoButton.Size = new Size(75, 23);
            BuscarResultadosxPeriodoButton.TabIndex = 12;
            BuscarResultadosxPeriodoButton.Text = "Buscar";
            BuscarResultadosxPeriodoButton.UseVisualStyleBackColor = true;
            BuscarResultadosxPeriodoButton.Click += BuscarResultadosxPeriodoButton_Click;
            // 
            // MonitoreoResultadosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(677, 441);
            Controls.Add(SeleccionPeriodoGroupBox);
            Controls.Add(CancelarButton);
            Controls.Add(ResultadoGroupBox);
            Name = "MonitoreoResultadosForm";
            Text = "Monitoreo de resultados";
            Load += MonitoreoResultadosForm_Load;
            ResultadoGroupBox.ResumeLayout(false);
            SeleccionPeriodoGroupBox.ResumeLayout(false);
            SeleccionPeriodoGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox ResultadoGroupBox;
        private ListView ResultadosxEmpresaListView;
        private ColumnHeader CostoMensualColumn;
        private ColumnHeader VentasMensualesColumn;
        private ColumnHeader ResultadoColumn;
        private Button CancelarButton;
        private ColumnHeader empresaTransporteColumn;
        private Label PeriodoLabel;
        private DateTimePicker PeriodoDateTimePicker;
        private GroupBox SeleccionPeriodoGroupBox;
        private Button BuscarResultadosxPeriodoButton;
    }
}