using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NotDefteriBlog.Entity
{
    [Table("oylama")]
    public class Oylama
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OYID { get; set; }
        public virtual Yazilar Yazi { get; set; }
        [StringLength(25),Required]
        public string ip { get; set; }
        [Required]
        public DateTime tarih { get; set; }
    }
}