using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC
{
    class Cart
    {
        //nampilin table cart yang statusnya pending
        public DataTable showCartinOrder()
        {
            string query =
               "SELECT " +
               "    COALESCE(mbu.nama_bucket, mco.nama_combo, mac.nama_menu, msp.nama_menu, mbr.nama_menu,d.nama_drinks, s.nama_sides) AS \"Nama Makanan\"," +
               "    COALESCE(mbu.deskripsi, mco.deskripsi,mac.deskripsi, msp.deskripsi, mbr.deskripsi, d.deskripsi, s.deskripsi) AS \"Deskripsi\"," +
               "    c.qty," +
               "    c.subtotal," +
               "    c.STATUS" +
               "    FROM cart c" +
               "    LEFT JOIN menu_utama mu ON c.id_menu = mu.id_menu " +
               "    LEFT JOIN menu_bucket mbu ON mu.list_id = mbu.id_bucket" +
               "    LEFT JOIN menu_combo mco ON mu.list_id = mco.id_combo" +
               "    LEFT JOIN menu_alacarte_chicken mac ON mu.list_id = mac.id_alacarte" +
               "    LEFT JOIN menu_spesial msp ON mu.list_id = msp.id_spesial" +
               "    LEFT JOIN menu_breakfast mbr ON mu.list_id = mbr.id_breakfast" +
               "    LEFT JOIN drinks d ON mu.list_id = d.id_drinks" +
               "    LEFT JOIN sides s ON mu.list_id = s.id_sides" +
               "    WHERE c.STATUS = 'Pending';";

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

        //buat insert ke table cart pas di celldoubleclick di bagian kasir , dgvMenu nya di sambungin sama ini
        public DataTable insertIntoCart()
        {
            string query =" Insert ";

            DataTable dt = new DataTable();

            using (var cmd = new MySqlCommand(query, koneksi.getConn()))
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
