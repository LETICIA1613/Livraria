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
    public partial class FormQuantidadeEstoque: Form
    {
        public FormQuantidadeEstoque()
        {
            InitializeComponent();
        }
        public int Quantidade { get; private set; }
        private int estoqueMaximo;

        public FormQuantidadeEstoque(string titulo, string livroNome, int estoqueMaximo = int.MaxValue)
        {
            InitializeComponent();
            this.Text = titulo;
            this.estoqueMaximo = estoqueMaximo;
            ConfigurarControles(livroNome, titulo);
        }

        private void ConfigurarControles(string livroNome, string operacao)
        {
            this.Size = new Size(400, 200);
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            // Label do livro
            Label lblLivro = new Label();
            lblLivro.Text = $"Livro: {livroNome}";
            lblLivro.Font = new Font("Arial", 10, FontStyle.Bold);
            lblLivro.Size = new Size(350, 30);
            lblLivro.Location = new Point(20, 20);
            this.Controls.Add(lblLivro);

            // Label da quantidade
            Label lblQuantidade = new Label();
            lblQuantidade.Text = "Quantidade:";
            lblQuantidade.Font = new Font("Arial", 10);
            lblQuantidade.Size = new Size(100, 25);
            lblQuantidade.Location = new Point(20, 60);
            this.Controls.Add(lblQuantidade);

            // NumericUpDown
            NumericUpDown numQuantidade = new NumericUpDown();
            numQuantidade.Size = new Size(100, 25);
            numQuantidade.Location = new Point(120, 60);
            numQuantidade.Minimum = 1;
            numQuantidade.Maximum = estoqueMaximo;
            numQuantidade.Value = 1;
            this.Controls.Add(numQuantidade);

            // Botão Confirmar
            Button btnConfirmar = new Button();
            btnConfirmar.Text = "✅ Confirmar";
            btnConfirmar.Size = new Size(120, 35);
            btnConfirmar.Location = new Point(100, 110);
            btnConfirmar.BackColor = Color.Green;
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Font = new Font("Arial", 10, FontStyle.Bold);
            btnConfirmar.Click += (s, e) =>
            {
                Quantidade = (int)numQuantidade.Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            };
            this.Controls.Add(btnConfirmar);

            // Botão Cancelar
            Button btnCancelar = new Button();
            btnCancelar.Text = "❌ Cancelar";
            btnCancelar.Size = new Size(120, 35);
            btnCancelar.Location = new Point(230, 110);
            btnCancelar.BackColor = Color.Red;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Font = new Font("Arial", 10, FontStyle.Bold);
            btnCancelar.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
            this.Controls.Add(btnCancelar);

            // Aviso de estoque máximo
            if (estoqueMaximo < int.MaxValue && operacao.Contains("Remover"))
            {
                Label lblAviso = new Label();
                lblAviso.Text = $"Estoque atual: {estoqueMaximo} unidades";
                lblAviso.Font = new Font("Arial", 9, FontStyle.Italic);
                lblAviso.ForeColor = Color.Blue;
                lblAviso.Size = new Size(200, 20);
                lblAviso.Location = new Point(230, 63);
                this.Controls.Add(lblAviso);
            }
        }
    }
}

