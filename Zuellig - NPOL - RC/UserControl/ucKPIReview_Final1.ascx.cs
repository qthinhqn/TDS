using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPOL.App_Code.Entities;
using NPOL.App_Code.Business;
using DevExpress.Web;
using System.Data;
using System.Collections;

namespace NPOL.UserControl
{
    public partial class ucKPIReview_Final1 : System.Web.UI.UserControl
    {
        private Competency_KPIService service = new Competency_KPIService();
        private tbl_Competency_KPI obj = new tbl_Competency_KPI();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load data
                LoadData();

                #region #Kiem tra het han danh gia
                int period = int.Parse(Session["PeriodID"].ToString());
                string EmployeeID = Session["EmployeeIDReview"].ToString();
                ArrayList arrayList = Employee_KPILevelService.GetAllManager_KPILevel(EmployeeID);
                tbl_KPI_Period objKPI = (new KPI_PeriodService()).GetObjectById(period);

                switch (arrayList.Count)
                {
                    case 1:
                        if (Session["EmployeeID"].ToString().ToUpper() == arrayList[0].ToString().ToUpper())
                        {
                            if (DateTime.Now >= objKPI.ReviewTime_First && DateTime.Now < objKPI.EndTime)
                            {
                                // cho edit
                            }
                            else
                            {
                                // khong cho edit
                                checkChuKyPhu(arrayList, 3);
                            }
                        }
                        else
                        {
                            // khong cho edit
                            trackBar.ReadOnly = true;
                        }
                        break;
                    case 2:
                        if (Session["EmployeeID"].ToString().ToUpper() == arrayList[0].ToString().ToUpper())
                        {
                            if (DateTime.Now >= objKPI.ReviewTime_First && DateTime.Now < objKPI.ApprovalTime)
                            {
                                // cho edit
                            }
                            else
                            {
                                // khong cho edit
                                checkChuKyPhu(arrayList, 2);
                            }
                        }
                        else if (Session["EmployeeID"].ToString().ToUpper() == arrayList[1].ToString().ToUpper())
                        {
                            if (DateTime.Now >= objKPI.ReviewTime_First && DateTime.Now < objKPI.EndTime)
                            {
                                // cho edit
                            }
                            else
                            {
                                // khong cho edit
                                checkChuKyPhu(arrayList, 3);
                            }
                        }
                        else
                        {
                            //// khong cho edit
                            trackBar.ReadOnly = true;
                        }
                        break;
                    case 3:
                        if (Session["EmployeeID"].ToString().ToUpper() == arrayList[0].ToString().ToUpper())
                        {
                            if (DateTime.Now >= objKPI.ReviewTime_First && DateTime.Now < objKPI.ReviewTime)
                            {
                                // cho edit
                            }
                            else
                            {
                                // khong cho edit
                                checkChuKyPhu(arrayList, 1);
                            }
                        }
                        else if (Session["EmployeeID"].ToString().ToUpper() == arrayList[1].ToString().ToUpper())
                        {
                            if (DateTime.Now >= objKPI.ReviewTime_First && DateTime.Now < objKPI.ApprovalTime)
                            {
                                // cho edit
                            }
                            else
                            {
                                // khong cho edit
                                checkChuKyPhu(arrayList, 2);
                            }
                        }
                        else if (Session["EmployeeID"].ToString().ToUpper() == arrayList[2].ToString().ToUpper())
                        {
                            if (DateTime.Now >= objKPI.ReviewTime && DateTime.Now < objKPI.EndTime)
                            {
                                // cho edit
                            }
                            else
                            {
                                // khong cho edit
                                checkChuKyPhu(arrayList, 3);
                            }
                        }
                        else
                        {
                            //// khong cho edit
                            trackBar.ReadOnly = true;
                        }
                        break;
                    case 4:

                        break;
                    default:
                        break;
                }
                #endregion
                 
                if (Session["JobFactor"] == null) Session["JobFactor"] = trackBar.Value;
            }

        }
        private void LoadData()
        {
            try
            {
                obj = service.GetObjectByEmpId(Session["EmployeeIDReview"].ToString(), int.Parse(Session["PeriodID"].ToString()));
                HiddenField1.Value = obj.ID.ToString();
                trackBar.Value = obj.JobFactor * 100;
            }
            catch(Exception ex)
            { }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //LoadData();
            trackBar.Value = Session["JobFactor"];
            trackBar_PositionChanged(null, null);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // save data
            try
            {
                /*
                {
                    // calculate total rating
                    Calculate_total_rating();

                    //obj.Notes = txtJob.Text;
                    obj.ID = int.Parse(HiddenField1.Value);
                    double jobFactor = double.Parse(trackBar.Value.ToString()) / 100.0;
                    double kpiFactor = 1 - jobFactor;

                    service.UpdateFactorByID(obj.ID, jobFactor, kpiFactor);

                    Session["JobFactor"] = trackBar.Value;
                }
                */
                Competency_KPIService service = new Competency_KPIService();
                // Check allow send to approval
                bool result = service.IsCompletedAssess(Session["EmployeeIDReview"].ToString(), int.Parse(Session["PeriodID"].ToString()));
                if (!result)
                {
                    string message = "alert('" + GetGlobalResourceObject("K_PerformanceAssessment", "alertNotAllow").ToString() + "')";
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                    //Session["Current"] = 1;
                    ////PreLoadIndicator();
                    ////LoadControlStep();
                    //Response.Redirect("SelfAssessment.aspx");
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
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                }
                else
                {
                    string message = "alert('" + GetGlobalResourceObject("K_PerformanceAssessment", "alertERROR").ToString() + "')";
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {

            }

            // Load data
            Repeater1.DataBind();
        }

        private void Calculate_total_rating()
        {
            Competency_KPIService service = new Competency_KPIService();
            /*// Check allow send to approval
            bool result = service.IsCompletedAssess(Session["EmployeeIDReview"].ToString(), int.Parse(Session["PeriodID"].ToString()));
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
            */
            // update score
            service.UpdateScore(Session["EmployeeIDReview"].ToString(), int.Parse(Session["PeriodID"].ToString()));

            // insert row to table Approval
            Competency_KPI_ApprovalService serviceApproval = new Competency_KPI_ApprovalService();
            serviceApproval.CreateNew(Session["EmployeeIDReview"].ToString(), int.Parse(Session["PeriodID"].ToString()));
            /*if (result)
            {
                string message = "alert('" + GetGlobalResourceObject("K_PerformanceAssessment", "alertOK").ToString() + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
            else
            {
                string message = "alert('" + GetGlobalResourceObject("K_PerformanceAssessment", "alertERROR").ToString() + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }*/
        }

        protected void trackBar_PositionChanged(object sender, EventArgs e)
        {
            // save data
            try
            {
                int value = int.Parse(trackBar.Value.ToString());
                if (value > 80 && value < 100)
                {
                    trackBar.Value = 80;
                    string message = "alert('" + GetGlobalResourceObject("K_PerformanceAssessment", "alertMinKPIRating").ToString() + "')";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                }
                {
                    // calculate total rating
                    Calculate_total_rating();

                    //obj.Notes = txtJob.Text;
                    obj.ID = int.Parse(HiddenField1.Value);
                    double jobFactor = double.Parse(trackBar.Value.ToString()) / 100.0;
                    double kpiFactor = 1 - jobFactor;

                    service.UpdateFactorByID(obj.ID, jobFactor, kpiFactor);
                }
            }
            catch (Exception ex)
            {

            }

            // Load data
            Repeater1.DataBind();
        }

        private void checkChuKyPhu(ArrayList arrayList, int level)
        {
            try
            {
                int period = int.Parse(Session["PeriodID"].ToString());
                string EmployeeID = Session["EmployeeIDReview"].ToString();
                SubPeriodService service = new SubPeriodService();

                DataTable dt = service.GetListByID(period, EmployeeID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    switch (level)
                    {
                        case 1:
                            trackBar.ReadOnly = true;
                            break;
                        case 2:
                        case 3:
                            // cho edit
                            break;
                        case 4:

                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    trackBar.ReadOnly = true;
                }
            }
            catch { }
        }
    }
}