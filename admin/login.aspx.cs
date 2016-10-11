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

namespace busrental.admin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnregister_Click(object sender, EventArgs e)
        {
            string strconnect = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
            SqlConnection con = new SqlConnection(strconnect);
            con.Open();
            SqlCommand cmd = new SqlCommand("Checkuser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", txtname.Text);
            cmd.Parameters.AddWithValue("@password", txtpassword.Text);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Read();
                lblinfo.Text = "Login Successful!";
                string name = txtname.Text;
                Session.Add("name",name);
                Response.Redirect("welcome.aspx");
            }
            else
            {
                lblinfo.Text = "Invalid login successful!";
                Response.Redirect("login.aspx");
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtpassword.Text = "";
        }
    }
}