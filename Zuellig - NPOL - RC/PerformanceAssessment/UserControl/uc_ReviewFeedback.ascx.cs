using PAOL.App_Code.Business;
using PAOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAOL.UserControl
{
    public partial class uc_ReviewFeedback : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Role"] == "PA_Admin")
                {
                    GridView1.DataSource = PAOL.App_Code.Business.EmpFeedbackService.GetInfoByEmpID("%");
                    GridView1.DataBind();
                }
                else
                {
                    string empID = Session["EmployeeID"].ToString();
                    GridView1.DataSource = PAOL.App_Code.Business.EmpFeedbackService.GetInfoByManagerID(empID);
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

    }
}