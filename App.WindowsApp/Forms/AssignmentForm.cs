using App.Core.Models;
using App.Core.Services;
using System.Windows.Forms.DataVisualization.Charting;

namespace App.WindowsApp.Forms
{
    public partial class AssignmentForm : Form
    {
        private readonly AssignmentService _assignmentService;
        private readonly string _connString;

        public AssignmentForm(string connString)
        {
            _connString = connString;
            _assignmentService = new AssignmentService(connString);
            InitializeComponent();
            LoadAssignments();
        }

        private void LoadAssignments()
        {
            try
            {
                var activeList = _assignmentService.GetActiveAssignments();
                dgvAssignments.DataSource = activeList;
                dgvAssignments.Columns["AssignmentID"].Visible = false;
                dgvAssignments.Columns["AssetID"].Visible = false;
                dgvAssignments.Columns["EmployeeID"].Visible = false;
                dgvAssignments.Columns["AssetName"].HeaderText = "Asset";
                dgvAssignments.Columns["EmployeeName"].HeaderText = "Employee";
                dgvAssignments.Columns["AssignedDate"].HeaderText = "Assigned On";
                dgvAssignments.Columns["ReturnDate"].HeaderText = "Returned On";
                dgvAssignments.Columns["AssignedBy"].HeaderText = "Assigned By";

                // Chart ke liye ALL assignments lo taake Active + Returned dono dikhein
                var allAssignments = _assignmentService.GetAllAssignments();
                LoadAssignmentChart(allAssignments);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAssignmentChart(List<Assignment> assignments)
        {
            // Purana chart remove karo
            var oldChart = this.Controls.Find("assignmentChart", true).FirstOrDefault();
            if (oldChart != null) oldChart.Parent.Controls.Remove(oldChart);

            var statusGroups = assignments
                .GroupBy(a => a.ReturnDate.HasValue ? "Returned" : "Active")
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToList();

            if (statusGroups.Count == 0) return;

            var chart = new Chart();
            chart.Name = "assignmentChart";
            chart.Dock = DockStyle.Bottom;
            chart.Height = 220;
            chart.BackColor = Color.White;

            var chartArea = new ChartArea("AssignmentArea");
            chartArea.BackColor = Color.White;
            chart.ChartAreas.Add(chartArea);

            var series = new Series("Status");
            series.ChartType = SeriesChartType.Pie;
            series["PieLabelStyle"] = "Outside";
            series["PieLineColor"] = "Black";
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "{0} ({P0})";

            var colors = new[]
            {
                Color.FromArgb(66, 133, 244),  // Active - blue
                Color.FromArgb(52, 168, 83),   // Returned - green
            };

            int i = 0;
            foreach (var group in statusGroups)
            {
                var point = new DataPoint();
                point.SetValueY(group.Count);
                point.Label = $"{group.Status}\n{group.Count}";
                point.LegendText = $"{group.Status} ({group.Count})";
                point.Color = colors[i % colors.Length];
                series.Points.Add(point);
                i++;
            }

            chart.Series.Add(series);

            var legend = new Legend("AssignmentLegend");
            legend.Docking = Docking.Bottom;
            legend.Font = new Font("Segoe UI", 9f);
            chart.Legends.Add(legend);

            var title = new Title("Assignment Status Distribution");
            title.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            chart.Titles.Add(title);

            this.Controls.Add(chart);
            chart.BringToFront();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            var form = new AssignmentDetailForm(_connString);
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _assignmentService.AssignAsset(form.Assignment);
                    LoadAssignments();
                    MessageBox.Show("Asset assigned successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dgvAssignments.CurrentRow?.DataBoundItem is not Assignment selected)
            {
                MessageBox.Show("Please select an assignment.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (selected.ReturnDate.HasValue)
            {
                MessageBox.Show("This asset is already returned.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var confirm = MessageBox.Show(
                $"Return '{selected.AssetName}' from {selected.EmployeeName}?",
                "Confirm Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _assignmentService.ReturnAsset(
                        selected.AssignmentID, DateTime.Today, "Returned");
                    LoadAssignments();
                    MessageBox.Show("Asset returned successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAssignments();
        }
    }
}