using MemoryGame.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.Controller
{

    class ControlerGame
    {
        private int valores;
        private Carta escolha1;
        private Carta escolha2;
        private List<Carta> cartas;
        public ControlerGame(List<Carta> cartas) {
            escolha1 = null;
            escolha2 = null;
            this.cartas = cartas;
            valores = 0;
        }

        //Retornos
        // True - Trava a carta e desabilita o botao
        // False - Destrava a primeira carta
        public Boolean selecionouImagem(int cartaEscolhida) {

            Boolean retorno = true;

            if (escolha1 == null)
            {
                escolha1 =  getCarta(cartaEscolhida);
            }
            else {
                escolha2 = getCarta(cartaEscolhida);
                if (escolha1.Id != escolha2.Id)
                {
                    if (escolha1.IdPar != escolha2.IdPar)
                    {
                        retorno = false;
                    }
                }
                escolha2 = escolha1;
                escolha1 = null;
         
            }

            return retorno;
        }

        public Carta getResposta() {
            return escolha2;
        }

        private Carta getCarta(int id) {
            return cartas.Find(x => x.Id ==id); 
        }
    }
}
