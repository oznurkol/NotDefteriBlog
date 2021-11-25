using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NotDefteriBlog.Entity
{
    [Table("etkiketler")]
    public class Etiketler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int E_ID { get; set; }

        [StringLength(50),Required]
        public string etiket { get; set; }
        [Required]
        public virtual Yazilar Yazi { get; set; }
    }
}