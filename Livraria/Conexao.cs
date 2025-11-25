using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;



namespace Livraria
{

    internal class Conexao
    {
        private static string connectionString =
          @"Data Source=sqlexpress;Initial Catalog=CJ3027481PR2;User Id=aluno;Password=aluno;";
        //@"Data Source=DESKTOP-3DSR1N8\SQLEXPRESS;Initial Catalog=CJ3027481PR2;User Id=sa;Password=leticia;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }


        /* private const string DATABASE_FILE = "Livraria.db";
         private static string ConnectionString => $"Data Source={DATABASE_FILE}";

         public static SqliteConnection GetConnection()
         {
             try
             {
                 // Verifica se o arquivo do banco existe
                 bool databaseExisted = File.Exists(DATABASE_FILE);

                 var connection = new SqliteConnection(ConnectionString);
                 connection.Open();

                 // Se o banco é novo, cria as tabelas
                 if (!databaseExisted)
                 {
                     CriarTabelas(connection);
                     MessageBox.Show("Banco de dados criado com sucesso!", "Info",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }

                 return connection;
             }
             catch (Exception ex)
             {
                 MessageBox.Show($"Erro ao conectar com o banco de dados: {ex.Message}",
                               "Erro de Conexão",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                 throw;
             }
         }

         private static void CriarTabelas(SqliteConnection connection)
         {
             // Tabela de Usuários
             string createUsuariosTable = @"
             CREATE TABLE IF NOT EXISTS Usuarios (
                 Id INTEGER PRIMARY KEY AUTOINCREMENT,
                 Nome TEXT NOT NULL,
                 Email TEXT UNIQUE NOT NULL,
                 Senha TEXT NOT NULL,
                 DataCadastro DATETIME DEFAULT CURRENT_TIMESTAMP
             )";

             // Tabela de Livros (exemplo adicional)
             string createLivrosTable = @"
             CREATE TABLE IF NOT EXISTS Livros (
                 Id INTEGER PRIMARY KEY AUTOINCREMENT,
                 Titulo TEXT NOT NULL,
                 Autor TEXT NOT NULL,
                 ISBN TEXT,
                 Preco DECIMAL(10,2),
                 Estoque INTEGER DEFAULT 0
             )";

             using (var command = new SqliteCommand(createUsuariosTable, connection))
             {
                 command.ExecuteNonQuery();
             }

             using (var command = new SqliteCommand(createLivrosTable, connection))
             {
                 command.ExecuteNonQuery();
             }
         }

         public static bool TestConnection()
         {
             try
             {
                 using (var connection = GetConnection())
                 {
                     return connection.State == System.Data.ConnectionState.Open;
                 }
             }
             catch
             {
                 return false;
             }
         }

     }
      internal class Conexao
       {
           private static string connectionString =
           //   @"Data Source=sqlexpress;Initial Catalog=CJ3027481PR2;User Id=aluno;Password=aluno;";
           @"Data Source=DESKTOP-3DSR1N8\SQLEXPRESS;Initial Catalog=CJ3027481PR2;User Id=sa;Password=leticia;";

           public static SqlConnection GetConnection()
           {
               return new SqlConnection(connectionString);
           }
       }

       /// <summary>
       /// Conector singleton para SQL Server (Windows Forms / .NET Framework).
       /// Uso:
       /// var conn = Conexao.Instance;
       /// if (conn.IsConnected) { ... }
       /// </summary>
       public sealed class Conexao : IDisposable
       {
           private static readonly Lazy<Conexao> _lazy = new Lazy<Conexao>(() => new Conexao());
           public static Conexao Instance => _lazy.Value;

           private SqlConnection _connection;
           private SqlTransaction _transaction;

           public bool IsConnected { get; private set; }
           public string LastError { get; private set; }
           public string ConnectionString { get; private set; }

           private const string DefaultDatabase = "CJ3027481PR2";

           private Conexao()
           {
               TryAutoConnect(DefaultDatabase);
           }

           public bool TryAutoConnect(string database = DefaultDatabase)
           {
               string[] candidates = new[] {
                   @"(localdb)\MSSQLLocalDB",
                   @".\SQLEXPRESS",
                   @"localhost",
                   @"(local)"
               };

               foreach (var instance in candidates)
               {
                   var cs = BuildConnectionString(instance, database);
                   try
                   {
                       using (var test = new SqlConnection(cs))
                       {
                           test.Open();

                           ConnectionString = cs;
                           _connection = new SqlConnection(cs);
                           _connection.Open();

                           IsConnected = true;
                           LastError = null;
                           return true;
                       }
                   }
                   catch (Exception ex)
                   {
                       LastError = ex.Message;
                   }
               }

               IsConnected = false;
               return false;
           }

           private string BuildConnectionString(string instance, string database)
           {
               var serverPart = string.IsNullOrWhiteSpace(instance) ? "." : instance;
               return $"Server={serverPart};Database={database};Integrated Security=True;Connect Timeout=3;";
           }

           private void EnsureConnected()
           {
               if (!IsConnected || _connection == null)
                   throw new InvalidOperationException("Não conectado ao banco de dados.");
           }

           public DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
           {
               EnsureConnected();

               using (var cmd = new SqlCommand(sql, _connection, _transaction))
               {
                   if (parameters != null && parameters.Length > 0)
                       cmd.Parameters.AddRange(parameters);

                   using (var adapter = new SqlDataAdapter(cmd))
                   {
                       var dt = new DataTable();
                       adapter.Fill(dt);
                       return dt;
                   }
               }
           }

           public int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
           {
               EnsureConnected();

               using (var cmd = new SqlCommand(sql, _connection, _transaction))
               {
                   if (parameters != null && parameters.Length > 0)
                       cmd.Parameters.AddRange(parameters);

                   return cmd.ExecuteNonQuery();
               }
           }

           public object ExecuteScalar(string sql, params SqlParameter[] parameters)
           {
               EnsureConnected();

               using (var cmd = new SqlCommand(sql, _connection, _transaction))
               {
                   if (parameters != null && parameters.Length > 0)
                       cmd.Parameters.AddRange(parameters);

                   return cmd.ExecuteScalar();
               }
           }

           public void BeginTransaction()
           {
               EnsureConnected();
               if (_transaction != null)
                   throw new InvalidOperationException("Já existe uma transação ativa.");

               _transaction = _connection.BeginTransaction();
           }

           public void Commit()
           {
               if (_transaction == null)
                   throw new InvalidOperationException("Nenhuma transação ativa.");

               _transaction.Commit();
               _transaction.Dispose();
               _transaction = null;
           }

           public void Rollback()
           {
               if (_transaction == null)
                   throw new InvalidOperationException("Nenhuma transação ativa.");

               _transaction.Rollback();
               _transaction.Dispose();
               _transaction = null;
           }

           public void Close()
           {
               try
               {
                   _transaction?.Dispose();
                   _transaction = null;

                   if (_connection != null)
                   {
                       if (_connection.State != ConnectionState.Closed)
                           _connection.Close();

                       _connection.Dispose();
                       _connection = null;
                   }
               }
               finally
               {
                   IsConnected = false;
               }
           }

           public void Dispose()
           {
               Close();
               GC.SuppressFinalize(this);
           }

           void IDisposable.Dispose()
           {
               Dispose();
           }

           // Método solicitado: retorna a conexão atual
           private SqlConnection GetInternalConnection()
           {
               EnsureConnected();
               return _connection;
           }

           // Método estático que seu sistema usa em todas as telas
           public static SqlConnection GetConnection()
           {
               return Instance.GetInternalConnection();
           }

           ~Conexao()
           {
               Close();
           }
       }
   }*/


    }

