using App.Core.Models;

namespace App.Core.Interfaces
{
    public interface IAssignmentService
    {
        List<Assignment> GetAllAssignments();
        List<Assignment> GetActiveAssignments();
        List<Assignment> GetAssignmentsByEmployee(int employeeID);
        List<Assignment> GetAssignmentsByAsset(int assetID);
        void AssignAsset(Assignment assignment);
        void ReturnAsset(int assignmentID, DateTime returnDate, string remarks);
    }
}