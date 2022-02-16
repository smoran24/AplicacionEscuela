using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionEscuela
{
    class Sistema
    {
        private MySqlConnection conexionSQL = new MySqlConnection("Server=localhost; Database=academias; Uid=root; Pwd=013042; SslMode = none");

        public Sistema()
        {

        }

        public MySqlConnection getConexion()
        {
            return conexionSQL;
        }
    }
}
