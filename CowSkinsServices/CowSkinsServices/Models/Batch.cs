using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CowSkinsService.Models
{
    [Table("Batch")]
    public partial class Batch
    {
        [Key]
        public int BatchID { get; set; }
        public DateTime? OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public string BatchStatus { get; set; }
        public int? SortingCount { get; set; }
        public int? DebitCount { get; set; }
        public int? ProviderID { get; set; }
        public int? SchemeID { get; set; }
    }
}
