using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPOL.App_Code.Entities;
using NPOL.App_Code.Business;
using DevExpress.Web;
using System.Data;
using System.Collections;
using System.Reflection;

namespace NPOL.UserControl
{
    public partial class ucNPOL_ChangeManager : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["PeriodID"] = 1;
            //Session["EmployeeID"] = "HR021";
            if(!IsPostBack)
            {
            }
            if (cbManager_A.Value != null)
            {
                string managerID = cbManager_A.Value.ToString();
            }
            gridChangeManager.DataBind();
        }
        
        protected void grid_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            try
            {
                ASPxGridView gridview = sender as ASPxGridView;
                switch (e.ButtonID)
                {
                    // Change manager item
                    case "Change_Manager":
                        int ID = int.Parse(gridview.GetRowValues(e.VisibleIndex, "ID").ToString());
                        ChangeManagerService service = new ChangeManagerService();
                        bool result = service.ChangeManager(ID);
                        if (result)
                        {
                            string message = "alert('Chuyển đổi thành công')";
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                        }
                        else
                        {
                            string message = "alert('Chuyển đổi bị lỗi')";
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                        }
                        gridview.DataBind();
                        break;

                    // Edit item
                    case "Edit":
                        HiddenField1.Value = gridview.GetRowValues(e.VisibleIndex, "ManagerID_A").ToString();
                        HiddenField2.Value = gridview.GetRowValues(e.VisibleIndex, "ID").ToString();
                        
                        Load_Detail();
                        memoDescription.Focus();
                        break;

                    case "Delete":
                        int ID2 = int.Parse(gridview.GetRowValues(e.VisibleIndex, "ID").ToString());
                        ChangeManagerService service2 = new ChangeManagerService();
                        service2.DeleteByID(ID2);
                        gridview.DataBind();
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Load_Detail()
        {
            try
            {
                ChangeManagerService detailservice = new ChangeManagerService();
                tblChangeManager itemDetail = detailservice.GetObjectById(int.Parse(HiddenField2.Value.ToString()));
                if (itemDetail != null)
                {
                    cbManager_A.Value = itemDetail.Manager_A;
                    cbManager_B.Value = itemDetail.Manager_B;
                    memoDescription.Text = itemDetail.Notes;
                    dateFrom.Value = itemDetail.FromDate;
                    dateTo.Value = itemDetail.ToDate;
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void btCancel_Click(object sender, EventArgs e)
        {
            clearContent();
        }

        protected void grid_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e)
        {
            // tuy chinh hien thi 
            //object Description = e.GetFieldValue("Description");
            //object Description_eng = e.GetFieldValue("Description_eng");
            //if (e.Column.FieldName.Equals("Description"))
            //{
            //    if (level.ToString() != "1")
            //    {
            //        e.DisplayText = Description_eng + " / " + Description;
            //    }
            //}
        }

        protected void grid_DetailRowGetButtonVisibility(object sender, ASPxGridViewDetailRowButtonEventArgs e)
        {
        }

        protected void grid_SubDetailRowGetButtonVisibility(object sender, ASPxGridViewDetailRowButtonEventArgs e)
        {
            
        }

        protected void ASPxGridView_DataBound(object sender, System.EventArgs e)
        {
            //((ASPxGridView)sender).DetailRows.ExpandAllRows();
            //((ASPxGridView)sender).SettingsDetail.ShowDetailButtons = false;
        }
        
        private void clearContent()
        {
            cbManager_A.Value = null;
            cbManager_B.Value = null;
            memoDescription.Text = "";
            dateFrom.Value = null;
            dateTo.Value = null;
            btnSave.Enabled = true;
            cbManager_A.Focus();
            HiddenField1.Value = "";
            HiddenField2.Value = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (IsPostBack && ASPxEdit.ValidateEditorsInContainer(this))
            try
            {
                tblChangeManager detail = new tblChangeManager();

                detail.Manager_A = cbManager_A.Value.ToString();
                detail.Manager_B = cbManager_B.Value.ToString();
                if (dateFrom.Value != null)
                    detail.FromDate = dateFrom.Date;
                else
                    detail.FromDate = null;
                if (dateTo.Value != null)
                    detail.ToDate = dateTo.Date;
                else
                    detail.ToDate = null;
                detail.Notes = memoDescription.Text;

                // Save data
                bool result = false;
                ChangeManagerService detailService = new ChangeManagerService();
                if (string.IsNullOrEmpty(HiddenField2.Value))
                {
                    //Insert new data
                    result = detailService.CreateNew(detail);
                }
                else
                {
                    // Update data
                    detail.ID = int.Parse(HiddenField2.Value);
                    result = detailService.UpdateByID(detail);
                }

                if (result)
                {
                    string message = "alert('Cập nhật thành công')";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                }
                else
                {
                    string message = "alert('Cập nhật bị lỗi')";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                }
                clearContent();
                gridChangeManager.DataBind();
            }
            catch (Exception ex)
            {
                string message = "alert('Cập nhật dữ liệu bị lỗi: " + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
        }

        protected void gridChangeManager_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            int index = e.VisibleIndex;
            if (index < 0)
                return;

            object status = grid.GetRowValues(index, "Status");
            object fromdate = grid.GetRowValues(index, "FromDate");
            //int id = int.Parse(grid.GetRowValues(index, "ID").ToString());
            //ChangeManagerService service = new ChangeManagerService();
            //tblChangeManager item = service.GetObjectById(id);

            try
            {
                if (status == null || status.ToString()=="")
                {
                    if (e.ButtonID == "Change_Manager")
                        if (fromdate == null || fromdate.ToString() == "")
                            e.Visible = DevExpress.Utils.DefaultBoolean.True;
                        else
                            e.Visible = DevExpress.Utils.DefaultBoolean.False;
                    if (e.ButtonID == "Edit")
                        e.Visible = DevExpress.Utils.DefaultBoolean.True;
                    if (e.ButtonID == "Delete")
                        e.Visible = DevExpress.Utils.DefaultBoolean.True;
                }
                else if ((bool)status == false)
                {
                    if (e.ButtonID == "Change_Manager")
                        if (fromdate == null || fromdate.ToString() == "")
                            e.Visible = DevExpress.Utils.DefaultBoolean.True;
                        else
                            e.Visible = DevExpress.Utils.DefaultBoolean.False;
                    if (e.ButtonID == "Edit")
                        e.Visible = DevExpress.Utils.DefaultBoolean.False;
                    if (e.ButtonID == "Delete")
                        e.Visible = DevExpress.Utils.DefaultBoolean.False;
                }
                else
                {
                    if (e.ButtonID == "Change_Manager")
                        e.Visible = DevExpress.Utils.DefaultBoolean.False;
                    if (e.ButtonID == "Edit")
                        e.Visible = DevExpress.Utils.DefaultBoolean.False;
                    if (e.ButtonID == "Delete")
                        e.Visible = DevExpress.Utils.DefaultBoolean.False;
                }
            }
            catch (Exception ex)
            {
                string message = "alert('" + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.UpdatePanel1.Unload += new EventHandler(UpdatePanel_Unload);
        }

        void UpdatePanel_Unload(object sender, EventArgs e)
        {
            this.RegisterUpdatePanel(sender as UpdatePanel);
        }

        public void RegisterUpdatePanel(UpdatePanel panel)
        {
            foreach (MethodInfo methodInfo in typeof(ScriptManager).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (methodInfo.Name.Equals("System.Web.UI.IScriptManagerInternal.RegisterUpdatePanel"))
                {
                    methodInfo.Invoke(ScriptManager.GetCurrent(Page), new object[] { UpdatePanel1 });
                }
            }
        }
    }
}