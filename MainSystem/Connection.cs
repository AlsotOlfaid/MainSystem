using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSystem
{
    class Connection
    {
        public static MySqlConnection getConnection()
        {
            string server = "localhost";
            string port = "3306";
            string user = "root";
            string password = "M226PEas05_12";
            string db = "users";

            string connectionString = "server=" + server + "; port=" + port + "; user=" + user + "; password=" + password + "; database=" + db;

            MySqlConnection connection = new MySqlConnection(connectionString);

            return connection;
        }
    }
}
