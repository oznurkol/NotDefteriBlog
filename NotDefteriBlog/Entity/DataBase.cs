using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NotDefteriBlog.Entity
{
    public class DataBase : DbContext
    {
        public DbSet<Yazarlar> Yazarlar { get; set; }
        public DbSet<Kategoriler> Kategoriler { get; set; }
        public DbSet<Yazilar> Yazilar { get; set; }
        public DbSet<Etiketler> Etiketler { get; set; }
        public DbSet<Yorumlar> Yorumlar { get; set; }
        public DbSet<YorumYanit> Yanitlar { get; set; }
        public DbSet<Favori> Favori { get; set; }
        public DbSet<Oylama> Oylama { get; set; }
        public DbSet<System_> System { get; set; }
        public DbSet<Duyurular> Duyurular { get; set; }
        public DbSet<Ziyaret> Ziyartci { get; set; }
        public DbSet<DinamikMenuler> Menuler { get; set; }

        public DataBase(){
            Database.SetInitializer(new Olustur());
        }
    }

    public class Olustur : CreateDatabaseIfNotExists<DataBase>
    {
        protected override void Seed(DataBase context)
        {
            Yazarlar yazar = new Yazarlar();
            yazar.adminmi = true;
            yazar.username = "admin";
            yazar.Pass = "admin";
            yazar.email = "a@a.com";
            context.Yazarlar.Add(yazar);
            System_ sys = new System_();
            sys.ID = 1;
            sys.uyealim = true;
            sys.uyegiris = true;
            sys.girensayisi = 0;
            sys.bannerresim = "../slider_resim/1.jpg";
            sys.copy = "Copyright 2017";
            sys.hakkimizda = "Hakkımızda 1 iki şey";
            sys.sitebaslik = "Köşede Dursun";
            sys.ziyarettarih = DateTime.Now.Date.ToString();
            context.System.Add(sys);
            context.SaveChanges();
        }
    }

    public class Kontroller
    {

    }
}