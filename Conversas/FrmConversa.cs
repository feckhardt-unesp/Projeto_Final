using System;
using System.Windows.Forms;

namespace ProjetoFinal.Views.Conversas
{
    public partial class FrmConversa : Form
    {
        private int conversaId;
        private int usuarioConversaId;
        private bool usuarioSaiu = false;

        private FlowLayoutPanel panelMensagens;
        private TextBox txtMensagem;
        private Button btnEnviar;
        private Button btnSair;
        private System.Windows.Forms.Timer timerMensagens;

        public FrmConversa(int conversaId, string tituloConversa, int usuarioConversaId)
        {
            this.conversaId = conversaId;
            this.usuarioConversaId = usuarioConversaId;
            InitializeComponent();
            Text = tituloConversa;
            
            InicializarTimer();
            CarregarMensagens();
        }

        private void InitializeComponent()
        {
            btnSair = new Button { Text = "Sair", Location = new System.Drawing.Point(300, 10), Width = 60 };
            panelMensagens = new FlowLayoutPanel { Location = new System.Drawing.Point(10, 45), Size = new System.Drawing.Size(360, 320), AutoScroll = true, FlowDirection = FlowDirection.TopDown, WrapContents = false };
            txtMensagem = new TextBox { Location = new System.Drawing.Point(10, 380), Width = 270 };
            btnEnviar = new Button { Text = "Enviar", Location = new System.Drawing.Point(290, 378), Width = 70 };

            btnSair.Click += BtnSair_Click;
            btnEnviar.Click += BtnEnviar_Click;

            Controls.Add(btnSair);
            Controls.Add(panelMensagens);
            Controls.Add(txtMensagem);
            Controls.Add(btnEnviar);

            Size = new System.Drawing.Size(400, 460);
        }

        private void InicializarTimer()
        {
            timerMensagens = new System.Windows.Forms.Timer();
            timerMensagens.Interval = 1000; // Timer de 1 segundo
            timerMensagens.Tick += (s, e) => CarregarMensagens();
            timerMensagens.Start();
        }

        private void CarregarMensagens()
        {
        }

        private void BtnEnviar_Click(object? sender, EventArgs e)
        {
            if (usuarioSaiu)
            {
                MessageBox.Show("Você saiu desta conversa e não pode mais enviar mensagens.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMensagem.Text)) return;

            txtMensagem.Clear();
            CarregarMensagens();
        }

        private void BtnSair_Click(object? sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja realmente sair da conversa?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                usuarioSaiu = true;
                txtMensagem.Enabled = false;
                btnEnviar.Enabled = false;
                MessageBox.Show("Você saiu da conversa.");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timerMensagens.Stop();
            timerMensagens.Dispose();
            base.OnFormClosing(e);
        }
    }
}