using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NotDefteriBlog.Entity;

namespace NotDefteriBlog
{
    public partial class Index : System.Web.UI.Page
    {
        DataBase VT = new DataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            var konucek = VT.Yazilar.Where(g => g.onay == true).Select(g => new
            {
                baslik = g.baslik,
                tarih = g.tarih,
                icerik=g.icerik.Length>255?g.icerik.ToString().Substring(0,250):g.icerik,
                yazar = g.Yazan.username,
                yaziid = g.Yazi_ID,
                kate_baslik = g.KAT.kate_adi
            }).ToList();
            if (konucek.Count > 0)
            {
                Repeater1.DataSource = konucek;
                Repeater1.DataBind();
            }
        }

        public string GetCurrentPageName()
        {
            string sPath = Request.Url.AbsolutePath;
            System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            string sRet = oInfo.Name;
            return sRet;
        } 
    }
}