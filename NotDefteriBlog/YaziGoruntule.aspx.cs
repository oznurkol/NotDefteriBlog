using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NotDefteriBlog.Entity;
using System.Net;

namespace NotDefteriBlog
{
    public partial class YaziGoruntule : System.Web.UI.Page
    {
        DataBase VT = new DataBase();
        Yazilar konu;
        Yazarlar yazar;
        Favori fav;
        public bool aktif = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = "";
            try { id = (Request.QueryString["id"].ToString()); }
            catch { }
            if (Session["uye"] == null)
            {
                Like.Visible = false;
                Like.Enabled = false;
                
            }

            if (string.IsNullOrEmpty(id))
                Response.Redirect("index.aspx");
            else
            {
                int ceviri=int.Parse(id);
                
                var konucek = VT.Yazilar.Where(g => g.Yazi_ID == ceviri).FirstOrDefault();



                if (konucek != null)
                {
                    
                    if (konucek.onay == false)
                        if (Session["admin"]==null)
                            Response.Redirect("index.aspx");

                    if (konucek.oyacikmi == 0)
                    {
                        Arti.Enabled = Arti.Visible = Eksi.Enabled = Eksi.Visible = false;
                    }
                    if (konucek.oyacikmi == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "gizle", "yorumgizle();", true);
                    }
                    if (Session["uye"] != null)
                    {
                        adsoyad.Enabled=RegularExpressionValidator1.Enabled=eposta.Enabled=RegularExpressionValidator2.Enabled=false;
                        ad.Enabled = web.Enabled = webpage.Enabled = RegularExpressionValidator3.Enabled = false;
                        email.Enabled = false;
                    }

                    konu = konucek;
                    baslik.Text = konucek.baslik;
                    icerik.Text = konucek.icerik;
                    yazan.Text = "Yazar: "+konucek.Yazan.username;
                    string user = "";
                    try { user = Session["uye"].ToString(); }
                    catch{ }
                    var usercek = VT.Yazarlar.Where(g => g.username == user).FirstOrDefault();
                    if (usercek!=null)
                    {
                        yazar = usercek;
                        var userbilgi = usercek.Fav.Where(g => g.Yazi == konucek).FirstOrDefault();
                        if (userbilgi == null)
                        {
                            Like.CssClass = "glyphicon glyphicon-heart-empty font35";
                        }
                        else
                        {
                            Like.CssClass = "glyphicon glyphicon-heart font35";
                        }
                        fav = userbilgi;
                    }
                    Repeater_Doldur();

                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
        }

        private void Repeater_Doldur()
        {
            int temp = 0;

            Repeater1.DataSource = konu.Yorum.Select(g => new
            {
                yazar = (int.TryParse(g.ad, out temp) ?
                "ÜYE: " + VT.Yazarlar.Where(k => k.ID == temp).Select(h => new { yazar = h.username }).FirstOrDefault().yazar.ToString() :
                "Yazar: " + g.ad),
                tarih = g.tarih,
                yorumid = g.YorumID,
                yorum_icerik = g.yorum_icerik
            }).ToList();
            Repeater1.DataBind();
            if (Session["admin"] != null)
            {
                aktif = true;
                foreach (RepeaterItem ritem in Repeater1.Items)
                {
                    Button btn = ritem.FindControl("btnSil") as Button;
                    btn.Click += new EventHandler(yorum_sil);
                }
            }
        }


        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            int save = -1;
            if (fav == null)
            {
                Favori newfav = new Favori();
                newfav.Yazi = konu;
                newfav.Yazar = yazar;
                newfav.tarih = DateTime.Now;
                VT.Favori.Add(newfav);
                save = VT.SaveChanges();
                if (save > 0)
                    Like.CssClass = "glyphicon glyphicon-heart font35";
            }
            else
            {
                VT.Favori.Remove(fav);
                save = VT.SaveChanges();
                if (save > 0)
                    Like.CssClass = "glyphicon glyphicon-heart-empty font35";
            }
        }

        protected void Arti_Click(object sender, EventArgs e)
        {
            if (konu.oyacikmi > 0)
            {
                var oykontrol = konu.Oy.Where(g => g.ip == GetIPAddress()).FirstOrDefault();
                if (oykontrol == null)
                {
                    konu.oy += 1;
                    VT.SaveChanges();
                    Oylama oyver = new Oylama();
                    oyver.tarih = DateTime.Now;
                    oyver.Yazi = konu;
                    oyver.ip = GetIPAddress();
                    VT.Oylama.Add(oyver);
                    VT.SaveChanges();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Daha önce bu konu hakkında oy kullanılmış.\\nTekrar kullanamazsınız.')", true);
                }
            }
        }
        protected void Eksi_Click(object sender, EventArgs e)
        {
            if (konu.oyacikmi > 0)
            {
                var oykontrol = konu.Oy.Where(g => g.ip == GetIPAddress()).FirstOrDefault();
                if (oykontrol == null)
                {
                    konu.oy -= 1;
                    VT.SaveChanges();
                    Oylama oyver = new Oylama();
                    oyver.tarih = DateTime.Now;
                    oyver.Yazi = konu;
                    oyver.ip = GetIPAddress();
                    VT.Oylama.Add(oyver);
                    VT.SaveChanges();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Daha önce bu konu hakkında oy kullanılmış.\\nTekrar kullanamazsınız.')", true);
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

        protected void gonder_Click(object sender, EventArgs e)
        {
            Yorumlar yorumyap = new Yorumlar();
            yorumyap.onay = false;
            yorumyap.ID = konu;
            string jquery = "";
            if (adsoyad.Text.Trim().Length > 3 && yorum.Text.Trim().Length > 15)
            {
                
                yorumyap.ad = adsoyad.Text.Trim();
                yorumyap.email = email.Text.Trim();
                yorumyap.webpage = webpage.Text.Trim();
                yorumyap.tarih = DateTime.Now;
                yorumyap.yorum_icerik = yorum.Text;
                VT.Yorumlar.Add(yorumyap);
                int save = VT.SaveChanges();
                if (save > 0)
                    jquery = "kayitbasarili('#yorumkayit','<div class=\"col-md-12\"><br /><div class=\"alert alert-success\"><h4><strong>Başarılı!</strong> Yorumunuz başarı ile eklenmiştir.<br /></h4></div></div>');";
                else
                    jquery = "kayitbasarili('#yorumkayit','<div class=\"col-md-12\"><br /><div class=\"alert alert-error\"><h4><strong>Hata!</strong> Yorumunuz eklenemedi.<br /></h4></div></div>');";
                
            }
            else if (Session["uye"] != null && yorum.Text.Trim().Length>15)
            {
                string uyee = (string)Session["uye"];
                var uye = VT.Yazarlar.Where(g => g.username == uyee).FirstOrDefault();
                if (uye != null)
                {
                    string kisiid = uye.ID.ToString();
                    yorumyap.ad = kisiid;
                    yorumyap.email = "sssss";
                    yorumyap.webpage = webpage.Text.Trim();
                    yorumyap.tarih = DateTime.Now;
                    yorumyap.yorum_icerik = yorum.Text;
                    VT.Yorumlar.Add(yorumyap);
                    int save = VT.SaveChanges();
                    if (save > 0)
                    {
                        jquery = "kayitbasarili('#yorumkayit','<div class=\"col-md-12\"><br /><div class=\"alert alert-success\"><h4><strong>Başarılı!</strong> Yorumunuz başarı ile eklenmiştir.<br /></h4></div></div>');";
                        Repeater_Doldur();
                    }
                    else
                        jquery = "kayitbasarili('#yorumkayit','<div class=\"col-md-12\"><br /><div class=\"alert alert-error\"><h4><strong>Hata!</strong> Yorumunuz eklenemedi.<br /></h4></div></div>');";
                }
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "uyari", jquery, true);
        }

        protected void yorum_sil(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int yid = int.Parse(button.CommandArgument);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('"+button.CommandArgument+"')", true);
            var yorumbul = VT.Yorumlar.Where(g => g.YorumID == yid).FirstOrDefault();
            if (yorumbul != null)
            {
                string jquery = "";
                VT.Yorumlar.Remove(yorumbul);
                int save = VT.SaveChanges();
                if (save > 0)
                {
                    jquery = "kayitbasarili('#yorumkayit','<div class=\"col-md-12\"><br /><div class=\"alert alert-success\"><h4><strong>Başarılı!</strong> Yorum başarı ile silindi.<br /></h4></div></div>');";
                    Repeater_Doldur();
                }
                else
                    jquery = "kayitbasarili('#yorumkayit','<div class=\"col-md-12\"><br /><div class=\"alert alert-error\"><h4><strong>Hata!</strong> Yorum silinemedi.<br /></h4></div></div>');";
                
            }
        }

        protected void Repeater1_ItemCreated(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}