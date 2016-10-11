using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace busrental
{
    public class Driver
    {
        #region property
        public static string id;
        public int driverno { get; set; }
        public string name { get; set; }
        public string phoneno { get; set; }
        public string address { get; set; }
        #endregion

        public void Upd_Driver()
        {
            string connectinstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(connectinstring);
                con.Open();
                SqlCommand cmd = new SqlCommand("Upd_Driver", con);
                cmd.Parameters.AddWithValue("@driverno", driverno);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@phone", phoneno);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();           
        }
        public void Del_Driver(string strdriverno)
        {
            string connectinstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(connectinstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("Del_Driver", con);
            cmd.Parameters.AddWithValue("@driverno", strdriverno);           
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}