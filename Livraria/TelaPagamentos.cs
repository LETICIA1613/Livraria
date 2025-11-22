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
    public partial class TelaPagamentos: Form
    {
        private decimal totalCompra;
        private int quantidadeItens;

        public TelaPagamentos(decimal total, int quantidade)
        {
            InitializeComponent();
            totalCompra = total;
            quantidadeItens = quantidade;
            CarregarTelaPagamentos();

           
        }
        private void CarregarTelaPagamentos()
        {
            this.Size = new Size(500, 600);
            this.Text = "Pagamento - Livraria";
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Título
            Label lblTitulo = new Label();
            lblTitulo.Text = "💳 FORMA DE PAGAMENTO";
            lblTitulo.Font = new Font("Arial", 18, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DarkBlue;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Size = new Size(400, 40);
            lblTitulo.Location = new Point(50, 20);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblTitulo);

            // Resumo da compra
            Label lblResumo = new Label();
            lblResumo.Text = $"Resumo da Compra:\n{quantidadeItens} itens - Total: R$ {totalCompra:F2}";
            lblResumo.Font = new Font("Arial", 12, FontStyle.Regular);
            lblResumo.ForeColor = Color.DarkSlateGray;
            lblResumo.BackColor = Color.Transparent;
            lblResumo.Size = new Size(400, 50);
            lblResumo.Location = new Point(50, 80);
            lblResumo.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblResumo);

            int y = 150;

            // Opção 1: Pix (5% de desconto)
            RadioButton rbPix = new RadioButton();
            rbPix.Text = $"💰 PIX - 5% DE DESCONTO\nR$ {CalcularComDesconto(5):F2}";
            rbPix.Font = new Font("Arial", 12, FontStyle.Bold);
            rbPix.ForeColor = Color.DarkGreen;
            rbPix.BackColor = Color.Transparent;
            rbPix.Size = new Size(400, 60);
            rbPix.Location = new Point(50, y);
            rbPix.Checked = true;
            this.Controls.Add(rbPix);
            y += 80;

            // Opção 2: Débito
            RadioButton rbDebito = new RadioButton();
            rbDebito.Text = $"💳 DÉBITO - R$ {totalCompra:F2}";
            rbDebito.Font = new Font("Arial", 12, FontStyle.Bold);
            rbDebito.ForeColor = Color.Blue;
            rbDebito.BackColor = Color.Transparent;
            rbDebito.Size = new Size(400, 40);
            rbDebito.Location = new Point(50, y);
            this.Controls.Add(rbDebito);
            y += 60;

            // Opção 3: Crédito à Vista
            RadioButton rbCreditoAVista = new RadioButton();
            rbCreditoAVista.Text = $"💳 CRÉDITO À VISTA - R$ {totalCompra:F2}";
            rbCreditoAVista.Font = new Font("Arial", 12, FontStyle.Bold);
            rbCreditoAVista.ForeColor = Color.Purple;
            rbCreditoAVista.BackColor = Color.Transparent;
            rbCreditoAVista.Size = new Size(400, 40);
            rbCreditoAVista.Location = new Point(50, y);
            this.Controls.Add(rbCreditoAVista);
            y += 60;

            // Opção 4: Crédito Parcelado
            RadioButton rbCreditoParcelado = new RadioButton();
            decimal totalParcelado = CalcularComJuros(10); // 10% de juros
            rbCreditoParcelado.Text = $"💳 CRÉDITO PARCELADO (até 12x)\nR$ {totalParcelado:F2} - com 10% de juros";
            rbCreditoParcelado.Font = new Font("Arial", 12, FontStyle.Bold);
            rbCreditoParcelado.ForeColor = Color.DarkRed;
            rbCreditoParcelado.BackColor = Color.Transparent;
            rbCreditoParcelado.Size = new Size(400, 60);
            rbCreditoParcelado.Location = new Point(50, y);
            this.Controls.Add(rbCreditoParcelado);
            y += 100;

            // Botão Confirmar Pagamento
            Button btnConfirmar = new Button();
            btnConfirmar.Text = "✅ CONFIRMAR PAGAMENTO";
            btnConfirmar.BackColor = Color.Green;
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Font = new Font("Arial", 14, FontStyle.Bold);
            btnConfirmar.Size = new Size(400, 50);
            btnConfirmar.Location = new Point(50, y);
            btnConfirmar.Cursor = Cursors.Hand;
            btnConfirmar.Click += (s, e) => ConfirmarPagamento();
            this.Controls.Add(btnConfirmar);
            y += 70;

            // Botão Voltar
            Button btnVoltar = new Button();
            btnVoltar.Text = "← Voltar ao Carrinho";
            btnVoltar.BackColor = Color.Gray;
            btnVoltar.ForeColor = Color.White;
            btnVoltar.Font = new Font("Arial", 11, FontStyle.Regular);
            btnVoltar.Size = new Size(400, 40);
            btnVoltar.Location = new Point(50, y);
            btnVoltar.Cursor = Cursors.Hand;
            btnVoltar.Click += (s, e) => this.Close();
            this.Controls.Add(btnVoltar);
        }

        private decimal CalcularComDesconto(int percentualDesconto)
        {
            return totalCompra * (1 - percentualDesconto / 100m);
        }

        private decimal CalcularComJuros(int percentualJuros)
        {
            return totalCompra * (1 + percentualJuros / 100m);
        }

        private void ConfirmarPagamento()
        {
            string mensagemSucesso = "🎉 PAGAMENTO CONFIRMADO COM SUCESSO!\n\n" +
                                   $"Itens: {quantidadeItens}\n" +
                                   $"Valor Total: R$ {totalCompra:F2}\n\n" +
                                   $"Obrigado pela compra! Seu pedido será enviado em breve.";

            MessageBox.Show(mensagemSucesso, "Pagamento Confirmado",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpar carrinho e fechar todas as telas
            Carrinho.LimparCarrinho();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void TelaPagamentos_Load(object sender, EventArgs e)
        {
            try
            {
                // Carrega a imagem dos recursos embutidos
                this.BackgroundImage = Livraria.Properties.Resources.TelaPerfilLivro; // Nome do recurso
                this.BackgroundImageLayout = ImageLayout.Stretch;
                this.DoubleBuffered = true;
            }
            catch
            {
                // Continua sem imagem de fundo
            }
           
        }
    }
}

