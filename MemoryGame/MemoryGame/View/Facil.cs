using MemoryGame.Controller;
using MemoryGame.Entidade;
using MemoryGame.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Facil : Form
    {
        private string tema;
        private int qtdeCartas;
        private static int counter = 0;
        private Loading loadingScreen;
        private List<Carta> cartas;
        private ControlerGame controler;
        public Facil(string tema, int qtdeCartas)
        {
            this.tema = tema;
            this.qtdeCartas = qtdeCartas;
            InitializeComponent();
            loadingScreen = new Loading();
            loadingScreen.Show();
            CarregarCartas();
            OcultarImagens();
        }

        private async Task CarregarCartas()
        {
            await Task.Run(() =>
            {
                CartaUtil cartaUtil = new CartaUtil();
                cartas = cartaUtil.GetCartas(this.tema, this.qtdeCartas);
                controler = new ControlerGame(cartas);
                for (var x = 0; x < cartas.Count; x++)
                {
                    PictureBox picture = (PictureBox)this.Controls.Find("pictureBox_" + cartas[x].Id, false)[0];

                    picture.LoadAsync(cartas[x].Imagem);
                    picture.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            });

        }

        private void OcultarImagens()
        {
            Button botao;
            PictureBox picture;
            for(var x=1; x<=12; x++)
            {
                botao = (Button)this.Controls.Find("button_" + x, false)[0];
                picture = (PictureBox)this.Controls.Find("pictureBox_" + x, false)[0];
                botao.Visible = true;
                picture.Visible = true;
            }
        }

        private void ClickBotao(object sender, EventArgs e)
        {
            Button botao = (Button)sender;

            botao.Visible = false;

            var id = botao.Name.Split('_')[1];
            var id1 = "";

            PictureBox picture = (PictureBox)this.Controls.Find("pictureBox_" + id, false)[0];
            picture.Visible = true;
            //picture.Enabled = false;
            botao.Enabled = false;

            if (!controler.selecionouImagem(Convert.ToInt32(id)))
            {

                id1 = Convert.ToString(controler.getResposta().Id);

                Thread.Sleep(800);

                desabilitarCartas(id, id1);
            }
        }
        private void desabilitarCartas(String img1, String img2)
        {
            Button botao1 = (Button)this.Controls.Find("button_" + img1, false)[0];
            PictureBox picture1 = (PictureBox)this.Controls.Find("pictureBox_" + img1, false)[0];
            Button botao2 = (Button)this.Controls.Find("button_" + img2, false)[0];
            PictureBox picture2 = (PictureBox)this.Controls.Find("pictureBox_" + img2, false)[0];

            botao1.Visible = true;
            botao1.Enabled = true;
            //picture1.Visible = false;
            picture1.Enabled = true;

            botao2.Visible = true;
            botao2.Enabled = true;
            //picture2.Visible = false;
            picture1.Enabled = true;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {

            counter++;
            if (counter == 12)
            {

                if (loadingScreen.InvokeRequired)
                {
                    loadingScreen.BeginInvoke((MethodInvoker)delegate
                    {
                        loadingScreen.Hide();
                        this.Show();
                    });
                }
                else
                {
                    loadingScreen.Hide();
                    this.Show();
                }
            }
        }

        private void pictureBoxClick(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;

            //picture.Visible = false;

            var id = picture.Name.Split('_')[1];

            Button botao = (Button)this.Controls.Find("button_" + id, false)[0];
            //botao.Visible = true;
        }
    }
}
