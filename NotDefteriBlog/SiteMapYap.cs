using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using NotDefteriBlog.Entity;
using System.Net;

namespace NotDefteriBlog
{
    public class SiteMapYap
    {
        public SiteMapYap(string sFileName)
        {
            try
            {
                DataBase VT = new DataBase();
                Encoding enc = Encoding.UTF8;
                XmlTextWriter objXMLTW = new XmlTextWriter(sFileName, enc);
                try
                {
                    objXMLTW.WriteStartDocument();
                    objXMLTW.WriteStartElement("siteMap");
                    objXMLTW.WriteStartElement("siteMapNode");
                    objXMLTW.WriteAttributeString("title", "Ana Sayfa");
                    objXMLTW.WriteAttributeString("description", "");
                    objXMLTW.WriteAttributeString("url", "index.aspx");
                    objXMLTW.WriteStartElement("siteMapNode");
                    objXMLTW.WriteAttributeString("title", "Giriş Yap");
                    objXMLTW.WriteAttributeString("description", "");
                    objXMLTW.WriteAttributeString("url", "GirisYap.aspx");
                    objXMLTW.WriteEndElement();
                    objXMLTW.WriteStartElement("siteMapNode");
                    objXMLTW.WriteAttributeString("title", "Kayıt Ol");
                    objXMLTW.WriteAttributeString("description", "");
                    objXMLTW.WriteAttributeString("url", "Kayit.aspx");
                    objXMLTW.WriteEndElement();
                    objXMLTW.WriteStartElement("siteMapNode");
                    objXMLTW.WriteAttributeString("title", "Galeri");
                    objXMLTW.WriteAttributeString("description", "");
                    objXMLTW.WriteAttributeString("url", "Galeri.aspx");
                    objXMLTW.WriteEndElement();
                    objXMLTW.WriteStartElement("siteMapNode");
                    objXMLTW.WriteAttributeString("title", "Hakkımızda");
                    objXMLTW.WriteAttributeString("description", "");
                    objXMLTW.WriteAttributeString("url", "Hakkimizda.aspx");
                    objXMLTW.WriteEndElement();
                    objXMLTW.WriteStartElement("siteMapNode");
                    objXMLTW.WriteAttributeString("title", "Üye Paneli");
                    objXMLTW.WriteAttributeString("description", "");
                    objXMLTW.WriteAttributeString("url", "Islem.aspx");
                    objXMLTW.WriteEndElement();
                    objXMLTW.WriteStartElement("siteMapNode");
                    objXMLTW.WriteAttributeString("title", "Yönetim Paneli");
                    objXMLTW.WriteAttributeString("description", "");
                    objXMLTW.WriteAttributeString("url", "Yonetim.aspx");
                    objXMLTW.WriteEndElement();
                    objXMLTW.WriteStartElement("siteMapNode");
                    objXMLTW.WriteAttributeString("title", "Kategoriler");
                    objXMLTW.WriteAttributeString("description", "");
                    objXMLTW.WriteAttributeString("url", "Kategori.aspx");

                    var kategoriler = VT.Kategoriler.ToList();
                    for (int i = 0; i < kategoriler.Count; i++)
                    {
                        objXMLTW.WriteStartElement("siteMapNode");
                        objXMLTW.WriteAttributeString("title", kategoriler[i].kate_adi.ToString());
                        objXMLTW.WriteAttributeString("description", kategoriler[i].kate_acikla.ToString());
                        objXMLTW.WriteAttributeString("url", "Kategori.aspx?kid=" + kategoriler[i].KID.ToString());
                        int kategori = kategoriler[i].KID;
                        var kateyazisi = VT.Yazilar.Where(g => g.KAT.KID == kategori).ToList();
                        for (int k = 0; k < kateyazisi.Count; k++)
                        {
                            objXMLTW.WriteStartElement("siteMapNode");
                            objXMLTW.WriteAttributeString("title", kateyazisi[k].baslik.ToString());
                            objXMLTW.WriteAttributeString("description", kateyazisi[k].icerik.Substring(0, 20));
                            objXMLTW.WriteAttributeString("url", "YaziGoruntule.aspx?id=" + kateyazisi[k].Yazi_ID.ToString());
                            objXMLTW.WriteEndElement();
                        }
                        objXMLTW.WriteEndElement();
                    }
                    objXMLTW.WriteEndElement();

                    objXMLTW.WriteStartElement("siteMapNode");
                    objXMLTW.WriteAttributeString("title", "Duyurular");
                    objXMLTW.WriteAttributeString("description", "");
                    objXMLTW.WriteAttributeString("url", "Duyurular.aspx");
                    var duyurular = VT.Duyurular.ToList();
                    for (int i = 0; i < duyurular.Count; i++)
                    {
                        objXMLTW.WriteStartElement("siteMapNode");
                        objXMLTW.WriteAttributeString("title", duyurular[i].baslik.ToString());
                        objXMLTW.WriteAttributeString("description", duyurular[i].icerik.Substring(0,50));
                        objXMLTW.WriteAttributeString("url", "Duyurular.aspx?id="+duyurular[i].duyuru_id.ToString());
                        objXMLTW.WriteEndElement();
                    }
                    objXMLTW.WriteEndElement();
                    var sayfalar = VT.Menuler.Where(g=> g.normalsayfami==false).ToList();
                    if(sayfalar.Count>0){
                        objXMLTW.WriteStartElement("siteMapNode");
                        objXMLTW.WriteAttributeString("title", "");
                        objXMLTW.WriteAttributeString("description", "Özel İçerik");
                        objXMLTW.WriteAttributeString("url", "icerik.aspx");
                        for (int i = 0; i < sayfalar.Count; i++)
                        {
                            objXMLTW.WriteStartElement("siteMapNode");
                            objXMLTW.WriteAttributeString("title", sayfalar[i].baslik.ToString());
                            objXMLTW.WriteAttributeString("description", sayfalar[i].icerik.Substring(0,50));
                            objXMLTW.WriteAttributeString("url", "icerik.aspx?id=" + sayfalar[i].menuID.ToString());
                            objXMLTW.WriteEndElement();
                        }
                        objXMLTW.WriteEndElement();
                    }
                    objXMLTW.WriteEndElement();
                    objXMLTW.WriteEndDocument();
                }
                finally
                {
                    objXMLTW.Flush();
                    objXMLTW.Close();
                }
            }
            catch
            {

            }
        }
    }
}