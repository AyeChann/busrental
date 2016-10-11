using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace busrental.admin
{
    public partial class bus_type_registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBustypeDetails();
            }
        }
        protected void BindBustypeDetails()
        {
            string connectinstring = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
            SqlConnection con = new SqlConnection(connectinstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from BusType", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvbustype.DataSource = ds;
                dgvbustype.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                dgvbustype.DataSource = ds;
                dgvbustype.DataBind();
                int columncount = dgvbustype.Rows[0].Cells.Count;
                dgvbustype.Rows[0].Cells.Clear();
                dgvbustype.Rows[0].Cells.Add(new TableCell());
                dgvbustype.Rows[0].Cells[0].ColumnSpan = columncount;
                dgvbustype.Rows[0].Cells[0].Text = "No Records Found";
            }
        }
        protected void dgvbustype_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvbustype.EditIndex = e.NewEditIndex;
            BindBustypeDetails();
        }
        protected void dgvbustype_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string connectinstring = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
            SqlConnection con = new SqlConnection(connectinstring);
            int bustypeno = Convert.ToInt32(dgvbustype.DataKeys[e.RowIndex].Value.ToString());
            string name = dgvbustype.DataKeys[e.RowIndex].Values["BusTypeName"].ToString();
            TextBox txtbustypename = (TextBox)dgvbustype.Rows[e.RowIndex].FindControl("txtbustypename");
            TextBox txtseat = (TextBox)dgvbustype.Rows[e.RowIndex].FindControl("txtseat");
            TextBox txtcolor = (TextBox)dgvbustype.Rows[e.RowIndex].FindControl("txtcolor");
            con.Open();
            SqlCommand cmd = new SqlCommand("update BusType set BusTypeName='" + txtbustypename.Text + "',Seat='" + txtseat.Text + "',Color='" + txtcolor.Text + "' where BusTypeNo=" + bustypeno, con);
            cmd.ExecuteNonQuery();
            con.Close();
            //lblresult.ForeColor = Color.Green;
            //lblresult.Text = username + " Details Updated successfully";
            dgvbustype.EditIndex = -1;
            BindBustypeDetails();
        }
        protected void dgvbustype_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvbustype.EditIndex = -1;
            BindBustypeDetails();
        }
        protected void dgvbustype_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string connectinstring = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
            SqlConnection con = new SqlConnection(connectinstring);
            int bustypeno = Convert.ToInt32(dgvbustype.DataKeys[e.RowIndex].Values["BusTypeNo"].ToString());
            string bustypename = dgvbustype.DataKeys[e.RowIndex].Values["BusTypeName"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from BusType where BusTypeNo=" + bustypeno, con);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result == 1)
            {
                BindBustypeDetails();
                //lblresult.ForeColor = Color.Red;
                //lblresult.Text = username + " details deleted successfully";
            }
        }
        protected void dgvbustype_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string connectinstring = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
            SqlConnection con = new SqlConnection(connectinstring);
            if (e.CommandName.Equals("AddNew"))
            {
                TextBox txtbustypename = (TextBox)dgvbustype.FooterRow.FindControl("txtftrbustypename");
                TextBox txtseat = (TextBox)dgvbustype.FooterRow.FindControl("txtftrseat");
                TextBox txtcolor = (TextBox)dgvbustype.FooterRow.FindControl("txtftrcolor");
                con.Open();
                SqlCommand cmd =
                new SqlCommand(
                "insert into BusType(BusTypeName,Seat,Color) values('" + txtbustypename.Text + "','" +
                txtseat.Text + "','" + txtcolor.Text + "')", con);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result == 1)
                {
                    BindBustypeDetails();
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
    }
}