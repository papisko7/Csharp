using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab5
{
    public partial class ChartForm : Form
    {
        private const string CONN_STRING_SCRIPT = @"Data Source=192.168.137.216\PRVSQL16; Initial Catalog=HurtowniaLabKK; User ID=sa;  Password=sql;";
        private const string SQL = "SELECT Event, COUNT(*) AS HM FROM ZoneAlarmLog GROUP BY Event";
        
        public ChartForm()
        {
            InitializeComponent();
            Text = @"Charts"; 
            LoadCharts(); 
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        private void LoadCharts()
        {
            try
            {
                using (var adapter = new SqlDataAdapter(SQL, CONN_STRING_SCRIPT))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    
                    chart1.Series.Clear(); 
                    var seriesBar = chart1.Series.Add("Event count by type");
                    seriesBar.ChartType = SeriesChartType.Column; 
                    seriesBar.XValueMember = "Event"; 
                    seriesBar.YValueMembers = "HM"; 
                    chart1.DataSource = dt;
                    chart1.DataBind();
                    
                    chart2.Series.Clear();
                    var seriesPie = chart2.Series.Add("Event distribution");
                    seriesPie.ChartType = SeriesChartType.Pie; 
                    seriesPie.XValueMember = "Event";
                    seriesPie.YValueMembers = "HM";
                    seriesPie.IsValueShownAsLabel = true; 
                    chart2.DataSource = dt;
                    chart2.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Chart error: " + ex.Message,
                    @"Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}