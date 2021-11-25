using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NotDefteriBlog.Entity
{
    [Table("system")]
    public class System_
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), DefaultValue("1")]
        public int ID { get; set; }
        [DefaultValue("true"),Required]
        public bool uyealim { get; set; }
        [DefaultValue("true"),Required]
        public bool uyegiris { get; set; }
        public string bannerresim { get; set; }

        public string hakkimizda { get; set; }
        public string sitebaslik { get; set; }
        public string desc { get; set; }
        public string copy { get; set; }
        public string keyw { get; set; }
        /*[DefaultValue("true"), Required]
        public bool yorumgosterim { get; set; }
        [DefaultValue("false"), Required]
        public bool yorumalim { get; set; }
        [DefaultValue("false"), Required]
        public bool gallerisistemi { get; set; }
        [DefaultValue("false"), Required]
        public bool duyurusistemi { get; set; }*/
        [DefaultValue("false"), Required]
        public bool oysistemi { get; set; }

        [Required, DefaultValue(0)]
        public int girensayisi { get; set; }

        public string ziyarettarih { get; set; }
    }
}