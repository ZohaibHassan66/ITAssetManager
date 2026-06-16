namespace App.Core.Models
{
    public class DashboardStats
    {
        public int TotalAssets { get; set; }
        public int AvailableAssets { get; set; }
        public int AssignedAssets { get; set; }
        public int UnderRepairAssets { get; set; }
        public int TotalEmployees { get; set; }
        public int ActiveAssignments { get; set; }
    }
}