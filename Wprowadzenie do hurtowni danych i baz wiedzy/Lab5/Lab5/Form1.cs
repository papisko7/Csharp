using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        private const string CONN_STRING_SCRIPT = @"Data Source=192.168.137.216\PRVSQL16; Initial Catalog=HurtowniaLabKK; User ID=sa;  Password=sql;";
        private const string COUNT_ALL_RECORDS_SCRIPT = @"SELECT COUNT(*) AS RecordCount FROM ZoneAlarmLog";
        private const string SHOW_ALL_RECORDS_SCRIPT = @"SELECT * FROM ZoneAlarmLog";
        private const string COUNT_BY_TYPE_SCRIPT = @"SELECT Event, COUNT(*) AS C FROM ZoneAlarmLog GROUP BY Event ORDER BY C DESC";
        private const string COUNT_WHEN_MOST_EVENTS_SCRIPT = @"SELECT TOP 1 
                   COUNT(*) AS HowManyEvents, 
                   CONVERT(VARCHAR(10), Date, 105) AS WhenMostEvents
                   FROM ZoneAlarmLog 
                   GROUP BY Date 
                   ORDER BY HowManyEvents DESC";

        public Form1()
        {
            InitializeComponent();
        }

        private void ShowAllBtn_Click(object sender, EventArgs e)
        {
            ShowData(SHOW_ALL_RECORDS_SCRIPT);
        }
        
        private void CountAllBtn_Click(object sender, EventArgs e)
        {
            ShowData(COUNT_ALL_RECORDS_SCRIPT);
        }

        private void CountByTypeBtn_Click(object sender, EventArgs e)
        {
            ShowData(COUNT_BY_TYPE_SCRIPT);
        }

        private void FilterByDateBtn_Click(object sender, EventArgs e)
        {
            var fromDateTimeFormat = FromDateTimePicker.Value.ToString("yyyy-MM-dd HH:mm:ss");
            var toDateTimeFormat = ToDateTimePicker.Value.ToString("yyyy-MM-dd HH:mm:ss");
            var filterByDateScript = @"SELECT * FROM ZoneAlarmLog " + 
                                     "WHERE CONVERT(VARCHAR(10), Date, 120) + ' ' + CONVERT(VARCHAR(8), Time, 108) " + 
                                     "BETWEEN '" + fromDateTimeFormat + "' AND '" + toDateTimeFormat + "'";
            
            ShowData(filterByDateScript);
        }

        private void ShowChartsBtn_Click(object sender, EventArgs e)
        {
            new ChartForm().Show();
        }
        
        private void WhenMostEventsBtn_Click(object sender, EventArgs e)
        {
            ShowData(COUNT_WHEN_MOST_EVENTS_SCRIPT);
        }

        private void FinishBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ShowData(string sqlQuery)
        {
            try
            {
                using (var dataAdapter = new SqlDataAdapter(sqlQuery,
                           CONN_STRING_SCRIPT))
                {
                    var dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Database error {e.Message}"
                    , @"Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}