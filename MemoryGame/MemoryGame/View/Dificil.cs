using MemoryGame.Controller;
using MemoryGame.Entidade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame.View
{
    public partial class Dificil : Form
    {
        private string tema;
        private int qtdeCartas;
        private bool off;
        private static int counter = 0;
        private Loading loadingScreen;
        private List<Carta> cartas;
        private ControlerGame controler;
        private bool iniciou;
        private int segundo;
        private int minuto;
        public Dificil(string tema, int qtdeCartas, bool off)
        {
            this.tema = tema;
            this.qtdeCartas = qtdeCartas;
            this.off = off;
            InitializeComponent();
            loadingScreen = new Loading();
            loadingScreen.Show();
            CarregarCartas();
            OcultarImagens();
            iniciou = false;
            segundo = 0;
            minuto = 0;
        }

        private async Task CarregarCartas()
        {
            await Task.Run(() =>
            {
                CartaUtil cartaUtil = new CartaUtil();
                cartas = cartaUtil.GetCartas(this.tema, this.qtdeCartas, this.off);
                if (cartas != null && cartas.Count == this.qtdeCartas)
                {
                    controler = new ControlerGame(cartas);
                    for (var x = 0; x < cartas.Count; x++)
                    {
                        PictureBox picture = (PictureBox)this.Controls.Find("pictureBox_" + (x + 1), false)[0];
                        Button button = (Button)this.Controls.Find("button_" + (x + 1), false)[0];
                        picture.Image = cartas[x].Imagem;
                        picture.Tag = cartas[x].Id;
                        picture.Refresh();
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;

                        button.Tag = cartas[x].Id;
                    }

                    if (loadingScreen.InvokeRequired)
                    {
                        loadingScreen.Invoke((MethodInvoker)delegate
                        {
                            loadingScreen.Close();
                            this.Show();
                        });

                    }
                    else
                    {
                        loadingScreen.Close();
                        this.Show();
                    }
                }
                else
                {
                    if (loadingScreen.InvokeRequired)
                    {
                        loadingScreen.Invoke((MethodInvoker)delegate
                        {
                            loadingScreen.Close();
                            ErroDownload erro = new ErroDownload();
                            erro.Show();
                        });
                    }
                    else
                    {
                        loadingScreen.Close();
                        ErroDownload erro = new ErroDownload();
                        erro.Show();
                    }

                }
            });
        }

        private void OcultarImagens()
        {
            Button botao;
            PictureBox picture;
            for (var x = 1; x <= this.qtdeCartas; x++)
            {
                botao = (Button)this.Controls.Find("button_" + x, false)[0];
                picture = (PictureBox)this.Controls.Find("pictureBox_" + x, false)[0];
                botao.Visible = true;
                picture.Visible = true;
                picture.Enabled = true;
            }
        }

        private void ClickBotao(object sender, EventArgs e)
        {

            if (!iniciou)
            {
                timer1.Enabled = true;
                iniciou = true;
            }

            Button botao = (Button)sender;

            botao.Visible = false;
            botao.Enabled = false;
            int id = (int)botao.Tag;
            int id1;

            PictureBox picture = (PictureBox)this.Controls.Find("pictureBox_" + FindIdByCarta(id), false)[0];
            picture.Visible = true;
            picture.Enabled = false;

            atualizarJogadas(controler.getJogadas());

            Refresh();
            if (!controler.selecionouImagem(Convert.ToInt32(id)))
            {

                id1 = controler.getResposta().Id;

                controler.pause();

                desabilitarCartas(id, id1);
            }

            vitoria();
        }

        private void vitoria()
        {

            if (controler.ganhou())
            {
                timer1.Stop();
                Ganhou ganhou = new Ganhou(Contador.Text, Tempo.Text);
                this.Close();
            }
        }
        private void desabilitarCartas(int img1, int img2)
        {
            Button botao1 = (Button)this.Controls.Find("button_" + FindIdByCarta(img1), false)[0];
            PictureBox picture1 = (PictureBox)this.Controls.Find("pictureBox_" + FindIdByCarta(img1), false)[0];
            Button botao2 = (Button)this.Controls.Find("button_" + FindIdByCarta(img2), false)[0];
            PictureBox picture2 = (PictureBox)this.Controls.Find("pictureBox_" + FindIdByCarta(img2), false)[0];

            botao1.Visible = true;
            botao1.Enabled = true;
            picture1.Visible = false;
            picture1.Enabled = true;

            botao2.Visible = true;
            botao2.Enabled = true;
            picture2.Visible = false;
            picture1.Enabled = true;

            Refresh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void atualizarJogadas(int valor)
        {
            Label variavel = (Label)this.Controls.Find("Contador", false)[0];
            variavel.Text = Convert.ToString(valor);
        }

        private void pictureBoxClick(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;

            picture.Visible = false;

            var id = picture.Name.Split('_')[1];

            Button botao = (Button)this.Controls.Find("button_" + id, false)[0];
            botao.Visible = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            segundo += 1;

            String tempoMin = "" + minuto;
            String tempoSeg = "" + segundo;

            if (segundo < 10)
            {
                tempoSeg = "0" + segundo;
            }
            else if (segundo == 60)
            {
                tempoSeg = "00";
                segundo = 0;
                minuto += 1;
            }

            if (minuto < 10)
            {
                tempoMin = "0" + minuto;
            }

            Tempo.Text = tempoMin + ":" + tempoSeg;
        }

        private int FindIdByCarta(int idCarta)
        {
            int retorno = 0;
            foreach (Control c in Controls)
            {
                if (c.Tag != null)
                {
                    if ((int)c.Tag == idCarta)
                    {
                        retorno = Int32.Parse(c.Name.Split('_')[1]);
                    }
                }
            }

            return retorno;
        }
    }
}
