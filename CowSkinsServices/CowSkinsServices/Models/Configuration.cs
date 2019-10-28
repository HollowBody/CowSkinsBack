using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CowSkinsService.Models
{
    [Table("Configuration")]
    public partial class Configuration
    {
        public Configuration()
        {
            Skin = new HashSet<Skin>();
            SkinType = new HashSet<SkinType>();
        }

        [Key]
        public int IdConfiguration { get; set; }
        public string ConfigurationLabel { get; set; }
        public string HotKey { get; set; }

        public virtual ICollection<Skin> Skin { get; set; }
        public virtual ICollection<SkinType> SkinType { get; set; }
    }
}
