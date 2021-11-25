using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NotDefteriBlog.Entity
{
    public class Ziyaret
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), DefaultValue("1")]
        public int ID { get; set; }
        public string IpAdres { get; set; }
        public string tarih { get; set; }
    }
}