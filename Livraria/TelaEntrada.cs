using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Livraria
{
    public partial class TelaEntrada : Form

    {
      
        private Usuario usuario;
        public TelaEntrada()
        {
            InitializeComponent();
            CarregarLivros();


        }

        private void TelaEntrada_Load(object sender, EventArgs e)
        {

           
            Txtwrite.Text = "Digite sua busca";
            Txtwrite.ForeColor = Color.Black;

            CarregarLivros();
           
        }

        private void CarregarLivros(string genero = null)
        {

            using (SqlConnection con = Conexao.GetConnection())
            {

                string sql = @"
                    SELECT l.Titulo, a.Nome AS Autor, l.Preco
                    FROM Livros l
                    INNER JOIN Autores a ON l.Id = a.Id";

                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {

                    string titulo = reader["Titulo"].ToString();
                    string autor = reader["Autor"].ToString();
                    string preco = reader["Preco"].ToString();

                    // Criar um painel para cada livro
                    Panel card = new Panel();
                    card.Width = 200;
                    card.Height = 120;
                    card.BorderStyle = BorderStyle.FixedSingle;
                    card.Margin = new Padding(10);

                    // Label do título
                    Label lblTitulo = new Label();
                    lblTitulo.Text = "📖 " + titulo;
                    lblTitulo.AutoSize = true;
                    lblTitulo.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                    // Label do autor
                    Label lblAutor = new Label();
                    lblAutor.Text = "Autor: " + autor;
                    lblAutor.AutoSize = true;

                    // Label do preço
                    Label lblPreco = new Label();
                    lblPreco.Text = "Preço: R$ " + preco;
                    lblPreco.AutoSize = true;
                    lblPreco.ForeColor = Color.DarkGreen;

                    // Adiciona os labels no card
                    card.Controls.Add(lblTitulo);
                    card.Controls.Add(lblAutor);
                    card.Controls.Add(lblPreco);

                    // Ajusta posição vertical
                    lblAutor.Top = lblTitulo.Bottom + 5;
                    lblPreco.Top = lblAutor.Bottom + 5;

                    // Adiciona o card no FlowLayoutPanel
                    FlpLivros.Controls.Add(card);

                }
            }

        }       
       










        private void Txtwrite_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt01_Click(object sender, EventArgs e)
        {

        }

        private void Btnsciencefiction_Click(object sender, EventArgs e)
        {

        }

        private void Btnmenu_Click(object sender, EventArgs e)
        {
            
        }

        private void Btnfantasy_Click(object sender, EventArgs e)
        {

        }

        private void Txtwrite_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txtwrite.Text))
            {
                Txtwrite.Text = "Digite sua busca";
                Txtwrite.ForeColor = Color.Black; // cor de placeholder
            }
        }
        private void Txtwrite_Enter(object sender, EventArgs e)
        {
            if (Txtwrite.Text == "Digite sua busca")
            {
                Txtwrite.Text = "";
                Txtwrite.ForeColor = Color.Black; // cor normal do texto
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Txtwrite_Click(object sender, EventArgs e)
        {
            if (Txtwrite.Text == "Digite sua busca")
            {
                Txtwrite.Text = "";
                Txtwrite.ForeColor = Color.Black; // cor normal do texto
            }
        }

        private void BtnRomance_Click(object sender, EventArgs e)
        {
            CarregarLivros("Romance");
        }

        private void FlpLivros_Paint(object sender, PaintEventArgs e)
        {
            

        }
    }
}
