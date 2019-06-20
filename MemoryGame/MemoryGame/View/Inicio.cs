using MemoryGame.Controller;
using MemoryGame.GoogleAPI;
using MemoryGame.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            rblFacil.Checked = true;
            txtTema.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtTema.Text))
            {
                focus = true;
                this.Refresh();
            }
            else
            {
                this.Hide();
                if (rblFacil.Checked)
                {
                    Facil facil = new Facil(txtTema.Text, 12, this.chkOff.Checked);
                }else if (rblMedio.Checked)
                {
                    Medio medio = new Medio(txtTema.Text, 16, this.chkOff.Checked);
                }else if (rblDificil.Checked)
                {
                    Dificil dificil = new Dificil(txtTema.Text, 20, this.chkOff.Checked);
                }
            }
        }

        bool focus = false;
        private void Inicio_Paint(object sender, PaintEventArgs e)
        {
            if (focus)
            {
                txtTema.BorderStyle = BorderStyle.None;
                Pen p = new Pen(Color.Red);
                Graphics g = e.Graphics;
                int variance = 3;
                g.DrawRectangle(p, new Rectangle(txtTema.Location.X - variance, txtTema.Location.Y - variance, txtTema.Width + variance, txtTema.Height + variance));
            }
            else
            {
                txtTema.BorderStyle = BorderStyle.FixedSingle;
            }
        }

    }
}
