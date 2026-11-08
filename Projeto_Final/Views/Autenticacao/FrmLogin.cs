using System;
using System.Windows.Forms;
using ProjetoFinal;
using ProjetoFinal.Presenters;
using ProjetoFinal.Views.Contatos;

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
                string codigo = txtCodigo.Text.Trim();//algo para dar push no git
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
                    var frmListar = new FrmListar();
                    frmListar.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}