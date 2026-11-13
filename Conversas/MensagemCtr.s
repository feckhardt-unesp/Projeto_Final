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
            lblNome = new Label { Location = new System.Drawing.Point(10, 5), AutoSize = true, Font = new System.Drawing.Font(Font, System.Drawing.FontStyle.Bold) };
            lblTexto = new Label { Location = new System.Drawing.Point(10, 25), AutoSize = true };
            lblDataHora = new Label { Location = new System.Drawing.Point(10, 50), AutoSize = true, ForeColor = System.Drawing.Color.Gray };

            Controls.Add(lblNome);
            Controls.Add(lblTexto);
            Controls.Add(lblDataHora);
            Size = new System.Drawing.Size(350, 75);
            BorderStyle = BorderStyle.FixedSingle;
        }
    }
}