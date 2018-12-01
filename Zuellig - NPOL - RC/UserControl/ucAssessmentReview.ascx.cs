using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPOL.App_Code.Business;
using DevExpress.Web;
using NPOL.App_Code.Entities;

namespace NPOL.UserControl
{
    public partial class ucAssessmentReview : System.Web.UI.UserControl
    {
        private int oldControl = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["PeriodID"] = 1;
            //Session["EmployeeIDReview"] = "HR021";
            if (!IsPostBack)
            {
                //Session["CurrentReview"] = null;
            }
            Competency_KPIService service = new Competency_KPIService();
            int current = 1;
            tbl_Competency_KPI obj = null;
            if (Session["EmployeeIDReview"] != null && Session["PeriodID"] != null)
                obj = service.GetObjectByEmpId(Session["EmployeeIDReview"].ToString(), int.Parse(Session["PeriodID"].ToString()));
            if (obj != null)
            {
                Session["Competency_KPI_ID"] = obj.ID;
                Session["Step"] = obj.Step;
                if (Session["CurrentReview"] == null)
                {
                    current = int.Parse(obj.Step);
                    Session["CurrentReview"] = current;
                }
            }
            else if (Session["CurrentReview"] == null)
            {
                current = 1;
                Session["CurrentReview"] = current;
            }
            
            // enable indicator
            current = int.Parse(Session["CurrentReview"].ToString());
            SetCurrentStep(current);
            LoadControlStep();
        }

        private void SetCurrentStep(int step)
        {
            switch (step)
            {
                case 1:
                    liStep_1.Attributes["class"] = "current";
                    break;
                case 2:
                    liStep_2.Attributes["class"] = "current";
                    break;
                case 3:
                    liStep_3.Attributes["class"] = "current";
                    break;
                case 4:
                    liStep_4.Attributes["class"] = "current";
                    break;
            }
        }

        private void LoadControlStep()
        {
            Placeholder1.Controls.Clear();

            int current = int.Parse(Session["CurrentReview"].ToString());
            switch (current)
            {
                case 1:
                    // load competency
                    if (oldControl != 1)
                    {
                        ucKPIReview_EmpCompetency ucCompetency = LoadControl("~/UserControl/ucKPIReview_EmpCompetency.ascx") as ucKPIReview_EmpCompetency;
                        if (ucCompetency != null)
                            Placeholder1.Controls.Add(ucCompetency);
                        oldControl = 1;
                    }
                    break;

                case 2:
                    // load KPI
                    if (oldControl != 2)
                    {
                        ucKPIReview_EmpKPI_Detail ucKPI = LoadControl("~/UserControl/ucKPIReview_EmpKPI_Detail.ascx") as ucKPIReview_EmpKPI_Detail;
                        if (ucKPI != null)
                            Placeholder1.Controls.Add(ucKPI);
                        oldControl = 2;
                    }
                    break;

                case 3:
                    // load Notes
                    if (oldControl != 3)
                    {
                        ucKPIReview_RequireTraining ucTraining = LoadControl("~/UserControl/ucKPIReview_RequireTraining.ascx") as ucKPIReview_RequireTraining;
                        //ucKPI_ManageNote ucTraining = LoadControl("~/UserControl/ucKPI_ManageNote.ascx") as ucKPI_ManageNote;
                        if (ucTraining != null)
                            Placeholder1.Controls.Add(ucTraining);
                        oldControl = 3;
                    }
                    break;

                case 4:
                    // load report
                    //ucKPI_ManageNote ucManageNote = LoadControl("~/UserControl/ucKPI_ManageNote.ascx") as ucKPI_ManageNote;
                    ucKPIReview_Comment ucManageNote = LoadControl("~/UserControl/ucKPIReview_Comment.ascx") as ucKPIReview_Comment;
                    if (ucManageNote != null)
                            Placeholder1.Controls.Add(ucManageNote);
                        oldControl = 3;
                    break;

                default:
                    break;

            }
        }
        public void Link_Click(Object sender, EventArgs e)
        {
            //uc_KPI_Indicator uc = this.FindControl("uc_KPI_Indicator") as uc_KPI_Indicator;
            try
            {
                Session["CurrentReview"] = (sender as System.Web.UI.HtmlControls.HtmlAnchor).Name;
            }
            catch { }
            //PreLoadIndicator();
            //LoadControlStep();
            Response.Redirect("PAreview.aspx");
        }

        protected void btnBackward_Click(object sender, EventArgs e)
        {
            // Return back
            Session["CurrentReview"] = int.Parse(Session["CurrentReview"].ToString()) - 1;
            //PreLoadIndicator();
            //LoadControlStep();
            Response.Redirect("PAreview.aspx");
        }

        protected void btnForward_Click(object sender, EventArgs e)
        {
            // save data
            // Next step
            Session["CurrentReview"] = int.Parse(Session["CurrentReview"].ToString()) + 1;
            //PreLoadIndicator();
            //LoadControlStep();
            Response.Redirect("PAreview.aspx");
        }

        protected void btnSendToApproval_Click(object sender, EventArgs e)
        {
            Competency_KPIService service = new Competency_KPIService();
            // Check allow send to approval
            bool result = service.IsCompletedAssess(Session["EmployeeIDReview"].ToString(), int.Parse(Session["PeriodID"].ToString()));
            if (!result)
            {
                string message = "alert('" + GetGlobalResourceObject("K_PerformanceAssessment", "alertNotAllow").ToString() + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                //Session["CurrentReview"] = 1;
                ////PreLoadIndicator();
                ////LoadControlStep();
                //Response.Redirect("SelfAssessmentHistory.aspx");
                return;
            }

            // update score
            service.UpdateScore(Session["EmployeeIDReview"].ToString(), int.Parse(Session["PeriodID"].ToString()));

            // insert row to table Approval
            Competency_KPI_ApprovalService serviceApproval = new Competency_KPI_ApprovalService();
            result = serviceApproval.CreateNew(Session["EmployeeIDReview"].ToString(), int.Parse(Session["PeriodID"].ToString()));
            if (result)
            {
                string message = "alert('" + GetGlobalResourceObject("K_PerformanceAssessment", "alertOK").ToString() + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
            else
            {
                string message = "alert('" + GetGlobalResourceObject("K_PerformanceAssessment", "alertERROR").ToString() + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
        }
    }
}