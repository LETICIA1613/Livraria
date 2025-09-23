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
            this.TxtEditora = new System.Windows.Forms.TextBox();
            this.Picturebook = new System.Windows.Forms.PictureBox();
            this.TxtPreco = new System.Windows.Forms.TextBox();
            this.Btnimage = new System.Windows.Forms.Button();
            this.TxtGenero = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Txtquant = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Picturebook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Btnadd
            // 
            this.Btnadd.BackColor = System.Drawing.Color.Pink;
            this.Btnadd.Location = new System.Drawing.Point(401, 357);
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
            // TxtEditora
            // 
            this.TxtEditora.Location = new System.Drawing.Point(175, 308);
            this.TxtEditora.Name = "TxtEditora";
            this.TxtEditora.Size = new System.Drawing.Size(185, 20);
            this.TxtEditora.TabIndex = 4;
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
            // TxtGenero
            // 
            this.TxtGenero.Location = new System.Drawing.Point(175, 357);
            this.TxtGenero.Name = "TxtGenero";
            this.TxtGenero.Size = new System.Drawing.Size(185, 20);
            this.TxtGenero.TabIndex = 10;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-2, -10);
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
            // Telaadicionarlivro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Txtquant);
            this.Controls.Add(this.Btnadd);
            this.Controls.Add(this.TxtGenero);
            this.Controls.Add(this.TxtPreco);
            this.Controls.Add(this.TxtEditora);
            this.Controls.Add(this.TxtAutor);
            this.Controls.Add(this.Txtnamebook);
            this.Controls.Add(this.Btnimage);
            this.Controls.Add(this.Picturebook);
            this.Controls.Add(this.pictureBox2);
            this.Name = "Telaadicionarlivro";
            this.Text = "Telaadicionarlivro";
            ((System.ComponentModel.ISupportInitialize)(this.Picturebook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Btnadd;
        private System.Windows.Forms.TextBox Txtnamebook;
        private System.Windows.Forms.TextBox TxtAutor;
        private System.Windows.Forms.TextBox TxtEditora;
        private System.Windows.Forms.PictureBox Picturebook;
        private System.Windows.Forms.TextBox TxtPreco;
        private System.Windows.Forms.Button Btnimage;
        private System.Windows.Forms.TextBox TxtGenero;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox Txtquant;
    }
}