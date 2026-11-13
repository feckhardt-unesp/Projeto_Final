using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProjetoFinal.Views.Conversas.ContatoCtr;

namespace ProjetoFinal.Views.Conversas
{
    public partial class FrmCriar : Form
    {
        private TextBox txtNome;
        private Button btnAdicionarContato;
        private Button btnCriar;
        private FlowLayoutPanel panelContatos;
        private List<int> contatosSelecionadosIds = new List<int>();

        public FrmCriar()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Label lblNome = new Label { Text = "Nome:", Location = new System.Drawing.Point(10, 15), AutoSize = true };
            txtNome = new TextBox { Location = new System.Drawing.Point(60, 12), Width = 200 };
            btnAdicionarContato = new Button { Text = "Adicionar Contato", Location = new System.Drawing.Point(60, 45), Width = 140 };
            panelContatos = new FlowLayoutPanel { Location = new System.Drawing.Point(10, 80), Size = new System.Drawing.Size(260, 200), AutoScroll = true, FlowDirection = FlowDirection.TopDown, WrapContents = false };
            btnCriar = new Button { Text = "Criar", Location = new System.Drawing.Point(100, 290), Width = 80 };

            btnAdicionarContato.Click += BtnAdicionarContato_Click;
            btnCriar.Click += BtnCriar_Click;

            Controls.Add(lblNome);
            Controls.Add(txtNome);
            Controls.Add(btnAdicionarContato);
            Controls.Add(panelContatos);
            Controls.Add(btnCriar);

            Size = new System.Drawing.Size(300, 360);
            Text = "Conversas/FrmCriar";
        }

        private void BtnAdicionarContato_Click(object? sender, EventArgs e)
        {
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
            MessageBox.Show("Conversa criada com sucesso!");
            Close();
        }
    }
}