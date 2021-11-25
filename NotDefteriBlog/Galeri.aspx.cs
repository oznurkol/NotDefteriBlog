using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NotDefteriBlog
{
    public partial class Galeri : System.Web.UI.Page
    {
        string[] klasor;
        string[] resimler;
        protected void Page_Load(object sender, EventArgs e)
        {
            resim_Get();
            if (!IsPostBack)
            {
                Image1.ImageUrl = resimler[0];
                Session["konum"] = 0;
            }
        }

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

        protected void Ileri_Click(object sender, EventArgs e)
        {
            byte tutsayac = byte.Parse(Session["konum"].ToString());
            tutsayac++;
            if (tutsayac == DataList1.Items.Count)
                tutsayac = 0;
            Image1.ImageUrl = resimler[tutsayac];
            Session["konum"] = tutsayac;
        }

        protected void Geri_Click(object sender, EventArgs e)
        {
            byte tutsayac = byte.Parse(Session["konum"].ToString());
            tutsayac--;
            if (tutsayac == DataList1.Items.Count)
                tutsayac = 0;
            else if (tutsayac == 255)
                tutsayac = Convert.ToByte(DataList1.Items.Count - 1);
            Image1.ImageUrl = resimler[tutsayac];
            Session["konum"] = tutsayac;
        }

        protected void oynat_Click(object sender, EventArgs e)
        {
            if (Timer1.Enabled)
                Timer1.Enabled = false;
            else
                Timer1.Enabled = true;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            byte tutsayac = byte.Parse(Session["konum"].ToString());
            tutsayac++;
            if (tutsayac == DataList1.Items.Count)
                tutsayac = 0;
            Image1.ImageUrl = resimler[tutsayac];
            Session["konum"] = tutsayac;
        }
    }
}