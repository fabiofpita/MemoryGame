using System.Drawing;
using System.Windows.Forms;

namespace MemoryGame
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.label1 = new System.Windows.Forms.Label();
            this.rblFacil = new System.Windows.Forms.RadioButton();
            this.rblMedio = new System.Windows.Forms.RadioButton();
            this.rblDificil = new System.Windows.Forms.RadioButton();
            this.txtTema = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnJogar = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkOff = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF Slapstick Comic", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 65);
            this.label1.TabIndex = 0;
            this.label1.Text = "JOGO DA MEMÓRIA";
            // 
            // rblFacil
            // 
            this.rblFacil.AutoSize = true;
            this.rblFacil.Location = new System.Drawing.Point(274, 339);
            this.rblFacil.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.rblFacil.Name = "rblFacil";
            this.rblFacil.Size = new System.Drawing.Size(62, 25);
            this.rblFacil.TabIndex = 1;
            this.rblFacil.TabStop = true;
            this.rblFacil.Text = "Fácil";
            this.rblFacil.UseVisualStyleBackColor = true;
            // 
            // rblMedio
            // 
            this.rblMedio.AutoSize = true;
            this.rblMedio.Location = new System.Drawing.Point(274, 374);
            this.rblMedio.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.rblMedio.Name = "rblMedio";
            this.rblMedio.Size = new System.Drawing.Size(70, 25);
            this.rblMedio.TabIndex = 2;
            this.rblMedio.TabStop = true;
            this.rblMedio.Text = "Médio";
            this.rblMedio.UseVisualStyleBackColor = true;
            // 
            // rblDificil
            // 
            this.rblDificil.AutoSize = true;
            this.rblDificil.Location = new System.Drawing.Point(274, 409);
            this.rblDificil.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.rblDificil.Name = "rblDificil";
            this.rblDificil.Size = new System.Drawing.Size(71, 25);
            this.rblDificil.TabIndex = 3;
            this.rblDificil.TabStop = true;
            this.rblDificil.Text = "Difícil";
            this.rblDificil.UseVisualStyleBackColor = true;
            // 
            // txtTema
            // 
            this.txtTema.Location = new System.Drawing.Point(217, 225);
            this.txtTema.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtTema.Name = "txtTema";
            this.txtTema.Size = new System.Drawing.Size(182, 29);
            this.txtTema.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SF Slapstick Comic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(213, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Escolha o tema:";
            // 
            // btnJogar
            // 
            this.btnJogar.BackColor = System.Drawing.Color.White;
            this.btnJogar.Font = new System.Drawing.Font("SF Slapstick Comic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnJogar.Location = new System.Drawing.Point(249, 462);
            this.btnJogar.Name = "btnJogar";
            this.btnJogar.Size = new System.Drawing.Size(121, 47);
            this.btnJogar.TabIndex = 6;
            this.btnJogar.Text = "JOGAR";
            this.btnJogar.UseVisualStyleBackColor = false;
            this.btnJogar.Click += new System.EventHandler(this.btnJogar_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(600, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(38, 38);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkOff
            // 
            this.chkOff.AutoSize = true;
            this.chkOff.Location = new System.Drawing.Point(217, 272);
            this.chkOff.Name = "chkOff";
            this.chkOff.Size = new System.Drawing.Size(130, 25);
            this.chkOff.TabIndex = 8;
            this.chkOff.Text = "JOGAR OFFLINE";
            this.chkOff.UseVisualStyleBackColor = true;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(650, 585);
            this.Controls.Add(this.chkOff);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnJogar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTema);
            this.Controls.Add(this.rblDificil);
            this.Controls.Add(this.rblMedio);
            this.Controls.Add(this.rblFacil);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("SF Slapstick Comic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jogo da Memória";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Inicio_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rblFacil;
        private System.Windows.Forms.RadioButton rblMedio;
        private System.Windows.Forms.RadioButton rblDificil;
        private System.Windows.Forms.TextBox txtTema;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnJogar;
        private System.Windows.Forms.Button btnClose;
        private CheckBox chkOff;
    }
}

