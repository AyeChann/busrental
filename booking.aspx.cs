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
using Microsoft.Reporting.WebForms;

namespace busrental
{
    public partial class booking : System.Web.UI.Page
    {
        decimal amount = 10000;
        helper objhelper = new helper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindcombo();
                
            }
        }
        //public void login()
        //{
        //    string strconnect = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
        //    SqlConnection con = new SqlConnection(strconnect);
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("Checkuser", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@username", txtuser.Text);
        //    cmd.Parameters.AddWithValue("@password", hfpassword.Value);
        //    SqlDataReader rd = cmd.ExecuteReader();
        //    if (rd.HasRows)
        //    {
        //        rd.Read();
        //        lblinfo.Text = "Login Successful!";
        //        btnlogout.Visible = true;

        //    }
        //    else
        //    {
        //        lblinfo.Text = "Invalid login successful!";
        //    }

        
            
        //}
        public DataTable Getbustype()
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

            ddlbustype.DataSource = Getbustype();
            ddlbustype.DataTextField = "BusTypeName";
            ddlbustype.DataValueField = "BusTypeNo";
            ddlbustype.DataBind();

        }
        protected void Book_Click(object sender, EventArgs e)
        {
           decimal total = amount*Convert.ToDecimal(txtno.Text);
            string strconnect = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
            SqlConnection con = new SqlConnection(strconnect);
            con.Open();
            SqlCommand cmd = new SqlCommand("Ins_Booking",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@customername",txtname.Text);
            cmd.Parameters.AddWithValue("@busno", ddlbustype.Text);
            cmd.Parameters.AddWithValue("@fromdate", SqlDbType.Date).Value = Calendar1.SelectedDate;
            cmd.Parameters.AddWithValue("@todate", SqlDbType.Date).Value = Calendar2.SelectedDate;
            
            //cmd.Parameters.AddWithValue("@fromdate",txtfrom.Text);
            //cmd.Parameters.AddWithValue("@todate",txtto.Text);
            cmd.Parameters.AddWithValue("@noofdays", Convert.ToDecimal(txtno.Text));
            cmd.Parameters.AddWithValue("@tripname", txttrip.Text);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@totalamount",total );
            cmd.ExecuteNonQuery();
            con.Close();
            objhelper.INS_Payment(txtname.Text, Convert.ToInt16(ddlbustype.SelectedValue), txtdate.Text, total, txtbank.Text, txtaccount.Text);
            txtname.Text = "";
            //ddlbustype.Text = "";
            txtno.Text = "";
            txttrip.Text = "";         
            txttotal.Text = "";
            txtdate.Text = "";
            txtaccount.Text = "";
            txtbank.Text = "";
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {

        }

        public void GetAllBooking()
        {
            string strconnect = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
            SqlConnection con = new SqlConnection(strconnect);
            con.Open();
            SqlCommand cmd = new SqlCommand("Get_Booking",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            
        }
        public DataTable GetBooking(string customername)
        {
            string strconnect = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
            SqlConnection con = new SqlConnection(strconnect);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetBooking", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerName", customername);
            SqlDataAdapter sdap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdap.Fill(dt);           
            con.Close();
            return dt;

        }
    
         public void GenerateReport(string customername, ReportViewer rptViewer)
        {
            //ReportDataSource rds = new ReportDataSource(Name = "DataSet1");

            //rptViewer.Reset();
            DataTable dt = GetBooking(customername);
      
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            rptViewer.ProcessingMode = ProcessingMode.Local;
            rptViewer.LocalReport.ReportPath = Server.MapPath("~/Report2.rdlc");
            rptViewer.LocalReport.DisplayName = "Report2";
            rptViewer.LocalReport.DataSources.Clear();
            rptViewer.LocalReport.DataSources.Add(rds);
        }

         protected void btnreport_Click(object sender, EventArgs e)
         {
             string name = Convert.ToString(Session["name"]);
             GenerateReport(name, rptbooking);
         }

         protected void txtno_TextChanged(object sender, EventArgs e)
         {
             
         }

         protected void Calendar2_SelectionChanged(object sender, EventArgs e)
         {
             DateTime start = Calendar1.SelectedDate;
             DateTime end = Calendar2.SelectedDate;
             txtno.Text = (end - start).ToString();
             
             string [] aa = txtno.Text.Split('.');
             txtno.Text = aa[0];
         }

         protected void txttrip_TextChanged(object sender, EventArgs e)
         {
             if (txttrip.Text.Length > 0)
             {
                 txttotal.Text = (amount * Convert.ToDecimal(txtno.Text)).ToString();
             }
         }

         protected void ddlbustype_SelectedIndexChanged(object sender, EventArgs e)
         {

             amount  = GetAmount(ddlbustype.SelectedValue.ToString());
             
         }
         public decimal GetAmount(string BusTypeNo)
         {
             decimal i = 0;
             String sqlQuery = "select Amount from bus where BusTypeNo ='" + BusTypeNo + "'";
             string strcon = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
             using (SqlConnection conn = new SqlConnection(strcon))
             {
                 try
                 {
                     SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Connection.Open();               
                     //cmd.Parameters.AddWithValue("@BalanceQty", BalanceQty);
                     //i = (decimal)cmd.ExecuteScalar();
                     cmd.Connection.Close();
                     return i;
                 }
                 catch (Exception)
                 {
                     throw;
                 }
             }
         }
    
         //protected void ddlbustype_TextChanged(object sender, EventArgs e)
         //{
         //    if (ddlbustype.Text != "")
         //    {
         //        decimal i = 0;
         //        string query = "select Amount from bus where BusTypeName = '" + ddlbustype.Text + "'";
         //        string strconnect = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
         //        SqlConnection con = new SqlConnection(strconnect);
         //        con.Open();
         //        SqlCommand cmd = new SqlCommand(query, con);
         //        i = (decimal)cmd.ExecuteScalar();
         //        Session.Add("amount", i);
         //    }
         //}

         //protected void ddlbustype_SelectedIndexChanged(object sender, EventArgs e)
         //{
         //    if (ddlbustype.Text != "")
         //    {
         //        decimal i = 0;
         //        string query = "select Amount from bus where BusTypeName = '" + ddlbustype.Text + "'";
         //        string strconnect = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
         //        SqlConnection con = new SqlConnection(strconnect);
         //        con.Open();
         //        SqlCommand cmd = new SqlCommand(query, con);
         //        i = (decimal)cmd.ExecuteScalar();
         //        Session.Add("amount", i);
         //    }
         //} 

    

        
    }
}