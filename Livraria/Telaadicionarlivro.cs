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

        private void TxtYears_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtYears_Enter(object sender, EventArgs e)
        {
            if (TxtYears.Text == "Ano de Publicação")
            {
                TxtYears.Text = "";
                TxtYears.ForeColor = Color.Black;
            }
        }

        private void TxtYears_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtYears.Text))
            {
                TxtYears.Text = "Ano de Publicação";
                TxtYears.ForeColor = Color.Black; // cor de placeholder
            }
        }

        private void TxtPages_Enter(object sender, EventArgs e)
        {
            if (TxtPages.Text == "Num páginas")
            {
                TxtPages.Text = "";
                TxtPages.ForeColor = Color.Black;
            }
        }

        private void TxtPages_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtPages.Text))
            {
                TxtPages.Text = "Num páginas";
                TxtPages.ForeColor = Color.Black; // cor de placeholder
            }
        }

        private void TxtLanguage_Enter(object sender, EventArgs e)
        {
            if (TxtLanguage.Text == "Idioma")
            {
                TxtLanguage.Text = "";
                TxtLanguage.ForeColor = Color.Black;
            }
        }

        private void TxtLanguage_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtLanguage.Text))
            {
                TxtLanguage.Text = "Idioma";
                TxtLanguage.ForeColor = Color.Black; // cor de placeholder
            }
        }

        private void TxtDescription_Enter(object sender, EventArgs e)
        {
            if (TxtDescription.Text == "Descrição do livro")
            {
                TxtDescription.Text = "";
                TxtDescription.ForeColor = Color.Black;
            }
        }

        private void TxtDescription_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtDescription.Text))
            {
                TxtDescription.Text = "Descrição do livro";
                TxtDescription.ForeColor = Color.Black; // cor de placeholder
            }
        }

        private void TxtNacionalidade_Enter(object sender, EventArgs e)
        {
            if (TxtNacionalidade.Text == "Nacionalidade do Autor")
            {
                TxtNacionalidade.Text = "";
                TxtNacionalidade.ForeColor = Color.Black;
            }
        }

        private void TxtNacionalidade_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNacionalidade.Text))
            {
                TxtNacionalidade.Text = "Nacionalidade do Autor";
                TxtNacionalidade.ForeColor = Color.Black; // cor de placeholder
            }
        }

        private void TxtBiografia_Enter(object sender, EventArgs e)
        {
            if (TxtBiografia.Text == "Biografia do Autor")
            {
                TxtBiografia.Text = "";
                TxtBiografia.ForeColor = Color.Black;
            }
        }

        private void TxtBiografia_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtBiografia.Text))
            {
                TxtBiografia.Text = "Biografia do Autor";
                TxtBiografia.ForeColor = Color.Black; // cor de placeholder
            }
        }
    }
}
    
