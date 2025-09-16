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
using System.Configuration;

namespace Livraria
{
    public partial class Telaadicionarlivro : Form
    {
        
        public Telaadicionarlivro()
        {
            InitializeComponent();
        }
        string sql = "INSERT INTO LivroGeneros (LivroId, GeneroId) VALUES (@LivroId, @GeneroId)";
        string cs = @"Data Source=.\SQLEXPRESS;Initial Catalog=CJ3027481PR2;Integrated Security=True";
     
        string caminhoFoto = "";
        private void Btnimage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Arquivos de imagem|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                caminhoFoto = ofd.FileName;
                Picturebook.ImageLocation = caminhoFoto; // troque pelo nome do seu PictureBox
            }

        }
        
        private void Btnadd_Click(object sender, EventArgs e)
        {
           

            var autores = TxtAutor.Text.Split(','); // divide pelos autores digitados
            byte[] fotoBytes = null;

            if (Picturebook.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Picturebook.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    fotoBytes = ms.ToArray();
                }
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();


                try
                {
                    // 1) Inserir o livro e pegar o ID gerado
                    string sqlLivro = @"INSERT INTO Livros (Nome, Editora, Preco, Foto)
                                OUTPUT INSERTED.Id
                                VALUES (@Nome, @Editora, @Preco, @Foto)";
                    int livroId;
                    using (SqlCommand cmd = new SqlCommand(sqlLivro, con, tx))
                    {
                        cmd.Parameters.AddWithValue("@Nome", Txtnamebook.Text);
                        cmd.Parameters.AddWithValue("@Editora", TxtEditora.Text);
                        cmd.Parameters.AddWithValue("@Preco", decimal.Parse(TxtPreco.Text));
                        cmd.Parameters.AddWithValue("@Foto", (object)fotoBytes ?? DBNull.Value);
                        livroId = (int)cmd.ExecuteScalar();
                    }

                    // 2) Para cada autor, garantir que ele existe em Autores
                    foreach (var autorNome in autores)
                    {
                        string nomeAutor = autorNome.Trim();
                        if (string.IsNullOrEmpty(nomeAutor)) continue;

                        // Tenta pegar Id existente
                        int autorId;
                        string sqlSelect = "SELECT Id FROM Autores WHERE Nome = @Nome";
                        using (SqlCommand cmdSel = new SqlCommand(sqlSelect, con, tx))
                        {
                            cmdSel.Parameters.AddWithValue("@Nome", nomeAutor);
                            object result = cmdSel.ExecuteScalar();
                            if (result != null)
                            {
                                autorId = (int)result;
                            }
                            else
                            {
                                // Se não existe, insere e pega o novo Id
                                string sqlAutor = @"INSERT INTO Autores (Nome)
                                            OUTPUT INSERTED.Id
                                            VALUES (@Nome)";
                                using (SqlCommand cmdAutor = new SqlCommand(sqlAutor, con, tx))
                                {
                                    cmdAutor.Parameters.AddWithValue("@Nome", nomeAutor);
                                    autorId = (int)cmdAutor.ExecuteScalar();
                                }
                            }
                        }
                        string[] generos = TxtGenero.Text.Split(',')
                           .Select(g => g.Trim())
                           .Where(g => g.Length > 0)
                           .ToArray();
                        foreach (string nomeGenero in generos)
                        {
                            // 1) Pega Id do gênero (se existir)
                            int generoId;
                            string sqlSelect = "SELECT Id FROM Generos WHERE Nome = @Nome";
                            using (SqlCommand cmdSel = new SqlCommand(sqlSelect, con, tx))
                            {
                                cmdSel.Parameters.AddWithValue("@Nome", nomeGenero);
                                object result = cmdSel.ExecuteScalar();
                                if (result != null)
                                {
                                    generoId = Convert.ToInt32(result);
                                }
                                else
                                {
                                    // 2) Insere gênero e pega o Id
                                    string sqlInserirGenero = "INSERT INTO Generos (Nome) OUTPUT INSERTED.Id VALUES (@Nome)";
                                    using (SqlCommand cmdIns = new SqlCommand(sqlInserirGenero, con, tx))
                                    {
                                        cmdIns.Parameters.AddWithValue("@Nome", nomeGenero);
                                        generoId = (int)cmdIns.ExecuteScalar();
                                    }
                                }
                            }

                            // 3) Insere relação (evita duplicata)
                            string sqlRel = @"IF NOT EXISTS (SELECT 1 FROM LivroGeneros WHERE LivroId=@LivroId AND GeneroId=@GeneroId)
                            INSERT INTO LivroGeneros (LivroId, GeneroId) VALUES (@LivroId, @GeneroId)";
                            using (SqlCommand cmdRel = new SqlCommand(sqlRel, con, tx))
                            {
                                cmdRel.Parameters.AddWithValue("@LivroId", livroId);
                                cmdRel.Parameters.AddWithValue("@GeneroId", generoId);
                                cmdRel.ExecuteNonQuery();
                            }
                        }
                    }

                    tx.Commit();
                    MessageBox.Show("Livro e autores cadastrados com sucesso!");
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }
    }
    }

