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
            CarregarFiltros();
            CarregarGeneros();
        }


        private void TelaEntrada_Load(object sender, EventArgs e)
        {


            Txtwrite.Text = "Digite sua busca";
            Txtwrite.ForeColor = Color.Black;

            CarregarLivros();
            CarregarGeneros();

        }

        private void CarregarFiltros()
        {
            // 💰 Preço
            ClbPreco.Items.Clear();
            ClbPreco.Items.Add("Até R$20");
            ClbPreco.Items.Add("R$20 a R$30");
            ClbPreco.Items.Add("R$30 a R$50");
            ClbPreco.Items.Add("R$50 a R$80");
            ClbPreco.Items.Add("Mais de R$80");

            // ✍️ Autores
            using (SqlConnection con = Conexao.GetConnection())
            {
                con.Open();
                SqlDataAdapter daAutor = new SqlDataAdapter("SELECT Id, Nome FROM Autores", con);
                DataTable dtAutor = new DataTable();
                daAutor.Fill(dtAutor);

                ClbFiltroAutor.Items.Clear();
                foreach (DataRow row in dtAutor.Rows)
                {
                    ClbFiltroAutor.Items.Add(new AutorItem
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Nome = row["Nome"].ToString()
                    }, false);
                }
            }

            // 👶 Faixa etária
            using (SqlConnection con = Conexao.GetConnection())
            {
                con.Open();
                SqlDataAdapter daFaixa = new SqlDataAdapter("SELECT Id, Idades FROM FaixaEtaria", con);
                DataTable dtFaixa = new DataTable();
                daFaixa.Fill(dtFaixa);

                CbFiltroFX.DataSource = dtFaixa;
                CbFiltroFX.DisplayMember = "Idades";
                CbFiltroFX.ValueMember = "Id";
                CbFiltroFX.SelectedIndex = -1;
            }
        }
/*
        private void CarregarFiltros()
        {
            // Filtro de preço manual
            ClbPreco.Items.Clear();
            ClbPreco.Items.Add("Até R$20");
            ClbPreco.Items.Add("R$20 a R$30");
            ClbPreco.Items.Add("R$30 a R$50");
            ClbPreco.Items.Add("R$50 a R$80");
            ClbPreco.Items.Add("Mais de R$80");

            // Filtro de Autor
            using (SqlConnection con = Conexao.GetConnection())
            {
                con.Open();
                SqlDataAdapter daAutor = new SqlDataAdapter("SELECT Id, Nome FROM Autores", con);
                DataTable dtAutor = new DataTable();
                daAutor.Fill(dtAutor);

                ClbFiltroAutor.Items.Clear();
                foreach (DataRow row in dtAutor.Rows)
                {
                    ClbFiltroAutor.Items.Add(new ListItem(row["Nome"].ToString(), row["Id"].ToString()));
                }
            }

            // Filtro de Faixa Etária (ComboBox)
            using (SqlConnection con = Conexao.GetConnection())
            {
                con.Open();
                SqlDataAdapter daFaixa = new SqlDataAdapter("SELECT Id, Idades FROM FaixaEtaria", con);
                DataTable dtFaixa = new DataTable();
                daFaixa.Fill(dtFaixa);

                CbFiltroFX.DataSource = dtFaixa;
                CbFiltroFX.DisplayMember = "Idades";
                CbFiltroFX.ValueMember = "Id";
                CbFiltroFX.SelectedIndex = -1;
            }
        }*/

        private void CarregarLivros(
    string Nome = "",
    List<int> generos = null,
    List<int> autores = null,
    int faixaEtaria = 0,
    
    List<(decimal min, decimal max)> precos = null)
            
        {

            FlpLivros.Controls.Clear();

            using (SqlConnection con = Conexao.GetConnection())
            {
                con.Open();

                // Query base com LEFT JOINs para muitos-para-muitos
                string query = @"
            SELECT DISTINCT L.Id, L.Nome, L.Preco, L.Foto, L.Editoraid, E.Nome AS EditoraNome, F.Idades AS FaixaEtaria
            FROM Livros L
            JOIN Editora E ON L.Editoraid = E.Id
            JOIN FaixaEtaria F ON L.FaixaEtariaId = F.Id
            LEFT JOIN LivroGeneros LG ON L.Id = LG.LivroId
            LEFT JOIN Generos G ON LG.GeneroId = G.Id
            LEFT JOIN LivroAutores  LA ON L.Id = LA.LivroId
            LEFT JOIN Autores A ON LA.AutorId = A.Id
            WHERE 1=1
        ";

                // 🔍 Busca por nome
                if (!string.IsNullOrEmpty(Nome))
                    query += " AND L.Nome LIKE @Nome";

                // 🎨 Filtro de gêneros
                if (generos != null && generos.Count > 0)
                    query += " AND LG.GeneroId IN (" + string.Join(",", generos) + ")";

                // ✍️ Filtro de autores
                if (autores != null && autores.Count > 0)
                    query += " AND LA.AutorId IN (" + string.Join(",", autores) + ")";

                // 👶 Faixa etária
                if (faixaEtaria > 0)
                    query += " AND L.FaixaEtariaId = @Faixa";

                // 💰 Faixas de preço
                if (precos != null && precos.Count > 0)
                {
                    List<string> condicoesPreco = new List<string>();
                    foreach (var faixa in precos)
                        condicoesPreco.Add($"(L.Preco >= {faixa.min} AND L.Preco <= {faixa.max})");

                    query += " AND (" + string.Join(" OR ", condicoesPreco) + ")";
                }

                SqlCommand cmd = new SqlCommand(query, con);

                if (!string.IsNullOrEmpty(Nome))
                    cmd.Parameters.AddWithValue("@Nome", "%" + Nome + "%");

                if (faixaEtaria > 0)
                    cmd.Parameters.AddWithValue("@Faixa", faixaEtaria);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LivroCard card = new LivroCard
                    {
                        LivroId = Convert.ToInt32(reader["Id"]), // 🧠 importante
                        Titulo = reader["Nome"].ToString(),
                        Editora = reader["EditoraNome"].ToString(),
                        Preco = "R$ " + Convert.ToDecimal(reader["Preco"]).ToString("F2")
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

                /*// 🔽 Executa e monta os cards
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LivroCard card = new LivroCard
                    {
                        Titulo = reader["Nome"].ToString(),
                        Editora = reader["EditoraNome"].ToString(),
                        Preco = "R$ " + reader["Preco"].ToString()
                        // Não mostramos gêneros nem autores
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
                }*/
            }
        }/*

/*
        private void CarregarLivros(
    string Nome = "",
    List<int> generos = null,
    int faixaEtaria = 0,
    List<(decimal min, decimal max)> precos = null)
        {
            FlpLivros.Controls.Clear();
            ClbFiltroAutor.Items.Clear();


            using (SqlConnection con = Conexao.GetConnection())
            {
                con.Open();

               
                // Query base
                string query = @"
            SELECT DISTINCT L.Id, L.Nome, L.Preco, L.Foto, L.Editoraid, E.Nome AS EditoraNome, F.Idades AS FaixaEtaria
            FROM Livros L
            JOIN Editora E ON L.Editoraid = E.Id
            JOIN FaixaEtaria F ON L.FaixaEtariaId = F.Id
            LEFT JOIN LivroGeneros LG ON L.Id = LG.LivroId
            LEFT JOIN Generos G ON LG.GeneroId = G.Id
            WHERE 1=1
        ";

                // 🔍 Busca por nome
                if (!string.IsNullOrEmpty(Nome))
                    query += " AND L.Nome LIKE @Nome";

                // 🎨 Filtro de gêneros (muitos-para-muitos)
                if (generos != null && generos.Count > 0)
                    query += " AND LG.GeneroId IN (" + string.Join(",", generos) + ")";

                // 👶 Faixa etária
                if (faixaEtaria > 0)
                    query += " AND L.FaixaEtariaId = @Faixa";

                // 💰 Faixas de preço
                if (precos != null && precos.Count > 0)
                {
                    List<string> condicoesPreco = new List<string>();
                    foreach (var faixa in precos)
                        condicoesPreco.Add($"(L.Preco >= {faixa.min} AND L.Preco <= {faixa.max})");

                    query += " AND (" + string.Join(" OR ", condicoesPreco) + ")";
                }

                SqlCommand cmd = new SqlCommand(query, con);

                if (!string.IsNullOrEmpty(Nome))
                    cmd.Parameters.AddWithValue("@Nome", "%" + Nome + "%");

                if (faixaEtaria > 0)
                    cmd.Parameters.AddWithValue("@Faixa", faixaEtaria);

                // 🔽 Executa e monta os cards
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LivroCard card = new LivroCard
                    {
                        Titulo = reader["Nome"].ToString(),
                        Editora = reader["EditoraNome"].ToString(),
                        Preco = "R$ " + reader["Preco"].ToString()
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
        }
*/
        private void CarregarGeneros()
        {
            using (SqlConnection con = Conexao.GetConnection())
            {
                con.Open();
                string sql = "SELECT Id, Nome FROM Generos";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                ClbGenerosfiltro.Items.Clear(); // limpa itens antigos

                while (reader.Read())
                {
                    GeneroItem genero = new GeneroItem
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nome = reader["Nome"].ToString()
                    };

                    ClbGenerosfiltro.Items.Add(genero, false);
                }
            }
        }

        public class GeneroItem
        {
            public int Id { get; set; }
            public string Nome { get; set; }

            public override string ToString()
            {
                return Nome; // faz o CheckedListBox mostrar o nome automaticamente
            }
        }
        public class AutorItem
        {
            public int Id { get; set; }
            public string Nome { get; set; }

            public override string ToString()
            {
                return Nome; // faz o CheckedListBox mostrar o nome
            }
        }
        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            string busca = Txtwrite.Text.Trim();
            if (busca == "Digite sua busca") busca = string.Empty;

            // 📚 Gêneros selecionados
            List<int> generosSelecionados = new List<int>();
            foreach (var item in ClbGenerosfiltro.CheckedItems)
            {
                if (item is GeneroItem genero)
                    generosSelecionados.Add(genero.Id);
            }

            // ✍️ Autores selecionados
            List<int> autoresSelecionados = new List<int>();
            foreach (var item in ClbFiltroAutor.CheckedItems)
            {
                if (item is AutorItem autor)
                    autoresSelecionados.Add(autor.Id);
            }

            // 👶 Faixa etária
            int faixaEtariaSelecionada = 0;
            if (CbFiltroFX.SelectedValue != null && int.TryParse(CbFiltroFX.SelectedValue.ToString(), out int faixaId))
                faixaEtariaSelecionada = faixaId;

            // 💰 Faixas de preço
            List<(decimal min, decimal max)> faixasPreco = new List<(decimal, decimal)>();
            foreach (var item in ClbPreco.CheckedItems)
            {
                string texto = item.ToString();

                if (texto.Contains("Até R$20")) faixasPreco.Add((0, 20));
                else if (texto.Contains("R$20 a R$30")) faixasPreco.Add((20, 30));
                else if (texto.Contains("R$30 a R$50")) faixasPreco.Add((30, 50));
                else if (texto.Contains("R$50 a R$80")) faixasPreco.Add((50, 80));
                else if (texto.Contains("Mais de R$80")) faixasPreco.Add((80, decimal.MaxValue));
            }

            // 🔽 Carrega livros com todos os filtros
            CarregarLivros(busca, generosSelecionados, autoresSelecionados, faixaEtariaSelecionada, faixasPreco);
        }

       
/*
        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            string busca = Txtwrite.Text.Trim();
            if (busca == "Digite sua busca") busca = string.Empty;

            // 📚 Gêneros selecionados
            List<int> generosSelecionados = new List<int>();
            foreach (var item in ClbGenerosfiltro.CheckedItems)
            {
                if (item is GeneroItem genero)
                    generosSelecionados.Add(genero.Id);
            }


            // 👶 Faixa etária
            int faixaEtariaSelecionada = 0;
            if (CbFiltroFX.SelectedValue != null && int.TryParse(CbFiltroFX.SelectedValue.ToString(), out int faixaId))
                faixaEtariaSelecionada = faixaId;

            // 💰 Faixas de preço (intervalos)
            List<(decimal min, decimal max)> faixasPreco = new List<(decimal, decimal)>();

            foreach (var item in ClbPreco.CheckedItems)
            {
                string texto = item.ToString();

                if (texto.Contains("Até R$20"))
                    faixasPreco.Add((0, 20));
                else if (texto.Contains("R$20 a R$30"))
                    faixasPreco.Add((20, 30));
                else if (texto.Contains("R$30 a R$50"))
                    faixasPreco.Add((30, 50));
                else if (texto.Contains("R$50 a R$80"))
                    faixasPreco.Add((50, 80));
                else if (texto.Contains("Mais de R$80"))
                    faixasPreco.Add((80, decimal.MaxValue));
            }

            // E chama assim:
            CarregarLivros(busca, generosSelecionados, faixaEtariaSelecionada, faixasPreco);
        }
    
        */
    


    private class ListItem
                {
                    public string Text { get; set; }
                    public string Value { get; set; }

                    public ListItem(string text, string value)
                    {
                        Text = text;
                        Value = value;
                    }

                    public override string ToString()
                    {
                        return Text;
                    }
                }


      

        private void Txtwrite_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt01_Click(object sender, EventArgs e)
        {

        }

            
         

        private void Btnmenu_Click(object sender, EventArgs e)
        {
            string buscaTitulo = Txtwrite.Text.Trim();
            if (buscaTitulo == "Digite sua busca") buscaTitulo = string.Empty;

            // 📚 Gêneros selecionados
            List<int> generosSelecionados = new List<int>();
            foreach (var item in ClbGenerosfiltro.CheckedItems)
            {
                if (item is GeneroItem genero)
                    generosSelecionados.Add(genero.Id);
            }

            // ✍️ Autores selecionados
            List<int> autoresSelecionados = new List<int>();
            foreach (var item in ClbFiltroAutor.CheckedItems)
            {
                if (item is AutorItem autor)
                    autoresSelecionados.Add(autor.Id);
            }

            // 👶 Faixa etária
            int faixaEtariaSelecionada = 0;
            if (CbFiltroFX.SelectedValue != null && int.TryParse(CbFiltroFX.SelectedValue.ToString(), out int faixaId))
                faixaEtariaSelecionada = faixaId;

            // 💰 Faixas de preço
            List<(decimal min, decimal max)> faixasPreco = new List<(decimal, decimal)>();
            foreach (var item in ClbPreco.CheckedItems)
            {
                string texto = item.ToString();

                if (texto.Contains("Até R$20")) faixasPreco.Add((0, 20));
                else if (texto.Contains("R$20 a R$30")) faixasPreco.Add((20, 30));
                else if (texto.Contains("R$30 a R$50")) faixasPreco.Add((30, 50));
                else if (texto.Contains("R$50 a R$80")) faixasPreco.Add((50, 80));
                else if (texto.Contains("Mais de R$80")) faixasPreco.Add((80, decimal.MaxValue));
            }

            // 🔽 Carrega livros
            CarregarLivros(buscaTitulo, generosSelecionados, autoresSelecionados, faixaEtariaSelecionada, faixasPreco);
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


        private void FlpLivros_Paint(object sender, PaintEventArgs e)
        {
            FlpLivros.WrapContents = true;
            FlpLivros.AutoScroll = true;
            FlpLivros.FlowDirection = FlowDirection.LeftToRight;
        }
        private void FlpLivros_ControlClick(object sender, EventArgs e)
        {
            Panel card = sender as Panel;
            if (card != null)
            {
                int livroId = (int)card.Tag; // Defina o ID do livro no Tag do card ao criar
                TelaPerfilLivro perfil = new TelaPerfilLivro(livroId);
                perfil.ShowDialog();
            }
        }


    }
}
