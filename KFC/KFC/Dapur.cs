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
        DataTable stokTable;
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

            stokTable = new DataTable();
            stokTable.Load(reader);
            reader.Close();
            koneksi.getConn().Close();

            dataGridView1.DataSource = stokTable;

            dataGridView1.Columns["id_bahan"].HeaderText = "ID";
            dataGridView1.Columns["nama"].HeaderText = "Nama Bahan";
            dataGridView1.Columns["qty"].HeaderText = "Jumlah Barang";
            dataGridView1.Columns["satuan_bahan"].HeaderText = "Satuan";

            DataGridViewButtonColumn btnIncrease = new DataGridViewButtonColumn();
            btnIncrease.HeaderText = "Increase";
            btnIncrease.Text = "+";
            btnIncrease.Name = "btnIncrease";
            btnIncrease.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btnIncrease);

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                koneksi.getConn().Open();

                MySqlConnection conn = koneksi.getConn();

                if (dataGridView1.Columns[e.ColumnIndex].Name == "btnIncrease")
                {
                    string id = dataGridView1.Rows[e.RowIndex].Cells["id_bahan"].Value.ToString();
                    string stocks = dataGridView1.Rows[e.RowIndex].Cells["qty"].Value.ToString();
                    int stok = Convert.ToInt32(stocks);
                    stok++;
                    dataGridView1.Rows[e.RowIndex].Cells["qty"].Value = stok;

                    string query = "UPDATE stock SET qty = @stok WHERE id_bahan = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@stok", stok);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    koneksi.getConn().Close();
                    dataGridView1.DataSource = stokTable;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
