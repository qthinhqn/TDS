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
using System.Collections.Specialized;

namespace PAOL
{
    public partial class K_ViewEmpKPI : System.Web.UI.Page
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
                LoadPeriod(Session["EmployeeID"].ToString());
            }

            gridRating.DataBind();
            //LoadData();
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
            try
            {
                int PeriodID = Convert.ToInt32(ddlYearSal.SelectedValue);
                Session["PeriodID"] = PeriodID;
            }
            catch (Exception ex)
            {}
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
            gridRating.DataBind();
            /*
            try
            {
                string EmpID = Session["EmployeeID"].ToString();
                int PeriodID = Convert.ToInt32(ddlYearSal.SelectedValue);

                //Session["CR_YearID"] = PeriodID;

                // Load danh sach phieu danh gia
                Competency_KPIService service = new Competency_KPIService();
                DataTable dt = service.GetTable_rptEmpKPI("spKPI_GetTable_rptEmpKPI", EmpID, PeriodID);
                if (dt != null)
                {
                    gridRating.DataSource = dt;
                    gridRating.DataBind();
                }
            }
            catch(Exception ex)
            { }
             */
        }

        protected void ASPxButton2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ddlYearSal.Text))
            {
                Session["rptEmployeeID"] = Session["EmployeeID"];
                Session["rptPeriodID"] = ddlYearSal.SelectedValue;
                Response.Redirect("~/PerformanceAssessment/K_ViewReportKPI.aspx");
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
                Session["rptPeiEmployeeID"] = Session["EmployeeID"];
                Session["rptPeriodID"] = ddlYearSal.SelectedValue;
                Response.Redirect("~/PerformanceAssessment/K_ViewReportKPI_Pie.aspx");
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
            string employeeid = grid.GetRowValues(e.VisibleIndex, "EmployeeID").ToString();
            int approvalid = Convert.ToInt32(grid.GetRowValues(e.VisibleIndex, "ID").ToString());
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
                        Session["PeriodIDReview"] = periodid;
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

                case "Approval":
                    Session["EmpID"] = employeeid;
                    Session["ApprovalID"] = approvalid;
                    //ASPxPopupControl1.ShowOnPageLoad = true;
                    gridRating.JSProperties["cpKeyValue"] = approvalid;
                    break;

                default:
                    break;
            }

            ASPxButton1_Click(null, null);
        }

        protected void popup_WindowCallback(object source, PopupWindowCallbackArgs e)
        {
            txtReason.Text = "input text";
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
            UpdateItem(e.Keys, e.NewValues);
            
            //Hủy chức năng cập nhật tự động của SqlDatasource
            e.Cancel = true;
            LoadData();
        }

        protected void UpdateItem(OrderedDictionary keys, OrderedDictionary newValues)
        {
            try
            {
                Competency_KPIService thucthi = new Competency_KPIService();

                {
                    int period = int.Parse(Session["PeriodID"].ToString());
                    string EmployeeID = keys[1].ToString();
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Competency_KPIService thucthi = new Competency_KPIService();
                string EmployeeID = Session["EmpID"].ToString();
                int period = int.Parse(Session["PeriodID"].ToString());
                int ApprovalID = int.Parse(Session["ApprovalID"].ToString());
                string reason = txtReason.Text;

                object curLevel = thucthi.getCurrentLevel(ApprovalID, Session["EmployeeID"].ToString());

                if (cbbApproval.Value.ToString().Equals("1")) //Trường hợp được duyệt
                {
                    if (thucthi.isLastLevel(ApprovalID, curLevel) || thucthi.isFirstLastLevel(ApprovalID, curLevel))
                    {
                        thucthi.ApproveLast(ApprovalID, curLevel, reason);
                    }
                    else
                    {
                        thucthi.ApproveFirst(ApprovalID, curLevel, reason);
                    }
                }
                else //Trường hợp không phê duyệt
                {
                    thucthi.CancelApproval(ApprovalID, curLevel, reason);
                }
            }
            catch(Exception ex)
            {
                string message = "alert('" + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
            finally
            {
                ASPxPopupControl1.ShowOnPageLoad = false;
                gridRating.DataBind();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ASPxPopupControl1.ShowOnPageLoad = false;
        }

        protected void txtReason_Validation(object sender, DevExpress.Web.ValidationEventArgs e)
        {
            try
            {
                if (cbbApproval.Value.ToString().Equals("0") && txtReason.Text.Equals(""))
                {
                    e.IsValid = false;
                }
                else
                {
                    e.IsValid = true;
                }
            }
            catch (Exception ex) { }
        }

        protected void gridRating_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            try
            {
                object id = e.KeyValue.ToString().Split('|')[0];
                ASPxGridView grid = sender as ASPxGridView;
                object fstatus = grid.GetRowValuesByKeyValue(e.KeyValue, "FinalStatus");

                Competency_KPIService thucthi = new Competency_KPIService();
                object empid = Session["EmployeeID"];
                if (e.DataColumn.Name == "Approval")
                {
                    if (id != null && empid != null)
                    {
                        object curLevel = thucthi.getCurrentLevel(id, empid);
                        object value = e.GetValue("ApprovingStatus_L" + curLevel.ToString());
                        if (value.ToString().Equals(""))
                        {
                            e.Cell.BackColor = System.Drawing.Color.LightGreen;
                        }
                        else
                        {
                            if (Convert.ToBoolean(value) == true)
                            {
                                e.Cell.BackColor = System.Drawing.Color.Yellow;
                            }
                            else
                            {
                                e.Cell.BackColor = System.Drawing.Color.Gray;
                                e.Cell.ForeColor = System.Drawing.Color.White;
                            }
                        }

                        if (fstatus.ToString().Equals("c"))
                        {
                            e.Cell.BackColor = System.Drawing.Color.Gray;
                            e.Cell.ForeColor = System.Drawing.Color.White;
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        protected void gridRating_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            object finalstatus = e.GetValue("FinalStatus");

            if (finalstatus != null)
            {
                if (string.Compare(finalstatus.ToString(), "a", true) == 0)
                {
                    e.Row.BackColor = System.Drawing.Color.White;
                }
                else if (string.Compare(finalstatus.ToString(), "c", true) == 0)
                {
                    e.Row.BackColor = System.Drawing.Color.Gray;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }
            }
        }

        protected void gridRating_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            Competency_KPIService thucthi = new Competency_KPIService();
            int index = e.VisibleIndex;
            if (index < 0)
                index = index + 1;

            try
            {
                
                object id = grid.GetRowValues(index, "ID");
                object managerid = Session["EmployeeID"];
                object curLevel = thucthi.getCurrentLevel(id, managerid);

                if (id != null && managerid != null)
                {
                    if (e.ButtonType == ColumnCommandButtonType.Edit)
                        e.Visible = false; //e.Enabled = false;

                    //Hiện nút edit khi quản lý tới lượt phê duyệt
                    object fstatus = grid.GetRowValues(index, "FinalStatus");
                    if (string.Compare("w", fstatus.ToString(), true) == 0)
                    {
                        object curstatus = grid.GetRowValues(index, "ApprovingStatus_L" + curLevel.ToString());
                        if (curstatus.ToString().Equals(""))
                        {
                            if (e.ButtonType == ColumnCommandButtonType.Edit)
                                    e.Visible = true; //e.Enabled = true;
                        }
                        else
                        {
                            if (thucthi.isFirstLastLevel(id, curLevel) || thucthi.isLastLevel(id, curLevel))
                            {
                                if (e.ButtonType == ColumnCommandButtonType.Edit)
                                        e.Visible = true; //e.Enabled = true;
                            }
                            else
                            {
                                object nextLevel = int.Parse(curLevel.ToString()) + 1;
                                object value = grid.GetRowValues(index, "ApprovingStatus_L" + nextLevel.ToString());
                                if (value.ToString().Equals(""))
                                {
                                    if (e.ButtonType == ColumnCommandButtonType.Edit)
                                        e.Visible = true; //e.Enabled = true;
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                string message = "alert('" + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
        }

        protected void gridRating_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            object id = e.GetFieldValue("ID");
            object empid = Session["EmployeeID"];
            object fstatus = e.GetFieldValue("FinalStatus");

            if (empid != null && id != null)
            {
                Competency_KPIService thucthi = new Competency_KPIService();
                object curLevel = thucthi.getCurrentLevel(id, empid);
                object value = e.GetFieldValue("ApprovingStatus_L" + curLevel.ToString());
                try
                {
                    if (e.Column.Name == "Approval")
                    {
                        if (fstatus != null)
                        {
                            if (value.ToString().Equals(""))
                            {
                                if (string.Compare(fstatus.ToString(), "c", true) == 0)
                                {
                                    e.DisplayText = GetGlobalResourceObject("AF_Approval", "other").ToString();
                                }
                                else
                                {
                                    e.DisplayText = GetGlobalResourceObject("AF_Approval", "w").ToString();
                                }
                            }
                            else
                            {
                                if (Convert.ToBoolean(value) == true)
                                {
                                    if (string.Compare(fstatus.ToString(), "c", true) == 0)
                                    {
                                        e.DisplayText = GetGlobalResourceObject("AF_Approval", "other").ToString();
                                    }
                                    else
                                    {
                                        e.DisplayText = GetGlobalResourceObject("AF_Approval", "a").ToString();
                                    }

                                }
                                else
                                {
                                    e.DisplayText = GetGlobalResourceObject("AF_Approval", "c").ToString();
                                }
                            }

                        }

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
}