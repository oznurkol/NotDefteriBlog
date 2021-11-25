using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NotDefteriBlog.Entity
{
    [Table("yorum_yanit")]
    public class YorumYanit
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int YanitID { get; set; }
        public virtual Yorumlar Y { get; set; }
        [StringLength(3000), Required]
        public string yanit_icerik { get; set; }
        [Required]
        public DateTime tarih { get; set; }
        [DefaultValue("true"), Required]
        public string ad { get; set; }
        [StringLength(150), Required]
        public string email { get; set; }
        [StringLength(150)]
        public string webpage { get; set; }
    }
}