using App.Core.Models;
using App.Core.Services;
using System.Windows.Forms.DataVisualization.Charting;

namespace App.WindowsApp.Forms
{
    public partial class AssetForm : Form
    {
        private readonly AssetService _assetService;
        private readonly CategoryService _categoryService;

        public AssetForm(string connString)
        {
            _assetService = new AssetService(connString);
            _categoryService = new CategoryService(connString);
            InitializeComponent();
            dgvAssets.ReadOnly = true;
            dgvAssets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAssets.MultiSelect = false;
            txtSearch.TextChanged += txtSearch_TextChanged;
            _ = LoadAssetsAsync();
        }

        private async Task LoadAssetsAsync()
        {
            SetButtonsEnabled(false);
            try
            {
                var assets = await _assetService.GetAllAssetsAsync();
                dgvAssets.DataSource = assets;
                LoadAssetChart(assets);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading assets: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetButtonsEnabled(true);
            }
        }

        private void LoadAssets()
        {
            var assets = _assetService.GetAllAssets();
            dgvAssets.DataSource = assets;
            LoadAssetChart(assets);
        }

        private void LoadAssetChart(List<Asset> assets)
        {
            // Purana chart remove karo
            var oldChart = this.Controls.Find("assetChart", true).FirstOrDefault();
            if (oldChart != null) oldChart.Parent.Controls.Remove(oldChart);

            var statusGroups = assets
                .GroupBy(a => a.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToList();

            if (statusGroups.Count == 0) return;

            var chart = new Chart();
            chart.Name = "assetChart";
            chart.Dock = DockStyle.Bottom;
            chart.Height = 220;
            chart.BackColor = Color.White;

            var chartArea = new ChartArea("AssetArea");
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
                Color.FromArgb(52, 168, 83),   // Available - green
                Color.FromArgb(66, 133, 244),  // Assigned - blue
                Color.FromArgb(251, 188, 5),   // Under Repair - amber
                Color.FromArgb(234, 67, 53)    // Other - red
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

            var legend = new Legend("StatusLegend");
            legend.Docking = Docking.Bottom;
            legend.Font = new Font("Segoe UI", 9f);
            chart.Legends.Add(legend);

            var title = new Title("Asset Status Distribution");
            title.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            chart.Titles.Add(title);

            this.Controls.Add(chart);
            chart.BringToFront();
        }

        private void SetButtonsEnabled(bool enabled)
        {
            btnAdd.Enabled = enabled;
            btnEdit.Enabled = enabled;
            btnDelete.Enabled = enabled;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
                _ = LoadAssetsAsync();
            else
                dgvAssets.DataSource = _assetService.SearchAssets(txtSearch.Text);
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new AssetDetailForm(_categoryService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _assetService.AddAsset(form.Asset);
                await LoadAssetsAsync();
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAssets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select Asset First!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var asset = (Asset)dgvAssets.SelectedRows[0].DataBoundItem;
            var form = new AssetDetailForm(_categoryService, asset);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _assetService.UpdateAsset(form.Asset);
                await LoadAssetsAsync();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAssets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select Asset First!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var asset = (Asset)dgvAssets.SelectedRows[0].DataBoundItem;
            var result = MessageBox.Show($"{asset.AssetName} Are you Sure you want to Delete?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _assetService.DeleteAsset(asset.AssetID);
                await LoadAssetsAsync();
            }
        }
    }
}