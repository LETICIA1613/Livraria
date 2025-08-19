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
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void BntNext1_Click(object sender, EventArgs e)
        {

            string name = TextCadastre2.Text;
            string email = TextEmail2.Text;
            string password = TextPW3.Text;
            string dateborn = Txtborn.Text;

            MessageBox.Show($"Nome: {name}\nEmail: {email}\nSenha: {password}\nData de aniversário: {dateborn}", "Dados Capturados");

            try
            {
                string connectionString = @"Data Source=sqlexpress;Initial Catalog=CJ3027481PR2;User Id=aluno;Password=aluno;";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO USUARIO (NOME, EMAIL, SENHA) VALUES (@Nome, @Email, @Senha)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Nome", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", password);
                    //cmd.Parameters.AddWithValue("@Senha", dateborn);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar no banco: " + ex.Message);
            }

            TelaEntrada product = new TelaEntrada();
            this.Visible = false;
            product.ShowDialog();
            this.Visible = true;
        }
            
        



        private void NextCadastre2_Click(object sender, EventArgs e)
        {
            string name = TextCadastre2.Text;
            string email = TextEmail2.Text;
            string password = TextPW3.Text;
            string dateborn = Txtborn.Text;

            MessageBox.Show($"Nome: {name}\nEmail: {email}\nSenha: {password}\nData de aniversário: {dateborn}", "Dados Capturados");

            try
            {
                string connectionString = @"Data Source=sqlexpress;Initial Catalog=CJ3027481PR2;User Id=aluno;Passwordaluno;";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO USUARIO (NOME, EMAIL, SENHA) VALUES (@Nome, @Email, @Senha)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Nome", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", password);
                    //cmd.Parameters.AddWithValue("@Senha", dateborn);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar no banco: " + ex.Message);
            }

            TelaEntrada product = new TelaEntrada();
            this.Visible = false;
            product.ShowDialog();
            this.Visible = true;
        }

        private void TextPW3_TextChanged(object sender, EventArgs e)
        {
        }
    }
}



