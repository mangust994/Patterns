using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQL_Yarik.DataBase
{
    public class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            string database = "pojiloy_mista";
            string username = "root";
            string password = "root";

            return DBMySQLUtils.GetDBConnection(host, database, username, password);
        }
    }
}
