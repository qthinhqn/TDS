using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NPOL
{
    public partial class AN_approvalNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] == null)
            {
                if (!Session["Role"].ToString().Equals("HR"))
                {
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                string conn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString;
                tblEmpManagerNews obj = new tblEmpManagerNews(conn);
                if (!obj.IsCheckerNews(Session["EmployeeID"].ToString()))
                    Response.Redirect("Login.aspx");
            }
        }
    }
}