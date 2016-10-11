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
    public partial class driver_registration : System.Web.UI.Page
    {
        Driver dr = new Driver();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDriverDetails();
            }
        }



        protected void BindDriverDetails()
        {
            string connectinstring = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
            SqlConnection con = new SqlConnection(connectinstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Driver", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvDetails.DataSource = ds;
                gvDetails.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                gvDetails.DataSource = ds;
                gvDetails.DataBind();
                int columncount = gvDetails.Rows[0].Cells.Count;
                gvDetails.Rows[0].Cells.Clear();
                gvDetails.Rows[0].Cells.Add(new TableCell());
                gvDetails.Rows[0].Cells[0].ColumnSpan = columncount;
                gvDetails.Rows[0].Cells[0].Text = "No Records Found";
            }
        }
        protected void gvDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDetails.EditIndex = e.NewEditIndex;
            BindDriverDetails();
        }
        protected void gvDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string connectinstring = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
            SqlConnection con = new SqlConnection(connectinstring);
            int userid = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Value.ToString());
            string name = gvDetails.DataKeys[e.RowIndex].Values["Name"].ToString();
            TextBox txtname = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtname");
            TextBox txtphone = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtphone");
            TextBox txtaddress = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtaddress");
            con.Open();
            SqlCommand cmd = new SqlCommand("update Driver set Name='" + txtname.Text + "',Phone='" + txtphone.Text + "',Address='" + txtaddress.Text + "' where DriverNo=" + userid, con);
            cmd.ExecuteNonQuery();
            con.Close();
            //lblresult.ForeColor = Color.Green;
            //lblresult.Text = username + " Details Updated successfully";
            gvDetails.EditIndex = -1;
            BindDriverDetails();
        }
        protected void gvDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDetails.EditIndex = -1;
            BindDriverDetails();
        }
        protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string connectinstring = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
            SqlConnection con = new SqlConnection(connectinstring);
            int userid = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Values["DriverNo"].ToString());
            string username = gvDetails.DataKeys[e.RowIndex].Values["Name"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Driver where DriverNo=" + userid, con);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result == 1)
            {
                BindDriverDetails();
                //lblresult.ForeColor = Color.Red;
                //lblresult.Text = username + " details deleted successfully";
            }
        }
        protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string connectinstring = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
            SqlConnection con = new SqlConnection(connectinstring);
            if (e.CommandName.Equals("AddNew"))
            {
                TextBox txtname = (TextBox)gvDetails.FooterRow.FindControl("txtftrname");
                TextBox txtphone = (TextBox)gvDetails.FooterRow.FindControl("txtftrphone");
                TextBox txtaddress = (TextBox)gvDetails.FooterRow.FindControl("txtftraddress");
                con.Open();
                SqlCommand cmd =
                new SqlCommand(
                "insert into Driver(Name,Phone,Address) values('" + txtname.Text + "','" +
                txtphone.Text + "','" + txtaddress.Text + "')", con);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result == 1)
                {
                    BindDriverDetails();
                    //lblresult.ForeColor = Color.Green;
                    //lblresult.Text = txtUsrname.Text + " Details inserted successfully";
                }
                else
                {
                    //lblresult.ForeColor = Color.Red;
                    //lblresult.Text = txtUsrname.Text + " Details not inserted";
                }
            }
        }




        //#region Get_Driver()
        //public DataTable Get_Driver()
        //{
        //    string connectinstring = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
        //    SqlConnection con = new SqlConnection(connectinstring);
        //    con.Open();
            
        //        SqlCommand cmd = new SqlCommand("Get_Driver", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        DataTable dt = new DataTable();
        //        SqlDataAdapter sdap = new SqlDataAdapter(cmd);
        //        sdap.Fill(dt);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //        return dt;
            
            
        //}
        //#endregion

        //#region
        //public void bindGrid()
        //{
        //    gvdusers.DataSource = Get_Driver(); ;
        //    gvdusers.DataBind();
        //}

        //#endregion

        //protected void btnregister_Click(object sender, EventArgs e)
        //{
        //    string strconnect = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
        //    SqlConnection con = new SqlConnection(strconnect);
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("Ins_Driver", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@name", txtname.Text);
        //    cmd.Parameters.AddWithValue("@phone", txtphone.Text);
        //    cmd.Parameters.AddWithValue("@address", txtaddress.Text);

        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    lblinfo.Text = "Registered Successfully!";
        //}

        //protected void Cancel_Click(object sender, EventArgs e)
        //{
        //    txtname.Text = "";
        //    txtphone.Text = "";
        //    txtaddress.Text = "";

        //}

        //#region row edit

        //protected void gvdusers_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    gvdusers.EditIndex = e.NewEditIndex;
        //    bindGrid();

        //}

        //#endregion

        

        //#region
        //protected void gvdusers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    int newsid = Convert.ToInt32(gvdusers.DataKeys[e.RowIndex].Value.ToString());
        //    string name = gvdusers.DataKeys[e.RowIndex].Values["Name"].ToString();
        //    string phone = gvdusers.DataKeys[e.RowIndex].Values["Phone"].ToString();
        //    string address = gvdusers.DataKeys[e.RowIndex].Values["Address"].ToString();

        //    TextBox txtname = (TextBox)gvdusers.Rows[e.RowIndex].FindControl("txtname");
        //    TextBox txtphone = (TextBox)gvdusers.Rows[e.RowIndex].FindControl("txtphone");
        //    TextBox txtaddress = (TextBox)gvdusers.Rows[e.RowIndex].FindControl("txtaddress");
          
        //    dr.driverno = Convert.ToInt32(newsid);
        //    dr.name = txtname.Text;
        //    dr.phoneno = txtphone.Text;
        //    dr.address = txtaddress.Text;
        //    dr.Upd_Driver();
        //    gvdusers.EditIndex = -1;
        //    bindGrid();
        //}
        //#endregion

        //#region Cancel
        //protected void gvdusers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    gvdusers.EditIndex = -1;
        //    bindGrid();
        //}
        //#endregion

        //#region Delete
        //protected void gvdusers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    int id = Convert.ToInt32(gvdusers.DataKeys[e.RowIndex].Values["driverno"].ToString());
        //    dr.Del_Driver(id.ToString());
        //    bindGrid();
        //}
        //#endregion

        
    }
}