using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PAOL.Report;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using PAOL.App_Code.Business;
using DevExpress.Web;

namespace PAOL
{
    public partial class K_ViewGeneralKPI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validate Page
            if (Session["EmployeeID"] == null || Session["Role"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                //Trường hợp là HR
                if (!Session["Role"].ToString().Equals("HR"))
                {
                    Response.Redirect("Login.aspx");
                }

            }

            if (!IsPostBack)
            {
                //Điền dữ liệu chu kỳ đánh giá
                LoadPeriod(Session["EmployeeID"].ToString());
                LoadData();
            }
        }

        private void LoadPeriod(string EmployeeID)
        {
            try
            {
                DataTable dt = KPI_PeriodService.GetAllKPI_Period();

                ddlYearSal.DataSource = dt;
                ddlYearSal.DataTextField = "Name";
                ddlYearSal.DataValueField = "ID";
                ddlYearSal.DataBind();

                if (dt!= null && dt.Rows.Count > 0)
                {
                    ddlYearSal.SelectedIndex = 0;
                }
            }catch(Exception ex)
            { }
        }

        protected void ddlYearSal_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ddlYearSal.Text))
            {
                LoadData();
            }
            else
            {
                string message = "alert('" + GetGlobalResourceObject("K_ViewEmpKPI", "alert").ToString() + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);

                //Reset session
                Session.Remove("CR_YearID");
                return;
            }

        }

        public void LoadData()
        {
            try
            {
                string EmpID = Session["EmployeeID"].ToString();
                int PeriodID = Convert.ToInt32(ddlYearSal.SelectedValue);

                //Session["CR_YearID"] = PeriodID;

                // Load danh sach phieu danh gia
                Competency_KPIService service = new Competency_KPIService();
                DataTable dt = service.GetTable_rptGeneralKPI(PeriodID);
                if (dt != null)
                {
                    gridRating.DataSource = dt;
                    gridRating.DataBind();
                }
            }
            catch(Exception ex)
            { }
        }

        protected void ASPxButton2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ddlYearSal.Text))
            {
                Session["rptEmployeeID"] = null;
                Session["rptPeriodID"] = ddlYearSal.SelectedValue;
                Response.Redirect("~/K_ViewReportKPI.aspx");
            }
            else
            {
                string message = "alert('" + GetGlobalResourceObject("K_ViewEmpKPI", "alert").ToString() + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);

                //Reset session
                Session.Remove("CR_YearID");
                return;
            }

        }

        protected void ASPxButton3_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ddlYearSal.Text))
            {
                Session["rptPieEmployeeID"] = null;
                Session["rptPeriodID"] = ddlYearSal.SelectedValue;
                Response.Redirect("~/K_ViewReportKPI_Pie.aspx");
            }
            else
            {
                string message = "alert('" + GetGlobalResourceObject("K_ViewEmpKPI", "alert").ToString() + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);

                //Reset session
                Session.Remove("CR_YearID");
                return;
            }

        }

        protected void ASPxGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            try
            {
                string tmp = grid.GetRowValues(-1, "EmployeeID").ToString();
            }
            catch { }
            string employeeid = grid.GetRowValues(e.VisibleIndex, "EmployeeID").ToString();
            int periodid = Convert.ToInt32(ddlYearSal.SelectedValue);
            switch (e.ButtonID)
            {
                // edit news
                case "Edit":
                    Competency_KPIService service = new Competency_KPIService();
                    DataTable dt = service.GetTable_rptEmpKPI("spKPI_GetTable_rptEmpKPI", Session["EmployeeID"].ToString(), periodid);
                    if (dt != null)
                    {
                        //Session["EmpCompetency_KPI_ID"] = grid.GetRowValues(e.VisibleIndex, "EmpCompetency_KPI_ID").ToString();
                        Session["EmpCompetency_KPI_ID"] = dt.Rows[e.VisibleIndex]["EmpCompetency_KPI_ID"].ToString();
                        Session["CurrentReview"] = 1;
                        Session["EmployeeIDReview"] = employeeid;
                        ASPxWebControl.RedirectOnCallback("~/PerformanceAssessment/PAreview.aspx");
                    }
                    break;
                case "Preview":
                    ViewEmployeeKPI wf = new ViewEmployeeKPI();
                    Session["EmpID"] = employeeid;
                    Session["PerID"] = periodid;
                    string url = "ViewEmployeeKPI.aspx";
                    //string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
                    //ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
                    ASPxGridView gridView = sender as ASPxGridView;
                    gridView.JSProperties["cpNewWindowUrl"] = url;
                    break;
                default:
                    break;
            }

        }
    }
}