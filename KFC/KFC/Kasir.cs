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
        public Kasir(string user)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            printMenu();
        }

        private void Kasir_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        public void printMenu()
        {
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    Label nwlb = new Label();
                    nwlb.BackColor = System.Drawing.Color.White;
                    nwlb.Location = new System.Drawing.Point(34 + j*222, 122 + i*235);
                    nwlb.Name = "l"+i.ToString()+j.ToString();
                    nwlb.Size = new System.Drawing.Size(222, 235);
                    nwlb.TabIndex = 6;
                    panel2.Controls.Add(nwlb);

                    PictureBox nwpb = new PictureBox();
                    nwpb.Location = new System.Drawing.Point(34, 122);
                    nwpb.Name = "pictureBox2";
                    nwpb.Size = new System.Drawing.Size(222, 120);
                    nwpb.TabIndex = 7;
                    nwpb.TabStop = false;
                    panel2.Controls.Add(nwpb);

                    nwlb.BackColor = System.Drawing.Color.White;
                    nwlb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    nwlb.Location = new System.Drawing.Point(34, 259);
                    nwlb.Name = "2l"+i.ToString()+j.ToString();
                    nwlb.Size = new System.Drawing.Size(222, 37);
                    nwlb.TabIndex = 8;
                    nwlb.Text = "Kentang";
                    nwlb.Click += new System.EventHandler(this.label5_Click);
                    panel2.Controls.Add(nwlb);

                    nwlb.AutoSize = true;
                    nwlb.BackColor = System.Drawing.Color.White;
                    nwlb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    nwlb.ForeColor = System.Drawing.Color.Red;
                    nwlb.Location = new System.Drawing.Point(34, 323);
                    nwlb.Name = "label6";
                    nwlb.Size = new System.Drawing.Size(93, 20);
                    nwlb.TabIndex = 9;
                    nwlb.Text = "Rp 255.000";
                    panel2.Controls.Add(nwlb);

                    Button nwbtn = new Button();
                    nwbtn.BackColor = System.Drawing.Color.White;
                    nwbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    nwbtn.Location = new System.Drawing.Point(382, 314);
                    nwbtn.Name = "button8";
                    nwbtn.Size = new System.Drawing.Size(92, 32);
                    nwbtn.TabIndex = 10;
                    nwbtn.Text = "Add";
                    nwbtn.UseVisualStyleBackColor = false;
                    panel2.Controls.Add(nwbtn);
                }
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
