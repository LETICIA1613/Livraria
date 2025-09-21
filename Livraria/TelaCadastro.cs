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
    public partial class TelaCadastro: Form
    {
        private string connectionString = @"Data Source=DESKTOP-3DSR1N8\SQLEXPRESS;Initial Catalog=CJ3027481PR2;Integrated Security=True";


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

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Usuarios (Nome, Email, DataNascimento, Senha) " +
                        "VALUES ('Teste','teste@teste.com','2000-01-01','1234')", con))
                    {
                        int linhas = cmd.ExecuteNonQuery();
                        MessageBox.Show("Linhas inseridas: " + linhas);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

            // ===== Validações =====

            // Campos obrigatórios
            if (string.IsNullOrEmpty(nome) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(senha) ||
                string.IsNullOrEmpty(confirmarSenha))
            {
                MessageBox.Show("Preencha todos os campos.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Senhas iguais
            if (senha != confirmarSenha)
            {
                MessageBox.Show("As senhas não coincidem.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Formato de e-mail simples (opcional)
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("E-mail inválido.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Idade mínima opcional (ex.: 12 anos)
            int idade = DateTime.Today.Year - dataNascimento.Year;
            if (dataNascimento.Date > DateTime.Today.AddYears(-idade)) idade--;

            if (idade < 12)
            {
                MessageBox.Show("É necessário ter pelo menos 12 anos para se cadastrar.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Se chegou até aqui, está tudo validado
            MessageBox.Show(
                $"Cadastro validado!\n\n" +
                $"Nome: {nome}\n" +
                $"E-mail: {email}\n" +
                $"Nascimento: {dataNascimento:dd/MM/yyyy}\n" +
                $"Idade calculada: {idade} anos",
                "Sucesso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }


    /*   if (count > 0)
       {
           MessageBox.Show("E-mail já cadastrado!");
           return;
       }

       // Insere novo usuário
       SqlCommand cmd = new SqlCommand("INSERT INTO Usuarios (Nome, Email, DataNascimento, SenhaHash) VALUES (@n, @e, @d, @s)", con);
       cmd.Parameters.AddWithValue("@n", nome);
       cmd.Parameters.AddWithValue("@e", email);
       cmd.Parameters.AddWithValue("@d", nascimento);
       cmd.Parameters.AddWithValue("@s", senhaHash);
       cmd.ExecuteNonQuery();

       MessageBox.Show("Cadastro realizado com sucesso!");

       // Login automático
       Sessao.UsuarioLogado = new Usuario
       {
           Nome = nome,
           Email = email,
           DataNascimento = nascimento
       };

       new TelaEntrada().Show();
       this.Close();
   }
   catch (Exception ex)
   {
       MessageBox.Show("Erro ao cadastrar: " + ex.Message);
   }
}*/


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

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