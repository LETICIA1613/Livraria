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
    public partial class Telaadicionarlivro : Form
    {
        public Telaadicionarlivro()
        {
            InitializeComponent();
        }



        string caminhoFoto = "";
        private void Btnimage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Arquivos de imagem|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                caminhoFoto = ofd.FileName;
                pictureBox2.ImageLocation = caminhoFoto; // troque pelo nome do seu PictureBox
            }

        }
    }
}
