namespace CowSkinsService.Models
{
    public class SortingAdvancedView
    {
        public int IdPallet { get; set; }
        public int? Sort { get; set; }
        public float? Brutto { get; set; }
        public float? Netto { get; set; }
        public float? Discount { get; set; }
        public string SkinTypeLabel { get; set; }
        public int? IdBatch { get; set; }
        public int? CurrentCount { get; set; }
        public int? MaximumCountSkin { get; set; }
        public int? IdSkin { get; set; }
    }
}
