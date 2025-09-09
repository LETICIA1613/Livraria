using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Livraria
{
    public partial class Telaentradaadmin : Form
    {
        public Telaentradaadmin()
        {
            InitializeComponent();
        }

        private void Txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txtpassword_Enter(object sender, EventArgs e)
        {
           
            if (Txtpassword.Text == "Senha do admin")
            {
                Txtpassword.Text = "";
                Txtpassword.UseSystemPasswordChar = true; // ativa as bolinhas
                Txtpassword.ForeColor = Color.Black;
            }
        }

        private void btnpassword_Click(object sender, EventArgs e)
        {
            string senhaCorreta = "130908"; // <-- defina sua senha aqui
            string senhaDigitada = Txtpassword.Text;

            if (senhaDigitada == senhaCorreta)
            {
                MessageBox.Show("Login realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // abrir a tela do admin
                Telaadicionarlivro tela = new Telaadicionarlivro();
                tela.Show();
               
            }
            else
            {
                MessageBox.Show("Senha incorreta!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Txtpassword.Clear();
                Txtpassword.Focus();
            }
        }
    }


}



