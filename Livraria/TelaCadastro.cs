using Livraria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Livraria
{
    public partial class TelaCadastro : Form
    {
        private string connectionString = @"Data Source=sqlexpress;Initial Catalog=CJ3027481PR2;User Id=aluno;Password=aluno;";


        public TelaCadastro()
        {
           
            InitializeComponent();

        }


        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            string nome = TxtNameCadastre.Text.Trim();
            string email = TxtEmailCadastre.Text.Trim();
            DateTime dataNascimento = DateNasci.Value.Date;
            string senha = TxtPWCadastre.Text;
            string confirmarSenha = TxtPWCadastre2.Text;

            // ===== Validações =====
            if (string.IsNullOrEmpty(nome) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(senha) ||
                string.IsNullOrEmpty(confirmarSenha))
            {
                MessageBox.Show("Preencha todos os campos.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (senha != confirmarSenha)
            {
                MessageBox.Show("As senhas não coincidem.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("E-mail inválido.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idade = DateTime.Today.Year - dataNascimento.Year;
            if (dataNascimento.Date > DateTime.Today.AddYears(-idade)) idade--;

            if (idade < 12)
            {
                MessageBox.Show("É necessário ter pelo menos 12 anos para se cadastrar.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ===== Grava no banco apenas se passou nas validações =====
            string query = @"INSERT INTO Usuarios
                             (Nome, Email, DataNascimento, SenhaHash)
                             VALUES (@Nome, @Email, @DataNascimento, @SenhaHash)";

            try
            {
                using (SqlConnection con = Conexao.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@DataNascimento", dataNascimento);
                    string senhaHash = Seguranca.HashSenha(senha);
                    cmd.Parameters.AddWithValue("@SenhaHash", senhaHash);


                    con.Open();
                    int linhas = cmd.ExecuteNonQuery();
                    MessageBox.Show($"Cadastro inserido com sucesso! Linhas afetadas: {linhas}");

                    TelaLogin product = new TelaLogin();
                    this.Visible = false;
                    product.ShowDialog();
                    this.Visible = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir no banco: " + ex.Message);

            }
            Sessao.UsuarioLogado = new Usuario { Nome = nome, Email = email, DataNascimento = dataNascimento };
            new TelaLogin().Show();
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TxtPWCadastre_Enter(object sender, EventArgs e)
        {
            if (TxtPWCadastre.Text == "Senha")
            {
                TxtPWCadastre.Text = "";
                TxtPWCadastre.UseSystemPasswordChar = true; // ativa bolinhas
                TxtPWCadastre.ForeColor = Color.Black;
            }
        }


        private void TxtPWCadastre_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtPWCadastre.Text))
            {
                TxtPWCadastre.Text = "Senha";
                TxtPWCadastre.ForeColor = Color.Black; // cor de placeholder
            }
        }

        private void TxtPWCadastre2_Enter(object sender, EventArgs e)
        {

            if (TxtPWCadastre2.Text == "Confirmar Senha")
            {
                TxtPWCadastre2.Text = "";
                TxtPWCadastre2.UseSystemPasswordChar = true; // ativa bolinhas
                TxtPWCadastre2.ForeColor = Color.Black;
            }

        }

        private void TxtPWCadastre2_Leave(object sender, EventArgs e)
        {
        }

        private void TelaCadastro_Load(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TelaLogin product = new TelaLogin();
            this.Visible = false;
            product.ShowDialog();
            this.Visible = true;
        }

        private void TxtEmailCadastre_Enter(object sender, EventArgs e)
        {
            if (TxtEmailCadastre.Text == "E-mail")
            {
                TxtEmailCadastre.Text = "";
                TxtEmailCadastre.ForeColor = Color.Black; // cor normal do texto
            }
        }

        private void TxtEmailCadastre_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtEmailCadastre.Text))
            {
                TxtEmailCadastre.Text = "E-mail";
                TxtEmailCadastre.ForeColor = Color.Black; // cor de placeholder
            }
        }


        private void TxtNameCadastre_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtNameCadastre_Enter(object sender, EventArgs e)
        {
            if (TxtNameCadastre.Text == "Nome")
            {
                TxtNameCadastre.Text = "";
                TxtNameCadastre.ForeColor = Color.Black; // cor normal do texto
            }
        }

        private void TxtNameCadastre_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNameCadastre.Text))
            {
                TxtNameCadastre.Text = "Nome";
                TxtNameCadastre.ForeColor = Color.Black; // cor de placeholder
            }
        }
        
      
        private bool mostrandoSenha = false;
        private void Pictureolhos_Click(object sender, EventArgs e)
        {
            mostrandoSenha = !mostrandoSenha;

            if (mostrandoSenha)
            {
                // Mostra a senha
                TxtPWCadastre.UseSystemPasswordChar = false;
                Pictureolhos.Image = Properties.Resources.imagem_olhos1;
            }
            else
            {
                // Esconde a senha
                TxtPWCadastre.UseSystemPasswordChar = true;
                Pictureolhos.Image = Properties.Resources.imagem_olhos2;
            }
        }


    }
}





/*string nome = TxtNameCadastre.Text;
string email = TxtEmailCadastre.Text;
DateTime nascimento = DateNasci.Value;
string senha = TxtPWCadastre.Text;

string senhaHash = HashSenha(senha);
string connectionString = @"Data Source=DESKTOP-3DSR1N8\SQLEXPRESS;Initial Catalog=CJ30274B1PR2;Integrated Security=True;";

using (SqlConnection con = new SqlConnection(connectionString))
{
    try
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            MessageBox.Show("Conexão OK!");
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Erro: " + ex.Message);
    }



    // Verifica se email já existe
    SqlCommand verifica = new SqlCommand("SELECT COUNT(*) FROM Usuarios WHERE Email=@", con);
    verifica.Parameters.AddWithValue("@e", email);
    int count = (int)verifica.ExecuteScalar();

    if (count > 0)
    {
        MessageBox.Show("E-mail já cadastrado!");
        return;
    }

    // Inserir usuário
    SqlCommand cmd = new SqlCommand("INSERT INTO Usuarios (Nome, Email, DataNascimento, SenhaHash) VALUES (@n, @e, @d, @s)", con);
    cmd.Parameters.AddWithValue("@n", nome);
    cmd.Parameters.AddWithValue("@e", email);
    cmd.Parameters.AddWithValue("@d", nascimento);
    cmd.Parameters.AddWithValue("@s", senhaHash);
    cmd.ExecuteNonQuery();

    MessageBox.Show("Cadastro realizado com sucesso!");

    Sessao.UsuarioLogado = new Usuario
    {
        Nome = TxtNameCadastre.Text,
        Email = TxtEmailCadastre.Text,
        DataNascimento = DateNasci.Value

    };
    TelaEntrada product = new TelaEntrada();
    this.Visible = false;
    product.ShowDialog();
    this.Visible = true;


    // Login automático
    Sessao.UsuarioLogado = new Usuario() { Nome = nome, Email = email, DataNascimento = nascimento };
    new TelaEntrada().Show();
    this.Close();


}

          }
*/