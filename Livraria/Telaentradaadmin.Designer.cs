namespace Livraria
{
    partial class Telaentradaadmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Telaentradaadmin));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Txtpassword = new System.Windows.Forms.TextBox();
            this.btnpassword = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, -14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(805, 479);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Txtpassword
            // 
            this.Txtpassword.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Txtpassword.Location = new System.Drawing.Point(256, 176);
            this.Txtpassword.Name = "Txtpassword";
            this.Txtpassword.Size = new System.Drawing.Size(243, 20);
            this.Txtpassword.TabIndex = 1;
            this.Txtpassword.Text = "Senha do admin";
            this.Txtpassword.UseWaitCursor = true;
            this.Txtpassword.TextChanged += new System.EventHandler(this.Txtpassword_TextChanged);
            this.Txtpassword.Enter += new System.EventHandler(this.Txtpassword_Enter);
            // 
            // btnpassword
            // 
            this.btnpassword.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpassword.Location = new System.Drawing.Point(423, 202);
            this.btnpassword.Name = "btnpassword";
            this.btnpassword.Size = new System.Drawing.Size(76, 22);
            this.btnpassword.TabIndex = 0;
            this.btnpassword.Text = "Entrar";
            this.btnpassword.UseVisualStyleBackColor = false;
            this.btnpassword.Click += new System.EventHandler(this.btnpassword_Click);
            // 
            // Telaentradaadmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnpassword);
            this.Controls.Add(this.Txtpassword);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Telaentradaadmin";
            this.Text = "Telaentradaadmin";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox Txtpassword;
        private System.Windows.Forms.Button btnpassword;
    }
}