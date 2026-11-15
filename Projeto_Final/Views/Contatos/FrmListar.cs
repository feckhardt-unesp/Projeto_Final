using System;
using System.Linq;
using System.Windows.Forms;
using ProjetoFinal.Presenters;

namespace ProjetoFinal.Views.Contatos
{
    public partial class FrmListar : Form
    {
        private readonly ContatoPresenter _presenter;

        public FrmListar()
        {
            InitializeComponent();
            _presenter = new ContatoPresenter();
            CarregarContatos();
        }

        private void FrmListar_Load(object sender, EventArgs e)
        {
            CarregarContatos();
        }

        public void CarregarContatos(string filtro = "")
        {
            try
            {
                var lista = _presenter.ObterContatosDoUsuarioAtual(filtro);

                dgvContatos.DataSource = lista.Select(c => new
                {
                    ID = c.Id,
                    Nome = c.Nome,
                    Codigo = c.UsuarioContato?.Codigo
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar contatos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btFiltrar_Click(object sender, EventArgs e)
        {
            CarregarContatos(txtNome.Text.Trim());
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            var frm = new FrmCadastrar(this);
            frm.ShowDialog();
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            if (dgvContatos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um contato para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idContato = Convert.ToInt32(dgvContatos.SelectedRows[0].Cells["ID"].Value);
            string nomeAtual = dgvContatos.SelectedRows[0].Cells["Nome"].Value?.ToString() ?? "";

            var frm = new FrmEditar(this, idContato, nomeAtual);
            frm.ShowDialog();
        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            if (dgvContatos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um contato para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idContato = Convert.ToInt32(dgvContatos.SelectedRows[0].Cells["ID"].Value);
            string nome = dgvContatos.SelectedRows[0].Cells["Nome"].Value?.ToString() ?? "";

            var confirm = MessageBox.Show($"Deseja realmente remover '{nome}' dos seus contatos?", "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _presenter.ExcluirContato(idContato);
                    CarregarContatos();
                    MessageBox.Show("Contato removido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}