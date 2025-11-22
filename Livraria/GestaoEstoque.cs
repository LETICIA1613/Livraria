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
        private DataGridView dataGridViewEstoque;
        private Label lblResumo;

        public GestaoEstoque()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            this.Size = new Size(1000, 600);
            this.Text = "📦 Gestão de Estoque";
            this.StartPosition = FormStartPosition.CenterScreen;

            InicializarComponentes();
            CarregarEstoque();
        }

        private void InicializarComponentes()
        {
            // Painel de controles
            Panel panelControles = new Panel();
            panelControles.Size = new Size(980, 60);
            panelControles.Location = new Point(10, 10);
            panelControles.BackColor = Color.SkyBlue;
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
            btnRemover.BackColor = Color.BlueViolet;
            btnRemover.ForeColor = Color.White;
            btnRemover.Font = new Font("Arial", 10, FontStyle.Bold);
            btnRemover.Click += BtnRemoverEstoque_Click;
            panelControles.Controls.Add(btnRemover);

            // Botão Ativar/Desativar
            Button btnAtivarDesativar = new Button();
            btnAtivarDesativar.Text = "⚡ Ativar/Desativar";
            btnAtivarDesativar.Size = new Size(150, 40);
            btnAtivarDesativar.Location = new Point(340, 10);
            btnAtivarDesativar.BackColor = Color.Teal;
            btnAtivarDesativar.ForeColor = Color.White;
            btnAtivarDesativar.Font = new Font("Arial", 10, FontStyle.Bold);
            btnAtivarDesativar.Click += BtnAtivarDesativar_Click;
            panelControles.Controls.Add(btnAtivarDesativar);

            // Botão Atualizar
            Button btnAtualizar = new Button();
            btnAtualizar.Text = "🔄 Atualizar";
            btnAtualizar.Size = new Size(120, 40);
            btnAtualizar.Location = new Point(500, 10);
            btnAtualizar.BackColor = Color.MediumPurple;
            btnAtualizar.ForeColor = Color.White;
            btnAtualizar.Font = new Font("Arial", 10, FontStyle.Bold);
            btnAtualizar.Click += (s, e) => CarregarEstoque();
            panelControles.Controls.Add(btnAtualizar);

            // Botão Relatório
            Button btnRelatorio = new Button();
            btnRelatorio.Text = "📊 Relatório";
            btnRelatorio.Size = new Size(120, 40);
            btnRelatorio.Location = new Point(630, 10);
            btnRelatorio.BackColor = Color.Purple;
            btnRelatorio.ForeColor = Color.White;
            btnRelatorio.Font = new Font("Arial", 10, FontStyle.Bold);
            btnRelatorio.Click += BtnRelatorio_Click;
            panelControles.Controls.Add(btnRelatorio);

            // DataGridView
            dataGridViewEstoque = new DataGridView();
            dataGridViewEstoque.Size = new Size(980, 450);
            dataGridViewEstoque.Location = new Point(10, 80);
            dataGridViewEstoque.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEstoque.ReadOnly = true;
            dataGridViewEstoque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEstoque.RowHeadersVisible = false;
            this.Controls.Add(dataGridViewEstoque);

            // Label de resumo
            lblResumo = new Label();
            lblResumo.Size = new Size(500, 30);
            lblResumo.Location = new Point(10, 540);
            lblResumo.Font = new Font("Arial", 10, FontStyle.Bold);
            lblResumo.ForeColor = Color.DarkBlue;
            this.Controls.Add(lblResumo);
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
                            L.Quantidade as 'Quantidade',
                            CASE 
                                WHEN L.Quantidade = 0 THEN 'ESGOTADO'
                                WHEN L.Quantidade <= 5 THEN 'BAIXO'
                                ELSE 'NORMAL'
                            END as 'Status',
                            CASE 
                                WHEN L.Ativo = 1 THEN 'ATIVO'
                                ELSE 'INATIVO'
                            END as 'Situação'
                        FROM Livros L
                        ORDER BY L.Ativo DESC, L.Quantidade ASC, L.Nome";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                        dataGridViewEstoque.DataSource = dt;
                        AplicarFormatoGrid();
                        AtualizarResumo();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar estoque: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFormatoGrid()
        {
            if (dataGridViewEstoque.Columns.Count > 0)
            {
                // Esconder coluna ID
                if (dataGridViewEstoque.Columns["Id"] != null)
                    dataGridViewEstoque.Columns["Id"].Visible = false;

                // Formatar coluna de preço
                if (dataGridViewEstoque.Columns["Preço"] != null)
                    dataGridViewEstoque.Columns["Preço"].DefaultCellStyle.Format = "C2";

                // Colorir linhas baseado no status e situação
                foreach (DataGridViewRow row in dataGridViewEstoque.Rows)
                {
                    // Status do estoque
                    if (row.Cells["Status"]?.Value != null)
                    {
                        var status = row.Cells["Status"].Value.ToString();
                        switch (status)
                        {
                            case "ESGOTADO":
                                row.DefaultCellStyle.BackColor = Color.LightCoral;
                                row.DefaultCellStyle.ForeColor = Color.DarkRed;
                                break;
                            case "BAIXO":
                                row.DefaultCellStyle.BackColor = Color.LightYellow;
                                row.DefaultCellStyle.ForeColor = Color.OrangeRed;
                                break;
                            case "NORMAL":
                                row.DefaultCellStyle.BackColor = Color.LightGreen;
                                row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                                break;
                        }
                    }

                    // Situação (Ativo/Inativo)
                    if (row.Cells["Situação"]?.Value != null)
                    {
                        var situacao = row.Cells["Situação"].Value.ToString();
                        if (situacao == "INATIVO")
                        {
                            // Se estiver inativo, aplicar estilo diferente
                            row.DefaultCellStyle.BackColor = Color.LightGray;
                            row.DefaultCellStyle.ForeColor = Color.Gray;
                            row.DefaultCellStyle.Font = new Font(dataGridViewEstoque.Font, FontStyle.Italic);
                        }
                    }
                }
            }
        }

        private void BtnAdicionarEstoque_Click(object sender, EventArgs e)
        {
            if (dataGridViewEstoque.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um livro para adicionar estoque!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridViewEstoque.SelectedRows[0];
            int livroId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            string livroNome = selectedRow.Cells["Livro"].Value.ToString();
            string situacao = selectedRow.Cells["Situação"].Value.ToString();

            if (situacao == "INATIVO")
            {
                MessageBox.Show("Não é possível adicionar estoque a um livro inativo!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Usar InputBox personalizado
            int quantidade = MostrarInputBoxQuantidade("Adicionar Estoque",
                $"Quantidade a adicionar para '{livroNome}':", 1);

            if (quantidade > 0)
            {
                AtualizarQuantidade(livroId, quantidade, true);
            }
        }

        private void BtnRemoverEstoque_Click(object sender, EventArgs e)
        {
            if (dataGridViewEstoque.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um livro para remover estoque!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridViewEstoque.SelectedRows[0];
            int livroId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            string livroNome = selectedRow.Cells["Livro"].Value.ToString();
            int quantidadeAtual = Convert.ToInt32(selectedRow.Cells["Quantidade"].Value);
            string situacao = selectedRow.Cells["Situação"].Value.ToString();

            if (situacao == "INATIVO")
            {
                MessageBox.Show("Não é possível remover estoque de um livro inativo!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Usar InputBox personalizado
            int quantidade = MostrarInputBoxQuantidade("Remover Estoque",
                $"Quantidade a remover de '{livroNome}' (Quantidade atual: {quantidadeAtual}):", 1, quantidadeAtual);

            if (quantidade > 0)
            {
                if (quantidade <= quantidadeAtual)
                {
                    AtualizarQuantidade(livroId, quantidade, false);
                }
                else
                {
                    MessageBox.Show("Quantidade maior que o estoque atual!", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnAtivarDesativar_Click(object sender, EventArgs e)
        {
            if (dataGridViewEstoque.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um livro para ativar/desativar!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridViewEstoque.SelectedRows[0];
            int livroId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            string livroNome = selectedRow.Cells["Livro"].Value.ToString();
            string situacaoAtual = selectedRow.Cells["Situação"].Value.ToString();

            string novaSituacao = situacaoAtual == "ATIVO" ? "INATIVO" : "ATIVO";
            string acao = situacaoAtual == "ATIVO" ? "desativar" : "ativar";

            var result = MessageBox.Show($"Deseja {acao} o livro '{livroNome}'?",
                "Confirmar Ação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                AlternarSituacaoLivro(livroId, situacaoAtual == "ATIVO" ? 0 : 1);
            }
        }

        private void AlternarSituacaoLivro(int livroId, int novoStatus)
        {
            try
            {
                using (SqlConnection con = Conexao.GetConnection())
                {
                    con.Open();

                    string query = "UPDATE Livros SET Ativo = @Ativo WHERE Id = @LivroId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Ativo", novoStatus);
                        cmd.Parameters.AddWithValue("@LivroId", livroId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            string acao = novoStatus == 1 ? "ativado" : "desativado";
                            MessageBox.Show($"Livro {acao} com sucesso!", "Sucesso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CarregarEstoque();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao alterar situação do livro!", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao alterar situação do livro: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int MostrarInputBoxQuantidade(string titulo, string mensagem, int valorPadrao, int maximo = 1000)
        {
            using (Form form = new Form())
            {
                form.Text = titulo;
                form.Size = new Size(300, 150);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                Label label = new Label() { Left = 20, Top = 20, Text = mensagem, Width = 250 };
                NumericUpDown numericUpDown = new NumericUpDown() { Left = 20, Top = 50, Width = 100, Minimum = 1, Maximum = maximo, Value = valorPadrao };
                Button btnOk = new Button() { Text = "OK", Left = 130, Top = 80, Width = 60, DialogResult = DialogResult.OK };
                Button btnCancel = new Button() { Text = "Cancelar", Left = 200, Top = 80, Width = 60, DialogResult = DialogResult.Cancel };

                btnOk.Click += (sender, e) => { form.Close(); };
                btnCancel.Click += (sender, e) => { form.Close(); };

                form.Controls.Add(label);
                form.Controls.Add(numericUpDown);
                form.Controls.Add(btnOk);
                form.Controls.Add(btnCancel);

                form.AcceptButton = btnOk;
                form.CancelButton = btnCancel;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    return (int)numericUpDown.Value;
                }

                return 0;
            }
        }

        private void AtualizarQuantidade(int livroId, int quantidade, bool isAdicao)
        {
            try
            {
                using (SqlConnection con = Conexao.GetConnection())
                {
                    con.Open();

                    string query = isAdicao ?
                        "UPDATE Livros SET Quantidade = Quantidade + @Quantidade WHERE Id = @LivroId" :
                        "UPDATE Livros SET Quantidade = Quantidade - @Quantidade WHERE Id = @LivroId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Quantidade", quantidade);
                        cmd.Parameters.AddWithValue("@LivroId", livroId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            string operacao = isAdicao ? "adicionado" : "removido";
                            MessageBox.Show($"{quantidade} unidades {operacao} com sucesso!", "Sucesso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CarregarEstoque();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao atualizar quantidade!", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar quantidade: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            COUNT(*) as 'TotalLivros',
                            SUM(Quantidade) as 'TotalQuantidade',
                            SUM(CASE WHEN Quantidade = 0 THEN 1 ELSE 0 END) as 'LivrosEsgotados',
                            SUM(CASE WHEN Quantidade <= 5 AND Quantidade > 0 THEN 1 ELSE 0 END) as 'LivrosQuantidadeBaixa',
                            SUM(CASE WHEN Ativo = 1 THEN 1 ELSE 0 END) as 'LivrosAtivos',
                            SUM(CASE WHEN Ativo = 0 THEN 1 ELSE 0 END) as 'LivrosInativos',
                            AVG(CAST(Quantidade as float)) as 'MediaQuantidade'
                        FROM Livros";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string relatorio = "📊 RELATÓRIO COMPLETO DE ESTOQUE\n\n" +
                                                $"Total de Livros: {reader["TotalLivros"]}\n" +
                                                $"Livros Ativos: {reader["LivrosAtivos"]}\n" +
                                                $"Livros Inativos: {reader["LivrosInativos"]}\n" +
                                                $"Total em Quantidade: {reader["TotalQuantidade"]} unidades\n" +
                                                $"Livros Esgotados: {reader["LivrosEsgotados"]}\n" +
                                                $"Livros com Quantidade Baixa: {reader["LivrosQuantidadeBaixa"]}\n" +
                                                $"Média de Quantidade: {reader["MediaQuantidade"]:F1} unidades";

                                MessageBox.Show(relatorio, "Relatório de Estoque",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            SUM(CASE WHEN Quantidade = 0 THEN 1 ELSE 0 END) as Esgotados,
                            SUM(CASE WHEN Quantidade <= 5 AND Quantidade > 0 THEN 1 ELSE 0 END) as Baixo,
                            SUM(Quantidade) as TotalQuantidade,
                            SUM(CASE WHEN Ativo = 1 THEN 1 ELSE 0 END) as Ativos,
                            SUM(CASE WHEN Ativo = 0 THEN 1 ELSE 0 END) as Inativos
                        FROM Livros";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblResumo.Text = $"📦 Resumo: {reader["Total"]} livros | " +
                                               $"✅ {reader["Ativos"]} ativos | " +
                                               $"❌ {reader["Inativos"]} inativos | " +
                                               $"📚 {reader["TotalQuantidade"]} unidades | " +
                                               $"⚠️ {reader["Baixo"]} estoque baixo | " +
                                               $"🚫 {reader["Esgotados"]} esgotados";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblResumo.Text = "Erro ao carregar resumo";
                Console.WriteLine($"Erro ao atualizar resumo: {ex.Message}");
            }
        }

        private void GestaoEstoque_Load(object sender, EventArgs e)
        {
            BackColor = Color.SkyBlue;
        }
    }
}

