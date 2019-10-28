using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CowSkinsService.Models
{
    [Table("CostJournal")]
    public partial class CostJournal
    {
        [Key]
        public int CostID { get; set; }
        public DateTime? CostDate { get; set; }
        public decimal? SkinPrice { get; set; }
        public int? TypeSkinID { get; set; }
        public int? SortID { get; set; }
        public int? BatchID { get; set; }
    }
}
