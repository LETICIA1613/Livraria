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

        // Propriedade para a capa
        public Image Capa
        {
            get => PicCapa.Image;
            set => PicCapa.Image = value;
        }
        private void Titulo_Click(object sender, EventArgs e)
        {

        }
    }

}
