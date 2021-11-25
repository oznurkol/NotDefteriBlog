using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NotDefteriBlog.Entity;
using System.Text;
using System.Data;
using System.IO;

namespace NotDefteriBlog
{
    public partial class Home : System.Web.UI.MasterPage
    {
        public static string baslik = "", copyyazi = "", desc="",keyws="";
        public StringBuilder builder = new StringBuilder();
        public StringBuilder icerik = new StringBuilder();
        string[] resimler;
        string[] klasor;
        int resimsira = 0;
        private void slider_Get()
        {
            klasor = Directory.GetFiles(Server.MapPath("slider_resim"));
            //Response.Write(klasor[0]);
            resimler = new string[klasor.Count()];
            for (int i = 0; i < klasor.Count(); i++)
            {
                resimler[i] = ("slider_resim/" + Path.GetFileName(klasor[i]));
            }
            Image1.ImageUrl = resimler[resimsira];
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            slider_Get();
            SiteMapYap yaphaci = new SiteMapYap(Server.MapPath("Web.SiteMap"));
            anasayfa.Text = "<li><a href=\"index.aspx\"><div class=\"glyphicon glyphicon-home\"></div> Ana Sayfa</a></li>";
            kategoriler.Text = "<li><a href=\"Kategori.aspx\"><div class=\"glyphicon glyphicon-list\"></div> Kategoriler</a></li>";
            duyurularx.Text = "<li><a href=\"Duyurular.aspx\"><div class=\"glyphicon glyphicon-flag\"></div> Duyurular</a></li>";
            galeri.Text = "<li><a href=\"Galeri.aspx\"><div class=\"glyphicon glyphicon-camera\"></div> Galeri</a></li>";
            hakkimizda.Text = "<li><a href=\"Hakkimizda.aspx\"><div class=\"glyphicon glyphicon-copyright-mark\"></div> Hakkımızda</a></li>";
            //ds.ReadXml(Server.MapPath("system.xml"));
            
           
            DataBase VT = new DataBase();
            System_ config = VT.System.Where(x => x.ID == 1).FirstOrDefault();
            baslik = config.sitebaslik;
            copyyazi = config.copy;
            keyws = config.keyw;
            desc = config.desc;
            Image1.ImageUrl = config.bannerresim;
            if ((string)Session["uye"] == null && config.uyegiris)
                Literal1.Text = "<li><a href=\"GirisYap.aspx\"><div class=\"glyphicon glyphicon glyphicon-log-in\"></div> Giriş Yap</a></li>";
            else {
                string uid = (string)Session["uye"];
                if (Session["uye"] != null)
                {
                    var kullanici = VT.Yazarlar.Where(x => x.username == uid).FirstOrDefault();
                    if (kullanici.adminmi)
                    {
                        Literal2.Text = "<li><a href=\"Yonetim.aspx\"><div class=\"glyphicon glyphicon-th-large\"></div> Yönetim İşlemleri</a></li>";
                        Literal1.Text = "<li><a href=\"Islem.aspx\"><div class=\"glyphicon glyphicon-th\"></div> Üye Paneli</a></li>";
                    }
                    else
                    {
                        Literal1.Text = "<li><a href=\"Islem.aspx\"><div class=\"glyphicon glyphicon-th\"></div> Üye Paneli</a></li>";
                    }
                    Literal3.Text = "<li><a href=\"cikis.aspx\"><div class=\"glyphicon glyphicon-log-out\"></div> Çıkış Yap</a></li>";
                }
            }
            if (Session["uye"] == null && config.uyealim)
                Literal2.Text = "<li><a id=\"menu_4\" href=\"Kayit.aspx\"><div class=\"glyphicon glyphicon-user\"></div> Kayıt Ol</a></li>";

            string ipadres = GetIPAddress();
            string tarih = DateTime.Now.Date.ToString();
            var ipbugungirmismi = VT.Ziyartci.Where(g => g.IpAdres == ipadres && g.tarih == tarih).FirstOrDefault();
            if (ipbugungirmismi==null)
            {
                var tarihkontrol = VT.System.Where(g => g.ziyarettarih == tarih).FirstOrDefault();
                if (tarihkontrol!=null)
                    tarihkontrol.girensayisi += 1;
                else
                {
                    var tarihci = VT.System.FirstOrDefault();
                    tarihci.girensayisi = 1;
                    tarihci.ziyarettarih = tarih;
                }
                VT.SaveChanges();
                Ziyaret zy = new Ziyaret();
                zy.IpAdres = ipadres;
                zy.tarih = tarih;
                VT.Ziyartci.Add(zy);
                VT.SaveChanges();

            }
            var tarihkon = VT.System.Where(g => g.ziyarettarih == tarih).FirstOrDefault();
            if (tarihkon != null)
                bugunltr.Text = tarihkon.girensayisi.ToString();
            else bugunltr.Text = "Bugün giren ilk kişisiniz";
            aktifltr.Text = Application["OnlineZiyaretci"].ToString();
            var menux = VT.Menuler.ToList();
            if (menux.Count > 0)
            {
                for (int i = 0; i < menux.Count; i++)
                {
                    if (!string.IsNullOrEmpty(menux[i].menuYol) && menux[i].normalsayfami==false)
                        Literal4.Text += "<li><a href='icerik.aspx?id=" + menux[i].menuID + "'><div class=\"glyphicon glyphicon-asterisk\"></div> " + menux[i].baslik + "</a></li>";
                    if(GetCurrentPageName().ToUpper()==(menux[i].menuYol).ToUpper() && menux[i].normalsayfami)
                    {
                        icerik.Append("<div class=\"row\"><div class=\"col-md-9 col-md-offset-1 bg-white main-border-4 mgb-30\"><h2>"+menux[i].baslik+"</h2><hr />"+menux[i].icerik+"</div></div>");
                    }
                }
            }
        }
        protected string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }

        public string GetCurrentPageName()
        {
            string sPath = Request.Url.AbsolutePath;
            System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            string sRet = oInfo.Name;
            return sRet;
        }

        protected void btnHidden_OnClick(object sender, EventArgs e)
        {
            resimsira--;
            if (resimsira <= 0)
                resimsira = resimler.Length - 1;
            Image1.ImageUrl = resimler[resimsira];
            
            
        }

        protected void btnHidden_OnClick2(object sender, EventArgs e)
        {
            resimsira++;
            if (resimsira >= resimler.Length)
                resimsira = 0;
            Image1.ImageUrl = resimler[resimsira];
            
        } 
    }
}