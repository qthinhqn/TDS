using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NPOL
{
    public partial class Dev_Leave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validate Page
            if (Session["Role"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (String.Compare(Session["Role"].ToString(), "hr", true) != 0)
                {
                    Response.Redirect("Login.aspx");
                }
            }

            if (Session["lang"].ToString().Equals("en"))
            {
                NPOL.Report.AnnualLeave_en rs = new Report.AnnualLeave_en();
                if (Session["CR_FromDate"] == null)
                {
                    rs.Parameters["_Year"].Value = "";
                    rs.Parameters["_FromDate"].Value = "";
                }
                else
                {
                    rs.Parameters["_Year"].Value = ((DateTime)Session["CR_FromDate"]).Year;
                    rs.Parameters["_FromDate"].Value = convertMonth((DateTime)Session["CR_FromDate"]) + "/" + convertDay((DateTime)Session["CR_FromDate"]);
                }

                if (Session["CR_ToDate"] == null)
                {
                    rs.Parameters["_ToDate"].Value = "";
                }
                else
                {
                    rs.Parameters["_ToDate"].Value = convertMonth((DateTime)Session["CR_ToDate"]) + "/" + convertDay((DateTime)Session["CR_ToDate"]);
                }
                ASPxDocumentViewer1.Report = rs;
            }
            else
            {
                NPOL.Report.AnnualLeave rs = new Report.AnnualLeave();
                if (Session["CR_FromDate"] == null)
                {
                    rs.Parameters["_Year"].Value = "";
                    rs.Parameters["_FromDate"].Value = "";
                }
                else
                {
                    rs.Parameters["_Year"].Value = ((DateTime)Session["CR_FromDate"]).Year;
                    rs.Parameters["_FromDate"].Value = convertDay((DateTime)Session["CR_FromDate"]) + "/" + convertMonth((DateTime)Session["CR_FromDate"]);
                }

                if (Session["CR_ToDate"] == null)
                {
                    rs.Parameters["_ToDate"].Value = "";
                }
                else
                {
                    rs.Parameters["_ToDate"].Value = convertDay((DateTime)Session["CR_ToDate"]) + "/" + convertMonth((DateTime)Session["CR_ToDate"]);
                }
                ASPxDocumentViewer1.Report = rs;
            }
        }

        private string convertMonth(DateTime input)
        {
            string strMonth = null;
            int Month = input.Month;
            if (Month < 10)
            {
                strMonth = "0" + Month;
            }
            else
            {
                strMonth = Month.ToString();
            }
            return strMonth;
        }

        private string convertDay(DateTime input)
        {
            string strDay = null;
            int Day = input.Day;
            if (Day < 10)
            {
                strDay = "0" + Day;
            }
            else
            {
                strDay = Day.ToString();
            }
            return strDay;
        }


    }
}