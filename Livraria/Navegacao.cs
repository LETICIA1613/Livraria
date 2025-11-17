using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Livraria
{
    public static class Navegacao
    {
        private static Stack<Form> pilhaTelas = new Stack<Form>();

        public static void AbrirTela(Form telaAtual, Form novaTela)
        {
            // Esconde a tela atual e empilha
            telaAtual.Hide();
            pilhaTelas.Push(telaAtual);

            // Configura a nova tela para voltar à anterior
            novaTela.FormClosed += (s, e) => {
                if (pilhaTelas.Count > 0)
                {
                    Form anterior = pilhaTelas.Pop();
                    anterior.Show();
                }
            };

            novaTela.Show();
        }

        public static void Voltar(Form telaAtual)
        {
            telaAtual.Close(); // Isso vai disparar o FormClosed da tela anterior
        }
    }
}
