using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CowSkinsService.Models
{
    [Table("Batch")]
    public partial class Batch
    {
        public Batch()
        {
            Skin = new HashSet<Skin>();
        }

        [Key]
        public int IdBatch { get; set; }
        public DateTime? OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public string BatchStatus { get; set; }
        public int? SortingCount { get; set; }
        public int? DebitCount { get; set; }
        public int? IdProvider { get; set; }
        public int? IdScheme { get; set; }

        public virtual ICollection<Skin> Skin { get; set; }
        public virtual Provider IdProviderNavigation { get; set; }
        public virtual SortingScheme IdSchemeNavigation { get; set; }
    }
}
