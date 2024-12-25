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
            string user = textBox1.Text;
            if (user.Equals("")) { 
                
            }
            Kasir k = new Kasir(user);
            k.ShowDialog();
            this.Hide();
        }
    }
}
