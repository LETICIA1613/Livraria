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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPerfilLivro));
            this.BtnComprar1 = new System.Windows.Forms.Button();
            this.LblNacionalidade = new System.Windows.Forms.Label();
            this.PbCapa2 = new System.Windows.Forms.PictureBox();
            this.TxtDescricao = new System.Windows.Forms.TextBox();
            this.TxtBiografia = new System.Windows.Forms.TextBox();
            this.LblEditora2 = new System.Windows.Forms.Label();
            this.LblTitulo2 = new System.Windows.Forms.Label();
            this.LblGenero2 = new System.Windows.Forms.Label();
            this.LblFaixa2 = new System.Windows.Forms.Label();
            this.LblPreco2 = new System.Windows.Forms.Label();
            this.LblAutor2 = new System.Windows.Forms.Label();
            this.LblTxtDescricaoadmin = new System.Windows.Forms.Label();
            this.LblInfor = new System.Windows.Forms.Label();
            this.LblInfoNome = new System.Windows.Forms.Label();
            this.LblInfoFX = new System.Windows.Forms.Label();
            this.LblInfoAutor = new System.Windows.Forms.Label();
            this.LblInfoEditora = new System.Windows.Forms.Label();
            this.LblInfoNaciAutor = new System.Windows.Forms.Label();
            this.LblBiografia = new System.Windows.Forms.Label();
            this.LblInfoGenero = new System.Windows.Forms.Label();
            this.LblInfoEditora2 = new System.Windows.Forms.Label();
            this.LblInfoAutor2 = new System.Windows.Forms.Label();
            this.LblInfoNome2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbCapa2)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnComprar1
            // 
            this.BtnComprar1.Location = new System.Drawing.Point(279, 181);
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
            this.LblNacionalidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNacionalidade.Location = new System.Drawing.Point(186, 532);
            this.LblNacionalidade.Name = "LblNacionalidade";
            this.LblNacionalidade.Size = new System.Drawing.Size(96, 16);
            this.LblNacionalidade.TabIndex = 7;
            this.LblNacionalidade.Text = "Nacionalidade";
            // 
            // PbCapa2
            // 
            this.PbCapa2.Image = ((System.Drawing.Image)(resources.GetObject("PbCapa2.Image")));
            this.PbCapa2.Location = new System.Drawing.Point(30, 24);
            this.PbCapa2.Name = "PbCapa2";
            this.PbCapa2.Size = new System.Drawing.Size(133, 232);
            this.PbCapa2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PbCapa2.TabIndex = 0;
            this.PbCapa2.TabStop = false;
            this.PbCapa2.Click += new System.EventHandler(this.PbCapa2_Click);
            // 
            // TxtDescricao
            // 
            this.TxtDescricao.Location = new System.Drawing.Point(30, 335);
            this.TxtDescricao.Name = "TxtDescricao";
            this.TxtDescricao.Size = new System.Drawing.Size(696, 20);
            this.TxtDescricao.TabIndex = 13;
            this.TxtDescricao.TextChanged += new System.EventHandler(this.TxtDescricao_TextChanged);
            // 
            // TxtBiografia
            // 
            this.TxtBiografia.Location = new System.Drawing.Point(30, 677);
            this.TxtBiografia.Name = "TxtBiografia";
            this.TxtBiografia.Size = new System.Drawing.Size(696, 20);
            this.TxtBiografia.TabIndex = 14;
            this.TxtBiografia.TextChanged += new System.EventHandler(this.TxtBiografia_TextChanged);
            // 
            // LblEditora2
            // 
            this.LblEditora2.AutoSize = true;
            this.LblEditora2.Location = new System.Drawing.Point(232, 82);
            this.LblEditora2.Name = "LblEditora2";
            this.LblEditora2.Size = new System.Drawing.Size(40, 13);
            this.LblEditora2.TabIndex = 12;
            this.LblEditora2.Text = "Editora";
            this.LblEditora2.Click += new System.EventHandler(this.LblEditora2_Click);
            // 
            // LblTitulo2
            // 
            this.LblTitulo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo2.Location = new System.Drawing.Point(231, 24);
            this.LblTitulo2.Name = "LblTitulo2";
            this.LblTitulo2.Size = new System.Drawing.Size(381, 26);
            this.LblTitulo2.TabIndex = 1;
            this.LblTitulo2.Text = "Título";
            // 
            // LblGenero2
            // 
            this.LblGenero2.AutoSize = true;
            this.LblGenero2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGenero2.Location = new System.Drawing.Point(85, 612);
            this.LblGenero2.Name = "LblGenero2";
            this.LblGenero2.Size = new System.Drawing.Size(52, 16);
            this.LblGenero2.TabIndex = 3;
            this.LblGenero2.Text = "Gênero";
            this.LblGenero2.Click += new System.EventHandler(this.LblGenero2_Click);
            // 
            // LblFaixa2
            // 
            this.LblFaixa2.AutoSize = true;
            this.LblFaixa2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFaixa2.Location = new System.Drawing.Point(122, 586);
            this.LblFaixa2.Name = "LblFaixa2";
            this.LblFaixa2.Size = new System.Drawing.Size(75, 16);
            this.LblFaixa2.TabIndex = 10;
            this.LblFaixa2.Text = "FaixaEtaria";
            // 
            // LblPreco2
            // 
            this.LblPreco2.AutoSize = true;
            this.LblPreco2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPreco2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblPreco2.Location = new System.Drawing.Point(400, 141);
            this.LblPreco2.Name = "LblPreco2";
            this.LblPreco2.Size = new System.Drawing.Size(55, 20);
            this.LblPreco2.TabIndex = 4;
            this.LblPreco2.Text = "Preço";
            // 
            // LblAutor2
            // 
            this.LblAutor2.Location = new System.Drawing.Point(232, 60);
            this.LblAutor2.Name = "LblAutor2";
            this.LblAutor2.Size = new System.Drawing.Size(213, 22);
            this.LblAutor2.TabIndex = 2;
            this.LblAutor2.Text = "Autor";
            // 
            // LblTxtDescricaoadmin
            // 
            this.LblTxtDescricaoadmin.AutoSize = true;
            this.LblTxtDescricaoadmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTxtDescricaoadmin.Location = new System.Drawing.Point(26, 300);
            this.LblTxtDescricaoadmin.Name = "LblTxtDescricaoadmin";
            this.LblTxtDescricaoadmin.Size = new System.Drawing.Size(157, 20);
            this.LblTxtDescricaoadmin.TabIndex = 15;
            this.LblTxtDescricaoadmin.Text = "Descrição do Livro";
            // 
            // LblInfor
            // 
            this.LblInfor.AutoSize = true;
            this.LblInfor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfor.Location = new System.Drawing.Point(28, 448);
            this.LblInfor.Name = "LblInfor";
            this.LblInfor.Size = new System.Drawing.Size(177, 20);
            this.LblInfor.TabIndex = 16;
            this.LblInfor.Text = "Informações do Livro";
            // 
            // LblInfoNome
            // 
            this.LblInfoNome.AutoSize = true;
            this.LblInfoNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfoNome.Location = new System.Drawing.Point(28, 480);
            this.LblInfoNome.Name = "LblInfoNome";
            this.LblInfoNome.Size = new System.Drawing.Size(47, 16);
            this.LblInfoNome.TabIndex = 17;
            this.LblInfoNome.Text = "Nome:";
            // 
            // LblInfoFX
            // 
            this.LblInfoFX.AutoSize = true;
            this.LblInfoFX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfoFX.Location = new System.Drawing.Point(27, 586);
            this.LblInfoFX.Name = "LblInfoFX";
            this.LblInfoFX.Size = new System.Drawing.Size(89, 16);
            this.LblInfoFX.TabIndex = 18;
            this.LblInfoFX.Text = "Faixa Etaária:";
            // 
            // LblInfoAutor
            // 
            this.LblInfoAutor.AutoSize = true;
            this.LblInfoAutor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfoAutor.Location = new System.Drawing.Point(28, 505);
            this.LblInfoAutor.Name = "LblInfoAutor";
            this.LblInfoAutor.Size = new System.Drawing.Size(41, 16);
            this.LblInfoAutor.TabIndex = 19;
            this.LblInfoAutor.Text = "Autor:";
            // 
            // LblInfoEditora
            // 
            this.LblInfoEditora.AutoSize = true;
            this.LblInfoEditora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfoEditora.Location = new System.Drawing.Point(28, 559);
            this.LblInfoEditora.Name = "LblInfoEditora";
            this.LblInfoEditora.Size = new System.Drawing.Size(53, 16);
            this.LblInfoEditora.TabIndex = 20;
            this.LblInfoEditora.Text = "Editora:";
            // 
            // LblInfoNaciAutor
            // 
            this.LblInfoNaciAutor.AutoSize = true;
            this.LblInfoNaciAutor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfoNaciAutor.Location = new System.Drawing.Point(28, 532);
            this.LblInfoNaciAutor.Name = "LblInfoNaciAutor";
            this.LblInfoNaciAutor.Size = new System.Drawing.Size(152, 16);
            this.LblInfoNaciAutor.TabIndex = 21;
            this.LblInfoNaciAutor.Text = "Nacionalidade do Autor:";
            // 
            // LblBiografia
            // 
            this.LblBiografia.AutoSize = true;
            this.LblBiografia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBiografia.Location = new System.Drawing.Point(27, 639);
            this.LblBiografia.Name = "LblBiografia";
            this.LblBiografia.Size = new System.Drawing.Size(155, 20);
            this.LblBiografia.TabIndex = 22;
            this.LblBiografia.Text = "Biografia do Autor";
            // 
            // LblInfoGenero
            // 
            this.LblInfoGenero.AutoSize = true;
            this.LblInfoGenero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfoGenero.Location = new System.Drawing.Point(29, 612);
            this.LblInfoGenero.Name = "LblInfoGenero";
            this.LblInfoGenero.Size = new System.Drawing.Size(55, 16);
            this.LblInfoGenero.TabIndex = 31;
            this.LblInfoGenero.Text = "Gênero:";
            // 
            // LblInfoEditora2
            // 
            this.LblInfoEditora2.AutoSize = true;
            this.LblInfoEditora2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfoEditora2.Location = new System.Drawing.Point(85, 559);
            this.LblInfoEditora2.Name = "LblInfoEditora2";
            this.LblInfoEditora2.Size = new System.Drawing.Size(50, 16);
            this.LblInfoEditora2.TabIndex = 32;
            this.LblInfoEditora2.Text = "Editora";
            // 
            // LblInfoAutor2
            // 
            this.LblInfoAutor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfoAutor2.Location = new System.Drawing.Point(75, 507);
            this.LblInfoAutor2.Name = "LblInfoAutor2";
            this.LblInfoAutor2.Size = new System.Drawing.Size(38, 17);
            this.LblInfoAutor2.TabIndex = 33;
            this.LblInfoAutor2.Text = "Autor";
            // 
            // LblInfoNome2
            // 
            this.LblInfoNome2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfoNome2.Location = new System.Drawing.Point(75, 480);
            this.LblInfoNome2.Name = "LblInfoNome2";
            this.LblInfoNome2.Size = new System.Drawing.Size(41, 27);
            this.LblInfoNome2.TabIndex = 34;
            this.LblInfoNome2.Text = "Título";
            // 
            // TelaPerfilLivro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 881);
            this.Controls.Add(this.LblInfoNome2);
            this.Controls.Add(this.LblInfoAutor2);
            this.Controls.Add(this.LblInfoEditora2);
            this.Controls.Add(this.LblInfoGenero);
            this.Controls.Add(this.LblBiografia);
            this.Controls.Add(this.LblInfoNaciAutor);
            this.Controls.Add(this.LblInfoEditora);
            this.Controls.Add(this.LblInfoAutor);
            this.Controls.Add(this.LblInfoFX);
            this.Controls.Add(this.LblInfoNome);
            this.Controls.Add(this.LblInfor);
            this.Controls.Add(this.LblTxtDescricaoadmin);
            this.Controls.Add(this.LblGenero2);
            this.Controls.Add(this.LblFaixa2);
            this.Controls.Add(this.LblAutor2);
            this.Controls.Add(this.LblPreco2);
            this.Controls.Add(this.PbCapa2);
            this.Controls.Add(this.BtnComprar1);
            this.Controls.Add(this.LblEditora2);
            this.Controls.Add(this.LblNacionalidade);
            this.Controls.Add(this.TxtBiografia);
            this.Controls.Add(this.LblTitulo2);
            this.Controls.Add(this.TxtDescricao);
            this.Name = "TelaPerfilLivro";
            this.Text = "TelaPerfilLivro";
            this.Load += new System.EventHandler(this.TelaPerfilLivro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbCapa2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PbCapa2;
        private System.Windows.Forms.Button BtnComprar1;
        private System.Windows.Forms.Label LblNacionalidade;
        private System.Windows.Forms.TextBox TxtDescricao;
        private System.Windows.Forms.TextBox TxtBiografia;
        private System.Windows.Forms.Label LblEditora2;
        private System.Windows.Forms.Label LblTitulo2;
        private System.Windows.Forms.Label LblGenero2;
        private System.Windows.Forms.Label LblFaixa2;
        private System.Windows.Forms.Label LblPreco2;
        private System.Windows.Forms.Label LblAutor2;
        private System.Windows.Forms.Label LblTxtDescricaoadmin;
        private System.Windows.Forms.Label LblInfor;
        private System.Windows.Forms.Label LblInfoNome;
        private System.Windows.Forms.Label LblInfoFX;
        private System.Windows.Forms.Label LblInfoAutor;
        private System.Windows.Forms.Label LblInfoEditora;
        private System.Windows.Forms.Label LblInfoNaciAutor;
        private System.Windows.Forms.Label LblBiografia;
        private System.Windows.Forms.Label LblInfoGenero;
        private System.Windows.Forms.Label LblInfoEditora2;
        private System.Windows.Forms.Label LblInfoAutor2;
        private System.Windows.Forms.Label LblInfoNome2;
    }
}