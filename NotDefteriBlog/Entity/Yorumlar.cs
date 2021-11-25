using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NotDefteriBlog.Entity
{
    [Table("yorumlar")]
    public class Yorumlar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int YorumID { get; set; }
        [Required]
        public virtual Yazilar ID { get; set; }
        [StringLength(3000), Required]
        public string yorum_icerik { get; set; }
        [Required]
        public DateTime tarih { get; set; }
        [DefaultValue("true"), Required]
        public bool onay { get; set; }
        [StringLength(150),Required]
        public string ad { get; set; }
        [StringLength(150), Required]
        public string email { get; set; }
        [StringLength(150)]
        public string webpage { get; set; }

        public virtual List<YorumYanit> Yanit { get; set; }


    }
}