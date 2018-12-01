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
    public partial class KPI_TimeLine : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // SET TITLE
                try
                {
                    int kpiid = KPI_PeriodService.GetKPI_LastActive();
                    tbl_KPI_Period obj = (new KPI_PeriodService()).GetObjectById(kpiid);

                    lbDateStart.Text = obj.StartTime.ToString("dd/MM") + " - " + obj.ReviewTime.AddDays(-1).ToString("dd/MM/yyyy");
                    lbDateReview.Text = obj.ReviewTime.ToString("dd/MM") + " - " + obj.ApprovalTime.AddDays(-1).ToString("dd/MM/yyyy");
                    lbDateApproval.Text = obj.ApprovalTime.ToString("dd/MM") + " - " + obj.EndTime.AddDays(-1).ToString("dd/MM/yyyy");
                    lbDateEnd.Text = obj.EndTime.ToString("dd/MM/yyyy");

                    // set timeline
                    if (DateTime.Now >= obj.StartTime)
                        liStart.Attributes["class"] = "li complete";
                    else
                        liStart.Attributes["class"] = "li";

                    if (DateTime.Now >= obj.ReviewTime)
                        liReview.Attributes["class"] = "li complete";
                    else
                        liReview.Attributes["class"] = "li";

                    if (DateTime.Now >= obj.ApprovalTime)
                        liApproval.Attributes["class"] = "li complete";
                    else
                        liApproval.Attributes["class"] = "li";

                    if (DateTime.Now >= obj.EndTime)
                        liEnd.Attributes["class"] = "li complete";
                    else
                        liEnd.Attributes["class"] = "li";
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}