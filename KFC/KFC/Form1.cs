using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KFC
{
    public partial class Form1 : Form
    {
        Design d = new Design();
        Karyawan karyawan = new Karyawan();

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            d.roundedLabel(label1,15);
            d.roundedButton(57, button1);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            koneksi.setupConn();
        }

        //  miss click
        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        // miss click
        private void label2_Click(object sender, EventArgs e)
        {

        }

        // login
        private void button1_Click(object sender, EventArgs e)
        {
            
            string username = textBox1.Text;
            string password = textBox2.Text;
            string fullName = karyawan.fullNameCheck(username, password);

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username dan password tidak boleh kosong.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = karyawan.karyawanCheck(username, password);

            if (dt.Rows.Count > 0)
            {
                if (karyawan.jabatanCheck(username, password).Equals("Kasir"))
                {
                    Kasir k = new Kasir(fullName);
                    k.ShowDialog();
                    this.Hide();
                }
                else if (karyawan.jabatanCheck(username, password).Equals("Manager") || karyawan.jabatanCheck(username, password).Equals("Admin")) {
                    manager m = new manager(fullName);
                    m.ShowDialog();
                    this.Hide(); 
                }
            }
            else
            {
                MessageBox.Show("Username atau password salah.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
