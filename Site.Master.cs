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
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void lblregister_Click(object sender, EventArgs e)
        {
            Response.Redirect("customer_registration.aspx");
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string strconnect = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
            SqlConnection con = new SqlConnection(strconnect);
            con.Open();
            SqlCommand cmd = new SqlCommand("Checkuser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", txtuser.Text);
            cmd.Parameters.AddWithValue("@password", txtpassword.Text);
            hfpassword.Value = txtpassword.Text;
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Read();
                lblinfo.Text = "Login Successful! as " + txtuser.Text;
                //Response.Redirect("~/home.aspx");
                btnlogout.Visible = true;
                Session["name"] = txtuser.Text;
                lblusername.Text = txtuser.Text;
                lbluser.Visible = false;
                txtuser.Visible = false;
                lblpassword.Visible = false;
                txtpassword.Visible = false;
                btnlogin.Visible = false;
                btnlogout.Visible = true;
                lblregister.Visible = false;
            }
            else
            {
                lblinfo.Text = "Invalid login successful!";
            }
            
            con.Close();

        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Remove("name");
            btnlogout.Visible = false;
            lbluser.Visible = true;
            txtuser.Visible = true;
            lblpassword.Visible = true;
            txtpassword.Visible = true;
            btnlogin.Visible = true;
            lblregister.Visible = true;
            lblinfo.Text = "";
            
            //Response.Redirect("home.aspx");
        }

        protected void booking_Click(object sender, EventArgs e)
        {
            if (Session["name"] != null)
            {
                Response.Redirect("booking.aspx");
            }
            else
            {
                lblinfo.Text = "please login";
            }
            

        }

        protected void middlecontent_Load(object sender, EventArgs e)
        {
            if (Session["name"] != null)
            {
                lblinfo.Text = Session["name"].ToString();

                lbluser.Visible = false;
                txtuser.Visible = false;
                lblpassword.Visible = false;
                txtpassword.Visible = false;
                btnlogin.Visible = false;
                btnlogout.Visible = true;
                lblregister.Visible = false;
            }
            else
            {
                if (btnlogout != null) btnlogout.Visible = false;
            }

        }
    }
}
