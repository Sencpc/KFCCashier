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

        // login
        private void button1_Click(object sender, EventArgs e)
        {
            koneksi.getConn().Open();
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
                if (karyawan.jabatanCheck(username, password).Equals("Kasir") && dt.Rows[0][6].ToString().Equals("Aktif"))
                {
                    koneksi.getConn().Close();
                    Kasir k = new Kasir(fullName);
                    this.Hide();
                    DialogResult dr = k.ShowDialog();
                    if(dr == DialogResult.OK)
                    {
                        this.Show();
                    }
                }
                else if ((karyawan.jabatanCheck(username, password).Equals("Manager") || karyawan.jabatanCheck(username, password).Equals("Admin")) && dt.Rows[0][6].ToString().Equals("Aktif")) {
                    koneksi.getConn().Close();
                    manager m = new manager(fullName);
                    this.Hide();
                    DialogResult dr = m.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        this.Show();
                    }
                }
                else if ((karyawan.jabatanCheck(username, password).Equals("Koki") || karyawan.jabatanCheck(username, password).Equals("Chef")) && dt.Rows[0][6].ToString().Equals("Aktif"))
                {
                    koneksi.getConn().Close();
                    Dapur d = new Dapur(fullName);
                    this.Hide();
                    DialogResult dr = d.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        this.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Akun anda tidak aktif.", "Login Gagal "+ dt.Rows[0][5].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    koneksi.getConn().Close();
                }
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Username atau password salah.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
