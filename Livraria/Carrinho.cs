using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{

        public static class Carrinho
        {
        private static List<LivroCarrinho> itens = new List<LivroCarrinho>();
        public static void LimparCarrinho()
        {
            itens.Clear();
        }


        // MÉTODOS EXISTENTES DO CARRINHO (mantenha os que já tem)
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

            // Salvar no banco se usuário estiver logado
            if (SessaoUsuario.EstaLogado)
            {
                SalvarOuAtualizarNoBanco(livroId, GetQuantidade(livroId));
            }
        }

        public static void RemoverLivro(int livroId)
        {
            var item = itens.FirstOrDefault(i => i.LivroId == livroId);
            if (item != null)
            {
                itens.Remove(item);

                // Remover do banco se usuário estiver logado
                if (SessaoUsuario.EstaLogado)
                {
                    RemoverDoBanco(livroId);
                }
            }
        }

        public static void AtualizarQuantidade(int livroId, int quantidade)
        {
            var item = itens.FirstOrDefault(i => i.LivroId == livroId);
            if (item != null)
            {
                item.Quantidade = quantidade;

                // Atualizar no banco se usuário estiver logado
                if (SessaoUsuario.EstaLogado)
                {
                    SalvarOuAtualizarNoBanco(livroId, quantidade);
                }
            }
        }

        public static List<LivroCarrinho> GetItens() => itens;
        public static decimal GetTotal() => itens.Sum(i => i.Preco * i.Quantidade);
        public static int GetQuantidadeTotal() => itens.Sum(i => i.Quantidade);

        public static void LimparCarrinhoMemoria()
        {
            itens.Clear();
        }

        // MÉTODOS PARA CARRINHO POR USUÁRIO
        public static void CarregarCarrinhoDoUsuario(int usuarioId)
        {
            try
            {
                itens.Clear();

                using (SqlConnection con = Conexao.GetConnection())
                {
                    con.Open();
                    string query = @"
                        SELECT 
                            CU.LivroId,
                            L.Nome as Titulo,
                            STUFF((
                                SELECT ', ' + A.Nome
                                FROM LivroAutores LA 
                                INNER JOIN Autores A ON LA.AutorId = A.Id
                                WHERE LA.LivroId = L.Id
                                FOR XML PATH('')
                            ), 1, 2, '') as Autores,
                            L.Preco,
                            L.Foto,
                            CU.Quantidade
                        FROM CarrinhoUsuario CU
                        INNER JOIN Livros L ON CU.LivroId = L.Id
                        WHERE CU.UsuarioId = @UsuarioId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itens.Add(new LivroCarrinho
                                {
                                    LivroId = Convert.ToInt32(reader["LivroId"]),
                                    Titulo = reader["Titulo"]?.ToString() ?? "Título não disponível",
                                    Autor = reader["Autores"]?.ToString() ?? "Autor não disponível",
                                    Preco = Convert.ToDecimal(reader["Preco"]),
                                    Foto = reader["Foto"] != DBNull.Value ? (byte[])reader["Foto"] : null,
                                    Quantidade = Convert.ToInt32(reader["Quantidade"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar carrinho: {ex.Message}");
            }
        }

        // MÉTODOS PARA PEDIDOS (NOVOS)
        public static int SalvarPedido()
        {
            try
            {
                using (SqlConnection con = Conexao.GetConnection())
                {
                    con.Open();

                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            // 1. Inserir o pedido principal
                            string queryPedido = @"
                                INSERT INTO Pedidos (UsuarioId, Total, Status) 
                                VALUES (@UsuarioId, @Total, 'Finalizado');
                                SELECT SCOPE_IDENTITY();";

                            decimal total = GetTotal();
                            object usuarioIdParam = SessaoUsuario.EstaLogado ?
                                (object)SessaoUsuario.UsuarioId : DBNull.Value;

                            using (SqlCommand cmd = new SqlCommand(queryPedido, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@UsuarioId", usuarioIdParam);
                                cmd.Parameters.AddWithValue("@Total", total);
                                int pedidoId = Convert.ToInt32(cmd.ExecuteScalar());

                                // 2. Inserir os itens do pedido
                                string queryItens = @"
                                    INSERT INTO PedidoItens (PedidoId, LivroId, Quantidade, PrecoUnitario, Subtotal)
                                    VALUES (@PedidoId, @LivroId, @Quantidade, @PrecoUnitario, @Subtotal)";

                                foreach (var item in itens)
                                {
                                    using (SqlCommand cmdItem = new SqlCommand(queryItens, con, transaction))
                                    {
                                        cmdItem.Parameters.AddWithValue("@PedidoId", pedidoId);
                                        cmdItem.Parameters.AddWithValue("@LivroId", item.LivroId);
                                        cmdItem.Parameters.AddWithValue("@Quantidade", item.Quantidade);
                                        cmdItem.Parameters.AddWithValue("@PrecoUnitario", item.Preco);
                                        cmdItem.Parameters.AddWithValue("@Subtotal", item.Preco * item.Quantidade);
                                        cmdItem.ExecuteNonQuery();
                                    }
                                }

                                // 3. Limpar carrinho do banco se usuário estiver logado
                                if (SessaoUsuario.EstaLogado)
                                {
                                    string queryLimparCarrinho = "DELETE FROM CarrinhoUsuario WHERE UsuarioId = @UsuarioId";
                                    using (SqlCommand cmdLimpar = new SqlCommand(queryLimparCarrinho, con, transaction))
                                    {
                                        cmdLimpar.Parameters.AddWithValue("@UsuarioId", SessaoUsuario.UsuarioId);
                                        cmdLimpar.ExecuteNonQuery();
                                    }
                                }

                                transaction.Commit();

                                // Limpar carrinho da memória
                                itens.Clear();

                                return pedidoId;
                            }
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao salvar pedido: {ex.Message}");
            }
        }

        public static DataTable GetHistoricoPedidos(int? usuarioId = null)
        {
            try
            {
                using (SqlConnection con = Conexao.GetConnection())
                {
                    con.Open();
                    string query = @"
                        SELECT 
                            P.Id as 'Número',
                            P.DataPedido as 'Data',
                            P.Total as 'Total',
                            P.Status as 'Status',
                            COUNT(PI.Id) as 'Qtd Itens'
                        FROM Pedidos P
                        LEFT JOIN PedidoItens PI ON P.Id = PI.PedidoId
                        WHERE (@UsuarioId IS NULL OR P.UsuarioId = @UsuarioId)
                        GROUP BY P.Id, P.DataPedido, P.Total, P.Status
                        ORDER BY P.DataPedido DESC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        if (usuarioId.HasValue)
                            cmd.Parameters.AddWithValue("@UsuarioId", usuarioId.Value);
                        else
                            cmd.Parameters.AddWithValue("@UsuarioId", DBNull.Value);

                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao carregar histórico: {ex.Message}");
            }
        }

        public static DataTable GetDetalhesPedido(int pedidoId)
        {
            try
            {
                using (SqlConnection con = Conexao.GetConnection())
                {
                    con.Open();
                    string query = @"
                        SELECT 
                            L.Nome as 'Livro',
                            PI.Quantidade as 'Quantidade',
                            PI.PrecoUnitario as 'Preço Unitário',
                            PI.Subtotal as 'Subtotal'
                        FROM PedidoItens PI
                        INNER JOIN Livros L ON PI.LivroId = L.Id
                        WHERE PI.PedidoId = @PedidoId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@PedidoId", pedidoId);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao carregar detalhes do pedido: {ex.Message}");
            }
        }

        // MÉTODOS PRIVADOS PARA BANCO DE DADOS
        private static void SalvarOuAtualizarNoBanco(int livroId, int quantidade)
        {
            if (!SessaoUsuario.EstaLogado) return;

            try
            {
                using (SqlConnection con = Conexao.GetConnection())
                {
                    con.Open();
                    string query = @"
                        MERGE CarrinhoUsuario AS target
                        USING (SELECT @UsuarioId AS UsuarioId, @LivroId AS LivroId) AS source
                        ON target.UsuarioId = source.UsuarioId AND target.LivroId = source.LivroId
                        WHEN MATCHED THEN
                            UPDATE SET Quantidade = @Quantidade, DataAdicao = GETDATE()
                        WHEN NOT MATCHED THEN
                            INSERT (UsuarioId, LivroId, Quantidade) 
                            VALUES (@UsuarioId, @LivroId, @Quantidade);";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UsuarioId", SessaoUsuario.UsuarioId);
                        cmd.Parameters.AddWithValue("@LivroId", livroId);
                        cmd.Parameters.AddWithValue("@Quantidade", quantidade);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar item: {ex.Message}");
            }
        }

        private static void RemoverDoBanco(int livroId)
        {
            if (!SessaoUsuario.EstaLogado) return;

            try
            {
                using (SqlConnection con = Conexao.GetConnection())
                {
                    con.Open();
                    string query = "DELETE FROM CarrinhoUsuario WHERE UsuarioId = @UsuarioId AND LivroId = @LivroId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UsuarioId", SessaoUsuario.UsuarioId);
                        cmd.Parameters.AddWithValue("@LivroId", livroId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao remover item: {ex.Message}");
            }
        }

        private static int GetQuantidade(int livroId)
        {
            var item = itens.FirstOrDefault(i => i.LivroId == livroId);
            return item?.Quantidade ?? 0;
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
