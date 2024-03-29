﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CowSkinsService.Models
{
    [Table("Skin")]
    public partial class Skin
    {
        [Key]
        public int SkinID { get; set; }
        public int? SortID { get; set; }
        public float? Brutto { get; set; }
        public float? Netto { get; set; }
        public float? Discount { get; set; }
        public int? BatchID { get; set; }
        public int? TypeSkinID { get; set; }
        public int? ConfigurationID { get; set; }
        public int? PalletID { get; set; }
    }
}
