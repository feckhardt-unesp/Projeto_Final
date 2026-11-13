using System;
using System.Windows.Forms;

namespace ProjetoFinal.Views.Conversas
{
    public partial class ContatoCtr : UserControl
    {
        public int ContatoId { get; private set; }
        public event EventHandler? OnApagarClicked;

        private Label lblNome;
        private Button btnApagar;

        public ContatoCtr(int contatoId, string nome)
        {
            ContatoId = contatoId;
            InitializeComponent();
            lblNome.Text = nome;
        }

        private void InitializeComponent()
        {
            lblNome = new Label { Location = new System.Drawing.Point(10, 12), AutoSize = true };
            btnApagar = new Button { Text = "Apagar", Location = new System.Drawing.Point(180, 8), Width = 60 };

            btnApagar.Click += (s, e) => OnApagarClicked?.Invoke(this, EventArgs.Empty);

            Controls.Add(lblNome);
            Controls.Add(btnApagar);
            Size = new System.Drawing.Size(250, 40);
            BorderStyle = BorderStyle.FixedSingle;
        }
    }
}