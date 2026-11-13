using System;
using System.Windows.Forms;

namespace ProjetoFinal.Views.Conversas
{
    public partial class ConversaCtr : UserControl
    {
        public int ConversaId { get; private set; }
        public event EventHandler? OnVerClicked;
        public event EventHandler? OnApagarClicked;

        private Label lblNome;
        private Button btnVer;
        private Button btnApagar;

        public ConversaCtr(int conversaId, string titulo)
        {
            ConversaId = conversaId;
            InitializeComponent();
            lblNome.Text = titulo;
        }

        private void InitializeComponent()
        {
            lblNome = new Label { Location = new System.Drawing.Point(10, 15), AutoSize = true };
            btnVer = new Button { Text = "Ver", Location = new System.Drawing.Point(140, 10), Width = 60 };
            btnApagar = new Button { Text = "Apagar", Location = new System.Drawing.Point(210, 10), Width = 60 };

            btnVer.Click += (s, e) => OnVerClicked?.Invoke(this, EventArgs.Empty);
            btnApagar.Click += (s, e) => OnApagarClicked?.Invoke(this, EventArgs.Empty);

            Controls.Add(lblNome);
            Controls.Add(btnVer);
            Controls.Add(btnApagar);
            Size = new System.Drawing.Size(280, 45);
            BorderStyle = BorderStyle.FixedSingle;
        }
    }
}