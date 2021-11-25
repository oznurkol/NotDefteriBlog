using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NotDefteriBlog.Entity
{
    [Table("kategoriler")]
    public class Kategoriler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KID { get; set; }
        public string kate_adi { get; set; }
        [StringLength(500)]
        public string kate_acikla { get; set; }
        [StringLength(160)]
        public string kate_title { get; set; }
        public virtual List<Yazilar> Kate { get; set; }

    }
}