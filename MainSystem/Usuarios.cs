using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace MainSystem
{
    class Usuarios
    {
        int id;
        int id_type;
        string userName;
        string name;
        string password;
        string conPassword;

        public int Id { get => id; set => id = value; }
        public int Id_type { get => id_type; set => id_type = value; }
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public string ConPassword { get => conPassword; set => conPassword = value; }
        public string UserName { get => userName; set => userName = value; }
    }
}
