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
            this.lblEditora = new System.Windows.Forms.Label();
            this.BtnAddbook = new System.Windows.Forms.Button();
            this.lblPreco = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicCapa)).BeginInit();
            this.SuspendLayout();
            // 
            // PicCapa
            // 
            this.PicCapa.Location = new System.Drawing.Point(29, 13);
            this.PicCapa.Name = "PicCapa";
            this.PicCapa.Size = new System.Drawing.Size(94, 167);
            this.PicCapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicCapa.TabIndex = 0;
            this.PicCapa.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(28, 183);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(57, 20);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "label1";
            this.lblTitulo.Click += new System.EventHandler(this.Titulo_Click);
            // 
            // lblEditora
            // 
            this.lblEditora.AutoSize = true;
            this.lblEditora.Location = new System.Drawing.Point(50, 203);
            this.lblEditora.Name = "lblEditora";
            this.lblEditora.Size = new System.Drawing.Size(35, 13);
            this.lblEditora.TabIndex = 2;
            this.lblEditora.Text = "label1";
            this.lblEditora.Click += new System.EventHandler(this.lblEditora_Click);
            // 
            // BtnAddbook
            // 
            this.BtnAddbook.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnAddbook.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAddbook.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddbook.Location = new System.Drawing.Point(19, 253);
            this.BtnAddbook.Name = "BtnAddbook";
            this.BtnAddbook.Size = new System.Drawing.Size(91, 23);
            this.BtnAddbook.TabIndex = 4;
            this.BtnAddbook.Text = "Adicionar 🛒";
            this.BtnAddbook.UseVisualStyleBackColor = false;
            this.BtnAddbook.Click += new System.EventHandler(this.BtnAddbook_Click);
            // 
            // lblPreco
            // 
            this.lblPreco.AutoSize = true;
            this.lblPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreco.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblPreco.Location = new System.Drawing.Point(63, 226);
            this.lblPreco.Name = "lblPreco";
            this.lblPreco.Size = new System.Drawing.Size(66, 24);
            this.lblPreco.TabIndex = 3;
            this.lblPreco.Text = "label1";
            // 
            // LivroCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnAddbook);
            this.Controls.Add(this.lblPreco);
            this.Controls.Add(this.lblEditora);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.PicCapa);
            this.Name = "LivroCard";
            this.Size = new System.Drawing.Size(159, 295);
            this.Load += new System.EventHandler(this.LivroCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicCapa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicCapa;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEditora;
        private System.Windows.Forms.Button BtnAddbook;
        private System.Windows.Forms.Label lblPreco;
    }
}
