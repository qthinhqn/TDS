using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace NPOL.Report
{
    public partial class Dev_AtSite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validate Page
            if (Session["CR_MonthID"] == null || Session["CR_YearID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            
            
            int monthid = (int)Session["CR_MonthID"];
            int yearid = (int)Session["CR_YearID"];
            DateTime EndCycle = new DateTime(yearid, monthid, 20);
            DateTime TempBeginCycle = EndCycle.AddMonths(-1);
            DateTime BeginCycle = new DateTime(TempBeginCycle.Year, TempBeginCycle.Month, 21);

            NPOL.Report.Xtra_AtSite report = new NPOL.Report.Xtra_AtSite();
            report.FilterString = "[EmployeeID] = '" + Session["EmployeeID"].ToString() + "' and [MonthID] = " + monthid + " and [YearID] = " + yearid;
            report.Parameters["BeginCycleSal"].Value = BeginCycle.ToShortDateString();
            report.Parameters["EndCycleSal"].Value = EndCycle.ToShortDateString();
            report.RequestParameters = false;
            ASPxDocumentViewer1.Report = report;           
        }        
    }
}