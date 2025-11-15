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
    public partial class TelaCarrinho : Form
    {
        public TelaCarrinho()
        {
            InitializeComponent();
            CarregarCarrinho();
        }

        private void CarregarCarrinho()
        {
            // Limpar controles existentes
            this.Controls.Clear();

            // Título
            Label lblTitulo = new Label();
            lblTitulo.Text = "🛒 MEU CARRINHO";
            lblTitulo.Font = new Font("Arial", 20, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DarkBlue;
            lblTitulo.Size = new Size(400, 40);
            lblTitulo.Location = new Point(20, 20);
            this.Controls.Add(lblTitulo);

            var itensCarrinho = Carrinho.GetItens();
            int y = 80; // Posição inicial abaixo do título

            if (itensCarrinho.Count == 0)
            {
                // Carrinho vazio
                Label lblVazio = new Label();
                lblVazio.Text = "Seu carrinho está vazio!";
                lblVazio.Font = new Font("Arial", 14, FontStyle.Italic);
                lblVazio.ForeColor = Color.Gray;
                lblVazio.Size = new Size(300, 30);
                lblVazio.Location = new Point(50, y);
                this.Controls.Add(lblVazio);

                // Botão voltar
                Button btnVoltar = new Button();
                btnVoltar.Text = "← Continuar Comprando";
                btnVoltar.BackColor = Color.DodgerBlue;
                btnVoltar.ForeColor = Color.White;
                btnVoltar.Font = new Font("Arial", 12, FontStyle.Bold);
                btnVoltar.Size = new Size(220, 40);
                btnVoltar.Location = new Point(50, y + 50);
                btnVoltar.Cursor = Cursors.Hand;
                btnVoltar.Click += (s, e) => this.Close();
                this.Controls.Add(btnVoltar);

                return;
            }

            // Cabeçalho da lista
            Panel cabecalho = CriarCabecalho(y);
            this.Controls.Add(cabecalho);
            y += 50;

            // Itens do carrinho
            foreach (var item in itensCarrinho)
            {
                Panel panelItem = CriarPanelItem(item, y);
                this.Controls.Add(panelItem);
                y += 100; // Espaço entre itens
            }

            // Painel do total
            Panel panelTotal = CriarPanelTotal(y);
            this.Controls.Add(panelTotal);
            y += 80;

            // Botões
            CriarBotoes(y);
        }

        private Panel CriarCabecalho(int y)
        {
            Panel panel = new Panel();
            panel.Size = new Size(700, 40);
            panel.Location = new Point(40, y);
            panel.BackColor = Color.LightGray;

            // Produto
            Label lblProduto = new Label();
            lblProduto.Text = "PRODUTO";
            lblProduto.Font = new Font("Arial", 10, FontStyle.Bold);
            lblProduto.ForeColor = Color.Black;
            lblProduto.Size = new Size(200, 30);
            lblProduto.Location = new Point(20, 5);
            panel.Controls.Add(lblProduto);

            // Preço
            Label lblPreco = new Label();
            lblPreco.Text = "PREÇO";
            lblPreco.Font = new Font("Arial", 10, FontStyle.Bold);
            lblPreco.ForeColor = Color.Black;
            lblPreco.Size = new Size(80, 30);
            lblPreco.Location = new Point(250, 5);
            lblPreco.TextAlign = ContentAlignment.MiddleCenter;
            panel.Controls.Add(lblPreco);

            // Quantidade
            Label lblQuantidade = new Label();
            lblQuantidade.Text = "QTD";
            lblQuantidade.Font = new Font("Arial", 10, FontStyle.Bold);
            lblQuantidade.ForeColor = Color.Black;
            lblQuantidade.Size = new Size(60, 30);
            lblQuantidade.Location = new Point(350, 5);
            lblQuantidade.TextAlign = ContentAlignment.MiddleCenter;
            panel.Controls.Add(lblQuantidade);

            // Subtotal
            Label lblSubtotal = new Label();
            lblSubtotal.Text = "SUBTOTAL";
            lblSubtotal.Font = new Font("Arial", 10, FontStyle.Bold);
            lblSubtotal.ForeColor = Color.Black;
            lblSubtotal.Size = new Size(80, 30);
            lblSubtotal.Location = new Point(430, 5);
            lblSubtotal.TextAlign = ContentAlignment.MiddleCenter;
            panel.Controls.Add(lblSubtotal);

            // Ações
            Label lblAcoes = new Label();
            lblAcoes.Text = "AÇÕES";
            lblAcoes.Font = new Font("Arial", 10, FontStyle.Bold);
            lblAcoes.ForeColor = Color.Black;
            lblAcoes.Size = new Size(80, 30);
            lblAcoes.Location = new Point(530, 5);
            lblAcoes.TextAlign = ContentAlignment.MiddleCenter;
            panel.Controls.Add(lblAcoes);

            return panel;
        }

        private Panel CriarPanelItem(LivroCarrinho item, int y)
        {
            Panel panel = new Panel();
            panel.Size = new Size(700, 90);
            panel.Location = new Point(40, y);
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;

            // Imagem do livro (se existir)
            if (item.Foto != null && item.Foto.Length > 0)
            {
                PictureBox pbCapa = new PictureBox();
                pbCapa.Size = new Size(50, 70);
                pbCapa.Location = new Point(10, 10);
                pbCapa.SizeMode = PictureBoxSizeMode.Zoom;

                try
                {
                    using (var ms = new System.IO.MemoryStream(item.Foto))
                    {
                        pbCapa.Image = Image.FromStream(ms);
                    }
                }
                catch
                {
                    pbCapa.Image = null;
                }
                panel.Controls.Add(pbCapa);
            }

            // Título e Autor
            Label lblTitulo = new Label();
            lblTitulo.Text = item.Titulo;
            lblTitulo.Font = new Font("Arial", 11, FontStyle.Bold);
            lblTitulo.ForeColor = Color.Black;
            lblTitulo.Size = new Size(200, 20);
            lblTitulo.Location = new Point(70, 15);
            panel.Controls.Add(lblTitulo);

            Label lblAutor = new Label();
            lblAutor.Text = item.Autor;
            lblAutor.Font = new Font("Arial", 9);
            lblAutor.ForeColor = Color.Gray;
            lblAutor.Size = new Size(200, 20);
            lblAutor.Location = new Point(70, 40);
            panel.Controls.Add(lblAutor);

            // Preço unitário
            Label lblPreco = new Label();
            lblPreco.Text = $"R$ {item.Preco:F2}";
            lblPreco.Font = new Font("Arial", 10);
            lblPreco.ForeColor = Color.Black;
            lblPreco.Size = new Size(80, 30);
            lblPreco.Location = new Point(250, 30);
            lblPreco.TextAlign = ContentAlignment.MiddleCenter;
            panel.Controls.Add(lblPreco);

            // Quantidade
            Label lblQuantidade = new Label();
            lblQuantidade.Text = item.Quantidade.ToString();
            lblQuantidade.Font = new Font("Arial", 11, FontStyle.Bold);
            lblQuantidade.ForeColor = Color.Black;
            lblQuantidade.Size = new Size(60, 30);
            lblQuantidade.Location = new Point(350, 30);
            lblQuantidade.TextAlign = ContentAlignment.MiddleCenter;
            panel.Controls.Add(lblQuantidade);

            // Subtotal
            decimal subtotal = item.Preco * item.Quantidade;
            Label lblSubtotal = new Label();
            lblSubtotal.Text = $"R$ {subtotal:F2}";
            lblSubtotal.Font = new Font("Arial", 11, FontStyle.Bold);
            lblSubtotal.ForeColor = Color.Green;
            lblSubtotal.Size = new Size(80, 30);
            lblSubtotal.Location = new Point(430, 30);
            lblSubtotal.TextAlign = ContentAlignment.MiddleCenter;
            panel.Controls.Add(lblSubtotal);

            // Botão Remover
            Button btnRemover = new Button();
            btnRemover.Text = "🗑️";
            btnRemover.Font = new Font("Arial", 10);
            btnRemover.Size = new Size(40, 30);
            btnRemover.Location = new Point(530, 30);
            btnRemover.BackColor = Color.White;
            btnRemover.ForeColor = Color.Red;
            btnRemover.FlatStyle = FlatStyle.Flat;
            btnRemover.Cursor = Cursors.Hand;
            btnRemover.Click += (s, e) => RemoverItem(item.LivroId);
            panel.Controls.Add(btnRemover);

            return panel;
        }

        private Panel CriarPanelTotal(int y)
        {
            Panel panel = new Panel();
            panel.Size = new Size(300, 60);
            panel.Location = new Point(440, y);
            panel.BackColor = Color.LightGray;
            panel.BorderStyle = BorderStyle.FixedSingle;

            decimal total = Carrinho.GetTotal();
            int quantidadeTotal = Carrinho.GetQuantidadeTotal();

            Label lblTotal = new Label();
            lblTotal.Text = $"TOTAL ({quantidadeTotal} itens): R$ {total:F2}";
            lblTotal.Font = new Font("Arial", 14, FontStyle.Bold);
            lblTotal.ForeColor = Color.DarkGreen;
            lblTotal.Size = new Size(280, 30);
            lblTotal.Location = new Point(10, 15);
            lblTotal.TextAlign = ContentAlignment.MiddleCenter;
            panel.Controls.Add(lblTotal);

            return panel;
        }

        private void CriarBotoes(int y)
        {
            // Botão Continuar Comprando
            Button btnContinuar = new Button();
            btnContinuar.Text = "← Continuar Comprando";
            btnContinuar.BackColor = Color.Gray;
            btnContinuar.ForeColor = Color.White;
            btnContinuar.Font = new Font("Arial", 12, FontStyle.Bold);
            btnContinuar.Size = new Size(200, 45);
            btnContinuar.Location = new Point(40, y);
            btnContinuar.Cursor = Cursors.Hand;
            btnContinuar.Click += (s, e) => this.Close();
            this.Controls.Add(btnContinuar);

            // Botão Finalizar Compra
            Button btnFinalizar = new Button();
            btnFinalizar.Text = "💰 Finalizar Compra";
            btnFinalizar.BackColor = Color.Green;
            btnFinalizar.ForeColor = Color.White;
            btnFinalizar.Font = new Font("Arial", 12, FontStyle.Bold);
            btnFinalizar.Size = new Size(200, 45);
            btnFinalizar.Location = new Point(260, y);
            btnFinalizar.Cursor = Cursors.Hand;
            btnFinalizar.Click += BtnFinalizar_Click;
            this.Controls.Add(btnFinalizar);

            // Botão Limpar Carrinho
            Button btnLimpar = new Button();
            btnLimpar.Text = "🗑️ Limpar Carrinho";
            btnLimpar.BackColor = Color.OrangeRed;
            btnLimpar.ForeColor = Color.White;
            btnLimpar.Font = new Font("Arial", 12, FontStyle.Bold);
            btnLimpar.Size = new Size(200, 45);
            btnLimpar.Location = new Point(480, y);
            btnLimpar.Cursor = Cursors.Hand;
            btnLimpar.Click += BtnLimpar_Click;
            this.Controls.Add(btnLimpar);
        }

        private void RemoverItem(int livroId)
        {
            Carrinho.RemoverLivro(livroId);
            CarregarCarrinho(); // Recarrega a tela
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Tem certeza que deseja limpar o carrinho?",
                "Limpar Carrinho", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Carrinho.LimparCarrinho();
                CarregarCarrinho();
            }
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            if (Carrinho.GetQuantidadeTotal() == 0)
            {
                MessageBox.Show("Seu carrinho está vazio!", "Carrinho Vazio",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total = Carrinho.GetTotal();
            int quantidade = Carrinho.GetQuantidadeTotal();

            string mensagem = $"COMPRA FINALIZADA COM SUCESSO! 🎉\n\n" +
                            $"Itens: {quantidade}\n" +
                            $"Total: R$ {total:F2}\n\n" +
                            $"Obrigado pela compra!";

            MessageBox.Show(mensagem, "Compra Finalizada",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            Carrinho.LimparCarrinho();
            this.Close();
        }
    }
}
