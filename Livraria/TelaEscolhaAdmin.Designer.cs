namespace Livraria
{
    partial class TelaEscolhaAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaEscolhaAdmin));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Btnescolhaadd = new System.Windows.Forms.Button();
            this.Btnescolhagestão = new System.Windows.Forms.Button();
            this.BtnTelaEntrada = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Btnescolhaadd
            // 
            this.Btnescolhaadd.BackColor = System.Drawing.Color.Pink;
            this.Btnescolhaadd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btnescolhaadd.Location = new System.Drawing.Point(200, 179);
            this.Btnescolhaadd.Name = "Btnescolhaadd";
            this.Btnescolhaadd.Size = new System.Drawing.Size(193, 27);
            this.Btnescolhaadd.TabIndex = 1;
            this.Btnescolhaadd.Text = "Adicionar Livros";
            this.Btnescolhaadd.UseVisualStyleBackColor = false;
            this.Btnescolhaadd.Click += new System.EventHandler(this.Btnescolhaadd_Click);
            // 
            // Btnescolhagestão
            // 
            this.Btnescolhagestão.BackColor = System.Drawing.Color.Pink;
            this.Btnescolhagestão.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btnescolhagestão.Location = new System.Drawing.Point(200, 222);
            this.Btnescolhagestão.Name = "Btnescolhagestão";
            this.Btnescolhagestão.Size = new System.Drawing.Size(193, 29);
            this.Btnescolhagestão.TabIndex = 2;
            this.Btnescolhagestão.Text = "Gestão de Estoque";
            this.Btnescolhagestão.UseVisualStyleBackColor = false;
            this.Btnescolhagestão.Click += new System.EventHandler(this.Btnescolhagestão_Click);
            // 
            // BtnTelaEntrada
            // 
            this.BtnTelaEntrada.BackColor = System.Drawing.Color.Pink;
            this.BtnTelaEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnTelaEntrada.Location = new System.Drawing.Point(200, 266);
            this.BtnTelaEntrada.Name = "BtnTelaEntrada";
            this.BtnTelaEntrada.Size = new System.Drawing.Size(193, 26);
            this.BtnTelaEntrada.TabIndex = 3;
            this.BtnTelaEntrada.Text = "Arrumar Tela Catálogo";
            this.BtnTelaEntrada.UseVisualStyleBackColor = false;
            this.BtnTelaEntrada.Click += new System.EventHandler(this.BtnTelaEntrada_Click);
            // 
            // TelaEscolhaAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnTelaEntrada);
            this.Controls.Add(this.Btnescolhagestão);
            this.Controls.Add(this.Btnescolhaadd);
            this.Controls.Add(this.pictureBox1);
            this.Name = "TelaEscolhaAdmin";
            this.Text = "TelaEscolhaAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Btnescolhaadd;
        private System.Windows.Forms.Button Btnescolhagestão;
        private System.Windows.Forms.Button BtnTelaEntrada;
    }
}