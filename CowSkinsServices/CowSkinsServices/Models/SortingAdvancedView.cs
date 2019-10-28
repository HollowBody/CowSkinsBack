namespace CowSkinsService.Models
{
    public class SortingAdvancedView
    {
        public int PalletID { get; set; }
        public int? Sort { get; set; }
        public float? Brutto { get; set; }
        public float? Netto { get; set; }
        public float? Discount { get; set; }
        public string SkinTypeLabel { get; set; }
        public int? BatchID { get; set; }
        public int? CurrentCount { get; set; }
        public int? MaximumCountSkin { get; set; }
        public int? SkinID { get; set; }
    }
}
