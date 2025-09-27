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
        private readonly string connectionString = @"Data Source=DESKTOP-3DSR1N8\SQLEXPRESS;Initial Catalog=CJ3027481PR2;User Id=sa;Password=leticia"
;
        private Usuario usuario;
        public TelaEntrada()
        {
            InitializeComponent();


        }

        private void TelaEntrada_Load(object sender, EventArgs e)
        {

           
            Txtwrite.Text = "Digite sua busca";
            Txtwrite.ForeColor = Color.Black;

            CarregarLivros();
           
        }
        private void CarregarLivros(string genero = null)
        {
            FlpLivros.Controls.Clear();

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                const string query = @"
                SELECT l.Id,
                       l.Nome,
                       l.Preco,
                       l.Foto,
                       STRING_AGG(a.Nome, ', ') AS Autores
                  FROM Livros l
             LEFT JOIN LivroAutores la ON la.LivroId = l.Id
             LEFT JOIN Autores a ON a.Id = la.AutorId
              GROUP BY l.Id, l.Nome, l.Preco, l.Foto
              ORDER BY l.Nome;";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var card = new LivroCard
                        {
                            Titulo = reader["Nome"].ToString(),
                            Autor = reader["Autores"]?.ToString() ?? "Autor não informado",
                            Preco = $"R$ {Convert.ToDecimal(reader["Preco"]):F2}"
                        };

                        // Foto vinda do banco (campo varbinary)
                        if (reader["Foto"] != DBNull.Value)
                        {
                            byte[] bytes = (byte[])reader["Foto"];
                            using (var ms = new MemoryStream(bytes))
                            {
                                card.Capa = Image.FromStream(ms);
                            }
                        }

                        FlpLivros.Controls.Add(card);
                    }
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
    }
}
