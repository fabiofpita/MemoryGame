using MemoryGame.GoogleAPI;
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
            BuscadorImagem buscador = new BuscadorImagem();

            return buscador.Search(busca, num);
        }
    }
}
