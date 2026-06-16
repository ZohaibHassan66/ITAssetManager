using App.Core.Models;
using App.Core.Services;
namespace App.WindowsApp.Forms
{
    public partial class AssignmentDetailForm : Form
    {
        public Assignment Assignment { get; private set; } = new();
        private readonly AssetService _assetService;
        private readonly EmployeeService _employeeService;

        public AssignmentDetailForm(string connString)
        {
            _assetService = new AssetService(connString);
            _employeeService = new EmployeeService(connString);
            InitializeComponent();
            LoadDropdowns();
        }

        private void LoadDropdowns()
        {
            try
            {
                var assets = _assetService.GetAssetsByStatus("Available");
                cmbAsset.DataSource = assets;
                cmbAsset.DisplayMember = "AssetName";
                cmbAsset.ValueMember = "AssetID";

                var employees = _employeeService.GetAllEmployees();
                cmbEmployee.DataSource = employees;
                cmbEmployee.DisplayMember = "FullName";
                cmbEmployee.ValueMember = "EmployeeID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbAsset.SelectedItem == null || cmbEmployee.SelectedItem == null)
            {
                MessageBox.Show("Please select Asset and Employee.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Assignment.AssetID = (int)cmbAsset.SelectedValue;
            Assignment.EmployeeID = (int)cmbEmployee.SelectedValue;
            Assignment.AssignedDate = dtpDate.Value.Date;
            Assignment.AssignedBy = txtAssignedBy.Text.Trim();
            Assignment.Remarks = txtRemarks.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}