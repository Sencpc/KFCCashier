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
                "  SELECT " +
                "    COALESCE(mbu.nama_bucket, mco.nama_combo, mac.nama_menu, msp.nama_menu, mbr.nama_menu , ) AS \"Nama Makanan\"," +
                "   c.qty as Jumlah," +
                "   c.subtotal as Subtotal," +
                "   FROM cart c" +
                "   LEFT JOIN menu_utama mu ON c.id_menu = mu.id_menu" +
                "   LEFT JOIN menu_bucket mbu ON mu.list_id = mbu.id_bucket" +
                "   LEFT JOIN menu_combo mco ON mu.list_id = mco.id_combo" +
                "   LEFT JOIN menu_alacarte_chicken mac ON mu.list_id = mac.id_alacarte" +
                "   LEFT JOIN menu_spesial msp ON mu.list_id = msp.id_spesial" +
                "   LEFT JOIN menu_breakfast mbr ON mu.list_id = mbr.id_breakfast" +
                "   WHERE cart.STATUS = 'Pending';";

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
