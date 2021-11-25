using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace NotDefteriBlog
{
    public class DB
    {
        public static SqlConnection baglan = new SqlConnection("Server=LAPTOP-8CEP8QGJ\\SQLEXPRESS;Database=notdefteri;Integrated Security = True");
        public DB()
        {
            if (baglan.State != ConnectionState.Open)
                baglan.Open();
        }
        public void Kontrol()
        {
            if (baglan.State != ConnectionState.Open)
                baglan.Open();
        }
        public SqlConnection Connect(){
            return baglan;
        }

        public DataSet Adapter_DS(string cumle, Dictionary<string, string> veri)
        {
            Kontrol();
            SqlDataAdapter ad = new SqlDataAdapter(cumle, DB.baglan);
            ad.SelectCommand.Parameters.Clear();
            foreach (var veriset in veri)
                ad.SelectCommand.Parameters.AddWithValue(veriset.Key.ToString(), veriset.Value.ToString());
            DataSet ds = new DataSet();
            ad.Fill(ds,"table");
            baglan.Close();
            return ds;
        }

        public DataSet Adapter_DS(string cumle)
        {
            Kontrol();
            SqlDataAdapter ad = new SqlDataAdapter(cumle, DB.baglan);
            DataSet ds = new DataSet();
            ad.Fill(ds, "table");
            baglan.Close();
            return ds;
        }

        public int Insert_Update(string cumle, Dictionary<string,string> veri)
        {
            Kontrol();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglan;
            cmd.CommandText = cumle;
            cmd.Parameters.Clear();
            foreach (var veriset in veri)
                cmd.Parameters.AddWithValue(veriset.Key.ToString(), veriset.Value.ToString());
            int tut = cmd.ExecuteNonQuery();
            baglan.Close();
            return tut;
        }

        public string GetTitle(int id=0)
        {
            DataSet ds = Adapter_DS("SELECT TOP 1 * FROM config ORDER BY id DESC");
            return ds.Tables[0].Rows[0]["title"].ToString();
        }

        public string GetDesc()
        {
            DataSet ds = Adapter_DS("SELECT TOP 1 * FROM config ORDER BY id DESC");
            return ds.Tables[0].Rows[0]["dsc"].ToString();
        }

        public bool LoginKontrol(string Session)
        {
            if (string.IsNullOrEmpty(Session))
                return false;
            else return true;
        }

    }
}