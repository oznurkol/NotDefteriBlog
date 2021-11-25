using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using NotDefteriBlog.Entity;

namespace NotDefteriBlog
{
    public partial class hakkimizda : System.Web.UI.Page
    {
        public DataSet ds;
        public static string hak;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataBase VT = new DataBase();
            System_ config = VT.System.Where(x => x.ID == 1).FirstOrDefault();
            Literal1.Text = config.hakkimizda;

        }
    }
}