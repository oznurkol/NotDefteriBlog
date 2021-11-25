using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NotDefteriBlog.Entity;

namespace NotDefteriBlog
{
    public partial class duyurular : System.Web.UI.Page
    {
        public bool idvar = false;
        DataBase VT = new DataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"]==null)
            {
                var list = VT.Duyurular.ToList();
                Repeater1.DataSource = list;
                Repeater1.DataBind();
                if (list.Count == 0)
                {
                    Literal1.Text = "<h2>Duyuru bulunamadı!</h2>";
                }
            }
            else
            {

                int idcek=int.Parse(Request.QueryString["id"]);
                var list = VT.Duyurular.Where(g=> g.duyuru_id==idcek).FirstOrDefault();
                Literal1.Text = "<h2>" + list.baslik + "</h2>";
                Literal2.Text = "<hr />" + list.icerik + "<hr /><div class=\"pull-right\">Tarih:" + list.tarih + "</div>";
            }
        }
    }
}