using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.Export;
using DevExpress.XtraPrinting;
using NPOL.App_Code.Business;
using DevExpress.Data.Filtering;

namespace NPOL
{
    public partial class RC_Synchronize : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validate Page
            if (Session["EmployeeID"] == null || Session["Role"] == null || !Session["Role"].ToString().Equals("RC_Admin"))
            {
                Response.Redirect("../Login.aspx");
            }

            if (!IsPostBack)
            {
                optWaitSync.Checked = true;
                Session["FinalStatus"] = '2';
            }
            if (optWaitApproval.Checked)
            {
                //gvHR.Columns["Approval"].Visible = false;
                gvHR.Columns[1].Visible = true;
                gvHR.Columns["YCTD_ID"].Visible = false;
            }
            else if (optWaitSync.Checked)
            {
                //gvHR.Columns["Approval"].Visible = true;
                gvHR.Columns[1].Visible = true;
                gvHR.Columns["YCTD_ID"].Visible = false;
            }
            else if (optChecked.Checked)
            {
                //gvHR.Columns["Approval"].Visible = true;
                gvHR.Columns[1].Visible = false;
                gvHR.Columns["YCTD_ID"].Visible = true;
            }

            gvHR.DataBind();
        }

        protected void gvHR_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridViewTableRowEventArgs e)
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

        protected void gvHR_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            switch (e.ButtonType)
            {
                case ColumnCommandButtonType.Delete:
                    if (optWaitSync.Checked || optWaitApproval.Checked)
                        e.Visible = true;
                    else
                        e.Visible = false;
                    break;
                case ColumnCommandButtonType.Edit:
                case ColumnCommandButtonType.SelectCheckbox:
                    if (optWaitSync.Checked || optWaitApproval.Checked)
                        e.Visible = true;
                    else
                        e.Visible = false;
                    break;
                default:
                    break;
            }
        }

        protected void gvHR_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name == "Approval")
            {
                object value = e.GetFieldValue("FinalStatus");
                if (value.ToString().Equals("a"))
                {
                    e.DisplayText = GetGlobalResourceObject("AF_HRNew", "w").ToString();
                }
                else if (value.ToString().Equals("s"))
                {
                    e.DisplayText = GetGlobalResourceObject("AF_HRNew", "sync").ToString();
                }
                else if (value.ToString().Equals("u"))
                {
                    e.DisplayText = GetGlobalResourceObject("AF_HRNew", "unsync").ToString();
                }
                else
                {
                    e.DisplayText = "";
                }
            }
        }

        protected void gvHR_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            //Hủy chế độ cập nhật tự động với SQLDatasource
            e.Cancel = true;

            //Khai báo đối tượng
            tblRecruitData webdata = new tblRecruitData(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
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
                string message = "alert('Vui lòng chọn lượt đăng ký cần đồng bộ vào hệ thống HRM')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                return;
            }

            try
            {
                tblRecruitData webdata = new tblRecruitData(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);

                foreach (object item in selectedRows)
                {
                    object[] arr = item as object[];
                    object id = item;
                    //object empid = arr[1];
                    //object startdate = arr[2];
                    //object frmtime = (arr[3] == null ? DBNull.Value : arr[3]);
                    //object totime = (arr[4] == null ? DBNull.Value : arr[4]);
                    //object totalhours = arr[5];

                    webdata.HRSync(id);
                }
                gvHR.Selection.UnselectAll();
                gvHR.DataBind();

                string message = "alert('Đồng bộ thành công')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
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
            selectedRows = grid.GetSelectedFieldValues(new string[] { "RequestID" });
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ASPxGridViewExporter1.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
            }
            catch (Exception ex)
            { }
        }

        protected void gvHR_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;
            object id = e.Keys[0];
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
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
            try
            {
                btnSync.Enabled = optWaitSync.Checked;
                if (optWaitApproval.Checked)
                    Session["FinalStatus"] = "1";
                else if (optWaitSync.Checked)
                    Session["FinalStatus"] = "2";
                else if (optChecked.Checked)
                    Session["FinalStatus"] = "3";
                gvHR.DataBind();
            }
            catch (Exception ex)
            { }
        }


        protected void btnView_Click(object sender, EventArgs e)
        {
            ASPxButton bt = sender as ASPxButton;
            GridViewDataItemTemplateContainer container = bt.NamingContainer as GridViewDataItemTemplateContainer;
            ASPxGridView grid = container.Grid;
            object otid = grid.GetRowValues(container.VisibleIndex, new string[] { "ID" });

            //Xử lý giá trị biến
            otid = (otid == null ? DBNull.Value : otid);

            //Gán dữ liệu vào Popup control
            ASPxPopupControl2.ShowOnPageLoad = true;
            ASPxGridView2.DataSource = OT_DataDetailService.GetTableByid((int)otid);
            ASPxGridView2.DataBind();

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

        protected void btnDetail_Click(object sender, EventArgs e)
        {
            try
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
                        Response.Redirect("~/Recruitment/HRReview_2.aspx");
                    else
                        Response.Redirect("~/Recruitment/HRReview.aspx");
                }
            }
            catch (Exception ex)
            {

            }
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

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ASPxButton bt = sender as ASPxButton;
                GridViewDataItemTemplateContainer container = bt.NamingContainer as GridViewDataItemTemplateContainer;
                ASPxGridView grid = container.Grid;
                object objID = grid.GetRowValues(container.VisibleIndex, new string[] { "RequestID" });
                object empID_Apply = grid.GetRowValues(container.VisibleIndex, new string[] { "EmpID_Apply" });

                ViewRequisition wf = new ViewRequisition();
                Session["RequestID"] = objID;
                Response.Redirect("~/Recruitment/ViewRequisition.aspx");
            }
            catch (Exception ex)
            {

            }
        }

        protected void cbbShowType_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvHR.DataBind();
            string f_expression = GetFilterExpression();

            gvHR.FilterExpression = f_expression;
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