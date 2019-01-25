using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NPOL.Report;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using NPOL.App_Code.Business;
using DevExpress.Web;
using System.Collections.Specialized;
using DevExpress.XtraPrinting;
using DevExpress.Export;
using System.IO;
using DevExpress.Web.ASPxTreeList;
using NPOL.App_Code.Entities;
using NPOL.App_Code.Data;
using conn = System.Web.Configuration;
using DevExpress.Utils;

namespace NPOL
{
    public partial class K_ViewEmpKPI : System.Web.UI.Page
    {
        tbl_KPI_Period objKPI = null;
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

            int period = int.Parse(Session["PeriodID"].ToString());
            objKPI = (new KPI_PeriodService()).GetObjectById(period);

            if (!IsPostBack)
            {
                // Hide checked level 3
                Session["Level3"] = 0;
                Khuong kh = new Khuong(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
                if (kh.IsShowCheckedLevel3(Session["EmployeeID"].ToString()))
                {
                    chkLevel3.Visible = true;
                }
                else
                {
                    chkLevel3.Visible = false;
                }
                //Điền dữ liệu chu kỳ đánh giá
                LoadPeriod(Session["EmployeeID"].ToString());
                // load dl filter
                int PeriodID = 0;
                if (ddlYearSal.SelectedValue != null)
                {
                    PeriodID = Convert.ToInt32(ddlYearSal.SelectedValue);
                    Session["Period_ID"] = PeriodID;
                }
                FilterByManagerService.InitGroup(PeriodID, Session["EmployeeID"].ToString());
                FilterByDepService.InitGroup(PeriodID, Session["EmployeeID"].ToString());
                FilterByLocationService.InitGroup(PeriodID, Session["EmployeeID"].ToString());

                treeListDep.SettingsSelection.Recursive = true;
                treeListDep.UnselectAll();

                treeListManager.SettingsSelection.Recursive = true;
                treeListManager.UnselectAll();

                treeListLocation.SettingsSelection.Recursive = true;
                treeListLocation.UnselectAll();
            }

            #region "IsCallback"

            if (IsPostBack)
            {
                // manager
                if (treeListManager.IsCallback)
                {
                    List<TreeListNode> lNodes = treeListManager.GetSelectedNodes();
                    //clear check
                    int PeriodID = 0;
                    if (ddlYearSal.SelectedValue != null)
                        PeriodID = Convert.ToInt32(ddlYearSal.SelectedValue);
                    FilterByManagerService.CleanCheck(PeriodID, Session["EmployeeID"].ToString());

                    {
                        foreach (TreeListNode node in lNodes)
                        {
                            if (!node.HasChildren)
                            {
                                // update checked
                                tblPA_FilterByManager obj = new tblPA_FilterByManager();
                                obj.ID = int.Parse(node.GetValue("ID").ToString());
                                obj.Status = true;
                                FilterByManagerService service = new FilterByManagerService();
                                service.UpdateByID(obj);
                            }
                        }
                    }
                }

                // Level 3
                if (treeListDep.IsCallback)
                {
                    List<TreeListNode> lNodes = treeListDep.GetSelectedNodes();

                    //clear check
                    int PeriodID = 0;
                    if (ddlYearSal.SelectedValue != null)
                        PeriodID = Convert.ToInt32(ddlYearSal.SelectedValue);
                    FilterByDepService.CleanCheck(PeriodID, Session["EmployeeID"].ToString());

                    if (lNodes.Count > 0)
                    {
                        foreach (TreeListNode node in lNodes)
                        {
                            if (!node.HasChildren)
                            {
                                // update checked
                                tblPA_FilterByDep obj = new tblPA_FilterByDep();
                                obj.ID = int.Parse(node.GetValue("ID").ToString());
                                obj.Status = true;
                                FilterByDepService service = new FilterByDepService();
                                service.UpdateByID(obj);
                            }
                        }
                    }
                }

                if (treeListLocation.IsCallback)
                {
                    List<TreeListNode> lNodes = treeListLocation.GetSelectedNodes();
                    //clear check
                    int PeriodID = 0;
                    if (ddlYearSal.SelectedValue != null)
                        PeriodID = Convert.ToInt32(ddlYearSal.SelectedValue);
                    FilterByLocationService.CleanCheck(PeriodID, Session["EmployeeID"].ToString());

                    foreach (TreeListNode node in lNodes)
                    {
                        // update checked
                        tblPA_FilterByLocation obj = new tblPA_FilterByLocation();
                        obj.ID = (int)node.GetValue("ID");
                        obj.Status = true;
                        FilterByLocationService service = new FilterByLocationService();
                        service.UpdateByID(obj);
                    }
                }
            }

            ASPxCallbackPanel1.EnableCallbackAnimation = true;
            ASPxCallbackPanel1.SettingsLoadingPanel.Enabled = false;
            #endregion
            //LoadData();
            gridRating.DataBind();
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

                if (dt != null && dt.Rows.Count > 0)
                {
                    ddlYearSal.SelectedIndex = 0;
                    ddlYearSal_SelectedIndexChanged(null, null);
                }
            }
            catch (Exception ex)
            { }
        }

        protected void ddlYearSal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Period_ID = Convert.ToInt32(ddlYearSal.SelectedValue);
                Session["Period_ID"] = Period_ID;
                if (KPI_PeriodService.GetKPI_LastActive() != Period_ID)
                {
                    btnApproval.Visible = false;
                    btnReject.Visible = false;
                }
                else
                {
                    objKPI = (new KPI_PeriodService()).GetObjectById(Period_ID);
                    if (DateTime.Now < objKPI.ReviewTime_First || DateTime.Now > objKPI.EndTime)
                    {
                        btnApproval.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            { }
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
                Session["rptPeiEmployeeID"] = Session["EmployeeID"];
                Session["rptPeriodID"] = ddlYearSal.SelectedValue;
                Session["Location"] = "";
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
                        ASPxWebControl.RedirectOnCallback("~/PAreview_1.aspx");
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
                    //gridRating.JSProperties["cpKeyValue"] = approvalid;
                    //if (grid.Selection.IsRowSelected(e.VisibleIndex) == false)
                    //{
                    //    btnSubmit_Click(true);
                    //}
                    //else
                    //{
                    //    btnApproval_Click(null, e);
                    //}
                    btnSubmit_Click(true);
                    break;

                case "Reject":
                    Session["EmpID"] = employeeid;
                    Session["ApprovalID"] = approvalid;
                    //if (grid.Selection.IsRowSelected(e.VisibleIndex) == false)
                    //{
                    Session["RejectGroup"] = null;
                    //}
                    //else
                    //{
                    //    Session["RejectGroup"] = true;
                    //}
                    ASPxPopupControl1.ShowOnPageLoad = true;
                    gridRating.JSProperties["cpKeyValue"] = approvalid;
                    //btnReject_Click(null, e);
                    break;

                default:
                    break;
            }

            //ASPxButton1_Click(null, null);
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
                    int period = int.Parse(Session["Period_ID"].ToString());
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
                Session["Reason"] = txtReason.Text.Trim();

                if (Session["RejectGroup"] != null)
                    btnReject_Click(null, e);
                else
                    btnSubmit_Click(false);
            }
            catch (Exception ex)
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

        protected void btnSubmit_Click(bool type)
        {
            try
            {
                Competency_KPIService thucthi = new Competency_KPIService();
                string EmployeeID = Session["EmpID"].ToString();
                int period = int.Parse(Session["Period_ID"].ToString());
                int ApprovalID = int.Parse(Session["ApprovalID"].ToString());
                string reason = "";// txtReason.Text;

                object curLevel = thucthi.getCurrentLevel(ApprovalID, Session["EmployeeID"].ToString());

                if (type) //Trường hợp được duyệt
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
                    reason = txtReason.Text;
                    thucthi.CancelApproval(ApprovalID, curLevel, reason);
                    // ghi lai t/h goi mail nhac

                }
            }
            catch (Exception ex)
            {
                string message = "alert('" + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
            finally
            {
                //ASPxPopupControl1.ShowOnPageLoad = false;
                gridRating.DataBind();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["Reason"] = null;
            ASPxPopupControl1.ShowOnPageLoad = false;
        }

        protected void txtReason_Validation(object sender, DevExpress.Web.ValidationEventArgs e)
        {
            try
            {
                if (txtReason.Text.Equals(""))
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
                                //e.Cell.BackColor = System.Drawing.Color.Yellow;
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
                    //e.Row.BackColor = System.Drawing.Color.Yellow;
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
                object curLevel = grid.GetRowValues(index, "curRank");
                object numOfRank = grid.GetRowValues(index, "NumOfRank");
                object Approval_L1 = grid.GetRowValues(index, "ApprovingStatus_L1");
                object Approval_L2 = grid.GetRowValues(index, "ApprovingStatus_L2");
                object Approval_L3 = grid.GetRowValues(index, "ApprovingStatus_L3");
                object Approval_L4 = grid.GetRowValues(index, "ApprovingStatus_L4");

                if (id != null && managerid != null)
                {
                    // Da public ky danh gia thi khong cho Select nua
                    int period = int.Parse(Session["PeriodID"].ToString());
                    objKPI = (new KPI_PeriodService()).GetObjectById(period);
                    object fstatus = grid.GetRowValues(index, "FinalStatus");
                    if (string.Compare("p", fstatus.ToString(), true) == 0)
                    {

                        if (e.ButtonType == ColumnCommandButtonType.SelectCheckbox)
                        {
                            e.Enabled = false;
                        }
                        return;
                    }
                    else
                    {
                        if (e.ButtonType != ColumnCommandButtonType.SelectCheckbox)
                        {
                            return;
                        }
                        object curstatus = grid.GetRowValues(index, "ApprovingStatus_L" + curLevel.ToString());
                        switch (numOfRank.ToString())
                        {
                            case "1": // 
                                switch (curLevel.ToString())
                                {
                                    case "1": // 
                                        if (DateTime.Now >= objKPI.ReviewTime_First && DateTime.Now < objKPI.EndTime)
                                        {
                                            // cho edit
                                        }
                                        else
                                        {
                                            // khong cho edit
                                            checkChuKyPhu_2(e, 3);
                                        }
                                        break;
                                }
                                break;

                            case "2": //
                                switch (curLevel.ToString())
                                {
                                    case "1": // 
                                        // update theo yeu cau Ms Tram [11.01.18]
                                        //if (DateTime.Now >= objKPI.ReviewTime_First && DateTime.Now < objKPI.ApprovalTime)
                                        if (DateTime.Now >= objKPI.ReviewTime_First && DateTime.Now < objKPI.EndTime)
                                        {
                                            // cho edit
                                            if (Approval_L2.ToString().ToLower().Equals("true"))
                                            {
                                                //Update 10.01.2019
                                                //e.Visible = false;
                                            }
                                        }
                                        else
                                        {
                                            // khong cho edit
                                            checkChuKyPhu_2(e, 2);
                                        }

                                        if (fstatus.ToString().Equals("a"))
                                        {
                                            //Update 10.01.2019
                                            //e.Visible = false;
                                        }
                                        break;

                                    case "2": //
                                        if (DateTime.Now >= objKPI.ReviewTime_First && DateTime.Now < objKPI.EndTime)
                                        {
                                            // cho edit
                                        }
                                        else
                                        {
                                            // khong cho edit
                                            checkChuKyPhu_2(e, 3);
                                        }

                                        if (Approval_L1.ToString().ToLower().Equals("") || fstatus.ToString().Equals("b"))
                                        {
                                            e.Visible = false;
                                        }
                                        break;
                                }
                                break;

                            case "3": // 
                                switch (curLevel.ToString())
                                {
                                    case "1": // 
                                        if (DateTime.Now >= objKPI.ReviewTime_First && DateTime.Now < objKPI.ReviewTime)
                                        {
                                            // cho edit
                                            if (Approval_L2.ToString().ToLower().Equals("true"))
                                            {
                                                e.Visible = false;
                                            }
                                        }
                                        else
                                        {
                                            // khong cho edit
                                            e.Visible = false;
                                        }

                                        if (Approval_L2.ToString().ToLower().Equals("false"))
                                        {
                                        }
                                        break;

                                    case "2": //
                                        // update theo yeu cau Ms Tram [11.01.18]
                                        //if (DateTime.Now >= objKPI.ReviewTime_First && DateTime.Now < objKPI.ApprovalTime)
                                        if (DateTime.Now >= objKPI.ReviewTime_First && DateTime.Now < objKPI.EndTime)
                                        {
                                            // cho edit
                                            if (Approval_L3.ToString().ToLower().Equals("true"))
                                            {
                                                //Update 10.01.2019
                                                //e.Visible = false;
                                            }
                                        }
                                        else
                                        {
                                            // khong cho edit
                                            checkChuKyPhu_2(e, 2);
                                        }

                                        if (Approval_L3.ToString().ToLower().Equals("false"))
                                        {

                                        }

                                        if (Approval_L1.ToString().ToLower().Equals(""))
                                        {
                                            //Update 10.01.2019
                                            //e.Visible = false;
                                        }

                                        if (fstatus.ToString().Equals("a"))
                                        {
                                            //Update 10.01.2019
                                            //e.Visible = false;
                                        }
                                        break;

                                    case "3": // 
                                        if (DateTime.Now >= objKPI.ReviewTime && DateTime.Now < objKPI.EndTime)
                                        {
                                            // cho edit
                                        }
                                        else
                                        {
                                            // khong cho edit
                                            checkChuKyPhu_2(e, 3);
                                        }

                                        if (Approval_L2.ToString().ToLower().Equals("") || fstatus.ToString().Equals("b"))
                                        {
                                            e.Visible = false;
                                        }
                                        break;
                                }
                                break;
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                string message = "alert('" + ex.Message + "')";
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
        }

        protected void gridRating_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            try
            {
                
                object id = e.GetFieldValue("ID");
                object empid = Session["EmployeeID"];
                object fstatus = e.GetFieldValue("FinalStatus");
                object pa_Check = e.GetFieldValue("PA_Check");

                if (empid != null && id != null)
                {
                    if (empid.ToString().ToUpper() == "HR018")
                    {
                        if (e.Column.Name == "Approval")
                        {
                            if (fstatus != null)
                            {
                                if (string.Compare(fstatus.ToString(), "c", true) == 0)
                                {
                                    e.DisplayText = GetGlobalResourceObject("AF_Approval", "other").ToString();
                                }
                                else if (string.Compare(fstatus.ToString(), "a", true) == 0)
                                {
                                    e.DisplayText = GetGlobalResourceObject("AF_Approval", "a").ToString();
                                }
                                else
                                {
                                    e.DisplayText = GetGlobalResourceObject("AF_Approval", "w").ToString();
                                }
                            }
                            // moi Them 15.12
                            if ((bool)pa_Check == false)
                            {
                                e.DisplayText = GetGlobalResourceObject("K_ViewEmpKPI", "pa_Check").ToString();
                            }
                        }
                        return;
                    }
                    Competency_KPIService thucthi = new Competency_KPIService();
                    object curLevel = thucthi.getCurrentLevel(id, empid);
                    object value = e.GetFieldValue("ApprovingStatus_L" + curLevel.ToString());
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
                            else if (string.Compare(fstatus.ToString(), "b", true) == 0)
                            {
                                // t/h mo chu ky phu
                                object value_l3 = e.GetFieldValue("Approval_L3");
                                if (curLevel.ToString() == "1" && value_l3.ToString() != "")
                                {
                                    e.DisplayText = GetGlobalResourceObject("AF_Approval", "a").ToString();
                                }
                                else
                                {
                                    e.DisplayText = GetGlobalResourceObject("AF_Approval", "b").ToString();
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
                                    object pre_value = e.GetFieldValue("ApprovingStatus_L" + ((int)curLevel - 1).ToString());
                                    if (Convert.ToBoolean(pre_value) == true && string.Compare(fstatus.ToString(), "w", true) == 0)
                                    {
                                        e.DisplayText = GetGlobalResourceObject("AF_Approval", "b").ToString();
                                    }
                                    else
                                    {
                                        e.DisplayText = GetGlobalResourceObject("AF_Approval", "c").ToString();
                                    }
                                }
                            }

                        }

                    }

                    // moi Them 15.12
                    if ((bool)pa_Check == false)
                    {
                        if (e.Column.Name == "Approval")
                        {
                            e.DisplayText = GetGlobalResourceObject("K_ViewEmpKPI", "pa_Check").ToString();
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                string message = "alert('" + ex.Message + "')";
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
        }

        protected void ASPxButton_Export_Click(object sender, EventArgs e)
        {
            try
            {
                gridExport.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
            }
            catch (Exception ex)
            {

            }
        }

        protected void ASPxCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Session["Level3"] = chkLevel3.Checked;
        }

        protected void ASPxCheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void treeListManager_CustomDataCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomDataCallbackEventArgs e)
        {
            ASPxTreeList treeList = (ASPxTreeList)sender;
            List<TreeListNode> lNodes = treeList.GetSelectedNodes();
            //clear check
            int PeriodID = 0;
            if (ddlYearSal.SelectedValue != null)
                PeriodID = Convert.ToInt32(ddlYearSal.SelectedValue);
            FilterByManagerService.CleanCheck(PeriodID, Session["EmployeeID"].ToString());

            {
                foreach (TreeListNode node in lNodes)
                {
                    if (!node.HasChildren)
                    {
                        // update checked
                        tblPA_FilterByManager obj = new tblPA_FilterByManager();
                        obj.ID = (int)node.GetValue("ID");
                        obj.Status = true;
                        FilterByManagerService service = new FilterByManagerService();
                        service.UpdateByID(obj);
                    }
                }
            }
            gridRating.DataBind();
        }

        protected void treeListDep_CustomDataCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomDataCallbackEventArgs e)
        {
            ASPxTreeList treeList = (ASPxTreeList)sender;
            List<TreeListNode> lNodes = treeList.GetSelectedNodes();
            if (lNodes.Count == 0)
            {
                //clear check
                int PeriodID = 0;
                if (ddlYearSal.SelectedValue != null)
                    PeriodID = Convert.ToInt32(ddlYearSal.SelectedValue);
                FilterByDepService.CleanCheck(PeriodID, Session["EmployeeID"].ToString());
            }
            else
            {
                foreach (TreeListNode node in lNodes)
                {
                    if (!node.HasChildren)
                    {
                        // update checked
                        tblPA_FilterByDep obj = new tblPA_FilterByDep();
                        obj.ID = (int)node.GetValue("ID");
                        obj.Status = true;
                        FilterByDepService service = new FilterByDepService();
                        service.UpdateByID(obj);
                    }
                }
            }
            gridRating.DataBind();
        }

        protected void treeList_DataBound(object sender, EventArgs e)
        {
            //SetNodeSelectionSettings(sender);
        }

        void SetNodeSelectionSettings(object sender)
        {
            ASPxTreeList treeList = (ASPxTreeList)sender;
            TreeListNodeIterator iterator = treeList.CreateNodeIterator();
            TreeListNode node;
            while (true)
            {
                node = iterator.GetNext();
                if (node == null) break;
            }
        }

        protected void btnApproval_Click(object sender, EventArgs e)
        {
            gvHR_SelectionChanged(gridRating, e);

            //Kiểm tra select checkbox
            if (selectedRows.Count <= 0)
            {
                string message = "alert('" + GetGlobalResourceObject("K_ViewEmpKPI", "alertSelectNull").ToString() + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                return;
            }

            try
            {
                tblWebData webdata = new tblWebData(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);

                foreach (object item in selectedRows)
                {
                    object[] arr = item as object[];
                    object id = arr[0];
                    object empid = arr[1];
                    object period_id = arr[2];

                    ApprovalAssessment(id, empid, period_id);
                }
                gridRating.Selection.UnselectAll();
                gridRating.DataBind();
            }
            catch (Exception ex)
            {
                string message = "alert('" + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
        }

        private void ApprovalAssessment(object approvalid, object empid, object period_id)
        {
            try
            {
                Competency_KPIService thucthi = new Competency_KPIService();
                object curLevel = thucthi.getCurrentLevel(approvalid, Session["EmployeeID"].ToString());

                //Trường hợp được duyệt
                if (thucthi.isLastLevel(approvalid, curLevel) || thucthi.isFirstLastLevel(approvalid, curLevel))
                {
                    thucthi.ApproveLast(approvalid, curLevel, "");
                }
                else
                {
                    thucthi.ApproveFirst(approvalid, curLevel, "");
                }
            }
            catch (Exception ex)
            {
                string message = "alert('" + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
            finally
            {

            }
        }

        static List<object> selectedRows = new List<object>();
        protected void gvHR_SelectionChanged(object sender, EventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;
            selectedRows.Clear();
            selectedRows = grid.GetSelectedFieldValues(new string[] { "ID", "EmployeeID", "Period_ID" });
        }

        protected void gridRating_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
        {
            if (e.ButtonID != "Edit" && e.ButtonID != "Approval" && e.ButtonID != "Reject")
            {
                return;
            }

            ASPxGridView grid = sender as ASPxGridView;
            Competency_KPIService thucthi = new Competency_KPIService();
            int index = e.VisibleIndex;
            if (index < 0)
                return;

            try
            {
                object id = grid.GetRowValues(index, "ID");
                object managerid = Session["EmployeeID"];
                //object curLevel = thucthi.getCurrentLevel(id, managerid);
                object curLevel = grid.GetRowValues(index, "curRank");
                object numOfRank = grid.GetRowValues(index, "NumOfRank");
                object Approval_L1 = grid.GetRowValues(index, "ApprovingStatus_L1");
                object Approval_L2 = grid.GetRowValues(index, "ApprovingStatus_L2");
                object Approval_L3 = grid.GetRowValues(index, "ApprovingStatus_L3");
                object Approval_L4 = grid.GetRowValues(index, "ApprovingStatus_L4");

                // Khong phai la QL thi thoi
                if (curLevel == null || curLevel.ToString() == "")
                {
                    if (e.ButtonID == "Edit" || e.ButtonID == "Approval" || e.ButtonID == "Reject")
                    {
                        e.Visible = DefaultBoolean.False;
                    }
                    return;
                }

                if (id != null && managerid != null && objKPI != null)
                {
                    //Hiện nút edit khi quản lý tới lượt phê duyệt
                    object fstatus = grid.GetRowValues(index, "FinalStatus");
                    if (string.Compare("p", fstatus.ToString(), true) == 0)
                    {
                        // Da public ky danh gia thi khong cho edit nua
                        if (e.ButtonID == "Edit" || e.ButtonID == "Approval" || e.ButtonID == "Reject")
                        {
                            e.Visible = DefaultBoolean.False;
                            e.Column.ShowSelectCheckbox = false;
                        }
                    }
                    else
                    {
                        if (e.ButtonID == "Reject")
                        {
                            if (numOfRank.ToString().Equals("1") || curLevel.ToString().Equals("1"))
                            {
                                e.Visible = DefaultBoolean.False;
                                return;
                            }
                        }

                        object curstatus = grid.GetRowValues(index, "ApprovingStatus_L" + curLevel.ToString());
                        switch (numOfRank.ToString())
                        {
                            case "1": // 
                                switch (curLevel.ToString())
                                {
                                    case "1": // 
                                        if (DateTime.Now >= objKPI.ReviewTime_First && DateTime.Now < objKPI.EndTime)
                                        {
                                            // cho edit
                                        }
                                        else
                                        {
                                            // khong cho edit
                                            if (e.ButtonID == "Reject")
                                            {
                                                e.Visible = DefaultBoolean.False;
                                            }
                                            else if (e.ButtonID == "Edit" || e.ButtonID == "Approval")
                                            {
                                                checkChuKyPhu(e, 3);
                                            }
                                        }
                                        break;
                                }
                                break;

                            case "2": //
                                switch (curLevel.ToString())
                                {
                                    case "1": // 
                                        // update theo yeu cau Ms Tram [11.01.18]
                                        //if (DateTime.Now >= objKPI.ReviewTime_First && DateTime.Now < objKPI.ApprovalTime)
                                        if (DateTime.Now >= objKPI.ReviewTime_First && DateTime.Now < objKPI.EndTime)
                                        {
                                            // cho edit
                                            if (Approval_L2.ToString().ToLower().Equals("true"))
                                            {
                                                if (e.ButtonID == "Edit" || e.ButtonID == "Approval" || e.ButtonID == "Reject")
                                                {
                                                    //Update 10.01.2019
                                                    //e.Visible = DefaultBoolean.False;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            // khong cho edit
                                            if (e.ButtonID == "Reject")
                                            {
                                                e.Visible = DefaultBoolean.False;
                                            }
                                            else if (e.ButtonID == "Edit" || e.ButtonID == "Approval")
                                            {
                                                checkChuKyPhu(e, 2);
                                            }
                                        }

                                        if (Approval_L2.ToString().ToLower().Equals("false"))
                                        {
                                            if (e.ButtonID == "Edit" || e.ButtonID == "Approval")
                                            {
                                                e.Visible = DefaultBoolean.True;
                                            }
                                        }

                                        if (fstatus.ToString().Equals("a"))
                                        {
                                            if (e.ButtonID == "Edit" || e.ButtonID == "Approval")
                                            {
                                                //Update 10.01.2019
                                                //e.Visible = DefaultBoolean.False;
                                            }
                                        }
                                        break;

                                    case "2": //
                                        if (DateTime.Now >= objKPI.ReviewTime_First && DateTime.Now < objKPI.EndTime)
                                        {
                                            // cho edit
                                        }
                                        else
                                        {
                                            // khong cho edit
                                            checkChuKyPhu(e, 3);
                                        }

                                        if (Approval_L1.ToString().ToLower().Equals("") || fstatus.ToString().Equals("b"))
                                        {
                                            if (e.ButtonID == "Edit" || e.ButtonID == "Approval" || e.ButtonID == "Reject")
                                            {
                                                //Update 10.01.2019
                                                //e.Visible = DefaultBoolean.False;
                                            }
                                        }
                                        break;
                                }
                                break;

                            case "3": // 
                                switch (curLevel.ToString())
                                {
                                    case "1": // 
                                        if (DateTime.Now >= objKPI.ReviewTime_First && DateTime.Now < objKPI.ReviewTime)
                                        {
                                            // cho edit
                                            if (Approval_L2.ToString().ToLower().Equals("true"))
                                            {
                                                if (e.ButtonID == "Edit" || e.ButtonID == "Approval" || e.ButtonID == "Reject")
                                                {
                                                    e.Visible = DefaultBoolean.False;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            // khong cho edit
                                            checkChuKyPhu(e, 1);
                                            return;
                                        }

                                        if (Approval_L2.ToString().ToLower().Equals("false"))
                                        {
                                            if (e.ButtonID == "Edit" || e.ButtonID == "Approval")
                                            {
                                                e.Visible = DefaultBoolean.True;
                                            }
                                        }
                                        break;

                                    case "2": //
                                        // update theo yeu cau Ms Tram [11.01.18]
                                        //if (DateTime.Now >= objKPI.ReviewTime_First && DateTime.Now < objKPI.ApprovalTime)
                                        if (DateTime.Now >= objKPI.ReviewTime_First && DateTime.Now < objKPI.EndTime)
                                        {
                                            // cho edit
                                            if (Approval_L3.ToString().ToLower().Equals("true"))
                                            {
                                                if (e.ButtonID == "Edit" || e.ButtonID == "Approval" || e.ButtonID == "Reject")
                                                {
                                                    // Update 10.01.2019
                                                    //e.Visible = DefaultBoolean.False;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            // khong cho edit
                                            if (e.ButtonID == "Reject")
                                            {
                                                e.Visible = DefaultBoolean.False;
                                            }
                                            else if (e.ButtonID == "Edit" || e.ButtonID == "Approval")
                                            {
                                                checkChuKyPhu(e, 2);
                                            }
                                        }

                                        if (Approval_L3.ToString().ToLower().Equals("false"))
                                        {
                                            if (e.ButtonID == "Edit" || e.ButtonID == "Approval")
                                            {
                                                e.Visible = DefaultBoolean.True;
                                            }
                                        }

                                        if (Approval_L1.ToString().ToLower().Equals(""))
                                        {
                                            if (e.ButtonID == "Edit" || e.ButtonID == "Approval" || e.ButtonID == "Reject")
                                            {
                                                // Update 10.01.2019
                                                //e.Visible = DefaultBoolean.False;
                                            }
                                        }

                                        if (fstatus.ToString().Equals("a"))
                                        {
                                            if (e.ButtonID == "Edit" || e.ButtonID == "Approval")
                                            {
                                                // Update 10.01.2019
                                                //e.Visible = DefaultBoolean.False;
                                            }
                                        }
                                        break;

                                    case "3": // 
                                        if (DateTime.Now >= objKPI.ReviewTime && DateTime.Now < objKPI.EndTime)
                                        {
                                            // cho edit
                                        }
                                        else
                                        {
                                            // khong cho edit
                                            string _emp = grid.GetRowValues(index, "EmployeeID").ToString();
                                            checkChuKyPhu(e, 3);
                                        }

                                        if (Approval_L2.ToString().ToLower().Equals("") || fstatus.ToString().Equals("b"))
                                        {
                                            if (e.ButtonID == "Edit" || e.ButtonID == "Approval" || e.ButtonID == "Reject")
                                            {
                                                e.Visible = DefaultBoolean.False;
                                            }
                                        }
                                        break;
                                }
                                break;
                        }
                        /*
                        switch (curstatus.ToString().ToLower())
                        {
                            case "": // chua phe duyet
                                if (e.ButtonID == "Edit" || e.ButtonID == "Approval")
                                {
                                    e.Visible = DefaultBoolean.True;
                                }
                                break;

                            case "false": // tu choi
                                if (e.ButtonID == "Edit" || e.ButtonID == "Reject")
                                {
                                    e.Visible = DefaultBoolean.False;
                                }
                                break;

                            case "true": // approval
                                if (e.ButtonID == "Edit" || e.ButtonID == "Approval")
                                {
                                    e.Visible = DefaultBoolean.False;
                                }
                                break;
                        }
                            if (thucthi.isFirstLastLevel(id, curLevel) || thucthi.isLastLevel(id, curLevel))
                            {
                                if (e.ButtonID == "Edit" || e.ButtonID == "Approval")
                                {
                                    e.Visible = DefaultBoolean.True;
                                }
                            }
                            else
                            {
                                object nextLevel = int.Parse(curLevel.ToString()) + 1;
                                object value = grid.GetRowValues(index, "ApprovingStatus_L" + nextLevel.ToString());
                                if (value.ToString().Equals(""))
                                {
                                    if (e.ButtonID == "Edit" || e.ButtonID == "Approval")
                                    {
                                        e.Visible = DefaultBoolean.True;
                                    }
                                }
                            }
                        }
                         * */
                    }
                }

            }
            catch (Exception ex)
            {
                string message = "alert('" + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
        }
        private void checkChuKyPhu(ASPxGridViewCustomButtonEventArgs e, int level)
        {
            try
            {
                int period = int.Parse(Session["Period_ID"].ToString());
                //string EmployeeID = Session["EmployeeID"].ToString();
                string EmployeeID = gridRating.GetRowValues(e.VisibleIndex, "EmployeeID").ToString();
                SubPeriodService service = new SubPeriodService();

                DataTable dt = service.GetListByID(period, EmployeeID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    switch (level)
                    {
                        case 1:
                            e.Visible = DefaultBoolean.False;
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
                    e.Visible = DefaultBoolean.False;
                }
            }
            catch { }
        }
        private void checkChuKyPhu_2(ASPxGridViewCommandButtonEventArgs e, int level)
        {
            try
            {
                int period = int.Parse(Session["Period_ID"].ToString());
                //string EmployeeID = Session["EmployeeID"].ToString();
                string EmployeeID = gridRating.GetRowValues(e.VisibleIndex, "EmployeeID").ToString();
                SubPeriodService service = new SubPeriodService();

                DataTable dt = service.GetListByID(period, EmployeeID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    switch (level)
                    {
                        case 1:
                            e.Visible = false;
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
                    e.Visible = false;
                }
            }
            catch { }
        }
        protected void btnReject_Click(object sender, EventArgs e)
        {
            Session["Reason"] = "";
            gvHR_SelectionChanged(gridRating, e);

            //Kiểm tra select checkbox
            if (selectedRows.Count <= 0)
            {
                string message = "alert('" + GetGlobalResourceObject("K_ViewEmpKPI", "alertSelectNull").ToString() + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                return;
            }

            try
            {
                tblWebData webdata = new tblWebData(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);

                foreach (object item in selectedRows)
                {
                    object[] arr = item as object[];
                    object id = arr[0];
                    object empid = arr[1];
                    object period_id = arr[2];

                    RejectAssessment(id, empid, period_id);
                }
                gridRating.Selection.UnselectAll();
                gridRating.DataBind();
            }
            catch (Exception ex)
            {
                string message = "alert('" + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
            finally
            {
                //ASPxPopupControl1.ShowOnPageLoad = false;
                gridRating.DataBind();
            }
        }
        private void RejectAssessment(object approvalid, object empid, object period_id)
        {
            try
            {
                Competency_KPIService thucthi = new Competency_KPIService();
                object curLevel = thucthi.getCurrentLevel(approvalid, Session["EmployeeID"].ToString());
                string reason = Session["Reason"].ToString();

                //Trường hợp không được duyệt
                thucthi.CancelApproval(approvalid, curLevel, reason);
                // ghi lai t/h goi mail nhac
            }
            catch (Exception ex)
            {
                string message = "alert('" + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
            finally
            {

            }
        }

        protected void treeListLocation_CustomDataCallback(object sender, TreeListCustomDataCallbackEventArgs e)
        {
            ASPxTreeList treeList = (ASPxTreeList)sender;
            List<TreeListNode> lNodes = treeList.GetSelectedNodes();
            //clear check
            int PeriodID = 0;
            if (ddlYearSal.SelectedValue != null)
                PeriodID = Convert.ToInt32(ddlYearSal.SelectedValue);
            FilterByLocationService.CleanCheck(PeriodID, Session["EmployeeID"].ToString());

            foreach (TreeListNode node in lNodes)
            {
                // update checked
                tblPA_FilterByLocation obj = new tblPA_FilterByLocation();
                obj.ID = (int)node.GetValue("ID");
                obj.Status = true;
                FilterByLocationService service = new FilterByLocationService();
                service.UpdateByID(obj);
            }
            gridRating.DataBind();
        }
        /*
        protected void txtReason_Validation(object sender, DevExpress.Web.ValidationEventArgs e)
        {
            if (txtReason.Text.Equals(""))
            {
                e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
        }

        protected void ASPxButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Session["Reason"] = txtReason.Text.Trim();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                ASPxPopupControl1.ShowOnPageLoad = false;
            }
        }

        protected void ASPxButtonCancle_Click(object sender, EventArgs e)
        {
            try
            {
                Session["Reason"] = null;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                ASPxPopupControl1.ShowOnPageLoad = false;
            }
        }
        */
    }
}