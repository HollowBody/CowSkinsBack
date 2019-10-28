namespace KRSClientApplication.Models
{
    public class CostingSelect
    {
        public int IdSkin { get; set; }
        public int? IdSort { get; set; }
        public float? Brutto { get; set; }
        public float? Netto { get; set; }
        public float? Discount { get; set; }
        public int? IdBatch { get; set; }
        public int? IdTypeSkin { get; set; }
        public int? IdConfiguration { get; set; }
        public int? IdPallet { get; set; }
        public string SkinTypeLabel { get; set; }
    }
}
