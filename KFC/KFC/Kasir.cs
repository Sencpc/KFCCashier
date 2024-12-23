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
        }

        private void Kasir_Load(object sender, EventArgs e)
        {

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

        //Kalau pakai dynamic component e

        //label
        //this.label4.BackColor = System.Drawing.Color.White;
        //this.label4.Location = new System.Drawing.Point(264, 122);
        //this.label4.Name = "label4";
        //this.label4.Size = new System.Drawing.Size(222, 235);
        //this.label4.TabIndex = 6;

        /* Picture Box
        this.pictureBox2.Location = new System.Drawing.Point(264, 122);
        this.pictureBox2.Name = "pictureBox2";
        this.pictureBox2.Size = new System.Drawing.Size(222, 120);
        this.pictureBox2.TabIndex = 7;
        this.pictureBox2.TabStop = false;
        */
        /* Label untuk text nama makanan e 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(264, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 37);
            this.label5.TabIndex = 8;
            this.label5.Text = "Kentang";
            this.label5.Click += new System.EventHandler(this.label5_Click);
         */

        /* label buat text harganya 
         
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(274, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Rp 255.000";
        
        */

        /* Button add
         
            this.button8.BackColor = System.Drawing.Color.White;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(382, 314);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(92, 32);
            this.button8.TabIndex = 10;
            this.button8.Text = "Add";
            this.button8.UseVisualStyleBackColor = false;
         
        */
    }
}
