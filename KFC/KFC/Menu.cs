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
        public DataTable showMenu(string keyword = "")
        {
            string query =
                "SELECT mac.nama_menu AS \"Nama Menu\" , mac.jenis AS Jenis , mac.harga AS Price , 'Alacarte Chicken' AS Kategori" +
                "FROM menu_utama mu" +
                "JOIN menu_alacarte_chicken mac ON mac.id_alacarte = mu.list_id" +
                "UNION ALL" +
                "5SELECT mbu.nama_bucket AS \"Nama Menu\" , 'Chicken Combo' AS Jenis , mbu.harga AS Price , 'Bucket' AS kategori" +
                "FROM menu_utama mu" +
                "JOIN menu_bucket mbu ON mbu.id_bucket = mu.list_id" +
                "UNION ALL" +
                "SELECT mco.nama_combo AS \"Nama Menu\" , \"I'm Hot\" AS Jenis , mco.harga AS Price , 'Combo' AS kategori" +
                "FROM menu_utama mu" +
                "JOIN menu_combo mco ON mco.id_combo = mu.list_id" +
                "UNION ALL" +
                "SELECT mbr.nama_menu AS \"Nama Menu\" , 'Breakfast Combo' AS Jenis , mbr.harga AS Price , 'Breakfast' AS kategori" +
                "FROM menu_utama mu" +
                "JOIN menu_breakfast mbr ON mbr.id_breakfast = mu.list_id" +
                "UNION ALL" +
                "SELECT mcf.nama_menu AS \"Nama Menu\" , mcf.jenis AS Jenis , mbu.harga AS Price , 'Coffee' AS kategori" +
                "FROM menu_utama mu" +
                "JOIN menu_coffee mcf ON mcf.id_coffee = mu.list_id" +
                "UNION ALL" +
                "SELECT mkm.nama_menu AS \"Nama Menu\" , 'Kid Combo' AS Jenis , mkm.harga AS Price , 'Kids Meal' AS kategori" +
                "FROM menu_utama mu" +
                "JOIN menu_kids_meal mkm ON mkm.id_kids = mu.list_id" +
                "UNION ALL" +
                "SELECT mde.nama_menu AS \"Nama Menu\" , 'Dessert Blyyatttt' AS Jenis , mde.harga AS Price , 'Dessert' AS kategori" +
                "FROM menu_utama mu" +
                "JOIN menu_dessert mde ON mde.id_dessert = mu.list_id" +
                "4UNION ALL" +
                "SELECT msp.nama_menu AS \"Nama Menu\" , 'Special Bitch' AS Jenis , msp.harga AS Price , 'Spesial' AS kategori" +
                "FROM menu_utama mu" +
                "JOIN menu_spesial msp ON msp.id_spesial = mu.list_id" +
                "SELECT d.nama_drinks AS \"Nama Menu\" , '!Africa' AS Jenis , d.harga AS Price , 'Drinks' AS kategori" +
                "FROM menu_utama mu" +
                "JOIN drinks d ON d.id_drinks = mu.list_id" +
                "SELECT s.nama_sides AS \"Nama Menu\" , 'AAAHHH Food' AS Jenis , s.harga AS Price , 'Sides' AS kategori" +
                "FROM menu_utama mu" +
                "JOIN sides s ON s.id_sides = mu.list_id";

            if (!string.IsNullOrEmpty(keyword))
            {
                query += " WHERE mac.nama_menu LIKE @keyword OR " +
                    "WHERE mbu.nama_bucket LIKE @keyword OR " +
                    "WHERE mco.nama_combo LIKE @keyword OR " +
                    "WHERE mbr.nama_menu LIKE @keyword OR " +
                    "WHERE mcf.nama_menu LIKE @keyword OR " +
                    "WHERE mkm.nama_menu LIKE @keyword OR " +
                    "WHERE mde.nama_menu LIKE @keyword OR " +
                    "WHERE msp.nama_menu LIKE @keyword OR " +
                    "WHERE d.nama_drinks LIKE @keyword OR " +
                    "WHERE s.nama_sides LIKE @keyword";
            }


            MySqlDataAdapter da = new MySqlDataAdapter(query, koneksi.getConn());
            if (!string.IsNullOrEmpty(keyword))
            {
                da.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
            }

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}