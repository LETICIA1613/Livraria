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
    public partial class GestaoEstoque : Form
    {
        public GestaoEstoque()
        {
            InitializeComponent();
        }
        private void Btn1_Click(object sender, EventArgs e)
        {
            GestaoEstoque screenproduct = new GestaoEstoque();
            screenproduct.Show();
        }
    }
}