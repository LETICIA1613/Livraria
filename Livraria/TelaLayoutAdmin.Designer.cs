namespace Livraria
{
    partial class TelaLayoutAdmin
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
            this.BtnSalvarLayout = new System.Windows.Forms.Button();
            this.PbCapaadmin = new System.Windows.Forms.PictureBox();
            this.LblTituloadmin = new System.Windows.Forms.Label();
            this.LblAutoradmin = new System.Windows.Forms.Label();
            this.LblDescricaoadmin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbCapaadmin)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSalvarLayout
            // 
            this.BtnSalvarLayout.Location = new System.Drawing.Point(651, 375);
            this.BtnSalvarLayout.Name = "BtnSalvarLayout";
            this.BtnSalvarLayout.Size = new System.Drawing.Size(75, 23);
            this.BtnSalvarLayout.TabIndex = 0;
            this.BtnSalvarLayout.Text = "button1";
            this.BtnSalvarLayout.UseVisualStyleBackColor = true;
            this.BtnSalvarLayout.Click += new System.EventHandler(this.BtnSalvarLayout_Click);
            // 
            // PbCapaadmin
            // 
            this.PbCapaadmin.Location = new System.Drawing.Point(39, 43);
            this.PbCapaadmin.Name = "PbCapaadmin";
            this.PbCapaadmin.Size = new System.Drawing.Size(164, 236);
            this.PbCapaadmin.TabIndex = 1;
            this.PbCapaadmin.TabStop = false;
            // 
            // LblTituloadmin
            // 
            this.LblTituloadmin.AutoSize = true;
            this.LblTituloadmin.Location = new System.Drawing.Point(337, 43);
            this.LblTituloadmin.Name = "LblTituloadmin";
            this.LblTituloadmin.Size = new System.Drawing.Size(35, 13);
            this.LblTituloadmin.TabIndex = 2;
            this.LblTituloadmin.Text = "label1";
            // 
            // LblAutoradmin
            // 
            this.LblAutoradmin.AutoSize = true;
            this.LblAutoradmin.Location = new System.Drawing.Point(340, 86);
            this.LblAutoradmin.Name = "LblAutoradmin";
            this.LblAutoradmin.Size = new System.Drawing.Size(35, 13);
            this.LblAutoradmin.TabIndex = 3;
            this.LblAutoradmin.Text = "label1";
            // 
            // LblDescricaoadmin
            // 
            this.LblDescricaoadmin.AutoSize = true;
            this.LblDescricaoadmin.Location = new System.Drawing.Point(343, 143);
            this.LblDescricaoadmin.Name = "LblDescricaoadmin";
            this.LblDescricaoadmin.Size = new System.Drawing.Size(35, 13);
            this.LblDescricaoadmin.TabIndex = 4;
            this.LblDescricaoadmin.Text = "label1";
            // 
            // TelaLayoutAdmin
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LblDescricaoadmin);
            this.Controls.Add(this.LblAutoradmin);
            this.Controls.Add(this.LblTituloadmin);
            this.Controls.Add(this.PbCapaadmin);
            this.Controls.Add(this.BtnSalvarLayout);
            this.Name = "TelaLayoutAdmin";
            this.Text = "TelaLayoutAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.PbCapaadmin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSalvarLayout;
        private System.Windows.Forms.PictureBox PbCapaadmin;
        private System.Windows.Forms.Label LblTituloadmin;
        private System.Windows.Forms.Label LblAutoradmin;
        private System.Windows.Forms.Label LblDescricaoadmin;
    }
}