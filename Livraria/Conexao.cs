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
            @"Server=.\SQLEXPRESS;Database=CJ3027481PR2;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
