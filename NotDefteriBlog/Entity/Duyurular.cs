using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NotDefteriBlog.Entity
{
    [Table("duyurular")]
    public class Duyurular
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int duyuru_id { get; set; }

        [StringLength(75), Required]
        public string baslik { get; set; }
        [Required]
        public string icerik { get; set; }

        public DateTime tarih { get; set; }
    }
}