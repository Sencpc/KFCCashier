using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KFC
{
    class Karyawan
    {
        public DataTable karyawanCheck(string username, string password)
        {
            string query = "SELECT * FROM karyawan WHERE username_karyawan = @username AND password_karyawan = @password";

            using (var cmd = new MySqlCommand(query, koneksi.getConn()))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                using (var da = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    return dt;
                }
            }
        }

        //buat pengecekan role di login
        public string jabatanCheck(string username , string password)
        {
            string query = "SELECT jabatan FROM karyawan WHERE username_karyawan = @username AND password_karyawan = @password";

            using (var cmd = new MySqlCommand(query, koneksi.getConn()))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                using (var da = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    return dt.Rows[0][0].ToString();
                }
                }
        }

        //buat masukin fullName kehalaman selanjutnya
        public string fullNameCheck(string username, string password)
        {
            string query = "SELECT fullName FROM karyawan WHERE username_karyawan = @username AND password_karyawan = @password";
            string fullName = "";
 
            using (var cmd = new MySqlCommand(query, koneksi.getConn()))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    fullName = result.ToString();
                }
            }

            return fullName;
        }

    }
}
