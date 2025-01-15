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
        int type;
        public Cetakan(int type,int id)
        {
            InitializeComponent();
            DatabaseService db = new DatabaseService();
            this.type = type;

            try
            {
                var dataset = db.GetAllData();

                if (dataset.Tables.Count > 0)
                {
                    foreach (DataTable table in dataset.Tables)
                    {
                        Console.WriteLine($"Loaded {table.TableName}: {table.Rows.Count} rows");
                    }

                    if(type == 1)
                    {
                        Nota_Pembelian report = new Nota_Pembelian();
                        report.SetDataSource(dataset);
                        report.SetParameterValue("h_transID", id);
                        crystalReportViewer1.ReportSource = report;
                    }
                    else if (type == 2)
                    {
                        OutputStock report = new OutputStock();
                        report.SetDataSource(db.GetDataByDateRange(DateTime.Now.AddMonths(-1),DateTime.Now));
                        crystalReportViewer1.ReportSource = report;
                    }
                    else if (type == 3)
                    {
                        HistoryPembelian report = new HistoryPembelian();
                        report.SetDataSource(db.GetDataByDateRange(DateTime.Now.AddDays(-7), DateTime.Now));
                        crystalReportViewer1.ReportSource = report;
                    }
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
                if (type == 1)
                {
                    Nota_Pembelian report = (Nota_Pembelian)crystalReportViewer1.ReportSource;
                    report.Close();
                    report.Dispose();
                }
                else if (type == 2)
                {
                    OutputStock report = (OutputStock)crystalReportViewer1.ReportSource;
                    report.Close();
                    report.Dispose();
                }
                else if (type == 3)
                {
                    HistoryPembelian report = (HistoryPembelian)crystalReportViewer1.ReportSource;
                    report.Close();
                    report.Dispose();
                }
            }
        }
    }
}
