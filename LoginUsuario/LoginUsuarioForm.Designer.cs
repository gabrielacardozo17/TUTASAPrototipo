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
            ContraseniaTextBox.UseSystemPasswordChar = true;
            // 
            // IngresarButton
            // 
            IngresarButton.Location = new Point(122, 159);
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
            // LoginUsuarioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(321, 217);
            Controls.Add(BienvenidoLabel);
            Controls.Add(IngresarButton);
            Controls.Add(ContraseniaTextBox);
            Controls.Add(label2);
            Controls.Add(EmailTextBox);
            Controls.Add(label1);
            Name = "LoginUsuarioForm";
            Text = "Inicio de Sesión";
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
    }
}