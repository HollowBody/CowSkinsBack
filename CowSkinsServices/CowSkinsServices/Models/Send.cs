using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CowSkinsService.Models
{
    [Table("Send")]
    public partial class Send
    {
        [Key]
        public int SendID { get; set; }
        public int? AdresseeID { get; set; }
        public int? PalletID { get; set; }
        public DateTime? SendDate { get; set; }
    }
}
