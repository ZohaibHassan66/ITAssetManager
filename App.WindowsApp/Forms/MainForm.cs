using App.Core.Services;
using App.WindowsApp.Forms;

namespace App.WindowsApp
{
    public partial class MainForm : Form
    {
        private readonly AssetService _assetService;
        private readonly EmployeeService _employeeService;
        private readonly AssignmentService _assignmentService;
        private readonly string _connString;

        public MainForm(string connString)
        {
            _connString = connString;
            _assetService = new AssetService(connString);
            _employeeService = new EmployeeService(connString);
            _assignmentService = new AssignmentService(connString);

            InitializeComponent();
            ShowDashboard();
        }

        private void LoadForm(Form form)
        {
            pnlContent.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(form);
            form.Show();
            form.BringToFront();
        }

        private void ShowDashboard()
        {
            var dash = new DashboardView(_connString);
            LoadForm(dash);
            dash.LoadDashboard();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Dashboard";
            ShowDashboard();
        }

        private void btnAssets_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Assets";
            LoadForm(new AssetForm(_connString));
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Employees";
            LoadForm(new EmployeeForm(_connString));
        }

        private void btnAssignments_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Assignments";
            LoadForm(new AssignmentForm(_connString));
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Categories";
            LoadForm(new CategoryForm(_connString));
        }
    }
}
