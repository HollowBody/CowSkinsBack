using System;

namespace CowSkinsService.Models
{
    public class CostJournalAdvancedView
    {
        public int CostID { get; set; }
        public DateTime? CostDate { get; set; }
        public decimal? SkinPrice { get; set; }
        public int? TypeSkinID { get; set; }
        public int? SortID { get; set; }
        public int? BatchID { get; set; }
        public string TypeSkinLabel { get; set; }
    }
}
