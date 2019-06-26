using MemoryGame.GoogleAPI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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

            imagens.Add(MemoryGame.Properties.Resources.imagem1);
            imagens.Add(MemoryGame.Properties.Resources.imagem2);
            imagens.Add(MemoryGame.Properties.Resources.imagem3);
            imagens.Add(MemoryGame.Properties.Resources.imagem4);
            imagens.Add(MemoryGame.Properties.Resources.imagem5);
            imagens.Add(MemoryGame.Properties.Resources.imagem6);
            imagens.Add(MemoryGame.Properties.Resources.imagem7);
            imagens.Add(MemoryGame.Properties.Resources.imagem8);
            imagens.Add(MemoryGame.Properties.Resources.imagem9);
            imagens.Add(MemoryGame.Properties.Resources.imagem10);

            imagens = imagens.Take(qtdeCartas/2).ToList();

            return imagens;
        }
    }
}
