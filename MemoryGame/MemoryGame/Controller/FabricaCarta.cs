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

namespace MemoryGame.Controller
{
    class FabricaCarta
    {
        public static List<Carta> GetCartas(string tema, int qtdeCartas)
        {

            List<Carta> cartas;
            Carta aux;
            Carta copia;
            List<Dictionary<String, String>> imagens = null;
            try
            {
                imagens = ImageController.GetDadosImagens(tema, qtdeCartas / 2);
                cartas = new List<Carta>();
                if (imagens != null)
                {
                    int retorno = SalvarImagens(imagens);
                    if (retorno == 0)
                    {
                        for (int x = 0; x < imagens.Count; x++)
                        {
                            aux = new Carta();
                            aux.Id = x + 1;
                            aux.Imagem = @"temp\imagem" + (x + 1) + "." + imagens[x]["Formato"];
                            aux.IdPar = x + 1;

                            copia = new Carta();
                            copia.Imagem = aux.Imagem;
                            copia.IdPar = x + 1;
                            copia.Id = (x + 1) + imagens.Count;

                            cartas.Add(aux);
                            cartas.Add(copia);
                        }
                        Random rnd = new Random();

                        cartas = cartas.OrderBy(x => rnd.Next()).ToList();

                    }
                }
            }
            catch (TimeoutException)
            {
                cartas = new List<Carta>();
            }

            return cartas;
        }


        private static int SalvarImagens(List<Dictionary<String, String>> imagens)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                int counter = 1;
                if (!Directory.Exists(@"temp"))
                {
                    Directory.CreateDirectory(@"temp");
                }

                string url;
                HttpWebRequest request;
                string basePath = @"temp"; // Change accordingly...

                foreach (Dictionary<String, String> dado in imagens)
                {
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(new Uri(dado["Url"]), "temp/imagem" + counter + "." + dado["Formato"]);
                    }
                    counter++;
                    if (sw.ElapsedMilliseconds > 20000)
                    {
                        throw new TimeoutException();
                    }
                }

                sw.Stop();
                sw.Reset();

            }
            catch (ExternalException)
            {
                return 1;
            }
            catch (ArgumentNullException)
            {
                return 2;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return 3;
            }

            return 0;
        }
    }
}
