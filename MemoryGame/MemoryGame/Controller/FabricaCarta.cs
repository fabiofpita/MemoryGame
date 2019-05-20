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

namespace MemoryGame.Controller
{
    class FabricaCarta
    {
        public static List<Carta> GetCartas(string tema, int qtdeCartas)
        {
            List<Dictionary<String, String>> imagens = ImageController.GetDadosImagens(tema, qtdeCartas/2);
            List<Carta> cartas = new List<Carta>();
            Carta aux;
            Carta copia;
            SalvarImagens(imagens);

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

            return cartas;
        }

        private static void SalvarImagens(List<Dictionary<String, String>> imagens)
        {
            try
            {
                int counter = 1;
                if (!Directory.Exists(@"temp"))
                {
                    Directory.CreateDirectory(@"temp");
                }
                foreach (Dictionary<String, String> dado in imagens)
                {
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(new Uri(dado["Url"]), "temp/imagem" + counter + "." + dado["Formato"]);
                    }
                    counter++;
                }

            }
            catch (ExternalException)
            {
                MessageBox.Show("Ocorreu um erro!", "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Ocorreu um erro!", "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
