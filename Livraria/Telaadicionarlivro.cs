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
        string cs = @"Data Source=sqlexpress;Initial Catalog=CJ3027481PR2;User Id=aluno;Password=aluno;";
     
        string caminhoFoto = "";
        private void Btnimage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Arquivos de imagem|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                caminhoFoto = ofd.FileName;
                Picturebook.ImageLocation = caminhoFoto;
            }

        }
        
        private void Btnadd_Click(object sender, EventArgs e)
        {
            var autores = TxtAutor.Text.Split(',');
            byte[] fotoBytes = null;

            if (Picturebook.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Picturebook.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    fotoBytes = ms.ToArray();
                }
            }

            using (SqlConnection con = Conexao.GetConnection())
            {
                con.Open();
                using (SqlTransaction tx = con.BeginTransaction())
                {
                    try
                    {
                        // 1) Inserir livro (sem coluna FaixaEtaria na tabela Livros)
                        string sqlLivro = @"INSERT INTO Livros (Nome, Editora, Preco, Foto, Quantidade)
                                    OUTPUT INSERTED.Id
                                    VALUES (@Nome, @Editora, @Preco, @Foto, @Quantidade)";
                        int livroId;
                        using (SqlCommand cmd = new SqlCommand(sqlLivro, con, tx))
                        {
                            cmd.Parameters.AddWithValue("@Nome", Txtnamebook.Text);
                            cmd.Parameters.AddWithValue("@Editora", TxtEditora.Text);
                            cmd.Parameters.AddWithValue("@Preco", decimal.Parse(TxtPreco.Text));
                            cmd.Parameters.AddWithValue("@Foto", (object)fotoBytes ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Quantidade", int.Parse(Txtquant.Text));
                            livroId = (int)cmd.ExecuteScalar();
                        }

                        // 2) Inserir relação Livro ↔ FaixaEtaria (se houver seleção)
                        if (CbFaixaEtaria.SelectedValue != null && CbFaixaEtaria.SelectedValue != DBNull.Value)
                        {
                            int faixaId = Convert.ToInt32(CbFaixaEtaria.SelectedValue);

                            string sqlFaixaRel = @"
                        IF NOT EXISTS (
                            SELECT 1 FROM LivroFaixaEtaria WHERE LivroId = @LivroId AND FaixaEtariaId = @FaixaId
                        )
                        INSERT INTO LivroFaixaEtaria (LivroId, FaixaEtariaId) VALUES (@LivroId, @FaixaId)";
                            using (SqlCommand cmdFaixa = new SqlCommand(sqlFaixaRel, con, tx))
                            {
                                cmdFaixa.Parameters.AddWithValue("@LivroId", livroId);
                                cmdFaixa.Parameters.AddWithValue("@FaixaId", faixaId);
                                cmdFaixa.ExecuteNonQuery();
                            }
                        }

                        // 3) Autores (seu código original, apenas ajustado para usar a mesma transação)
                        foreach (var autorNome in autores)
                        {
                            string nomeAutor = autorNome.Trim();
                            if (string.IsNullOrEmpty(nomeAutor)) continue;

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
                                    string sqlAutor = @"INSERT INTO Autores (Nome) OUTPUT INSERTED.Id VALUES (@Nome)";
                                    using (SqlCommand cmdAutor = new SqlCommand(sqlAutor, con, tx))
                                    {
                                        cmdAutor.Parameters.AddWithValue("@Nome", nomeAutor);
                                        autorId = (int)cmdAutor.ExecuteScalar();
                                    }
                                }
                            }

                            // relaciona autor ↔ livro (se você tem uma tabela de relação LivroAutores)
                            string sqlRelAutor = @"IF NOT EXISTS (SELECT 1 FROM LivroAutores WHERE LivroId=@LivroId AND AutorId=@AutorId)
                                           INSERT INTO LivroAutores (LivroId, AutorId) VALUES (@LivroId, @AutorId)";
                            using (SqlCommand cmdRelAutor = new SqlCommand(sqlRelAutor, con, tx))
                            {
                                cmdRelAutor.Parameters.AddWithValue("@LivroId", livroId);
                                cmdRelAutor.Parameters.AddWithValue("@AutorId", autorId);
                                cmdRelAutor.ExecuteNonQuery();
                            }
                        }

                        // 4) Gêneros (seu código original)
                        string[] generos = TxtGenero.Text.Split(',')
                            .Select(g => g.Trim())
                            .Where(g => g.Length > 0)
                            .ToArray();

                        foreach (string nomeGenero in generos)
                        {
                            int generoId;

                            string sqlBusca = "SELECT Id FROM Generos WHERE Nome = @Nome";
                            using (SqlCommand cmdBusca = new SqlCommand(sqlBusca, con, tx))
                            {
                                cmdBusca.Parameters.AddWithValue("@Nome", nomeGenero);
                                object result = cmdBusca.ExecuteScalar();
                                if (result != null)
                                {
                                    generoId = Convert.ToInt32(result);
                                }
                                else
                                {
                                    string sqlInsertGenero = "INSERT INTO Generos (Nome) OUTPUT INSERTED.Id VALUES (@Nome)";
                                    using (SqlCommand cmdInsertGen = new SqlCommand(sqlInsertGenero, con, tx))
                                    {
                                        cmdInsertGen.Parameters.AddWithValue("@Nome", nomeGenero);
                                        generoId = (int)cmdInsertGen.ExecuteScalar();
                                    }
                                }
                            }

                            string sqlRelacao = @"
                        IF NOT EXISTS (SELECT 1 FROM LivroGeneros WHERE LivroId = @LivroId AND GeneroId = @GeneroId)
                        INSERT INTO LivroGeneros (LivroId, GeneroId) VALUES (@LivroId, @GeneroId)";
                            using (SqlCommand cmdRel = new SqlCommand(sqlRelacao, con, tx))
                            {
                                cmdRel.Parameters.AddWithValue("@LivroId", livroId);
                                cmdRel.Parameters.AddWithValue("@GeneroId", generoId);
                                cmdRel.ExecuteNonQuery();
                            }
                        }

                        tx.Commit();
                        MessageBox.Show("📚 Livro cadastrado com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                }

               /* var autores = TxtAutor.Text.Split(',');
            byte[] fotoBytes = null;

            if (Picturebook.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Picturebook.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    fotoBytes = ms.ToArray();
                }
            }

            using (SqlConnection con = Conexao.GetConnection())
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();

                try
                {
                    // 1️⃣ Inserir o livro com FaixaEtaria
                    string sqlLivro = @"INSERT INTO Livros (Nome, Editora, Preco, Foto, Quantidade, LivroFaixaEtaria)
                                    OUTPUT INSERTED.Id
                                    VALUES (@Nome, @Editora, @Preco, @Foto, @Quantidade, @FaixaEtaria)";
                    int livroId;

                    using (SqlCommand cmd = new SqlCommand(sqlLivro, con, tx))
                    {
                        cmd.Parameters.AddWithValue("@Nome", Txtnamebook.Text);
                        cmd.Parameters.AddWithValue("@Editora", TxtEditora.Text);
                        cmd.Parameters.AddWithValue("@Preco", decimal.Parse(TxtPreco.Text));
                        cmd.Parameters.AddWithValue("@Foto", (object)fotoBytes ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Quantidade", int.Parse(Txtquant.Text));
                        cmd.Parameters.AddWithValue("@FaixaEtaria", TxtFaixaEtaria.Text); // <- NOVO CAMPO
                        livroId = (int)cmd.ExecuteScalar();
                    }

                    // 2️⃣ Inserir autores e vincular
                    foreach (var autorNome in autores)
                    {
                        string nomeAutor = autorNome.Trim();
                        if (string.IsNullOrEmpty(nomeAutor)) continue;

                        int autorId;
                        string sqlSelect = "SELECT Id FROM Autores WHERE Nome = @Nome";
                        using (SqlCommand cmdSel = new SqlCommand(sqlSelect, con, tx))
                        {
                            cmdSel.Parameters.AddWithValue("@Nome", nomeAutor);
                            object result = cmdSel.ExecuteScalar();

                            if (result != null)
                                autorId = (int)result;
                            else
                            {
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

                        // 3️⃣ Inserir gêneros e vincular
                        string[] generos = TxtGenero.Text.Split(',')
                            .Select(g => g.Trim())
                            .Where(g => g.Length > 0)
                            .ToArray();

                        foreach (string nomeGenero in generos)
                        {
                            int generoId;
                            string sqlBusca = "SELECT Id FROM Generos WHERE Nome = @Nome";
                            using (SqlCommand cmdBusca = new SqlCommand(sqlBusca, con, tx))
                            {
                                cmdBusca.Parameters.AddWithValue("@Nome", nomeGenero);
                                object result = cmdBusca.ExecuteScalar();
                                if (result != null)
                                {
                                    generoId = Convert.ToInt32(result);
                                }
                                else
                                {
                                    string sqlInsertGenero = "INSERT INTO Generos (Nome) OUTPUT INSERTED.Id VALUES (@Nome)";
                                    using (SqlCommand cmdInsertGen = new SqlCommand(sqlInsertGenero, con, tx))
                                    {
                                        cmdInsertGen.Parameters.AddWithValue("@Nome", nomeGenero);
                                        generoId = (int)cmdInsertGen.ExecuteScalar();
                                    }
                                }
                            }

                            // 4️⃣ Relacionar livro ↔ gênero
                            string sqlRelacao = @"IF NOT EXISTS (
                             SELECT 1 FROM LivroGeneros 
                             WHERE LivroId = @LivroId AND GeneroId = @GeneroId)
                          INSERT INTO LivroGeneros (LivroId, GeneroId) 
                          VALUES (@LivroId, @GeneroId)";
                            using (SqlCommand cmdRel = new SqlCommand(sqlRelacao, con, tx))
                            {
                                cmdRel.Parameters.AddWithValue("@LivroId", livroId);
                                cmdRel.Parameters.AddWithValue("@GeneroId", generoId);
                                cmdRel.ExecuteNonQuery();
                            }
                        }
                    }

                    tx.Commit();
                    MessageBox.Show("📚 Livro cadastrado com sucesso!");
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("Erro ao cadastrar: " + ex.Message);
                }*/
            }
        }
        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void Telaadicionarlivro_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = Conexao.GetConnection())
            {
                string sql = "SELECT Id, Idade FROM FaixaEtaria";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                CbFaixaEtaria.DataSource = dt;
                CbFaixaEtaria.DisplayMember = "Idade";
                CbFaixaEtaria.ValueMember = "Id";
            }
        }
    }
    }

