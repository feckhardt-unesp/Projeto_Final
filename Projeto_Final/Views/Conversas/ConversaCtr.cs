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
            this.AutoScaleMode = AutoScaleMode.None;
            this.Size = new System.Drawing.Size(272, 45);
            this.BorderStyle = BorderStyle.FixedSingle;

            lblNome = new Label
            {
                Location = new System.Drawing.Point(8, 14),
                AutoSize = true,
                MaximumSize = new System.Drawing.Size(125, 0),
                AutoEllipsis = true
            };

            btnVer = new Button
            {
                Text = "Ver",
                Location = new System.Drawing.Point(140, 10),
                Size = new System.Drawing.Size(58, 25)
            };

            btnApagar = new Button
            {
                Text = "Apagar",
                Location = new System.Drawing.Point(203, 10),
                Size = new System.Drawing.Size(60, 25)
            };

            btnVer.Click += (s, e) => OnVerClicked?.Invoke(this, EventArgs.Empty);
            btnApagar.Click += (s, e) => OnApagarClicked?.Invoke(this, EventArgs.Empty);

            this.Controls.Add(lblNome);
            this.Controls.Add(btnVer);
            this.Controls.Add(btnApagar);
        }
    }
}