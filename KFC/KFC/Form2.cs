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
using System.Collections;

namespace KFC
{
    public partial class Form2 : Form
    {
        DataTable dtCart;
        DataTable dtDiskon= new DataTable();
        int selected = -1;
        string idkaryawan;
        string iddiskon;

        public Form2(DataTable dtCart, string idkaryawan)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.dtCart = dtCart;
            this.idkaryawan = idkaryawan;
            koneksi.setupConn();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dgvOrder.DataSource = dtCart;
            numericUpDown1.Enabled = false;
            button4.Enabled = false;
            LoadDiskonComboBox();
            comboBox1.SelectedIndex = 0;
            iddiskon = comboBox1.SelectedValue.ToString();
        }

        private void LoadDiskonComboBox()
        {
            koneksi.getConn().Open();
            string query = "SELECT id_diskon, nama_diskon FROM diskon WHERE status_diskon = 'Aktif'";
            MySqlDataAdapter da = new MySqlDataAdapter(query, koneksi.getConn());
            koneksi.getConn().Close();
            da.Fill(dtDiskon);

            comboBox1.DataSource = dtDiskon;
            comboBox1.DisplayMember = "nama_diskon";
            comboBox1.ValueMember = "id_diskon";
        }

        //tombol home
        private void label2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //tombol cetak
        private void button4_Click(object sender, EventArgs e)
        {
            if (selected != -1)
            {
                if (numericUpDown1.Value == 0)
                {
                    dtCart.Rows[selected].Delete();
                    selected = -1;
                    return;
                }
                try
                {
                    decimal harga = decimal.Parse(GetNumbers(dtCart.Rows[selected]["Harga"].ToString()));
                    int jumlah = Convert.ToInt32(numericUpDown1.Value);
                    decimal subtotal = harga * jumlah;

                    dtCart.Rows[selected]["Jumlah"] = jumlah;
                    dtCart.Rows[selected]["Subtotal"] = subtotal;

                    dgvOrder.DataSource = dtCart;
                    numericUpDown1.Enabled = false;
                    button4.Enabled = false;
                    selected = -1;
                    iddiskon = "1";
                    comboBox1.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating cart: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static string GetNumbers(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "0";

            return new string(input.Where(c => char.IsDigit(c)).ToArray());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dtCart.Rows.Count == 0)
            {
                MessageBox.Show("Cart is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MySqlTransaction transaction = null;
            MySqlConnection conn = koneksi.getConn();

            try
            {
                conn.Open();
                transaction = conn.BeginTransaction();

                decimal totalharga = 0;
                bool availability = true;

                foreach (DataRow row in dtCart.Rows)
                {
                    decimal subtotal;
                    if (decimal.TryParse(row["Subtotal"].ToString(), out subtotal))
                    {
                        totalharga += subtotal;
                    }

                    int menuId = Convert.ToInt32(row["Id"]);
                    int quantity = Convert.ToInt32(row["Jumlah"]);

                    availability = CheckStockAvailabilityWithConnection(conn, menuId, quantity);
                    if (!availability)
                    {
                        break;
                    }
                }

                if (!availability)
                {
                    MessageBox.Show("Stock is not enough", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string htrans = @"INSERT INTO h_trans 
            (tanggal_transaksi, id_karyawan, total_harga, id_diskon, total_diskon) 
            VALUES (@tanggal, @id_karyawan, @totalharga, @id_diskon, @totaldiskon);
            SELECT LAST_INSERT_ID();";

                long lastInsertedId;
                using (MySqlCommand cmd = new MySqlCommand(htrans, conn, transaction))
                {
                    cmd.Parameters.Add("@tanggal", MySqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@id_karyawan", MySqlDbType.VarChar).Value = idkaryawan;
                    cmd.Parameters.Add("@totalharga", MySqlDbType.Decimal).Value = totalharga;
                    cmd.Parameters.Add("@id_diskon", MySqlDbType.VarChar).Value = iddiskon;
                    cmd.Parameters.Add("@totaldiskon", MySqlDbType.Decimal).Value = GetTotalDiskonWithConnection(conn, Convert.ToInt32(totalharga));
                    lastInsertedId = Convert.ToInt64(cmd.ExecuteScalar());
                }

                string dtrans = @"INSERT INTO d_trans 
            (id_htrans, id_menu, qty, subtotal) 
            VALUES (@idhtrans, @idmenu, @qty, @subtotal)";

                foreach (DataRow row in dtCart.Rows)
                {
                    using (MySqlCommand cmd = new MySqlCommand(dtrans, conn, transaction))
                    {
                        cmd.Parameters.Add("@idhtrans", MySqlDbType.Int64).Value = lastInsertedId;
                        cmd.Parameters.Add("@idmenu", MySqlDbType.Int32).Value = Convert.ToInt32(row["Id"]);
                        cmd.Parameters.Add("@qty", MySqlDbType.Int32).Value = Convert.ToInt32(row["Jumlah"]);
                        cmd.Parameters.Add("@subtotal", MySqlDbType.Decimal).Value = Convert.ToDecimal(row["Subtotal"]);
                        cmd.ExecuteNonQuery();
                    }
                    ReduceStockWithConnection(conn, Convert.ToInt32(row["Id"]), Convert.ToInt32(row["Jumlah"]));
                }

                transaction.Commit();
                MessageBox.Show("Transaction successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cetakan cetak = new Cetakan(1,Convert.ToInt32(lastInsertedId));
                cetak.ShowDialog();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                button4.Enabled = true;
                numericUpDown1.Enabled = true;
                numericUpDown1.Value = Convert.ToInt32(dtCart.Rows[e.RowIndex]["Jumlah"].ToString());
                selected = e.RowIndex;
            }
        }

        private int GetTotalDiskonWithConnection(MySqlConnection conn, int totalharga)
        {
            int totaldiskon = 0;
            string query = @"SELECT nominal, diskon_type 
                    FROM diskon 
                    WHERE id_diskon = @id_diskon";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_diskon", iddiskon);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int nominal = reader.GetInt32("nominal");
                        string diskonType = reader.GetString("diskon_type");

                        if (diskonType == "Persen")
                        {
                            totaldiskon = (totalharga * nominal) / 100;
                        }
                        else if (diskonType == "Nominal")
                        {
                            totaldiskon = nominal;
                        }else
                        {
                            totaldiskon = 0;
                        }
                    }
                }
            }
            return totaldiskon;
        }

        private bool CheckStockAvailabilityWithConnection(MySqlConnection conn, int menuId, int quantity)
        {
            string query = "SELECT check_stock_availability(@menuId, @quantity)";
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@menuId", menuId);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }

        private void ReduceStockWithConnection(MySqlConnection conn, int menuId, int quantity)
        {
            using (var cmd = new MySqlCommand("reduce_stock", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_menu_id", menuId);
                cmd.Parameters.AddWithValue("@p_quantity", quantity);
                cmd.ExecuteNonQuery();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             iddiskon = comboBox1.SelectedValue.ToString();
        }
    }
}