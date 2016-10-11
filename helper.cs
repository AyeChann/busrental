using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace busrental
{
    public class helper
    {
        public static string edit;
        public static string id;
        public void INS_Payment(string CustomerID, int BookingNo,string PaymentDate,decimal paymentAmount,string BankName,string Accountno)
        {
            try
            {
                string strCon = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
                SqlConnection cn = new SqlConnection(strCon);
                cn.Open();
                SqlCommand cmd = new SqlCommand("INS_Payment", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                cmd.Parameters.AddWithValue("@BookingNo", BookingNo);
                cmd.Parameters.AddWithValue("@PaymentDate",Convert.ToDateTime(PaymentDate));
                cmd.Parameters.AddWithValue("@paymentAmount", paymentAmount);
                cmd.Parameters.AddWithValue("@BankName", BankName);
                cmd.Parameters.AddWithValue("@Accountno", Accountno);
            
                SqlDataAdapter sdap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sdap.Fill(dt);
                cn.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}