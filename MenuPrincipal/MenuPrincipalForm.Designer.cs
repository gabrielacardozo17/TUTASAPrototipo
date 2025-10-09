namespace TUTASAPrototipo.MenuPrincipal
{
    partial class MenuPrincipalForm
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
            CallCenterGroupBox = new GroupBox();
            ConsultarEstadoCallCenter = new Button();
            ImposicionCallCenterButton = new Button();
            AgenciaGroupBox = new GroupBox();
            EntregarEncomiendaAgenciaButton = new Button();
            RecepcionAgenciaButton = new Button();
            ImposicionAgenciaButton = new Button();
            CDGroupBox = new GroupBox();
            ConsultarEstadoButton = new Button();
            EntregaEncomiendasCDButton = new Button();
            RecepcionYDespachoLargaDistanciaButton = new Button();
            RecepcionYDespachoUMButton = new Button();
            ImposicionEncomiendasCDButton = new Button();
            AdministracionYFinanzasGroupBox = new GroupBox();
            MonitorearResultadosButton = new Button();
            ConsultarEstadoCCButton = new Button();
            EmitirFacturaButton = new Button();
            CallCenterGroupBox.SuspendLayout();
            AgenciaGroupBox.SuspendLayout();
            CDGroupBox.SuspendLayout();
            AdministracionYFinanzasGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // CallCenterGroupBox
            // 
            CallCenterGroupBox.Controls.Add(ConsultarEstadoCallCenter);
            CallCenterGroupBox.Controls.Add(ImposicionCallCenterButton);
            CallCenterGroupBox.Font = new Font("Segoe UI", 10F);
            CallCenterGroupBox.Location = new Point(22, 12);
            CallCenterGroupBox.Name = "CallCenterGroupBox";
            CallCenterGroupBox.Size = new Size(420, 120);
            CallCenterGroupBox.TabIndex = 0;
            CallCenterGroupBox.TabStop = false;
            CallCenterGroupBox.Text = "Call Center";
            CallCenterGroupBox.Enter += CallCenterGroupBox_Enter;
            // 
            // ConsultarEstadoCallCenter
            // 
            ConsultarEstadoCallCenter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ConsultarEstadoCallCenter.Location = new Point(42, 71);
            ConsultarEstadoCallCenter.Name = "ConsultarEstadoCallCenter";
            ConsultarEstadoCallCenter.Size = new Size(346, 39);
            ConsultarEstadoCallCenter.TabIndex = 1;
            ConsultarEstadoCallCenter.Text = "Consulta de estado de encomiendas";
            ConsultarEstadoCallCenter.UseVisualStyleBackColor = true;
            ConsultarEstadoCallCenter.Click += ConsultarEstadoCallCenter_Click;
            // 
            // ImposicionCallCenterButton
            // 
            ImposicionCallCenterButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ImposicionCallCenterButton.Location = new Point(42, 26);
            ImposicionCallCenterButton.Name = "ImposicionCallCenterButton";
            ImposicionCallCenterButton.Size = new Size(346, 39);
            ImposicionCallCenterButton.TabIndex = 0;
            ImposicionCallCenterButton.Text = "Imposición de encomiendas";
            ImposicionCallCenterButton.UseVisualStyleBackColor = true;
            ImposicionCallCenterButton.Click += ImposicionCallCenterButton_Click;
            // 
            // AgenciaGroupBox
            // 
            AgenciaGroupBox.Controls.Add(EntregarEncomiendaAgenciaButton);
            AgenciaGroupBox.Controls.Add(RecepcionAgenciaButton);
            AgenciaGroupBox.Controls.Add(ImposicionAgenciaButton);
            AgenciaGroupBox.Font = new Font("Segoe UI", 10F);
            AgenciaGroupBox.Location = new Point(22, 138);
            AgenciaGroupBox.Name = "AgenciaGroupBox";
            AgenciaGroupBox.Size = new Size(420, 170);
            AgenciaGroupBox.TabIndex = 1;
            AgenciaGroupBox.TabStop = false;
            AgenciaGroupBox.Text = "Agencia";
            AgenciaGroupBox.Enter += AgenciaGroupBox_Enter;
            // 
            // EntregarEncomiendaAgenciaButton
            // 
            EntregarEncomiendaAgenciaButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EntregarEncomiendaAgenciaButton.Location = new Point(42, 116);
            EntregarEncomiendaAgenciaButton.Name = "EntregarEncomiendaAgenciaButton";
            EntregarEncomiendaAgenciaButton.Size = new Size(346, 39);
            EntregarEncomiendaAgenciaButton.TabIndex = 2;
            EntregarEncomiendaAgenciaButton.Text = "Entrega de encomiendas";
            EntregarEncomiendaAgenciaButton.UseVisualStyleBackColor = true;
            EntregarEncomiendaAgenciaButton.Click += EntregarEncomiendaAgenciaButton_Click;
            // 
            // RecepcionAgenciaButton
            // 
            RecepcionAgenciaButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RecepcionAgenciaButton.Location = new Point(42, 71);
            RecepcionAgenciaButton.Name = "RecepcionAgenciaButton";
            RecepcionAgenciaButton.Size = new Size(346, 39);
            RecepcionAgenciaButton.TabIndex = 1;
            RecepcionAgenciaButton.Text = "Recepción y despacho de encomiendas";
            RecepcionAgenciaButton.UseVisualStyleBackColor = true;
            RecepcionAgenciaButton.Click += RecepcionAgenciaButton_Click;
            // 
            // ImposicionAgenciaButton
            // 
            ImposicionAgenciaButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ImposicionAgenciaButton.Location = new Point(42, 26);
            ImposicionAgenciaButton.Name = "ImposicionAgenciaButton";
            ImposicionAgenciaButton.Size = new Size(346, 39);
            ImposicionAgenciaButton.TabIndex = 0;
            ImposicionAgenciaButton.Text = "Imposición de encomiendas";
            ImposicionAgenciaButton.UseVisualStyleBackColor = true;
            ImposicionAgenciaButton.Click += ImposicionAgenciaButton_Click;
            // 
            // CDGroupBox
            // 
            CDGroupBox.Controls.Add(ConsultarEstadoButton);
            CDGroupBox.Controls.Add(EntregaEncomiendasCDButton);
            CDGroupBox.Controls.Add(RecepcionYDespachoLargaDistanciaButton);
            CDGroupBox.Controls.Add(RecepcionYDespachoUMButton);
            CDGroupBox.Controls.Add(ImposicionEncomiendasCDButton);
            CDGroupBox.Font = new Font("Segoe UI", 10F);
            CDGroupBox.Location = new Point(22, 314);
            CDGroupBox.Name = "CDGroupBox";
            CDGroupBox.Size = new Size(420, 259);
            CDGroupBox.TabIndex = 2;
            CDGroupBox.TabStop = false;
            CDGroupBox.Text = "Centro de distribución";
            CDGroupBox.Enter += groupBox1_Enter;
            // 
            // ConsultarEstadoButton
            // 
            ConsultarEstadoButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ConsultarEstadoButton.Location = new Point(42, 206);
            ConsultarEstadoButton.Name = "ConsultarEstadoButton";
            ConsultarEstadoButton.Size = new Size(346, 39);
            ConsultarEstadoButton.TabIndex = 4;
            ConsultarEstadoButton.Text = "Consulta de estado de encomiendas";
            ConsultarEstadoButton.UseVisualStyleBackColor = true;
            ConsultarEstadoButton.Click += ConsultarEstadoButton_Click;
            // 
            // EntregaEncomiendasCDButton
            // 
            EntregaEncomiendasCDButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EntregaEncomiendasCDButton.Location = new Point(42, 161);
            EntregaEncomiendasCDButton.Name = "EntregaEncomiendasCDButton";
            EntregaEncomiendasCDButton.Size = new Size(346, 39);
            EntregaEncomiendasCDButton.TabIndex = 3;
            EntregaEncomiendasCDButton.Text = "Entrega de encomiendas";
            EntregaEncomiendasCDButton.UseVisualStyleBackColor = true;
            EntregaEncomiendasCDButton.Click += EntregaEncomiendasCDButton_Click;
            // 
            // RecepcionYDespachoLargaDistanciaButton
            // 
            RecepcionYDespachoLargaDistanciaButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RecepcionYDespachoLargaDistanciaButton.Location = new Point(42, 116);
            RecepcionYDespachoLargaDistanciaButton.Name = "RecepcionYDespachoLargaDistanciaButton";
            RecepcionYDespachoLargaDistanciaButton.Size = new Size(346, 39);
            RecepcionYDespachoLargaDistanciaButton.TabIndex = 2;
            RecepcionYDespachoLargaDistanciaButton.Text = "Recepción y despacho de encomiendas larga distancia";
            RecepcionYDespachoLargaDistanciaButton.UseVisualStyleBackColor = true;
            RecepcionYDespachoLargaDistanciaButton.Click += RecepcionYDespachoLargaDistanciaButton_Click;
            // 
            // RecepcionYDespachoUMButton
            // 
            RecepcionYDespachoUMButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RecepcionYDespachoUMButton.Location = new Point(42, 71);
            RecepcionYDespachoUMButton.Name = "RecepcionYDespachoUMButton";
            RecepcionYDespachoUMButton.Size = new Size(346, 39);
            RecepcionYDespachoUMButton.TabIndex = 1;
            RecepcionYDespachoUMButton.Text = "Recepción y despacho de encomiendas última milla";
            RecepcionYDespachoUMButton.UseVisualStyleBackColor = true;
            RecepcionYDespachoUMButton.Click += RecepcionYDespachoUMButton_Click;
            // 
            // ImposicionEncomiendasCDButton
            // 
            ImposicionEncomiendasCDButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ImposicionEncomiendasCDButton.Location = new Point(42, 26);
            ImposicionEncomiendasCDButton.Name = "ImposicionEncomiendasCDButton";
            ImposicionEncomiendasCDButton.Size = new Size(346, 39);
            ImposicionEncomiendasCDButton.TabIndex = 0;
            ImposicionEncomiendasCDButton.Text = "Imposición de encomiendas";
            ImposicionEncomiendasCDButton.UseVisualStyleBackColor = true;
            ImposicionEncomiendasCDButton.Click += ImposicionEncomiendasCDButton_Click;
            // 
            // AdministracionYFinanzasGroupBox
            // 
            AdministracionYFinanzasGroupBox.Controls.Add(MonitorearResultadosButton);
            AdministracionYFinanzasGroupBox.Controls.Add(ConsultarEstadoCCButton);
            AdministracionYFinanzasGroupBox.Controls.Add(EmitirFacturaButton);
            AdministracionYFinanzasGroupBox.Font = new Font("Segoe UI", 10F);
            AdministracionYFinanzasGroupBox.Location = new Point(22, 579);
            AdministracionYFinanzasGroupBox.Name = "AdministracionYFinanzasGroupBox";
            AdministracionYFinanzasGroupBox.Size = new Size(420, 174);
            AdministracionYFinanzasGroupBox.TabIndex = 3;
            AdministracionYFinanzasGroupBox.TabStop = false;
            AdministracionYFinanzasGroupBox.Text = "Administración y finanzas";
            AdministracionYFinanzasGroupBox.Enter += AdministracionYFinanzasGroupBox_Enter;
            // 
            // MonitorearResultadosButton
            // 
            MonitorearResultadosButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MonitorearResultadosButton.Location = new Point(42, 116);
            MonitorearResultadosButton.Name = "MonitorearResultadosButton";
            MonitorearResultadosButton.Size = new Size(346, 39);
            MonitorearResultadosButton.TabIndex = 2;
            MonitorearResultadosButton.Text = "Monitoreo de resultados";
            MonitorearResultadosButton.UseVisualStyleBackColor = true;
            MonitorearResultadosButton.Click += MonitorearResultadosButton_Click;
            // 
            // ConsultarEstadoCCButton
            // 
            ConsultarEstadoCCButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ConsultarEstadoCCButton.Location = new Point(42, 71);
            ConsultarEstadoCCButton.Name = "ConsultarEstadoCCButton";
            ConsultarEstadoCCButton.Size = new Size(346, 39);
            ConsultarEstadoCCButton.TabIndex = 1;
            ConsultarEstadoCCButton.Text = "Consulta de estado de cuenta corriente";
            ConsultarEstadoCCButton.UseVisualStyleBackColor = true;
            ConsultarEstadoCCButton.Click += ConsultarEstadoCCButton_Click;
            // 
            // EmitirFacturaButton
            // 
            EmitirFacturaButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EmitirFacturaButton.Location = new Point(42, 26);
            EmitirFacturaButton.Name = "EmitirFacturaButton";
            EmitirFacturaButton.Size = new Size(346, 39);
            EmitirFacturaButton.TabIndex = 0;
            EmitirFacturaButton.Text = "Emisión de facturas";
            EmitirFacturaButton.UseVisualStyleBackColor = true;
            EmitirFacturaButton.Click += EmitirFacturaButton_Click;
            // 
            // MenuPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 765);
            Controls.Add(AdministracionYFinanzasGroupBox);
            Controls.Add(CDGroupBox);
            Controls.Add(AgenciaGroupBox);
            Controls.Add(CallCenterGroupBox);
            Name = "MenuPrincipalForm";
            Text = "Menú Principal";
            CallCenterGroupBox.ResumeLayout(false);
            AgenciaGroupBox.ResumeLayout(false);
            CDGroupBox.ResumeLayout(false);
            AdministracionYFinanzasGroupBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox CallCenterGroupBox;
        private Button ImposicionCallCenterButton;
        private GroupBox AgenciaGroupBox;
        private Button RecepcionAgenciaButton;
        private Button ImposicionAgenciaButton;
        private Button EntregarEncomiendaAgenciaButton;
        private GroupBox CDGroupBox;
        private Button RecepcionYDespachoLargaDistanciaButton;
        private Button RecepcionYDespachoUMButton;
        private Button ImposicionEncomiendasCDButton;
        private Button EntregaEncomiendasCDButton;
        private Button ConsultarEstadoButton;
        private GroupBox AdministracionYFinanzasGroupBox;
        private Button MonitorearResultadosButton;
        private Button ConsultarEstadoCCButton;
        private Button EmitirFacturaButton;
        private Button ConsultarEstadoCallCenter;
    }
}