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
            this.PbCapa2 = new System.Windows.Forms.PictureBox();
            this.LblTitulo2 = new System.Windows.Forms.Label();
            this.LblAutor2 = new System.Windows.Forms.Label();
            this.LblGenero2 = new System.Windows.Forms.Label();
            this.LblPreco2 = new System.Windows.Forms.Label();
            this.BtnComprar1 = new System.Windows.Forms.Button();
            this.LblNacionalidade = new System.Windows.Forms.Label();
            this.RtbDescricao = new System.Windows.Forms.RichTextBox();
            this.RtbBiografia = new System.Windows.Forms.RichTextBox();
            this.LblFaixa2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbCapa2)).BeginInit();
            this.SuspendLayout();
            // 
            // PbCapa2
            // 
            this.PbCapa2.Location = new System.Drawing.Point(29, 36);
            this.PbCapa2.Name = "PbCapa2";
            this.PbCapa2.Size = new System.Drawing.Size(143, 255);
            this.PbCapa2.TabIndex = 0;
            this.PbCapa2.TabStop = false;
            // 
            // LblTitulo2
            // 
            this.LblTitulo2.AutoSize = true;
            this.LblTitulo2.Location = new System.Drawing.Point(322, 36);
            this.LblTitulo2.Name = "LblTitulo2";
            this.LblTitulo2.Size = new System.Drawing.Size(35, 13);
            this.LblTitulo2.TabIndex = 1;
            this.LblTitulo2.Text = "label1";
            // 
            // LblAutor2
            // 
            this.LblAutor2.AutoSize = true;
            this.LblAutor2.Location = new System.Drawing.Point(322, 62);
            this.LblAutor2.Name = "LblAutor2";
            this.LblAutor2.Size = new System.Drawing.Size(35, 13);
            this.LblAutor2.TabIndex = 2;
            this.LblAutor2.Text = "label1";
            // 
            // LblGenero2
            // 
            this.LblGenero2.AutoSize = true;
            this.LblGenero2.Location = new System.Drawing.Point(322, 94);
            this.LblGenero2.Name = "LblGenero2";
            this.LblGenero2.Size = new System.Drawing.Size(35, 13);
            this.LblGenero2.TabIndex = 3;
            this.LblGenero2.Text = "label1";
            // 
            // LblPreco2
            // 
            this.LblPreco2.AutoSize = true;
            this.LblPreco2.Location = new System.Drawing.Point(322, 125);
            this.LblPreco2.Name = "LblPreco2";
            this.LblPreco2.Size = new System.Drawing.Size(35, 13);
            this.LblPreco2.TabIndex = 4;
            this.LblPreco2.Text = "label1";
            // 
            // BtnComprar1
            // 
            this.BtnComprar1.Location = new System.Drawing.Point(713, 415);
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
            this.LblNacionalidade.Location = new System.Drawing.Point(321, 156);
            this.LblNacionalidade.Name = "LblNacionalidade";
            this.LblNacionalidade.Size = new System.Drawing.Size(35, 13);
            this.LblNacionalidade.TabIndex = 7;
            this.LblNacionalidade.Text = "label1";
            // 
            // RtbDescricao
            // 
            this.RtbDescricao.Location = new System.Drawing.Point(324, 204);
            this.RtbDescricao.Name = "RtbDescricao";
            this.RtbDescricao.ReadOnly = true;
            this.RtbDescricao.Size = new System.Drawing.Size(378, 96);
            this.RtbDescricao.TabIndex = 8;
            this.RtbDescricao.Text = "";
            // 
            // RtbBiografia
            // 
            this.RtbBiografia.Location = new System.Drawing.Point(324, 306);
            this.RtbBiografia.Name = "RtbBiografia";
            this.RtbBiografia.ReadOnly = true;
            this.RtbBiografia.Size = new System.Drawing.Size(378, 96);
            this.RtbBiografia.TabIndex = 9;
            this.RtbBiografia.Text = "";
            // 
            // LblFaixa2
            // 
            this.LblFaixa2.AutoSize = true;
            this.LblFaixa2.Location = new System.Drawing.Point(324, 185);
            this.LblFaixa2.Name = "LblFaixa2";
            this.LblFaixa2.Size = new System.Drawing.Size(35, 13);
            this.LblFaixa2.TabIndex = 10;
            this.LblFaixa2.Text = "label1";
            // 
            // TelaPerfilLivro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LblFaixa2);
            this.Controls.Add(this.RtbBiografia);
            this.Controls.Add(this.RtbDescricao);
            this.Controls.Add(this.LblNacionalidade);
            this.Controls.Add(this.BtnComprar1);
            this.Controls.Add(this.LblPreco2);
            this.Controls.Add(this.LblGenero2);
            this.Controls.Add(this.LblAutor2);
            this.Controls.Add(this.LblTitulo2);
            this.Controls.Add(this.PbCapa2);
            this.Name = "TelaPerfilLivro";
            this.Text = "TelaPerfilLivro";
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
        private System.Windows.Forms.RichTextBox RtbDescricao;
        private System.Windows.Forms.RichTextBox RtbBiografia;
        private System.Windows.Forms.Label LblFaixa2;
    }
}