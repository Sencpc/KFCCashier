using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            DatabaseService db = new DatabaseService();

            try
            {
                var dataset = db.GetAllData();

                if (dataset.Tables.Count > 0)
                {
                    foreach (DataTable table in dataset.Tables)
                    {
                        Console.WriteLine($"Loaded {table.TableName}: {table.Rows.Count} rows");
                    }

                    CrystalReport1 report = new CrystalReport1();
                    report.SetDataSource(dataset);
                    report.SetParameterValue("h_transID", id);
                    crystalReportViewer1.ReportSource = report;
                }
                else
                {
                    MessageBox.Show("No data was loaded from the database.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report: {ex.Message}");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (crystalReportViewer1.ReportSource != null)
            {
                CrystalReport1 report = (CrystalReport1)crystalReportViewer1.ReportSource;
                report.Close();
                report.Dispose();
            }
        }
    }
}
