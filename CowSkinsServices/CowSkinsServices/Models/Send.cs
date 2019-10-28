using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CowSkinsService.Models
{
    [Table("SchemeType")]
    public partial class Send
    {
        [Key]
        public int IdSend { get; set; }
        public int? IdAdressee { get; set; }
        public int? IdPallet { get; set; }
        public DateTime? SendDate { get; set; }

        public virtual Adressee IdAdresseeNavigation { get; set; }
        public virtual Pallet IdPalletNavigation { get; set; }
    }
}
