using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC
{
    class Karyawan
    {
        public DataTable karyawanCheck(string username , string password)
        {
            string query = $"SELECT * from karyawan " +
                $"WHERE username_karyawan = {username} AND password_karyawan = {password}";

            using (var conn = koneksi.getConn())
            {
                DataTable dt = new DataTable();

                using (var cmd = new MySqlCommand(query, conn))
                {

                    using (var da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }


                return dt;
            }
        }
    }
}
