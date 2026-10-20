namespace ProjetoFinal.Views.Autenticacao
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblCodigo = new Label();
            txtCodigo = new TextBox();
            lblPIN = new Label();
            txtPIN = new TextBox();
            btEntrar = new Button();
            SuspendLayout();
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCodigo.Location = new Point(30, 25);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(54, 17);
            lblCodigo.TabIndex = 0;
            lblCodigo.Text = "Código:";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(30, 45);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(200, 23);
            txtCodigo.TabIndex = 1;
            // 
            // lblPIN
            // 
            lblPIN.AutoSize = true;
            lblPIN.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPIN.Location = new Point(30, 80);
            lblPIN.Name = "lblPIN";
            lblPIN.Size = new Size(33, 17);
            lblPIN.TabIndex = 2;
            lblPIN.Text = "PIN:";
            // 
            // txtPIN
            // 
            txtPIN.Location = new Point(30, 100);
            txtPIN.Name = "txtPIN";
            txtPIN.PasswordChar = '*';
            txtPIN.Size = new Size(200, 23);
            txtPIN.TabIndex = 3;
            // 
            // btEntrar
            // 
            btEntrar.BackColor = Color.YellowGreen;
            btEntrar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btEntrar.Location = new Point(30, 140);
            btEntrar.Name = "btEntrar";
            btEntrar.Size = new Size(200, 35);
            btEntrar.TabIndex = 4;
            btEntrar.Text = "ENTRAR";
            btEntrar.UseVisualStyleBackColor = false;
            btEntrar.Click += btEntrar_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(260, 200);
            Controls.Add(btEntrar);
            Controls.Add(txtPIN);
            Controls.Add(lblPIN);
            Controls.Add(txtCodigo);
            Controls.Add(lblCodigo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - C#at";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCodigo;
        private TextBox txtCodigo;
        private Label lblPIN;
        private TextBox txtPIN;
        private Button btEntrar;
    }
}