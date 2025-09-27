namespace Livraria
{
    partial class LivroCard
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

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.PicCapa = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblAutor = new System.Windows.Forms.Label();
            this.lblPreco = new System.Windows.Forms.Label();
            this.BtnAddbook = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PicCapa)).BeginInit();
            this.SuspendLayout();
            // 
            // PicCapa
            // 
            this.PicCapa.Location = new System.Drawing.Point(113, 28);
            this.PicCapa.Name = "PicCapa";
            this.PicCapa.Size = new System.Drawing.Size(122, 196);
            this.PicCapa.TabIndex = 0;
            this.PicCapa.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(144, 227);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(57, 20);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "label1";
            this.lblTitulo.Click += new System.EventHandler(this.Titulo_Click);
            // 
            // lblAutor
            // 
            this.lblAutor.AutoSize = true;
            this.lblAutor.Location = new System.Drawing.Point(154, 259);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(35, 13);
            this.lblAutor.TabIndex = 2;
            this.lblAutor.Text = "label1";
            // 
            // lblPreco
            // 
            this.lblPreco.AutoSize = true;
            this.lblPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreco.Location = new System.Drawing.Point(205, 282);
            this.lblPreco.Name = "lblPreco";
            this.lblPreco.Size = new System.Drawing.Size(60, 24);
            this.lblPreco.TabIndex = 3;
            this.lblPreco.Text = "label1";
            // 
            // BtnAddbook
            // 
            this.BtnAddbook.Location = new System.Drawing.Point(126, 321);
            this.BtnAddbook.Name = "BtnAddbook";
            this.BtnAddbook.Size = new System.Drawing.Size(75, 23);
            this.BtnAddbook.TabIndex = 4;
            this.BtnAddbook.Text = "button1";
            this.BtnAddbook.UseVisualStyleBackColor = true;
            // 
            // LivroCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnAddbook);
            this.Controls.Add(this.lblPreco);
            this.Controls.Add(this.lblAutor);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.PicCapa);
            this.Name = "LivroCard";
            this.Size = new System.Drawing.Size(332, 382);
            ((System.ComponentModel.ISupportInitialize)(this.PicCapa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicCapa;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblAutor;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.Button BtnAddbook;
    }
}
