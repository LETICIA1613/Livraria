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
            try
            {
                List<int> generosSelecionados = new List<int>();

                // 📚 Gêneros selecionados (CheckedListBox)
                foreach (KeyValuePair<int, string> item in ClbGenero.CheckedItems)
                {
                    generosSelecionados.Add(item.Key);
                }


                // ⚠️ Verifica se pelo menos 1 gênero foi selecionado
                if (generosSelecionados.Count == 0)
                {
                    MessageBox.Show("Selecione pelo menos um gênero!");
                    return;
                }

                // Gênero principal → o primeiro selecionado
                int generoPrincipalId = generosSelecionados[0];

                // ✍️ Autores separados por vírgula (TextBox)
                string[] nomesAutores = TxtAutor.Text.Split(',');
                List<int> autorIds = new List<int>();

                using (SqlConnection con = Conexao.GetConnection())
                {
                    con.Open();

                    using (SqlTransaction trans = con.BeginTransaction())
                    {
                        try
                        {
                            // 🔄 Processa autores (cria se não existir)
                            foreach (string nome in nomesAutores)
                            {
                                string autor = nome.Trim();
                                if (string.IsNullOrEmpty(autor)) continue;

                                SqlCommand cmdCheck = new SqlCommand("SELECT Id FROM Autores WHERE Nome = @Nome", con, trans);
                                cmdCheck.Parameters.AddWithValue("@Nome", autor);
                                object result = cmdCheck.ExecuteScalar();

                                int autorId;
                                if (result != null)
                                {
                                    autorId = Convert.ToInt32(result);
                                }
                                else
                                {
                                    SqlCommand cmdInsert = new SqlCommand(
                                    "INSERT INTO Autores (Nome, Nacionalidade, Biografia) OUTPUT INSERTED.Id VALUES (@Nome, @Nacionalidade, @Biografia)", con, trans);
                                    cmdInsert.Parameters.AddWithValue("@Nome", autor);
                                    cmdInsert.Parameters.AddWithValue("@Nacionalidade", TxtNacionalidade.Text.Trim());
                                    cmdInsert.Parameters.AddWithValue("@Biografia", TxtBiografia.Text.Trim());
                                    autorId = (int)cmdInsert.ExecuteScalar();

                                }

                                autorIds.Add(autorId);
                            }

                            string autoresIdString = string.Join(",", autorIds);

                            // 🏢 EDITORA (ComboBox)
                            string nomeEditora = CbEditora.Text?.Trim();
                            if (string.IsNullOrEmpty(nomeEditora))
                            {
                                MessageBox.Show("Digite ou selecione uma editora antes de salvar!");
                                return;
                            }

                            int editoraId;
                            SqlCommand cmdCheckEditora = new SqlCommand("SELECT Id FROM Editora WHERE Nome = @Nome", con, trans);
                            cmdCheckEditora.Parameters.AddWithValue("@Nome", nomeEditora);
                            object resultEditora = cmdCheckEditora.ExecuteScalar();

                            if (resultEditora != null)
                            {
                                editoraId = Convert.ToInt32(resultEditora);
                            }
                            else
                            {
                                SqlCommand cmdInsertEditora = new SqlCommand(
                                    "INSERT INTO Editora (Nome) OUTPUT INSERTED.Id VALUES (@Nome)", con, trans);
                                cmdInsertEditora.Parameters.AddWithValue("@Nome", nomeEditora);
                                editoraId = (int)cmdInsertEditora.ExecuteScalar();
                            }

                            // 👶 FAIXA ETÁRIA (ComboBox)
                            int faixaId;
                            string faixaEscolhida = CbFaixaEtaria.Text?.Trim();
                            if (string.IsNullOrEmpty(faixaEscolhida))
                            {
                                MessageBox.Show("Selecione ou digite uma Faixa Etária válida!");
                                return;
                            }

                            SqlCommand cmdFaixa = new SqlCommand("SELECT Id FROM FaixaEtaria WHERE Idades = @Idades", con, trans);
                            cmdFaixa.Parameters.AddWithValue("@Idades", faixaEscolhida);
                            object resultFaixa = cmdFaixa.ExecuteScalar();

                            if (resultFaixa != null)
                            {
                                faixaId = Convert.ToInt32(resultFaixa);
                            }
                            else
                            {
                                SqlCommand cmdInsertFaixa = new SqlCommand(
                                    "INSERT INTO FaixaEtaria (Idades) OUTPUT INSERTED.Id VALUES (@Idades)", con, trans);
                                cmdInsertFaixa.Parameters.AddWithValue("@Idades", faixaEscolhida);
                                faixaId = (int)cmdInsertFaixa.ExecuteScalar();
                            }

                            // 💾 Insere o livro com GenerosId
                            string sqlLivro = @"
                        INSERT INTO Livros
                        (Nome, AutoresId, EditoraId, Preco, Quantidade, FaixaEtariaId, Foto,
                         AnoPublicacao, NumeroPaginas, Idioma, Descricao, GenerosId, DataCadastro, Ativo)
                        VALUES
                        (@Nome, @AutoresId, @EditoraId, @Preco, @Quantidade, @FaixaEtariaId, @Foto,
                         @AnoPublicacao, @NumeroPaginas, @Idioma, @Descricao, @GenerosId, GETDATE(), 1);
                        SELECT SCOPE_IDENTITY();";

                            SqlCommand cmd = new SqlCommand(sqlLivro, con, trans);
                            cmd.Parameters.AddWithValue("@Nome", Txtnamebook.Text);
                            cmd.Parameters.AddWithValue("@AutoresId", autoresIdString);
                            cmd.Parameters.AddWithValue("@EditoraId", editoraId);
                            cmd.Parameters.AddWithValue("@FaixaEtariaId", faixaId);
                            cmd.Parameters.AddWithValue("@GenerosId", generoPrincipalId);
                            cmd.Parameters.AddWithValue("@Preco", decimal.Parse(TxtPreco.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture));
                            cmd.Parameters.AddWithValue("@Quantidade", int.Parse(Txtquant.Text));

                            // 📸 Foto do livro (PictureBox)
                            if (Picturebook.Image != null)
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    Picturebook.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    cmd.Parameters.AddWithValue("@Foto", ms.ToArray());
                                }
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@Foto", DBNull.Value);
                            }

                            // 🆕 Novos campos
                            cmd.Parameters.AddWithValue("@AnoPublicacao", int.Parse(TxtYears.Text));
                            cmd.Parameters.AddWithValue("@NumeroPaginas", int.Parse(TxtPages.Text));
                            cmd.Parameters.AddWithValue("@Idioma", TxtLanguage.Text);
                            cmd.Parameters.AddWithValue("@Descricao", TxtDescription.Text);

                            int idLivro = Convert.ToInt32(cmd.ExecuteScalar());

                            // 🎭 Gêneros extras — Tabela LivroGeneros
                            foreach (int idGenero in generosSelecionados)
                            {
                                SqlCommand cmdGenero = new SqlCommand(
                                    "INSERT INTO LivroGeneros (LivroId, GeneroId) VALUES (@LivroId, @GeneroId)", con, trans);
                                cmdGenero.Parameters.AddWithValue("@LivroId", idLivro);
                                cmdGenero.Parameters.AddWithValue("@GeneroId", idGenero);
                                cmdGenero.ExecuteNonQuery();
                            }

                            trans.Commit();
                            MessageBox.Show("📗 Livro cadastrado com sucesso!");
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            MessageBox.Show("Erro ao cadastrar: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro geral: " + ex.Message);
            }
        }

        /*  try
          {
              List<int> generosSelecionados = new List<int>();

              // 📚 Gêneros selecionados (CheckedListBox)
              foreach (var item in ClbGenero.CheckedItems)
              {
                  if (item is DataRowView row)
                  {
                      generosSelecionados.Add(Convert.ToInt32(row["Id"]));
                  }
              }

              // ✍️ Autores separados por vírgula (TextBox)
              string[] nomesAutores = TxtAutor.Text.Split(',');
              List<int> autorIds = new List<int>();

              using (SqlConnection con = Conexao.GetConnection())
              {
                  con.Open();

                  using (SqlTransaction trans = con.BeginTransaction())
                  {
                      try
                      {
                          // 🔄 Processa autores (cria se não existir)
                          foreach (string nome in nomesAutores)
                          {
                              string autor = nome.Trim();
                              if (string.IsNullOrEmpty(autor)) continue;

                              SqlCommand cmdCheck = new SqlCommand("SELECT Id FROM Autores WHERE Nome = @Nome", con, trans);
                              cmdCheck.Parameters.AddWithValue("@Nome", autor);
                              object result = cmdCheck.ExecuteScalar();

                              int autorId;
                              if (result != null)
                              {
                                  autorId = Convert.ToInt32(result);
                              }
                              else
                              {
                                  SqlCommand cmdInsert = new SqlCommand(
                                      "INSERT INTO Autores (Nome) OUTPUT INSERTED.Id VALUES (@Nome)", con, trans);
                                  cmdInsert.Parameters.AddWithValue("@Nome", autor);
                                  autorId = (int)cmdInsert.ExecuteScalar();
                              }

                              autorIds.Add(autorId);
                          }

                          string autoresIdString = string.Join(",", autorIds);

                          // 🏢 EDITORA (ComboBox)
                          string nomeEditora = CbEditora.Text?.Trim();
                          if (string.IsNullOrEmpty(nomeEditora))
                          {
                              MessageBox.Show("Digite ou selecione uma editora antes de salvar!");
                              return;
                          }

                          int editoraId;
                          SqlCommand cmdCheckEditora = new SqlCommand("SELECT Id FROM Editora WHERE Nome = @Nome", con, trans);
                          cmdCheckEditora.Parameters.AddWithValue("@Nome", nomeEditora);
                          object resultEditora = cmdCheckEditora.ExecuteScalar();

                          if (resultEditora != null)
                          {
                              editoraId = Convert.ToInt32(resultEditora);
                          }
                          else
                          {
                              SqlCommand cmdInsertEditora = new SqlCommand(
                                  "INSERT INTO Editora (Nome) OUTPUT INSERTED.Id VALUES (@Nome)", con, trans);
                              cmdInsertEditora.Parameters.AddWithValue("@Nome", nomeEditora);
                              editoraId = (int)cmdInsertEditora.ExecuteScalar();
                          }

                          // 👶 FAIXA ETÁRIA (ComboBox)
                          int faixaId;
                          string faixaEscolhida = CbFaixaEtaria.Text?.Trim();
                          if (string.IsNullOrEmpty(faixaEscolhida))
                          {
                              MessageBox.Show("Selecione ou digite uma Faixa Etária válida!");
                              return;
                          }

                          SqlCommand cmdFaixa = new SqlCommand("SELECT Id FROM FaixaEtaria WHERE Idades = @Idades", con, trans);
                          cmdFaixa.Parameters.AddWithValue("@Idades", faixaEscolhida);
                          object resultFaixa = cmdFaixa.ExecuteScalar();

                          if (resultFaixa != null)
                          {
                              faixaId = Convert.ToInt32(resultFaixa);
                          }
                          else
                          {
                              SqlCommand cmdInsertFaixa = new SqlCommand(
                                  "INSERT INTO FaixaEtaria (Idades) OUTPUT INSERTED.Id VALUES (@Idades)", con, trans);
                              cmdInsertFaixa.Parameters.AddWithValue("@Idades", faixaEscolhida);
                              faixaId = (int)cmdInsertFaixa.ExecuteScalar();
                          }

                          // 💾 Insere o livro com novos campos
                          string sqlLivro = @"
                      INSERT INTO Livros
                      (Nome, AutoresId, EditoraId, Preco, Quantidade, FaixaEtariaId, Foto,
                       AnoPublicacao, NumeroPaginas, Idioma, Descricao, DataCadastro, Ativo)
                      VALUES
                      (@Nome, @AutoresId, @EditoraId, @Preco, @Quantidade, @FaixaEtariaId, @Foto,
                       @AnoPublicacao, @NumeroPaginas, @Idioma, @Descricao, GETDATE(), 1);
                      SELECT SCOPE_IDENTITY();";

                          SqlCommand cmd = new SqlCommand(sqlLivro, con, trans);
                          cmd.Parameters.AddWithValue("@Nome", Txtnamebook.Text);
                          cmd.Parameters.AddWithValue("@AutoresId", autoresIdString);
                          cmd.Parameters.AddWithValue("@EditoraId", editoraId);
                          cmd.Parameters.AddWithValue("@FaixaEtariaId", faixaId);
                          cmd.Parameters.AddWithValue("@Preco", decimal.Parse(TxtPreco.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture));
                          cmd.Parameters.AddWithValue("@Quantidade", int.Parse(Txtquant.Text));

                          // 📸 Foto do livro (PictureBox)
                          if (Picturebook.Image != null)
                          {
                              using (MemoryStream ms = new MemoryStream())
                              {
                                  Picturebook.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                  cmd.Parameters.AddWithValue("@Foto", ms.ToArray());
                              }
                          }
                          else
                          {
                              cmd.Parameters.AddWithValue("@Foto", DBNull.Value);
                          }

                          // 🆕 Novos campos
                          cmd.Parameters.AddWithValue("@AnoPublicacao", int.Parse(TxtYears.Text));
                          cmd.Parameters.AddWithValue("@NumeroPaginas", int.Parse(TxtPages.Text));
                          cmd.Parameters.AddWithValue("@Idioma", TxtLanguage.Text);
                          cmd.Parameters.AddWithValue("@Descricao", TxtDescription.Text);

                          int idLivro = Convert.ToInt32(cmd.ExecuteScalar());

                          // 🎭 Gêneros
                          foreach (int idGenero in generosSelecionados)
                          {
                              SqlCommand cmdGenero = new SqlCommand(
                                  "INSERT INTO LivroGeneros (LivroId, GeneroId) VALUES (@LivroId, @GeneroId)", con, trans);
                              cmdGenero.Parameters.AddWithValue("@LivroId", idLivro);
                              cmdGenero.Parameters.AddWithValue("@GeneroId", idGenero);
                              cmdGenero.ExecuteNonQuery();
                          }

                          trans.Commit();
                          MessageBox.Show("📗 Livro cadastrado com sucesso!");
                      }
                      catch (Exception ex)
                      {
                          trans.Rollback();
                          MessageBox.Show("Erro ao cadastrar: " + ex.Message);
                      }
                  }
              }
          }
          catch (Exception ex)
          {
              MessageBox.Show("Erro geral: " + ex.Message);
          }
      }
        /*


      /*
        List<int> generosSelecionados = new List<int>();

        // Pega os gêneros selecionados
        foreach (KeyValuePair<int, string> item in ClbGenero.CheckedItems)
        {
            generosSelecionados.Add(item.Key);
        }

        // Pega os autores do TextBox separados por vírgula
        string[] nomesAutores = TxtAutor.Text.Split(',');
        List<int> autorIds = new List<int>();

        using (SqlConnection con = Conexao.GetConnection())
        {
            con.Open();

            // Processa os autores
            foreach (string nome in nomesAutores)
            {
                string autor = nome.Trim();

                // Verifica se já existe
                SqlCommand cmdCheck = new SqlCommand("SELECT Id FROM Autores WHERE Nome = @Nome", con);
                cmdCheck.Parameters.AddWithValue("@Nome", autor);
                object result = cmdCheck.ExecuteScalar();

                int autorId;
                if (result != null)
                {
                    autorId = Convert.ToInt32(result);
                }
                else
                {
                    // Insere se não existir
                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO Autores (Nome) OUTPUT INSERTED.Id VALUES (@Nome)", con);
                    cmdInsert.Parameters.AddWithValue("@Nome", autor);
                    autorId = (int)cmdInsert.ExecuteScalar();
                }

                autorIds.Add(autorId);
            }

            // Concatena os IDs dos autores em uma string separada por vírgula
            string autoresIdString = string.Join(",", autorIds);

            // Primeiro insere o livro
            string sqlLivro = @"INSERT INTO Livros
        (Nome, AutoresId, EditoraId, Preco, Quantidade, FaixaEtariaId, Foto)
        VALUES (@Nome, @AutoresId, @EditoraId, @Preco, @Quantidade, @FaixaEtariaId, @Foto);
        SELECT SCOPE_IDENTITY();"; // pega o Id do livro inserido

            SqlCommand cmd = new SqlCommand(sqlLivro, con);
            cmd.Parameters.AddWithValue("@Nome", Txtnamebook.Text);
            cmd.Parameters.AddWithValue("@AutoresId", autoresIdString); // IDs separados por vírgula
            cmd.Parameters.AddWithValue("@Preco", decimal.Parse(TxtPreco.Text.Replace(",", ".")));
            cmd.Parameters.AddWithValue("@Quantidade", int.Parse(Txtquant.Text));

            // Foto do livro
            if (Picturebook != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Picturebook.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    cmd.Parameters.AddWithValue("@Foto", ms.ToArray());
                }
            }
            else
            {
                cmd.Parameters.AddWithValue("@Foto", DBNull.Value);
            }

            // Editora e faixa etária
            if (CbEditora.SelectedValue != null)
            {
                cmd.Parameters.AddWithValue("@EditoraId", (int)CbEditora.SelectedValue);
            }
            else
            {
                MessageBox.Show("Selecione uma editora antes de salvar!");
                return;
            }
            if (CbFaixaEtaria.SelectedValue != null)
            {
                cmd.Parameters.AddWithValue("@FaixaEtariaId", (int)CbFaixaEtaria.SelectedValue);
            }
            else
            {
                MessageBox.Show("Selecione uma Faixa Etaria antes de salvar!");
                return;
            }

            int idLivro = Convert.ToInt32(cmd.ExecuteScalar()); // pega o Id do livro inserido

            // Insere os gêneros na tabela de ligação LivroGenero
            foreach (int idGenero in generosSelecionados)
            {
                SqlCommand cmdGenero = new SqlCommand(
                    "INSERT INTO LivroGeneros (LivroId, GeneroId) VALUES (@LivroId, @GeneroId)", con);
                cmdGenero.Parameters.AddWithValue("@LivroId", idLivro);
                cmdGenero.Parameters.AddWithValue("@GeneroId", idGenero);
                cmdGenero.ExecuteNonQuery();
            }

            MessageBox.Show("Livro cadastrado com sucesso!");
        }
    }*/

        /*
         List<int> generosSelecionados = new List<int>();

            foreach (KeyValuePair<int, string> item in ClbGenero.CheckedItems)
            {
                generosSelecionados.Add(item.Key);
            }

            // Agora, se seu banco tiver uma tabela de ligação Livro-Genero, você precisará inserir cada Id de gênero separado
            using (SqlConnection con = Conexao.GetConnection())
            {
                con.Open();

                // Primeiro insere o livro
                string sqlLivro = @"INSERT INTO Livros
                    (Nome, AutoresId, EditoraId, Preco, Quantidade, FaixaEtariaId, Foto)
                    VALUES (@Nome, @AutoresId, @EditoraId, @Preco, @Quantidade, @FaixaEtariaId, @Foto);
                    SELECT SCOPE_IDENTITY();"; // pega o Id do livro inserido

                SqlCommand cmd = new SqlCommand(sqlLivro, con);
                cmd.Parameters.AddWithValue("@Nome", Txtnamebook.Text);
                cmd.Parameters.AddWithValue("@AutoresId", (int)CbAutores.SelectedValue);

                cmd.Parameters.AddWithValue("@Preco", decimal.Parse(TxtPreco.Text.Replace(",", ".")));
                cmd.Parameters.AddWithValue("@Quantidade", int.Parse(Txtquant.Text));


                // Foto do livro
                if (Picturebook != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Picturebook.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        cmd.Parameters.AddWithValue("@Foto", ms.ToArray());
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Foto", DBNull.Value);
                }

                int idLivro = Convert.ToInt32(cmd.ExecuteScalar()); // pega o Id do livro inserido

                // Insere os gêneros na tabela de ligação LivroGenero
                foreach (int idGenero in generosSelecionados)
                {
                    SqlCommand cmdGenero = new SqlCommand(
                        "INSERT INTO LivroGenero (LivroId, GeneroId) VALUES (@LivroId, @GeneroId)", con);
                    cmdGenero.Parameters.AddWithValue("@LivroId", idLivro);
                    cmdGenero.Parameters.AddWithValue("@GeneroId", idGenero);
                    cmdGenero.ExecuteNonQuery();


                if (CbEditora.SelectedValue != null)
                {
                    cmd.Parameters.AddWithValue("@EditoraId", (int)CbEditora.SelectedValue);
                }
                else
                {
                    MessageBox.Show("Selecione uma editora antes de salvar!");
                    return;
                }
                if (CbFaixaEtaria.SelectedValue != null)
                {
                    cmd.Parameters.AddWithValue("@FaixaEtariaId", (int)CbFaixaEtaria.SelectedValue);
                }
                else
                {
                    MessageBox.Show("Selecione uma Faixa Etaria antes de salvar!");
                    return;
                }
            }
            }

    }*/


        /*  con.Open();

          string sql = @"INSERT INTO Livros 
                 (Nome, AutoresId, EditoraId, GenerosId, Preco, Quantidade, FaixaEtariaId, Foto)
                 VALUES (@Nome, @AutoresId, @EditoraId, @GenerosId, @Preco, @Quantidade, @FaixaEtariaId, @Foto)";

          SqlCommand cmd = new SqlCommand(sql, con);
          cmd.Parameters.AddWithValue("@Nome", Txtnamebook.Text);
          cmd.Parameters.AddWithValue("@AutoresId", (int)CbAutores.SelectedValue);

          cmd.Parameters.AddWithValue("@GenerosId", (int)ClbGenero.SelectedValue);
          cmd.Parameters.AddWithValue("@Preco", decimal.Parse(TxtPreco.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture));
          cmd.Parameters.AddWithValue("@Quantidade", int.Parse(Txtquant.Text));
          cmd.Parameters.AddWithValue("@FaixaEtariaId", (int)CbFaixaEtaria.SelectedValue);
          if (CbEditora.SelectedValue != null)
          {
              cmd.Parameters.AddWithValue("@EditoraId", (int)CbEditora.SelectedValue);
          }
          else
          {
              MessageBox.Show("Selecione uma editora antes de salvar!");
              return;
          }

          // Foto do livro
          if (Picturebook != null)
          {
              using (MemoryStream ms = new MemoryStream())
              {
                  Picturebook.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                  cmd.Parameters.AddWithValue("@Foto", ms.ToArray());
              }
          }
          else
          {
              cmd.Parameters.AddWithValue("@Foto", DBNull.Value);
          }

          cmd.ExecuteNonQuery();
          MessageBox.Show("Livro adicionado com sucesso!");
      }
  }
*/
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
             using (SqlTransaction tx = con.BeginTransaction())
             {
                 try
                 {
                     // 1) Inserir livro (sem coluna FaixaEtaria na tabela Livros)
                     string sqlLivro = @"INSERT INTO Livros (Nome, Editoraid, Preco, Foto, Quantidade)
                                 OUTPUT INSERTED.Id
                                 VALUES (@Nome, @Editoraid, @Preco, @Foto, @Quantidade)";
                     int livroId;
                     using (SqlCommand cmd = new SqlCommand(sqlLivro, con, tx))
                     {
                         cmd.Parameters.AddWithValue("@Nome", Txtnamebook.Text);
                         cmd.Parameters.AddWithValue("@Editoraid", TxtEditora.Text);
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




        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void Telaadicionarlivro_Load(object sender, EventArgs e)
        {
           
            using (SqlConnection con = Conexao.GetConnection())
            {
             
                con.Open();
             
                
                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Nome FROM Editora", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                CbEditora.DataSource = dt;
                CbEditora.DisplayMember = "Nome";
                CbEditora.ValueMember = "Id";

                
                // Limpa itens anteriores
                ClbGenero.Items.Clear();

                // Busca os gêneros do banco
                SqlDataAdapter daGenero = new SqlDataAdapter("SELECT Id, Nome FROM Generos", con);
                DataTable dtGenero = new DataTable();
                daGenero.Fill(dtGenero);
                
                // Adiciona cada gênero como um objeto KeyValuePair (Id + Nome)
                foreach (DataRow row in dtGenero.Rows)
                {
                    int id = Convert.ToInt32(row["Id"]);
                    string nome = row["Nome"].ToString();

                    ClbGenero.Items.Add(new KeyValuePair<int, string>(id, nome), false);
                }

                // Define como exibir o texto (Nome)
                ClbGenero.DisplayMember = "Value"; // o 'Value' é o Nome
                ClbGenero.ValueMember = "Key";     // o 'Key' é o Id

                foreach (KeyValuePair<int, string> item in ClbGenero.CheckedItems)
                {
                    int idGenero = item.Key;
                    string nomeGenero = item.Value;

                    Console.WriteLine($"Id: {idGenero}, Nome: {nomeGenero}");
                }


                // --- FAIXA ETÁRIA ---
                SqlDataAdapter daFaixa = new SqlDataAdapter("SELECT Id, Idades FROM FaixaEtaria", con);
                DataTable dtFaixa = new DataTable();
                daFaixa.Fill(dtFaixa);
                CbFaixaEtaria.DataSource = dtFaixa;
                CbFaixaEtaria.DisplayMember = "Idades";
                CbFaixaEtaria.ValueMember = "Id";
            }
        }

        private void TxtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClbGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
    
