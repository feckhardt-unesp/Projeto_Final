using System;
using System.Windows.Forms;
using ProjetoFinal;
using ProjetoFinal.Presenters;

namespace ProjetoFinal.Views.Autenticacao
{
    public partial class FrmLogin : Form
    {
        private readonly LoginPresenter _presenter;

        public FrmLogin()
        {
            InitializeComponent();
            _presenter = new LoginPresenter();
        }

        private void btEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = txtCodigo.Text.Trim();//algo para dar pusha
                string pin = txtPIN.Text.Trim();

                bool comSucesso = _presenter.AuthenticateOrRegister(codigo, pin, () =>
                {
                    var result = MessageBox.Show(
                        "O código informado não existe. Deseja criar um novo utilizador com este PIN?",
                        "Criar Utilizador",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    return result == DialogResult.Yes;
                });

                if (comSucesso)
                {
                    MessageBox.Show($"Bem-vindo! Logado como ID: {Session.UsuarioAtual?.Id}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}