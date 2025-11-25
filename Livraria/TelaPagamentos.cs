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
    public partial class TelaPagamentos : Form
    {
        private decimal totalCompra;
        private int quantidadeItens;
        private Panel panelPix;
        private PictureBox picQRCode;
        private Label lblInstrucoesPix;
        private RadioButton rbPix, rbDebito, rbCreditoAVista, rbCreditoParcelado;
        private bool pagamentoPixConfirmado = false;

        public TelaPagamentos(decimal total, int quantidade)
        {
            InitializeComponent();
            totalCompra = total;
            quantidadeItens = quantidade;
            CarregarTelaPagamentos();
        }

        private void CarregarTelaPagamentos()
        {
            this.Size = new Size(500, 800);
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
            rbPix = new RadioButton();
            rbPix.Text = $"💰 PIX - 5% DE DESCONTO\nR$ {CalcularComDesconto(5):F2}";
            rbPix.Font = new Font("Arial", 12, FontStyle.Bold);
            rbPix.ForeColor = Color.DarkGreen;
            rbPix.BackColor = Color.Transparent;
            rbPix.Size = new Size(400, 60);
            rbPix.Location = new Point(50, y);
            rbPix.Checked = true;
            rbPix.CheckedChanged += (s, e) => MostrarQRCodePix();
            this.Controls.Add(rbPix);
            y += 80;

            // Opção 2: Débito
            rbDebito = new RadioButton();
            rbDebito.Text = $"💳 DÉBITO - R$ {totalCompra:F2}";
            rbDebito.Font = new Font("Arial", 12, FontStyle.Bold);
            rbDebito.ForeColor = Color.Blue;
            rbDebito.BackColor = Color.Transparent;
            rbDebito.Size = new Size(400, 40);
            rbDebito.Location = new Point(50, y);
            rbDebito.CheckedChanged += (s, e) => OcultarQRCodePix();
            this.Controls.Add(rbDebito);
            y += 60;

            // Opção 3: Crédito à Vista
            rbCreditoAVista = new RadioButton();
            rbCreditoAVista.Text = $"💳 CRÉDITO À VISTA - R$ {totalCompra:F2}";
            rbCreditoAVista.Font = new Font("Arial", 12, FontStyle.Bold);
            rbCreditoAVista.ForeColor = Color.Purple;
            rbCreditoAVista.BackColor = Color.Transparent;
            rbCreditoAVista.Size = new Size(400, 40);
            rbCreditoAVista.Location = new Point(50, y);
            rbCreditoAVista.CheckedChanged += (s, e) => OcultarQRCodePix();
            this.Controls.Add(rbCreditoAVista);
            y += 60;

            // Opção 4: Crédito Parcelado
            rbCreditoParcelado = new RadioButton();
            decimal totalParcelado = CalcularComJuros(10);
            rbCreditoParcelado.Text = $"💳 CRÉDITO PARCELADO (até 12x)\nR$ {totalParcelado:F2} - com 10% de juros";
            rbCreditoParcelado.Font = new Font("Arial", 12, FontStyle.Bold);
            rbCreditoParcelado.ForeColor = Color.DarkRed;
            rbCreditoParcelado.BackColor = Color.Transparent;
            rbCreditoParcelado.Size = new Size(400, 60);
            rbCreditoParcelado.Location = new Point(50, y);
            rbCreditoParcelado.CheckedChanged += (s, e) => OcultarQRCodePix();
            this.Controls.Add(rbCreditoParcelado);
            y += 80;

            // Painel do QR Code PIX
            panelPix = new Panel();
            panelPix.Size = new Size(400, 200);
            panelPix.Location = new Point(50, y);
            panelPix.BackColor = Color.LightGreen;
            panelPix.Visible = true;
            this.Controls.Add(panelPix);

            // Instruções do PIX
            lblInstrucoesPix = new Label();
            lblInstrucoesPix.Text = "📱 PAGAMENTO VIA PIX\n\n" +
                                   "1. Abra seu app bancário\n" +
                                   "2. Escaneie o QR Code\n" +
                                   $"3. Pague R$ {CalcularComDesconto(5):F2}\n" +
                                   "4. Clique em 'PAGAMENTO FEITO'";
            lblInstrucoesPix.Font = new Font("Arial", 10, FontStyle.Bold);
            lblInstrucoesPix.ForeColor = Color.DarkGreen;
            lblInstrucoesPix.TextAlign = ContentAlignment.MiddleCenter;
            lblInstrucoesPix.Size = new Size(400, 80);
            lblInstrucoesPix.Location = new Point(0, 5);
            panelPix.Controls.Add(lblInstrucoesPix);

            // QR Code
            picQRCode = new PictureBox();
            picQRCode.Size = new Size(120, 120);
            picQRCode.Location = new Point(140, 80);
            picQRCode.SizeMode = PictureBoxSizeMode.StretchImage;
            picQRCode.BorderStyle = BorderStyle.FixedSingle;
            picQRCode.BackColor = Color.White;

            try
            {
                picQRCode.Image = Image.FromFile(@"C:\qrcode-pix-livraria.png");
            }
            catch
            {
                using (Bitmap bmp = new Bitmap(120, 120))
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                    g.DrawString("QR CODE PIX",
                                new Font("Arial", 8, FontStyle.Bold),
                                Brushes.Black, 10, 50);
                    picQRCode.Image = (Image)bmp.Clone();
                }
            }
            panelPix.Controls.Add(picQRCode);

            // Botão "PAGAMENTO FEITO" para PIX
            Button btnPagamentoFeito = new Button();
            btnPagamentoFeito.Text = "✅ PAGAMENTO FEITO";
            btnPagamentoFeito.BackColor = Color.Green;
            btnPagamentoFeito.ForeColor = Color.White;
            btnPagamentoFeito.Font = new Font("Arial", 10, FontStyle.Bold);
            btnPagamentoFeito.Size = new Size(150, 30);
            btnPagamentoFeito.Location = new Point(125, 205);
            btnPagamentoFeito.Cursor = Cursors.Hand;
            btnPagamentoFeito.Click += (s, e) => MarcarPagamentoPixComoFeito();
            panelPix.Controls.Add(btnPagamentoFeito);

            y += 190;

            // Botão Confirmar Pagamento
            Button btnConfirmar = new Button();
            btnConfirmar.Text = "✅ CONFIRMAR PAGAMENTO";
            btnConfirmar.BackColor = Color.Green;
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Font = new Font("Arial", 14, FontStyle.Bold);
            btnConfirmar.Size = new Size(400, 50);
            btnConfirmar.Location = new Point(50, y +10);
            btnConfirmar.Cursor = Cursors.Hand;
            btnConfirmar.Click += (s, e) => ValidarEConfirmarPagamento();
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

            MostrarQRCodePix();
        }

        private void MarcarPagamentoPixComoFeito()
        {
            pagamentoPixConfirmado = true;
            lblInstrucoesPix.Text = "✅ PAGAMENTO CONFIRMADO!\n\n" +
                                   "Obrigado! Agora clique em\n" +
                                   "'CONFIRMAR PAGAMENTO'\n" +
                                   "para finalizar seu pedido.";
            lblInstrucoesPix.ForeColor = Color.DarkBlue;

            // Marcar visualmente o QR Code como pago
            using (Graphics g = picQRCode.CreateGraphics())
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(100, 0, 255, 0)),
                    0, 0, picQRCode.Width, picQRCode.Height);
            }
        }

        private void ValidarEConfirmarPagamento()
        {
            // VALIDAÇÃO: Se for PIX, verifica se o pagamento foi confirmado
            if (rbPix.Checked && !pagamentoPixConfirmado)
            {
                MessageBox.Show("❌ Por favor, primeiro faça o pagamento PIX e clique em 'PAGAMENTO FEITO'",
                    "Pagamento Pendente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Se chegou aqui, o pagamento é válido
            string formaPagamento = ObterFormaPagamentoSelecionada();
            decimal valorFinal = ObterValorFinal();

            string mensagemSucesso = "🎉 PAGAMENTO CONFIRMADO COM SUCESSO!\n\n" +
                                   $"Forma de Pagamento: {formaPagamento}\n" +
                                   $"Itens: {quantidadeItens}\n" +
                                   $"Valor Total: R$ {valorFinal:F2}\n\n" +
                                   $"Obrigado pela compra! Seu pedido será enviado em breve.";

            MessageBox.Show(mensagemSucesso, "Pagamento Confirmado",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpar carrinho e fechar
            Carrinho.LimparCarrinho();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private string ObterFormaPagamentoSelecionada()
        {
            if (rbPix.Checked) return "PIX (com 5% de desconto)";
            if (rbDebito.Checked) return "Cartão de Débito";
            if (rbCreditoAVista.Checked) return "Cartão de Crédito à Vista";
            if (rbCreditoParcelado.Checked) return "Cartão de Crédito Parcelado";
            return "Não selecionado";
        }

        private decimal ObterValorFinal()
        {
            if (rbPix.Checked) return CalcularComDesconto(5);
            if (rbCreditoParcelado.Checked) return CalcularComJuros(10);
            return totalCompra;
        }

        private void MostrarQRCodePix()
        {
            panelPix.Visible = true;
            pagamentoPixConfirmado = false; // Reseta a confirmação
            lblInstrucoesPix.Text = "📱 PAGAMENTO VIA PIX\n\n" +
                                   "1. Abra seu app bancário\n" +
                                   "2. Escaneie o QR Code\n" +
                                   $"3. Pague R$ {CalcularComDesconto(5):F2}\n" +
                                   "4. Clique em 'PAGAMENTO FEITO'";
            lblInstrucoesPix.ForeColor = Color.DarkGreen;

            // Restaurar QR Code visualmente
            try
            {
                picQRCode.Image = Image.FromFile(@"C:\Users\CJ3027481\Downloads\QRCode.jpg");
            }
            catch
            {
                // Manter o placeholder se não conseguir carregar
            }
        }

        private void OcultarQRCodePix()
        {
            panelPix.Visible = false;
            pagamentoPixConfirmado = true; // Para cartão, considera como confirmado
        }

        private decimal CalcularComDesconto(int percentualDesconto)
        {
            return totalCompra * (1 - percentualDesconto / 100m);
        }

        private decimal CalcularComJuros(int percentualJuros)
        {
            return totalCompra * (1 + percentualJuros / 100m);
        }

        private void TelaPagamentos_Load(object sender, EventArgs e)
        {
            try
            {
                this.BackgroundImage = Livraria.Properties.Resources.TelaPerfilLivro;
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
/* private decimal totalCompra;
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

*/