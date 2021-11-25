using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NotDefteriBlog.Entity
{
    [Table("yazilar")]
    public class Yazilar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Yazi_ID { get; set; }
        public virtual Yazarlar Yazan { get; set; }
        [StringLength(100),Required]
        public string baslik { get; set; }
        [StringLength(50000),Required]
        public string icerik { get; set; }
        [Required]
        public DateTime tarih { get; set; }
        [DefaultValue("true"),Required]
        public bool onay { get; set; }
        [DefaultValue("true"), Required]
        public bool gizlimi { get; set; }
        [DefaultValue("0")]
        public byte oyacikmi { get; set; }
        [DefaultValue("0"),Required]
        public int oy { get; set; }
        [DefaultValue("0")]
        public byte yorum_turu { get; set; }
        [DefaultValue("true"),Required]
        public bool yorum_onay { get; set; }

        public virtual Kategoriler KAT { get; set; }
        public virtual List<Etiketler> Etiket { get; set; }

        public virtual List<Yorumlar> Yorum { get; set; }
        public virtual List<Favori> Fav { get; set; }
        public virtual List<Oylama> Oy { get; set; }
    }
}