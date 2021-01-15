using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GaregeApi.InterfaceDTOs;
using GaregeApi.Modelos;
using MySql.Data.MySqlClient;

namespace GaregeApi.Configuracion
{
    public class Autentificar : Conections, ISecurity
    {
        private MySqlCommand command;
        private MySqlDataReader reader;
        public Autentificar() { }

        public LoginModel Identificar(string email, string pwd)
        {
            LoginModel user = null;
            Conectar();
            string sql = string.Format("select * from login where email='{0}' and pwd={1}",email,pwd);
            command = new MySqlCommand(sql,conn);
            reader = command.ExecuteReader();
            if (reader.HasRows) {
                while (reader.Read()) {
                    user = new LoginModel {
                        id = Convert.ToInt32(reader["id"].ToString()),
                        nombre = reader["nombre"].ToString(),
                        email = reader["email"].ToString(),
                        pwd = reader["pwd"].ToString(),
                        tipo=reader["tipo"].ToString(),
                        last_session = DateTime.Parse(reader["first_session"].ToString()),
                        firts_session = DateTime.Now,
                        _token = InsertToken()
                    };
                }                
            }
            Desconectar();
            
            if (user != null) {
                Conectar();
                sql = string.Format("update login set last_session='{0}' ,  first_session='{1}' where id={2};",
                user.last_session.ToString("yyyy-MM-dd HH:mm:ss"), user.firts_session.ToString("yyyy-MM-dd HH:mm:ss"), user.id);

                command = new MySqlCommand(sql,conn);
                command.ExecuteNonQuery();
                Desconectar();
            }            
            return user;
        }

        public string InsertToken()
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            return Convert.ToBase64String(time.Concat(key).ToArray());
        }
    }
}
