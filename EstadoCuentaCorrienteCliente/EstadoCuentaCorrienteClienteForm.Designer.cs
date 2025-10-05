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
            BuscarClienteButton = new Button();
            DatosClienteLabel = new Label();
            CuitClienteMaskedText = new MaskedTextBox();
            DatosLabel = new Label();
            MovimientosClienteGroupBox = new GroupBox();
            listView1 = new ListView();
            FechaColumn = new ColumnHeader();
            ConceptoColumn = new ColumnHeader();
            debeColumn = new ColumnHeader();
            haberColumn = new ColumnHeader();
            saldoHeader = new ColumnHeader();
            FechaDesdeLabel = new Label();
            FechaHastaLabel = new Label();
            DesdeDateTimePicker = new DateTimePicker();
            HastaDateTimePicker = new DateTimePicker();
            CancelarButton = new Button();
            label1 = new Label();
            SeleccionClienteGroupBox.SuspendLayout();
            MovimientosClienteGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // SeleccionClienteGroupBox
            // 
            SeleccionClienteGroupBox.Controls.Add(HastaDateTimePicker);
            SeleccionClienteGroupBox.Controls.Add(DesdeDateTimePicker);
            SeleccionClienteGroupBox.Controls.Add(FechaHastaLabel);
            SeleccionClienteGroupBox.Controls.Add(FechaDesdeLabel);
            SeleccionClienteGroupBox.Controls.Add(BuscarClienteButton);
            SeleccionClienteGroupBox.Controls.Add(DatosClienteLabel);
            SeleccionClienteGroupBox.Controls.Add(CuitClienteMaskedText);
            SeleccionClienteGroupBox.Controls.Add(DatosLabel);
            SeleccionClienteGroupBox.Location = new Point(12, 22);
            SeleccionClienteGroupBox.Name = "SeleccionClienteGroupBox";
            SeleccionClienteGroupBox.Size = new Size(776, 123);
            SeleccionClienteGroupBox.TabIndex = 1;
            SeleccionClienteGroupBox.TabStop = false;
            SeleccionClienteGroupBox.Text = "Seleccion";
            // 
            // BuscarClienteButton
            // 
            BuscarClienteButton.Location = new Point(335, 94);
            BuscarClienteButton.Name = "BuscarClienteButton";
            BuscarClienteButton.Size = new Size(75, 23);
            BuscarClienteButton.TabIndex = 8;
            BuscarClienteButton.Text = "Buscar";
            BuscarClienteButton.UseVisualStyleBackColor = true;
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
            MovimientosClienteGroupBox.Controls.Add(label1);
            MovimientosClienteGroupBox.Controls.Add(listView1);
            MovimientosClienteGroupBox.Location = new Point(12, 151);
            MovimientosClienteGroupBox.Name = "MovimientosClienteGroupBox";
            MovimientosClienteGroupBox.Size = new Size(776, 259);
            MovimientosClienteGroupBox.TabIndex = 2;
            MovimientosClienteGroupBox.TabStop = false;
            MovimientosClienteGroupBox.Text = "Movimientos de cuenta corriente";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { FechaColumn, ConceptoColumn, debeColumn, haberColumn, saldoHeader });
            listView1.Location = new Point(15, 22);
            listView1.Name = "listView1";
            listView1.Size = new Size(738, 138);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // FechaColumn
            // 
            FechaColumn.Text = "Fecha";
            FechaColumn.Width = 100;
            // 
            // ConceptoColumn
            // 
            ConceptoColumn.Text = "Concepto";
            ConceptoColumn.Width = 120;
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
            // saldoHeader
            // 
            saldoHeader.Text = "Saldo";
            saldoHeader.Width = 100;
            // 
            // FechaDesdeLabel
            // 
            FechaDesdeLabel.AutoSize = true;
            FechaDesdeLabel.Location = new Point(335, 58);
            FechaDesdeLabel.Name = "FechaDesdeLabel";
            FechaDesdeLabel.Size = new Size(42, 15);
            FechaDesdeLabel.TabIndex = 9;
            FechaDesdeLabel.Text = "Desde:";
            FechaDesdeLabel.Click += label1_Click;
            // 
            // FechaHastaLabel
            // 
            FechaHastaLabel.AutoSize = true;
            FechaHastaLabel.Location = new Point(528, 58);
            FechaHastaLabel.Name = "FechaHastaLabel";
            FechaHastaLabel.Size = new Size(40, 15);
            FechaHastaLabel.TabIndex = 10;
            FechaHastaLabel.Text = "Hasta:";
            // 
            // DesdeDateTimePicker
            // 
            DesdeDateTimePicker.Format = DateTimePickerFormat.Short;
            DesdeDateTimePicker.Location = new Point(383, 54);
            DesdeDateTimePicker.MaxDate = new DateTime(2025, 12, 31, 0, 0, 0, 0);
            DesdeDateTimePicker.Name = "DesdeDateTimePicker";
            DesdeDateTimePicker.Size = new Size(121, 23);
            DesdeDateTimePicker.TabIndex = 11;
            // 
            // HastaDateTimePicker
            // 
            HastaDateTimePicker.Format = DateTimePickerFormat.Short;
            HastaDateTimePicker.Location = new Point(574, 54);
            HastaDateTimePicker.MaxDate = new DateTime(2025, 12, 31, 0, 0, 0, 0);
            HastaDateTimePicker.Name = "HastaDateTimePicker";
            HastaDateTimePicker.Size = new Size(121, 23);
            HastaDateTimePicker.TabIndex = 12;
            // 
            // CancelarButton
            // 
            CancelarButton.Location = new Point(701, 416);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 23);
            CancelarButton.TabIndex = 3;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 208);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 1;
            label1.Text = "TOTAL: ";
            // 
            // EstadoCuentaCorrienteClienteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
        private ListView listView1;
        private ColumnHeader FechaColumn;
        private ColumnHeader ConceptoColumn;
        private ColumnHeader debeColumn;
        private ColumnHeader haberColumn;
        private ColumnHeader saldoHeader;
        private Label FechaHastaLabel;
        private Label FechaDesdeLabel;
        private DateTimePicker HastaDateTimePicker;
        private DateTimePicker DesdeDateTimePicker;
        private Button CancelarButton;
        private Label label1;
    }
}