namespace TUTASAPrototipo.EstadoCuentaCorrienteCliente
{
    partial class EstadoCuentaCorrienteClienteForm
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
            SeleccionClienteGroupBox = new GroupBox();
            PeriodoDateTimePicker = new DateTimePicker();
            PeriodoLabel = new Label();
            BuscarClienteButton = new Button();
            DatosClienteLabel = new Label();
            CuitClienteMaskedText = new MaskedTextBox();
            DatosLabel = new Label();
            MovimientosClienteGroupBox = new GroupBox();
            SaldoAlCierre = new Label();
            MovimientosListView = new ListView();
            FechaColumn = new ColumnHeader();
            ConceptoColumn = new ColumnHeader();
            debeColumn = new ColumnHeader();
            haberColumn = new ColumnHeader();
            CancelarButton = new Button();
            SeleccionClienteGroupBox.SuspendLayout();
            MovimientosClienteGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // SeleccionClienteGroupBox
            // 
            SeleccionClienteGroupBox.Controls.Add(PeriodoDateTimePicker);
            SeleccionClienteGroupBox.Controls.Add(PeriodoLabel);
            SeleccionClienteGroupBox.Controls.Add(BuscarClienteButton);
            SeleccionClienteGroupBox.Controls.Add(DatosClienteLabel);
            SeleccionClienteGroupBox.Controls.Add(CuitClienteMaskedText);
            SeleccionClienteGroupBox.Controls.Add(DatosLabel);
            SeleccionClienteGroupBox.Location = new Point(12, 22);
            SeleccionClienteGroupBox.Name = "SeleccionClienteGroupBox";
            SeleccionClienteGroupBox.Size = new Size(664, 123);
            SeleccionClienteGroupBox.TabIndex = 1;
            SeleccionClienteGroupBox.TabStop = false;
            SeleccionClienteGroupBox.Text = "Seleccion";
            // 
            // PeriodoDateTimePicker
            // 
            PeriodoDateTimePicker.CustomFormat = "MMMM yyyy";
            PeriodoDateTimePicker.Format = DateTimePickerFormat.Custom;
            PeriodoDateTimePicker.Location = new Point(428, 54);
            PeriodoDateTimePicker.MaxDate = new DateTime(2369, 12, 31, 0, 0, 0, 0);
            PeriodoDateTimePicker.Name = "PeriodoDateTimePicker";
            PeriodoDateTimePicker.ShowUpDown = true;
            PeriodoDateTimePicker.Size = new Size(200, 23);
            PeriodoDateTimePicker.TabIndex = 10;
            PeriodoDateTimePicker.Value = new DateTime(2025, 10, 7, 0, 0, 0, 0);
            PeriodoDateTimePicker.ValueChanged += PeriodoDateTimePicker_ValueChanged;
            // 
            // PeriodoLabel
            // 
            PeriodoLabel.AutoSize = true;
            PeriodoLabel.Location = new Point(371, 58);
            PeriodoLabel.Name = "PeriodoLabel";
            PeriodoLabel.Size = new Size(51, 15);
            PeriodoLabel.TabIndex = 9;
            PeriodoLabel.Text = "Período:";
            PeriodoLabel.Click += label1_Click;
            // 
            // BuscarClienteButton
            // 
            BuscarClienteButton.Location = new Point(294, 94);
            BuscarClienteButton.Name = "BuscarClienteButton";
            BuscarClienteButton.Size = new Size(75, 23);
            BuscarClienteButton.TabIndex = 8;
            BuscarClienteButton.Text = "Buscar";
            BuscarClienteButton.UseVisualStyleBackColor = true;
            BuscarClienteButton.Click += BuscarClienteButton_Click;
            // 
            // DatosClienteLabel
            // 
            DatosClienteLabel.AutoSize = true;
            DatosClienteLabel.Location = new Point(6, 28);
            DatosClienteLabel.Name = "DatosClienteLabel";
            DatosClienteLabel.Size = new Size(97, 15);
            DatosClienteLabel.TabIndex = 2;
            DatosClienteLabel.Text = "Datos del cliente:";
            // 
            // CuitClienteMaskedText
            // 
            CuitClienteMaskedText.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            CuitClienteMaskedText.Location = new Point(104, 54);
            CuitClienteMaskedText.Mask = "00-00000000-0";
            CuitClienteMaskedText.Name = "CuitClienteMaskedText";
            CuitClienteMaskedText.Size = new Size(154, 23);
            CuitClienteMaskedText.TabIndex = 1;
            // 
            // DatosLabel
            // 
            DatosLabel.AutoSize = true;
            DatosLabel.Location = new Point(6, 58);
            DatosLabel.Name = "DatosLabel";
            DatosLabel.Size = new Size(92, 15);
            DatosLabel.TabIndex = 0;
            DatosLabel.Text = "CUIT del cliente:";
            // 
            // MovimientosClienteGroupBox
            // 
            MovimientosClienteGroupBox.Controls.Add(SaldoAlCierre);
            MovimientosClienteGroupBox.Controls.Add(MovimientosListView);
            MovimientosClienteGroupBox.Location = new Point(12, 151);
            MovimientosClienteGroupBox.Name = "MovimientosClienteGroupBox";
            MovimientosClienteGroupBox.Size = new Size(664, 259);
            MovimientosClienteGroupBox.TabIndex = 2;
            MovimientosClienteGroupBox.TabStop = false;
            MovimientosClienteGroupBox.Text = "Movimientos de cuenta corriente";
            // 
            // SaldoAlCierre
            // 
            SaldoAlCierre.AutoSize = true;
            SaldoAlCierre.Location = new Point(6, 203);
            SaldoAlCierre.Name = "SaldoAlCierre";
            SaldoAlCierre.Size = new Size(154, 15);
            SaldoAlCierre.TabIndex = 1;
            SaldoAlCierre.Text = "Saldo al cierre del periodo: -";
            // 
            // MovimientosListView
            // 
            MovimientosListView.Columns.AddRange(new ColumnHeader[] { FechaColumn, ConceptoColumn, debeColumn, haberColumn });
            MovimientosListView.Location = new Point(51, 36);
            MovimientosListView.Name = "MovimientosListView";
            MovimientosListView.Size = new Size(555, 138);
            MovimientosListView.TabIndex = 0;
            MovimientosListView.UseCompatibleStateImageBehavior = false;
            MovimientosListView.View = View.Details;
            // 
            // FechaColumn
            // 
            FechaColumn.Text = "Fecha";
            FechaColumn.Width = 100;
            // 
            // ConceptoColumn
            // 
            ConceptoColumn.Text = "Concepto";
            ConceptoColumn.Width = 250;
            // 
            // debeColumn
            // 
            debeColumn.Text = "Debe";
            debeColumn.Width = 100;
            // 
            // haberColumn
            // 
            haberColumn.Text = "Haber";
            haberColumn.Width = 100;
            // 
            // CancelarButton
            // 
            CancelarButton.Location = new Point(601, 415);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 23);
            CancelarButton.TabIndex = 3;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // EstadoCuentaCorrienteClienteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(714, 450);
            Controls.Add(CancelarButton);
            Controls.Add(MovimientosClienteGroupBox);
            Controls.Add(SeleccionClienteGroupBox);
            Name = "EstadoCuentaCorrienteClienteForm";
            Text = "Estado de Cuenta Corriente ";
            SeleccionClienteGroupBox.ResumeLayout(false);
            SeleccionClienteGroupBox.PerformLayout();
            MovimientosClienteGroupBox.ResumeLayout(false);
            MovimientosClienteGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox SeleccionClienteGroupBox;
        private Button BuscarClienteButton;
        private Label DatosClienteLabel;
        private MaskedTextBox CuitClienteMaskedText;
        private Label DatosLabel;
        private GroupBox MovimientosClienteGroupBox;
        private ListView MovimientosListView;
        private ColumnHeader FechaColumn;
        private ColumnHeader ConceptoColumn;
        private ColumnHeader debeColumn;
        private ColumnHeader haberColumn;
        private Button CancelarButton;
        private Label SaldoAlCierre;
        private Label PeriodoLabel;
        private DateTimePicker PeriodoDateTimePicker;
    }
}