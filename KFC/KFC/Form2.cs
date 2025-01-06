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
    public partial class Form2 : Form
    {
        DataTable dtCart;
        int selected = -1;
        public Form2(DataTable dtCart)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.dtCart = dtCart;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            koneksi.setupConn();
            dgvOrder.DataSource = dtCart;
            numericUpDown1.Enabled = false;
            button4.Enabled = false;
        }

        //tombol home
        private void label2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(selected != -1)
            {
                if (numericUpDown1.Value == 0)
                {
                    dtCart.Rows[selected].Delete();
                    selected = -1;
                    return;
                }
                dtCart.Rows[selected]["Jumlah"] = numericUpDown1.Value;
                dtCart.Rows[selected]["Subtotal"] = Convert.ToInt32(dtCart.Rows[selected]["Harga"]) * Convert.ToInt32(dtCart.Rows[selected]["Jumlah"]);
                dgvOrder.DataSource = dtCart;
                numericUpDown1.Enabled = false;
                button4.Enabled = false;
                selected = -1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cetakan cetak = new Cetakan(1);
            cetak.ShowDialog();
            cetak.Close();
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvOrder.Rows[e.RowIndex];
                button4.Enabled = true;
                numericUpDown1.Enabled = true;
                numericUpDown1.Value = Convert.ToInt32(row.Cells["Jumlah"].Value);
                selected = e.RowIndex;
            }
        }
    }
}
