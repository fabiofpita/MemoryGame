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
        private int jogadas;
        private Carta escolha1;
        private Carta escolha2;
        private Carta resposta;
        private List<Carta> cartas;
        public ControlerGame(List<Carta> cartas) {
            escolha1 = null;
            escolha2 = null;
            this.cartas = cartas;
            valores = 0;
            jogadas = 0;
        }

        //Retornos
        // True - Trava a carta e desabilita o botao
        // False - Destrava a primeira carta
        public bool selecionouImagem(int cartaEscolhida) {

            bool retorno = true;

            if (escolha1 == null)
            {
                escolha1 =  getCarta(cartaEscolhida);
                resposta = escolha1;
            }
            else {
                escolha2 = getCarta(cartaEscolhida);
                if (escolha1.Id != escolha2.Id)
                {
                    if (escolha1.IdPar == escolha2.IdPar)
                    {
                        valores += 2;

                    }
                    else
                    {
                        retorno = false;
                    }                  
                }
                escolha2 = null;
                escolha1 = null;
            }
            return retorno;
        }

        public bool ganhou() {
            return valores == cartas.Count();
        }

        public int getJogadas() {
            jogadas++;
            return jogadas;
        }

        public Carta getResposta() {
            return resposta;
        }

        private Carta getCarta(int id) {
            return cartas.Find(x => x.Id == id); 
        }

        public void pause() {
            Thread.Sleep(1000);
        }
    }
}
