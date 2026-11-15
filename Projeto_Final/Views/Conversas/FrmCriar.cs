using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ProjetoFinal.Presenters;

namespace ProjetoFinal.Views.Conversas
{
    public partial class FrmCriar : Form
    {
        private readonly ConversaPresenter _conversaPresenter;
        private readonly ContatoPresenter _contatoPresenter;

        private TextBox txtNome;
        private ComboBox cmbContatos;
        private Button btnAdicionarContato;
        private Button btnCriar;
        private FlowLayoutPanel panelContatos;
        private Label lblNome;
        private List<int> contatosSelecionadosIds = new List<int>();

        public FrmCriar()
        {
            InitializeComponent();
            _conversaPresenter = new ConversaPresenter();
            _contatoPresenter = new ContatoPresenter();
            CarregarComboContatos();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.AutoScaleMode = AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(300, 340);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Nova Conversa";
            this.StartPosition = FormStartPosition.CenterParent;

            Label lblNome = new Label
            {
                Text = "Título:",
                Location = new System.Drawing.Point(10, 15),
                AutoSize = true
            };

            txtNome = new TextBox
            {
                Location = new System.Drawing.Point(60, 12),
                Size = new System.Drawing.Size(228, 25)
            };

            cmbContatos = new ComboBox
            {
                Location = new System.Drawing.Point(10, 48),
                Size = new System.Drawing.Size(185, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            btnAdicionarContato = new Button
            {
                Text = "Adicionar",
                Location = new System.Drawing.Point(203, 47),
                Size = new System.Drawing.Size(85, 26)
            };

            panelContatos = new FlowLayoutPanel
            {
                Location = new System.Drawing.Point(10, 85),
                Size = new System.Drawing.Size(278, 200),
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BorderStyle = BorderStyle.FixedSingle
            };

            btnCriar = new Button
            {
                Text = "Criar",
                Location = new System.Drawing.Point(105, 298),
                Size = new System.Drawing.Size(90, 30)
            };

            btnAdicionarContato.Click += BtnAdicionarContato_Click;
            btnCriar.Click += BtnCriar_Click;

            this.Controls.Add(lblNome);
            this.Controls.Add(txtNome);
            this.Controls.Add(cmbContatos);
            this.Controls.Add(btnAdicionarContato);
            this.Controls.Add(panelContatos);
            this.Controls.Add(btnCriar);

            this.ResumeLayout(false);
        }

        private void CarregarComboContatos()
        {
            try
            {
                var contatos = _contatoPresenter.ObterContatosDoUsuarioAtual();
                cmbContatos.DataSource = contatos.Select(c => new
                {
                    c.Id,
                    Exibicao = $"{c.Nome} ({c.UsuarioContato?.Codigo})"
                }).ToList();
                cmbContatos.DisplayMember = "Exibicao";
                cmbContatos.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdicionarContato_Click(object? sender, EventArgs e)
        {
            if (cmbContatos.SelectedValue == null) return;

            int contatoId = Convert.ToInt32(cmbContatos.SelectedValue);
            string nomeContato = cmbContatos.Text;
            AdicionarContatoLista(contatoId, nomeContato);
        }

        public void AdicionarContatoLista(int contatoId, string nomeContato)
        {
            if (contatosSelecionadosIds.Contains(contatoId)) return;

            contatosSelecionadosIds.Add(contatoId);
            var ctr = new ContatoCtr(contatoId, nomeContato);
            ctr.OnApagarClicked += (s, e) =>
            {
                panelContatos.Controls.Remove(ctr);
                contatosSelecionadosIds.Remove(contatoId);
            };
            panelContatos.Controls.Add(ctr);
        }

        private void BtnCriar_Click(object? sender, EventArgs e)
        {
            try
            {
                _conversaPresenter.CriarConversa(txtNome.Text, contatosSelecionadosIds);
                MessageBox.Show("Conversa criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}