namespace ProjetoFinal.Views.Contatos
{
    partial class FrmEditar
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
            btnSalvar = new Button();
            lblNovoApelido = new Label();
            txtNovoApelido = new TextBox();
            SuspendLayout();
            // 
            // btnSalvar
            // 
            btnSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSalvar.BackColor = Color.YellowGreen;
            btnSalvar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalvar.Location = new Point(99, 147);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(96, 37);
            btnSalvar.TabIndex = 5;
            btnSalvar.Text = "SALVAR";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // lblNovoApelido
            // 
            lblNovoApelido.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblNovoApelido.AutoSize = true;
            lblNovoApelido.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNovoApelido.Location = new Point(12, 31);
            lblNovoApelido.Name = "lblNovoApelido";
            lblNovoApelido.Size = new Size(216, 25);
            lblNovoApelido.TabIndex = 6;
            lblNovoApelido.Text = "Novo nome do contato:";
            // 
            // txtNovoApelido
            // 
            txtNovoApelido.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtNovoApelido.Location = new Point(12, 73);
            txtNovoApelido.Name = "txtNovoApelido";
            txtNovoApelido.Size = new Size(253, 23);
            txtNovoApelido.TabIndex = 7;
            // 
            // FrmEditar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(289, 196);
            Controls.Add(txtNovoApelido);
            Controls.Add(lblNovoApelido);
            Controls.Add(btnSalvar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FrmEditar";
            Text = "Editar Contato";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSalvar;
        private Label lblNovoApelido;
        private TextBox txtNovoApelido;
    }
}