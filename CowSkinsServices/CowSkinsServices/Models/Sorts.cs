using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CowSkinsService.Models
{
    [Table("Sorts")]
    public partial class Sorts
    {
        [Key]
        public int SortID { get; set; }
        public string Sort { get; set; }
    }
}
