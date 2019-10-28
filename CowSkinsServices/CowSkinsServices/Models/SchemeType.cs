using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CowSkinsService.Models
{
    [Table("SchemeType")]
    public partial class SchemeType
    {
        [Key]
        public int SchemeTypeID { get; set; }
        public int? SchemeID { get; set; }
        public int? TypeSkinID { get; set; }
    }
}
