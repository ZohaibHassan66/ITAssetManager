using App.Core.Interfaces;
using App.Core.Models;
using Microsoft.Data.SqlClient;

namespace App.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly string _connectionString;

        public EmployeeService(string connString)
        {
            _connectionString = connString;
        }

        public List<Employee> GetAllEmployees()
        {
            var list = new List<Employee>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string sql = "SELECT EmployeeID, FullName, Department, ContactNumber, Email, IsActive FROM Employees WHERE IsActive=1 ORDER BY FullName";
            using var cmd = new SqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) list.Add(MapEmployee(reader));
            return list;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            var list = new List<Employee>();
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            string sql = "SELECT EmployeeID, FullName, Department, ContactNumber, Email, IsActive FROM Employees WHERE IsActive=1 ORDER BY FullName";
            using var cmd = new SqlCommand(sql, conn);
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync()) list.Add(MapEmployee(reader));
            return list;
        }

        public List<Employee> SearchEmployees(string keyword)
        {
            var list = new List<Employee>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string sql = @"SELECT EmployeeID, FullName, Department, ContactNumber, Email, IsActive
                           FROM Employees
                           WHERE IsActive=1 AND (FullName LIKE @kw OR Department LIKE @kw 
                           OR Email LIKE @kw OR ContactNumber LIKE @kw)
                           ORDER BY FullName";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) list.Add(MapEmployee(reader));
            return list;
        }

        public async Task<List<Employee>> SearchEmployeesAsync(string keyword)
        {
            var list = new List<Employee>();
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            string sql = @"SELECT EmployeeID, FullName, Department, ContactNumber, Email, IsActive
                           FROM Employees
                           WHERE IsActive=1 AND (FullName LIKE @kw OR Department LIKE @kw 
                           OR Email LIKE @kw OR ContactNumber LIKE @kw)
                           ORDER BY FullName";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync()) list.Add(MapEmployee(reader));
            return list;
        }

        public Employee GetEmployeeByID(int employeeID)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string sql = "SELECT EmployeeID, FullName, Department, ContactNumber, Email, IsActive FROM Employees WHERE EmployeeID=@id";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", employeeID);
            using var reader = cmd.ExecuteReader();
            if (reader.Read()) return MapEmployee(reader);
            return null;
        }

        public void AddEmployee(Employee emp)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string sql = "INSERT INTO Employees (FullName, Department, ContactNumber, Email, IsActive) VALUES (@name, @dept, @phone, @email, 1)";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", emp.FullName);
            cmd.Parameters.AddWithValue("@dept", (object)emp.Department ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@phone", (object)emp.ContactNumber ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@email", (object)emp.Email ?? DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        public void UpdateEmployee(Employee emp)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string sql = "UPDATE Employees SET FullName=@name, Department=@dept, ContactNumber=@phone, Email=@email WHERE EmployeeID=@id";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", emp.FullName);
            cmd.Parameters.AddWithValue("@dept", (object)emp.Department ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@phone", (object)emp.ContactNumber ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@email", (object)emp.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@id", emp.EmployeeID);
            cmd.ExecuteNonQuery();
        }

        public void DeleteEmployee(int employeeID)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("UPDATE Employees SET IsActive=0 WHERE EmployeeID=@id", conn);
            cmd.Parameters.AddWithValue("@id", employeeID);
            cmd.ExecuteNonQuery();
        }

        private Employee MapEmployee(SqlDataReader r) => new Employee
        {
            EmployeeID = r.GetInt32(0),
            FullName = r.GetString(1),
            Department = r.IsDBNull(2) ? "" : r.GetString(2),
            ContactNumber = r.IsDBNull(3) ? "" : r.GetString(3),
            Email = r.IsDBNull(4) ? "" : r.GetString(4),
            IsActive = r.GetBoolean(5)
        };
    }
}