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
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
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
            SalirButton = new Button();
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
            DatosLabel.Size = new Size(92, 15);
            DatosLabel.TabIndex = 0;
            DatosLabel.Text = "CUIT del cliente:";
            // 
            // ResultadosGroupBox
            // 
            ResultadosGroupBox.Controls.Add(MontoTotalLabel);
            ResultadosGroupBox.Controls.Add(label8);
            ResultadosGroupBox.Controls.Add(label7);
            ResultadosGroupBox.Controls.Add(label6);
            ResultadosGroupBox.Controls.Add(label5);
            ResultadosGroupBox.Controls.Add(label4);
            ResultadosGroupBox.Controls.Add(label3);
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
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = SystemColors.ControlLightLight;
            label8.Location = new Point(717, 81);
            label8.Name = "label8";
            label8.Size = new Size(37, 15);
            label8.TabIndex = 5;
            label8.Text = "$2000";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = SystemColors.ControlLightLight;
            label7.Location = new Point(657, 81);
            label7.Name = "label7";
            label7.Size = new Size(13, 15);
            label7.TabIndex = 5;
            label7.Text = "S";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ControlLightLight;
            label6.Location = new Point(517, 81);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 4;
            label6.Text = "Chivilcoy";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ControlLightLight;
            label5.Location = new Point(363, 81);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 4;
            label5.Text = "Lanús";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ControlLightLight;
            label4.Location = new Point(213, 81);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 4;
            label4.Text = "09/09/2025";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ControlLightLight;
            label3.Location = new Point(49, 81);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 3;
            label3.Text = "LN02365845";
            // 
            // IndicacionTotalLabel
            // 
            IndicacionTotalLabel.AutoSize = true;
            IndicacionTotalLabel.Location = new Point(6, 190);
            IndicacionTotalLabel.Name = "IndicacionTotalLabel";
            IndicacionTotalLabel.Size = new Size(113, 15);
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
            // SalirButton
            // 
            SalirButton.Location = new Point(685, 407);
            SalirButton.Name = "SalirButton";
            SalirButton.Size = new Size(96, 30);
            SalirButton.TabIndex = 3;
            SalirButton.Text = "Salir";
            SalirButton.UseVisualStyleBackColor = true;
            // 
            // EmitirFacturaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(907, 458);
            Controls.Add(SalirButton);
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
        private Button SalirButton;
        private Label MontoTotalLabel;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
    }
}