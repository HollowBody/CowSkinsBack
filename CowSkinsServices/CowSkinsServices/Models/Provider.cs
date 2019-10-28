using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CowSkinsService.Models
{
    [Table("Provider")]
    public partial class Provider
    {
        public Provider()
        {
            Batch = new HashSet<Batch>();
        }

        [Key]
        public int IdProvider { get; set; }
        public string ProviderLabel { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public decimal? Discount { get; set; }

        public virtual ICollection<Batch> Batch { get; set; }
    }
}
