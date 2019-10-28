using System;

namespace CowSkinsService.Models
{
    public class CostJournalAdvancedView
    {
        public int IdCost { get; set; }
        public DateTime? CostDate { get; set; }
        public decimal? SkinPrice { get; set; }
        public int? IdTypeSkin { get; set; }
        public int? IdSort { get; set; }
        public int? IdBatch { get; set; }
        public string TypeSkinLabel { get; set; }
    }
}
