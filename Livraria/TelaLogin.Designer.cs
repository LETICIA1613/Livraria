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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaLogin));
            this.TextEmail2 = new System.Windows.Forms.TextBox();
            this.TextPW3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BntNext1 = new System.Windows.Forms.Button();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.directoryEntry2 = new System.DirectoryServices.DirectoryEntry();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.PictureLogin = new System.Windows.Forms.PictureBox();
            this.Pictureolhos2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pictureolhos2)).BeginInit();
            this.SuspendLayout();
            // 
            // TextEmail2
            // 
            this.TextEmail2.Location = new System.Drawing.Point(89, 172);
            this.TextEmail2.Name = "TextEmail2";
            this.TextEmail2.Size = new System.Drawing.Size(279, 20);
            this.TextEmail2.TabIndex = 2;
            this.TextEmail2.Text = "E-mail";
            this.TextEmail2.Click += new System.EventHandler(this.TextEmail2_Click);
            this.TextEmail2.TextChanged += new System.EventHandler(this.TextEmail2_TextChanged);
            this.TextEmail2.Enter += new System.EventHandler(this.TextEmail2_Enter);
            this.TextEmail2.Leave += new System.EventHandler(this.TextEmail2_Leave);
            // 
            // TextPW3
            // 
            this.TextPW3.Location = new System.Drawing.Point(89, 222);
            this.TextPW3.Name = "TextPW3";
            this.TextPW3.Size = new System.Drawing.Size(279, 20);
            this.TextPW3.TabIndex = 3;
            this.TextPW3.Text = "Senha";
            this.TextPW3.Click += new System.EventHandler(this.TextPW3_Click);
            this.TextPW3.TextChanged += new System.EventHandler(this.TextPW3_TextChanged);
            this.TextPW3.Enter += new System.EventHandler(this.TextPW3_Enter);
            this.TextPW3.Leave += new System.EventHandler(this.TextPW3_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 29);
            this.label1.TabIndex = 1;
            // 
            // BntNext1
            // 
            this.BntNext1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BntNext1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BntNext1.Location = new System.Drawing.Point(293, 295);
            this.BntNext1.Name = "BntNext1";
            this.BntNext1.Size = new System.Drawing.Size(75, 23);
            this.BntNext1.TabIndex = 4;
            this.BntNext1.Text = "Próximo";
            this.BntNext1.UseVisualStyleBackColor = false;
            this.BntNext1.Click += new System.EventHandler(this.BntNext1_Click_1);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.linkLabel1.Location = new System.Drawing.Point(184, 254);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(184, 13);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Não tenho um Cadastro! Cadastrar-se";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // PictureLogin
            // 
            this.PictureLogin.Image = ((System.Drawing.Image)(resources.GetObject("PictureLogin.Image")));
            this.PictureLogin.Location = new System.Drawing.Point(-1, -49);
            this.PictureLogin.Name = "PictureLogin";
            this.PictureLogin.Size = new System.Drawing.Size(805, 545);
            this.PictureLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureLogin.TabIndex = 17;
            this.PictureLogin.TabStop = false;
            // 
            // Pictureolhos2
            // 
            this.Pictureolhos2.Image = ((System.Drawing.Image)(resources.GetObject("Pictureolhos2.Image")));
            this.Pictureolhos2.Location = new System.Drawing.Point(333, 222);
            this.Pictureolhos2.Name = "Pictureolhos2";
            this.Pictureolhos2.Size = new System.Drawing.Size(35, 20);
            this.Pictureolhos2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Pictureolhos2.TabIndex = 18;
            this.Pictureolhos2.TabStop = false;
            this.Pictureolhos2.Click += new System.EventHandler(this.Pictureolhos2_Click);
            // 
            // TelaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Pictureolhos2);
            this.Controls.Add(this.BntNext1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.TextPW3);
            this.Controls.Add(this.TextEmail2);
            this.Controls.Add(this.PictureLogin);
            this.Controls.Add(this.label1);
            this.Name = "TelaLogin";
            this.Load += new System.EventHandler(this.TelaLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pictureolhos2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TextEmail2;
        private System.Windows.Forms.TextBox TextPW3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BntNext1;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.DirectoryServices.DirectoryEntry directoryEntry2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox PictureLogin;
        private System.Windows.Forms.PictureBox Pictureolhos2;
    }
}