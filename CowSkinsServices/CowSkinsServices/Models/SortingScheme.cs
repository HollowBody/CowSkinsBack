using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CowSkinsService.Models
{
    [Table("SkinType")]
    public partial class SortingScheme
    {
        public SortingScheme()
        {
            Batch = new HashSet<Batch>();
            SchemeType = new HashSet<SchemeType>();
        }

        [Key]
        public int IdScheme { get; set; }
        public string SchemeLabel { get; set; }

        public virtual ICollection<Batch> Batch { get; set; }
        public virtual ICollection<SchemeType> SchemeType { get; set; }
    }
}
