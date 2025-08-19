namespace Livraria
{
    partial class GestaoEstoque
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
            this.Btn01 = new System.Windows.Forms.Button();
            this.Txb01 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Btn01
            // 
            this.Btn01.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Btn01.Location = new System.Drawing.Point(134, 12);
            this.Btn01.Name = "Btn01";
            this.Btn01.Size = new System.Drawing.Size(75, 23);
            this.Btn01.TabIndex = 0;
            this.Btn01.Text = "Buscar";
            this.Btn01.UseVisualStyleBackColor = false;
            // 
            // Txb01
            // 
            this.Txb01.Location = new System.Drawing.Point(28, 12);
            this.Txb01.Name = "Txb01";
            this.Txb01.Size = new System.Drawing.Size(100, 20);
            this.Txb01.TabIndex = 1;
            // 
            // GestaoEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Txb01);
            this.Controls.Add(this.Btn01);
            this.Name = "GestaoEstoque";
            this.Text = "GestaoEstoque";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn01;
        private System.Windows.Forms.TextBox Txb01;
    }
}