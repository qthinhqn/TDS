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
    public partial class ViewList : System.Web.UI.Page
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
                    case "G":
                    case "H":
                    case "I":
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

                        case "w":
                            e.DisplayText = GetGlobalResourceObject("AF_Approval", "w").ToString();
                            break;

                        default:
                            e.DisplayText = "";
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

        protected void gvApproval_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            try
            {
                ASPxGridView grid = sender as ASPxGridView;
                object objID = grid.GetRowValues(e.VisibleIndex, "RequestID");
                object empID_Apply = grid.GetRowValues(e.VisibleIndex, "EmpID_Apply");
                switch (e.ButtonID)
                {
                    case "Edit":
                        if (objID != null)
                        {
                            Session["RequestID"] = objID;
                            if (empID_Apply != null && empID_Apply.ToString() != "")
                                ASPxWebControl.RedirectOnCallback("~/Recruitment/DetailReview_2.aspx");
                            else
                                ASPxWebControl.RedirectOnCallback("~/Recruitment/DetailReview.aspx");
                        }
                        break;

                    case "Print":
                        ViewRequisition wf = new ViewRequisition();
                        Session["RequestID"] = objID;
                        ASPxWebControl.RedirectOnCallback("~/Recruitment/ViewRequisition.aspx");
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            { }
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