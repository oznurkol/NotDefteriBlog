using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NotDefteriBlog.Entity;

namespace NotDefteriBlog
{
    public partial class kayit : System.Web.UI.Page
    {
        public bool hata = false, kayitt=true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid1"] == null)
            {
                DataBase db = new DataBase();
                System_ config = db.System.Where(x => x.ID == 1).FirstOrDefault();
                if (config == null || (!config.uyealim && !config.uyegiris))
                    Response.Redirect("index.aspx");
                if (!config.uyealim)
                    kayitt = false;
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }

        protected void login_btn_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>mesaj();</script>", true);
            Literal1.Text = hata.ToString();
        }

        protected void login_btn_Click1(object sender, EventArgs e)
        {
            string jquery = "";
            if (kayitt == false)
                jquery = "kayitbasarili('#kayit','<div class=\"col-md-12\"><br /><div class=\"alert alert-info\"><h4><strong>Bilgilendirme!</strong> Kullanıcı kaydı işlemi aktif değildir.</h4></div></div>');";
            else
            {
                uname.Text = uname.Text.Trim();
                pass.Text = pass.Text.Trim();
                passr.Text = passr.Text.Trim();
                email.Text = email.Text.Trim();
                if (string.IsNullOrEmpty(uname.Text))
                    jquery = "mesaj('alert-danger', '<strong>Hata</strong> Kullanıcı adınız boş olamaz.');";
                else if (uname.Text.Length > 30 || uname.Text.Length < 5)
                    jquery = "mesaj('alert-danger', '<strong>Hata</strong> Kullanıcı adınız 5-30 karakter arası olmak zorundadır.');";
                else if (string.IsNullOrEmpty(email.Text))
                    jquery = "mesaj('alert-danger', '<strong>Hata</strong> Email boş olamaz.');";
                else if (email.Text.Length < 7 || email.Text.Length > 30)
                    jquery = "mesaj('alert-danger', '<strong>Hata</strong> Email 7-30 karakter arası olmak zorundadır.');";
                else if (string.IsNullOrEmpty(pass.Text))
                    jquery = "mesaj('alert-danger', '<strong>Hata</strong> Şifre boş olamaz.');";
                else if (pass.Text.Length > 30 || pass.Text.Length < 5)
                    jquery = "mesaj('alert-danger', '<strong>Hata</strong> Şifreniz 5-30 karakter arası olmak zorundadır.');";
                else if (pass.Text != passr.Text)
                    jquery = "mesaj('alert-danger', '<strong>Hata</strong> Şifreler uyuşmuyor!');";
                else if (!string.IsNullOrEmpty(ad.Text) && (ad.Text.Trim().Length < 3 || ad.Text.Trim().Length > 20))
                    jquery = "mesaj('alert-danger', '<strong>Hata</strong> Ad alanı 3-20 karakter arası olmalıdır.');";
                else if (!string.IsNullOrEmpty(soyad.Text) && (soyad.Text.Trim().Length < 3 || soyad.Text.Trim().Length > 20))
                    jquery = "mesaj('alert-danger', '<strong>Hata</strong> Ad alanı 3-20 karakter arası olmalıdır.');";
                else if (!string.IsNullOrEmpty(telefon.Text) && telefon.Text.Trim().Length != 10)
                    jquery = "mesaj('alert-danger', '<strong>Hata</strong> Telefon alanı 10 karakter olmalıdır.');";
                else if (!string.IsNullOrEmpty(webpage.Text) && (webpage.Text.IndexOf("http://") == -1 || webpage.Text.Length > 100))
                    jquery = "mesaj('alert-danger', '<strong>Hata</strong> Web siteniz \"http://www...\" şeklinde olmaldır ve 100 karakterden fazla olamaz.');";
                else if (!string.IsNullOrEmpty(hakkinda.Text) && hakkinda.Text.Length > 3000)
                    jquery = "mesaj('alert-danger', '<strong>Hata</strong> Hakkınızda alanı 3000 karakteri geçemez.');";
                else if (!string.IsNullOrEmpty(facebook.Text) && (facebook.Text.IndexOf("http://") == -1 || facebook.Text.Length > 100))
                    jquery = "mesaj('alert-danger', '<strong>Hata</strong> Facebook sayfanız \"http://www...\" şeklinde olmaldır ve 100 karakterden fazla olamaz.');";
                else if (!string.IsNullOrEmpty(twitter.Text) && (twitter.Text.IndexOf("http://") == -1 || twitter.Text.Length > 100))
                    jquery = "mesaj('alert-danger', '<strong>Hata</strong> Twitter sayfanız \"http://www...\" şeklinde olmaldır ve 100 karakterden fazla olamaz.');";
                else if (!string.IsNullOrEmpty(instagram.Text) && (instagram.Text.IndexOf("http://") == -1 || instagram.Text.Length > 100))
                    jquery = "mesaj('alert-danger', '<strong>Hata</strong> Instagram sayfanız \"http://www...\" şeklinde olmaldır ve 100 karakterden fazla olamaz.');";
                else if (!string.IsNullOrEmpty(linkedin.Text) && (linkedin.Text.IndexOf("http://") == -1 || linkedin.Text.Length > 100))
                    jquery = "mesaj('alert-danger', '<strong>Hata</strong> LinkedIn sayfanız \"http://www...\" şeklinde olmaldır ve 100 karakterden fazla olamaz.');";
                else
                {
                    DataBase db = new DataBase();
                    var kisi = db.Yazarlar.Where(x => x.username == uname.Text || x.email == email.Text).FirstOrDefault();
                    if (kisi != null)
                    {
                        jquery = "mesaj('alert-danger', '<strong>Hata</strong> Bu kullanıcı adı veya email ile kayıtlı bir kullanıcı var.');";
                    }
                    else
                    {
                        bool gizli = int.Parse(gizlilik.SelectedValue) == 1 ? true : false;
                        Yazarlar yazar = new Yazarlar();
                        yazar.username = uname.Text;
                        yazar.Pass = pass.Text;
                        yazar.email = email.Text;
                        yazar.ad = ad.Text;
                        yazar.soyad = soyad.Text;
                        yazar.telefon = telefon.Text;
                        yazar.gizlimi = gizli;
                        yazar.webpage = webpage.Text.Trim();
                        yazar.hakkinda = hakkinda.Text;
                        yazar.face = facebook.Text.Trim();
                        yazar.twitter = twitter.Text.Trim();
                        yazar.inst = instagram.Text.Trim();
                        yazar.linked = linkedin.Text.Trim();
                        db.Yazarlar.Add(yazar);
                        int i = db.SaveChanges();
                        if (i == 1)
                        {
                            jquery = "kayitbasarili('#kayit','<div class=\"col-md-12\"><br /><div class=\"alert alert-success\"><h4><strong>Başarılı!</strong> Kayıt İşlemi Başarı İle Tamamlandı <br />Bilgileriniz:<br />Kullanıcı Adınız:" + uname.Text + "<br />Şifre:" + pass.Text + "<br />Email:" + email.Text + "<br />Yönlendiriliyorsunuz...</h4></div></div>');";
                            //Session["uid1"] = kisi.ID.ToString();
                            Session.Add("uye", uname.Text);
                            Timer1.Enabled = true;
                        }
                        else
                            jquery = "mesaj('alert-info', '<strong>Başarısız!</strong> Başarılı bir şekilde kayıt işlemi gerçekleşmiştir.');";
                    }
                }
            }
            if (!string.IsNullOrEmpty(jquery))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "scriptx", jquery, true);
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "scriptxy", "goster();", true);
                //Literal1.Text = "asdasdasd";
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}