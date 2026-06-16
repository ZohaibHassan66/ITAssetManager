using App.Core.Models;
using App.Core.Services;
namespace App.WindowsApp.Forms
{
    public partial class EmployeeForm : Form
    {
        private readonly EmployeeService _employeeService;

        public EmployeeForm(string connString)
        {
            _employeeService = new EmployeeService(connString);
            InitializeComponent();
            txtSearch.TextChanged += txtSearch_TextChanged;
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                var list = string.IsNullOrEmpty(keyword)
                    ? _employeeService.GetAllEmployees()
                    : _employeeService.SearchEmployees(keyword);
                dgvEmployees.DataSource = list;
                dgvEmployees.Columns["EmployeeID"].Visible = false;
                dgvEmployees.Columns["IsActive"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new EmployeeDetailForm(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _employeeService.AddEmployee(form.Employee);
                LoadEmployees();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow?.DataBoundItem is not Employee selected)
            {
                MessageBox.Show("Please select an employee.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var form = new EmployeeDetailForm(selected);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _employeeService.UpdateEmployee(form.Employee);
                LoadEmployees();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow?.DataBoundItem is not Employee selected)
            {
                MessageBox.Show("Please select an employee.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var confirm = MessageBox.Show(
                $"Delete '{selected.FullName}'?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                _employeeService.DeleteEmployee(selected.EmployeeID);
                LoadEmployees();
            }
        }
    }
}