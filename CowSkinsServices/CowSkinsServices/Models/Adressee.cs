using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CowSkinsService.Models
{
    [Table("Adressee")]
    public partial class Adressee
    {
        public Adressee()
        {
            Send = new HashSet<Send>();
        }
        [Key]
        public int IdAdressee { get; set; }
        public string AdresseeLabel { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }

        public virtual ICollection<Send> Send { get; set; }
    }
}
