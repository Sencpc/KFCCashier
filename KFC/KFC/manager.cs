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
    public partial class manager : Form
    {
        public manager(string user)
        {
            InitializeComponent();
            disableButton();
            label8.Text = user;
        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        //miss click
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //miss click
        private void label6_Click(object sender, EventArgs e)
        {

        }

        //miss click
        private void label7_Click(object sender, EventArgs e)
        {

        }


        //button add
        private void button4_Click(object sender, EventArgs e)
        {

        }

        //button update
        private void button5_Click(object sender, EventArgs e)
        {

        }

        //button delete
        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void disableButton()
        {
            button4.Enabled = true;
            button5.Enabled = false;
            button6.Enabled = false;
        }

        //logOut ke halaman login
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.ShowDialog();
            this.Hide();
        }
    }
}
