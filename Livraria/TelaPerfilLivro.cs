using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Livraria
{
    public partial class TelaPerfilLivro: Form
    {
        private int livroId;

    
        public TelaPerfilLivro(int id)
        {
            InitializeComponent();
            livroId = id;
            CarregarDetalhes(livroId);
   
        }
        private void CarregarDetalhes(int id)
        {
            using (SqlConnection con = Conexao.GetConnection())
            {
                con.Open();

                string query = @"SELECT L.Nome, L.Editoraid, L.Preco, L.Descricao, F.Idades AS FaixaEtaria,  E.Nome AS EditoraNome, L.Foto AS Foto, A.Nome AS Autor, A.Nacionalidade,
                                 A.Biografia, G.Nome AS Genero 
                                 FROM Livros L 
                                 INNER JOIN Generos G ON L.GenerosId = G.Id
                                 INNER JOIN FaixaEtaria F ON L.FaixaEtariaid = F.Id
                                 INNER JOIN Autores A ON L.AutoresId = A.Id
                                 INNER JOIN Editora E ON L.EditoraId = E.Id
                                 WHERE L.Id = @id";



                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            LblTitulo2.Text = reader["Titulo"].ToString();
                            LblGenero2.Text = "Gênero: " + reader["Genero"].ToString();
                            LblFaixa2.Text = "Faixa: " + reader["FaixaEtaria"].ToString();
                            LblPreco2.Text = "R$ " + Convert.ToDecimal(reader["Preco"]).ToString("F2");

                            LblAutor2.Text = "Autor: " + reader["AutorNome"].ToString();
                            LblNacionalidade.Text = "Nacionalidade: " + reader["Nacionalidade"].ToString();
                            RtbBiografia.Text = reader["Biografia"].ToString();
                            RtbDescricao.Text = reader["Descricao"].ToString();

                            string caminhoCapa = reader["CaminhoCapa"].ToString();
                            try
                            {
                                if (!string.IsNullOrEmpty(caminhoCapa) && System.IO.File.Exists(caminhoCapa))
                                {
                                    PbCapa2.Image = Image.FromFile(caminhoCapa);
                                }
                                else
                                {
                                    PbCapa2.Image = null; // Nenhuma capa disponível
                                    PbCapa2.BackColor = Color.LightGray; // Indica visualmente que não há imagem
                                }
                            }
                            catch
                            {
                                PbCapa2.Image = null;
                                PbCapa2.BackColor = Color.LightGray;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Livro não encontrado!");
                            this.Close();
                        }
                    }
                }
            }
        }


     

        private void BtnComprar1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Livro adicionado ao carrinho! 🛒", "Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
