using System.DirectoryServices.ActiveDirectory;
using System.Media;

namespace JogoDaVelha
{
    public partial class frmJogoDaVelha : Form
    {
        private bool _vezDoX = true;
        private int _jogadas = 0;
        private SoundPlayer _somClique = new SoundPlayer("escrita.wav");
        private SoundPlayer _somVitoria = new SoundPlayer("receba.wav");

        private void somLogica()
        {

            if (_vezDoX)
            {
                _somClique = new SoundPlayer("escrita.wav");
            }
            else
            {
                _somClique = new SoundPlayer("escrita2.wav");
            };
        }

        public frmJogoDaVelha()
        {
            InitializeComponent();
            pnlTelaInicial.BringToFront();
            _somClique.Load();
            _somVitoria.Load();
        }

        private void BotaoGrid_Click(object sender, EventArgs e)
        {
            Button botaoClicado = (Button)sender;

            if (botaoClicado.Text != "") return;
            botaoClicado.Text = _vezDoX ? "X" : "O";
            _jogadas++;

            if (VerificarVencedor())
            {
                string vencedor = _vezDoX ? "X" : "O";
                lblTituloFinal.Text = $"O Jogador {vencedor} venceu!";
                lblReceba.Text = "RECEBA!";
                ZerarTabuleiro();

                pnlTelaFinal.BringToFront();
                pnlTelaFinal.Visible = true;
                _somVitoria.Play();


            }
            else if (_jogadas == 9)
            {
                pnlTelaFinal.Visible = Enabled;
                lblTituloFinal.Text = "Deu velha! O jogo empatou";
                lblReceba.Text = "RECEBA...?";

                ZerarTabuleiro();
                pnlTelaFinal.BringToFront();
                pnlTelaFinal.Visible = true;
            }
            else
            {
                _vezDoX = !_vezDoX;
                lblVez.Text = $"Vez do jogador: {(_vezDoX ? "X" : "O")}";
                somLogica();
                _somClique.Play();
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            pnlTelaFinal.Visible = false;
            pnlTelaInicial.Visible = true;
        }
    }
}
