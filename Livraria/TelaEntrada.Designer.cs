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
            this.Btnmenu = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.FlpLivros = new System.Windows.Forms.FlowLayoutPanel();
            this.ClbGenerosfiltro = new System.Windows.Forms.CheckedListBox();
            this.BtnFiltrar = new System.Windows.Forms.Button();
            this.ClbPreco = new System.Windows.Forms.CheckedListBox();
            this.CbFiltroFX = new System.Windows.Forms.ComboBox();
            this.ClbFiltroAutor = new System.Windows.Forms.CheckedListBox();
            this.ChkNovidades = new System.Windows.Forms.CheckBox();
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
            // FlpLivros
            // 
            this.FlpLivros.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.FlpLivros.Location = new System.Drawing.Point(252, 70);
            this.FlpLivros.Name = "FlpLivros";
            this.FlpLivros.Size = new System.Drawing.Size(548, 380);
            this.FlpLivros.TabIndex = 13;
            this.FlpLivros.Paint += new System.Windows.Forms.PaintEventHandler(this.FlpLivros_Paint);
            // 
            // ClbGenerosfiltro
            // 
            this.ClbGenerosfiltro.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClbGenerosfiltro.FormattingEnabled = true;
            this.ClbGenerosfiltro.Location = new System.Drawing.Point(12, 322);
            this.ClbGenerosfiltro.Name = "ClbGenerosfiltro";
            this.ClbGenerosfiltro.Size = new System.Drawing.Size(134, 109);
            this.ClbGenerosfiltro.TabIndex = 0;
            // 
            // BtnFiltrar
            // 
            this.BtnFiltrar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnFiltrar.Location = new System.Drawing.Point(161, 59);
            this.BtnFiltrar.Name = "BtnFiltrar";
            this.BtnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.BtnFiltrar.TabIndex = 0;
            this.BtnFiltrar.Text = "Filtrar";
            this.BtnFiltrar.UseVisualStyleBackColor = false;
            this.BtnFiltrar.Click += new System.EventHandler(this.BtnFiltrar_Click);
            // 
            // ClbPreco
            // 
            this.ClbPreco.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClbPreco.FormattingEnabled = true;
            this.ClbPreco.Location = new System.Drawing.Point(12, 237);
            this.ClbPreco.Name = "ClbPreco";
            this.ClbPreco.Size = new System.Drawing.Size(131, 79);
            this.ClbPreco.TabIndex = 14;
            // 
            // CbFiltroFX
            // 
            this.CbFiltroFX.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CbFiltroFX.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CbFiltroFX.FormattingEnabled = true;
            this.CbFiltroFX.Location = new System.Drawing.Point(12, 125);
            this.CbFiltroFX.Name = "CbFiltroFX";
            this.CbFiltroFX.Size = new System.Drawing.Size(128, 21);
            this.CbFiltroFX.TabIndex = 0;
            this.CbFiltroFX.Text = "Faixa Etaria";
            // 
            // ClbFiltroAutor
            // 
            this.ClbFiltroAutor.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClbFiltroAutor.FormattingEnabled = true;
            this.ClbFiltroAutor.Location = new System.Drawing.Point(12, 152);
            this.ClbFiltroAutor.Name = "ClbFiltroAutor";
            this.ClbFiltroAutor.Size = new System.Drawing.Size(120, 79);
            this.ClbFiltroAutor.TabIndex = 0;
            // 
            // ChkNovidades
            // 
            this.ChkNovidades.AutoSize = true;
            this.ChkNovidades.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ChkNovidades.Location = new System.Drawing.Point(12, 102);
            this.ChkNovidades.Name = "ChkNovidades";
            this.ChkNovidades.Size = new System.Drawing.Size(77, 17);
            this.ChkNovidades.TabIndex = 0;
            this.ChkNovidades.Text = "Novidades";
            this.ChkNovidades.UseVisualStyleBackColor = false;
            // 
            // TelaEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChkNovidades);
            this.Controls.Add(this.ClbFiltroAutor);
            this.Controls.Add(this.CbFiltroFX);
            this.Controls.Add(this.ClbPreco);
            this.Controls.Add(this.BtnFiltrar);
            this.Controls.Add(this.ClbGenerosfiltro);
            this.Controls.Add(this.FlpLivros);
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
        private System.Windows.Forms.Button Btnmenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel FlpLivros;
        private System.Windows.Forms.CheckedListBox ClbGenerosfiltro;
        private System.Windows.Forms.Button BtnFiltrar;
        private System.Windows.Forms.CheckedListBox ClbPreco;
        private System.Windows.Forms.ComboBox CbFiltroFX;
        private System.Windows.Forms.CheckedListBox ClbFiltroAutor;
        private System.Windows.Forms.CheckBox ChkNovidades;
    }
}