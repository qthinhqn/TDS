using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPOL.App_Code.Entities;
using NPOL.App_Code.Business;
using DevExpress.Web;

namespace NPOL.UserControl
{
    public partial class ucKPI_CompetencyNotes : System.Web.UI.UserControl
    {
        private Competency_KPIService service = new Competency_KPIService();
        private tbl_Competency_KPI obj = new tbl_Competency_KPI();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load data
                LoadData();
                // kiem tra het han danh gia
                int kpiid = KPI_PeriodService.GetKPI_LastActive();
                tbl_KPI_Period objKPI = (new KPI_PeriodService()).GetObjectById(kpiid);
                // bo qua trong gia doan test

                if (DateTime.Now >= objKPI.StartTime && DateTime.Now < objKPI.ReviewTime_First)
                {
                    // cho edit
                }
                else
                {
                    // khong cho edit
                    trackBar.ReadOnly = true;
                    btCancel.Visible = false;
                    btnSave.Visible = false;
                }
            }

        }
        private void LoadData()
        {
            try
            {
                obj = service.GetObjectByEmpId(Session["EmployeeID"].ToString(), int.Parse(Session["PeriodID"].ToString()));
                //HiddenField1.Value = obj.ID.ToString();
                trackBar.Value = obj.JobFactor * 100;

                if (Session["JobFactor"] == null) Session["JobFactor"] = trackBar.Value;

                if (Session["Total_KPIPoint"] == null) Session["Total_KPIPoint"] = obj.Total_KPIPoint;
            }
            catch (Exception ex)
            { }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                //LoadData();
                if (Session["JobFactor"] != null)
                {
                    trackBar.Value = Session["JobFactor"];
                    double jobFactor = double.Parse(trackBar.Value.ToString()) / 100.0;
                    double kpiFactor = (100 - double.Parse(trackBar.Value.ToString())) / 100.0; ;
                    service.UpdateFactorByID(obj.ID, jobFactor, kpiFactor);
                }
                // cap nhat KPI point
                if (Session["Total_KPIPoint"] != null)
                {
                    double _Total_KPIPoint =  double.Parse(Session["Total_KPIPoint"].ToString());
                    service.UpdateKPIPoint(Session["EmployeeID"].ToString(), int.Parse(Session["PeriodID"].ToString()), _Total_KPIPoint);
                }

                service.UpdateScore(Session["EmployeeID"].ToString(), int.Parse(Session["PeriodID"].ToString()));

                //trackBar_PositionChanged(null, null);
                Repeater1.DataBind();
            }
            catch(Exception ex)
            {

            }
        }

        private void Update_KpiPoint()
        {
            try
            {
                Competency_KPIService service = new Competency_KPIService();
                // update KPI point
                if (HiddenField1.Value != "")
                {
                    double kpiPoint = double.Parse(HiddenField1.Value);
                    service.UpdateKPIPoint(Session["EmployeeID"].ToString(), int.Parse(Session["PeriodID"].ToString()), kpiPoint);
                }
            }
            catch (Exception ex)
            {

            }
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
                // update KPI point
                Update_KpiPoint();

                bool result = false;

                // update score
                service.UpdateScore(Session["EmployeeID"].ToString(), int.Parse(Session["PeriodID"].ToString()));

                // Check allow send to approval
                result = service.IsCompletedAssess(Session["EmployeeID"].ToString(), int.Parse(Session["PeriodID"].ToString()));
                if (!result)
                {
                    string message = "alert('" + GetGlobalResourceObject("K_PerformanceAssessment", "alertNotAllow").ToString() + "')";
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                    //Session["Current"] = 1;
                    ////PreLoadIndicator();
                    ////LoadControlStep();
                    //Response.Redirect("SelfAssessment.aspx");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    if (Session["JobFactor"] != null) Session["JobFactor"] = trackBar.Value;
                    if (Session["Total_KPIPoint"] != null) Session["Total_KPIPoint"] = obj.Total_KPIPoint;
                    
                    string message = "alert('" + GetGlobalResourceObject("K_PerformanceAssessment", "alertSubmit").ToString() + "')";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                }

                // insert row to table Approval
                Competency_KPI_ApprovalService serviceApproval = new Competency_KPI_ApprovalService();
                result = serviceApproval.CreateNew(Session["EmployeeID"].ToString(), int.Parse(Session["PeriodID"].ToString()));
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
            // update score
            service.UpdateScore(Session["EmployeeID"].ToString(), int.Parse(Session["PeriodID"].ToString()));

            // insert row to table Approval
            Competency_KPI_ApprovalService serviceApproval = new Competency_KPI_ApprovalService();
            serviceApproval.CreateNew(Session["EmployeeID"].ToString(), int.Parse(Session["PeriodID"].ToString()));
        }

        protected void trackBar_PositionChanged(object sender, EventArgs e)
        {
            obj = service.GetObjectByEmpId(Session["EmployeeID"].ToString(), int.Parse(Session["PeriodID"].ToString()));
            // save data
            try
            {

                //obj.ID = int.Parse(HiddenField1.Value);
                double jobFactor = double.Parse(trackBar.Value.ToString()) / 100.0;
                double kpiFactor = 1 - jobFactor;

                if (obj.JobFactor != jobFactor)
                {
                    int value = int.Parse(trackBar.Value.ToString());
                    if (value > 80 && value < 100)
                    {
                        //trackBar.Value = 80;
                        string message = "alert('" + GetGlobalResourceObject("K_PerformanceAssessment", "alertMinKPIRating").ToString() + "')";
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                    }
                    Update_KpiPoint();

                    // calculate total rating
                    Calculate_total_rating();

                    service.UpdateFactorByID(obj.ID, jobFactor, kpiFactor);
                    // Load data
                    Repeater1.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void txtKpiPoint_TextChanged(object sender, EventArgs e)
        {
            ASPxTextBox txt = (ASPxTextBox)sender;
            try
            {
                double kpiPoint = 0;
                try
                {
                    String[] tmp = txt.Text.Split('.');
                    switch (tmp.Length)
                    {
                        case 0:
                            kpiPoint = 0;
                            HiddenField1.Value = "0";
                            break;
                        case 1:
                            if (tmp[0].Length == 0)
                                kpiPoint = 0;
                            else
                                kpiPoint = double.Parse(tmp[0]);
                            break;
                        case 2:
                            if (tmp[1].Length == 0)
                                kpiPoint = double.Parse(tmp[0]);
                            else if (tmp[1].Length == 1)
                                kpiPoint = double.Parse(tmp[0]) + double.Parse(tmp[1]) / 10;
                            else
                                kpiPoint = double.Parse(tmp[0]) + double.Parse(tmp[1].Substring(0, 2)) / 100;
                            break;
                    }
                    if (kpiPoint > 5)
                    {
                        string message = "alert('" + GetGlobalResourceObject("K_PerformanceAssessment", "alertKPIPoint").ToString() + "')";
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                        HiddenField1.Value = "";
                        return;
                    }
                    else
                    {
                        HiddenField1.Value = kpiPoint.ToString();
                        Update_KpiPoint();

                        // calculate total rating
                        Calculate_total_rating();

                        double jobFactor = double.Parse(trackBar.Value.ToString()) / 100.0;
                        double kpiFactor = 1 - jobFactor;
                        service.UpdateFactorByID(obj.ID, jobFactor, kpiFactor);

                        // Load data
                        Repeater1.DataBind();
                    }
                }
                catch (Exception ex)
                {
                }
            }
            catch (Exception ex)
            {
                string message = "alert('" + GetGlobalResourceObject("KPI_Period", "alertFail").ToString() + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
            finally { }
            // Load data
            //Repeater1.DataBind();
        }

        protected void txtKpiPoint_Validation(object sender, ValidationEventArgs e)
        {
            ASPxTextBox txt = (ASPxTextBox)sender;
            try
            {
                // update cho 2017
                Competency_KPIService service = new Competency_KPIService();
                double kpiPoint = 0;
                try
                {
                    kpiPoint = double.Parse(txt.Text);
                }
                catch (Exception ex)
                {
                }
                if (kpiPoint > 5)
                {
                    e.IsValid = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = "alert('" + GetGlobalResourceObject("KPI_Period", "alertFail").ToString() + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
            finally { }
            // Load data
            //Repeater1.DataBind();
        }
    }
}
