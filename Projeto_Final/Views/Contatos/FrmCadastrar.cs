using System;
using System.Windows.Forms;
using ProjetoFinal.Presenters;

namespace ProjetoFinal.Views.Contatos
{
    public partial class FrmCadastrar : Form
    {
        private readonly ContatoPresenter _presenter;
        private readonly FrmListar _frmListar;

        public FrmCadastrar(FrmListar frmListar)
        {
            InitializeComponent();
            _presenter = new ContatoPresenter();
            _frmListar = frmListar;
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = txtCodigo.Text.Trim();
                string apelido = txtApelido.Text.Trim();

                _presenter.AdicionarContato(codigo, apelido);
                MessageBox.Show("Contato adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _frmListar.CarregarContatos();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}