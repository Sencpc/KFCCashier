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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace KFC
{
    public partial class manager : Form
    {
        MySqlTransaction transaction = null;
        int status;
        public manager(string user)
        {
            InitializeComponent();
            disableButton();
            label1.Text ="Welcome, "+user;
            koneksi.setupConn();
            LoadKategori();
            loadMenu();
            loadJenis();
            loadPotongan();
        }

        public void clearInput()
        {
            textBox1.Text = "";
            textBox4.Text = "";
            textBox2.Text = "";
            numericUpDown1.Value = 1;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
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

        public void loadJenis() 
        {
            comboBox2.Items.Add("Cripsy");
            comboBox2.Items.Add("Original");
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void loadPotongan()
        {
            comboBox3.Items.Add("Dada");
            comboBox3.Items.Add("Paha");
            comboBox3.Items.Add("Sayap");
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
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
            if (CekInput())
            {
                string namaMenu = textBox1.Text;
                string deskripsi = textBox4.Text;
                int idkategori = int.Parse(comboBox1.SelectedValue.ToString());
                //string namakategori = comboBox1.SelectedItem.ToString();
                int harga = int.Parse(GetNumbers(textBox2.Text));
                string jenis = comboBox2.SelectedItem.ToString();
                string potongan = comboBox3.SelectedItem.ToString();
                int jumlahPotongan = int.Parse(numericUpDown1.Value.ToString());
                int includeToy = 0;
                int statusMenu = status;

                koneksi.getConn().Open();

                string query = "INSERT INTO menu (nama_menu, deskripsi, id_kategori, harga, jenis, potongan, jumlah_potongan, include_toy, STATUS) VALUES " +
                    "(@namaMenu, @deskripsi, @idkategori, @harga, @jenis, @potongan, @jumlahPotongan, @includeToy, @statusMenu)";

                MySqlConnection conn = koneksi.getConn();

                try
                {
                    transaction = conn.BeginTransaction();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@namaMenu", namaMenu);
                        cmd.Parameters.AddWithValue("@deskripsi", deskripsi);
                        cmd.Parameters.AddWithValue("@idkategori", idkategori);
                        cmd.Parameters.AddWithValue("@harga", harga);
                        cmd.Parameters.AddWithValue("@jenis", jenis);
                        cmd.Parameters.AddWithValue("@potongan", potongan);
                        cmd.Parameters.AddWithValue("@jumlahPotongan", jumlahPotongan);
                        cmd.Parameters.AddWithValue("@includeToy", includeToy);
                        cmd.Parameters.AddWithValue("@statusMenu", statusMenu);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows && reader.Read())
                            {
                                MessageBox.Show("Berhasil menambahkan menu baru");
                            }
                        }
                    }

                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    transaction?.Rollback();

                    MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
                }
                finally
                {
                    koneksi.getConn().Close();
                    loadMenu();
                }
            }
            clearInput();
        }
        private bool CekInput()
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Menu kategori tidak diketahui");
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Menu harus punya nama");
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Menu harga harus ada");
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Deskripsi tidak boleh kosong");
                return false;
            }

            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Jenis ayam tidak boleh kosong");
                return false;
            }

            if (comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Harus ada potongan ayam");
                return false;
            }

            if (checkBox1.Checked == false && checkBox2.Checked == false)
            {
                MessageBox.Show("Menu harus aktif atau nonaktif");
                return false;
            }

            return true;
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
            status = 1;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            status = 0;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private static string GetNumbers(string input)
        {
            return new string(input.Where(c => char.IsDigit(c)).ToArray());
        }
    }
}
