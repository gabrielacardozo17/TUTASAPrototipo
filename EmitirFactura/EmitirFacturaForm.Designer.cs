namespace TUTASAPrototipo.EmitirFactura
{
    partial class EmitirFacturaForm
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
            SeleccionGroupBox = new GroupBox();
            BuscarFacturasButton = new Button();
            DatosClienteLabel = new Label();
            CuitClienteMaskedText = new MaskedTextBox();
            DatosLabel = new Label();
            ResultadosGroupBox = new GroupBox();
            MontoTotalLabel = new Label();
            IndicacionTotalLabel = new Label();
            DetalleFacturaciónListView = new ListView();
            GuiaColumn = new ColumnHeader();
            FechaAdmisionColumn = new ColumnHeader();
            OrigenColumn = new ColumnHeader();
            DestinoColumn = new ColumnHeader();
            TamanioColumn = new ColumnHeader();
            ImporteColumn = new ColumnHeader();
            IndicacionMontosLabel = new Label();
            EmitirFacturaButton = new Button();
            CancelarButton = new Button();
            SeleccionGroupBox.SuspendLayout();
            ResultadosGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // SeleccionGroupBox
            // 
            SeleccionGroupBox.Controls.Add(BuscarFacturasButton);
            SeleccionGroupBox.Controls.Add(DatosClienteLabel);
            SeleccionGroupBox.Controls.Add(CuitClienteMaskedText);
            SeleccionGroupBox.Controls.Add(DatosLabel);
            SeleccionGroupBox.Location = new Point(28, 32);
            SeleccionGroupBox.Name = "SeleccionGroupBox";
            SeleccionGroupBox.Size = new Size(867, 105);
            SeleccionGroupBox.TabIndex = 0;
            SeleccionGroupBox.TabStop = false;
            SeleccionGroupBox.Text = "Seleccion";
            // 
            // BuscarFacturasButton
            // 
            BuscarFacturasButton.Location = new Point(275, 54);
            BuscarFacturasButton.Name = "BuscarFacturasButton";
            BuscarFacturasButton.Size = new Size(75, 23);
            BuscarFacturasButton.TabIndex = 8;
            BuscarFacturasButton.Text = "Buscar";
            BuscarFacturasButton.UseVisualStyleBackColor = true;
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
            DatosLabel.Size = new Size(93, 15);
            DatosLabel.TabIndex = 0;
            DatosLabel.Text = "CUIT del cliente:";
            // 
            // ResultadosGroupBox
            // 
            ResultadosGroupBox.Controls.Add(MontoTotalLabel);
            ResultadosGroupBox.Controls.Add(IndicacionTotalLabel);
            ResultadosGroupBox.Controls.Add(DetalleFacturaciónListView);
            ResultadosGroupBox.Controls.Add(IndicacionMontosLabel);
            ResultadosGroupBox.Location = new Point(28, 159);
            ResultadosGroupBox.Name = "ResultadosGroupBox";
            ResultadosGroupBox.Size = new Size(867, 218);
            ResultadosGroupBox.TabIndex = 1;
            ResultadosGroupBox.TabStop = false;
            ResultadosGroupBox.Text = "Detalle de envíos a facturar";
            // 
            // MontoTotalLabel
            // 
            MontoTotalLabel.AutoSize = true;
            MontoTotalLabel.Font = new Font("Segoe UI", 10F);
            MontoTotalLabel.Location = new Point(125, 188);
            MontoTotalLabel.Name = "MontoTotalLabel";
            MontoTotalLabel.Size = new Size(49, 19);
            MontoTotalLabel.TabIndex = 6;
            MontoTotalLabel.Text = "$2000";
            // 
            // IndicacionTotalLabel
            // 
            IndicacionTotalLabel.AutoSize = true;
            IndicacionTotalLabel.Location = new Point(6, 190);
            IndicacionTotalLabel.Name = "IndicacionTotalLabel";
            IndicacionTotalLabel.Size = new Size(116, 15);
            IndicacionTotalLabel.TabIndex = 2;
            IndicacionTotalLabel.Text = "TOTAL A FACTURAR:";
            // 
            // DetalleFacturaciónListView
            // 
            DetalleFacturaciónListView.Columns.AddRange(new ColumnHeader[] { GuiaColumn, FechaAdmisionColumn, OrigenColumn, DestinoColumn, TamanioColumn, ImporteColumn });
            DetalleFacturaciónListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            DetalleFacturaciónListView.Location = new Point(44, 56);
            DetalleFacturaciónListView.Name = "DetalleFacturaciónListView";
            DetalleFacturaciónListView.Size = new Size(774, 97);
            DetalleFacturaciónListView.TabIndex = 1;
            DetalleFacturaciónListView.UseCompatibleStateImageBehavior = false;
            DetalleFacturaciónListView.View = View.Details;
            // 
            // GuiaColumn
            // 
            GuiaColumn.Text = "Nro de Guia";
            GuiaColumn.Width = 160;
            // 
            // FechaAdmisionColumn
            // 
            FechaAdmisionColumn.Text = "Fecha de Admision";
            FechaAdmisionColumn.Width = 150;
            // 
            // OrigenColumn
            // 
            OrigenColumn.Text = "Origen";
            OrigenColumn.Width = 150;
            // 
            // DestinoColumn
            // 
            DestinoColumn.Text = "Destino";
            DestinoColumn.Width = 150;
            // 
            // TamanioColumn
            // 
            TamanioColumn.Text = "Tamaño";
            // 
            // ImporteColumn
            // 
            ImporteColumn.Text = "Importe";
            ImporteColumn.Width = 100;
            // 
            // IndicacionMontosLabel
            // 
            IndicacionMontosLabel.AutoSize = true;
            IndicacionMontosLabel.Location = new Point(6, 29);
            IndicacionMontosLabel.Name = "IndicacionMontosLabel";
            IndicacionMontosLabel.Size = new Size(362, 15);
            IndicacionMontosLabel.TabIndex = 0;
            IndicacionMontosLabel.Text = "Usted está viendo los montos pendientes de facturación del cliente:";
            // 
            // EmitirFacturaButton
            // 
            EmitirFacturaButton.Location = new Point(787, 407);
            EmitirFacturaButton.Name = "EmitirFacturaButton";
            EmitirFacturaButton.Size = new Size(96, 30);
            EmitirFacturaButton.TabIndex = 2;
            EmitirFacturaButton.Text = "Emitir Factura";
            EmitirFacturaButton.UseVisualStyleBackColor = true;
            EmitirFacturaButton.Click += EmitirFacturaButton_Click;
            // 
            // CancelarButton
            // 
            CancelarButton.Location = new Point(685, 407);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(96, 30);
            CancelarButton.TabIndex = 3;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            // 
            // EmitirFacturaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(907, 458);
            Controls.Add(CancelarButton);
            Controls.Add(EmitirFacturaButton);
            Controls.Add(ResultadosGroupBox);
            Controls.Add(SeleccionGroupBox);
            Name = "EmitirFacturaForm";
            Text = "Emitir Factura";
            SeleccionGroupBox.ResumeLayout(false);
            SeleccionGroupBox.PerformLayout();
            ResultadosGroupBox.ResumeLayout(false);
            ResultadosGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox SeleccionGroupBox;
        private Label DatosClienteLabel;
        private MaskedTextBox CuitClienteMaskedText;
        private Label DatosLabel;
        private Button BuscarFacturasButton;
        private GroupBox ResultadosGroupBox;
        private ListView DetalleFacturaciónListView;
        private ColumnHeader GuiaColumn;
        private ColumnHeader FechaAdmisionColumn;
        private ColumnHeader OrigenColumn;
        private ColumnHeader DestinoColumn;
        private ColumnHeader TamanioColumn;
        private ColumnHeader ImporteColumn;
        private Label IndicacionMontosLabel;
        private Label IndicacionTotalLabel;
        private Button EmitirFacturaButton;
        private Button CancelarButton;
        private Label MontoTotalLabel;
    }
}