using System.DirectoryServices.ActiveDirectory;
using System.Media;

namespace JogoDaVelha
{
    public partial class frmJogoDaVelha : Form
    {
        private bool _vezDoX = true;
        private int _jogadas = 0;
        private SoundPlayer _somClique = new SoundPlayer("escrita.wav");

        public frmJogoDaVelha()
        {
            InitializeComponent();
            pnlTelaInicial.BringToFront();
            _somClique.Load();
        }

        private void BotaoGrid_Click(object sender, EventArgs e)
        {
            Button botaoClicado = (Button)sender;

            if (botaoClicado.Text != "") return;
            botaoClicado.Text = _vezDoX ? "X" : "O";
            _jogadas++;
            _somClique.Play();

            if (VerificarVencedor())
            {
                string vencedor = _vezDoX ? "X" : "O";
                MessageBox.Show($"Jogador {vencedor} venceu!", "Temos um Vencedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ZerarTabuleiro();
                pnlTelaInicial.Visible = true;

            }
            else if (_jogadas == 9)
            {
                MessageBox.Show("Deu velha! O jogo empatou", "Empate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ZerarTabuleiro();
                pnlTelaInicial.Visible = true;
            }
            else
            {
                _vezDoX = !_vezDoX;
                lblVez.Text = $"Vez do jogador: {(_vezDoX ? "X" : "O")}";
            }
            
        }

        private bool VerificarVencedor()
        {
            if (ChecarTrinca(btn1, btn2, btn3)) return true;
            if (ChecarTrinca(btn4, btn5, btn6)) return true;
            if (ChecarTrinca(btn7, btn8, btn9)) return true;

            if (ChecarTrinca(btn1, btn4, btn7)) return true;
            if (ChecarTrinca(btn2, btn5, btn8)) return true;
            if (ChecarTrinca(btn3, btn6, btn9)) return true;

            if (ChecarTrinca(btn1, btn5, btn9)) return true;
            if (ChecarTrinca(btn3, btn5, btn7)) return true;
            return false;
        }

        private bool ChecarTrinca(Button b1, Button b2, Button b3)
        {
            if (b1.Text == "") return false;
            return (b1.Text == b2.Text && b2.Text == b3.Text);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            pnlTelaInicial.Visible = false;
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            ZerarTabuleiro();
        }

        private void ZerarTabuleiro()
        {
            btn1.Text = ""; btn2.Text = ""; btn3.Text = "";
            btn4.Text = ""; btn5.Text = ""; btn6.Text = "";
            btn7.Text = ""; btn8.Text = ""; btn9.Text = "";
            _vezDoX = true;
            _jogadas = 0;
            lblVez.Text = "Vez do jogador: X";
        }
    }
}
