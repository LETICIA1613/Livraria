namespace Livraria
{
    partial class TelaCadastro
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
            this.TxtNameCadastre = new System.Windows.Forms.TextBox();
            this.TxtEmailCadastre = new System.Windows.Forms.TextBox();
            this.TxtPWCadastre = new System.Windows.Forms.TextBox();
            this.DateNasci = new System.Windows.Forms.DateTimePicker();
            this.BtnConfirmar = new System.Windows.Forms.Button();
            this.TxtPWCadastre2 = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // TxtNameCadastre
            // 
            this.TxtNameCadastre.Location = new System.Drawing.Point(374, 101);
            this.TxtNameCadastre.Name = "TxtNameCadastre";
            this.TxtNameCadastre.Size = new System.Drawing.Size(100, 20);
            this.TxtNameCadastre.TabIndex = 1;
            this.TxtNameCadastre.Text = "Nome";
            this.TxtNameCadastre.TextChanged += new System.EventHandler(this.TxtNameCadastre_TextChanged);
            this.TxtNameCadastre.Enter += new System.EventHandler(this.TxtNameCadastre_Enter);
            this.TxtNameCadastre.Leave += new System.EventHandler(this.TxtNameCadastre_Leave);
            // 
            // TxtEmailCadastre
            // 
            this.TxtEmailCadastre.Location = new System.Drawing.Point(374, 147);
            this.TxtEmailCadastre.Name = "TxtEmailCadastre";
            this.TxtEmailCadastre.Size = new System.Drawing.Size(100, 20);
            this.TxtEmailCadastre.TabIndex = 2;
            this.TxtEmailCadastre.Text = "E-mail";
            this.TxtEmailCadastre.Enter += new System.EventHandler(this.TxtEmailCadastre_Enter);
            this.TxtEmailCadastre.Leave += new System.EventHandler(this.TxtEmailCadastre_Leave);
            // 
            // TxtPWCadastre
            // 
            this.TxtPWCadastre.Location = new System.Drawing.Point(374, 188);
            this.TxtPWCadastre.Name = "TxtPWCadastre";
            this.TxtPWCadastre.Size = new System.Drawing.Size(100, 20);
            this.TxtPWCadastre.TabIndex = 3;
            this.TxtPWCadastre.Text = "Senha";
            this.TxtPWCadastre.Enter += new System.EventHandler(this.TxtPWCadastre_Enter);
            this.TxtPWCadastre.Leave += new System.EventHandler(this.TxtPWCadastre_Leave);
            // 
            // DateNasci
            // 
            this.DateNasci.Location = new System.Drawing.Point(374, 240);
            this.DateNasci.Name = "DateNasci";
            this.DateNasci.Size = new System.Drawing.Size(247, 20);
            this.DateNasci.TabIndex = 0;
            this.DateNasci.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // BtnConfirmar
            // 
            this.BtnConfirmar.Location = new System.Drawing.Point(640, 300);
            this.BtnConfirmar.Name = "BtnConfirmar";
            this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.BtnConfirmar.TabIndex = 6;
            this.BtnConfirmar.Text = "Confirmar";
            this.BtnConfirmar.UseVisualStyleBackColor = true;
            this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // TxtPWCadastre2
            // 
            this.TxtPWCadastre2.Location = new System.Drawing.Point(503, 188);
            this.TxtPWCadastre2.Name = "TxtPWCadastre2";
            this.TxtPWCadastre2.Size = new System.Drawing.Size(100, 20);
            this.TxtPWCadastre2.TabIndex = 4;
            this.TxtPWCadastre2.Text = "Confirmar Senha";
            this.TxtPWCadastre2.Enter += new System.EventHandler(this.TxtPWCadastre2_Enter);
            this.TxtPWCadastre2.Leave += new System.EventHandler(this.TxtPWCadastre2_Leave);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(371, 263);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(112, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Já tenho um cadastro!";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // TelaCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.TxtPWCadastre2);
            this.Controls.Add(this.BtnConfirmar);
            this.Controls.Add(this.DateNasci);
            this.Controls.Add(this.TxtPWCadastre);
            this.Controls.Add(this.TxtEmailCadastre);
            this.Controls.Add(this.TxtNameCadastre);
            this.Name = "TelaCadastro";
            this.Text = "TelaCadastro";
            this.Load += new System.EventHandler(this.TelaCadastro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtNameCadastre;
        private System.Windows.Forms.TextBox TxtEmailCadastre;
        private System.Windows.Forms.TextBox TxtPWCadastre;
        private System.Windows.Forms.DateTimePicker DateNasci;
        private System.Windows.Forms.Button BtnConfirmar;
        private System.Windows.Forms.TextBox TxtPWCadastre2;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}