using MemoryGame.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MemoryGame.Controller
{

    class ControlerGame
    {
        private int valores;
        private Carta escolha1;
        private Carta escolha2;
        private Carta resposta;
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
                resposta = escolha1;
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
                escolha2 = null;
                escolha1 = null;
                valores += 2;
            }

            return retorno;
        }

        public Boolean ganhou() {
            return ((valores * 2) == cartas.Count());
        }

        public int getJogadas() {
            return valores;
        }

        public Carta getResposta() {
            return resposta;
        }

        private Carta getCarta(int id) {
            return cartas.Find(x => x.Id ==id); 
        }

        public void pause() {
            Thread.Sleep(1000);
        }
    }
}
