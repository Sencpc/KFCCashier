using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC
{
    class koneksi
    {
        static MySqlConnection conn;
        public static MySqlConnection getConn()
        {
            return conn;
        }

        public static void setupConn()
        {
            conn = new MySqlConnection(
                "Server=localhost;" +
                "Database=proyekpv;" +
                "User ID=root;" +
                "Password=;"
                );
            conn.Open();
        }
    }
}
