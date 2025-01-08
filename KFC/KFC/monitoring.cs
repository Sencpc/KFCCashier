using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MySql.Data.MySqlClient;

namespace KFC
{
    public partial class monitoring : Form
    {
        MySqlTransaction transaction = null;
        int idKaryawan;
        public monitoring()
        {
            InitializeComponent();
            koneksi.setupConn();
            loadKaryawan();
            loadCabang();
            loadJabatan();
            loadStatus();
            clearInput();
        }

        private void monitoring_Load(object sender, EventArgs e)
        {

        }

        // Load Karyawan ke DGV
        public void loadKaryawan()
        {
            koneksi.getConn().Open();

            string query = "SELECT k.id_pegawai, k.id_cabang, c.nama_daerah, c.jalan_cabang, k.fullName, " +
                           "k.username_karyawan, k.password_karyawan, k.jabatan, k.status " +
                           "FROM karyawan k " +
                           "JOIN cabang c ON k.id_cabang = c.id_cabang " +
                           "ORDER BY k.id_pegawai ASC";
            MySqlCommand command = new MySqlCommand(query, koneksi.getConn());
            MySqlDataReader reader = command.ExecuteReader();

            DataTable karyawanTable = new DataTable();
            karyawanTable.Load(reader);
            reader.Close();
            koneksi.getConn().Close();

            dataGridView1.DataSource = karyawanTable;

            dataGridView1.Columns["id_pegawai"].HeaderText = "ID";
            dataGridView1.Columns["id_cabang"].HeaderText = "ID Cabang";
            dataGridView1.Columns["nama_daerah"].HeaderText = "Daerah";
            dataGridView1.Columns["jalan_cabang"].HeaderText = "Alamat";
            dataGridView1.Columns["fullName"].HeaderText = "Nama Lengkap";
            dataGridView1.Columns["username_karyawan"].HeaderText = "Username";
            dataGridView1.Columns["password_karyawan"].HeaderText = "Password";
            dataGridView1.Columns["jabatan"].HeaderText = "Jabatan";
            dataGridView1.Columns["status"].HeaderText = "Status";
        }

        private void loadCabang()
        {
            koneksi.getConn().Open();

            string query = "SELECT id_cabang, jalan_cabang FROM cabang";
            MySqlCommand command = new MySqlCommand(query, koneksi.getConn());
            MySqlDataReader reader = command.ExecuteReader();

            DataTable cabangTable = new DataTable();
            cabangTable.Load(reader);
            reader.Close();
            koneksi.getConn().Close();

            comboBox1.DataSource = cabangTable;
            comboBox1.DisplayMember = "jalan_cabang";
            comboBox1.ValueMember = "id_cabang";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void loadJabatan()
        {
            comboBox2.Items.Add("Admin");
            comboBox2.Items.Add("Kasir");
            comboBox2.Items.Add("Manager");
            comboBox2.Items.Add("Chef");
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void loadStatus()
        {
            comboBox3.Items.Add("Aktif");
            comboBox3.Items.Add("Nonaktif");
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //Button back (nutup form)
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Button ADD
        private void button2_Click(object sender, EventArgs e)
        {
            if (CekInput())
            {

                int idCabang = int.Parse(comboBox1.SelectedValue.ToString());
                string fullName = textBox1.Text;
                string username = textBox2.Text;
                string password = textBox3.Text;
                string jabatan = comboBox2.SelectedItem.ToString();
                string status = comboBox3.SelectedItem.ToString();

                koneksi.getConn().Open();

                string query = "INSERT INTO karyawan (id_cabang , fullName , username_karyawan , password_karyawan , jabatan , status) VALUES " +
                    "(@idCabang , @fullName , @username , @password , @jabatan , @status)";

                MySqlConnection conn = koneksi.getConn();

                try
                {
                    transaction = conn.BeginTransaction();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@idCabang", idCabang);
                        cmd.Parameters.AddWithValue("@fullName", fullName);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@jabatan", jabatan);
                        cmd.Parameters.AddWithValue("@status", status);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows && reader.Read())
                            {
                                MessageBox.Show("Berhasil menambahkan Karyawan Baru!YEY");
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
                    loadKaryawan();
                    clearInput();   
                }
            }
        }

        private bool CekInput()
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Tolong Pilih Jalan ya BABI!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("KAMU GA PUNYA NAMA?");
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("MAU PAKE NAMA NIGGA@1424?");
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("KU KASI PASSWORD REKOMENDASI DARI GOOGLE MAU?");
                return false;
            }

            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Jd JANITOR aja ya?");
                return false;
            }

            if (comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Mau ga dapet gaji?");
                return false;
            }

            return true;
        }

        private void clearInput() {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                idKaryawan = Convert.ToInt32(row.Cells["id_pegawai"].Value.ToString());
                textBox1.Text = row.Cells["fullName"].Value?.ToString();
                textBox2.Text = row.Cells["username_karyawan"].Value?.ToString();
                textBox3.Text = row.Cells["password_karyawan"].Value?.ToString(); // Hindari menampilkan password asli

                string idCabang = row.Cells["id_cabang"].Value?.ToString();
                if (!string.IsNullOrEmpty(idCabang))
                {
                    comboBox1.SelectedValue = idCabang;
                }

                string jabatan = row.Cells["jabatan"].Value?.ToString();
                if (comboBox2.Items.Contains(jabatan))
                {
                    comboBox2.SelectedItem = jabatan;
                }

                string status = row.Cells["STATUS"].Value?.ToString();
                if (status == "Aktif")
                {
                    comboBox3.SelectedIndex = 0;
                }
                else if (status == "Nonaktif")
                {
                    comboBox3.SelectedIndex = 1;
                }
            }
        }

        //button UPDATE
        private void button3_Click(object sender, EventArgs e)
        {
            int idCabang = int.Parse(comboBox1.SelectedValue.ToString());
            string fullName = textBox1.Text;
            string username = textBox2.Text;
            string password = textBox3.Text;
            string jabatan = comboBox2.SelectedItem.ToString();
            string status = comboBox3.SelectedItem.ToString();

            if (CekInput())
            {
                koneksi.getConn().Open();

                string query = "UPDATE karyawan " +
                    "SET id_cabang = @idCabang , fullName = @fullName , username_karyawan = @username , password_karyawan = @password , jabatan = @jabatan , status = @status " +
                    "WHERE id_pegawai = @idKaryawan ";

                MySqlConnection conn = koneksi.getConn();

                try
                {
                    transaction = conn.BeginTransaction();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@idKaryawan", idKaryawan);
                        cmd.Parameters.AddWithValue("@idCabang", idCabang);
                        cmd.Parameters.AddWithValue("@fullName", fullName);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@jabatan", jabatan);
                        cmd.Parameters.AddWithValue("@status", status);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows && reader.Read())
                            {
                                MessageBox.Show("Berhasil mengubah Data!");
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
                    loadKaryawan();
                    clearInput();
                }
            }
        }

        //button Clear
        private void button4_Click(object sender, EventArgs e)
        {
            clearInput();
        }
    }
}
