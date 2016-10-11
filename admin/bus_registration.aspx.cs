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
    public partial class bus_registration : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBustypeDetails();
                bindcombo();
            }
        }
        public DataTable GetType()
        {
            try
            {
                string strCon = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
                SqlConnection cn = new SqlConnection(strCon);
                cn.Open();
                SqlCommand cmd = new SqlCommand("Getbustype", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sdap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sdap.Fill(dt);
                cn.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void bindcombo()
        {

            ddlBusTypeName.DataSource = GetType();
            ddlBusTypeName.DataTextField = "BusTypeName";
            ddlBusTypeName.DataValueField = "BusTypeNo";
            ddlBusTypeName.DataBind();

        }
        protected void BindBustypeDetails()
        {
            helper.edit = "Add";
            string connectinstring = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
            SqlConnection con = new SqlConnection(connectinstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("Getbus", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            //DropDownList drpbustype = (DropDownList)dgvbus.Rows[e.RowIndex].FindControl("drpbustype");
            dgvbus.DataSource = ds;
            da.Fill(ds);

            //drpbustype.DataValueField = "BusTypeNo";
            //drpbustype.DataTextField = "BusTypeName";
            //drpbus        
            // da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvbus.DataSource = ds;
                dgvbus.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                dgvbus.DataSource = ds;
                dgvbus.DataBind();
                int columncount = dgvbus.Rows[0].Cells.Count;
                dgvbus.Rows[0].Cells.Clear();
                dgvbus.Rows[0].Cells.Add(new TableCell());
                dgvbus.Rows[0].Cells[0].ColumnSpan = columncount;
                dgvbus.Rows[0].Cells[0].Text = "No Records Found";
            }
        }
        protected void dgvbus_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvbus.EditIndex = e.NewEditIndex;
            BindBustypeDetails();
        }

        #region Row Command
        protected void dgvbus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                string id = (e.CommandArgument).ToString();
                GridViewRow row = dgvbus.Rows[Convert.ToInt32(id)];
                txtBusName.Text = row.Cells[1].Text;
                ddlBusTypeName.SelectedValue = row.Cells[3].Text;

            }
        }
        #endregion

        protected void dgvbus_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtBusName.Text = dgvbus.Rows[dgvbus.SelectedRow.RowIndex].Cells[1].Text;
            ddlBusTypeName.SelectedValue = dgvbus.DataKeys[dgvbus.SelectedRow.RowIndex].Values["BusTypeNo"].ToString();
            txtAmount.Text = dgvbus.Rows[dgvbus.SelectedRow.RowIndex].Cells[4].Text;
            //ViewState["Action"] = "Edit";
            helper.edit = "Edit";
        }

        protected void btnregister_Click(object sender, EventArgs e)
        {

            //if (ViewState["Action"] != null)
            //{
            //    if (ViewState["Action"].ToString() == "Edit")
            //    {
            if (helper.edit == "Edit")
            {
               
                //if (dgvbus.Rows.Count > 0)
                //{
                helper.id = dgvbus.DataKeys[dgvbus.SelectedRow.RowIndex].Values["BusNo"].ToString();
                //}
                string connectinstring = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
                SqlConnection con = new SqlConnection(connectinstring);
                con.Open();
                SqlCommand cmd = new SqlCommand("Upd_bus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@busid", helper.id);
                cmd.Parameters.AddWithValue("@busname", txtBusName.Text);
                cmd.Parameters.AddWithValue("@bustypeno", ddlBusTypeName.SelectedValue);
                cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(txtAmount.Text));

                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                string connectinstring = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
                SqlConnection con = new SqlConnection(connectinstring);
                con.Open();
                SqlCommand cmd = new SqlCommand("Ins_Bus", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@busname", txtBusName.Text);
                cmd.Parameters.AddWithValue("@bustypeno", ddlBusTypeName.SelectedValue);
                cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(txtAmount.Text));

                cmd.ExecuteNonQuery();
                con.Close();
            }
            BindBustypeDetails();
            bindcombo();
            clear();
        }
        private void clear()
        {
            txtBusName.Text = "";
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            BindBustypeDetails();
            bindcombo();
            clear();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            helper.id= dgvbus.DataKeys[dgvbus.SelectedRow.RowIndex].Values["BusNo"].ToString();
            //}
            string connectinstring = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
            SqlConnection con = new SqlConnection(connectinstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("Del_bus", con);
            cmd.Parameters.AddWithValue("@busid", helper.id);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            BindBustypeDetails();
            bindcombo();
            clear();
        }
    }
        //}
    //}
}