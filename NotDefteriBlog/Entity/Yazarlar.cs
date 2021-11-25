using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace NotDefteriBlog.Entity
{
    [Table("yazarlar")]
    public class Yazarlar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(50), Required]
        public string username { get; set; }
        [StringLength(100), Required]
        [DataType(DataType.Password), MaxLength(50)]
        private string password;
        public string Pass
        {
            get
            {
                return password;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    password = FormsAuthentication.HashPasswordForStoringInConfigFile(value, "MD5");
                }
            }

        }
        [StringLength(75),Required]
        public string email { get; set; }
        [StringLength(30)]
        public string ad { get; set; }
        [StringLength(30)]
        public string soyad { get; set; }
        [StringLength(12)]
        public string telefon { get; set; }
        [DefaultValue("true"),Required]
        public bool adminmi { get; set; }
        [DefaultValue("true"),Required]
        public bool gizlimi { get; set; }
        [StringLength(100)]
        public string webpage { get; set; }
        [StringLength(3000)]
        public string hakkinda { get; set; }
        [StringLength(150)]
        public string face { get; set; }
        [StringLength(150)]
        public string inst { get; set; }
        [StringLength(150)]
        public string twitter { get; set; }
        [StringLength(150)]
        public string linked { get; set; }

        public virtual List<Yazilar> Yazilari{get; set;}
        public virtual List<Favori> Fav { get; set; }


    }
}