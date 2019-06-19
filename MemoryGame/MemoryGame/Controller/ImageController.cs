using MemoryGame.GoogleAPI;
using MemoryGame.View;
using System;
using System.Collections.Generic;
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
    }
}
