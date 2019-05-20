using System.Drawing;
using System.Windows.Forms;

namespace MemoryGame.View
{
    partial class Loading
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading));
            this.label1 = new System.Windows.Forms.Label();
            this.rblFacil = new System.Windows.Forms.RadioButton();
            this.rblMedio = new System.Windows.Forms.RadioButton();
            this.rblDificil = new System.Windows.Forms.RadioButton();
            this.txtTema = new System.Windows.Forms.TextBox();
            this.btnJogar = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF Slapstick Comic", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(100, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 65);
            this.label1.TabIndex = 0;
            this.label1.Text = "CARREGANDO";
            // 
            // rblFacil
            // 
            this.rblFacil.Location = new System.Drawing.Point(0, 0);
            this.rblFacil.Name = "rblFacil";
            this.rblFacil.Size = new System.Drawing.Size(104, 24);
            this.rblFacil.TabIndex = 0;
            // 
            // rblMedio
            // 
            this.rblMedio.Location = new System.Drawing.Point(0, 0);
            this.rblMedio.Name = "rblMedio";
            this.rblMedio.Size = new System.Drawing.Size(104, 24);
            this.rblMedio.TabIndex = 0;
            // 
            // rblDificil
            // 
            this.rblDificil.Location = new System.Drawing.Point(0, 0);
            this.rblDificil.Name = "rblDificil";
            this.rblDificil.Size = new System.Drawing.Size(104, 24);
            this.rblDificil.TabIndex = 0;
            // 
            // txtTema
            // 
            this.txtTema.Location = new System.Drawing.Point(0, 0);
            this.txtTema.Name = "txtTema";
            this.txtTema.Size = new System.Drawing.Size(100, 20);
            this.txtTema.TabIndex = 0;
            // 
            // btnJogar
            // 
            this.btnJogar.Location = new System.Drawing.Point(0, 0);
            this.btnJogar.Name = "btnJogar";
            this.btnJogar.Size = new System.Drawing.Size(75, 23);
            this.btnJogar.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(164, 112);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(448, 248);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("SF Slapstick Comic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Loading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jogo da Memória";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rblFacil;
        private System.Windows.Forms.RadioButton rblMedio;
        private System.Windows.Forms.RadioButton rblDificil;
        private System.Windows.Forms.TextBox txtTema;
        private System.Windows.Forms.Button btnJogar;
        private System.Windows.Forms.Button btnClose;
        private PictureBox pictureBox1;
    }
}

