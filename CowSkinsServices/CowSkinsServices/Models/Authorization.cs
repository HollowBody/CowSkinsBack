using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CowSkinsService.Models
{
    [Table("Authorization")]
    public partial class Authorization
    {
        [Key]
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}
