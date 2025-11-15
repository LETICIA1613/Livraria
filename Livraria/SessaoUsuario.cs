using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
        public static class SessaoUsuario
        {

        public static int UsuarioId { get; private set; }
        public static string Nome { get; private set; }
        public static string Email { get; private set; }
        public static bool EstaLogado => UsuarioId > 0;

        public static void Login(int usuarioId, string nome, string email)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            Email = email;
            Carrinho.CarregarCarrinhoDoUsuario(usuarioId);
        }

        public static void Logout()
        {
            UsuarioId = 0;
            Nome = string.Empty;
            Email = string.Empty;
            Carrinho.LimparCarrinhoMemoria();
        }
    }

}
