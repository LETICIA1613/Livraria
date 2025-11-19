namespace Livraria
{
    partial class Telaadicionarlivro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Telaadicionarlivro));
            this.Btnadd = new System.Windows.Forms.Button();
            this.Txtnamebook = new System.Windows.Forms.TextBox();
            this.TxtAutor = new System.Windows.Forms.TextBox();
            this.Picturebook = new System.Windows.Forms.PictureBox();
            this.TxtPreco = new System.Windows.Forms.TextBox();
            this.Btnimage = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Txtquant = new System.Windows.Forms.TextBox();
            this.CbFaixaEtaria = new System.Windows.Forms.ComboBox();
            this.CbEditora = new System.Windows.Forms.ComboBox();
            this.ClbGenero = new System.Windows.Forms.CheckedListBox();
            this.TxtYears = new System.Windows.Forms.TextBox();
            this.TxtPages = new System.Windows.Forms.TextBox();
            this.TxtLanguage = new System.Windows.Forms.TextBox();
            this.TxtDescription = new System.Windows.Forms.TextBox();
            this.TxtNacionalidade = new System.Windows.Forms.TextBox();
            this.TxtBiografia = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Picturebook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Btnadd
            // 
            this.Btnadd.BackColor = System.Drawing.Color.Pink;
            this.Btnadd.Location = new System.Drawing.Point(579, 409);
            this.Btnadd.Name = "Btnadd";
            this.Btnadd.Size = new System.Drawing.Size(75, 23);
            this.Btnadd.TabIndex = 1;
            this.Btnadd.Text = "Adicionar";
            this.Btnadd.UseVisualStyleBackColor = false;
            this.Btnadd.Click += new System.EventHandler(this.Btnadd_Click);
            // 
            // Txtnamebook
            // 
            this.Txtnamebook.Location = new System.Drawing.Point(175, 256);
            this.Txtnamebook.Name = "Txtnamebook";
            this.Txtnamebook.Size = new System.Drawing.Size(185, 20);
            this.Txtnamebook.TabIndex = 2;
            // 
            // TxtAutor
            // 
            this.TxtAutor.Location = new System.Drawing.Point(175, 282);
            this.TxtAutor.Name = "TxtAutor";
            this.TxtAutor.Size = new System.Drawing.Size(185, 20);
            this.TxtAutor.TabIndex = 3;
            // 
            // Picturebook
            // 
            this.Picturebook.Location = new System.Drawing.Point(175, 102);
            this.Picturebook.Name = "Picturebook";
            this.Picturebook.Size = new System.Drawing.Size(100, 129);
            this.Picturebook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Picturebook.TabIndex = 5;
            this.Picturebook.TabStop = false;
            // 
            // TxtPreco
            // 
            this.TxtPreco.Location = new System.Drawing.Point(175, 334);
            this.TxtPreco.Name = "TxtPreco";
            this.TxtPreco.Size = new System.Drawing.Size(185, 20);
            this.TxtPreco.TabIndex = 7;
            // 
            // Btnimage
            // 
            this.Btnimage.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Btnimage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btnimage.Location = new System.Drawing.Point(281, 208);
            this.Btnimage.Name = "Btnimage";
            this.Btnimage.Size = new System.Drawing.Size(111, 23);
            this.Btnimage.TabIndex = 8;
            this.Btnimage.Text = "Selecionar foto";
            this.Btnimage.UseVisualStyleBackColor = false;
            this.Btnimage.Click += new System.EventHandler(this.Btnimage_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-5, -16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(808, 473);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Txtquant
            // 
            this.Txtquant.Location = new System.Drawing.Point(175, 383);
            this.Txtquant.Name = "Txtquant";
            this.Txtquant.Size = new System.Drawing.Size(185, 20);
            this.Txtquant.TabIndex = 12;
            // 
            // CbFaixaEtaria
            // 
            this.CbFaixaEtaria.FormattingEnabled = true;
            this.CbFaixaEtaria.Location = new System.Drawing.Point(175, 411);
            this.CbFaixaEtaria.Name = "CbFaixaEtaria";
            this.CbFaixaEtaria.Size = new System.Drawing.Size(121, 21);
            this.CbFaixaEtaria.TabIndex = 13;
            // 
            // CbEditora
            // 
            this.CbEditora.FormattingEnabled = true;
            this.CbEditora.Location = new System.Drawing.Point(175, 307);
            this.CbEditora.Name = "CbEditora";
            this.CbEditora.Size = new System.Drawing.Size(185, 21);
            this.CbEditora.TabIndex = 16;
            // 
            // ClbGenero
            // 
            this.ClbGenero.FormattingEnabled = true;
            this.ClbGenero.Location = new System.Drawing.Point(366, 249);
            this.ClbGenero.Name = "ClbGenero";
            this.ClbGenero.Size = new System.Drawing.Size(120, 154);
            this.ClbGenero.TabIndex = 18;
            this.ClbGenero.SelectedIndexChanged += new System.EventHandler(this.ClbGenero_SelectedIndexChanged);
            // 
            // TxtYears
            // 
            this.TxtYears.Location = new System.Drawing.Point(553, 76);
            this.TxtYears.Name = "TxtYears";
            this.TxtYears.Size = new System.Drawing.Size(175, 20);
            this.TxtYears.TabIndex = 19;
            this.TxtYears.Text = "Ano de Publicação";
            this.TxtYears.TextChanged += new System.EventHandler(this.TxtYears_TextChanged);
            this.TxtYears.Enter += new System.EventHandler(this.TxtYears_Enter);
            this.TxtYears.Leave += new System.EventHandler(this.TxtYears_Leave);
            // 
            // TxtPages
            // 
            this.TxtPages.Location = new System.Drawing.Point(553, 102);
            this.TxtPages.Name = "TxtPages";
            this.TxtPages.Size = new System.Drawing.Size(175, 20);
            this.TxtPages.TabIndex = 20;
            this.TxtPages.Text = "Num páginas";
            this.TxtPages.Enter += new System.EventHandler(this.TxtPages_Enter);
            this.TxtPages.Leave += new System.EventHandler(this.TxtPages_Leave);
            // 
            // TxtLanguage
            // 
            this.TxtLanguage.Location = new System.Drawing.Point(553, 128);
            this.TxtLanguage.Name = "TxtLanguage";
            this.TxtLanguage.Size = new System.Drawing.Size(175, 20);
            this.TxtLanguage.TabIndex = 21;
            this.TxtLanguage.Text = "Idioma";
            this.TxtLanguage.Enter += new System.EventHandler(this.TxtLanguage_Enter);
            this.TxtLanguage.Leave += new System.EventHandler(this.TxtLanguage_Leave);
            // 
            // TxtDescription
            // 
            this.TxtDescription.Location = new System.Drawing.Point(553, 167);
            this.TxtDescription.Name = "TxtDescription";
            this.TxtDescription.Size = new System.Drawing.Size(202, 20);
            this.TxtDescription.TabIndex = 22;
            this.TxtDescription.Text = "Descrição do livro";
            this.TxtDescription.TextChanged += new System.EventHandler(this.TxtDescription_TextChanged);
            this.TxtDescription.Enter += new System.EventHandler(this.TxtDescription_Enter);
            this.TxtDescription.Leave += new System.EventHandler(this.TxtDescription_Leave);
            // 
            // TxtNacionalidade
            // 
            this.TxtNacionalidade.Location = new System.Drawing.Point(553, 193);
            this.TxtNacionalidade.Name = "TxtNacionalidade";
            this.TxtNacionalidade.Size = new System.Drawing.Size(206, 20);
            this.TxtNacionalidade.TabIndex = 23;
            this.TxtNacionalidade.Text = "Nacionalidade do Autor";
            this.TxtNacionalidade.Enter += new System.EventHandler(this.TxtNacionalidade_Enter);
            this.TxtNacionalidade.Leave += new System.EventHandler(this.TxtNacionalidade_Leave);
            // 
            // TxtBiografia
            // 
            this.TxtBiografia.Location = new System.Drawing.Point(553, 219);
            this.TxtBiografia.Name = "TxtBiografia";
            this.TxtBiografia.Size = new System.Drawing.Size(206, 20);
            this.TxtBiografia.TabIndex = 24;
            this.TxtBiografia.Text = "Biografia do Autor";
            this.TxtBiografia.Enter += new System.EventHandler(this.TxtBiografia_Enter);
            this.TxtBiografia.Leave += new System.EventHandler(this.TxtBiografia_Leave);
            // 
            // Telaadicionarlivro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TxtBiografia);
            this.Controls.Add(this.TxtNacionalidade);
            this.Controls.Add(this.TxtDescription);
            this.Controls.Add(this.TxtLanguage);
            this.Controls.Add(this.TxtPages);
            this.Controls.Add(this.TxtYears);
            this.Controls.Add(this.ClbGenero);
            this.Controls.Add(this.CbEditora);
            this.Controls.Add(this.CbFaixaEtaria);
            this.Controls.Add(this.Txtquant);
            this.Controls.Add(this.Btnadd);
            this.Controls.Add(this.TxtPreco);
            this.Controls.Add(this.TxtAutor);
            this.Controls.Add(this.Txtnamebook);
            this.Controls.Add(this.Btnimage);
            this.Controls.Add(this.Picturebook);
            this.Controls.Add(this.pictureBox2);
            this.Name = "Telaadicionarlivro";
            this.Text = "Telaadicionarlivro";
            this.Load += new System.EventHandler(this.Telaadicionarlivro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Picturebook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Btnadd;
        private System.Windows.Forms.TextBox Txtnamebook;
        private System.Windows.Forms.TextBox TxtAutor;
        private System.Windows.Forms.PictureBox Picturebook;
        private System.Windows.Forms.TextBox TxtPreco;
        private System.Windows.Forms.Button Btnimage;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox Txtquant;
        private System.Windows.Forms.ComboBox CbFaixaEtaria;
        private System.Windows.Forms.ComboBox CbEditora;
        private System.Windows.Forms.CheckedListBox ClbGenero;
        private System.Windows.Forms.TextBox TxtYears;
        private System.Windows.Forms.TextBox TxtPages;
        private System.Windows.Forms.TextBox TxtLanguage;
        private System.Windows.Forms.TextBox TxtDescription;
        private System.Windows.Forms.TextBox TxtNacionalidade;
        private System.Windows.Forms.TextBox TxtBiografia;
    }
}