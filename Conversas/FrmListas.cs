using System;
using System.Windows.Forms;

namespace ProjetoFinal.Views.Conversas
{
    public partial class FrmListas : Form
    {
        private System.Windows.Forms.Timer timerAtualizacao;
        private FlowLayoutPanel panelConversas;
        private Button btnContatos;
        private Button btnNovaConversa;

        public FrmListas()
        {
            InitializeComponent();
            InicializarTimer();
            CarregarConversas();
        }

        private void InitializeComponent()
        {
            btnContatos = new Button { Text = "Contatos", Location = new System.Drawing.Point(10, 10), Width = 100 };
            btnNovaConversa = new Button { Text = "Nova Conversa", Location = new System.Drawing.Point(200, 10), Width = 110 };
            panelConversas = new FlowLayoutPanel { Location = new System.Drawing.Point(10, 50), Size = new System.Drawing.Size(300, 380), AutoScroll = true, FlowDirection = FlowDirection.TopDown, WrapContents = false };

            btnContatos.Click += BtnContatos_Click;
            btnNovaConversa.Click += BtnNovaConversa_Click;

            Controls.Add(btnContatos);
            Controls.Add(btnNovaConversa);
            Controls.Add(panelConversas);

            Size = new System.Drawing.Size(340, 480);
            Text = "Conversas/FrmListas";
        }

        private void InicializarTimer()
        {
            timerAtualizacao = new System.Windows.Forms.Timer();
            timerAtualizacao.Interval = 30000; // Timer de 30 segundos
            timerAtualizacao.Tick += (s, e) => CarregarConversas();
            timerAtualizacao.Start();
        }

        public void CarregarConversas()
        {
            panelConversas.Controls.Clear();
        }

        private void BtnContatos_Click(object? sender, EventArgs e)
        {
        }

        private void BtnNovaConversa_Click(object? sender, EventArgs e)
        {
            var frmCriar = new FrmCriar();
            frmCriar.ShowDialog();
            CarregarConversas();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timerAtualizacao.Stop();
            timerAtualizacao.Dispose();
            base.OnFormClosing(e);
        }
    }
}