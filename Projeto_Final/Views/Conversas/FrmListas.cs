using System;
using System.Windows.Forms;
using ProjetoFinal.Presenters;
using ProjetoFinal.Views.Contatos;

namespace ProjetoFinal.Views.Conversas
{
    public partial class FrmListas : Form
    {
        private readonly ConversaPresenter _presenter;
        private System.Windows.Forms.Timer timerAtualizacao;
        private FlowLayoutPanel panelConversas;
        private Button btnContatos;
        private Button btnNovaConversa;

        public FrmListas()
        {
            InitializeComponent();
            _presenter = new ConversaPresenter();
            InicializarTimer();
            CarregarConversas();

            this.FormClosed += (s, e) => Application.Exit();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.AutoScaleMode = AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(320, 460);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Minhas Conversas";
            this.StartPosition = FormStartPosition.CenterScreen;

            btnContatos = new Button
            {
                Text = "Contatos",
                Location = new System.Drawing.Point(10, 12),
                Size = new System.Drawing.Size(100, 30)
            };

            btnNovaConversa = new Button
            {
                Text = "Nova Conversa",
                Location = new System.Drawing.Point(190, 12),
                Size = new System.Drawing.Size(120, 30)
            };

            panelConversas = new FlowLayoutPanel
            {
                Location = new System.Drawing.Point(10, 52),
                Size = new System.Drawing.Size(300, 395),
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BorderStyle = BorderStyle.FixedSingle
            };

            btnContatos.Click += BtnContatos_Click;
            btnNovaConversa.Click += BtnNovaConversa_Click;

            this.Controls.Add(btnContatos);
            this.Controls.Add(btnNovaConversa);
            this.Controls.Add(panelConversas);

            this.ResumeLayout(false);
        }

        private void InicializarTimer()
        {
            timerAtualizacao = new System.Windows.Forms.Timer();
            timerAtualizacao.Interval = 30000;
            timerAtualizacao.Tick += (s, e) => CarregarConversas();
            timerAtualizacao.Start();
        }

        public void CarregarConversas()
        {
            try
            {
                panelConversas.Controls.Clear();
                var conversas = _presenter.ObterConversasDoUsuarioAtual();

                foreach (var uc in conversas)
                {
                    string titulo = uc.Conversa?.Titulo ?? "Conversa";
                    var ctr = new ConversaCtr(uc.ConversaId, titulo);

                    ctr.OnVerClicked += (s, e) =>
                    {
                        var frm = new FrmConversa(uc.ConversaId, titulo, uc.Id);
                        frm.ShowDialog();
                        CarregarConversas();
                    };

                    ctr.OnApagarClicked += (s, e) =>
                    {
                        var resp = MessageBox.Show($"Deseja sair da conversa '{titulo}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resp == DialogResult.Yes)
                        {
                            _presenter.SairDaConversa(uc.Id);
                            CarregarConversas();
                        }
                    };

                    panelConversas.Controls.Add(ctr);
                }
            }
            catch (Exception ex)
            {
                timerAtualizacao.Stop();
                MessageBox.Show(ex.Message, "Erro ao carregar conversas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnContatos_Click(object? sender, EventArgs e)
        {
            var frmContatos = new FrmListar();
            frmContatos.ShowDialog();
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