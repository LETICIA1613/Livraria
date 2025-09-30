using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
    internal class Conexao
    {
        private static string connectionString =
            @"Data Source=sqlexpress;Initial Catalog=CJ3027481PR2;User Id=aluno;Password=aluno";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
