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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KFC
{
    public partial class Diskon : Form
    {
        DataTable ingTable;
        MySqlTransaction transaction = null;
        public Diskon()
        {
            InitializeComponent();
            loadDiskon();
            loadStatus();
            loadTipe();
            CLearInput();
        }

        private bool CheckInput()
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Tipenya apa ya?!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Diskonnya unknown?");
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Ga berharga ya?!");
                return false;
            }

            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Statusnya apa? Jomblo kayak kamu? hahaha");
                return false;
            }

            return true;
        }

        public void CLearInput() 
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.SelectedIndex = -1; 
            comboBox2.SelectedIndex = -1;
        }

        private static string GetNumbers(string input)
        {
            return new string(input.Where(c => char.IsDigit(c)).ToArray());
        }

        public void loadTipe()
        {
            comboBox1.Items.Add("Persen");
            comboBox1.Items.Add("Nominal");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void loadStatus()
        {
            comboBox2.Items.Add("Aktif");
            comboBox2.Items.Add("Nonaktif");
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void loadDiskon() 
        {
            koneksi.getConn().Open();

            string query = "SELECT id_diskon as ID , nama_diskon as 'Nama Diskon' , diskon_type as Tipe , nominal as 'Total Diskon' , status_diskon as Status " +
                "FROM diskon";
            MySqlCommand command = new MySqlCommand(query, koneksi.getConn());
            MySqlDataReader reader = command.ExecuteReader();

            ingTable = new DataTable();
            ingTable.Load(reader);
            reader.Close();
            koneksi.getConn().Close();

            dataGridView1.DataSource = ingTable;

            DataGridViewButtonColumn turnOff = new DataGridViewButtonColumn();
            turnOff.HeaderText = "Change";
            turnOff.Text = "NonActive Status";
            turnOff.Name = "turnOff";
            turnOff.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(turnOff);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {

                string namaDiskon = textBox1.Text;
                decimal nominal = int.Parse(GetNumbers(textBox2.Text));
                string type = comboBox1.SelectedItem.ToString();
                string status = comboBox2.SelectedItem.ToString();

                koneksi.getConn().Open();

                string query = "INSERT INTO diskon (nama_diskon , nominal , diskon_type , status_diskon) VALUES " +
                    "(@namaDiskon , @nominal , @type , @status)";

                MySqlConnection conn = koneksi.getConn();

                try
                {
                    transaction = conn.BeginTransaction();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@namaDiskon", namaDiskon);
                        cmd.Parameters.AddWithValue("@nominal", nominal);
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.Parameters.AddWithValue("@status", status);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows && reader.Read())
                            {
                                MessageBox.Show("Berhasil menambahkan Diskon Baru :) !YEY");
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
                    dataGridView1.DataSource = ingTable;
                    CLearInput();
                }
            }
        }

        public enum DiskonStatus
        {
            Aktif = 1,
            Nonaktif = 0
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "turnOff")
            {
                koneksi.getConn().Open();

                MySqlConnection conn = koneksi.getConn();

                string id = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                string status = dataGridView1.Rows[e.RowIndex].Cells["Status"].Value.ToString();

                // Konversi status ke tipe enum
                DiskonStatus currentStatus;
                if (!Enum.TryParse(status, out currentStatus))
                {
                    MessageBox.Show("Status tidak valid.");
                    koneksi.getConn().Close();
                    return;
                }

                // Tentukan status baru berdasarkan status saat ini
                DiskonStatus newStatus = currentStatus == DiskonStatus.Aktif ? DiskonStatus.Nonaktif : DiskonStatus.Aktif;

                // Update database
                string query = "UPDATE diskon SET status_diskon = @status WHERE id_diskon = @id";
                
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@status", newStatus.ToString()); // Cast enum ke int
                    cmd.ExecuteNonQuery();
                }

                string query1 = "SELECT id_diskon as ID , nama_diskon as 'Nama Diskon' , diskon_type as Tipe , nominal as 'Total Diskon' , status_diskon as Status " +
                    "FROM diskon";
                MySqlCommand command = new MySqlCommand(query1, koneksi.getConn());
                MySqlDataReader reader = command.ExecuteReader();

                ingTable = new DataTable();
                ingTable.Load(reader);
                reader.Close();
                koneksi.getConn().Close();
                dataGridView1.DataSource = ingTable;
            }
        }
    }
}
