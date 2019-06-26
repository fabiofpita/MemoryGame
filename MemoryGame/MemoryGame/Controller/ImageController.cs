using MemoryGame.GoogleAPI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.Controller
{
    class ImageController
    {
        public static List<Dictionary<String, String>> GetDadosImagens(string busca, int num)
        {
            try
            {
                BuscadorImagem buscador = new BuscadorImagem();
                return buscador.Search(busca, num);
            }
            catch (TimeoutException)
            {
                return null;
            }
        }

        public static List<Image> GetImagensOffline(int qtdeCartas)
        {
            List<Image> imagens = new List<Image>();
            DirectoryInfo Dir = new DirectoryInfo(@"Imagens");
            FileInfo[] Files = Dir.GetFiles("*", SearchOption.AllDirectories);
            int counter = 1;
            foreach (FileInfo File in Files)
            {
                imagens.Add(Image.FromFile(File.FullName));

                if (counter == qtdeCartas/2) break;

                counter++;
            }
            

            return imagens;
        }
    }
}
