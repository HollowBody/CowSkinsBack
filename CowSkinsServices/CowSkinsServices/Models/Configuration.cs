using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CowSkinsService.Models
{
    [Table("Configuration")]
    public partial class Configuration
    {
        [Key]
        public int ConfigurationID { get; set; }
        public string ConfigurationLabel { get; set; }
        public string HotKey { get; set; }
    }
}
