using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NotDefteriBlog.Entity;
using System.Data.Entity.Validation;
using System.Text;
using System.Web.Services;
using System.Web.Security;

namespace NotDefteriBlog
{
    public partial class kat_islem : System.Web.UI.Page
    {

        IList<string> kelimeler=new List<string>();
        IList<string> yeniyazikati = new List<string>();
        string adi1 = "", aciklama1="", title1="";
        public static string hata = "";
        DataBase VT = new DataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uye"] == null)
                Response.Redirect("index.aspx");
        }

        private Yazarlar yazarGet()
        {
            string uyee = (string)Session["uye"];
            var uye = VT.Yazarlar.Where(g => g.username == uyee).FirstOrDefault();
            return uye;
        }

        private void yazilar_Get()
        {
            var yazar = yazarGet();
            var yazilar = yazar.Yazilari.Where(g=> g.onay==false).Select(g => new
            {
                Yazi_ID=g.Yazi_ID,
                baslik=g.baslik,
                tarih=g.tarih,
                oykul=g.oyacikmi==1?"Aktif":"Aktif Değil",
                oy=g.oy,
                yorumkul=g.yorum_turu==1?"Yapılabilir":"Yapılamaz",
                kate=g.KAT.kate_adi,
                yorumsayisi = g.Yorum.Count()
            }).ToList();
            if (yazilar.Count > 0)
            {
                GridView2.DataSource = yazilar;
                GridView2.DataBind();
            }
            
        }

        protected void yazilar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            yazilar_Get();
        }

        protected void yaziolustur_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
            var yazar = yazarGet();
            var kategoriler = VT.Kategoriler.ToList();
            yeniyazikat.DataSource = kategoriler;
            yeniyazikat.DataTextField = "kate_adi";
            yeniyazikat.DataValueField = "KID";
            yeniyazikat.DataBind();
        }

        protected void yaziEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(yeniyazibaslik.Text.Trim()))
            {
                int cevir = int.Parse(yeniyazikat.SelectedValue.ToString());
                var kategori = VT.Kategoriler.Where(g => g.KID == cevir).FirstOrDefault();
                Yazilar yeniyazi = new Yazilar();
                yeniyazi.baslik = yeniyazibaslik.Text.Trim();
                string icerik = yeniyaziicerik.Text;
                yeniyazi.icerik = icerik;
                yeniyazi.onay = false;
                yeniyazi.tarih = DateTime.Now;
                yeniyazi.oy = 0;
                yeniyazi.gizlimi = int.Parse(yeniyayin.SelectedValue) == 0 ? true : false;
                yeniyazi.oyacikmi = int.Parse(yenioy.SelectedValue) == 1 ? (byte)1 : (byte)0;
                yeniyazi.KAT = kategori;
                yeniyazi.Yazan = yazarGet();
                yeniyazi.yorum_turu = int.Parse(yeniyorum.SelectedValue) == 0 ? (byte)0 : (byte)1;
                VT.Yazilar.Add(yeniyazi);
                int save = VT.SaveChanges();
                if (save > 0)
                {
                    Literal3.Text = "<div class=\"alert alert-success\" id=\"" + Literal3.ClientID + "\"><h4><strong>Başarılı!</strong> Yazı ekleme işlemi başarılı.<br /></h4></div";
                    yeniyaziicerik.Text = yeniyazibaslik.Text = "";
                    yeniyazikat.SelectedIndex = -1;
                }
                else
                    Literal3.Text = "<div class=\"alert alert-danger\" id=\"" + Literal3.ClientID + "\"><h4><strong>Hata!</strong> Yazı ekleme işlemi başarısız.<br /></h4></div>";
                Random rnd = new Random();
                string ltr = rnd.Next(1, 99999).ToString();
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), ltr, "gizleltr(" + Literal3.ClientID + ");", true);
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rakam = int.Parse(GridView2.SelectedValue.ToString());
            duzenyazikate.Items.Clear();
            duzenyazikate.SelectedIndex = -1;
            
            var sec = yazarGet();
            var kategoriler = VT.Kategoriler.ToList();

            duzenyazikate.DataSource = kategoriler;
            duzenyazikate.DataTextField = "kate_adi";
            duzenyazikate.DataValueField = "KID";
            duzenyazikate.DataBind();
            duzenyazikate.SelectedValue = null;
            var secili = sec.Yazilari.Where(g => g.Yazi_ID == rakam).FirstOrDefault();
            if (secili != null)
            {
                duzenyazibaslik.Text = secili.baslik;
                duzenyaziicerik.Text = secili.icerik;
                try
                {
                    duzenyazikate.SelectedValue = secili.KAT.ToString();
                }
                catch
                {

                }
                duzenyazioy.SelectedValue=secili.oyacikmi==1?"1":"0";
                duzenyaziyayin.SelectedValue = secili.yorum_turu == 1 ? "1" : "0";
                duzenyaziyorum.SelectedValue = secili.yorum_onay == true ? "1" : "0";
            }
            else
            {
                yazilarltl.Text = "Sorun var!";
            }
        }

        protected void YaziDuzen_Click(object sender, EventArgs e)
        {
            int rakam = -1;
            try
            {
                rakam = int.Parse(string.IsNullOrEmpty(GridView2.SelectedValue.ToString()) ? "-1" : (string)GridView2.SelectedValue.ToString());
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "scx", "alert(\"Yazı seçmeden düzenleme işlemi yapamazsınız!\")", true);
            }
            var yazar = yazarGet();
            var duzen = yazar.Yazilari.Where(g => g.Yazi_ID == rakam && g.onay == false).FirstOrDefault();
            if (duzen != null)
            {
                duzen.baslik = duzenyazibaslik.Text;
                duzen.icerik = duzenyaziicerik.Text;
                int cevir = int.Parse(duzenyazikate.SelectedValue.ToString());
                var kategori = VT.Kategoriler.Where(g => g.KID == cevir).FirstOrDefault();
                duzen.KAT = kategori;
                duzen.gizlimi = int.Parse(duzenyaziyayin.SelectedValue.ToString()) == 0 ? true : false;
                duzen.oyacikmi = int.Parse(duzenyazioy.SelectedValue.ToString()) == 1 ? (byte)1 : (byte)0;
                int save=VT.SaveChanges();
                if (save > 0)
                {
                    yazilarltl.Text = "<div class=\"alert alert-success\" id=\"" + yazilarltl.ClientID + "\"><h4><strong>Başarılı!</strong> Düzenleme başarılı.<br /></h4></div>";
                    yazilar_Get();
                    duzenyazibaslik.Text = duzenyaziicerik.Text = "";
                    duzenyazikate.SelectedIndex = -1;

                }
                else
                {
                    yazilarltl.Text = "<div class=\"alert alert-danger\" id=\"" + yazilarltl.ClientID + "\"><h4><strong>Hata!</strong> İşlem başarısız.<br /></h4></div>"; ;
                }
                Random rnd = new Random();
                string ltr = rnd.Next(1, 99999).ToString();
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), ltr, "gizleltr(" + yazilarltl.ClientID + ");", true);
            }
        }

        protected void favlar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 4;
            fav_Get();
        }

        private void fav_Get()
        {
            
            var yazar = yazarGet();
            var favlar = yazar.Fav.Where(g => g.Yazi.onay == true).Select(k =>
                new { baslik = k.Yazi.baslik, username = k.Yazi.Yazan.username, Fav_ID = k.Fav_ID, Yazi_ID = k.Yazi.Yazi_ID }).ToList();
            GridView3.DataSource = favlar;
            GridView3.DataBind();
           
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                //Literal1.Text = GridView1.Rows[index].Cells[1].Text.ToString();
                int cevir = Convert.ToInt32(GridView3.Rows[index].Cells[2].Text.ToString());
                var yazar = yazarGet();
                var fav = yazar.Fav.Where(g => g.Fav_ID == cevir).FirstOrDefault();
                if (fav != null)
                {
                    VT.Favori.Remove(fav);
                    int save = VT.SaveChanges();
                    if (save > 0)
                    {
                        favlit.Text = "<div class=\"alert alert-success\" id=\"" + favlit.ClientID + "\"><h4><strong>Başarılı!</strong> Favorilerinizden kaldırıldı.<br /></h4></div>";
                        fav_Get();
                    }
                    else
                        favlit.Text = "<div class=\"alert alert-danger\" id=\"" + favlit.ClientID + "\"><h4><strong>Hata!</strong> İşlem başarısız.<br /></h4></div>";
                    Random rnd = new Random();
                    string ltr = rnd.Next(1, 99999).ToString();
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), ltr, "gizleltr(" + favlit.ClientID + ");", true);
                }
                
            }
        }

        protected void yorumlar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 5;
            var uyecek = yazarGet();
            adi.Text = uyecek.ad;
            soyadi.Text = uyecek.soyad;
            emails.Text = uyecek.email;
            telefon.Text = uyecek.telefon;
            webpage.Text = uyecek.webpage;
            hesapgizlilik.SelectedValue = uyecek.gizlimi == true ? "1" : "0";
            facebook.Text = uyecek.face;
            twitter.Text = uyecek.twitter;
            instgram.Text = uyecek.inst;
            hakkinizda.Text = uyecek.hakkinda;

        }

        protected void sifrebtn_Click(object sender, EventArgs e)
        {
            string uye=Session["uye"].ToString();
            string password = FormsAuthentication.HashPasswordForStoringInConfigFile(eskisifre.Text, "MD5");
            var kim = VT.Yazarlar.Where(g => g.username == uye && g.Pass == password).FirstOrDefault();
            if (kim == null)
            {
                Literal4.Text = "<div class=\"alert alert-danger\" id=\"" + Literal4.ClientID + "\"><h4><strong>Hata!</strong> Eski şifreniz hatalı.<br /></h4></div>";
            }
            else if(yenisi.Text!=yenisitekrar.Text)
            {
                Literal4.Text = "<div class=\"alert alert-danger\" id=\"" + Literal4.ClientID + "\"><h4><strong>Hata!</strong> Yeni şifreler uyuşmuyor!<br /></h4></div>";
            }
            else if(yenisi.Text.Length > 30 || yenisi.Text.Length < 5)
            {
                Literal4.Text = "<div class=\"alert alert-danger\" id=\"" + Literal4.ClientID + "\"><h4><strong>Hata!</strong> Şifre 5-30 karakter arasında olabilir!<br /></h4></div>";
            }
            else
            {
                string password2 = FormsAuthentication.HashPasswordForStoringInConfigFile(yenisi.Text, "MD5");
                kim.Pass = password2;
                int save=VT.SaveChanges();
                if (save > 0)
                {
                    Literal4.Text = "<div class=\"alert alert-success\" id=\"" + Literal4.ClientID + "\"><h4><strong>Başarılı!</strong> Şifre değişikliği işlemi başarılı!<br /></h4></div>";
                    yenisi.Text = yenisitekrar.Text = eskisifre.Text = "";
                }
                else
                    Literal4.Text = "<div class=\"alert alert-danger\" id=\"" + Literal4.ClientID + "\"><h4><strong>Hata!</strong> İşlem başarısız!<br /></h4></div>";
            }
            Random rnd = new Random();
            string ltr = rnd.Next(1, 99999).ToString();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), ltr, "gizleltr(" + Literal4.ClientID + ");", true);
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                //Literal1.Text = GridView1.Rows[index].Cells[1].Text.ToString();
                int cevir = Convert.ToInt32(GridView2.Rows[index].Cells[7].Text.ToString());
                var yazar = yazarGet();
                var fav = yazar.Yazilari.Where(g => g.Yazi_ID == cevir && g.onay!=true).FirstOrDefault();
                if (fav != null)
                {
                    VT.Yazilar.Remove(fav);
                    int save = VT.SaveChanges();
                    if (save > 0)
                    {
                        yazilarltl.Text = "<div class=\"alert alert-success\" id=\"" + yazilarltl.ClientID + "\"><h4><strong>Başarılı!</strong> Yazı silindi.<br /></h4></div>";
                        yazilar_Get();
                    }
                    else

                        yazilarltl.Text = "<div class=\"alert alert-danger\" id=\"" + yazilarltl.ClientID + "\"><h4><strong>Hata!</strong> İşlem başarısız.<br /></h4></div>";
                }
                else
                {
                    yazilarltl.Text = "Bulunamadı!";
                }
                Random rnd = new Random();
                string ltr = rnd.Next(1, 99999).ToString();
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), ltr, "gizleltr(" + yazilarltl.ClientID + ");", true);

            }
        }

        protected void kisiselBtn_Click(object sender, EventArgs e)
        {
            var yazarcek = yazarGet();
            if(adi.Text.Trim().Length<3 || adi.Text.Trim().Length>50)
                Literal4.Text = "<div class=\"alert alert-danger\" id=\"" + Literal4.ClientID + "\"><h4><strong>Hata!</strong> Ad 3-50 karakter arasında olabilir!<br /></h4></div>";
            else if(soyadi.Text.Trim().Length<3 || soyadi.Text.Trim().Length>50)
                Literal4.Text = "<div class=\"alert alert-danger\" id=\"" + Literal4.ClientID + "\"><h4><strong>Hata!</strong> Soyad 3-50 karakter arasında olabilir!<br /></h4></div>";
            else if(emails.Text.Trim().Length<5 || emails.Text.Trim().Length>75)
                Literal4.Text = "<div class=\"alert alert-danger\" id=\"" + Literal4.ClientID + "\"><h4><strong>Hata!</strong> Email 5-75 karakter arasında olabilir!<br /></h4></div>";
            else if(telefon.Text.Trim().Length!=10)
                Literal4.Text = "<div class=\"alert alert-danger\" id=\"" + Literal4.ClientID + "\"><h4><strong>Hata!</strong> Telefon 11 karakter olabilir!<br /></h4></div>";
            else
            {
                yazarcek.ad = adi.Text.Trim();
                yazarcek.soyad = soyadi.Text.Trim();
                yazarcek.telefon = telefon.Text;
                yazarcek.email = emails.Text.Trim();
                yazarcek.webpage = webpage.Text;
                yazarcek.gizlimi = hesapgizlilik.SelectedValue.ToString()=="0"?false:true;
                int save=VT.SaveChanges();
                if(save>0)
                    Literal4.Text = "<div class=\"alert alert-success\" id=\"" + Literal4.ClientID + "\"><h4><strong>Başarılı!</strong> Başarılı bir şekilde bilgiler güncellendi!<br /></h4></div>";
                else
                    Literal4.Text = "<div class=\"alert alert-danger\" id=\"" + Literal4.ClientID + "\"><h4><strong>Hata!</strong> Bir sorun ile karşılaşıldı.<br /></h4></div>";

            }
            Random rnd = new Random();
            string ltr = rnd.Next(1, 99999).ToString();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), ltr, "gizleltr(" + Literal4.ClientID + ");", true);
        }

        protected void sosyalBtn_Click(object sender, EventArgs e)
        {
            
            var yazarcek = yazarGet();
            yazarcek.face = facebook.Text;
            yazarcek.inst = instgram.Text;
            yazarcek.twitter = twitter.Text;
            yazarcek.hakkinda = hakkinizda.Text;
            int save = VT.SaveChanges();
            if (save > 0)
            {
                Literal4.Text = "<div class=\"alert alert-success\" id=\""+Literal4.ClientID+"\"><h4><strong>Başarılı!</strong> Başarılı bir şekilde bilgiler güncellendi!<br /></h4></div>";
            }
            else
                Literal4.Text = "<div class=\"alert alert-danger\" id=\"" + Literal4.ClientID + "\"><h4><strong>Hata!</strong> Bir sorun ile karşılaşıldı.<br /></h4></div>";
            Random rnd = new Random();
            string ltr = rnd.Next(1, 99999).ToString();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), ltr, "gizleltr(" + Literal4.ClientID + ");", true);
            
        }
    }
}