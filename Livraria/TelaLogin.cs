using Microsoft.Data.Sqlite;
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
            string email = TextEmail2.Text.Trim();
            string senha = TextPW3.Text;
            string senhaHash = Seguranca.HashSenha(senha);

           
            using (SqlConnection con = Conexao.GetConnection())
            {
                 con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Nome, DataNascimento FROM Usuarios WHERE Email=@e AND SenhaHash=@s", con);
                cmd.Parameters.AddWithValue("@e", email);
                cmd.Parameters.AddWithValue("@s", senhaHash);


                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string nome = reader.GetString(0);
                    DateTime nascimento = reader.GetDateTime(1);

                    Sessao.UsuarioLogado = new Usuario { Nome = nome, Email = email, DataNascimento = nascimento };
                    TelaEntrada product = new TelaEntrada();
                    this.Visible = false;
                    product.ShowDialog();
                    this.Visible = true;
                }

                else
                {
                    MessageBox.Show("E-mail ou senha incorretos!");
                }
            }
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
       
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TelaCadastro product = new TelaCadastro();
            this.Visible = false;
            product.ShowDialog();
            this.Visible = true;
        }
        private bool mostrandoSenha = false;
        private void Pictureolhos2_Click(object sender, EventArgs e)
        {
            mostrandoSenha = !mostrandoSenha;

            if (mostrandoSenha)
            {
                // Mostra a senha
                TextPW3.UseSystemPasswordChar = false;
                Pictureolhos2.Image = Properties.Resources.imagem_olhos1;
            }
            else
            {
                // Esconde a senha
                TextPW3.UseSystemPasswordChar = true;
                Pictureolhos2.Image = Properties.Resources.imagem_olhos2;
            }
        }

        
    }

}