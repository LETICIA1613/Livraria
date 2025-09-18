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
    public partial class TelaEscolhaAdmin: Form
    {
        public TelaEscolhaAdmin()
        {
            InitializeComponent();
        }

        private void Btnescolhaadd_Click(object sender, EventArgs e)
        {
            Telaadicionarlivro product = new Telaadicionarlivro();
            this.Visible = false;
            product.ShowDialog();
            this.Visible = true;
        }
    }
}
