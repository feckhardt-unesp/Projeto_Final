using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ProjetoFinal.Presenters;

namespace ProjetoFinal.Views.Conversas
{
    public partial class FrmConversa : Form
    {
        private readonly ConversaPresenter _presenter;
        private int conversaId;
        private int usuarioConversaId;
        private bool usuarioSaiu = false;
        private int ultimaQuantidadeMensagens = -1;
        private Dictionary<int, string> _apelidosContatos = new Dictionary<int, string>();

        private FlowLayoutPanel panelMensagens;
        private TextBox txtMensagem;
        private Button btnEnviar;
        private Button btnSair;
        private System.Windows.Forms.Timer timerMensagens;

        public FrmConversa(int conversaId, string tituloConversa, int usuarioConversaId)
        {
            this.conversaId = conversaId;
            this.usuarioConversaId = usuarioConversaId;
            _presenter = new ConversaPresenter();

            InitializeComponent();
            Text = tituloConversa;
            StartPosition = FormStartPosition.CenterParent;

            CarregarApelidos();
            InicializarTimer();
            CarregarMensagens();
        }

        private void CarregarApelidos()
        {
            try
            {
                var contatoPresenter = new ContatoPresenter();
                var contatos = contatoPresenter.ObterContatosDoUsuarioAtual();
                _apelidosContatos = contatos.ToDictionary(c => c.ContatoId, c => c.Nome);
            }
            catch { }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.AutoScaleMode = AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(385, 425);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            btnSair = new Button
            {
                Text = "Sair",
                Location = new System.Drawing.Point(310, 10),
                Size = new System.Drawing.Size(65, 28)
            };

            panelMensagens = new FlowLayoutPanel
            {
                Location = new System.Drawing.Point(10, 45),
                Size = new System.Drawing.Size(365, 330),
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BorderStyle = BorderStyle.FixedSingle
            };

            txtMensagem = new TextBox
            {
                Location = new System.Drawing.Point(10, 388),
                Size = new System.Drawing.Size(280, 25)
            };

            btnEnviar = new Button
            {
                Text = "Enviar",
                Location = new System.Drawing.Point(300, 386),
                Size = new System.Drawing.Size(75, 28)
            };

            btnSair.Click += BtnSair_Click;
            btnEnviar.Click += BtnEnviar_Click;

            this.Controls.Add(btnSair);
            this.Controls.Add(panelMensagens);
            this.Controls.Add(txtMensagem);
            this.Controls.Add(btnEnviar);

            this.ResumeLayout(false);
        }

        private void InicializarTimer()
        {
            timerMensagens = new System.Windows.Forms.Timer();
            timerMensagens.Interval = 1000;
            timerMensagens.Tick += (s, e) => CarregarMensagens();
            timerMensagens.Start();
        }

        private void CarregarMensagens()
        {
            try
            {
                var mensagens = _presenter.ObterMensagens(conversaId);
                if (mensagens.Count == ultimaQuantidadeMensagens) return;

                ultimaQuantidadeMensagens = mensagens.Count;
                panelMensagens.Controls.Clear();

                int meuId = Session.UsuarioAtual?.Id ?? 0;

                foreach (var msg in mensagens)
                {
                    int remetenteId = msg.UsuarioConversa?.UsuarioId ?? 0;
                    bool souEu = remetenteId == meuId;

                    string nomeExibicao = _apelidosContatos.ContainsKey(remetenteId)
                        ? _apelidosContatos[remetenteId]
                        : (msg.UsuarioConversa?.Usuario?.Codigo ?? "Desconhecido");

                    var ctr = new MensagemCtr(nomeExibicao, msg.Texto, msg.DataHora.ToLocalTime(), souEu);
                    panelMensagens.Controls.Add(ctr);
                }

                if (panelMensagens.Controls.Count > 0)
                {
                    panelMensagens.ScrollControlIntoView(panelMensagens.Controls[panelMensagens.Controls.Count - 1]);
                }
            }
            catch { }
        }

        private void BtnEnviar_Click(object? sender, EventArgs e)
        {
            if (usuarioSaiu)
            {
                MessageBox.Show("Você saiu desta conversa e não pode mais enviar mensagens.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMensagem.Text)) return;

            try
            {
                _presenter.EnviarMensagem(usuarioConversaId, txtMensagem.Text);
                txtMensagem.Clear();
                CarregarMensagens();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao enviar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSair_Click(object? sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja realmente sair da conversa?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    _presenter.SairDaConversa(usuarioConversaId);
                    usuarioSaiu = true;
                    txtMensagem.Enabled = false;
                    btnEnviar.Enabled = false;
                    MessageBox.Show("Você saiu da conversa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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