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
    public partial class Cetakan : Form
    {
        public Cetakan(int id)
        {
            InitializeComponent();
            try
            {
                CrystalReport1 report = new CrystalReport1();
                report.SetParameterValue("h_transID", id);

                crystalReportViewer1.ReportSource = report;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report: {ex.Message}");
            }
        }
    }
}
