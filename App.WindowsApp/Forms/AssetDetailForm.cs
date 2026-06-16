using App.Core.Models;
using App.Core.Services;

namespace App.WindowsApp.Forms
{
    public partial class AssetDetailForm : Form
    {
        private readonly CategoryService _categoryService;
        public Asset Asset { get; private set; } = new();

        public AssetDetailForm(CategoryService categoryService, Asset? asset = null)
        {
            InitializeComponent();
            _categoryService = categoryService;
            LoadCategories();
            LoadStatuses();
            dtpPurchaseDate.Enabled = false;
            chkPurchaseDate.CheckedChanged += (s, e) =>
                dtpPurchaseDate.Enabled = chkPurchaseDate.Checked;

            if (asset != null)
            {
                Asset = asset;
                FillForm(asset);
            }
        }

        private void LoadCategories()
        {
            cmbCategory.DataSource = _categoryService.GetAllCategories();
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryID";
        }

        private void LoadStatuses()
        {
            cmbStatus.Items.AddRange(new string[]
            {
                "Available", "Assigned", "Under Repair", "Disposed"
            });
            cmbStatus.SelectedIndex = 0;
        }

        private void FillForm(Asset asset)
        {
            txtAssetName.Text = asset.AssetName;
            txtBrand.Text = asset.Brand;
            txtModel.Text = asset.Model;
            txtSerial.Text = asset.SerialNumber;
            txtNotes.Text = asset.Notes;
            cmbCategory.SelectedValue = asset.CategoryID;
            cmbStatus.SelectedItem = asset.Status;
            if (asset.PurchaseDate.HasValue)
            {
                chkPurchaseDate.Checked = true;
                dtpPurchaseDate.Value = asset.PurchaseDate.Value;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAssetName.Text))
            {
                MessageBox.Show("Write Asset Name Must!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Asset.AssetName = txtAssetName.Text.Trim();
            Asset.CategoryID = (int)cmbCategory.SelectedValue;
            Asset.Brand = txtBrand.Text.Trim();
            Asset.Model = txtModel.Text.Trim();
            Asset.SerialNumber = txtSerial.Text.Trim();
            Asset.Status = cmbStatus.SelectedItem.ToString();
            Asset.Notes = txtNotes.Text.Trim();
            Asset.PurchaseDate = chkPurchaseDate.Checked ? dtpPurchaseDate.Value.Date : null;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}