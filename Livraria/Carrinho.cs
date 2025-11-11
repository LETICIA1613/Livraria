using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
    public static class Carrinho
    {
        private static List<LivroCarrinho> itens = new List<LivroCarrinho>();

        public static void AdicionarLivro(int livroId, string titulo, string autor, decimal preco, byte[] foto = null)
        {
            var itemExistente = itens.FirstOrDefault(i => i.LivroId == livroId);

            if (itemExistente != null)
            {
                itemExistente.Quantidade++;
            }
            else
            {
                itens.Add(new LivroCarrinho
                {
                    LivroId = livroId,
                    Titulo = titulo,
                    Autor = autor,
                    Preco = preco,
                    Foto = foto,
                    Quantidade = 1
                });
            }
        }

        public static void RemoverLivro(int livroId)
        {
            var item = itens.FirstOrDefault(i => i.LivroId == livroId);
            if (item != null)
            {
                itens.Remove(item);
            }
        }

        public static List<LivroCarrinho> GetItens()
        {
            return itens;
        }

        public static decimal GetTotal()
        {
            return itens.Sum(i => i.Preco * i.Quantidade);
        }

        public static int GetQuantidadeTotal()
        {
            return itens.Sum(i => i.Quantidade);
        }

        public static void LimparCarrinho()
        {
            itens.Clear();
        }
    }

    public class LivroCarrinho
    {
        public int LivroId { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public decimal Preco { get; set; }
        public byte[] Foto { get; set; }
        public int Quantidade { get; set; }
    }
}
