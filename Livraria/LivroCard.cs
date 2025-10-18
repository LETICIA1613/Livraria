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
    public partial class LivroCard : UserControl
    {
        public LivroCard()
        {
            InitializeComponent();
            BtnAddbook.Click += BtnAddbook_Click;
        }
        public int LivroId { get; set; }
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
        public string Editora
        {
            get => lblEditora.Text;
            set => lblEditora.Text = value;
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

        private void lblEditora_Click(object sender, EventArgs e)
        {

        }

        private void BtnAddbook_Click(object sender, EventArgs e)
        {
            TelaPerfilLivro tela = new TelaPerfilLivro(LivroId);
            tela.ShowDialog(); // modal, bloqueia até fechar
        }
    }
}
