using System;
using System.Collections.Generic;
using System.Web.UI;
using DevExpress.Web;
using NPOL.App_Code.Business;
using System.Data;
using conn = System.Web.Configuration;
using DevExpress.Data.Filtering;

namespace NPOL
{
    public partial class Approval_Recruit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validate Page
            if (Session["EmployeeID"] == null || Session["Role"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {

            }

            if (!IsPostBack)
            {
                Session["RCStatus"] = 'w';
                Session["RecruitTmp"] = true;
                // chi hien thi cho HR tuyen dung va HR director
                switch (RCManager_OpenType(Session["EmployeeID"].ToString()))
                {
                    case "A":
                    case "B":
                    case "D":
                    case "E":
                    case "F":
                        ASPxRadioButton1.Visible = true;
                        break;
                    default:
                        ASPxRadioButton1.Visible = false;
                        break;
                }
            }

            gvApproval.DataBind();
        }

        String RCManager_OpenType(string employeeID)
        {
            String result = "";
            //Code xu ly
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            try
            {
                sqlProvider.CommandText = "Select [Type] from tbl_RCManager_Open A WHERE A.ManagerID = @EmpID AND Status = 0 ";
                sqlProvider.ParameterCollection = new string[] { "@EmpID" };
                sqlProvider.ValueCollection = new object[] { employeeID };
                object obj = sqlProvider.ExecuteScalar();

                if (obj != null)
                {
                    result = obj.ToString();
                }
            }
            catch (Exception ex)
            {

            }
            sqlProvider.CloseConnection();
            return result;
        }
        protected void optWaitApproval_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optWaitApproval.Checked)
                    Session["RCStatus"] = 'w';
                else if (optWaitSync.Checked)
                    Session["RCStatus"] = 'c';
                else if (optChecked.Checked)
                    Session["RCStatus"] = 'a';
                else if (ASPxRadioButton1.Checked)
                    Session["RCStatus"] = 's';
                gvApproval.DataBind();
            }
            catch (Exception ex)
            { }
        }

        protected void txtReason_Validation(object sender, DevExpress.Web.ValidationEventArgs e)
        {
            ASPxComboBox cbb = gvApproval.FindEditFormTemplateControl("cbbApproval") as ASPxComboBox;
            ASPxMemo lydo = gvApproval.FindEditFormTemplateControl("txtReason") as ASPxMemo;

            if (cbb.Value.ToString().Equals("0") && lydo.Text.Equals(""))
            {
                e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
        }
        
        #region // gvApproval Events
        protected void gvApproval_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            string ketnoi = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString;
            ASPxGridView grid = sender as ASPxGridView;
            tblRecruitData thucthi = new tblRecruitData(ketnoi);
            int index = e.VisibleIndex;
            if (index < 0)
                index = index + 1;

            try
            {
                object id = grid.GetRowValues(index, "RequestID");
                object managerid = Session["EmployeeID"];
                object curLevel = thucthi.getCurrentLevel(id, managerid);

                if (id != null && managerid != null)
                {
                    if (e.ButtonType == ColumnCommandButtonType.Edit)
                        e.Visible = false; //e.Enabled = false;

                    //Hiện nút edit khi quản lý tới lượt phê duyệt
                    object fstatus = grid.GetRowValues(index, "FinalStatus");
                    if (fstatus.ToString().Equals("w"))
                    {
                        if (thucthi.AllowUpdate(id, curLevel))
                        {
                            if (e.ButtonType == ColumnCommandButtonType.Edit)
                                e.Visible = true; //e.Enabled = true;
                        }
                        #region // old code
                        /*
                        object curstatus = grid.GetRowValues(index, "ApprovingStatus_L" + curLevel.ToString());
                        //object curmail = grid.GetRowValues(index, "MailToL" + curLevel.ToString());
                        if (curstatus == null || curstatus.ToString() == "")
                        {
                            if ((int)curLevel > 0)
                            {
                                if (e.ButtonType == ColumnCommandButtonType.Edit)
                                    e.Visible = true; //e.Enabled = true;
                            }

                        }
                        else
                        {
                            if (thucthi.isFirstLastLevel(id, curLevel) || thucthi.isLastLevel(id, curLevel))
                            {
                                object hrStatus = grid.GetRowValues(index, "HRCheckingStatus");
                                if (hrStatus.ToString().Equals(""))
                                {
                                    if (e.ButtonType == ColumnCommandButtonType.Edit)
                                        e.Visible = true; //e.Enabled = true;
                                }
                            }
                            else
                            {
                                object nextLevel = thucthi.getNextLevel(id, curLevel);
                                object value = grid.GetRowValues(index, "ApprovingStatus_L" + nextLevel.ToString());
                                if (value.ToString().Equals(""))
                                {
                                    if (e.ButtonType == ColumnCommandButtonType.Edit)
                                        e.Visible = true; //e.Enabled = true;
                                }
                            }
                        }*/
                        #endregion
                    }
                    else if (fstatus.ToString().Equals("a"))
                    {
                        if (e.ButtonType == ColumnCommandButtonType.Edit)
                        {
                            string _type = Check_RCManager_Open(Session["EmployeeID"].ToString());
                            object _HR_Status = grid.GetRowValues(index, "HR_Status");
                            object _Director_Status = grid.GetRowValues(index, "Director_Status");
                            switch (_type)
                            {
                                case "":
                                    break;

                                case "A":
                                    if (_HR_Status.ToString().Equals("w"))
                                        e.Visible = true;
                                    break;

                                case "B":
                                    if (_HR_Status.ToString().Equals("r"))
                                        e.Visible = true;
                                    break;

                                case "C":
                                    if (_HR_Status.ToString().Equals("a") && _Director_Status.ToString().Equals("w"))
                                        e.Visible = true;
                                    break;
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

        private string Check_RCManager_Open(string employeeID)
        {
            string result = "";
            //Code xu ly
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            sqlProvider.CommandText = "Select * from tbl_RCManager_Open Where ManagerID=@EmpID";
            sqlProvider.CommandType = CommandType.Text;
            sqlProvider.ParameterCollection = new string[] { "@EmpID" };
            sqlProvider.ValueCollection = new object[] { employeeID };
            DataTable dt = sqlProvider.GetDataTable();

            if (dt != null && dt.Rows.Count > 0)
            {
                result = dt.Rows[0]["Type"].ToString();
            }
            sqlProvider.CloseConnection();
            return result;
        }

        protected void gvApproval_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            string ketnoi = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString;
            object id = e.GetFieldValue("RequestID");
            object empid = Session["EmployeeID"];
            object fstatus = e.GetFieldValue("FinalStatus");

            tblRecruitData thucthi = new tblRecruitData(ketnoi);
            //object curLevel = thucthi.getCurrentLevel(id, empid);
            object curLevel = e.GetFieldValue("iLevel");

            if (curLevel != null)
            {
                object value = e.GetFieldValue("iL" + curLevel.ToString());
                try
                {
                    if (e.Column.Name == "Approval")
                    {
                        switch (fstatus.ToString().ToLower())
                        {
                            case "c":
                            case "u":
                                e.DisplayText = GetGlobalResourceObject("AF_Approval", "c").ToString();
                                break;

                            case "a":
                            case "s":
                                e.DisplayText = GetGlobalResourceObject("AF_Approval", "a").ToString();
                                break;
                            default:
                                if (value.ToString().Equals(""))
                                    e.DisplayText = GetGlobalResourceObject("AF_Approval", "w").ToString();
                                else if (value.ToString().Equals("1"))
                                    e.DisplayText = GetGlobalResourceObject("AF_Approval", "a").ToString();
                                else if (value.ToString().Equals("0"))
                                    e.DisplayText = GetGlobalResourceObject("AF_Approval", "c").ToString();
                                break;
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

        protected void gvApproval_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            object id = e.KeyValue;
            ASPxGridView grid = sender as ASPxGridView;
            object fstatus = grid.GetRowValuesByKeyValue(id, "FinalStatus");

            string ketnoi = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString;
            tblRecruitData thucthi = new tblRecruitData(ketnoi);
            object empid = Session["EmployeeID"];
            if (e.DataColumn.Name == "Approval")
            {
                if (id != null && empid != null)
                {/*
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
                    }*/
                }
            }

        }

        protected void gvApproval_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                if (e.RowType != GridViewRowType.Data) return;
                string empID_Apply = e.GetValue("EmpID_Apply").ToString();
                if (String.Compare(empID_Apply, "", true) == 0)
                {
                    e.Row.BackColor = System.Drawing.Color.FromArgb(153, 255, 102);
                }
                else
                {

                }

                string duyet = e.GetValue("FinalStatus").ToString();
                if (duyet.Equals("c") || duyet.Equals("C")
                    || duyet.Equals("u") || duyet.Equals("U"))
                {
                    e.Row.BackColor = System.Drawing.Color.Gray;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }
            }
            catch (Exception ex)
            { }
        }

        protected void gvApproval_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            //Hủy chức năng cập nhật tự động của SqlDatasource
            e.Cancel = true;

            //Khai báo đối tượng và biến
            ASPxGridView grid = sender as ASPxGridView;
            ASPxComboBox cbb = grid.FindEditFormTemplateControl("cbbApproval") as ASPxComboBox;
            ASPxMemo lydo = grid.FindEditFormTemplateControl("txtReason") as ASPxMemo;
            ASPxCheckBox chk = grid.FindEditFormTemplateControl("chkDirector") as ASPxCheckBox;
            string ketnoi = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString;
            tblRecruitData thucthi = new tblRecruitData(ketnoi);

            object id = e.Keys[0];
            object ManagerID = Session["EmployeeID"];
            if (ManagerID != null)
            {
                try
                {
                    //object curLevel = thucthi.getCurrentLevel(id, ManagerID);
                    object curLevel = e.Keys[1];
                    if (curLevel != null)
                    {
                        if (cbb.Value.ToString().Equals("1")) //Trường hợp được duyệt
                        {
                            thucthi.Approve_open(id, ManagerID, true, lydo.Text, chk.Checked, curLevel);
                        }
                        else //Trường hợp không phê duyệt
                        {
                            thucthi.Approve_open(id, ManagerID, false, lydo.Text, chk.Checked, curLevel);
                        }

                        //Thoát chế độ edit
                        grid.CancelEdit();

                        //Cập nhật lại lưới
                        grid.DataBind();
                    }
                    else
                    {
                        grid.CancelEdit();
                    }

                }
                catch (Exception ex)
                {
                    string message = "alert('" + ex.Message + "')";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                }
            }

        }
        #endregion

        #region // gvDetail Events
        protected void gvDetail_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["id"] = (sender as DevExpress.Web.ASPxGridView).GetMasterRowKeyValue();
        }

        protected void gvDetail_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            string ketnoi = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString;
            object finalstatus = new tblRecruitData(ketnoi).getFinalStatusByID(e.GetFieldValue("ID"));

            if (e.Column.Name == "managernamel1")
            {
                object value = e.GetFieldValue("ApprovingStatus_L1");
                object managerName = e.GetFieldValue("ManagerName_L1");
                if (value.ToString().Equals(""))
                {

                    if (managerName.ToString().Equals(""))
                    {
                        e.DisplayText = "";
                    }
                    else
                    {
                        if (finalstatus.ToString().ToLower().Equals("a") || finalstatus.ToString().ToLower().Equals("c"))
                        {
                            e.DisplayText = "";
                        }
                    }
                }
            }

            if (e.Column.Name == "approval1")
            {
                object value = e.GetFieldValue("ApprovingStatus_L1");
                object managerName = e.GetFieldValue("ManagerName_L1");

                if (value.ToString().Equals(""))
                {

                    if (managerName.ToString().Equals(""))
                    {
                        e.DisplayText = "";
                    }
                    else
                    {
                        if (finalstatus.ToString().ToLower().Equals("a") || finalstatus.ToString().ToLower().Equals("c"))
                        {
                            e.DisplayText = "";
                        }
                        else
                        {
                            e.DisplayText = GetGlobalResourceObject("AF_Approval", "w").ToString();
                        }
                    }
                }
                else if (value.ToString().Equals("True"))
                {
                    e.DisplayText = GetGlobalResourceObject("AF_Approval", "a").ToString();
                }
                else if (value.ToString().Equals("False"))
                {
                    e.DisplayText = GetGlobalResourceObject("AF_Approval", "c").ToString();
                }
            }

            if (e.Column.Name == "managernamel2")
            {
                object value = e.GetFieldValue("ApprovingStatus_L2");
                object managerName = e.GetFieldValue("ManagerName_L2");
                if (value.ToString().Equals(""))
                {

                    if (managerName.ToString().Equals(""))
                    {
                        e.DisplayText = "";
                    }
                    else
                    {
                        if (finalstatus.ToString().ToLower().Equals("a") || finalstatus.ToString().ToLower().Equals("c"))
                        {
                            e.DisplayText = "";
                        }
                    }
                }
            }

            if (e.Column.Name == "approval2")
            {
                object value = e.GetFieldValue("ApprovingStatus_L2");
                object managerName = e.GetFieldValue("ManagerName_L2");

                if (value.ToString().Equals(""))
                {
                    if (managerName.ToString().Equals(""))
                    {
                        e.DisplayText = "";
                    }
                    else
                    {
                        if (finalstatus.ToString().ToLower().Equals("a") || finalstatus.ToString().ToLower().Equals("c"))
                        {
                            e.DisplayText = "";
                        }
                        else
                        {
                            e.DisplayText = GetGlobalResourceObject("AF_Approval", "w").ToString();
                        }
                    }
                }
                else if (value.ToString().Equals("True"))
                {
                    e.DisplayText = GetGlobalResourceObject("AF_Approval", "a").ToString();
                }
                else if (value.ToString().Equals("False"))
                {
                    e.DisplayText = GetGlobalResourceObject("AF_Approval", "c").ToString();
                }
            }

            if (e.Column.Name == "managernamel3")
            {
                object value = e.GetFieldValue("ApprovingStatus_L3");
                object managerName = e.GetFieldValue("ManagerName_L3");
                if (value.ToString().Equals(""))
                {

                    if (managerName.ToString().Equals(""))
                    {
                        e.DisplayText = "";
                    }
                    else
                    {
                        if (finalstatus.ToString().ToLower().Equals("a") || finalstatus.ToString().ToLower().Equals("c"))
                        {
                            e.DisplayText = "";
                        }
                    }
                }
            }

            if (e.Column.Name == "approval3")
            {
                object value = e.GetFieldValue("ApprovingStatus_L3");
                object managerName = e.GetFieldValue("ManagerName_L3");
                if (value.ToString().Equals(""))
                {
                    if (managerName.ToString().Equals(""))
                    {
                        e.DisplayText = "";
                    }
                    else
                    {
                        if (finalstatus.ToString().ToLower().Equals("a") || finalstatus.ToString().ToLower().Equals("c"))
                        {
                            e.DisplayText = "";
                        }
                        else
                        {
                            e.DisplayText = GetGlobalResourceObject("AF_Approval", "w").ToString();
                        }
                    }
                }
                else if (value.ToString().Equals("True"))
                {
                    e.DisplayText = GetGlobalResourceObject("AF_Approval", "a").ToString();
                }
                else if (value.ToString().Equals("False"))
                {
                    e.DisplayText = GetGlobalResourceObject("AF_Approval", "c").ToString();
                }
            }

            if (e.Column.Name == "hrapproval")
            {
                object hrView = e.GetFieldValue("HRview");
                object hrApproval = e.GetFieldValue("HRCheckingStatus");
                if (!hrView.ToString().Equals("") && !hrApproval.ToString().Equals(""))
                {
                    if (string.Compare("a", hrView.ToString(), true) == 0 && string.Compare(hrApproval.ToString(), "w", true) == 0)
                    {
                        e.DisplayText = GetGlobalResourceObject("AF_Approval", "wsync").ToString();
                    }
                    else if (hrApproval.ToString().Equals("True"))
                    {
                        e.DisplayText = GetGlobalResourceObject("AF_Approval", "sync").ToString();
                    }
                    else if (hrApproval.ToString().Equals("False"))
                    {
                        e.DisplayText = GetGlobalResourceObject("AF_Approval", "unsync").ToString();
                    }
                }
            }

        }

        protected void gvDetail_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            string ketnoi = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString;
            if (e.DataColumn.Name == "approval1")
            {
                object value = e.GetValue("ApprovingStatus_L1");
                object managerName = e.GetValue("ManagerName_L1");

                if (value.ToString().Equals(""))
                {
                    if (!managerName.ToString().Equals(""))
                    {
                        e.Cell.BackColor = System.Drawing.Color.LightGreen;
                    }
                }
                else if (value.ToString().Equals("True"))
                {
                    e.Cell.BackColor = System.Drawing.Color.Yellow;
                }
                else if (value.ToString().Equals("False"))
                {
                    e.Cell.BackColor = System.Drawing.Color.Gray;
                    e.Cell.ForeColor = System.Drawing.Color.White;
                }
            }

            if (e.DataColumn.Name == "approval2")
            {
                object value = e.GetValue("ApprovingStatus_L2");
                object managerName = e.GetValue("ManagerName_L2");
                object checknum = new tblWebData(ketnoi).getCheckNum(e.KeyValue);

                if (value.ToString().Equals(""))
                {
                    if (!managerName.ToString().Equals(""))
                    {
                        if (Convert.ToInt32(checknum) > 1)
                        {
                            e.Cell.BackColor = System.Drawing.Color.LightGreen;
                        }
                    }
                }
                else if (value.ToString().Equals("True"))
                {
                    e.Cell.BackColor = System.Drawing.Color.Yellow;
                }
                else if (value.ToString().Equals("False"))
                {
                    e.Cell.BackColor = System.Drawing.Color.Gray;
                    e.Cell.ForeColor = System.Drawing.Color.White;
                }
            }

            if (e.DataColumn.Name == "approval3")
            {
                object value = e.GetValue("ApprovingStatus_L3");
                object managerName = e.GetValue("ManagerName_L3");
                object checknum = new tblWebData(ketnoi).getCheckNum(e.KeyValue);

                if (value.ToString().Equals(""))
                {
                    if (!managerName.ToString().Equals(""))
                    {
                        if (Convert.ToInt32(checknum) > 2)
                        {
                            e.Cell.BackColor = System.Drawing.Color.LightGreen;
                        }
                    }
                }
                else if (value.ToString().Equals("True"))
                {
                    e.Cell.BackColor = System.Drawing.Color.Yellow;
                }
                else if (value.ToString().Equals("False"))
                {
                    e.Cell.BackColor = System.Drawing.Color.Gray;
                    e.Cell.ForeColor = System.Drawing.Color.White;
                }
            }


            if (e.DataColumn.Name == "hrapproval")
            {
                object hrView = e.GetValue("HRview");
                object hrApproval = e.GetValue("HRCheckingStatus");
                if (!hrView.ToString().Equals("") && !hrApproval.ToString().Equals(""))
                {
                    if (string.Compare("a", hrView.ToString(), true) == 0 && string.Compare(hrApproval.ToString(), "w", true) == 0)
                    {
                        e.Cell.BackColor = System.Drawing.Color.LightGreen;
                    }
                    else if (hrApproval.ToString().Equals("True"))
                    {
                        e.Cell.BackColor = System.Drawing.Color.Yellow;
                    }
                    else if (hrApproval.ToString().Equals("False"))
                    {
                        e.Cell.BackColor = System.Drawing.Color.Gray;
                        e.Cell.ForeColor = System.Drawing.Color.White;
                    }
                }

            }
        }
        #endregion

        protected void btnView_Click(object sender, EventArgs e)
        {
            ASPxButton bt = sender as ASPxButton;
            GridViewDataItemTemplateContainer container = bt.NamingContainer as GridViewDataItemTemplateContainer;
            ASPxGridView grid = container.Grid;
            object otid = grid.GetRowValues(container.VisibleIndex, new string[] { "ID" });

            //Xử lý giá trị biến
            otid = (otid == null ? DBNull.Value : otid);

            //Gán dữ liệu vào Popup control
            //ASPxPopupControl2.ShowOnPageLoad = true;
            //ASPxGridView2.DataSource = OT_DataDetailService.GetTableByid((int)otid);
            //ASPxGridView2.DataBind();

        }

        protected void btnView2_Click(object sender, EventArgs e)
        {
            ASPxButton bt = sender as ASPxButton;
            GridViewDataItemTemplateContainer container = bt.NamingContainer as GridViewDataItemTemplateContainer;
            ASPxGridView grid = container.Grid;
            object otid = grid.GetRowValues(container.VisibleIndex, new string[] { "RequestID" });

            //Xử lý giá trị biến
            otid = (otid == null ? DBNull.Value : otid);

            //Gán dữ liệu vào Popup control
            ASPxPopupControl1.ShowOnPageLoad = true;
            gvOTList.DataSource = Recruit_ApprovalService.GetTableByid(otid.ToString());
            gvOTList.DataBind();

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            ASPxButton bt = sender as ASPxButton;
            GridViewDataItemTemplateContainer container = bt.NamingContainer as GridViewDataItemTemplateContainer;
            ASPxGridView grid = container.Grid;
            object objID = grid.GetRowValues(container.VisibleIndex, new string[] { "RequestID" });
            object empID_Apply = grid.GetRowValues(container.VisibleIndex, new string[] { "EmpID_Apply" });
            //Xử lý giá trị biến
            if (objID != null)
            {
                Session["RequestID"] = objID;
                if (empID_Apply != null && empID_Apply.ToString() != "")
                    Response.Redirect("~/Recruitment/DetailReview_2.aspx");
                else
                    Response.Redirect("~/Recruitment/DetailReview.aspx");
            }
        }

        protected void gvApproval_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            try
            {
                ASPxGridView grid = sender as ASPxGridView;
                object objID = grid.GetRowValues(e.VisibleIndex, "RequestID");
                object empID_Apply = grid.GetRowValues(e.VisibleIndex, "EmpID_Apply");
                switch (e.ButtonID)
                {
                    // edit 
                    case "Edit":
                        if (objID != null)
                        {
                            Session["RequestID"] = objID;
                            Session["LevelNo"] = grid.GetRowValues(e.VisibleIndex, "iLevel");
                            //if (Page.IsCallback)
                            //    ASPxWebControl.RedirectOnCallback(TARGET_URL);
                            //else
                            //    Response.Redirect(TARGET_URL);
                            if (empID_Apply != null && empID_Apply.ToString() != "")
                                //Response.Redirect("~/Recruitment/DetailReview_2.aspx");
                                ASPxWebControl.RedirectOnCallback("~/Recruitment/DetailReview_2.aspx");
                            else
                                //Response.Redirect("~/Recruitment/DetailReview.aspx");
                                ASPxWebControl.RedirectOnCallback("~/Recruitment/DetailReview.aspx");
                        }
                        break;

                    case "Print":
                        //Session["RequestID"] = objID;
                        //string url = "~/Recruitment/DetailReview.aspx";
                        //grid.JSProperties["cpNewWindowUrl"] = url;
                        //break;

                        //ViewRequisition wf = new ViewRequisition();
                        //Session["RequestID"] = objID;
                        //string url = "Recruitment/ViewRequisition.aspx";
                        //ASPxGridView gridView = sender as ASPxGridView;
                        //gridView.JSProperties["cpNewWindowUrl"] = url;

                        ViewRequisition wf = new ViewRequisition();
                        Session["RequestID"] = objID;
                        Session["LevelNo"] = grid.GetRowValues(e.VisibleIndex, "iLevel");
                        ASPxWebControl.RedirectOnCallback("~/Recruitment/ViewRequisition.aspx");
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            { }
        }

        protected void gvApproval_HtmlEditFormCreated(object sender, ASPxGridViewEditFormEventArgs e)
        {
            try
            {
                string _type = Check_RCManager_Open(Session["EmployeeID"].ToString());
                ASPxCheckBox chk = gvApproval.FindEditFormTemplateControl("chkDirector") as ASPxCheckBox;
                if (_type.Equals("B"))
                {
                    chk.Visible = true;
                }
                else
                {
                    chk.Visible = false;
                }
            }
            catch (Exception ex)
            { }
        }

        protected void gvOTList_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {

            if (e.Column.Name == "ApprovingStatusText")
            {
                object value = e.GetFieldValue("ApprovingStatusText");
                switch (value.ToString())
                {
                    case "Chờ duyệt":
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("en"))
                                e.DisplayText = "Waiting";
                        }
                        break;

                    case "Không duyệt":
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("en"))
                                e.DisplayText = "Rejected";
                        }
                        break;

                    case "Đã Duyệt":
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("en"))
                                e.DisplayText = "Approved";
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        protected void cbbShowType_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvApproval.DataBind();

            string f_expression = GetFilterExpression();
            gvApproval.FilterExpression = f_expression;
        }

        protected void gvApproval_DataBinding(object sender, EventArgs e)
        {
            
        }

        private string GetFilterExpression()
        {
            string res_str = string.Empty;
            List<CriteriaOperator> lst_operator = new List<CriteriaOperator>();

            if (cbbShowType.SelectedIndex == 0)
            {
                res_str = "";
            }
            else if (cbbShowType.SelectedIndex == 1)
            {
                res_str = "ISNULL(EmpID_Apply,'') = ''";
            }
            else if (cbbShowType.SelectedIndex == 2)
            {
                res_str = "ISNULL(EmpID_Apply,'') <> ''";
            }

            return res_str;
        }
    }
}