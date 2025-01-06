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
    public partial class monitoring : Form
    {
        public monitoring()
        {
            InitializeComponent();
        }

        private void monitoring_Load(object sender, EventArgs e)
        {
            koneksi.setupConn();
        }

        //Button back (nutup form)
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
