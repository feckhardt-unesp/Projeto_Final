namespace ProjetoFinal.Views.Contatos
{
    partial class FrmCadastrar
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
            lblCodigo = new Label();
            lblApelido = new Label();
            txtCodigo = new TextBox();
            txtApelido = new TextBox();
            btSalvar = new Button();
            SuspendLayout();
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCodigo.Location = new Point(12, 9);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(175, 25);
            lblCodigo.TabIndex = 0;
            lblCodigo.Text = "Código do Usuário:";
            // 
            // lblApelido
            // 
            lblApelido.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblApelido.AutoSize = true;
            lblApelido.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblApelido.Location = new Point(12, 100);
            lblApelido.Name = "lblApelido";
            lblApelido.Size = new Size(171, 25);
            lblApelido.TabIndex = 2;
            lblApelido.Text = "Nome do Contato:";
            // 
            // txtCodigo
            // 
            txtCodigo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCodigo.Location = new Point(12, 51);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(242, 23);
            txtCodigo.TabIndex = 1;
            // 
            // txtApelido
            // 
            txtApelido.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtApelido.Location = new Point(12, 146);
            txtApelido.Name = "txtApelido";
            txtApelido.Size = new Size(242, 23);
            txtApelido.TabIndex = 3;
            // 
            // btSalvar
            // 
            btSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btSalvar.BackColor = Color.YellowGreen;
            btSalvar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btSalvar.Location = new Point(74, 222);
            btSalvar.Name = "btSalvar";
            btSalvar.Size = new Size(113, 37);
            btSalvar.TabIndex = 4;
            btSalvar.Text = "SALVAR";
            btSalvar.UseVisualStyleBackColor = false;
            btSalvar.Click += btSalvar_Click;
            // 
            // FrmCadastrar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(279, 271);
            Controls.Add(btSalvar);
            Controls.Add(txtApelido);
            Controls.Add(txtCodigo);
            Controls.Add(lblApelido);
            Controls.Add(lblCodigo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmCadastrar";
            Text = "Cadastrar Contato";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCodigo;
        private Label lblApelido;
        private TextBox txtCodigo;
        private TextBox txtApelido;
        private Button btSalvar;
    }
}