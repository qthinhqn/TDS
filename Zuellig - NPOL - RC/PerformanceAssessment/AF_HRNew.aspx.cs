using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.Export;
using DevExpress.XtraPrinting;

namespace PAOL
{
    public partial class AF_HRNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validate Page
            if (Session["EmployeeID"] == null || Session["Role"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (!Session["Role"].ToString().Equals("HR"))
                {
                    Response.Redirect("Login.aspx");
                }
            }

            if (!IsPostBack)
            {
                optWaitApproval.Checked = true;
            }

            // Load data grid
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            tblWebData webdata = new tblWebData(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligPAConnection"].ConnectionString);
            
            //gvHR.DataSource = webdata.GetLeaveData(optChecked.Checked);
            if (optWaitApproval.Checked)
            {
                Session["LeaveDataType"] = true;
                gvHR.DataSourceID = "LeaveDataOds";
                gvHR.Columns[1].Visible = true;
            }
            else
            {
                Session["LeaveDataType"] = false;
                gvHR.DataSourceID = "LeaveDataOds2";
                gvHR.Columns[1].Visible = false;
            }
            gvHR.DataBind();
        }

        protected void gvHR_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridViewTableRowEventArgs e)
        {
            object hrview = e.GetValue("HRview");
            object finalStatus = e.GetValue("FinalStatus");
            if (hrview != null && finalStatus != null)
            {
                if (string.Compare("w", finalStatus.ToString(), true) != 0)
                {
                    if (finalStatus.ToString().Equals("a") || finalStatus.ToString().Equals("A"))
                    {
                        e.Row.BackColor = System.Drawing.Color.Yellow;
                    }

                    if (finalStatus.ToString().Equals("c") || finalStatus.ToString().Equals("C"))
                    {
                        e.Row.BackColor = System.Drawing.Color.Red;
                        e.Row.ForeColor = System.Drawing.Color.White;
                    }
                }
                else
                {
                    if (hrview.ToString().Equals("a") || hrview.ToString().Equals("A"))
                    {
                        e.Row.BackColor = System.Drawing.Color.LightGreen;
                    }
                }
            }
        }

        protected void gvHR_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            //Ẩn toàn bộ nút và checkbox
            //if (e.ButtonType == ColumnCommandButtonType.SelectCheckbox)
            //{
            //    e.Visible = false;
            //}
            //if (e.ButtonType == ColumnCommandButtonType.Edit)
            //{
            //    e.Visible = false;
            //}
            

            //Xét trường hợp để hiện các nút và checkbox đã ẩn
            int index = e.VisibleIndex;
            if (index < 0)
                index = index + 1;
            ASPxGridView grid = sender as ASPxGridView;
            object finalStatus = grid.GetRowValues(index, "FinalStatus");
            object hrStatus = grid.GetRowValues(index, "HRCheckingStatus");
            object hrview = grid.GetRowValues(index, "HRview");

            if (finalStatus != null && hrview != null && hrStatus != null)
            {
                //if (string.Compare("w", finalStatus.ToString(), true) == 0 && string.Compare("a", hrview.ToString(), true) == 0)
                //{
                //    if (e.ButtonType == ColumnCommandButtonType.SelectCheckbox)
                //        e.Visible = true;
                //    if (e.ButtonType == ColumnCommandButtonType.Edit)
                //        e.Visible = true;
                //}
                
                switch(e.ButtonType)
                {
                    case ColumnCommandButtonType.Delete:
                        if (finalStatus.ToString().ToLower().Equals("a") ||
                            finalStatus.ToString().ToLower().Equals("w"))
                            e.Visible = false;
                        else
                            e.Visible = false;
                        break;
                    case ColumnCommandButtonType.Edit:
                    case ColumnCommandButtonType.SelectCheckbox:
                        e.Visible = false;
                        if (finalStatus.ToString().ToLower().Equals("a") )
                            if (hrStatus.ToString().Equals(""))
                                e.Visible = true;
                        break;
                    default:
                        break;
                }
                /* 
                if (hrStatus.ToString().Equals("") && string.Compare(finalStatus.ToString(), "a", true) == 0)
                {
                    if (e.ButtonType == ColumnCommandButtonType.SelectCheckbox)
                        e.Visible = true;
                    if (e.ButtonType == ColumnCommandButtonType.Edit)
                        e.Visible = true;
                    if (e.ButtonType == ColumnCommandButtonType.Delete)
                        e.Visible = false;
                }

                if (finalStatus.ToString().ToLower().Equals("w"))
                {
                    if (e.ButtonType == ColumnCommandButtonType.Delete)
                        e.Visible = false;
                }*/
            }

        }

        protected void gvHR_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name == "HRStatus")
            {
                object value = e.GetFieldValue("HRCheckingStatus");
                object hrview = e.GetFieldValue("HRview");
                if (!value.ToString().Equals(""))
                {
                    if (Convert.ToBoolean(value) == true)
                        e.DisplayText = GetGlobalResourceObject("AF_HRNew", "sync").ToString();
                    else if (Convert.ToBoolean(value) == false)
                        e.DisplayText = GetGlobalResourceObject("AF_HRNew", "unsync").ToString();
                }
                else
                {
                    if (!hrview.ToString().Equals(""))
                    {
                        if (string.Compare("a", hrview.ToString(), true) == 0)
                            e.DisplayText = GetGlobalResourceObject("AF_HRNew", "w").ToString();
                    }
                }
            }
        }

        protected void gvHR_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            //Hủy chế độ cập nhật tự động với SQLDatasource
            e.Cancel = true;

            //Khai báo đối tượng
            tblWebData webdata = new tblWebData(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligPAConnection"].ConnectionString);
            ASPxGridView grid = sender as ASPxGridView;
            object id = e.Keys[0];

            try
            {
                ASPxMemo lydo = grid.FindEditFormTemplateControl("txtHRReason") as ASPxMemo;
                webdata.HRCancel(id, lydo.Text);
                grid.CancelEdit();
                grid.DataBind();
            }
            catch (Exception ex)
            {
                string message = "alert('" + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }

        }

        protected void btnSync_Click(object sender, EventArgs e)
        {
            //"ID", "EmployeeID", "LeaveID", "PerTimeID", "StartDate", "ToDate", "FromTime", "ToTime", "HRCheckingDate", "TotalDays"
            gvHR_SelectionChanged(gvHR, e);

            //Kiểm tra select checkbox
            if (selectedRows.Count <= 0)
            {
                string message = "alert('Vui lòng chọn lượt đăng ký phép cần đồng bộ vào hệ thống HRM')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                return;
            }

            try
            {
                tblWebData webdata = new tblWebData(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligPAConnection"].ConnectionString);

                foreach (object item in selectedRows)
                {
                    object[] arr = item as object[];
                    object id = arr[0];
                    object empid = arr[1];
                    object leaveid = arr[2];
                    object pertimeid = arr[3];
                    object startdate = arr[4];
                    object todate = arr[5];
                    object frmtime = (arr[6] == null ? DBNull.Value : arr[6]);
                    object totime = (arr[7] == null ? DBNull.Value : arr[7]);
                    object totaldays = arr[8];
                    object regdate = DateTime.Today;

                    webdata.HRSync(id, empid, leaveid, pertimeid, startdate, todate, frmtime, totime, regdate, totaldays);
                }
                gvHR.Selection.UnselectAll();
                gvHR.DataBind();
            }
            catch (Exception ex)
            {
                string message = "alert('" + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }

        }

        static List<object> selectedRows = new List<object>();
        protected void gvHR_SelectionChanged(object sender, EventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;
            selectedRows.Clear();
            selectedRows = grid.GetSelectedFieldValues(new string[] { "ID", "EmployeeID", "LeaveID", "PerTimeID", "StartDate", "ToDate", "FromTime", "ToTime", "TotalDays" });
        }

        protected void gvDetail_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["id"] = (sender as DevExpress.Web.ASPxGridView).GetMasterRowKeyValue();
        }

        protected void gvDetail_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            string ketnoi = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligPAConnection"].ConnectionString;
            object finalstatus = new tblWebData(ketnoi).getFinalStatusByID(e.GetFieldValue("ID"));

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
            string ketnoi = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligPAConnection"].ConnectionString;
            object checknum = new tblWebData(ketnoi).getCheckNum(e.KeyValue);

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
                    e.Cell.BackColor = System.Drawing.Color.Red;
                    e.Cell.ForeColor = System.Drawing.Color.White;
                }
            }

            if (e.DataColumn.Name == "approval2")
            {
                object value = e.GetValue("ApprovingStatus_L2");
                object managerName = e.GetValue("ManagerName_L2");
                
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
                    e.Cell.BackColor = System.Drawing.Color.Red;
                    e.Cell.ForeColor = System.Drawing.Color.White;
                }
            }

            if (e.DataColumn.Name == "approval3")
            {
                object value = e.GetValue("ApprovingStatus_L3");
                object managerName = e.GetValue("ManagerName_L3");
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
                    e.Cell.BackColor = System.Drawing.Color.Red;
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
                        e.Cell.BackColor = System.Drawing.Color.Red;
                        e.Cell.ForeColor = System.Drawing.Color.White;
                    }
                }

            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
        }

        protected void gvHR_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;
            object id = e.Keys[0];
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligPAConnection"].ConnectionString);
            if (id != null)
            {
                provider.CommandText = "Delete from tblWebData where ID = @ID";
                provider.ParameterCollection = new string[] { "@ID" };
                provider.ValueCollection = new object[] { id };
                provider.ExecuteNonQuery();
            }
            provider.CloseConnection();
        }

        protected void optWaitApproval_CheckedChanged(object sender, EventArgs e)
        {
            btnSync.Enabled = optWaitApproval.Checked;
        }


    }
}