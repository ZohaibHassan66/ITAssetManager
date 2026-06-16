using App.Core.Interfaces;
using App.Core.Models;
using Microsoft.Data.SqlClient;

namespace App.Core.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly string _connectionString;

        public AssignmentService(string connString)
        {
            _connectionString = connString;
        }

        public List<Assignment> GetAllAssignments()
        {
            var list = new List<Assignment>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string sql = @"SELECT a.AssignmentID, a.AssetID, ast.AssetName,
                                  a.EmployeeID, e.FullName,
                                  a.AssignedDate, a.ReturnDate, a.AssignedBy, a.Remarks
                           FROM Assignments a
                           INNER JOIN Assets ast ON a.AssetID = ast.AssetID
                           INNER JOIN Employees e ON a.EmployeeID = e.EmployeeID
                           ORDER BY a.AssignedDate DESC";
            using var cmd = new SqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) list.Add(MapAssignment(reader));
            return list;
        }

        public List<Assignment> GetActiveAssignments()
        {
            var list = new List<Assignment>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string sql = @"SELECT a.AssignmentID, a.AssetID, ast.AssetName,
                                  a.EmployeeID, e.FullName,
                                  a.AssignedDate, a.ReturnDate, a.AssignedBy, a.Remarks
                           FROM Assignments a
                           INNER JOIN Assets ast ON a.AssetID = ast.AssetID
                           INNER JOIN Employees e ON a.EmployeeID = e.EmployeeID
                           WHERE a.ReturnDate IS NULL
                           ORDER BY a.AssignedDate DESC";
            using var cmd = new SqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) list.Add(MapAssignment(reader));
            return list;
        }

        public List<Assignment> GetAssignmentsByEmployee(int employeeID)
        {
            var list = new List<Assignment>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string sql = @"SELECT a.AssignmentID, a.AssetID, ast.AssetName,
                                  a.EmployeeID, e.FullName,
                                  a.AssignedDate, a.ReturnDate, a.AssignedBy, a.Remarks
                           FROM Assignments a
                           INNER JOIN Assets ast ON a.AssetID = ast.AssetID
                           INNER JOIN Employees e ON a.EmployeeID = e.EmployeeID
                           WHERE a.EmployeeID = @empID
                           ORDER BY a.AssignedDate DESC";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@empID", employeeID);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) list.Add(MapAssignment(reader));
            return list;
        }

        public List<Assignment> GetAssignmentsByAsset(int assetID)
        {
            var list = new List<Assignment>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string sql = @"SELECT a.AssignmentID, a.AssetID, ast.AssetName,
                                  a.EmployeeID, e.FullName,
                                  a.AssignedDate, a.ReturnDate, a.AssignedBy, a.Remarks
                           FROM Assignments a
                           INNER JOIN Assets ast ON a.AssetID = ast.AssetID
                           INNER JOIN Employees e ON a.EmployeeID = e.EmployeeID
                           WHERE a.AssetID = @assetID
                           ORDER BY a.AssignedDate DESC";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@assetID", assetID);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) list.Add(MapAssignment(reader));
            return list;
        }

        public void AssignAsset(Assignment assignment)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string sql = @"INSERT INTO Assignments (AssetID, EmployeeID, AssignedDate, AssignedBy, Remarks)
                           VALUES (@assetID, @empID, @date, @by, @remarks)";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@assetID", assignment.AssetID);
            cmd.Parameters.AddWithValue("@empID", assignment.EmployeeID);
            cmd.Parameters.AddWithValue("@date", assignment.AssignedDate);
            cmd.Parameters.AddWithValue("@by", (object)assignment.AssignedBy ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@remarks", (object)assignment.Remarks ?? DBNull.Value);
            cmd.ExecuteNonQuery();

            using var cmd2 = new SqlCommand("UPDATE Assets SET Status='Assigned' WHERE AssetID=@id", conn);
            cmd2.Parameters.AddWithValue("@id", assignment.AssetID);
            cmd2.ExecuteNonQuery();
        }

        public void ReturnAsset(int assignmentID, DateTime returnDate, string remarks)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            int assetID = 0;
            using (var cmd = new SqlCommand("SELECT AssetID FROM Assignments WHERE AssignmentID=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", assignmentID);
                assetID = (int)cmd.ExecuteScalar();
            }

            string sql = "UPDATE Assignments SET ReturnDate=@rDate, Remarks=@remarks WHERE AssignmentID=@id";
            using var cmd2 = new SqlCommand(sql, conn);
            cmd2.Parameters.AddWithValue("@rDate", returnDate);
            cmd2.Parameters.AddWithValue("@remarks", (object)remarks ?? DBNull.Value);
            cmd2.Parameters.AddWithValue("@id", assignmentID);
            cmd2.ExecuteNonQuery();

            using var cmd3 = new SqlCommand("UPDATE Assets SET Status='Available' WHERE AssetID=@id", conn);
            cmd3.Parameters.AddWithValue("@id", assetID);
            cmd3.ExecuteNonQuery();
        }

        private Assignment MapAssignment(SqlDataReader r) => new Assignment
        {
            AssignmentID = r.GetInt32(0),
            AssetID = r.GetInt32(1),
            AssetName = r.GetString(2),
            EmployeeID = r.GetInt32(3),
            EmployeeName = r.GetString(4),
            AssignedDate = r.GetDateTime(5),
            ReturnDate = r.IsDBNull(6) ? null : r.GetDateTime(6),
            AssignedBy = r.IsDBNull(7) ? "" : r.GetString(7),
            Remarks = r.IsDBNull(8) ? "" : r.GetString(8)
        };
    }
}