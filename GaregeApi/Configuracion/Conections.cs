using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GaregeApi.Configuracion
{
    /// <summary>
    /// Configuracion personalizada la base de datos no es necesario declararla
    /// </summary>
    public class Conections
    {
        private string host = "localhost";
        private int port = 3306;
        private string database = "ApiRestGarage";
        private string user = "root";
        private string pwd = "user";

        /// <summary>
        /// Usar cuando se conecte a la base de datos.
        /// <para>Esta retorna <see cref="MySqlConnection"/> cunado se realize la coneccion</para>
        /// </summary>
        public MySqlConnection conn = null;

        /// <summary>
        /// Realiza la coneccion a la base de datos.
        /// </summary>
        ///

        public void Conectar()
        {
            if (conn == null)
            {
                conn = new MySqlConnection();
                conn.ConnectionString = "server= " + host + "; port=" + port + "; Database=" + database + "; Uid=" + user + "; pwd=" + pwd;
                conn.Open();
            }
            else
            {
                Desconectar();
            }
        }

        /// <summary>
        /// Finaliza la coneccion de la base de datos
        /// </summary>
        public void Desconectar()
        {
            if (conn != null)
            {
                conn.Close();
                conn = null;
            }
        }

        /// <summary>
        /// Realiza consultas mas avanzadas.
        /// <para>Esta retorna el valor de tipo <see cref="MySqlDataReader"/> del resultado de la consulta</para>
        /// </summary>
        /// <param name="sqlcomand"></param>
        /// <returns name="result"> Retorna MySqlReader</returns>
        public MySqlDataReader ConsultMultiTable(string sqlcomand)
        {
            MySqlDataReader result = null;
            Conectar();
            MySqlCommand query = new MySqlCommand(sqlcomand, conn);
            result = query.ExecuteReader();
            Desconectar();
            return result;
        }

    }
}
