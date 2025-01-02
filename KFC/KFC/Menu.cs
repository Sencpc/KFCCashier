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
                @"SELECT mac.nama_menu AS 'Nama Menu', mac.deskripsi AS 'Deskripsi', mac.harga AS 'Price', 'Alacarte Chicken' AS 'Kategori'
                FROM menu_utama mu
                JOIN menu_alacarte_chicken mac ON mac.id_alacarte = mu.list_id
                UNION ALL
                SELECT mbu.nama_bucket AS 'Nama Menu', mbu.deskripsi AS 'Deskripsi', mbu.harga AS 'Price', 'Bucket' AS 'Kategori'
                FROM menu_utama mu
                JOIN menu_bucket mbu ON mbu.id_bucket = mu.list_id
                UNION ALL
                SELECT mco.nama_combo AS 'Nama Menu', mco.deskripsi AS 'Deskripsi', mco.harga AS 'Price', 'Combo' AS 'Kategori'
                FROM menu_utama mu
                JOIN menu_combo mco ON mco.id_combo = mu.list_id
                UNION ALL
                SELECT mbr.nama_menu AS 'Nama Menu', mbr.deskripsi AS 'Deskripsi', mbr.harga AS 'Price', 'Breakfast' AS 'Kategori'
                FROM menu_utama mu
                JOIN menu_breakfast mbr ON mbr.id_breakfast = mu.list_id
                UNION ALL
                SELECT mcf.nama_menu AS 'Nama Menu', mcf.deskripsi AS 'Deskripsi', mcf.harga AS 'Price', 'Coffee' AS 'Kategori'
                FROM menu_utama mu
                JOIN menu_coffee mcf ON mcf.id_coffee = mu.list_id
                UNION ALL
                SELECT mkm.nama_menu AS 'Nama Menu', mkm.deskripsi AS 'Deskripsi', mkm.harga AS 'Price', 'Kids Meal' AS 'Kategori'
                FROM menu_utama mu
                JOIN menu_kids_meal mkm ON mkm.id_kids = mu.list_id
                UNION ALL
                SELECT mde.nama_menu AS 'Nama Menu', mde.deskripsi AS 'Deskripsi', mde.harga AS 'Price', 'Dessert' AS 'Kategori'
                FROM menu_utama mu
                JOIN menu_dessert mde ON mde.id_dessert = mu.list_id
                UNION ALL
                SELECT msp.nama_menu AS 'Nama Menu', msp.deskripsi AS 'Deskripsi', msp.harga AS 'Price', 'Spesial' AS 'Kategori'
                FROM menu_utama mu
                JOIN menu_spesial msp ON msp.id_spesial = mu.list_id
                UNION ALL
                SELECT d.nama_drinks AS 'Nama Menu', d.deskripsi AS 'Deskripsi', d.harga AS 'Price', 'Drinks' AS 'Kategori'
                FROM menu_utama mu
                JOIN drinks d ON d.id_drinks = mu.list_id
                UNION ALL
                SELECT s.nama_sides AS 'Nama Menu', s.deskripsi AS 'Deskripsi', s.harga AS 'Price', 'Sides' AS 'Kategori'
                FROM menu_utama mu
                JOIN sides s ON s.id_sides = mu.list_id";

            if (!string.IsNullOrEmpty(kategori))
            {
                query = "SELECT * FROM " +
                    "(SELECT mac.nama_menu AS \"Nama Menu\", mac.deskripsi AS 'Deskripsi', mac.harga AS Price, 'Alacarte Chicken' AS Kategori" +
                    " FROM menu_utama mu" +
                    " JOIN menu_alacarte_chicken mac ON mac.id_alacarte = mu.list_id" +
                    " UNION ALL" +
                    " SELECT mbu.nama_bucket AS \"Nama Menu\", mbu.deskripsi AS 'Deskripsi', mbu.harga AS Price, 'Bucket' AS Kategori" +
                    " FROM menu_utama mu" +
                    " JOIN menu_bucket mbu ON mbu.id_bucket = mu.list_id" +
                    " UNION ALL" +
                    " SELECT mco.nama_combo AS \"Nama Menu\", mco.deskripsi AS 'Deskripsi', mco.harga AS Price, 'Combo' AS Kategori" +
                    " FROM menu_utama mu" +
                    " JOIN menu_combo mco ON mco.id_combo = mu.list_id" +
                    " UNION ALL" +
                    " SELECT mbr.nama_menu AS \"Nama Menu\", mbr.deskripsi AS 'Deskripsi', mbr.harga AS Price, 'Breakfast' AS Kategori" +
                    " FROM menu_utama mu" +
                    " JOIN menu_breakfast mbr ON mbr.id_breakfast = mu.list_id" +
                    " UNION ALL" +
                    " SELECT mcf.nama_menu AS \"Nama Menu\", mcf.deskripsi AS 'Deskripsi', mcf.harga AS Price, 'Coffee' AS Kategori" +
                    " FROM menu_utama mu" +
                    " JOIN menu_coffee mcf ON mcf.id_coffee = mu.list_id" +
                    " UNION ALL" +
                    " SELECT mkm.nama_menu AS \"Nama Menu\", mkm.deskripsi AS 'Deskripsi', mkm.harga AS Price, 'Kids Meal' AS Kategori" +
                    " FROM menu_utama mu" +
                    " JOIN menu_kids_meal mkm ON mkm.id_kids = mu.list_id" +
                    " UNION ALL" +
                    " SELECT mde.nama_menu AS \"Nama Menu\", mde.deskripsi AS 'Deskripsi', mde.harga AS Price, 'Dessert' AS Kategori" +
                    " FROM menu_utama mu" +
                    " JOIN menu_dessert mde ON mde.id_dessert = mu.list_id" +
                    " UNION ALL" +
                    " SELECT msp.nama_menu AS \"Nama Menu\", msp.deskripsi AS 'Deskripsi', msp.harga AS Price, 'Spesial' AS Kategori" +
                    " FROM menu_utama mu" +
                    " JOIN menu_spesial msp ON msp.id_spesial = mu.list_id" +
                    " UNION ALL" +
                    " SELECT d.nama_drinks AS \"Nama Menu\", d.deskripsi AS 'Deskripsi', d.harga AS Price, 'Drinks' AS Kategori" +
                    " FROM menu_utama mu" +
                    " JOIN drinks d ON d.id_drinks = mu.list_id" +
                    " UNION ALL" +
                    " SELECT s.nama_sides AS \"Nama Menu\", s.deskripsi AS 'Deskripsi', s.harga AS Price, 'Sides' AS Kategori" +
                    " FROM menu_utama mu" +
                    " JOIN sides s ON s.id_sides = mu.list_id) AS full_menu" +
                    " WHERE full_menu.Kategori = @kategori;";
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