using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KFC
{
    public partial class Dapur : Form
    {
        public Dapur(string user)
        {
            InitializeComponent();
            label2.Text = "Welcome, " + user;
            loadStok();
            loadIngredient();
            koneksi.setupConn();
        }
        private void loadStok()
        {
            koneksi.getConn().Open();

            string query = "SELECT id_bahan, nama, qty, satuan_bahan FROM stock";
            MySqlCommand command = new MySqlCommand(query, koneksi.getConn());
            MySqlDataReader reader = command.ExecuteReader();

            DataTable stokTable = new DataTable();
            stokTable.Load(reader);
            reader.Close();
            koneksi.getConn().Close();

            dataGridView1.DataSource = stokTable;
        }

        private void loadIngredient()
        {
            koneksi.getConn().Open();

            string query = "SELECT m.id_menu, m.nama_menu, i.id_stock, s.nama, i.qty " +
                "FROM menu_ingredients i " +
                "JOIN menu m ON i.id_menu = m.id_menu " +
                "JOIN stock s ON i.id_stock = s.id_bahan " +
                "ORDER BY i.id_menu ASC";
            MySqlCommand command = new MySqlCommand(query, koneksi.getConn());
            MySqlDataReader reader = command.ExecuteReader();

            DataTable ingTable = new DataTable();
            ingTable.Load(reader);
            reader.Close();
            koneksi.getConn().Close();

            dataGridView2.DataSource = ingTable;
        }

        private void Dapur_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
