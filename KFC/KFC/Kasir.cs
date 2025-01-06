using KFC.Properties;
using Mysqlx.Resultset;
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
    public partial class Kasir : Form
    {
        Design d = new Design();
        Menu menu = new Menu();
        DataTable menuUtama = new DataTable();
        DataTable dtCart = new DataTable();
        public Kasir(string user)
        {
            InitializeComponent();
            koneksi.setupConn();
            label1.Text = user;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Kasir_Load(object sender, EventArgs e)
        {
            koneksi.getConn().Open();
            menuUtama = menu.showMenu();
            resetMenu();
        }

        public void resetMenu()
        {
            koneksi.getConn().Close();
            panel2.Controls.Clear();
            printMenu();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(dtCart);
            form2.ShowDialog();
            form2.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void printMenu()
        {
            int t = -1;
            for (int i = 0 ;i < menuUtama.Rows.Count ; i++)
            {
                int j = 0;
                if (i % 2 == 1)
                {
                    j = 1;
                }
                else
                {
                    t++;
                }

                Panel nwpl = new Panel();
                nwpl.BackColor = System.Drawing.Color.White;
                nwpl.Location = new System.Drawing.Point(34 + j * 340, 10 + t * 340);
                nwpl.Name = "panelMenu" + i;
                nwpl.Size = new System.Drawing.Size(322, 326);
                nwpl.TabIndex = 11;

                Label nwlb= new Label();
                nwlb.AutoSize = true;
                nwlb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                nwlb.Location = new System.Drawing.Point(23, 161);
                nwlb.Name = "labelNama" + i;
                nwlb.Size = new System.Drawing.Size(161, 29);
                nwlb.TabIndex = 2;
                nwlb.Text = menuUtama.Rows[i][0].ToString();
                nwpl.Controls.Add(nwlb);

                Label nwlb2 = new Label();
                nwlb2.Location = new System.Drawing.Point(28, 194);
                nwlb2.Name = "labelDesk" + i;
                nwlb2.Size = new System.Drawing.Size(275, 75);
                nwlb2.TabIndex = 3;
                nwlb2.Text = menuUtama.Rows[i][1].ToString();
                nwpl.Controls.Add(nwlb2);

                Label nwlb3 = new Label();
                nwlb3.BackColor = System.Drawing.Color.White;
                nwlb3.ForeColor = System.Drawing.Color.Red;
                nwlb3.Location = new System.Drawing.Point(23, 282);
                nwlb3.Name = "labelHarga" + i;
                nwlb3.Size = new System.Drawing.Size(152, 29);
                nwlb3.TabIndex = 4;
                nwlb3.Text = "Rp "+menuUtama.Rows[i][2].ToString();
                nwpl.Controls.Add(nwlb3);

                PictureBox nwpb = new PictureBox();
                //nwpb.Image = Image.FromFile("C:\\Users\\seanc\\Downloads\\6b061175-ed79-daf0-5aab-f1026a9b657a.png");
                nwpb.Location = new System.Drawing.Point(19, 16);
                nwpb.Name = "gambarMenu" + i;
                nwpb.Size = new System.Drawing.Size(284, 131);
                nwpb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                nwpb.TabIndex = 0;
                nwpb.TabStop = false;
                nwpl.Controls.Add(nwpb);

                Button nwbtn = new Button();
                nwbtn.Location = new System.Drawing.Point(181, 272);
                nwbtn.Name = "btnBuy" + i;
                nwbtn.Size = new System.Drawing.Size(122, 39);
                nwbtn.TabIndex = 1;
                nwbtn.Text = "Buy";
                nwbtn.UseVisualStyleBackColor = true;
                nwbtn.Click += new EventHandler(btnBuy_Click);
                nwpl.Controls.Add(nwbtn);

                panel2.Controls.Add(nwpl);
            }
        }

        //buat ngeadd ke cart
        private void btnBuy_Click(object sender, EventArgs e)
        {

        }

        //fiter button ALL
        private void button3_Click(object sender, EventArgs e)
        {
            koneksi.getConn().Open();
            menuUtama = menu.showMenu();
            resetMenu();
        }

        //fiter button Sides
        private void button4_Click(object sender, EventArgs e)
        {
            koneksi.getConn().Open();
            menuUtama = menu.showMenu(kategori: "Sides");
            resetMenu();
        }

        //fiter button Drinks
        private void button5_Click(object sender, EventArgs e)
        {
            koneksi.getConn().Open();
            menuUtama = menu.showMenu(kategori: "Drinks");
            resetMenu();
        }

        //fiter button Breakfast
        private void button6_Click(object sender, EventArgs e)
        {
            koneksi.getConn().Open();
            menuUtama = menu.showMenu(kategori: "Breakfast");
            resetMenu();
        }

        //fiter button Bucket
        private void button7_Click(object sender, EventArgs e)
        {
            koneksi.getConn().Open();
            menuUtama = menu.showMenu(kategori: "Bucket");
            resetMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.ShowDialog();
            this.Hide();
        }
    }
}
