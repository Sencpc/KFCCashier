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
                "Server=10.10.5.192;" +
                "Database=proyekpv;" +
                "User ID=tegar;" +
                "Password=1234;"
                );
            conn.Open();
            conn.Close();
        }
    }
}
