using MainSystem.View;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSystem
{
    class Model
    {
        public int record(Usuarios usuario)
        {
            MySqlConnection connection  = Connection.getConnection();
            connection.Open();

            string sql = "INSERT INTO usuarios (user_name, name, password, id_type) " +
                "VALUES(@user_name, @name, @password, @id_type)";

            MySqlCommand command  = new MySqlCommand(sql, connection);


            command.Parameters.AddWithValue("@user_name", usuario.UserName);
            command.Parameters.AddWithValue("@name", usuario.Name);
            command.Parameters.AddWithValue("@password", usuario.Password);
            command.Parameters.AddWithValue("@id_type", usuario.Id_type);

            int result = command.ExecuteNonQuery();

            return result;
        }

        public bool userExists(string usuario)
        {
            MySqlDataReader reader;

            MySqlConnection connection = Connection.getConnection();
            connection.Open();

            string sql = "SELECT id FROM usuarios WHERE name LIKE @name";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@name", usuario);

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Usuarios forUser(string usuario)
        {
            MySqlDataReader reader;

            MySqlConnection connection = Connection.getConnection();
            connection.Open();

            string sql = "SELECT id, name, password, id_type FROM usuarios WHERE name LIKE @name";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@name", usuario);

            reader = command.ExecuteReader();

            Usuarios usr = null;

            while (reader.Read())
            {
                usr = new Usuarios();
                usr.Id = int.Parse(reader["id"].ToString());
                usr.UserName = reader["name"].ToString();
                usr.Password = reader["password"].ToString();
                usr.Id_type = int.Parse(reader["id_type"].ToString());
            }

            return usr;

        }
    }
}
