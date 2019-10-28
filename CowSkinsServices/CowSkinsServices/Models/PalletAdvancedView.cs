using System;

namespace CowSkinsService.Models
{
    public class PalletAdvancedView   
    {
        public int PalletID { get; set; }
        public DateTime? OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public DateTime? SendingDate { get; set; }
        public string Status { get; set; }
        public int? CurrentCountSkins { get; set; }
        public int? TypeSkinID { get; set; }
        public string SkinTypeLabel { get; set; }
    }
}
