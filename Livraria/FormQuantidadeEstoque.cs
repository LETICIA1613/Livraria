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
    public partial class FormQuantidadeEstoque : Form
    {
        public int Quantidade { get; private set; }

        public FormQuantidadeEstoque(string titulo, string livroNome, int estoqueMaximo = 0)
        {
            InitializeForm(titulo, livroNome, estoqueMaximo);
        }

        private void InitializeForm(string titulo, string livroNome, int estoqueMaximo)
        {
            this.Size = new Size(300, 200);
            this.Text = titulo;
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Label do livro
            Label lblLivro = new Label();
            lblLivro.Text = $"Livro: {livroNome}";
            lblLivro.Font = new Font("Arial", 10, FontStyle.Bold);
            lblLivro.Size = new Size(250, 30);
            lblLivro.Location = new Point(20, 20);
            this.Controls.Add(lblLivro);

            // Label da quantidade
            Label lblQuantidade = new Label();
            lblQuantidade.Text = "Quantidade:";
            lblQuantidade.Font = new Font("Arial", 9);
            lblQuantidade.Size = new Size(100, 20);
            lblQuantidade.Location = new Point(20, 60);
            this.Controls.Add(lblQuantidade);

            // NumericUpDown
            NumericUpDown numQuantidade = new NumericUpDown();
            numQuantidade.Size = new Size(100, 20);
            numQuantidade.Location = new Point(120, 60);
            numQuantidade.Minimum = 1;
            numQuantidade.Maximum = estoqueMaximo > 0 ? estoqueMaximo : 1000;
            numQuantidade.Value = 1;
            this.Controls.Add(numQuantidade);

            // Botão Confirmar
            Button btnConfirmar = new Button();
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.Size = new Size(100, 30);
            btnConfirmar.Location = new Point(50, 100);
            btnConfirmar.BackColor = Color.Green;
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Click += (s, e) =>
            {
                Quantidade = (int)numQuantidade.Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            };
            this.Controls.Add(btnConfirmar);

            // Botão Cancelar
            Button btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Size = new Size(100, 30);
            btnCancelar.Location = new Point(160, 100);
            btnCancelar.BackColor = Color.Gray;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
            this.Controls.Add(btnCancelar);
        }
    }
}

