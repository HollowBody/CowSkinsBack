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
        public int IdCost { get; set; }
        public DateTime? CostDate { get; set; }
        public decimal? SkinPrice { get; set; }
        public int? IdTypeSkin { get; set; }
        public int? IdSort { get; set; }
        public int? IdBatch { get; set; }

        public virtual Sorts IdSortNavigation { get; set; }
        public virtual SkinType IdTypeSkinNavigation { get; set; }
    }
}
