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
        private void CarregarLivros(string genero = "", string busca = "")
        {
            FlpLivros.Controls.Clear(); // limpa cards antigos

            using (SqlConnection con = Conexao.GetConnection())
            {
                con.Open();

                string sql = @"
            SELECT L.Nome, L.Preco, L.Foto, E.Nome AS Editora
            FROM Livros L
            INNER JOIN Editora E ON L.EditoraId = E.Id
            INNER JOIN Generos G ON L.GenerosId = G.Id
            WHERE (@Generos = '' OR G.Nome = @Generos)
              AND (@Busca = '' OR L.Nome LIKE '%' + @Busca + '%')";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Generos", genero);
                cmd.Parameters.AddWithValue("@Busca", busca);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LivroCard card = new LivroCard
                    {
                        Titulo = reader["Nome"].ToString(),
                        Editora = reader["Editora"].ToString(),
                        Preco = "R$ " + Convert.ToDecimal(reader["Preco"]).ToString("N2")
                    };

                    if (reader["Foto"] != DBNull.Value)
                    {
                        byte[] imgBytes = (byte[])reader["Foto"];
                        using (MemoryStream ms = new MemoryStream(imgBytes))
                        {
                            card.Imagem = Image.FromStream(ms);
                        }
                    }

                    FlpLivros.Controls.Add(card);
                }
            }
   
            using (SqlConnection con = Conexao.GetConnection())
            {
                string sql = "SELECT Nome, Editora, Preco, Foto FROM Livros";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LivroCard card = new LivroCard();
                    card.Titulo = reader["Nome"].ToString();
                    card.Editora = reader["Editora"].ToString();
                    card.Preco = "R$ " + reader["Preco"].ToString();

                    // Converter varbinary em imagem
                    if (reader["Foto"] != DBNull.Value)
                    {
                        byte[] imgBytes = (byte[])reader["Foto"];
                        using (MemoryStream ms = new MemoryStream(imgBytes))
                        {
                            card.Imagem = Image.FromStream(ms);
                        }
                    }

                    FlpLivros.Controls.Add(card); // usa o nome real do teu painel
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
            CarregarLivros("Ficção Científica");
        }

        private void Btnmenu_Click(object sender, EventArgs e)
        {
            CarregarLivros(Txtwrite.Text.Trim());
            string termo = Txtwrite.Text.Trim();
            CarregarLivros("", termo); // "" = sem filtro de gênero
        }

       

        private void Btnfantasy_Click(object sender, EventArgs e)
        {
            CarregarLivros("Fantasia");
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
            FlpLivros.WrapContents = true;
            FlpLivros.AutoScroll = true;
            FlpLivros.FlowDirection = FlowDirection.LeftToRight;
        }

        private void Btnterror_Click(object sender, EventArgs e)
        {
            CarregarLivros("Terror");
        }

        private void Btnselfhelp_Click(object sender, EventArgs e)
        {
            CarregarLivros("Autoajuda");
        }

        private void BtnComedy_Click(object sender, EventArgs e)
        {
            CarregarLivros("Comédia");
        }

        private void Btnthriller_Click(object sender, EventArgs e)
        {
            CarregarLivros("Suspense");
        }

        private void BtnUtopia_Click(object sender, EventArgs e)
        {
            CarregarLivros("Utopia");
        }

        private void Btnreligious_Click(object sender, EventArgs e)
        {
            CarregarLivros("Religioso");
        }

        private void BtnFiction_Click(object sender, EventArgs e)
        {
            CarregarLivros("Ficção");
        }
    
    }
}
