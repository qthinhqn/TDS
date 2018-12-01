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
    public partial class ucEmp_Competency_KPI : System.Web.UI.UserControl
    {
        private int oldControl = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["PeriodID"] = 1;
            //Session["EmployeeID"] = "HR021";
            if (!IsPostBack)
            {
                // kiem tra het han danh gia
                int kpiid = KPI_PeriodService.GetKPI_LastActive();
                tbl_KPI_Period objKPI = (new KPI_PeriodService()).GetObjectById(kpiid);

                if (DateTime.Now >= objKPI.StartTime && DateTime.Now < objKPI.ReviewTime)
                {
                    // cho edit
                    btnSendToApproval.Enabled = true;
                }
                else
                {
                    // khong cho edit
                    btnSendToApproval.Enabled = false;
                }
            }
            Competency_KPIService service = new Competency_KPIService();
            int current = 1;
            tbl_Competency_KPI obj = service.GetObjectByEmpId(Session["EmployeeID"].ToString(), int.Parse(Session["PeriodID"].ToString()));
            if (obj != null)
            {
                Session["Competency_KPI_ID"] = obj.ID;
                Session["Step"] = obj.Step; 
                if (Session["Current"] == null)
                {
                    //current = int.Parse(obj.Step);
                    Session["Current"] = current;
                }
            }
            else if (Session["Current"] == null)
            {
                current = 1;
                Session["Current"] = current;
                btnSendToApproval.Enabled = false;
            }
            
            // enable indicator
            current = int.Parse(Session["Current"].ToString());
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
                case 5:
                    liStep_5.Attributes["class"] = "current";
                    break;
            }
        }

        private void LoadControlStep()
        {
            Placeholder1.Controls.Clear();
            
            int current = int.Parse(Session["Current"].ToString());
            switch (current)
            {
                case 1:
                    // load competency
                    //if (oldControl != 1)
                    {
                        ucKPI_EmpCompetency ucCompetency = LoadControl("~/UserControl/ucKPI_EmpCompetency.ascx") as ucKPI_EmpCompetency;
                        if (ucCompetency != null)
                            Placeholder1.Controls.Add(ucCompetency);
                        oldControl = 1;
                    }
                    break;

                case 2:
                    // load KPI
                    //if (oldControl != 2)
                    {
                        ucKPI_EmpKPI_Detail ucKPI = LoadControl("~/UserControl/ucKPI_EmpKPI_Detail.ascx") as ucKPI_EmpKPI_Detail;
                        if (ucKPI != null)
                            Placeholder1.Controls.Add(ucKPI);
                        oldControl = 2;
                    }
                    break;

                case 3:
                    // load Training
                    if (oldControl != 3)
                    {
                        ucKPI_RequireTraining ucTraining = LoadControl("~/UserControl/ucKPI_RequireTraining.ascx") as ucKPI_RequireTraining;
                        if (ucTraining != null)
                            Placeholder1.Controls.Add(ucTraining);
                        oldControl = 3;
                    }
                    break;

                case 4:
                    // load Note
                    if (oldControl != 4)
                    {
                        ucKPI_CompetencyComment ucNotes = LoadControl("~/UserControl/ucKPI_CompetencyComment.ascx") as ucKPI_CompetencyComment;
                        if (ucNotes != null)
                            Placeholder1.Controls.Add(ucNotes);
                        oldControl = 4;
                    }
                    break;

                case 5:
                    // load Note
                    if (oldControl != 5)
                    {
                        ucKPI_CompetencyNotes ucNotes = LoadControl("~/UserControl/ucKPI_CompetencyNotes.ascx") as ucKPI_CompetencyNotes;
                        if (ucNotes != null)
                            Placeholder1.Controls.Add(ucNotes);
                        oldControl = 5;
                    }
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
                Session["Current"] = (sender as System.Web.UI.HtmlControls.HtmlAnchor).Name;
            }
            catch { }
            //PreLoadIndicator();
            //LoadControlStep();
            Response.Redirect("SelfAssessment.aspx");
        }

        protected void btnBackward_Click(object sender, EventArgs e)
        {
            // Return back
            Session["Current"] = int.Parse(Session["Current"].ToString()) - 1;
            //PreLoadIndicator();
            //LoadControlStep();
            Response.Redirect("SelfAssessment.aspx");
        }

        protected void btnForward_Click(object sender, EventArgs e)
        {
            // save data
            // Next step
            Session["Current"] = int.Parse(Session["Current"].ToString()) + 1;
            //PreLoadIndicator();
            //LoadControlStep();
            Response.Redirect("SelfAssessment.aspx");
        }

        protected void btnSendToApproval_Click(object sender, EventArgs e)
        {
            Competency_KPIService service = new Competency_KPIService();
            // Check allow send to approval
            bool result = service.IsCompletedAssess(Session["EmployeeID"].ToString(), int.Parse(Session["PeriodID"].ToString()));
            if (!result)
            {
                string message = "alert('" + GetGlobalResourceObject("K_PerformanceAssessment", "alertNotAllow").ToString() + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                //Session["Current"] = 1;
                ////PreLoadIndicator();
                ////LoadControlStep();
                //Response.Redirect("SelfAssessment.aspx");
                return;
            }

            // update score
            service.UpdateScore(Session["EmployeeID"].ToString(), int.Parse(Session["PeriodID"].ToString()));

            // insert row to table Approval
            Competency_KPI_ApprovalService serviceApproval = new Competency_KPI_ApprovalService();
            result = serviceApproval.CreateNew(Session["EmployeeID"].ToString(), int.Parse(Session["PeriodID"].ToString()));
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