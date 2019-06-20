using MemoryGame.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.Controller
{
    class CartaUtil
    {
        public List<Carta> GetCartas(string tema, int qtdeCartas, bool off)
        {
            return FabricaCarta.GetCartas(tema, qtdeCartas, off);
        }
    }
}
