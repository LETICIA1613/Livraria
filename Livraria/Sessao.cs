using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
    public static class Sessao
    {
        public static Usuario UsuarioLogado { get; set; }
    }

    public class Usuario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }

        public int Idade
        {
            get
            {
                int idade = DateTime.Today.Year - DataNascimento.Year;
                if (DataNascimento.Date > DateTime.Today.AddYears(-idade)) idade--;
                return idade;
            }
        }
    }
}

