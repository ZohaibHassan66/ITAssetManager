using App.Core.Models;
using Microsoft.Data.SqlClient;

namespace App.Core.Services
{
    public class CategoryService
    {
        private readonly string _connectionString;

        public CategoryService(string connString)
        {
            _connectionString = connString;
        }

        public List<Category> GetAllCategories()
        {
            var list = new List<Category>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("SELECT CategoryID, CategoryName FROM Categories ORDER BY CategoryName", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(new Category { CategoryID = reader.GetInt32(0), CategoryName = reader.GetString(1) });
            return list;
        }

        public void AddCategory(string categoryName)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand(
                "INSERT INTO Categories (CategoryName) VALUES (@name)", conn);
            cmd.Parameters.AddWithValue("@name", categoryName);
            cmd.ExecuteNonQuery();
        }

        public void DeleteCategory(int categoryId)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            
            using var updateCmd = new SqlCommand(
                "UPDATE Assets SET CategoryID = NULL WHERE CategoryID = @id", conn);
            updateCmd.Parameters.AddWithValue("@id", categoryId);
            updateCmd.ExecuteNonQuery();

            
            using var deleteCmd = new SqlCommand(
                "DELETE FROM Categories WHERE CategoryID = @id", conn);
            deleteCmd.Parameters.AddWithValue("@id", categoryId);
            deleteCmd.ExecuteNonQuery();
        }
    }
}