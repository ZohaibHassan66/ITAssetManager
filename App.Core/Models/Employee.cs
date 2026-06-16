namespace App.Core.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; } = true;

        public override string ToString() => FullName;
    }
}