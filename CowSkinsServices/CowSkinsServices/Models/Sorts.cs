using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CowSkinsService.Models
{
    [Table("Sorts")]
    public partial class Sorts
    {
        public Sorts()
        {
            CostJournal = new HashSet<CostJournal>();
            Skin = new HashSet<Skin>();
        }

        [Key]
        public int IdSort { get; set; }
        public string Sort { get; set; }

        public virtual ICollection<CostJournal> CostJournal { get; set; }
        public virtual ICollection<Skin> Skin { get; set; }
    }
}
