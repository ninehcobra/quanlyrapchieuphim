using GUI.DAO;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Markup;


namespace GUI.frmAdminUserControls
{
    public partial class RevenueUC : UserControl
    {
        private LiveCharts.WinForms.CartesianChart cartesianChart;
        public RevenueUC()
        {
            InitializeComponent();

            this.cartesianChart = new LiveCharts.WinForms.CartesianChart();
            this.SuspendLayout();
            this.cartesianChart.Location = new System.Drawing.Point(150, 99);
            this.cartesianChart.Name = "cartesianChart";
            this.cartesianChart.Size = new System.Drawing.Size(775, 342);
            this.cartesianChart.TabIndex = 0;
            this.Controls.Add(this.cartesianChart);
            this.ResumeLayout(false);
            this.PerformLayout();
            dtgvRevenue.Visible = false;


            LoadRevenue();
        }
        void LoadRevenue()
        {
            LoadMovieIntoCombobox(cboSelectMovie);
            LoadDateTimePickerRevenue();//Set "Từ ngày" & "Đến ngày ngày" về đầu tháng & cuối tháng
            LoadRevenue(cboSelectMovie.SelectedValue.ToString(), dtmFromDate.Value, dtmToDate.Value);
        }
        void LoadMovieIntoCombobox(ComboBox comboBox)
        {
            comboBox.DataSource = MovieDAO.GetListMovie();
            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "ID";
        }
        void LoadDateTimePickerRevenue()
        {
            dtmFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtmToDate.Value = dtmFromDate.Value.AddMonths(1).AddDays(-1);
        }
        void LoadRevenue(string idMovie, DateTime fromDate, DateTime toDate)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            DataTable data = RevenueDAO.GetRevenue(idMovie, fromDate, toDate);
            dtgvRevenue.DataSource = data;
            txtDoanhThu.Text = GetSumRevenue().ToString("c", culture);

            LoadChartRevenue(data);
        }

        void LoadChartRevenue(DataTable data)
        {
            cartesianChart.Series.Clear();
            cartesianChart.AxisX.Clear();
            cartesianChart.AxisY.Clear();

            var columnSeries = new ColumnSeries
            {
                Title = "Revenue",
                Values = new ChartValues<decimal>()
            };

            foreach (DataRow row in data.Rows)
            {
                string movieName = row["Tên phim"].ToString();
                decimal revenue = Convert.ToDecimal(row["Tiền vé"]);

                columnSeries.Values.Add(revenue);
            }

            cartesianChart.Series.Add(columnSeries);

            cartesianChart.AxisX.Add(new Axis
            {
                Title = "Movie",
                Labels = data.AsEnumerable().Select(row => row["Tên phim"].ToString()).ToArray()
            });

            cartesianChart.AxisY.Add(new Axis
            {
                Title = "Revenue",
                LabelFormatter = value => value.ToString("C", new CultureInfo("vi-VN"))
            });
        }

        decimal GetSumRevenue()
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in dtgvRevenue.Rows)
            {
                sum += Convert.ToDecimal(row.Cells["Tiền vé"].Value);
            }
            return sum;
        }

        private void btnShowRevenue_Click(object sender, EventArgs e)
        {
            LoadRevenue(cboSelectMovie.SelectedValue.ToString(), dtmFromDate.Value, dtmToDate.Value);
        }

        private void btnReportRevenue_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport(cboSelectMovie.SelectedValue.ToString(), dtmFromDate.Value, dtmToDate.Value);
            frm.ShowDialog();
        }
    }
}
