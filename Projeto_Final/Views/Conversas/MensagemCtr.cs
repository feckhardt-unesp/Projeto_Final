using System;
using System.Windows.Forms;

namespace ProjetoFinal.Views.Conversas
{
    public partial class MensagemCtr : UserControl
    {
        private Label lblNome;
        private Label lblTexto;
        private Label lblDataHora;

        public MensagemCtr(string remetente, string texto, DateTime dataHora, bool ehUsuarioAtual)
        {
            InitializeComponent();

            lblNome.Text = ehUsuarioAtual ? "Você:" : remetente;
            lblTexto.Text = $"\"{texto}\"";
            lblDataHora.Text = $"{dataHora:dd/MM/yyyy HH:mm}";

            if (ehUsuarioAtual)
            {
                BackColor = System.Drawing.Color.LightCyan;
            }
        }

        private void InitializeComponent()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.Size = new System.Drawing.Size(335, 75);
            this.BorderStyle = BorderStyle.FixedSingle;

            lblNome = new Label
            {
                Location = new System.Drawing.Point(10, 6),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold)
            };

            lblTexto = new Label
            {
                Location = new System.Drawing.Point(10, 26),
                AutoSize = true,
                MaximumSize = new System.Drawing.Size(315, 0)
            };

            lblDataHora = new Label
            {
                Location = new System.Drawing.Point(10, 52),
                AutoSize = true,
                ForeColor = System.Drawing.Color.Gray
            };

            this.Controls.Add(lblNome);
            this.Controls.Add(lblTexto);
            this.Controls.Add(lblDataHora);
        }
    }
}