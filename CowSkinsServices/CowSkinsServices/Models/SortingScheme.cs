using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CowSkinsService.Models
{
    [Table("SortingScheme")]
    public partial class SortingScheme
    {
        [Key]
        public int SchemeID { get; set; }
        public string SchemeLabel { get; set; }
    }
}
