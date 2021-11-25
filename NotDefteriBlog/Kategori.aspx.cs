using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NotDefteriBlog.Entity;

namespace NotDefteriBlog
{
    public partial class Kategori : System.Web.UI.Page
    {
        DataBase VT = new DataBase();
        List<Kategoriler> kate=new List<Kategoriler>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["kid"] == null)
            {
                kate = VT.Kategoriler.ToList();
                Repeater1.DataSource = kate;
                Repeater1.DataBind();
            }
            else
            {
                int kid = int.Parse(Request.QueryString["kid"].ToString());
                kate = VT.Kategoriler.Where(g=> g.KID==kid).ToList();
                Repeater1.DataSource = kate;
                Repeater1.DataBind();
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
            
                HiddenField hiddenid = (HiddenField)e.Item.FindControl("hiddenid");
                int KID=int.Parse(hiddenid.Value.ToString());
                Repeater rpt = (Repeater)e.Item.FindControl("Repeater2");
                
                var yazilar = VT.Kategoriler.Where(g => g.KID == KID).FirstOrDefault();
                if (yazilar != null)
                {
                    var yaziara = yazilar.Kate.Where(g => g.onay == true).ToList();
                    //var yaziara = VT.Yazilar.Where(g => g.KAT == yazilar).ToList();
                    rpt.DataSource = yaziara;
                    rpt.DataBind();
                }
           }
        }
    }
}