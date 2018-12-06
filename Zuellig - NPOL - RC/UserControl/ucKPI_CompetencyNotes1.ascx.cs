﻿using System;
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
    public partial class ucKPI_CompetencyNotes1 : System.Web.UI.UserControl
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
                    ASPxButton1.Visible = false;
                }
                 
                if (Session["JobFactor"] == null) Session["JobFactor"] = trackBar.Value;
            }

        }
        private void LoadData()
        {
            try
            {
                obj = service.GetObjectByEmpId(Session["EmployeeID"].ToString(), int.Parse(Session["PeriodID"].ToString()));
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
                // update score
                service.UpdateScore(Session["EmployeeID"].ToString(), int.Parse(Session["PeriodID"].ToString()));

                // Check allow send to approval
                bool result = service.IsCompletedAssess(Session["EmployeeID"].ToString(), int.Parse(Session["PeriodID"].ToString()));
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
            /*// Check allow send to approval
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
            */
            // update score
            service.UpdateScore(Session["EmployeeID"].ToString(), int.Parse(Session["PeriodID"].ToString()));

            // insert row to table Approval
            Competency_KPI_ApprovalService serviceApproval = new Competency_KPI_ApprovalService();
            serviceApproval.CreateNew(Session["EmployeeID"].ToString(), int.Parse(Session["PeriodID"].ToString()));
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
    }
}