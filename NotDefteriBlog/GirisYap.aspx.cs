using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NotDefteriBlog.Entity;
using System.Web.Security;

namespace NotDefteriBlog
{
    public partial class girisyap : System.Web.UI.Page
    {
        public static bool giris=true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uye"] == null)
            {
                DataBase db = new DataBase();
                System_ config = db.System.Where(x => x.ID == 1).FirstOrDefault();
                if (!config.uyegiris)
                    Response.Redirect("index.aspx");
            }
            else
            {
                Response.Redirect("Islem.aspx");
            }
        }

        protected void giris_yap_Click(object sender, EventArgs e)
        {
            string jquery = "";
            username.Text = username.Text.Trim();
            password.Text = password.Text.Trim();
            if (string.IsNullOrEmpty(username.Text))
                jquery = "mesaj('alert-danger', '<strong>Hata</strong> Kullanıcı adınız boş olamaz!');";
            else if (username.Text.Length > 30 || username.Text.Length < 5)
                jquery = "mesaj('alert-danger', '<strong>Hata</strong> Kullanıcı adınız 5-30 karakter arası olmak zorundadır!');";
            else if (string.IsNullOrEmpty(password.Text))
                jquery = "mesaj('alert-danger', '<strong>Hata</strong> Şifre boş olamaz!');";
            else if (password.Text.Length > 30 || password.Text.Length < 5)
                jquery = "mesaj('alert-danger', '<strong>Hata</strong> Şifreniz 5-30 karakter arası olmak zorundadır!');";
            else
            {
                DataBase db = new DataBase();
                string pass = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "MD5");
                var kisi = db.Yazarlar.Where(x => x.username == username.Text && x.Pass == pass).FirstOrDefault();
                if (kisi == null)
                    jquery = "mesaj('alert-danger', '<strong>Hata</strong> Kullanıcı adınız veya şifreniz hatalı.');";
                else
                {
                    jquery = "kayitbasarili('#giris','<div class=\"col-md-12\"><br /><div class=\"alert alert-success\"><h4><strong>Başarılı!</strong> Giriş işleminiz başarılı<br />Yönlendiriliyorsunuz...</h4></div></div>');";
                    Session["uye"] = kisi.username.ToString();
                    Timer1.Enabled = true;
                    if (kisi.adminmi)
                        Session["admin"] = "true";
                }
            }
            if (!string.IsNullOrEmpty(jquery))
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "scripty", jquery, true);
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Response.Redirect("Islem.aspx");
        }
    }
}