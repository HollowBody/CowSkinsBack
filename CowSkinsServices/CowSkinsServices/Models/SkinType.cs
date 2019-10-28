using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CowSkinsService.Models
{
    [Table("SkinType")]
    public partial class SkinType
    {
        [Key]
        public int TypeSkinID { get; set; }
        public string TypeSkinLabel { get; set; }
        public decimal? MinimumWeight { get; set; }
        public decimal? MaximumWeight { get; set; }
        public int? MaximumCountSkin { get; set; }
        public int? IdConfiguration { get; set; }

    }
}
