using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.Entidade
{
    class Carta
    {
        private Image imagem;
        public Image Imagem
        {
            get
            {
                return imagem;
            }
            set
            {
                this.imagem = value;
            }

        }
        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                this.id = value;
            }
        }

        private int idPar;
        public int IdPar
        {
            get
            {
                return idPar;
            }
            set
            {
                this.idPar = value;
            }
        }

        public Carta()
        {

        }
    }
}
