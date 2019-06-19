using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame.View
{
    public partial class Ganhou : Form
    {
        public Ganhou(string jogadas, string tempo)
        {
            InitializeComponent();
            lblJogadas.Text = jogadas;
            lblTempo.Text = tempo;
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio();
            inicio.Show();
            this.Hide();
        }
    }
}
