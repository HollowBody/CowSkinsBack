using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CowSkinsService.Models
{
    [Table("Provider")]
    public partial class Provider
    {
        [Key]
        public int ProviderID { get; set; }
        public string ProviderLabel { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public decimal? Discount { get; set; }
    }
}
