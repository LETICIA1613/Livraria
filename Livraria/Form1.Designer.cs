namespace Livraria
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BtnCadastre0 = new System.Windows.Forms.Button();
            this.imagementrar = new System.Windows.Forms.PictureBox();
            this.Btnadmin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imagementrar)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCadastre0
            // 
            this.BtnCadastre0.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BtnCadastre0.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnCadastre0.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCadastre0.Location = new System.Drawing.Point(272, 172);
            this.BtnCadastre0.Name = "BtnCadastre0";
            this.BtnCadastre0.Size = new System.Drawing.Size(250, 89);
            this.BtnCadastre0.TabIndex = 1;
            this.BtnCadastre0.Text = "ENTRAR";
            this.BtnCadastre0.UseVisualStyleBackColor = false;
            this.BtnCadastre0.Click += new System.EventHandler(this.BtnCadastre0_Click);
            // 
            // imagementrar
            // 
            this.imagementrar.Image = ((System.Drawing.Image)(resources.GetObject("imagementrar.Image")));
            this.imagementrar.Location = new System.Drawing.Point(-8, -2);
            this.imagementrar.Name = "imagementrar";
            this.imagementrar.Size = new System.Drawing.Size(813, 462);
            this.imagementrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagementrar.TabIndex = 3;
            this.imagementrar.TabStop = false;
            // 
            // Btnadmin
            // 
            this.Btnadmin.BackColor = System.Drawing.Color.LightPink;
            this.Btnadmin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btnadmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnadmin.Location = new System.Drawing.Point(272, 267);
            this.Btnadmin.Name = "Btnadmin";
            this.Btnadmin.Size = new System.Drawing.Size(250, 31);
            this.Btnadmin.TabIndex = 4;
            this.Btnadmin.Text = "Entrar como Admin?";
            this.Btnadmin.UseVisualStyleBackColor = false;
            this.Btnadmin.Click += new System.EventHandler(this.Btnadmin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btnadmin);
            this.Controls.Add(this.BtnCadastre0);
            this.Controls.Add(this.imagementrar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imagementrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnCadastre0;
        private System.Windows.Forms.PictureBox imagementrar;
        private System.Windows.Forms.Button Btnadmin;
    }
}

