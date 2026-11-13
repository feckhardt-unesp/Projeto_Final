namespace ProjetoFinal.Views.Contatos
{
    partial class FrmListar
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
            btFiltrar = new Button();
            txtNome = new TextBox();
            dgvContatos = new DataGridView();
            btAdicionar = new Button();
            btEditar = new Button();
            btRemover = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvContatos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(70, 25);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            // 
            // btFiltrar
            // 
            btFiltrar.BackColor = SystemColors.ActiveCaption;
            btFiltrar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btFiltrar.Location = new Point(394, 20);
            btFiltrar.Name = "btFiltrar";
            btFiltrar.Size = new Size(84, 27);
            btFiltrar.TabIndex = 1;
            btFiltrar.Text = "FILTRAR";
            btFiltrar.UseVisualStyleBackColor = false;
            btFiltrar.Click += btFiltrar_Click;
            // 
            // txtNome
            // 
            txtNome.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNome.Location = new Point(88, 20);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(300, 23);
            txtNome.TabIndex = 2;
            // 
            // dgvContatos
            // 
            dgvContatos.AllowUserToAddRows = false;
            dgvContatos.AllowUserToDeleteRows = false;
            dgvContatos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvContatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvContatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContatos.Location = new Point(12, 64);
            dgvContatos.MultiSelect = false;
            dgvContatos.Name = "dgvContatos";
            dgvContatos.ReadOnly = true;
            dgvContatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvContatos.Size = new Size(466, 164);
            dgvContatos.TabIndex = 0;
            // 
            // btAdicionar
            // 
            btAdicionar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btAdicionar.BackColor = Color.YellowGreen;
            btAdicionar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btAdicionar.Location = new Point(12, 245);
            btAdicionar.Name = "btAdicionar";
            btAdicionar.Size = new Size(103, 27);
            btAdicionar.TabIndex = 4;
            btAdicionar.Text = "ADICIONAR";
            btAdicionar.UseVisualStyleBackColor = false;
            btAdicionar.Click += btAdicionar_Click;
            // 
            // btEditar
            // 
            btEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btEditar.BackColor = Color.Yellow;
            btEditar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btEditar.Location = new Point(203, 245);
            btEditar.Name = "btEditar";
            btEditar.Size = new Size(84, 27);
            btEditar.TabIndex = 5;
            btEditar.Text = "EDITAR";
            btEditar.UseVisualStyleBackColor = false;
            btEditar.Click += btEditar_Click;
            // 
            // btRemover
            // 
            btRemover.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btRemover.BackColor = Color.Firebrick;
            btRemover.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btRemover.Location = new Point(385, 245);
            btRemover.Name = "btRemover";
            btRemover.Size = new Size(93, 27);
            btRemover.TabIndex = 6;
            btRemover.Text = "REMOVER";
            btRemover.UseVisualStyleBackColor = false;
            btRemover.Click += btRemover_Click;
            // 
            // FrmListar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 284);
            Controls.Add(btRemover);
            Controls.Add(btEditar);
            Controls.Add(btAdicionar);
            Controls.Add(dgvContatos);
            Controls.Add(txtNome);
            Controls.Add(btFiltrar);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmListar";
            Text = "Lista dos Contatos";
            ((System.ComponentModel.ISupportInitialize)dgvContatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btFiltrar;
        private TextBox txtNome;
        private DataGridView dgvContatos;
        private Button btAdicionar;
        private Button btEditar;
        private Button btRemover;
    }
}