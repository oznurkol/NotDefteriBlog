using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NotDefteriBlog.Entity
{
    public class DinamikMenuler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int menuID { get; set; }
        public string menuYol { get; set; }
        public bool normalsayfami{get; set;}
        public string baslik { get; set; }
        public string icerik { get; set; }

    }
}