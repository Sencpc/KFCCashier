using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KFC
{
    class GeneratorID
    {
        public string GetLastID(string tableName, string idColumn, string prefix, int idLength)
        {
            string lastID = "";
            string newID = "";

            try
            {
                MySqlConnection conn = koneksi.getConn();

                string query = $@"
                SELECT {idColumn}
                FROM {tableName}
                WHERE {idColumn} LIKE '{prefix}%'
                ORDER BY {idColumn} DESC
                LIMIT 1
                ";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    lastID = result.ToString();

                    // Ambil bagian angka dari ID (misalnya '001' dari 'AB001')
                    string numericPart = lastID.Substring(prefix.Length);

                    // Konversi ke integer dan tambahkan 1
                    int nextNumber = int.Parse(numericPart) + 1;

                    // Format ulang menjadi string dengan padding nol
                    newID = prefix + nextNumber.ToString($"D{idLength}");
                }
                else
                {
                    // Jika tidak ada ID, buat ID baru dengan angka pertama
                    newID = prefix + "1".PadLeft(idLength, '0');
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return newID;
        }
    }
}
