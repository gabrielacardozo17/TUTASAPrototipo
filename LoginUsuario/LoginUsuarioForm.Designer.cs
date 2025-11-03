namespace TUTASAPrototipo.LoginUsuario
{
    partial class LoginUsuarioForm
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
            EmailTextBox = new TextBox();
            label2 = new Label();
            ContraseniaTextBox = new TextBox();
            IngresarButton = new Button();
            BienvenidoLabel = new Label();
            label3 = new Label();
            CdActualCombo = new ComboBox();
            AgenciaActualCombo = new ComboBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 74);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Email:";
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(98, 71);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(185, 23);
            EmailTextBox.TabIndex = 1;
            EmailTextBox.Text = "jperez@gmail.com";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 115);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 2;
            label2.Text = "Contraseña:";
            // 
            // ContraseniaTextBox
            // 
            ContraseniaTextBox.Location = new Point(98, 112);
            ContraseniaTextBox.Name = "ContraseniaTextBox";
            ContraseniaTextBox.Size = new Size(185, 23);
            ContraseniaTextBox.TabIndex = 3;
            ContraseniaTextBox.Text = "juanAgosto";
            ContraseniaTextBox.UseSystemPasswordChar = true;
            // 
            // IngresarButton
            // 
            IngresarButton.Location = new Point(136, 231);
            IngresarButton.Name = "IngresarButton";
            IngresarButton.Size = new Size(75, 23);
            IngresarButton.TabIndex = 4;
            IngresarButton.Text = "Ingresar";
            IngresarButton.UseVisualStyleBackColor = true;
            IngresarButton.Click += IngresarButton_Click;
            // 
            // BienvenidoLabel
            // 
            BienvenidoLabel.AutoSize = true;
            BienvenidoLabel.Font = new Font("Segoe UI", 12F);
            BienvenidoLabel.Location = new Point(111, 23);
            BienvenidoLabel.Name = "BienvenidoLabel";
            BienvenidoLabel.Size = new Size(100, 21);
            BienvenidoLabel.TabIndex = 5;
            BienvenidoLabel.Text = "BIENVENIDO";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 160);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 6;
            label3.Text = "CD Actual:";
            // 
            // CdActualCombo
            // 
            CdActualCombo.FormattingEnabled = true;
            CdActualCombo.Location = new Point(111, 157);
            CdActualCombo.Name = "CdActualCombo";
            CdActualCombo.Size = new Size(185, 23);
            CdActualCombo.TabIndex = 7;
            // 
            // AgenciaActualCombo
            // 
            AgenciaActualCombo.FormattingEnabled = true;
            AgenciaActualCombo.Location = new Point(111, 186);
            AgenciaActualCombo.Name = "AgenciaActualCombo";
            AgenciaActualCombo.Size = new Size(185, 23);
            AgenciaActualCombo.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 189);
            label4.Name = "label4";
            label4.Size = new Size(88, 15);
            label4.TabIndex = 8;
            label4.Text = "Agencia actual:";
            // 
            // LoginUsuarioForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(321, 297);
            Controls.Add(AgenciaActualCombo);
            Controls.Add(label4);
            Controls.Add(CdActualCombo);
            Controls.Add(label3);
            Controls.Add(BienvenidoLabel);
            Controls.Add(IngresarButton);
            Controls.Add(ContraseniaTextBox);
            Controls.Add(label2);
            Controls.Add(EmailTextBox);
            Controls.Add(label1);
            Name = "LoginUsuarioForm";
            Text = "Inicio de Sesión";
            Load += LoginUsuarioForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox EmailTextBox;
        private Label label2;
        private TextBox ContraseniaTextBox;
        private Button IngresarButton;
        private Label BienvenidoLabel;
        private Label label3;
        private ComboBox CdActualCombo;
        private ComboBox AgenciaActualCombo;
        private Label label4;
    }
}