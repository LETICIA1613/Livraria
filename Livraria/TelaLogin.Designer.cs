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
            this.TextCadastre2 = new System.Windows.Forms.TextBox();
            this.TextCadastre4 = new System.Windows.Forms.TextBox();
            this.TextPW2 = new System.Windows.Forms.TextBox();
            this.NextCadastre2 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Cadastredate = new System.Windows.Forms.DateTimePicker();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.directoryEntry2 = new System.DirectoryServices.DirectoryEntry();
            this.datewrite = new System.Windows.Forms.Label();
            this.Textname = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // TextEmail2
            // 
            this.TextEmail2.Location = new System.Drawing.Point(89, 196);
            this.TextEmail2.Name = "TextEmail2";
            this.TextEmail2.Size = new System.Drawing.Size(279, 20);
            this.TextEmail2.TabIndex = 1;
            this.TextEmail2.Text = "E-mail";
            this.TextEmail2.Click += new System.EventHandler(this.TextEmail2_Click);
            this.TextEmail2.TextChanged += new System.EventHandler(this.TextEmail2_TextChanged);
            this.TextEmail2.Enter += new System.EventHandler(this.TextEmail2_Enter);
            this.TextEmail2.Leave += new System.EventHandler(this.TextEmail2_Leave);
            // 
            // TextPW3
            // 
            this.TextPW3.Location = new System.Drawing.Point(89, 242);
            this.TextPW3.Name = "TextPW3";
            this.TextPW3.Size = new System.Drawing.Size(279, 20);
            this.TextPW3.TabIndex = 2;
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
            this.label1.TabIndex = 3;
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
            // 
            // TextCadastre2
            // 
            this.TextCadastre2.Location = new System.Drawing.Point(450, 152);
            this.TextCadastre2.Name = "TextCadastre2";
            this.TextCadastre2.Size = new System.Drawing.Size(287, 20);
            this.TextCadastre2.TabIndex = 6;
            this.TextCadastre2.Text = "Nome";
            this.TextCadastre2.Click += new System.EventHandler(this.TextCadastre2_Click);
            this.TextCadastre2.Enter += new System.EventHandler(this.TextCadastre2_Enter);
            this.TextCadastre2.Leave += new System.EventHandler(this.TextCadastre2_Leave);
            // 
            // TextCadastre4
            // 
            this.TextCadastre4.Location = new System.Drawing.Point(450, 196);
            this.TextCadastre4.Name = "TextCadastre4";
            this.TextCadastre4.Size = new System.Drawing.Size(287, 20);
            this.TextCadastre4.TabIndex = 8;
            this.TextCadastre4.Text = "E-mail";
            this.TextCadastre4.Click += new System.EventHandler(this.TextCadastre4_Click);
            this.TextCadastre4.TextChanged += new System.EventHandler(this.TextCadastre4_TextChanged);
            this.TextCadastre4.Enter += new System.EventHandler(this.TextCadastre4_Enter);
            this.TextCadastre4.Leave += new System.EventHandler(this.TextCadastre4_Leave);
            // 
            // TextPW2
            // 
            this.TextPW2.Location = new System.Drawing.Point(450, 242);
            this.TextPW2.Name = "TextPW2";
            this.TextPW2.Size = new System.Drawing.Size(287, 20);
            this.TextPW2.TabIndex = 9;
            this.TextPW2.Text = "Senha";
            this.TextPW2.Click += new System.EventHandler(this.TextPW2_Click);
            this.TextPW2.Enter += new System.EventHandler(this.TextPW2_Enter);
            this.TextPW2.Leave += new System.EventHandler(this.TextPW2_Leave);
            // 
            // NextCadastre2
            // 
            this.NextCadastre2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.NextCadastre2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.NextCadastre2.Location = new System.Drawing.Point(662, 348);
            this.NextCadastre2.Name = "NextCadastre2";
            this.NextCadastre2.Size = new System.Drawing.Size(75, 23);
            this.NextCadastre2.TabIndex = 10;
            this.NextCadastre2.Text = "Próximo";
            this.NextCadastre2.UseVisualStyleBackColor = false;
            this.NextCadastre2.Click += new System.EventHandler(this.NextCadastre2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-47, -1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(894, 452);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // Cadastredate
            // 
            this.Cadastredate.Location = new System.Drawing.Point(450, 298);
            this.Cadastredate.Name = "Cadastredate";
            this.Cadastredate.Size = new System.Drawing.Size(287, 20);
            this.Cadastredate.TabIndex = 16;
            // 
            // datewrite
            // 
            this.datewrite.AutoSize = true;
            this.datewrite.BackColor = System.Drawing.Color.LightBlue;
            this.datewrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datewrite.Location = new System.Drawing.Point(447, 279);
            this.datewrite.Name = "datewrite";
            this.datewrite.Size = new System.Drawing.Size(136, 16);
            this.datewrite.TabIndex = 17;
            this.datewrite.Text = "Data de Nascimento :";
            this.datewrite.Click += new System.EventHandler(this.datewrite_Click);
            // 
            // Textname
            // 
            this.Textname.Location = new System.Drawing.Point(88, 152);
            this.Textname.Name = "Textname";
            this.Textname.Size = new System.Drawing.Size(280, 20);
            this.Textname.TabIndex = 18;
            this.Textname.Text = "Nome";
            this.Textname.Click += new System.EventHandler(this.Textname_Click);
            this.Textname.TextChanged += new System.EventHandler(this.Textname_TextChanged);
            this.Textname.Enter += new System.EventHandler(this.Textname_Enter);
            this.Textname.Leave += new System.EventHandler(this.Textname_Leave);
            // 
            // TelaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Textname);
            this.Controls.Add(this.datewrite);
            this.Controls.Add(this.Cadastredate);
            this.Controls.Add(this.BntNext1);
            this.Controls.Add(this.TextPW3);
            this.Controls.Add(this.TextEmail2);
            this.Controls.Add(this.NextCadastre2);
            this.Controls.Add(this.TextPW2);
            this.Controls.Add(this.TextCadastre4);
            this.Controls.Add(this.TextCadastre2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Name = "TelaLogin";
            this.Load += new System.EventHandler(this.TelaLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DateTimePicker Cadastredate;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.DirectoryServices.DirectoryEntry directoryEntry2;
        private System.Windows.Forms.Label datewrite;
        private System.Windows.Forms.TextBox Textname;
    }
}