namespace KRSClientApplication.Models
{
    public class CostingAdvancedView
    {
        public int SkinID { get; set; }
        public int? SortID { get; set; }
        public float? Brutto { get; set; }
        public float? Netto { get; set; }
        public float? Discount { get; set; }
        public int? BatchID { get; set; }
        public int? TypeSkinID { get; set; }
        public int? ConfigurationID { get; set; }
        public int? PalletID { get; set; }
        public string SkinTypeLabel { get; set; }
    }
}
