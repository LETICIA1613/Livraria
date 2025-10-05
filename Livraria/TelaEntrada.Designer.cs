namespace Livraria
{
    partial class TelaEntrada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaEntrada));
            this.Txtwrite = new System.Windows.Forms.TextBox();
            this.Txt01 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnRomance = new System.Windows.Forms.Button();
            this.Btnfantasy = new System.Windows.Forms.Button();
            this.Btnterror = new System.Windows.Forms.Button();
            this.Btnselfhelp = new System.Windows.Forms.Button();
            this.Btnsciencefiction = new System.Windows.Forms.Button();
            this.BtnComedy = new System.Windows.Forms.Button();
            this.Btnthriller = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.Btnmenu = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Btnreligious = new System.Windows.Forms.Button();
            this.FlpLivros = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Txtwrite
            // 
            this.Txtwrite.Location = new System.Drawing.Point(478, 6);
            this.Txtwrite.Name = "Txtwrite";
            this.Txtwrite.Size = new System.Drawing.Size(211, 20);
            this.Txtwrite.TabIndex = 9;
            this.Txtwrite.Text = "Digite sua busca";
            this.Txtwrite.Click += new System.EventHandler(this.Txtwrite_Click);
            this.Txtwrite.TextChanged += new System.EventHandler(this.Txtwrite_TextChanged);
            this.Txtwrite.Enter += new System.EventHandler(this.Txtwrite_Enter);
            this.Txtwrite.Leave += new System.EventHandler(this.Txtwrite_Leave);
            // 
            // Txt01
            // 
            this.Txt01.AutoSize = true;
            this.Txt01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt01.Location = new System.Drawing.Point(12, 37);
            this.Txt01.Name = "Txt01";
            this.Txt01.Size = new System.Drawing.Size(0, 13);
            this.Txt01.TabIndex = 1;
            this.Txt01.Click += new System.EventHandler(this.Txt01_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // BtnRomance
            // 
            this.BtnRomance.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BtnRomance.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnRomance.Location = new System.Drawing.Point(37, 99);
            this.BtnRomance.Name = "BtnRomance";
            this.BtnRomance.Size = new System.Drawing.Size(119, 23);
            this.BtnRomance.TabIndex = 0;
            this.BtnRomance.Text = "Romance";
            this.BtnRomance.UseVisualStyleBackColor = false;
            this.BtnRomance.Click += new System.EventHandler(this.BtnRomance_Click);
            // 
            // Btnfantasy
            // 
            this.Btnfantasy.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Btnfantasy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btnfantasy.Location = new System.Drawing.Point(37, 128);
            this.Btnfantasy.Name = "Btnfantasy";
            this.Btnfantasy.Size = new System.Drawing.Size(119, 23);
            this.Btnfantasy.TabIndex = 1;
            this.Btnfantasy.Text = "Fantasia";
            this.Btnfantasy.UseVisualStyleBackColor = false;
            this.Btnfantasy.Click += new System.EventHandler(this.Btnfantasy_Click);
            // 
            // Btnterror
            // 
            this.Btnterror.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Btnterror.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btnterror.Location = new System.Drawing.Point(37, 157);
            this.Btnterror.Name = "Btnterror";
            this.Btnterror.Size = new System.Drawing.Size(119, 23);
            this.Btnterror.TabIndex = 2;
            this.Btnterror.Text = "Terror";
            this.Btnterror.UseVisualStyleBackColor = false;
            // 
            // Btnselfhelp
            // 
            this.Btnselfhelp.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Btnselfhelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btnselfhelp.Location = new System.Drawing.Point(37, 186);
            this.Btnselfhelp.Name = "Btnselfhelp";
            this.Btnselfhelp.Size = new System.Drawing.Size(119, 23);
            this.Btnselfhelp.TabIndex = 3;
            this.Btnselfhelp.Text = "Autoajuda";
            this.Btnselfhelp.UseVisualStyleBackColor = false;
            // 
            // Btnsciencefiction
            // 
            this.Btnsciencefiction.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Btnsciencefiction.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btnsciencefiction.Location = new System.Drawing.Point(37, 215);
            this.Btnsciencefiction.Name = "Btnsciencefiction";
            this.Btnsciencefiction.Size = new System.Drawing.Size(119, 23);
            this.Btnsciencefiction.TabIndex = 4;
            this.Btnsciencefiction.Text = "Ficção Científica";
            this.Btnsciencefiction.UseVisualStyleBackColor = false;
            this.Btnsciencefiction.Click += new System.EventHandler(this.Btnsciencefiction_Click);
            // 
            // BtnComedy
            // 
            this.BtnComedy.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BtnComedy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnComedy.Location = new System.Drawing.Point(37, 244);
            this.BtnComedy.Name = "BtnComedy";
            this.BtnComedy.Size = new System.Drawing.Size(119, 23);
            this.BtnComedy.TabIndex = 5;
            this.BtnComedy.Text = "Comédia";
            this.BtnComedy.UseVisualStyleBackColor = false;
            // 
            // Btnthriller
            // 
            this.Btnthriller.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Btnthriller.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btnthriller.Location = new System.Drawing.Point(37, 273);
            this.Btnthriller.Name = "Btnthriller";
            this.Btnthriller.Size = new System.Drawing.Size(119, 23);
            this.Btnthriller.TabIndex = 6;
            this.Btnthriller.Text = "Suspense";
            this.Btnthriller.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button8.Location = new System.Drawing.Point(37, 302);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(119, 23);
            this.button8.TabIndex = 7;
            this.button8.Text = "Utopia";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // Btnmenu
            // 
            this.Btnmenu.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Btnmenu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btnmenu.Location = new System.Drawing.Point(614, 6);
            this.Btnmenu.Name = "Btnmenu";
            this.Btnmenu.Size = new System.Drawing.Size(75, 20);
            this.Btnmenu.TabIndex = 10;
            this.Btnmenu.Text = "Buscar";
            this.Btnmenu.UseVisualStyleBackColor = false;
            this.Btnmenu.Click += new System.EventHandler(this.Btnmenu_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Btnreligious
            // 
            this.Btnreligious.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Btnreligious.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btnreligious.Location = new System.Drawing.Point(37, 331);
            this.Btnreligious.Name = "Btnreligious";
            this.Btnreligious.Size = new System.Drawing.Size(119, 23);
            this.Btnreligious.TabIndex = 8;
            this.Btnreligious.Text = "Religioso";
            this.Btnreligious.UseVisualStyleBackColor = false;
            // 
            // FlpLivros
            // 
            this.FlpLivros.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.FlpLivros.Location = new System.Drawing.Point(252, 70);
            this.FlpLivros.Name = "FlpLivros";
            this.FlpLivros.Size = new System.Drawing.Size(548, 380);
            this.FlpLivros.TabIndex = 13;
            this.FlpLivros.Paint += new System.Windows.Forms.PaintEventHandler(this.FlpLivros_Paint);
            // 
            // TelaEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FlpLivros);
            this.Controls.Add(this.Btnreligious);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.Btnthriller);
            this.Controls.Add(this.BtnComedy);
            this.Controls.Add(this.Btnsciencefiction);
            this.Controls.Add(this.Btnselfhelp);
            this.Controls.Add(this.Btnterror);
            this.Controls.Add(this.Btnfantasy);
            this.Controls.Add(this.BtnRomance);
            this.Controls.Add(this.Btnmenu);
            this.Controls.Add(this.Txtwrite);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Txt01);
            this.Controls.Add(this.pictureBox1);
            this.Name = "TelaEntrada";
            this.Text = "TelaEntrada";
            this.Load += new System.EventHandler(this.TelaEntrada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txtwrite;
        private System.Windows.Forms.Label Txt01;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnRomance;
        private System.Windows.Forms.Button Btnfantasy;
        private System.Windows.Forms.Button Btnterror;
        private System.Windows.Forms.Button Btnselfhelp;
        private System.Windows.Forms.Button Btnsciencefiction;
        private System.Windows.Forms.Button BtnComedy;
        private System.Windows.Forms.Button Btnthriller;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button Btnmenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Btnreligious;
        private System.Windows.Forms.FlowLayoutPanel FlpLivros;
    }
}