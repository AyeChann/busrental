using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace busrental
{
    public partial class welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbdriver_Click(object sender, EventArgs e)
        {
            Response.Redirect("driver_registration.aspx");
        }

        protected void lbbus_Click(object sender, EventArgs e)
        {
            Response.Redirect("bus_registration.aspx");
        }

        protected void lblbooking_Click(object sender, EventArgs e)
        {
            Response.Redirect("booking_report.aspx");
        }

        protected void lbbustype_Click(object sender, EventArgs e)
        {
            Response.Redirect("bus_type_registration.aspx");
        }
    }
}