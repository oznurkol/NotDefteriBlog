using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NotDefteriBlog.Entity;
using System.Text;

namespace NotDefteriBlog
{
    public partial class icerik : System.Web.UI.Page
    {
        public StringBuilder builder = new StringBuilder();
        DataBase VT = new DataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"].ToString()))
                {
                    int cevir = int.Parse(Request.QueryString["id"].ToString());
                    var menucek = VT.Menuler.Where(g => g.menuID == cevir && g.normalsayfami==false).FirstOrDefault();
                    if (menucek != null)
                    {
                        builder.Append("<div class=\"row\"><div class=\"col-md-9 col-md-offset-1 bg-white main-border-4 mgb-30\"><h2>" + menucek.baslik + "</h2><hr />" + menucek.icerik + "</div></div>");
                    }
                }
            }
            catch
            {

            }
        }
    }
}