using System.DirectoryServices.ActiveDirectory;

namespace JogoDaVelha
{
    public partial class frmJogoDaVelha : Form
    {
        public frmJogoDaVelha()
        {
            InitializeComponent();
            pnlTelaInicial.BringToFront();
        }

        private void BotaoGrid_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            pnlTelaInicial.Visible = false;
        }
    }
}
