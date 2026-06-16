using App.Core.Services;

namespace App.WindowsApp.Forms
{
    public partial class DashboardView : Form
    {
        private readonly AssetService _assetService;
        private readonly EmployeeService _employeeService;
        private readonly AssignmentService _assignmentService;

        public DashboardView(string connString)
        {
            InitializeComponent();
            _assetService = new AssetService(connString);
            _employeeService = new EmployeeService(connString);
            _assignmentService = new AssignmentService(connString);
        }

        public void LoadDashboard()
        {
            try
            {
                var assets = _assetService.GetAllAssets();
                var employees = _employeeService.GetAllEmployees();
                var assignments = _assignmentService.GetActiveAssignments();

                lblVal1.Text = assets.Count.ToString();
                lblVal2.Text = assets.FindAll(a => a.Status == "Available").Count.ToString();
                lblVal3.Text = assets.FindAll(a => a.Status == "Assigned").Count.ToString();
                lblVal4.Text = assets.FindAll(a => a.Status == "Under Repair").Count.ToString();
                lblVal5.Text = employees.Count.ToString();
                lblVal6.Text = assignments.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dashboard Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
