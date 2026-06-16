using App.Core.Models;

namespace App.WindowsApp.Forms
{
    public partial class EmployeeDetailForm : Form
    {
        public Employee Employee { get; private set; }

        public EmployeeDetailForm(Employee existing)
        {
            InitializeComponent();

            Employee = existing ?? new Employee();

            if (existing != null)
            {
                txtFullName.Text = existing.FullName;
                txtDepartment.Text = existing.Department;
                txtContact.Text = existing.ContactNumber;
                txtEmail.Text = existing.Email;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Full Name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Employee.FullName = txtFullName.Text.Trim();
            Employee.Department = txtDepartment.Text.Trim();
            Employee.ContactNumber = txtContact.Text.Trim();
            Employee.Email = txtEmail.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }
    }
}