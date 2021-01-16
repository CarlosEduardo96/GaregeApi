using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GaregeApi.Modelos;
using GaregeApi.Configuracion;
using GaregeApi.InterfaceDTOs;
using MySql.Data.MySqlClient;

namespace GaregeApi.DTOs
{

    public enum Columns {
        nombre=0,
        email=1
    }
    /// <summary>
    /// Interactua con la tabla de login en la base de datos
    /// </summary>
    public class LoginDTO : Conections, QueryDTO<LoginModel>
    {

        private MySqlCommand command;
        private MySqlDataReader reader;

        public LoginDTO (){}

        public LoginModel Delete(int id)
        {
            LoginModel del = SelectById(id);
            if (del != null)
            {
                string sql = "delete from login wherw id=" + del.id;

                Conectar();
                command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                Desconectar();
            }
            return del;
        }

        public List<LoginModel> Find(string type, int colums)
        {
            List<LoginModel> lista = null;
            string sql = null;

            if ((int)Columns.email == colums)
            {
                sql = "select * from login where email='" + type + "'";
            }
            else if ((int)Columns.nombre == colums)
            {
                sql = "select * from login where nombre='" + type + "'";
            }

            Conectar();
            command = new MySqlCommand(sql,conn);
            reader = command.ExecuteReader();
            if (reader.HasRows) {
                while (reader.Read()) {
                    lista = new List<LoginModel>();
                    LoginModel select = new LoginModel
                    {
                        id = Convert.ToInt32(reader["id"].ToString()),
                        email = reader["email"].ToString(),
                        pwd = reader["pwd"].ToString(),
                        nombre = reader["nombre"].ToString(),
                        tipo = reader["tipo"].ToString(),
                        last_session = DateTime.Parse(reader["last_session"].ToString()),
                        firts_session = DateTime.Parse(reader["first_session"].ToString()),
                        _token = reader["_token"].ToString()
                    };
                    lista.Add(select);
                }
            }
            

            Desconectar();
            return lista;
        }

        public LoginModel Insert(LoginModel login)
        {
            List<LoginModel> result = Find(login.email,(int)Columns.email);
            LoginModel insert = null;

            if (result == null) {
                Conectar();
                insert = login;
                string sql = string.Format("insert into login values(null,'{0}','{1}','{2}','{3}', CURDATE(),CURDATE(),null);",
                    login.email,login.nombre,login.pwd,login.tipo);

                command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                
                insert.id=Convert.ToInt32(command.LastInsertedId);
                Desconectar();
            }
            return insert;
        }

        public List<LoginModel> SelectAll()
        {
            List<LoginModel> lista = null;
            Conectar();
            string sql = "select * from login";
            command = new MySqlCommand(sql,conn);
            reader = command.ExecuteReader();
            if (reader.HasRows) {
                while (reader.Read()) {
                    lista = new List<LoginModel>();
                    LoginModel select = new LoginModel
                    {
                        id = Convert.ToInt32(reader["id"].ToString()),
                        email = reader["email"].ToString(),
                        pwd = reader["pwd"].ToString(),
                        nombre = reader["nombre"].ToString(),
                        tipo = reader["tipo"].ToString(),
                        last_session = DateTime.Parse(reader["last_session"].ToString()),
                        firts_session = DateTime.Parse(reader["first_session"].ToString()),
                        _token = reader["token"].ToString()
                    };
                    lista.Add(select);
                }
            }
            Desconectar();
            return lista;
        }

        public LoginModel SelectById(int id)
        {
            LoginModel select = null;
            Conectar();
            string sql = "select * from login where id="+id;
            command = new MySqlCommand(sql,conn);
            reader = command.ExecuteReader();
            if (reader.HasRows) {
                while (reader.Read()) {
                    select = new LoginModel {
                        id = Convert.ToInt32(reader["id"].ToString()),
                        email = reader["email"].ToString(),
                        pwd = reader["pwd"].ToString(),
                        nombre = reader["nombre"].ToString(),
                        tipo = reader["tipo"].ToString(),
                        last_session = DateTime.Parse(reader["last_session"].ToString()),
                        firts_session = DateTime.Parse(reader["first_session"].ToString()),
                        _token= reader["_token"].ToString()
                    };
                }
            }
            Desconectar();
            return select;
        }

        /// <summary>
        /// Actualizacion de usuarios
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public LoginModel Update(LoginModel type)
        {
            LoginModel upgrade = SelectById(type.id);
            if (upgrade != null) {

                string sql =string.Format("update login set nombre='{0}', pwd='{1}', tipo='{2}' where id={3}",
                    type.nombre,type.pwd,type.tipo,type.id);
                Conectar();                
                command = new MySqlCommand(sql,conn);
                command.ExecuteNonQuery();
                Desconectar();
                upgrade = type;
            }
            return upgrade;
        }
               
    }
}
