namespace App.Core.Models
{
    public class Assignment
    {
        public int AssignmentID { get; set; }
        public int AssetID { get; set; }
        public string AssetName { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string AssignedBy { get; set; }
        public string Remarks { get; set; }
        public string Status => ReturnDate.HasValue ? "Returned" : "Active";
    }
}