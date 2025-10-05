using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Livraria
{
    public partial class LivroCard: UserControl
    {
        public LivroCard()
        {
            InitializeComponent();
        }



        public Image Imagem
        {
            get { return PicCapa.Image; }
            set { PicCapa.Image = value; }
        }

        // Propriedade para o título
        public string Titulo
        {
            get => lblTitulo.Text;
            set => lblTitulo.Text = value;
        }

        // Propriedade para o autor
        public string Autor
        {
            get => lblAutor.Text;
            set => lblAutor.Text = value;
        }

        // Propriedade para o preço
        public string Preco
        {
            get => lblPreco.Text;
            set => lblPreco.Text = value;
        }


        
private void Titulo_Click(object sender, EventArgs e)
        {

        }

        private void LivroCard_Load(object sender, EventArgs e)
        {
           
        }
    }

}
