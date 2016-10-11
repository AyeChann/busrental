using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Data;


namespace busrental
{
    public partial class customer_registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnregister_Click(object sender, EventArgs e)
        {
            string strconnect = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
            SqlConnection con = new SqlConnection(strconnect);
            con.Open();
            SqlCommand cmd = new SqlCommand("Ins_Customer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@customername", txtname.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.Parameters.AddWithValue("@phoneno",txtphno.Text);
            cmd.Parameters.AddWithValue("@address", txtaddress.Text);
            cmd.Parameters.AddWithValue("@password", txtpassword.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            lblinfo.Text = "Registered Successfully!";
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtpassword.Text = "";
            txtemail.Text = "";
            txtaddress.Text = "";
            txtphno.Text = "";

        }
    }
}