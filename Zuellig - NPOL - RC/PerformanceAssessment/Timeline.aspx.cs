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
    public partial class K_SetKPI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                // SET TITLE
                try
                {
                    int kpiid = KPI_PeriodService.GetKPI_LastActive();
                    tbl_KPI_Period obj = (new KPI_PeriodService()).GetObjectById(kpiid);
                    Label1.Text = GetGlobalResourceObject("KPI_TitlePage", "titleTimeline").ToString() + obj.Name;
                }
                catch (Exception ex)
                {
                    
                }
            }
        }
    }
}