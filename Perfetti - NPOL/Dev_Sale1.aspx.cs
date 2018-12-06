using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPOL.Report;

namespace NPOL
{
    public partial class Dev_Sale1 : System.Web.UI.Page
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
            //DateTime PayDay = getPayDay(monthid, yearid);

            Xtra_Sale report = new Xtra_Sale();
            report.FilterString = "[EmployeeID] = '" + Session["EmployeeID"].ToString() + "' and [MonthID] = " + monthid + " and [YearID] = " + yearid;
            report.Parameters["BeginCycleSal"].Value = BeginCycle.ToShortDateString();
            report.Parameters["EndCycleSal"].Value = EndCycle.ToShortDateString();            
            //if (PayDay.Day == 1 && PayDay.Month == 1 && PayDay.Year == 1)
            //{
            //    report.Parameters["PayDay"].Value = "";
            //}
            //else
            //{
            //    report.Parameters["PayDay"].Value = PayDay.ToShortDateString();
            //}
            report.RequestParameters = false;
            ASPxDocumentViewer1.Report = report;
        }

        private DateTime getPayDay(int monthid, int yearid)
        {
            DateTime returnValue = new DateTime();
            System.Data.DataTable dt;
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
            provider.CommandText = "Select * from tblPayroll_Payday where YearID = @YearID and MonthID = @MonthID";
            provider.ParameterCollection = new string[] { "@YearID", "@MonthID" };
            provider.ValueCollection = new object[] { yearid, monthid };
            dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                returnValue = (DateTime)dt.Rows[0]["PayDay"];
            }
            provider.CloseConnection();
            return returnValue;
        }
    }
}