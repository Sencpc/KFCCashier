using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KFC
{
    public partial class manager : Form
    {
        public manager(string user)
        {
            InitializeComponent();
            disableButton();
            label1.Text ="Welcome, "+user;
            koneksi.setupConn();
            LoadKategori();
            loadMenu();
        }

        public void LoadKategori()
        {
            koneksi.getConn().Open();

            string query = "SELECT id_kategori, nama_kategori FROM kategori";
            MySqlCommand command = new MySqlCommand(query, koneksi.getConn());
            MySqlDataReader reader = command.ExecuteReader();

            DataTable kategoriTable = new DataTable();
            kategoriTable.Load(reader);
            reader.Close();
            koneksi.getConn().Close();

            comboBox1.DataSource = kategoriTable;
            comboBox1.DisplayMember = "nama_kategori";
            comboBox1.ValueMember = "id_kategori";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void loadMenu()
        {
            koneksi.getConn().Open();

            string query = "SELECT m.nama_menu, m.deskripsi, k.id_kategori, k.nama_kategori," +
                           " m.harga, m.jenis, m.potongan, m.jumlah_potongan, m.status " +
                           "FROM menu m " +
                           "JOIN kategori k ON m.id_kategori = k.id_kategori " +
                           "ORDER BY m.id_menu ASC";
            MySqlCommand command = new MySqlCommand(query, koneksi.getConn());
            MySqlDataReader reader = command.ExecuteReader();

            DataTable menuTable = new DataTable();
            menuTable.Load(reader);
            reader.Close();
            koneksi.getConn().Close();

            dataGridView2.DataSource = menuTable;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //button add
        private void button4_Click(object sender, EventArgs e)
        {
            string foodName = textBox1.Text;
        }

        //button update
        private void button5_Click(object sender, EventArgs e)
        {

        }

        //button delete
        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void disableButton()
        {
            button4.Enabled = true;
            button5.Enabled = false;
            button6.Enabled = false;
        }

        //logOut ke halaman login
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //Buka form monitoring
        private void button2_Click(object sender, EventArgs e)
        {
            monitoring monitor = new monitoring();
            monitor.ShowDialog();
        }

        //kepencet
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }
    }
}
