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

        public int IdSchemeType { get; set; }
        public int? IdScheme { get; set; }
        public int? IdTypeSkin { get; set; }

        public virtual SortingScheme IdSchemeNavigation { get; set; }
        public virtual SkinType IdTypeSkinNavigation { get; set; }
    }
}
