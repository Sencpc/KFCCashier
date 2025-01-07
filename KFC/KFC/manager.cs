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
        private int selectedMenuId = -1;
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
            selectedMenuId = -1;
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
            comboBox2.Items.Add("Hot");
            comboBox2.Items.Add("Cold");
            comboBox2.Items.Add("Sandwich");
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

            string query = "SELECT m.id_menu, m.nama_menu, m.deskripsi, k.id_kategori, k.nama_kategori," +
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
            if (!CekInput() || selectedMenuId == -1)
            {
                if (selectedMenuId == -1)
                {
                    MessageBox.Show("Pilih menu yang akan diupdate terlebih dahulu");
                }
                return;
            }

            DialogResult result = MessageBox.Show("Apakah anda yakin ingin mengupdate menu ini?",
                "Konfirmasi Update", MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes) return;

            MySqlConnection conn = koneksi.getConn();
            MySqlTransaction localTransaction = null;

            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                conn.Open();
                localTransaction = conn.BeginTransaction();

                string query = @"UPDATE menu 
                       SET nama_menu = @namaMenu,
                           deskripsi = @deskripsi, 
                           id_kategori = @idkategori, 
                           harga = @harga, 
                           jenis = @jenis, 
                           potongan = @potongan, 
                           jumlah_potongan = @jumlahPotongan, 
                           status = @statusMenu 
                       WHERE id_menu = @idMenu";

                using (MySqlCommand cmd = new MySqlCommand(query, conn, localTransaction))
                {
                    cmd.Parameters.AddWithValue("@idMenu", selectedMenuId);
                    cmd.Parameters.AddWithValue("@namaMenu", textBox1.Text);
                    cmd.Parameters.AddWithValue("@deskripsi", textBox4.Text);
                    cmd.Parameters.AddWithValue("@idkategori", int.Parse(comboBox1.SelectedValue.ToString()));
                    cmd.Parameters.AddWithValue("@harga", int.Parse(GetNumbers(textBox2.Text)));
                    cmd.Parameters.AddWithValue("@jenis", comboBox2.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@potongan", comboBox3.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@jumlahPotongan", (int)numericUpDown1.Value);
                    cmd.Parameters.AddWithValue("@statusMenu", status);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        localTransaction.Commit();
                        MessageBox.Show("Menu berhasil diupdate");
                        clearInput();
                        disableButton();
                    }
                    else
                    {
                        localTransaction.Rollback();
                        MessageBox.Show("Menu tidak ditemukan");
                    }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    localTransaction?.Rollback();
                }
                catch { }
                MessageBox.Show($"Terjadi kesalahan saat update: {ex.Message}");
            }
            finally
            {
                try
                {
                    conn.Close();
                }
                catch { }

                loadMenu();
            }
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

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    button5.Enabled = true;
                    button6.Enabled = true;
                    button4.Enabled = false;

                    DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                    selectedMenuId = Convert.ToInt32(row.Cells["id_menu"].Value);

                    textBox1.Text = row.Cells["nama_menu"].Value == DBNull.Value ? "" : row.Cells["nama_menu"].Value.ToString();
                    textBox4.Text = row.Cells["deskripsi"].Value == DBNull.Value ? "" : row.Cells["deskripsi"].Value.ToString();
                    textBox2.Text = row.Cells["harga"].Value == DBNull.Value ? "0" : row.Cells["harga"].Value.ToString();

                    if (row.Cells["id_kategori"].Value != DBNull.Value)
                    {
                        comboBox1.SelectedValue = row.Cells["id_kategori"].Value;
                    }

                    if (row.Cells["jenis"].Value != DBNull.Value)
                    {
                        string jenis = row.Cells["jenis"].Value.ToString();
                        for (int i = 0; i < comboBox2.Items.Count; i++)
                        {
                            if (comboBox2.Items[i].ToString().Equals(jenis, StringComparison.OrdinalIgnoreCase))
                            {
                                comboBox2.SelectedIndex = i;
                                break;
                            }
                        }
                    }

                    if (row.Cells["potongan"].Value != DBNull.Value)
                    {
                        string potongan = row.Cells["potongan"].Value.ToString();
                        for (int i = 0; i < comboBox3.Items.Count; i++)
                        {
                            if (comboBox3.Items[i].ToString().Equals(potongan, StringComparison.OrdinalIgnoreCase))
                            {
                                comboBox3.SelectedIndex = i;
                                break;
                            }
                        }
                    }

                    numericUpDown1.Value = row.Cells["jumlah_potongan"].Value == DBNull.Value ?
                        1 : Convert.ToDecimal(row.Cells["jumlah_potongan"].Value);

                    int status = row.Cells["status"].Value == DBNull.Value ?
                        0 : Convert.ToInt32(row.Cells["status"].Value);

                    if (status == 1)
                    {
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                        checkBox2.Checked = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Terjadi kesalahan saat memuat data: {ex.Message}");
                }
            }
        }
    }
}
