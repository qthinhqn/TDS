using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

namespace NPOL
{
    public partial class AF_ApprovalNew : System.Web.UI.Page
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
                //Tru?ng h?p là nhân viên m?i ho?c nhân viên cu
                if (Session["Role"].ToString().Substring(0, 1).Equals("E"))
                {
                    Response.Redirect("Login.aspx");
                }

                //Tru?ng h?p là HR
                if (Session["Role"].ToString().Equals("HR"))
                {
                    Response.Redirect("Login.aspx");
                }
            }

            if (!IsPostBack)
            {
                //Hiển thị thông tin đăng nhập
                lbWelcome.Text = GetGlobalResourceObject("F_Registration1", "lbWelcome").ToString();
                lbUserName.Text = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString).getEmployeeName(Session["EmployeeID"].ToString());
            }
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

        protected void gvApproval_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            //Hủy chức năng cập nhật tự động của SqlDatasource
            e.Cancel = true;

            //Khai báo đối tượng và biến
            ASPxGridView grid = sender as ASPxGridView;
            ASPxComboBox cbb = grid.FindEditFormTemplateControl("cbbApproval") as ASPxComboBox;
            ASPxMemo lydo = grid.FindEditFormTemplateControl("txtReason") as ASPxMemo;
            string ketnoi = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString;
            tblWebData thucthi = new tblWebData(ketnoi);

            object id = e.Keys[0];
            object ManagerID = Session["EmployeeID"];
            if (ManagerID != null)
            {
                try
                {
                    object curLevel = thucthi.getCurrentLevel(id, ManagerID);
                    if (thucthi.AllowUpdate(id, curLevel))
                    {
                        if (cbb.Value.ToString().Equals("1")) //Trường hợp được duyệt
                        {
                            if (thucthi.isLastLevel(id, curLevel) || thucthi.isFirstLastLevel(id, curLevel))
                            {
                                thucthi.ApproveLast(id, curLevel, lydo.Text);
                            }
                            else
                            {
                                thucthi.ApproveFirst(id, curLevel, lydo.Text);
                            }
                        }
                        else //Trường hợp không phê duyệt
                        {
                            thucthi.CancelApproval(id, curLevel, lydo.Text);
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

        protected void gvApproval_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            string ketnoi = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString;
            object id = e.GetFieldValue("ID");
            object empid = Session["EmployeeID"];
            object fstatus = e.GetFieldValue("FinalStatus");

            if (empid != null)
            {
                tblWebData thucthi = new tblWebData(ketnoi);
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

        protected void gvApproval_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            object id = e.KeyValue;
            ASPxGridView grid = sender as ASPxGridView;
            object fstatus = grid.GetRowValuesByKeyValue(id, "FinalStatus");

            string ketnoi = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString;
            tblWebData thucthi = new tblWebData(ketnoi);
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
                            e.Cell.BackColor = System.Drawing.Color.Red;
                            e.Cell.ForeColor = System.Drawing.Color.White;
                        }
                    }

                    if (fstatus.ToString().Equals("c"))
                    {
                        e.Cell.BackColor = System.Drawing.Color.Red;
                        e.Cell.ForeColor = System.Drawing.Color.White;
                    }
                }
            }

        }

        protected void gvApproval_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            object finalstatus = e.GetValue("FinalStatus");

            if (finalstatus != null)
            {
                if (string.Compare(finalstatus.ToString(), "a", true) == 0)
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }
                else if (string.Compare(finalstatus.ToString(), "c", true) == 0)
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }
            }
        }

        protected void gvApproval_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            string ketnoi = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString;
            ASPxGridView grid = sender as ASPxGridView;
            tblWebData thucthi = new tblWebData(ketnoi);
            int index = e.VisibleIndex;
            if (index < 0)
                index = index + 1;

            object id = grid.GetRowValues(index, "ID");
            object managerid = Session["EmployeeID"];
            object curLevel = thucthi.getCurrentLevel(id, managerid);

            try
            {
                if (id != null && managerid != null)
                {
                    if (e.ButtonType == ColumnCommandButtonType.Edit)
                        e.Visible = false; //e.Enabled = false;

                    //Hiện nút edit khi quản lý tới lượt phê duyệt
                    object fstatus = grid.GetRowValues(index, "FinalStatus");
                    if (string.Compare("w", fstatus.ToString(), true) == 0)
                    {
                        object curstatus = grid.GetRowValues(index, "ApprovingStatus_L" + curLevel.ToString());
                        object curmail = grid.GetRowValues(index, "MailToL" + curLevel.ToString());
                        if (curstatus.ToString().Equals(""))
                        {
                            if (!curmail.ToString().Equals("") && (curmail.ToString().Equals("1") || curmail.ToString().Equals("2")))
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

        protected void gvDetail_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["id"] = (sender as DevExpress.Web.ASPxGridView).GetMasterRowKeyValue();
        }

        protected void gvDetail_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            string ketnoi = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString;
            object checknum = new tblWebData(ketnoi).getCheckNum(e.GetFieldValue("ID"));
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
            string ketnoi = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString;
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
                    e.Cell.BackColor = System.Drawing.Color.Red;
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
    }
}