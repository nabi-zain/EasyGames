using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGames.Model
{
    public static class DBConnection
    {
        public static string ConnectionString { get; set; }

        public static SqlConnection GetOpenConnection(string connectionString, bool mars = false)
        {
            var cs = connectionString;
            {
                if (mars)
                {
                    var conn = new SqlConnectionStringBuilder(cs) { MultipleActiveResultSets = true };
                    cs = conn.ConnectionString;
                }
                var connection = new SqlConnection(cs);
                connection.Open();
                return connection;
            }
        }

        public static SqlConnection GetClosedConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
