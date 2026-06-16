using App.Core.Interfaces;
using App.Core.Models;
using Microsoft.Data.SqlClient;

namespace App.Core.Services
{
    public class AssetService : IAssetService
    {
        private readonly string _connectionString;

        public AssetService(string connString)
        {
            _connectionString = connString;
        }

        public List<Asset> GetAllAssets()
        {
            var list = new List<Asset>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string sql = @"SELECT a.AssetID, a.AssetName, a.CategoryID, c.CategoryName,
                                  a.Brand, a.Model, a.SerialNumber, a.PurchaseDate, a.Status, a.Notes
                           FROM Assets a
                           INNER JOIN Categories c ON a.CategoryID = c.CategoryID
                           ORDER BY a.AssetName";
            using var cmd = new SqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) list.Add(MapAsset(reader));
            return list;
        }

        // Async version — used by the main Assets list view for a responsive UI
        public async Task<List<Asset>> GetAllAssetsAsync()
        {
            var list = new List<Asset>();
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            string sql = @"SELECT a.AssetID, a.AssetName, a.CategoryID, c.CategoryName,
                                  a.Brand, a.Model, a.SerialNumber, a.PurchaseDate, a.Status, a.Notes
                           FROM Assets a
                           INNER JOIN Categories c ON a.CategoryID = c.CategoryID
                           ORDER BY a.AssetName";
            using var cmd = new SqlCommand(sql, conn);
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync()) list.Add(MapAsset(reader));
            return list;
        }

        public List<Asset> SearchAssets(string keyword)
        {
            var list = new List<Asset>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string sql = @"SELECT a.AssetID, a.AssetName, a.CategoryID, c.CategoryName,
                                  a.Brand, a.Model, a.SerialNumber, a.PurchaseDate, a.Status, a.Notes
                           FROM Assets a
                           INNER JOIN Categories c ON a.CategoryID = c.CategoryID
                           WHERE a.AssetName LIKE @kw OR a.Brand LIKE @kw
                           OR a.SerialNumber LIKE @kw OR c.CategoryName LIKE @kw
                           OR a.Model LIKE @kw OR a.Status LIKE @kw
                           ORDER BY a.AssetName";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) list.Add(MapAsset(reader));
            return list;
        }

        public List<Asset> GetAssetsByStatus(string status)
        {
            var list = new List<Asset>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string sql = @"SELECT a.AssetID, a.AssetName, a.CategoryID, c.CategoryName,
                                  a.Brand, a.Model, a.SerialNumber, a.PurchaseDate, a.Status, a.Notes
                           FROM Assets a
                           INNER JOIN Categories c ON a.CategoryID = c.CategoryID
                           WHERE a.Status = @status ORDER BY a.AssetName";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@status", status);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) list.Add(MapAsset(reader));
            return list;
        }

        public Asset GetAssetByID(int assetID)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string sql = @"SELECT a.AssetID, a.AssetName, a.CategoryID, c.CategoryName,
                                  a.Brand, a.Model, a.SerialNumber, a.PurchaseDate, a.Status, a.Notes
                           FROM Assets a
                           INNER JOIN Categories c ON a.CategoryID = c.CategoryID
                           WHERE a.AssetID = @id";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", assetID);
            using var reader = cmd.ExecuteReader();
            if (reader.Read()) return MapAsset(reader);
            return null;
        }

        public async Task<Asset> GetAssetByIDAsync(int assetID)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            string sql = @"SELECT a.AssetID, a.AssetName, a.CategoryID, c.CategoryName,
                                  a.Brand, a.Model, a.SerialNumber, a.PurchaseDate, a.Status, a.Notes
                           FROM Assets a
                           INNER JOIN Categories c ON a.CategoryID = c.CategoryID
                           WHERE a.AssetID = @id";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", assetID);
            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync()) return MapAsset(reader);
            return null;
        }

        public void AddAsset(Asset asset)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string sql = @"INSERT INTO Assets (AssetName, CategoryID, Brand, Model, SerialNumber, PurchaseDate, Status, Notes)
                           VALUES (@name, @catID, @brand, @model, @serial, @pDate, @status, @notes)";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", asset.AssetName);
            cmd.Parameters.AddWithValue("@catID", asset.CategoryID);
            cmd.Parameters.AddWithValue("@brand", (object)asset.Brand ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@model", (object)asset.Model ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@serial", (object)asset.SerialNumber ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@pDate", (object)asset.PurchaseDate ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@status", asset.Status ?? "Available");
            cmd.Parameters.AddWithValue("@notes", (object)asset.Notes ?? DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        public void UpdateAsset(Asset asset)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string sql = @"UPDATE Assets SET AssetName=@name, CategoryID=@catID, Brand=@brand,
                           Model=@model, SerialNumber=@serial, PurchaseDate=@pDate,
                           Status=@status, Notes=@notes WHERE AssetID=@id";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", asset.AssetName);
            cmd.Parameters.AddWithValue("@catID", asset.CategoryID);
            cmd.Parameters.AddWithValue("@brand", (object)asset.Brand ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@model", (object)asset.Model ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@serial", (object)asset.SerialNumber ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@pDate", (object)asset.PurchaseDate ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@status", asset.Status);
            cmd.Parameters.AddWithValue("@notes", (object)asset.Notes ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@id", asset.AssetID);
            cmd.ExecuteNonQuery();
        }

        public void DeleteAsset(int assetID)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            using var cmd1 = new SqlCommand(
                "DELETE FROM Assignments WHERE AssetID=@id", conn);
            cmd1.Parameters.AddWithValue("@id", assetID);
            cmd1.ExecuteNonQuery();

            using var cmd2 = new SqlCommand(
                "DELETE FROM Assets WHERE AssetID=@id", conn);
            cmd2.Parameters.AddWithValue("@id", assetID);
            cmd2.ExecuteNonQuery();
        }

        public void UpdateAssetStatus(int assetID, string status)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("UPDATE Assets SET Status=@status WHERE AssetID=@id", conn);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@id", assetID);
            cmd.ExecuteNonQuery();
        }

        private Asset MapAsset(SqlDataReader r) => new Asset
        {
            AssetID = r.GetInt32(0),
            AssetName = r.GetString(1),
            CategoryID = r.GetInt32(2),
            CategoryName = r.GetString(3),
            Brand = r.IsDBNull(4) ? "" : r.GetString(4),
            Model = r.IsDBNull(5) ? "" : r.GetString(5),
            SerialNumber = r.IsDBNull(6) ? "" : r.GetString(6),
            PurchaseDate = r.IsDBNull(7) ? null : r.GetDateTime(7),
            Status = r.GetString(8),
            Notes = r.IsDBNull(9) ? "" : r.GetString(9)
        };
    }
}