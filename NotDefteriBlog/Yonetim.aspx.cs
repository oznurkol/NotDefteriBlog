using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NotDefteriBlog.Entity;
using System.IO;
using System.Data;

namespace NotDefteriBlog
{
    public partial class yonetim : System.Web.UI.Page
    {
        DataBase VT = new DataBase();
        private void uyeler_Get()
        {
            var uyeler = VT.Yazarlar.ToList();
            GridView2.DataSource = uyeler;
            GridView2.DataBind();
        }

        private void menuGetir()
        {
            var menuler = VT.Menuler.Select(g => new { baslik=g.baslik,icerik=g.icerik,menuYol=g.menuYol, menuID=g.menuID,normal = g.normalsayfami == true ? "Evet" : "Hayır" }).ToList();
            GridView6.DataSource = menuler;
            GridView6.DataBind();
        }

        private void yazilar_Get()
        {
            var yazilar = VT.Yazilar.Select(g => new { 
                yazi_ID=g.Yazi_ID,
                baslik=g.baslik,
                username=g.Yazan.username,
                icerik=g.icerik,
                onay=g.onay,
                gizlimi=g.gizlimi,
                oyacikmi=g.oyacikmi,
                yorumtur=g.yorum_turu,
                kategorisi=g.KAT.kate_adi,
                oy=g.oy,
                tarih=g.tarih
            }).ToList();
            GridView1.DataSource = yazilar;
            GridView1.DataBind();
        }

        private void kate_Get()
        {
            var kateler = VT.Kategoriler.Select(g => new { 
                kate_adi=g.kate_adi, 
                KID = g.KID,
                kate_acikla = g.kate_acikla,
                kate_title = g.kate_title,
                yazisayisi=VT.Yazilar.Where(k=> k.KAT==g).Count()
            }).ToList();
            GridView3.DataSource = kateler;
            GridView3.DataBind();
        }
        private void view1()
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("index.aspx");
        }

        protected void btnolstur_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            uyeler_Get();
        }

        protected void kateler_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
            kate_Get();
        }

        protected void yazilar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            yazilar_Get();
            var kate = VT.Kategoriler.Select(g => new { g.kate_adi, g.KID }).ToList();
            yazi_kate.DataSource = kate;
            yazi_kate.DataBind();
        }

        protected void kate_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(kateadi.Text))
            {
                Kategoriler kat = new Kategoriler();
                kat.kate_adi = kateadi.Text;
                kat.kate_acikla = kate_acik.Text;
                kat.kate_title = kate_tit.Text;
                VT.Kategoriler.Add(kat);
                int save = VT.SaveChanges();
                if (save > 0)
                {
                    yenikate.Text = "<div class=\"alert alert-success\" id=\"" + yenikate.ClientID + "\"><h4><strong>Başarılı!</strong> Kategori ekleme başarılı.<br /></h4></div>";
                    kate_Get();
                    kate_acik.Text = "";
                    kateadi.Text = "";
                    kate_tit.Text = "";
                }
                else

                    yenikate.Text = "<div class=\"alert alert-error\" id=\"" + yenikate.ClientID + "\"><h4><strong>Hata!</strong> Kategori ekleme işlemi başarısız.<br /></h4></div>";
                Random rnd = new Random();
                string ltr = rnd.Next(1, 99999).ToString();
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), ltr, "gizleltr(" + yenikate.ClientID + ");", true);
            }
        }

        void duyuru_Get()
        {
            var duyurular = VT.Duyurular.ToList();
            GridView5.DataSource = duyurular;
            GridView5.DataBind();
            
        }
        protected void duyuru_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(duyurubaslik.Text))
            {
                Duyurular duyru = new Duyurular();
                duyru.baslik = duyurubaslik.Text;
                duyru.icerik = duyuruicerik.Text;
                duyru.tarih = DateTime.Now;
                VT.Duyurular.Add(duyru);
                int save = VT.SaveChanges();
                if (save > 0)
                {
                    yeniduyrultr.Text = "<div class=\"alert alert-success\" id=\"" + yeniduyrultr.ClientID + "\"><h4><strong>Başarılı!</strong> Duyuru ekleme başarılı.<br /></h4></div>";
                    duyurubaslik.Text = duyuruicerik.Text = "";
                    duyuru_Get();
                    
                }
                else

                    yeniduyrultr.Text = "<div class=\"alert alert-error\" id=\"" + yeniduyrultr.ClientID + "\"><h4><strong>Hata!</strong> Duyuru ekleme işlemi başarısız.<br /></h4></div>";
                Random rnd = new Random();
                string ltr = rnd.Next(1, 99999).ToString();
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), ltr, "gizleltr(" + yeniduyrultr.ClientID + ");", true);
            }
        }

        protected void duyurular_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 4;
            duyuru_Get();
        }
        string[] klasor,klasor2;
        string[] resimler,resimler2;
        private void resim_Get()
        {
            klasor = Directory.GetFiles(Server.MapPath("resimler"));
            //Response.Write(klasor[0]);
            resimler = new string[klasor.Count()];
            for (int i = 0; i < klasor.Count(); i++)
            {
                resimler[i] = ("resimler/" + Path.GetFileName(klasor[i]));
            }
            DataList1.DataSource = resimler;
            DataList1.DataBind();
        }
        private void slider_Get()
        {
            klasor2 = Directory.GetFiles(Server.MapPath("slider_resim"));
            resimler2 = new string[klasor2.Count()];
            for (int i = 0; i < klasor2.Count(); i++)
            {
                resimler2[i] = ("slider_resim/" + Path.GetFileName(klasor2[i]));
            }
            DataList2.DataSource = resimler2;
            DataList2.DataBind();
        }

        protected void galeri_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 5;
            resim_Get();
        }

        protected void resimyukle_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("/resimler/"+ FileUpload1.FileName));
                //FileUpload1.SaveAs("E:\\blog\\" + FileUpload1.FileName);
            }
            resim_Get();
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "siliver")
            {
                Label resimyol = (Label)e.Item.FindControl("resimyol");
                File.Delete(Server.MapPath(resimyol.Text));
                resim_Get();
            }
        }
        DataSet ds = new DataSet();
        protected void bilgiler_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            var bilgiler = VT.System.ToList();
            uyekayit.SelectedIndex = bilgiler[0].uyealim.ToString().ToUpper() =="TRUE"?0:1;
            uyegirisi.SelectedIndex = bilgiler[0].uyegiris.ToString().ToUpper() == "TRUE" ? 0 : 1;

            genel_islem();
            menuGetir();
        }

        private void genel_islem()
        {
            var system = VT.System.FirstOrDefault();
            sitebaslik.Text=system.sitebaslik;
            sitekeys.Text=system.keyw;
            description.Text=system.desc;
            hakkimizda.Text=system.hakkimizda;
            sitecopy.Text=system.copy;
            bannerresim.Text = system.bannerresim;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dinamikbaslik.Text) && !string.IsNullOrEmpty(dinamikicerik.Text))
            {
                DinamikMenuler menuekle = new DinamikMenuler();
                menuekle.baslik = dinamikbaslik.Text;
                menuekle.icerik = dinamikicerik.Text;
                menuekle.menuYol = dinamikyol.Text;
                menuekle.normalsayfami = chknormal.Checked;
                VT.Menuler.Add(menuekle);
                VT.SaveChanges();
                menuGetir();
            }
        }

        protected void GridView6_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rakam = int.Parse(GridView6.SelectedValue.ToString());
            var cekkonu = VT.Menuler.Where(g => g.menuID == rakam).FirstOrDefault();
            if (cekkonu != null)
            {
                dinamikbaslik.Text = cekkonu.baslik;
                dinamikicerik.Text = cekkonu.icerik;
                dinamikyol.Text = cekkonu.menuYol;
                chknormal.Checked = cekkonu.normalsayfami;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int rakam = int.Parse(GridView6.SelectedValue.ToString());
            var cekkonu = VT.Menuler.Where(g => g.menuID == rakam).FirstOrDefault();
            if (cekkonu != null)
            {
                cekkonu.baslik = dinamikbaslik.Text;
                cekkonu.icerik=dinamikicerik.Text;
                cekkonu.menuYol = dinamikyol.Text;
                cekkonu.normalsayfami = chknormal.Checked;
                int save=VT.SaveChanges();
                if (save > 0)
                {
                    dinamikltr.Text = "<div class=\"alert alert-success\" id=\"" + dinamikltr.ClientID + "\"><h4><strong>Başarılı!</strong> Dinamik sayfa işlemi gerçekleşti.<br /></h4></div>";
                    menuGetir();
                }
                else
                    dinamikltr.Text = "<div class=\"alert alert-error\" id=\"" + dinamikltr.ClientID + "\"><h4><strong>Hata!</strong> Dinamik sayfa işlemi gerçekleşemedi.<br /></h4></div>";
                Random rnd = new Random();
                string ltr = rnd.Next(1, 99999).ToString();
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), ltr, "gizleltr(" + dinamikltr.ClientID + ");", true);
                
            }
        }

        protected void btnDzn_Click(object sender, EventArgs e)
        {
            var system = VT.System.ToList();
            system[0].uyealim = bool.Parse(uyekayit.SelectedIndex==0?"true":"false");
            system[0].uyegiris = bool.Parse(uyegirisi.SelectedIndex==0?"true":"false");
            int save = VT.SaveChanges();
            if (save > 0)
            {
                genel1.Text = "<div class=\"alert alert-success\" id=\"" + genel1.ClientID + "\"><h4><strong>Başarılı!</strong> İşlem tamamlandı<br /></h4></div>";
            }
            else
                genel1.Text = "<div class=\"alert alert-error\" id=\"" + genel1.ClientID + "\"><h4><strong>Hata!</strong> İşlem başarısız<br /></h4></div>";
            Random rnd = new Random();
            string ltr = rnd.Next(1, 99999).ToString();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), ltr, "gizleltr(" + genel1.ClientID + ");", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var system = VT.System.FirstOrDefault();
            system.sitebaslik = sitebaslik.Text;
            system.keyw = sitekeys.Text;
            system.desc = description.Text;
            system.hakkimizda = hakkimizda.Text;
            system.copy = sitecopy.Text;
            system.bannerresim = bannerresim.Text;
            VT.SaveChanges();
            genel2.Text = "<div class=\"alert alert-success\" id=\"" + genel2.ClientID + "\"><h4><strong>Başarılı!</strong> İşlem tamamlandı<br /></h4></div>";
            Random rnd = new Random();
            string ltr = rnd.Next(1, 99999).ToString();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), ltr, "gizleltr(" + genel2.ClientID + ");", true);
        }

        protected void GridView6_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string lbmenu = GridView6.DataKeys[e.RowIndex].Values["menuID"].ToString();
            int index = Convert.ToInt32(lbmenu);
            var cekkonu = VT.Menuler.Where(g => g.menuID == index).FirstOrDefault();
            if (cekkonu != null)
            {
                VT.Menuler.Remove(cekkonu);
                int save = VT.SaveChanges();
                if (save > 0)
                {
                    dinamikltr.Text = "<div class=\"alert alert-success\" id=\"" + dinamikltr.ClientID + "\"><h4><strong>Başarılı!</strong> Dinamik sayfa silme işlemi gerçekleşti.<br /></h4></div>";
                    menuGetir();
                }
                else
                    dinamikltr.Text = "<div class=\"alert alert-error\" id=\"" + dinamikltr.ClientID + "\"><h4><strong>Hata!</strong> Dinamik sayfa silme işlemi gerçekleşemedi.<br /></h4></div>";
                Random rnd = new Random();
                string ltr = rnd.Next(1, 99999).ToString();
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), ltr, "gizleltr(" + dinamikltr.ClientID + ");", true);
            }
            else
            {
                dinamikltr.Text = "Menü bulunamadı";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex == -1)
                return;
            int rakam = int.Parse(GridView1.SelectedValue.ToString());
            var cekkonu = VT.Yazilar.Where(g=> g.Yazi_ID==rakam).FirstOrDefault();
            if (cekkonu != null)
            {
                yazibaslik.Text=cekkonu.baslik;
                yazi_onay.Checked=cekkonu.onay;
                yazi_gizli.Checked=cekkonu.gizlimi;
                yazi_acikla.Text=cekkonu.icerik;
                yazi_oylama.Checked=cekkonu.oyacikmi==1?true:false;
                yazi_yorum.Checked=cekkonu.yorum_turu==1?true:false;
                yazi_kate.SelectedValue = cekkonu.KAT.KID.ToString();
            }
            
        }

        protected void yaziduzen_Click(object sender, EventArgs e)
        {
            int rakam = int.Parse(GridView1.SelectedValue.ToString());
            var cekkonu = VT.Yazilar.Where(g => g.Yazi_ID == rakam).FirstOrDefault();
            if (cekkonu != null)
            {
                cekkonu.baslik=yazibaslik.Text;
                cekkonu.onay=yazi_onay.Checked;
                cekkonu.gizlimi=yazi_gizli.Checked;
                cekkonu.icerik=yazi_acikla.Text;
                cekkonu.oyacikmi = (yazi_oylama.Checked==true)?(byte)1:(byte)0;
                cekkonu.yorum_turu = (yazi_yorum.Checked == true)?(byte)1:(byte)0;
                cekkonu.KAT.KID=int.Parse(yazi_kate.SelectedValue);
                int save = VT.SaveChanges();
                if (save > 0)
                {
                    yazilarltr.Text = "<div class=\"alert alert-success\" id=\"" + yazilarltr.ClientID + "\"><h4><strong>Başarılı!</strong> Yazı düzenleme işlemi başarılı.<br /></h4></div>";
                    yazilar_Get();
                }
                else

                    yazilarltr.Text = "<div class=\"alert alert-error\" id=\"" + yazilarltr.ClientID + "\"><h4><strong>Hata!</strong> Yazı düzenleme işlemi başarısız.<br /></h4></div>";
                Random rnd = new Random();
                string ltr = rnd.Next(1, 99999).ToString();
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), ltr, "gizleltr(" + yazilarltr.ClientID + ");", true);
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rakam = int.Parse(GridView2.SelectedValue.ToString());
            var cekuye = VT.Yazarlar.Where(g => g.ID == rakam).FirstOrDefault();
            if (cekuye != null)
            {
                uemail.Text = cekuye.email;
                uad.Text = cekuye.ad;
                usoyad.Text = cekuye.soyad;
                utelefon.Text = cekuye.telefon;
                adminmi.Checked = cekuye.adminmi;
                gizlimi.Checked = cekuye.gizlimi;
                webpage.Text = cekuye.webpage;
                facebook.Text = cekuye.face;
                twitter.Text = cekuye.twitter;
                inst.Text = cekuye.inst;
            }
        }

        protected void uyeduzen_Click(object sender, EventArgs e)
        {
            if (GridView2.SelectedIndex == -1)
                return;
            int rakam = int.Parse(GridView2.SelectedValue.ToString());
            var cekuye = VT.Yazarlar.Where(g => g.ID == rakam).FirstOrDefault();
            if (cekuye != null)
            {
                cekuye.email=uemail.Text;
                cekuye.ad=uad.Text;
                cekuye.soyad = usoyad.Text;
                cekuye.telefon = utelefon.Text;
                cekuye.adminmi = adminmi.Checked;
                cekuye.gizlimi = gizlimi.Checked;
                cekuye.webpage = webpage.Text;
                cekuye.face = facebook.Text;
                cekuye.twitter = twitter.Text;
                cekuye.inst = inst.Text;
                int save = VT.SaveChanges();
                if (save > 0)
                {
                    ltruyeler.Text = "<div class=\"alert alert-success\" id=\"" + ltruyeler.ClientID + "\"><h4><strong>Başarılı!</strong> Başarılı bir şekilde bilgiler güncellendi!<br /></h4></div>";
                    uyeler_Get();
                }
                else
                {
                    ltruyeler.Text = "<div class=\"alert alert-danger\" id=\"" + ltruyeler.ClientID + "\"><h4><strong>Hata!</strong> Bir sorun ile karşılaşıldı.<br /></h4></div>";
                }
                Random rnd = new Random();
                string ltr = rnd.Next(1, 99999).ToString();
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), ltr, "gizleltr(" + ltruyeler.ClientID + ");", true);
           
            }
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rakam = int.Parse(GridView3.SelectedValue.ToString());
            var cekkate = VT.Kategoriler.Where(g => g.KID == rakam).FirstOrDefault();
            if (cekkate != null)
            {
                kateadi.Text = cekkate.kate_adi;
                kate_acik.Text = cekkate.kate_acikla;
                kate_tit.Text = cekkate.kate_title;
            }
        }

        protected void kate_duzen_Click(object sender, EventArgs e)
        {
            if (GridView3.SelectedIndex == -1)
                return;
            int rakam = int.Parse(GridView3.SelectedValue.ToString());
            var cekkate = VT.Kategoriler.Where(g => g.KID == rakam).FirstOrDefault();
            if (cekkate != null)
            {
                cekkate.kate_adi = kateadi.Text;
                cekkate.kate_acikla = kate_acik.Text;
                cekkate.kate_title = kate_tit.Text;
                int save = VT.SaveChanges();
                if (save > 0)
                {
                    ltrkategori.Text = "<div class=\"alert alert-success\" id=\"" + ltrkategori.ClientID + "\"><h4><strong>Başarılı!</strong> Başarılı bir şekilde bilgiler güncellendi!<br /></h4></div>";
                    kate_Get();
                }
                else
                {
                    ltrkategori.Text = "<div class=\"alert alert-danger\" id=\"" + ltrkategori.ClientID + "\"><h4><strong>Hata!</strong> Bir sorun ile karşılaşıldı.<br /></h4></div>";
                }
                Random rnd = new Random();
                string ltr = rnd.Next(1, 99999).ToString();
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), ltr, "gizleltr(" + ltrkategori.ClientID + ");", true);
            }
        }

        protected void GridView5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rakam = int.Parse(GridView5.SelectedValue.ToString());
            var cekduyuru = VT.Duyurular.Where(g => g.duyuru_id == rakam).FirstOrDefault();
            if (cekduyuru != null)
            {
                duyurubaslik.Text = cekduyuru.baslik;
                duyuruicerik.Text = cekduyuru.icerik;
            }
        }

        protected void duyru_duzen_Click(object sender, EventArgs e)
        {
            if (GridView5.SelectedIndex == -1)
                return;
            int rakam = int.Parse(GridView5.SelectedValue.ToString());
            var cekduyuru = VT.Duyurular.Where(g => g.duyuru_id == rakam).FirstOrDefault();
            if (cekduyuru != null)
            {
                cekduyuru.baslik = duyurubaslik.Text;
                cekduyuru.icerik = duyuruicerik.Text;
                int save = VT.SaveChanges();
                if (save > 0)
                {
                    duyurultr.Text = "<div class=\"alert alert-success\" id=\"" + duyurultr.ClientID + "\"><h4><strong>Başarılı!</strong> Duyuru düzenleme işlemi başarılı.<br /></h4></div>";
                    duyuru_Get();
                }
                else

                    duyurultr.Text = "<div class=\"alert alert-error\" id=\"" + duyurultr.ClientID + "\"><h4><strong>Hata!</strong> Duyuru düzenleme işlemi başarısız.<br /></h4></div>";
                Random rnd = new Random();
                string ltr = rnd.Next(1, 99999).ToString();
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), ltr, "gizleltr(" + duyurultr.ClientID + ");", true);
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 6;
            slider_Get();
        }

        protected void slider_yukle_Click(object sender, EventArgs e)
        {
            if (FileUpload2.HasFile)
            {
                FileUpload2.SaveAs(MapPath("~/slider_resim/" + FileUpload2.FileName));
            }
            slider_Get();
        }

        protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "siliver")
            {
                Label resimyol = (Label)e.Item.FindControl("resimyol2");
                File.Delete(Server.MapPath(resimyol.Text));
                slider_Get();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                //Literal1.Text = GridView1.Rows[index].Cells[1].Text.ToString();
                int cevir = Convert.ToInt32(GridView1.Rows[index].Cells[0].Text.ToString());
                var ara = VT.Yazilar.Where(x => x.Yazi_ID == cevir).FirstOrDefault();
                if (ara != null)
                {
                    VT.Yazilar.Remove(ara);
                    int save = VT.SaveChanges();
                    if (save > 0)
                    {
                        yazilarltr.Text = "<div class=\"alert alert-success\" id=\"" + yazilarltr.ClientID + "\"><h4><strong>Başarılı!</strong> Yazı silme işlemi başarılı.<br /></h4></div>";
                        yazilar_Get();
                    }
                    else

                        yazilarltr.Text = "<div class=\"alert alert-error\" id=\"" + yazilarltr.ClientID + "\"><h4><strong>Hata!</strong> Yazı silme işlemi başarısız.<br /></h4></div>";
                    Random rnd = new Random();
                    string ltr = rnd.Next(1, 99999).ToString();
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), ltr, "gizleltr(" + yazilarltr.ClientID + ");", true);
                }
            }
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                //Literal1.Text = GridView1.Rows[index].Cells[1].Text.ToString();
                int cevir = Convert.ToInt32(GridView3.Rows[index].Cells[0].Text.ToString());
                var ara = VT.Kategoriler.Where(x => x.KID == cevir).FirstOrDefault();
                if (ara != null)
                {
                    VT.Kategoriler.Remove(ara);
                    int save = VT.SaveChanges();
                    if (save > 0)
                    {
                        ltrkategori.Text = "<div class=\"alert alert-success\" id=\"" + ltrkategori.ClientID + "\"><h4><strong>Başarılı!</strong> Kategori silme işlemi başarılı.<br /></h4></div>";
                        kate_Get();
                    }
                    else

                        ltrkategori.Text = "<div class=\"alert alert-error\" id=\"" + ltrkategori.ClientID + "\"><h4><strong>Hata!</strong> Kategori silme işlemi başarısız.<br /></h4></div>";
                    Random rnd = new Random();
                    string ltr = rnd.Next(1, 99999).ToString();
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), ltr, "gizleltr(" + ltrkategori.ClientID + ");", true);
                }
            }
        }

        protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                //Literal1.Text = GridView1.Rows[index].Cells[1].Text.ToString();
                int cevir = Convert.ToInt32(GridView5.Rows[index].Cells[0].Text.ToString());
                var ara = VT.Duyurular.Where(x => x.duyuru_id == cevir).FirstOrDefault();
                if (ara != null)
                {
                    VT.Duyurular.Remove(ara);
                    int save = VT.SaveChanges();
                    if (save > 0)
                    {
                        duyurultr.Text = "<div class=\"alert alert-success\" id=\"" + duyurultr.ClientID + "\"><h4><strong>Başarılı!</strong> Duyuru silme işlemi başarılı.<br /></h4></div>";
                        duyuru_Get();
                    }
                    else

                        duyurultr.Text = "<div class=\"alert alert-error\" id=\"" + duyurultr.ClientID + "\"><h4><strong>Hata!</strong> Duyuru silme işlemi başarısız.<br /></h4></div>";
                    Random rnd = new Random();
                    string ltr = rnd.Next(1, 99999).ToString();
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), ltr, "gizleltr(" + duyurultr.ClientID + ");", true);
                }
            }
        }
    }
}