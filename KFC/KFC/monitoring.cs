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
        public monitoring()
        {
            InitializeComponent();
            koneksi.setupConn();
            loadKaryawan();
            loadCabang();
            loadJabatan();
            loadStatus();
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
            int idCabang = int.Parse(comboBox1.SelectedValue.ToString());
            string fullName = textBox1.Text;
            string username = textBox2.Text;
            string password = textBox3.Text;
            string jabatan = comboBox2.SelectedItem.ToString();
            string status = comboBox3.SelectedItem.ToString();

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

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

        }

        //button DELETE
        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
