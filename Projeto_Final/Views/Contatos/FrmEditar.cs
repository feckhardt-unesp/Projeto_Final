using ProjetoFinal.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_Final.Views.Contatos
{
    public partial class FrmEditar : Form
    {
        private readonly ContatoPresenter _presenter;
        private readonly FrmListar _frmListar;
        private readonly int _contatoId;

        public FrmEditar(FrmListar frmListar, int contatoId, string nomeAtual)
        {
            InitializeComponent();
            _presenter = new ContatoPresenter();
            _frmListar = frmListar;
            _contatoId = contatoId;
            txtNovoApelido.Text = nomeAtual;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string novoApelido = txtNovoApelido.Text.Trim();
                _presenter.EditarContato(_contatoId, novoApelido);

                MessageBox.Show("Apelido atualizado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
