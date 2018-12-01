using DevExpress.Web;
using PAOL.App_Code.Business;
using PAOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAOL.UserControl
{
    public partial class uc_EmpViewPAHistory : System.Web.UI.UserControl
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
                if (Session["Role"].ToString().Equals("HR"))
                {
                    Response.Redirect("Login.aspx");
                }

                //Trường hợp là nhân viên mới
                if (Session["Role"].ToString().Equals("E1"))
                {
                    Response.Redirect("Login.aspx");
                }
            }

            if (!IsPostBack)
            {
                //Điền dữ liệu chu kỳ đánh giá
                //LoadData();
            }
        }

        public void LoadData()
        {
            try
            {
                string EmpID = Session["EmployeeID"].ToString();

                //Session["CR_YearID"] = PeriodID;

                // Load danh sach phieu danh gia
                //Competency_KPIService service = new Competency_KPIService();
                //DataTable dt = service.GetTable_rptEmpHistory("spKPI_GetTable_rptEmpHistory", EmpID);
                //if (dt != null)
                //{
                //    gridRating.DataSource = dt;
                //    gridRating.DataBind();
                //}
            }
            catch (Exception ex)
            { }
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
            int periodid = Convert.ToInt32(grid.GetRowValues(e.VisibleIndex, "PeriodID").ToString());
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
                        ASPxWebControl.RedirectOnCallback("~/PerformanceAssessment/SelfAssessment_Review.aspx");
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

        protected void gridRating_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType == DevExpress.Web.GridViewRowType.Data)
            {
                e.Row.Height = Unit.Pixel(40);
            }
        }

        protected void gridRating_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                int period = int.Parse(e.Keys[1].ToString());
                tbl_KPI_Period obj = (new KPI_PeriodService()).GetObjectById(period);

                if (DateTime.Now >= obj.StartTime && DateTime.Now < obj.ReviewTime)
                {
                    UpdateItem(e.Keys, e.NewValues);
                }
                else
                {
                }
                

                //Hủy chức năng cập nhật tự động của SqlDatasource
                e.Cancel = true;
            }
            catch(Exception ex)
            { }
        }

        protected void UpdateItem(OrderedDictionary keys, OrderedDictionary newValues)
        {
            try
            {
                Competency_KPIService thucthi = new Competency_KPIService();

                {
                    int period = int.Parse(keys[1].ToString());
                    string EmployeeID = keys[0].ToString();
                    double jobFactor = Convert.ToDouble(newValues["Job_Factor"]);
                    double kpiFactor = Convert.ToDouble(newValues["KPI_Factor"]);

                    thucthi.UpdateFactor(EmployeeID, period, jobFactor, kpiFactor);
                }
            }
            catch (Exception ex)
            {
                string message = "alert('" + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
        }

    }
}