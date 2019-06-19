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
            try
            {
                await Task.Run(() =>
                {
                    CartaUtil cartaUtil = new CartaUtil();
                    List<Carta> cartas = cartaUtil.GetCartas(this.tema, this.qtdeCartas);

                    if (cartas.Count > 0)
                    {
                        for (var x = 0; x < cartas.Count; x++)
                        {
                            PictureBox picture = (PictureBox)this.Controls.Find("pictureBox_" + cartas[x].Id, false)[0];

                            picture.Load(cartas[x].Imagem);
                            picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }


                });
                OcultarTelaLoad();
                this.Show();
            }
            catch (Exception)
            {
                OcultarTelaLoad();
                ErroDownload erro = new ErroDownload();
                erro.Show();
            }
            

        }

        private void OcultarImagens()
        {
            Button botao;
            PictureBox picture;
            for (var x = 1; x <= 12; x++)
            {
                botao = (Button)this.Controls.Find("button_" + x, false)[0];
                picture = (PictureBox)this.Controls.Find("pictureBox_" + x, false)[0];
                botao.Visible = true;
                picture.Visible = false;
            }
        }

        private void ClickBotao(object sender, EventArgs e)
        {
            Button botao = (Button)sender;

            botao.Visible = false;

            var id = botao.Name.Split('_')[1];

            PictureBox picture = (PictureBox)this.Controls.Find("pictureBox_" + id, false)[0];
            picture.Visible = true;
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
                OcultarTelaLoad();
            }
        }

        private void pictureBoxClick(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;

            picture.Visible = false;

            var id = picture.Name.Split('_')[1];

            Button botao = (Button)this.Controls.Find("button_" + id, false)[0];
            botao.Visible = true;
        }

        private void OcultarTelaLoad()
        {
            if (loadingScreen.InvokeRequired)
            {
                loadingScreen.BeginInvoke((MethodInvoker)delegate
                {
                    loadingScreen.Hide();
                });
            }
            else
            {
                loadingScreen.Hide();
            }
        }
    }

}
