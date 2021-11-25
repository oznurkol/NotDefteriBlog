using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NotDefteriBlog.Entity
{
    [Table("favoriler")]
    public class Favori
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Fav_ID { get; set; }
        [Required]
        public DateTime tarih { get; set; }
        public virtual Yazarlar Yazar { get; set; }
        public virtual Yazilar Yazi{get; set;}

    }
}