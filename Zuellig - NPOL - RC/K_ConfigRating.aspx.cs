using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NPOL
{
    public partial class K_ConfigRating : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (!Session["Role"].ToString().Equals("PA_Admin"))
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}