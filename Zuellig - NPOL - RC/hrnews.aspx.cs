using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NPOL
{
    public partial class hrNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Validate Page
                if (Session["EmployeeID"] == null || Session["Role"] == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
                else if (Session["Role"] == "HR")
                {
                    Response.Redirect("~/hrnews2.aspx");
                }

            }
            catch(Exception ex)
            {

            }
        }
    }
}