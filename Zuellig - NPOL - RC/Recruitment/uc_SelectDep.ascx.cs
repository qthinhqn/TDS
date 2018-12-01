
using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using NPOL.App_Code.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using conn = System.Web.Configuration;

namespace NPOL.UserControl
{
    public partial class uc_SelectDep : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Role"] != "RC_Admin")
                {
                    object refUrl = ViewState["RefUrl"];
                    if (refUrl != null)
                        Response.Redirect((string)refUrl);
                }

                if (!IsPostBack)
                {
                    
                }
            }
            catch (Exception ex)
            {
            
            }
        }


        static List<object> selectedKPI = new List<object>();
        static List<object> selectedEmployeeID = new List<object>();
        protected void gvEmployee_SelectionChanged(object sender, EventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            selectedEmployeeID.Clear();
            selectedEmployeeID = grid.GetSelectedFieldValues(new string[] { "EmployeeID" });
        }

        protected void gvTrainLine_RowDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {

        }

        protected void gvTrainLine_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {
        }

        protected void gridKPIList_SelectionChanged(object sender, EventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            selectedKPI.Clear();
            selectedKPI = grid.GetSelectedFieldValues(new string[] { "ID" });
            Session["KPI_ID"] = selectedKPI[0];
        }
        protected void gridKPIList_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["KPI_ID"] = (sender as DevExpress.Web.ASPxGridView).GetMasterRowKeyValue();
        }

        protected void gridKPIList_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {
        }

        protected void gridKPIList_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            ASPxButton bt = sender as ASPxButton;
            GridViewDataItemTemplateContainer container = bt.NamingContainer as GridViewDataItemTemplateContainer;
            ASPxGridView grid = container.Grid;
            object _pid = grid.GetRowValues(container.VisibleIndex, new string[] { "ID" });
            object _empID = grid.GetRowValues(container.VisibleIndex, new string[] { "ManagerID" });
            hdfManagerID.Value = _pid.ToString();

            //Xử lý giá trị biến
            _pid = (_pid == null ? DBNull.Value : _pid);

            //Gán dữ liệu vào Popup control
            ASPxPopupControl1.ShowOnPageLoad = true;
            string ketnoi = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString;
            tblRecruitData obj = new tblRecruitData(ketnoi);
            //gridManagerHR_Direct.DataSource = obj.GetTablePayGroupReviewByid(_pid.ToString());
            Khuong kh = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            ASPxPopupControl1.HeaderText = "Nhóm quản lý theo nhân sự tuyển dụng: " + kh.getEmployeeName(_empID.ToString());
            Session["PayGroupReview_ID"] = _pid;
            {
                cmbGroup.SelectedIndex = 0;
                treeList.ExpandToLevel(0);
                cmbGroup_SelectedIndexChanged(cmbGroup, null);
            }
        }

        protected void btnView_Init(object sender, EventArgs e)
        {
            try
            {
                ASPxButton button = sender as ASPxButton;
                GridViewDataItemTemplateContainer container = button.NamingContainer as GridViewDataItemTemplateContainer;
                string regType = DataBinder.Eval(container.DataItem, "Type").ToString();
                if (regType != null)
                {
                    if (regType == "A" || regType == "E" || regType == "G" || regType == "H" || regType == "I")
                        button.Visible = true;
                    else
                        button.Visible = false;
                }
                else
                {
                    button.Visible = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        #region cascading combobox


        protected void FillGroupCombo(ASPxComboBox cmb, string groupCode)
        {
            if (string.IsNullOrEmpty(groupCode)) return;

            DataTable divisions = GetDivisions(groupCode);
            cmb.DataSource = divisions;
            cmb.DataBind();
        }
        private DataTable GetDivisions(string groupCode)
        {
            ManagerHR_DirectService service = new ManagerHR_DirectService();
            return service.GetTableByid(groupCode, hdfManagerID.Value);
        }

        void cmbDivision_OnCallback(object source, CallbackEventArgsBase e)
        {
            FillGroupCombo(source as ASPxComboBox, e.Parameter);
        }
        #endregion

        protected void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["GroupID"] = cmbGroup.SelectedItem.Value;
            treeList.DataBind();
            SetNodeSelectionSettings();
        }

        protected void treeList_CustomDataCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomDataCallbackEventArgs e)
        {
            e.Result = treeList.SelectionCount.ToString();
        }

        protected void treeList_DataBound(object sender, EventArgs e)
        {
            //SetNodeSelectionSettings();
        }

        void SetNodeSelectionSettings()
        {
            try
            {
                TreeListNodeIterator iterator = treeList.CreateNodeIterator();
                TreeListNode node;
                while (true)
                {
                    node = iterator.GetNext();
                    if (node == null) break;
                    node.Selected = (bool)node["Checked"];
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            var pr_service = new prServices(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            // Save new Group
            string newGroup = txtGroup.Text.Trim();
            int newGroupid = 0;
            if (newGroup == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Mời nhập tên nhóm!')", true);
            }
            else
            {
                if (pr_service.CheckExists_GroupDep(newGroup))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Nhóm đã tồn tại. mời nhập lại!')", true);
                }
                else
                {
                    newGroupid = pr_service.Save_GroupDep(newGroup);
                }
            }
            if (newGroupid  == 0)
                return;

            // Save department selected by Group
            TreeListNodeIterator iterator = treeList.CreateNodeIterator();
            TreeListNode node;
            while (true)
            {
                node = iterator.GetNext();
                if (node == null) break;
                var depid = node.Key;
                var groupid = newGroupid;
                var managerid = 0;
                var status = node.Selected;
                pr_service.Save_SelectedDep(depid, managerid, groupid, status);
            }

            txtGroup.Text = "";
            cmbGroup.DataBind();
        }

        protected void ASPxButton2_Click(object sender, EventArgs e)
        {
            cmbGroup.SelectedIndex = 0;
            cmbGroup_SelectedIndexChanged(cmbGroup, null);
            //treeList.DataBind();
            //SetNodeSelectionSettings();
        }

        protected void ASPxButton3_Click(object sender, EventArgs e)
        {
            var pr_service = new prServices(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            // Save department selected by Manager
            TreeListNodeIterator iterator = treeList.CreateNodeIterator();
            TreeListNode node;
            while (true)
            {
                node = iterator.GetNext();
                if (node == null) break;
                var depid = node.Key;
                var groupid = 0;
                var managerid = Session["PayGroupReview_ID"];
                var status = node.Selected;
                pr_service.Save_SelectedDep(depid, managerid, groupid, status);
            }
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Cập nhật thành công!')", true);
        }
    }
}