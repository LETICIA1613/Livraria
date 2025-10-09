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
        }
        private void CarregarLivros(string Nome = "", List<int> generos = null, int faixaEtaria = 0, List<decimal> precos = null)
        {
            FlpLivros.Controls.Clear();

            using (SqlConnection con = Conexao.GetConnection())
            {
                con.Open();

                string query = "SELECT L.Nome, L.Preco, L.Foto, L.Editoraid, E.Nome, G.Nome AS Genero, F.Idades AS FaixaEtaria " +
                "FROM Livros L " +
                "JOIN Generos G ON L.Generosid = G.id " +
                "JOIN FaixaEtaria F ON L.FaixaEtariaId = F.Id " +
                "JOIN Editora E ON L.Editoraid = E.id " +
                "WHERE 1=1";


                if (!string.IsNullOrEmpty(Nome))
                    query += " AND L.Nome LIKE @Nome";

                if (generos != null && generos.Count > 0)
                    query += " AND L.GenerosId IN (" + string.Join(",", generos) + ")";

                if (faixaEtaria > 0)
                    query += " AND L.FaixaEtariaId = @Faixa";

                if (precos != null && precos.Count > 0)
                    query += " AND L.Preco IN (" + string.Join(",", precos) + ")";

                SqlCommand cmd = new SqlCommand(query, con);

                if (!string.IsNullOrEmpty(Nome))
                    cmd.Parameters.AddWithValue("@Nome", "%" + Nome + "%");

                if (faixaEtaria > 0)
                    cmd.Parameters.AddWithValue("@Faixa", faixaEtaria);

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
        

        /*
        FlpLivros.Controls.Clear();

        using (SqlConnection con = Conexao.GetConnection())
        {
            con.Open();

            string sql = @"
         SELECT L.Nome, E.Nome AS EditoraNome, L.Preco
         FROM Livros L
         INNER JOIN Editora E ON L.EditoraId = E.Id
         INNER JOIN Generos G ON L.GenerosId = G.Id
         WHERE (@Busca = '' OR L.Nome LIKE '%' + @Busca + '%')";




            string query = @"SELECT L.Id, L.Nome, L.Editoraid, L.Preco, L.Foto, L.DataCadastro, A.Nome AS Autor, F.Idades AS FaixaEtaria
                             FROM Livros L
                             JOIN Autores A ON A.Id = L.AutoresId
                             JOIN FaixaEtaria F ON F.Id = L.FaixaEtariaId
                             ";

            List<SqlParameter> parametros = new List<SqlParameter>();

            // --- Filtro de preço ---
            List<(decimal min, decimal max)> precos = new List<(decimal, decimal)>();
            foreach (var item in ClbPreco.CheckedItems)
            {
                switch (item.ToString())
                {
                    case "Até R$20": precos.Add((0, 20)); break;
                    case "R$20 a R$30": precos.Add((20, 30)); break;
                    case "R$30 a R$50": precos.Add((30, 50)); break;
                    case "R$50 a R$80": precos.Add((50, 80)); break;
                    case "Mais de R$80": precos.Add((80, decimal.MaxValue)); break;
                }
            }

            if (precos.Count > 0)
            {
                List<string> condicoes = new List<string>();
                for (int i = 0; i < precos.Count; i++)
                {
                    condicoes.Add($"(L.Preco BETWEEN @Min{i} AND @Max{i})");
                    parametros.Add(new SqlParameter($"@Min{i}", precos[i].min));
                    parametros.Add(new SqlParameter($"@Max{i}", precos[i].max == decimal.MaxValue ? 999999 : precos[i].max));

                }
                query += " AND (" + string.Join(" OR ", condicoes) + ")";
            }

            // --- Filtro de autor ---
            List<int> autorIds = new List<int>();
            foreach (var item in ClbFiltroAutor.CheckedItems)
            {
                ListItem autorItem = (ListItem)item;
                autorIds.Add(int.Parse(autorItem.Value));
            }

            if (autorIds.Count > 0)
            {
                string autorIn = string.Join(",", autorIds);
                query += $" AND L.AutorId IN ({autorIn})";
            }

            // --- Filtro de faixa etária ---
            if (CbFiltroFX.SelectedIndex != -1)
            {
                query += " AND L.FaixaEtariaId = @FaixaEtariaId";
                parametros.Add(new SqlParameter("@FaixaEtariaId", CbFiltroFX.SelectedValue));
            }

            // --- Filtro de novidades ---
            if (ChkNovidades.Checked)
            {
                query += " AND L.DataCadastro >= DATEADD(day, -7, GETDATE())";
            }

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddRange(parametros.ToArray());
            cmd.Parameters.AddWithValue("@Busca", busca);


            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // Aqui você cria seus cards de livros com os dados
                // Exemplo básico:

                LivroCard card = new LivroCard();
                card.Titulo = reader["Nome"].ToString();
                card.Editora = reader["Editoraid"].ToString();
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
    }*/
        /*
        FlpLivros.Controls.Clear();

        using (SqlConnection con = Conexao.GetConnection())
        {
            con.Open();

            string query = "SELECT L.Nome, L.Preco, L.Foto, L.Editoraid F.Idades AS FaixaEtaria, G.Nome AS Genero " +
                           "FROM Livros L " +
                           "JOIN Generos G ON L.GenerosId = G.Id " +
                           "JOIN FaixaEtaria F ON L.FaixaEtariaId = F.Id " +
                           "WHERE 1=1";

            if (!string.IsNullOrEmpty(titulo))
                query += " AND L.Nome LIKE @Nome";

            if (generos != null && generos.Count > 0)
                query += " AND L.GenerosId IN (" + string.Join(",", generos) + ")";

            if (faixaEtaria > 0)
                query += " AND L.FaixaEtariaId = @Faixa";

            if (precos != null && precos.Count > 0)
                query += " AND L.Preco IN (" + string.Join(",", precos) + ")";

            SqlCommand cmd = new SqlCommand(query, con);

            if (!string.IsNullOrEmpty(titulo))
                cmd.Parameters.AddWithValue("@Nome", "%" + titulo + "%");

            if (faixaEtaria > 0)
                cmd.Parameters.AddWithValue("@Faixa", faixaEtaria);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Label lbl = new Label();
                lbl.Text = reader["Nome"].ToString() + " - R$ " + reader["Preco"].ToString();
                lbl.AutoSize = true;
                FlpLivros.Controls.Add(lbl);
            }
        }
    }
        */

        /*
        private void CarregarLivros(string genero = "", string busca = "")
        {

            FlpLivros.Controls.Clear();

            using (SqlConnection con = Conexao.GetConnection())
            {
                con.Open();

                string sql = @"
             SELECT L.Nome, E.Nome AS EditoraNome, L.Preco
             FROM Livros L
             INNER JOIN Editora E ON L.EditoraId = E.Id
             INNER JOIN Generos G ON L.GenerosId = G.Id
             WHERE (@Busca = '' OR L.Nome LIKE '%' + @Busca + '%')";




                string query = @"SELECT L.Id, L.Nome, L.Editoraid, L.Preco, L.Foto, L.DataCadastro, A.Nome AS Autor, F.Idades AS FaixaEtaria
                                 FROM Livros L
                                 JOIN Autores A ON A.Id = L.AutoresId
                                 JOIN FaixaEtaria F ON F.Id = L.FaixaEtariaId
                                 ";

                List<SqlParameter> parametros = new List<SqlParameter>();

                // --- Filtro de preço ---
                List<(decimal min, decimal max)> precos = new List<(decimal, decimal)>();
                foreach (var item in ClbPreco.CheckedItems)
                {
                    switch (item.ToString())
                    {
                        case "Até R$20": precos.Add((0, 20)); break;
                        case "R$20 a R$30": precos.Add((20, 30)); break;
                        case "R$30 a R$50": precos.Add((30, 50)); break;
                        case "R$50 a R$80": precos.Add((50, 80)); break;
                        case "Mais de R$80": precos.Add((80, decimal.MaxValue)); break;
                    }
                }

                if (precos.Count > 0)
                {
                    List<string> condicoes = new List<string>();
                    for (int i = 0; i < precos.Count; i++)
                    {
                        condicoes.Add($"(L.Preco BETWEEN @Min{i} AND @Max{i})");
                        parametros.Add(new SqlParameter($"@Min{i}", precos[i].min));
                        parametros.Add(new SqlParameter($"@Max{i}", precos[i].max == decimal.MaxValue ? 999999 : precos[i].max));

                    }
                    query += " AND (" + string.Join(" OR ", condicoes) + ")";
                }

                // --- Filtro de autor ---
                List<int> autorIds = new List<int>();
                foreach (var item in ClbFiltroAutor.CheckedItems)
                {
                    ListItem autorItem = (ListItem)item;
                    autorIds.Add(int.Parse(autorItem.Value));
                }

                if (autorIds.Count > 0)
                {
                    string autorIn = string.Join(",", autorIds);
                    query += $" AND L.AutorId IN ({autorIn})";
                }

                // --- Filtro de faixa etária ---
                if (CbFiltroFX.SelectedIndex != -1)
                {
                    query += " AND L.FaixaEtariaId = @FaixaEtariaId";
                    parametros.Add(new SqlParameter("@FaixaEtariaId", CbFiltroFX.SelectedValue));
                }

                // --- Filtro de novidades ---
                if (ChkNovidades.Checked)
                {
                    query += " AND L.DataCadastro >= DATEADD(day, -7, GETDATE())";
                }

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddRange(parametros.ToArray());
                cmd.Parameters.AddWithValue("@Busca", busca);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Aqui você cria seus cards de livros com os dados
                    // Exemplo básico:

                    LivroCard card = new LivroCard();
                    card.Titulo = reader["Nome"].ToString();
                    card.Editora = reader["Editoraid"].ToString();
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

        */



        private void CarregarGeneros()
        {
            using (SqlConnection con = Conexao.GetConnection())
            {
                con.Open();
                string sql = "SELECT Id, Nome FROM Generos";  // Verifique o nome da tabela

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                ClbGenerosfiltro.Items.Clear(); // limpa itens antigos

                while (reader.Read())
                {
                    // Adiciona com objeto para poder pegar o Id depois
                    ClbGenerosfiltro.Items.Add(new
                    {
                        Id = reader["Id"],
                        Nome = reader["Nome"].ToString()
                    }, false);
                }
            }

            // Exibir apenas o Nome visualmente
            ClbGenerosfiltro.DisplayMember = "Nome";
            ClbGenerosfiltro.ValueMember = "Id";
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            CarregarLivros();
        }
       
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
           

        /* FlpLivros.Controls.Clear(); // limpa cards antigos

         using (SqlConnection con = Conexao.GetConnection())
         {
             con.Open();

             string sql = @"
             SELECT L.Nome, E.Nome AS EditoraNome, L.Preco
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
                     Editora = reader["EditoraNome"].ToString(), // 👈 agora pega o nome da editora
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
             string sql = "SELECT Nome, Editoraid, Preco, Foto FROM Livros";
             SqlCommand cmd = new SqlCommand(sql, con);
             con.Open();

             SqlDataReader reader = cmd.ExecuteReader();
             while (reader.Read())
             {
                 LivroCard card = new LivroCard();
                 card.Titulo = reader["Nome"].ToString();
                 card.Editora = reader["Editoraid"].ToString();
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


     }*/



        private void Txtwrite_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt01_Click(object sender, EventArgs e)
        {

        }

      

        private void Btnmenu_Click(object sender, EventArgs e)
        {
       
            // Busca por título
            string buscaTitulo = Txtwrite.Text.Trim();

            // Gêneros selecionados (CheckedListBox)
            List<int> generosSelecionados = new List<int>();
            foreach (var item in ClbGenerosfiltro.CheckedItems)
            {
                DataRowView row = item as DataRowView;
                generosSelecionados.Add((int)row["Id"]);
            }

            // Faixa etária selecionada (ComboBox)
            int faixaEtariaSelecionada = 0;
            if (CbFiltroFX.SelectedValue != null)
            {
                faixaEtariaSelecionada = (int)CbFiltroFX.SelectedValue;
            }

            List<decimal> precosSelecionados = new List<decimal>();
            foreach (var item in ClbPreco.CheckedItems)
            {
                DataRowView row = item as DataRowView;
                precosSelecionados.Add(Convert.ToDecimal(row["Valor"])); // supondo que o valor da faixa esteja na coluna "Valor"
            }

            // Chama função para carregar livros com filtros
            CarregarLivros(buscaTitulo, generosSelecionados, faixaEtariaSelecionada, precosSelecionados);
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

       
    }
}
