using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Livraria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

     

        private void BtnCadastre0_Click(object sender, EventArgs e)
        {
            TelaCadastro product = new TelaCadastro();
            this.Visible = false;
            product.ShowDialog();
            this.Visible = true;
        }

        private void Btnadmin_Click(object sender, EventArgs e)
        {
            Telaentradaadmin product = new Telaentradaadmin();
            this.Visible = false;
            product.ShowDialog();
            this.Visible = true;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
          
            // Centralizar botão
            BtnCadastre0.Left = (this.ClientSize.Width - BtnCadastre0.Width) / 2;
            BtnCadastre0.Top = (this.ClientSize.Height - BtnCadastre0.Height) / 2;

            // Se quiser manter o Admin logo abaixo:
            Btnadmin.Left = (this.ClientSize.Width - Btnadmin.Width) / 2;
            Btnadmin.Top = BtnCadastre0.Bottom + 10; // 10 px abaixo
        
    }
    }
}