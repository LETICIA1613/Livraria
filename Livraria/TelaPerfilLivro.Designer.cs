namespace Livraria
{
    partial class TelaPerfilLivro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblTitulo2 = new System.Windows.Forms.Label();
            this.LblAutor2 = new System.Windows.Forms.Label();
            this.LblGenero2 = new System.Windows.Forms.Label();
            this.LblPreco2 = new System.Windows.Forms.Label();
            this.BtnComprar1 = new System.Windows.Forms.Button();
            this.LblNacionalidade = new System.Windows.Forms.Label();
            this.LblFaixa2 = new System.Windows.Forms.Label();
            this.PbCapa2 = new System.Windows.Forms.PictureBox();
            this.LblEditora2 = new System.Windows.Forms.Label();
            this.TxtDescricao = new System.Windows.Forms.TextBox();
            this.TxtBiografia = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbCapa2)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTitulo2
            // 
            this.LblTitulo2.Location = new System.Drawing.Point(322, 36);
            this.LblTitulo2.Name = "LblTitulo2";
            this.LblTitulo2.Size = new System.Drawing.Size(35, 13);
            this.LblTitulo2.TabIndex = 1;
            this.LblTitulo2.Text = "Título";
            // 
            // LblAutor2
            // 
            this.LblAutor2.Location = new System.Drawing.Point(322, 62);
            this.LblAutor2.Name = "LblAutor2";
            this.LblAutor2.Size = new System.Drawing.Size(35, 13);
            this.LblAutor2.TabIndex = 2;
            this.LblAutor2.Text = "Autor";
            // 
            // LblGenero2
            // 
            this.LblGenero2.AutoSize = true;
            this.LblGenero2.Location = new System.Drawing.Point(325, 109);
            this.LblGenero2.Name = "LblGenero2";
            this.LblGenero2.Size = new System.Drawing.Size(42, 13);
            this.LblGenero2.TabIndex = 3;
            this.LblGenero2.Text = "Gênero";
            this.LblGenero2.Click += new System.EventHandler(this.LblGenero2_Click);
            // 
            // LblPreco2
            // 
            this.LblPreco2.AutoSize = true;
            this.LblPreco2.Location = new System.Drawing.Point(448, 156);
            this.LblPreco2.Name = "LblPreco2";
            this.LblPreco2.Size = new System.Drawing.Size(35, 13);
            this.LblPreco2.TabIndex = 4;
            this.LblPreco2.Text = "Preço";
            // 
            // BtnComprar1
            // 
            this.BtnComprar1.Location = new System.Drawing.Point(325, 195);
            this.BtnComprar1.Name = "BtnComprar1";
            this.BtnComprar1.Size = new System.Drawing.Size(75, 23);
            this.BtnComprar1.TabIndex = 6;
            this.BtnComprar1.Text = "button1";
            this.BtnComprar1.UseVisualStyleBackColor = true;
            this.BtnComprar1.Click += new System.EventHandler(this.BtnComprar1_Click);
            // 
            // LblNacionalidade
            // 
            this.LblNacionalidade.AutoSize = true;
            this.LblNacionalidade.Location = new System.Drawing.Point(40, 269);
            this.LblNacionalidade.Name = "LblNacionalidade";
            this.LblNacionalidade.Size = new System.Drawing.Size(75, 13);
            this.LblNacionalidade.TabIndex = 7;
            this.LblNacionalidade.Text = "Nacionalidade";
            // 
            // LblFaixa2
            // 
            this.LblFaixa2.AutoSize = true;
            this.LblFaixa2.Location = new System.Drawing.Point(322, 134);
            this.LblFaixa2.Name = "LblFaixa2";
            this.LblFaixa2.Size = new System.Drawing.Size(59, 13);
            this.LblFaixa2.TabIndex = 10;
            this.LblFaixa2.Text = "FaixaEtaria";
            // 
            // PbCapa2
            // 
            this.PbCapa2.Location = new System.Drawing.Point(29, 36);
            this.PbCapa2.Name = "PbCapa2";
            this.PbCapa2.Size = new System.Drawing.Size(150, 200);
            this.PbCapa2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbCapa2.TabIndex = 0;
            this.PbCapa2.TabStop = false;
            this.PbCapa2.Click += new System.EventHandler(this.PbCapa2_Click);
            // 
            // LblEditora2
            // 
            this.LblEditora2.AutoSize = true;
            this.LblEditora2.Location = new System.Drawing.Point(322, 84);
            this.LblEditora2.Name = "LblEditora2";
            this.LblEditora2.Size = new System.Drawing.Size(40, 13);
            this.LblEditora2.TabIndex = 12;
            this.LblEditora2.Text = "Editora";
            this.LblEditora2.Click += new System.EventHandler(this.LblEditora2_Click);
            // 
            // TxtDescricao
            // 
            this.TxtDescricao.Location = new System.Drawing.Point(43, 297);
            this.TxtDescricao.Name = "TxtDescricao";
            this.TxtDescricao.Size = new System.Drawing.Size(100, 20);
            this.TxtDescricao.TabIndex = 13;
            this.TxtDescricao.TextChanged += new System.EventHandler(this.TxtDescricao_TextChanged);
            // 
            // TxtBiografia
            // 
            this.TxtBiografia.Location = new System.Drawing.Point(43, 349);
            this.TxtBiografia.Name = "TxtBiografia";
            this.TxtBiografia.Size = new System.Drawing.Size(100, 20);
            this.TxtBiografia.TabIndex = 14;
            this.TxtBiografia.TextChanged += new System.EventHandler(this.TxtBiografia_TextChanged);
            // 
            // TelaPerfilLivro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TxtBiografia);
            this.Controls.Add(this.TxtDescricao);
            this.Controls.Add(this.LblEditora2);
            this.Controls.Add(this.LblFaixa2);
            this.Controls.Add(this.LblNacionalidade);
            this.Controls.Add(this.BtnComprar1);
            this.Controls.Add(this.LblPreco2);
            this.Controls.Add(this.LblGenero2);
            this.Controls.Add(this.LblAutor2);
            this.Controls.Add(this.LblTitulo2);
            this.Controls.Add(this.PbCapa2);
            this.Name = "TelaPerfilLivro";
            this.Text = "TelaPerfilLivro";
            this.Load += new System.EventHandler(this.TelaPerfilLivro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbCapa2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PbCapa2;
        private System.Windows.Forms.Label LblTitulo2;
        private System.Windows.Forms.Label LblAutor2;
        private System.Windows.Forms.Label LblGenero2;
        private System.Windows.Forms.Label LblPreco2;
        private System.Windows.Forms.Button BtnComprar1;
        private System.Windows.Forms.Label LblNacionalidade;
        private System.Windows.Forms.Label LblFaixa2;
        private System.Windows.Forms.Label LblEditora2;
        private System.Windows.Forms.TextBox TxtDescricao;
        private System.Windows.Forms.TextBox TxtBiografia;
    }
}