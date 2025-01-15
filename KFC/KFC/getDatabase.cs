using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KFC
{
    public class DatabaseService
    {
        private readonly string[] _tables = {
            "cabang",
            "karyawan",
            "kategori",
            "menu",
            "diskon",
            "h_trans",
            "d_trans",
            "stock",
            "stock_history",
            "menu_ingredients"
        };

        public proyekPv GetAllData()
        {
            proyekPv dataSet = new proyekPv();
            dataSet.EnforceConstraints = false;
            try
            {
                using (MySqlConnection connection = koneksi.getConn())
                {

                    foreach (string table in _tables)
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT * FROM {table}", connection);
                        adapter.Fill(dataSet, table);
                    }
                }
                return dataSet;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
                throw;
            }
        }

        public proyekPv GetDataByDateRange(DateTime startDate, DateTime endDate)
        {
            var dataSet = new proyekPv();
            dataSet.EnforceConstraints = false;

            try
            {
                using (var connection = koneksi.getConn())
                {

                    foreach (string table in _tables)
                    {
                        using (var command = new MySqlCommand())
                        {
                            command.Connection = connection;
                            command.CommandText = $@"
                                SELECT * 
                                FROM {table} 
                                WHERE (created_date BETWEEN @startDate AND @endDate)
                                   OR (modified_date BETWEEN @startDate AND @endDate)";

                            command.Parameters.AddWithValue("@startDate", startDate);
                            command.Parameters.AddWithValue("@endDate", endDate);

                            using (var adapter = new MySqlDataAdapter(command))
                            {
                                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                                try
                                {
                                    adapter.Fill(dataSet, table);
                                }
                                catch (MySqlException ex)
                                {
                                    Console.WriteLine($"Error loading table {table}: {ex.Message}");
                                    continue;
                                }
                            }
                        }
                    }
                }

                return dataSet;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
                throw new DataException("Failed to retrieve data by date range", ex);
            }
        }
    }
}