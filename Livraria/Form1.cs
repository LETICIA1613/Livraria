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
            TelaLogin product = new TelaLogin();
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
    }
}