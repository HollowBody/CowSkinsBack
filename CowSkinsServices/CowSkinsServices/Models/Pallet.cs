using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CowSkinsService.Models
{
    [Table("Pallet")]
    public partial class Pallet
    {
        [Key]
        public int PalletID { get; set; }
        public DateTime? OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public DateTime? SendingDate { get; set; }
        public string Status { get; set; }
        public int? CurrentCountSkins { get; set; }
        public int? TypeSkinID { get; set; }
    }
}
