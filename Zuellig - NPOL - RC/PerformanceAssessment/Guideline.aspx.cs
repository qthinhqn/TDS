using PAOL.App_Code.Business;
using PAOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAOL
{
    public partial class Guideline : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                tbl_MenuRole menuRole = MenuRoleService.GetInfoByEmpID(Session["EmployeeID"].ToString());
                if (menuRole.KPI4Manager == true)
                    ASPxRichEdit1.Open(Server.MapPath("~/PerformanceAssessment/App_Data/HDSD_KPI_ONLINE.docx"));
                else if (menuRole.KPI4Employee == true)
                    ASPxRichEdit1.Open(Server.MapPath("~/PerformanceAssessment/App_Data/HDSD_KPI_ONLINE_E.docx"));
            }
        }
    }
}