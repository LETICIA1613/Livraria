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
using System.IO;

namespace Livraria
{
    public partial class TelaPerfilLivro: Form
    {
        private int id;



        public TelaPerfilLivro(int id)
        {
            InitializeComponent();
            InitializeComponent();
            this.id = id; // ✅

        }
        private void TelaPerfilLivro_Load(object sender, EventArgs e)
        {
            CarregarInformacoesDoLivro();
            
            AplicarLayout();
        }

        private void CarregarInformacoesDoLivro()
        {
            using (SqlConnection con = Conexao.GetConnection())
            {
                con.Open();
                string query = @"
                SELECT 
                    L.Nome AS Titulo,
                    L.Preco,
                    L.Foto,
                    L.Descricao,
                    E.Nome AS Editora,
                    F.Idades AS FaixaEtaria,
                    STUFF(
                        (SELECT ', ' + G2.Nome
                         FROM LivroGeneros LG2
                         INNER JOIN Generos G2 ON LG2.GeneroId = G2.Id
                         WHERE LG2.LivroId = L.Id
                         FOR XML PATH('')), 1, 2, '') AS Generos,
                    STUFF(
                        (SELECT ', ' + A2.Nome
                         FROM LivroAutores LA2
                         INNER JOIN Autores A2 ON LA2.AutorId = A2.Id
                         WHERE LA2.LivroId = L.Id
                         FOR XML PATH('')), 1, 2, '') AS Autores,
                    STUFF(
                        (SELECT ', ' + A2.Nacionalidade
                         FROM LivroAutores LA2
                         INNER JOIN Autores A2 ON LA2.AutorId = A2.Id
                         WHERE LA2.LivroId = L.Id
                         FOR XML PATH('')), 1, 2, '') AS Nacionalidades,
                    STUFF(
                        (SELECT '; ' + A2.Biografia
                         FROM LivroAutores LA2
                         INNER JOIN Autores A2 ON LA2.AutorId = A2.Id
                         WHERE LA2.LivroId = L.Id
                         FOR XML PATH('')), 1, 2, '') AS Biografias
                FROM Livros L
                LEFT JOIN Editora E ON L.EditoraId = E.Id
                LEFT JOIN FaixaEtaria F ON L.FaixaEtariaId = F.Id
                WHERE L.Id = @id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            LblTitulo2.Text = reader["Titulo"].ToString();
                            LblPreco2.Text = "R$ " + reader["Preco"].ToString();
                            LblEditora2.Text = reader["Editora"].ToString();
                            LblGenero2.Text = reader["Generos"].ToString();
                            LblFaixa2.Text = reader["FaixaEtaria"].ToString();
                            LblAutor2.Text = reader["Autores"].ToString();
                            LblNacionalidade.Text = reader["Nacionalidades"].ToString();
                            TxtBiografia.Text = reader["Biografias"].ToString();
                            TxtDescricao.Text = reader["Descricao"].ToString();

                            if (reader["Foto"] != DBNull.Value)
                            {
                                var caminhoFoto = reader["Foto"].ToString();
                                if (File.Exists(caminhoFoto))
                                {
                                    PbCapa2.Image = Image.FromFile(caminhoFoto);
                                }
                                else
                                {
                                    PbCapa2.Image = null; // caso a imagem não exista
                                }
                            }
                            else
                            {
                                PbCapa2.Image = null;
                            }
                        }

                    }/*
                    string query = @"
            SELECT DISTINCT 
                L.Nome AS Nome, 
                L.Autoresid, 
                A.Nome AS Autores, 
                L.Descricao AS Descricao, 
                L.Foto AS Foto 
            FROM Livros L
            JOIN Autores A ON L.Autoresid = A.Id
            WHERE L.Id = @id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    // Preenche os labels com os dados do banco
                    LblTitulo2.Text = dr["Nome"].ToString();
                    LblAutor2.Text = dr["Autores"].ToString();
                    LblDescricao2.Text = dr["Descricao"].ToString();

                    // Preenche a capa do livro
                    string caminhoImagem = dr["Foto"].ToString();
                    if (File.Exists(caminhoImagem))
                    {
                        PbCapa2.Image = Image.FromFile(caminhoImagem);
                        PbCapa2.SizeMode = PictureBoxSizeMode.StretchImage; // garante que a imagem se ajuste
                    }

                    // Se algum dia você quiser pegar a imagem direto do banco (byte[])
                    
                    if (dr["Foto"] != DBNull.Value)
                    {
                        byte[] imagemBytes = (byte[])dr["Foto"];
                        using (MemoryStream ms = new MemoryStream(imagemBytes))
                        {
                            PbCapa2.Image = Image.FromStream(ms);
                        }
                    }
                    */
                }
            }

            /*
            using (SqlConnection con = Conexao.GetConnection())
            {
                con.Open();
                string query = @"
    SELECT DISTINCT 
        L.Nome AS Nome, 
        L.Autoresid, 
        A.Nome AS Autores, 
        L.Descricao AS Descricao, 
        L.Foto AS Foto 
    FROM Livros L
    JOIN Autores A ON L.Autoresid = A.Id
    WHERE L.Id = @id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", idLivro);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    LblTitulo2.Text = dr["Nome"].ToString();
                    LblAutor2.Text = dr["Autores"].ToString();
                    LblDescricao2.Text = dr["Descricao"].ToString();

                    string caminhoImagem = dr["Foto"].ToString();
                    if (File.Exists(caminhoImagem))
                    {
                        PbCapa2.Image = Image.FromFile(caminhoImagem);
                    }
                }
            }*/
        }

        private void AplicarLayout()
        {
            var layout = LayoutHelper.Carregar();
            if (layout != null)
            {
                LblTitulo2.Location = layout.PosTitulo;
                LblAutor2.Location = layout.PosAutor;
                TxtDescricao.Location = layout.PosDescricao;
                TxtBiografia.Location = layout.PosBiografia;
                PbCapa2.Location = layout.PosImagem;

                LblTitulo2.Size = layout.TamTitulo;
                LblAutor2.Size = layout.TamAutor;
                TxtBiografia.Size = layout.TamBiografia;
                PbCapa2.Size = layout.TamImagem;
            }
        }

        /*
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
        */



        private void BtnComprar1_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("Livro adicionado ao carrinho! 🛒", "Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LblDescricao2_Click(object sender, EventArgs e)
        {

        }

        private void PbCapa2_Click(object sender, EventArgs e)
        {

        }

        private void LblEditora2_Click(object sender, EventArgs e)
        {

        }

        private void LblGenero2_Click(object sender, EventArgs e)
        {

        }

        private void TxtDescricao_TextChanged(object sender, EventArgs e)
        {
            TxtDescricao.Multiline = true;
            TxtDescricao.ScrollBars = ScrollBars.None; // sem barra de rolagem
            TxtDescricao.ReadOnly = true;
            TxtDescricao.WordWrap = true;               // quebra de linha automática
            TxtDescricao.Height = 200;                  // ajusta a altura para mostrar bastante texto

        }

        private void TxtBiografia_TextChanged(object sender, EventArgs e)
        {
            TxtBiografia.Multiline = true;
            TxtBiografia.ScrollBars = ScrollBars.None;
            TxtBiografia.ReadOnly = true;
            TxtBiografia.WordWrap = true;
            TxtBiografia.Height = 200;

        }
    }
}
