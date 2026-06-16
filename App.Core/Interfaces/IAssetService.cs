using App.Core.Models;

namespace App.Core.Interfaces
{
    public interface IAssetService
    {
        List<Asset> GetAllAssets();
        Task<List<Asset>> GetAllAssetsAsync();
        List<Asset> SearchAssets(string keyword);
        List<Asset> GetAssetsByStatus(string status);
        Asset GetAssetByID(int assetID);
        Task<Asset> GetAssetByIDAsync(int assetID);
        void AddAsset(Asset asset);
        void UpdateAsset(Asset asset);
        void DeleteAsset(int assetID);
        void UpdateAssetStatus(int assetID, string status);
    }
}