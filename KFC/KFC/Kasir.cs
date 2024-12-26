using KFC.Properties;
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
        public Kasir(string user)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Kasir_Load(object sender, EventArgs e)
        {
            printMenu();
            dgvMenu.DataSource = menu.showMenu();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        public void printMenu()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Panel nwpl = new Panel();
                    nwpl.BackColor = System.Drawing.Color.White;
                    nwpl.Location = new System.Drawing.Point(34 + j * 340, 80 + i * 340);
                    nwpl.Name = "panel3";
                    nwpl.Size = new System.Drawing.Size(322, 326);
                    nwpl.TabIndex = 11;

                    Label nwlb= new Label();
                    nwlb.AutoSize = true;
                    nwlb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    nwlb.Location = new System.Drawing.Point(23, 161);
                    nwlb.Name = "label4";
                    nwlb.Size = new System.Drawing.Size(161, 29);
                    nwlb.TabIndex = 2;
                    nwlb.Text = "Paket Hemat";
                    nwpl.Controls.Add(nwlb);

                    Label nwlb2 = new Label();
                    nwlb2.Location = new System.Drawing.Point(28, 194);
                    nwlb2.Name = "label5";
                    nwlb2.Size = new System.Drawing.Size(275, 75);
                    nwlb2.TabIndex = 3;
                    nwlb2.Text = "21 Piece of chicken cooked to golden perfection and a 2lt Pepsi";
                    nwpl.Controls.Add(nwlb2);

                    Label nwlb3 = new Label();
                    nwlb3.BackColor = System.Drawing.Color.White;
                    nwlb3.ForeColor = System.Drawing.Color.Red;
                    nwlb3.Location = new System.Drawing.Point(23, 282);
                    nwlb3.Name = "label6";
                    nwlb3.Size = new System.Drawing.Size(152, 29);
                    nwlb3.TabIndex = 4;
                    nwlb3.Text = "Rp 78.000";
                    nwpl.Controls.Add(nwlb3);

                    PictureBox nwpb = new PictureBox();
                    //nwpb.Image = Image.FromFile("C:\\Users\\seanc\\Downloads\\6b061175-ed79-daf0-5aab-f1026a9b657a.png");
                    nwpb.Location = new System.Drawing.Point(19, 16);
                    nwpb.Name = "pictureBox2";
                    nwpb.Size = new System.Drawing.Size(284, 131);
                    nwpb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                    nwpb.TabIndex = 0;
                    nwpb.TabStop = false;
                    nwpl.Controls.Add(nwpb);

                    Button nwbtn = new Button();
                    nwbtn.Location = new System.Drawing.Point(181, 272);
                    nwbtn.Name = "button2";
                    nwbtn.Size = new System.Drawing.Size(122, 39);
                    nwbtn.TabIndex = 1;
                    nwbtn.Text = "Buy";
                    nwbtn.UseVisualStyleBackColor = true;
                    nwpl.Controls.Add(nwbtn);

                    panel2.Controls.Add(nwpl);
                }
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //fiter button ALL
        private void button3_Click(object sender, EventArgs e)
        {
            dgvMenu.DataSource = menu.showMenu();
        }

        //fiter button Burger
        private void button4_Click(object sender, EventArgs e)
        {
            dgvMenu.DataSource = menu.showMenu(kategori: "Sides");
        }

        //fiter button Drinks
        private void button5_Click(object sender, EventArgs e)
        {
            dgvMenu.DataSource = menu.showMenu(kategori: "Drinks");
        }

        //fiter button Breakfast
        private void button6_Click(object sender, EventArgs e)
        {
            dgvMenu.DataSource = menu.showMenu(kategori: "Breakfast");
        }

        //fiter button Bucket
        private void button7_Click(object sender, EventArgs e)
        {
            dgvMenu.DataSource = menu.showMenu(kategori: "Bucket");
        }
    }
}
