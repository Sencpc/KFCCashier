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
        }

        //tombol home
        private void label2_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.ShowDialog();
            this.Hide();
        }

    }
}
