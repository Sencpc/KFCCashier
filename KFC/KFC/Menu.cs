using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC
{
    class Menu
    {
        //untuk show menu utama yang akan menampilkan semua menu yang ada blyattt
        public DataTable showMenu (string kategori = "")
        {
            string query =
                "SELECT m.id_menu AS id, m.nama_menu AS Menu, m.deskripsi AS DESCRIPTION , m.harga AS Price , k.nama_kategori AS Category " +
                "FROM menu m " +
                "JOIN kategori k ON k.id_kategori = m.id_kategori";

            if (!string.IsNullOrEmpty(kategori))
            {
                query += " WHERE k.nama_kategori = @kategori";
            }

            // kalo ada keyword di parameternya

            //if (!string.IsNullOrEmpty(keyword))
            //{
            //    query += (string.IsNullOrEmpty(kategori) ? " WHERE" : " AND") + " Nama Menu LIKE @keyword";
            //}

            MySqlDataAdapter da = new MySqlDataAdapter(query, koneksi.getConn());
            if (!string.IsNullOrEmpty(kategori))
            {
                da.SelectCommand.Parameters.AddWithValue("@kategori", kategori);
            }
            //if (!string.IsNullOrEmpty(keyword))
            //{
            //    da.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
            //}

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //buat combobox di form manager
        public DataTable comboBoxList() {
            string query = "Select * from kategori";
 
            MySqlDataAdapter da = new MySqlDataAdapter (query, koneksi.getConn());
            
            DataTable dt = new DataTable();
            da.Fill (dt);
            return dt;
        }

    }
}