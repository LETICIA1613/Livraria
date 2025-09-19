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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Livraria
{
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }
        


        private void BntNext1_Click_1(object sender, EventArgs e)
        {
            string name = Textname.Text;
            string email = TextEmail2.Text;
            string password = TextPW3.Text;

            MessageBox.Show($"Nome: {name}\nEmail: {email}\nSenha: {password}", "Dados Capturados");

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
            string dateborn = Cadastredate.Value.ToString("yyyy-MM-dd");

            MessageBox.Show($"Nome: {name}\nEmail: {email}\nSenha: {password}\nData de Nascimento: {dateborn}", "Dados Capturados");

            try
            {
                string connectionString = @"Data Source=sqlexpress;Initial Catalog=CJ3027481PR2;User Id=aluno;Passwordaluno;";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO USUARIO (NOME, EMAIL, SENHA, Data de Nascimento) VALUES (@Nome, @Email, @Senha, @Data)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Nome", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", password);
                    cmd.Parameters.AddWithValue("@Data", dateborn);


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


        private void TextEmail2_Enter(object sender, EventArgs e)
        {
            if (TextEmail2.Text == "E-mail")
            {
                TextEmail2.Text = "";
                TextEmail2.ForeColor = Color.Black; // cor normal do texto
            }
        }

        private void TextEmail2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextEmail2.Text))
            {
                TextEmail2.Text = "E-mail";
                TextEmail2.ForeColor = Color.Black; // cor de placeholder
            }
        }


        private void TelaLogin_Load(object sender, EventArgs e)
        {
           
        }

        private void TextEmail2_TextChanged(object sender, EventArgs e)
        {
        }

        private void TextEmail2_Click(object sender, EventArgs e)
        {
            if (TextEmail2.Text == "E-mail")
            {
                TextEmail2.Clear();
                TextEmail2.ForeColor = Color.Black;
            }
        }

        private void TextPW3_Enter(object sender, EventArgs e)
        {
            if (TextPW3.Text == "Senha")
            {
                TextPW3.Text = "";
                TextPW3.UseSystemPasswordChar = true;
                TextPW3.ForeColor = Color.Black; // cor normal do texto
               
            }
        }

        private void TextPW3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextPW3.Text))
            {
                TextPW3.Text = "Senha";
                TextPW3.ForeColor = Color.Black; // cor de placeholder
            }
        }

        private void TextPW3_Click(object sender, EventArgs e)
        {
            if (TextPW3.Text == "Senha")
            {
                TextPW3.Clear();
                TextPW3.ForeColor = Color.Black;
            }
        }

        private void TextCadastre2_Enter(object sender, EventArgs e)
        {
            if (TextCadastre2.Text == "Nome")
            {
                TextCadastre2.Text = "";
                TextCadastre2.ForeColor = Color.Black; // cor normal do texto
            }
        }

        private void TextCadastre2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextCadastre2.Text))
            {
                TextCadastre2.Text = "Nome";
                TextCadastre2.ForeColor = Color.Black; // cor de placeholder
            }
        }

        private void TextCadastre2_Click(object sender, EventArgs e)
        {
            if (TextCadastre2.Text == "Nome")
            {
                TextCadastre2.Clear();
                TextCadastre2.ForeColor = Color.Black;
            }
        }

        private void TextCadastre4_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextCadastre4_Enter(object sender, EventArgs e)
        {
            if (TextCadastre4.Text == "E-mail")
            {
                TextCadastre4.Text = "";
                TextCadastre4.ForeColor = Color.Black; // cor normal do texto
            }
        }

        private void TextCadastre4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextCadastre4.Text))
            {
                TextCadastre4.Text = "E-mail";
                TextCadastre4.ForeColor = Color.Black; // cor de placeholder
            }
        }

        private void TextCadastre4_Click(object sender, EventArgs e)
        {
            if (TextCadastre4.Text == "E-mail")
            {
                TextCadastre4.Clear();
                TextCadastre4.ForeColor = Color.Black;
            }
        }

        private void TextPW2_Enter(object sender, EventArgs e)
        {
            if (TextPW2.Text == "Senha")
            {
                TextPW2.Text = "";
                TextPW2.UseSystemPasswordChar = true;
                TextPW2.ForeColor = Color.Black; // cor normal do texto
            }
        }

        private void TextPW2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextPW2.Text))
            {
                TextPW2.Text = "Senha";
                TextPW2.ForeColor = Color.Black; // cor de placeholder
            }
        }

        private void TextPW2_Click(object sender, EventArgs e)
        {
            if (TextPW2.Text == "Senha")
            {
                TextPW2.Clear();
                TextPW2.ForeColor = Color.Black;
            }
        }

        

        private void datewrite_Click(object sender, EventArgs e)
        {

        }

        private void Textname_TextChanged(object sender, EventArgs e)
        {

        }

        private void Textname_Enter(object sender, EventArgs e)
        {
            if (Textname.Text == "Nome")
            {
                Textname.Text = "";
                Textname.ForeColor = Color.Black; // cor normal do texto
            }
        }

        private void Textname_Leave(object sender, EventArgs e)
        { 
            if (string.IsNullOrWhiteSpace(Textname.Text))
            {
                Textname.Text = "Nome";
                Textname.ForeColor = Color.Black; // cor de placeholder
            }
        }

        private void Textname_Click(object sender, EventArgs e)
        {
            if (Textname.Text == "Nome")
            {
                Textname.Clear();
                Textname.ForeColor = Color.Black;
            }
        }

        private void Cadastredate_ValueChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}