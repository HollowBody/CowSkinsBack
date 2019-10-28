using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CowSkinsService.Models
{
    [Table("Adressee")]
    public partial class Adressee
    {
        [Key]
        public int AdresseeID { get; set; }
        public string AdresseeLabel { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
    }
}
