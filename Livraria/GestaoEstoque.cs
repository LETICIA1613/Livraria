using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Livraria
{
    public partial class GestaoEstoque : Form
    {
        public GestaoEstoque()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            this.Size = new Size(1000, 600);
            this.Text = "📦 Gestão de Estoque";

            CarregarEstoque();
            ConfigurarBotoes();
        }
        private void CarregarEstoque()
        {
            try
            {
                using (SqlConnection con = Conexao.GetConnection())
                {
                    con.Open();
                    string query = @"
                        SELECT 
                            L.Id,
                            L.Nome as 'Livro',
                            STUFF((
                                SELECT ', ' + A.Nome
                                FROM LivroAutores LA 
                                INNER JOIN Autores A ON LA.AutorId = A.Id
                                WHERE LA.LivroId = L.Id
                                FOR XML PATH('')
                            ), 1, 2, '') as 'Autor',
                            L.Preco as 'Preço',
                            L.Estoque as 'Estoque Atual',
                            CASE 
                                WHEN L.Estoque = 0 THEN 'ESGOTADO'
                                WHEN L.Estoque <= 5 THEN 'BAIXO'
                                ELSE 'NORMAL'
                            END as 'Status'
                        FROM Livros L
                        ORDER BY L.Estoque ASC, L.Nome";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                        dataGridViewEstoque.DataSource = dt;
                        AplicarFormatoGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar estoque: {ex.Message}");
            }
        }

        private void AplicarFormatoGrid()
        {
            dataGridViewEstoque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEstoque.RowHeadersVisible = false;
            dataGridViewEstoque.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEstoque.ReadOnly = true;

            // Formatar colunas
            if (dataGridViewEstoque.Columns.Count > 0)
            {
                dataGridViewEstoque.Columns["Id"].Visible = false;
                dataGridViewEstoque.Columns["Preço"].DefaultCellStyle.Format = "C2";

                // Colorir linhas baseado no status
                dataGridViewEstoque.CellFormatting += (sender, e) =>
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewEstoque.Columns["Status"].Index)
                    {
                        var cell = dataGridViewEstoque.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        var status = cell.Value?.ToString();

                        switch (status)
                        {
                            case "ESGOTADO":
                                cell.Style.BackColor = Color.LightCoral;
                                cell.Style.ForeColor = Color.DarkRed;
                                break;
                            case "BAIXO":
                                cell.Style.BackColor = Color.LightYellow;
                                cell.Style.ForeColor = Color.OrangeRed;
                                break;
                            case "NORMAL":
                                cell.Style.BackColor = Color.LightGreen;
                                cell.Style.ForeColor = Color.DarkGreen;
                                break;
                        }
                    }
                };
            }
        }

        private void ConfigurarBotoes()
        {
            // Painel de controles
            Panel panelControles = new Panel();
            panelControles.Size = new Size(980, 60);
            panelControles.Location = new Point(10, 10);
            panelControles.BackColor = Color.LightGray;
            this.Controls.Add(panelControles);

            // Botão Adicionar Estoque
            Button btnAdicionar = new Button();
            btnAdicionar.Text = "➕ Adicionar Estoque";
            btnAdicionar.Size = new Size(150, 40);
            btnAdicionar.Location = new Point(20, 10);
            btnAdicionar.BackColor = Color.DodgerBlue;
            btnAdicionar.ForeColor = Color.White;
            btnAdicionar.Font = new Font("Arial", 10, FontStyle.Bold);
            btnAdicionar.Click += BtnAdicionarEstoque_Click;
            panelControles.Controls.Add(btnAdicionar);

            // Botão Remover Estoque
            Button btnRemover = new Button();
            btnRemover.Text = "➖ Remover Estoque";
            btnRemover.Size = new Size(150, 40);
            btnRemover.Location = new Point(180, 10);
            btnRemover.BackColor = Color.Orange;
            btnRemover.ForeColor = Color.White;
            btnRemover.Font = new Font("Arial", 10, FontStyle.Bold);
            btnRemover.Click += BtnRemoverEstoque_Click;
            panelControles.Controls.Add(btnRemover);

            // Botão Atualizar
            Button btnAtualizar = new Button();
            btnAtualizar.Text = "🔄 Atualizar";
            btnAtualizar.Size = new Size(120, 40);
            btnAtualizar.Location = new Point(340, 10);
            btnAtualizar.BackColor = Color.Gray;
            btnAtualizar.ForeColor = Color.White;
            btnAtualizar.Font = new Font("Arial", 10, FontStyle.Bold);
            btnAtualizar.Click += (s, e) => CarregarEstoque();
            panelControles.Controls.Add(btnAtualizar);

            // Botão Relatório
            Button btnRelatorio = new Button();
            btnRelatorio.Text = "📊 Relatório";
            btnRelatorio.Size = new Size(120, 40);
            btnRelatorio.Location = new Point(470, 10);
            btnRelatorio.BackColor = Color.Purple;
            btnRelatorio.ForeColor = Color.White;
            btnRelatorio.Font = new Font("Arial", 10, FontStyle.Bold);
            btnRelatorio.Click += BtnRelatorio_Click;
            panelControles.Controls.Add(btnRelatorio);

            // DataGridView
            dataGridViewEstoque = new DataGridView();
            dataGridViewEstoque.Size = new Size(980, 450);
            dataGridViewEstoque.Location = new Point(10, 80);
            this.Controls.Add(dataGridViewEstoque);

            // Label de resumo
            Label lblResumo = new Label();
            lblResumo.Size = new Size(400, 30);
            lblResumo.Location = new Point(10, 540);
            lblResumo.Font = new Font("Arial", 10, FontStyle.Bold);
            this.Controls.Add(lblResumo);

            AtualizarResumo();
        }

        private void BtnAdicionarEstoque_Click(object sender, EventArgs e)
        {
            if (dataGridViewEstoque.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um livro para adicionar estoque!");
                return;
            }

            var selectedRow = dataGridViewEstoque.SelectedRows[0];
            int livroId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            string livroNome = selectedRow.Cells["Livro"].Value.ToString();

            using (var form = new FormQuantidadeEstoque("Adicionar Estoque", livroNome))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    int quantidade = form.Quantidade;
                    AtualizarEstoque(livroId, quantidade, true);
                }
            }
        }

        private void BtnRemoverEstoque_Click(object sender, EventArgs e)
        {
            if (dataGridViewEstoque.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um livro para remover estoque!");
                return;
            }

            var selectedRow = dataGridViewEstoque.SelectedRows[0];
            int livroId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            string livroNome = selectedRow.Cells["Livro"].Value.ToString();
            int estoqueAtual = Convert.ToInt32(selectedRow.Cells["Estoque Atual"].Value);

            using (var form = new FormQuantidadeEstoque("Remover Estoque", livroNome, estoqueAtual))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    int quantidade = form.Quantidade;
                    AtualizarEstoque(livroId, -quantidade, false);
                }
            }
        }

        private void AtualizarEstoque(int livroId, int quantidade, bool isAdicao)
        {
            try
            {
                using (SqlConnection con = Conexao.GetConnection())
                {
                    con.Open();

                    string query = isAdicao ?
                        "UPDATE Livros SET Estoque = Estoque + @Quantidade WHERE Id = @LivroId" :
                        "UPDATE Livros SET Estoque = Estoque - @Quantidade WHERE Id = @LivroId AND Estoque >= @Quantidade";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Quantidade", quantidade);
                        cmd.Parameters.AddWithValue("@LivroId", livroId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            string operacao = isAdicao ? "adicionado" : "removido";
                            MessageBox.Show($"{quantidade} unidades {operacao} com sucesso!");
                            CarregarEstoque();
                            AtualizarResumo();
                        }
                        else
                        {
                            MessageBox.Show("Erro: Estoque insuficiente para remover!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar estoque: {ex.Message}");
            }
        }

        private void BtnRelatorio_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = Conexao.GetConnection())
                {
                    con.Open();
                    string query = @"
                        SELECT 
                            COUNT(*) as 'Total Livros',
                            SUM(Estoque) as 'Total em Estoque',
                            SUM(CASE WHEN Estoque = 0 THEN 1 ELSE 0 END) as 'Livros Esgotados',
                            SUM(CASE WHEN Estoque <= 5 THEN 1 ELSE 0 END) as 'Livros com Estoque Baixo',
                            AVG(Estoque) as 'Média de Estoque'
                        FROM Livros";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string relatorio = "📊 RELATÓRIO DE ESTOQUE\n\n" +
                                                $"Total de Livros: {reader["Total Livros"]}\n" +
                                                $"Total em Estoque: {reader["Total em Estoque"]} unidades\n" +
                                                $"Livros Esgotados: {reader["Livros Esgotados"]}\n" +
                                                $"Livros com Estoque Baixo: {reader["Livros com Estoque Baixo"]}\n" +
                                                $"Média de Estoque: {reader["Média de Estoque"]:F1} unidades";

                                MessageBox.Show(relatorio, "Relatório de Estoque");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório: {ex.Message}");
            }
        }

        private void AtualizarResumo()
        {
            try
            {
                using (SqlConnection con = Conexao.GetConnection())
                {
                    con.Open();
                    string query = @"
                        SELECT 
                            COUNT(*) as Total,
                            SUM(CASE WHEN Estoque = 0 THEN 1 ELSE 0 END) as Esgotados,
                            SUM(CASE WHEN Estoque <= 5 AND Estoque > 0 THEN 1 ELSE 0 END) as Baixo
                        FROM Livros";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var lblResumo = this.Controls.OfType<Label>().First(l => l.Text.Contains("📦"));
                                lblResumo.Text = $"📦 Resumo: {reader["Total"]} livros | " +
                                               $"⚠️ {reader["Baixo"]} com estoque baixo | " +
                                               $"❌ {reader["Esgotados"]} esgotados";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar resumo: {ex.Message}");
            }
        }

        // Componentes
        private DataGridView dataGridViewEstoque;
    }
}
