namespace Livraria
{
    partial class TelaLogin
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
            this.TextEmail2 = new System.Windows.Forms.TextBox();
            this.TextPW3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BntNext1 = new System.Windows.Forms.Button();
            this.TextCadastre2 = new System.Windows.Forms.TextBox();
            this.TextCadastre4 = new System.Windows.Forms.TextBox();
            this.TextPW2 = new System.Windows.Forms.TextBox();
            this.NextCadastre2 = new System.Windows.Forms.Button();
            this.Txtborn = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TextEmail2
            // 
            this.TextEmail2.Location = new System.Drawing.Point(89, 152);
            this.TextEmail2.Name = "TextEmail2";
            this.TextEmail2.Size = new System.Drawing.Size(279, 20);
            this.TextEmail2.TabIndex = 1;
            this.TextEmail2.Text = "E-mail";
            // 
            // TextPW3
            // 
            this.TextPW3.Location = new System.Drawing.Point(89, 207);
            this.TextPW3.Name = "TextPW3";
            this.TextPW3.Size = new System.Drawing.Size(279, 20);
            this.TextPW3.TabIndex = 2;
            this.TextPW3.Text = "Senha";
            this.TextPW3.TextChanged += new System.EventHandler(this.TextPW3_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("RomanD", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 35);
            this.label1.TabIndex = 3;
            // 
            // BntNext1
            // 
            this.BntNext1.Location = new System.Drawing.Point(293, 260);
            this.BntNext1.Name = "BntNext1";
            this.BntNext1.Size = new System.Drawing.Size(75, 23);
            this.BntNext1.TabIndex = 4;
            this.BntNext1.Text = "Próximo";
            this.BntNext1.UseVisualStyleBackColor = true;
            this.BntNext1.Click += new System.EventHandler(this.BntNext1_Click);
            // 
            // TextCadastre2
            // 
            this.TextCadastre2.Location = new System.Drawing.Point(450, 152);
            this.TextCadastre2.Name = "TextCadastre2";
            this.TextCadastre2.Size = new System.Drawing.Size(287, 20);
            this.TextCadastre2.TabIndex = 6;
            this.TextCadastre2.Text = "Nome";
            // 
            // TextCadastre4
            // 
            this.TextCadastre4.Location = new System.Drawing.Point(450, 196);
            this.TextCadastre4.Name = "TextCadastre4";
            this.TextCadastre4.Size = new System.Drawing.Size(287, 20);
            this.TextCadastre4.TabIndex = 8;
            this.TextCadastre4.Text = "E-mail";
            // 
            // TextPW2
            // 
            this.TextPW2.Location = new System.Drawing.Point(450, 242);
            this.TextPW2.Name = "TextPW2";
            this.TextPW2.Size = new System.Drawing.Size(287, 20);
            this.TextPW2.TabIndex = 9;
            this.TextPW2.Text = "Senha";
            // 
            // NextCadastre2
            // 
            this.NextCadastre2.Location = new System.Drawing.Point(662, 348);
            this.NextCadastre2.Name = "NextCadastre2";
            this.NextCadastre2.Size = new System.Drawing.Size(75, 23);
            this.NextCadastre2.TabIndex = 10;
            this.NextCadastre2.Text = "Próximo";
            this.NextCadastre2.UseVisualStyleBackColor = true;
            this.NextCadastre2.Click += new System.EventHandler(this.NextCadastre2_Click);
            // 
            // Txtborn
            // 
            this.Txtborn.Location = new System.Drawing.Point(450, 292);
            this.Txtborn.Name = "Txtborn";
            this.Txtborn.Size = new System.Drawing.Size(287, 20);
            this.Txtborn.TabIndex = 11;
            this.Txtborn.Text = "Data de Nascimento";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Livraria.Properties.Resources.Title_of_your_Brainstorm_Whiteboard__1_;
            this.pictureBox1.Location = new System.Drawing.Point(-94, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(988, 457);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // TelaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NextCadastre2);
            this.Controls.Add(this.Txtborn);
            this.Controls.Add(this.TextPW2);
            this.Controls.Add(this.TextCadastre4);
            this.Controls.Add(this.TextCadastre2);
            this.Controls.Add(this.BntNext1);
            this.Controls.Add(this.TextPW3);
            this.Controls.Add(this.TextEmail2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "TelaLogin";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TextEmail2;
        private System.Windows.Forms.TextBox TextPW3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BntNext1;
        private System.Windows.Forms.TextBox TextCadastre2;
        private System.Windows.Forms.TextBox TextCadastre4;
        private System.Windows.Forms.TextBox TextPW2;
        private System.Windows.Forms.Button NextCadastre2;
        private System.Windows.Forms.TextBox Txtborn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}