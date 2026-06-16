namespace App.Core.Models
{
    public class Asset
    {
        public int AssetID { get; set; }
        public string AssetName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }

        public override string ToString() => AssetName;
    }
}