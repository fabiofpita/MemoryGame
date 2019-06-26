using MemoryGame.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Drawing;
using System.Reflection;
using MemoryGame.View;
using System.Diagnostics;
using System.Security.Cryptography;

namespace MemoryGame.Controller
{
    class FabricaCarta
    {
        private static Random rng = new Random();
        public static List<Carta> GetCartas(string tema, int qtdeCartas, bool off)
        {

            List<Carta> cartas;
            Carta aux;
            Carta copia;
            cartas = new List<Carta>();
            List<Dictionary<String, String>> imagens = null;
            if (!off)
            {
                try
                {
                    imagens = ImageController.GetDadosImagens(tema, qtdeCartas / 2);
                    if (imagens != null)
                    {
                        List<Image> retorno = SalvarImagens(imagens);
                        if (retorno != null)
                        {
                            for (int x = 0; x < imagens.Count; x++)
                            {
                                aux = new Carta();
                                aux.Id = x + 1;
                                aux.Imagem = retorno[x];
                                aux.IdPar = x + 1;

                                copia = new Carta();
                                copia.Imagem = aux.Imagem;
                                copia.IdPar = x + 1;
                                copia.Id = (x + 1) + imagens.Count;

                                cartas.Add(aux);
                                cartas.Add(copia);
                            }

                            EmbaralharCartas(cartas);

                        }
                    }
                }
                catch (TimeoutException)
                {
                    cartas = new List<Carta>();
                }
            }
            else
            {
                List<Image> imagensOff = ImageController.GetImagensOffline(qtdeCartas);

                for (int x = 0; x < imagensOff.Count; x++)
                {
                    aux = new Carta();
                    aux.Id = x + 1;
                    aux.Imagem = imagensOff[x];
                    aux.IdPar = x + 1;

                    copia = new Carta();
                    copia.Imagem = aux.Imagem;
                    copia.IdPar = x + 1;
                    copia.Id = (x + 1) + imagensOff.Count;

                    cartas.Add(aux);
                    cartas.Add(copia);
                }

                EmbaralharCartas(cartas);
            }
            

            return cartas;
        }


        private static List<Image> SalvarImagens(List<Dictionary<String, String>> imagens)
        {
            try
            {
                List<Image> listaImagens = new List<Image>();
                Stopwatch sw = new Stopwatch();
                sw.Start();

                int counter = 1;

                foreach (Dictionary<String, String> dado in imagens)
                {
                    using (WebClient client = new WebClient())
                    {
                        //client.DownloadFile(new Uri(dado["Url"]), "temp/imagem" + counter + dado["Formato"]);
                        byte[] imagem = client.DownloadData(dado["Url"]);

                        using(var ms = new MemoryStream(imagem))
                        {
                            listaImagens.Add(Image.FromStream(ms));
                        }
                    }
                    counter++;
                    if (sw.ElapsedMilliseconds > 20000)
                    {
                        throw new TimeoutException();
                    }
                }

                sw.Stop();
                sw.Reset();

                return listaImagens;
            }
            catch (ExternalException)
            {
                return null;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        private static void EmbaralharCartas(List<Carta> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                Carta value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    
}
