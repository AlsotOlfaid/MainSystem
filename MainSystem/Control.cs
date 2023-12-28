
using MainSystem.View;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace MainSystem
{
    class Control
    {
        public string ctrlRecord(Usuarios usuario)
        {
            Model model = new Model();
            string answer = string.Empty;

            if (string.IsNullOrEmpty(usuario.Name) || string.IsNullOrEmpty(usuario.Name) || string.IsNullOrEmpty(usuario.Password) || string.IsNullOrEmpty(usuario.ConPassword))
            {
                answer = "Debe llenar todos los campos";
            }
            else
            {
                if (usuario.Password == usuario.ConPassword)
                {
                    if (model.userExists(usuario.Name))
                    {
                        answer = "El usuario ya existe";
                    }
                    else
                    {
                        usuario.Password = SHA512Generator(usuario.Password);
                        model.record(usuario);
                    }
                }

                
            }

            return answer;
        }


        public string ctrlLogin(string user, string password)
        {
            Model model = new Model();
            string answer = string.Empty;
            Usuarios userData = null;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            {
                answer = "Debe llenar todos los campos";
            }
            else
            {
                userData = model.forUser(user);

                if (userData == null)
                {
                    answer = "El usuario no existe";
                }
                else
                {
                    if (userData.Password != SHA512Generator(password))
                    {
                        answer = "El usuario y/o contraseña no coinciden";
                    }
                    else
                    {
                        Session.id = userData.Id;
                        Session.id_type = userData.Id_type;
                        Session.username = user;
                    }
                }
            }

            return answer;
        }

        private string SHA512Generator(string cadena)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] data = encoding.GetBytes(cadena);
            byte[] result;

            SHA512 sha = SHA512.Create();

            result = sha.ComputeHash(data);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
