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
            set
            {
                // ✅ SOLUÇÃO ALTERNATIVA - Layout dinâmico mas controlado
                lblTitulo.AutoSize = true;
                lblTitulo.MaximumSize = new Size(150, 40); // Altura máxima também
                lblTitulo.AutoEllipsis = true;
                lblTitulo.TextAlign = ContentAlignment.TopCenter;
                lblTitulo.Text = value;

                // Recalcula posições baseado no título REAL
                int tituloBottom = lblTitulo.Bottom;
                lblEditora.Top = tituloBottom + 3;
                lblPreco.Top = lblEditora.Bottom + 3;
                BtnAddbook.Top = lblPreco.Bottom + 5;
                /*  lblTitulo.Text = value;

                  // título flexível
                  lblTitulo.AutoSize = true;
                  lblTitulo.MaximumSize = new Size(150, 0);
                  lblTitulo.AutoEllipsis = false;
                  lblTitulo.TextAlign = ContentAlignment.TopCenter;
                  lblTitulo.Refresh();

                  // EDITORA → fica logo abaixo do título
                  lblEditora.Location = new Point(lblEditora.Location.X, lblTitulo.Bottom + 3);

                  // PREÇO → fica logo abaixo da editora
                  lblPreco.Location = new Point(lblPreco.Location.X, lblEditora.Bottom + 5);

                  // BOTÃO → fica abaixo do preço
                  BtnAddbook.Location = new Point(BtnAddbook.Location.X, lblPreco.Bottom + 5);*/
            }

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
            TelaPerfilLivro product = new TelaPerfilLivro(LivroId);
            this.Visible = false;
            product.ShowDialog();
            this.Visible = true;
        }
    }
}
