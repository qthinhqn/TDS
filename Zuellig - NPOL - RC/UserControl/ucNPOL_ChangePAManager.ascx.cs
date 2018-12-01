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
    public partial class ucNPOL_ChangePAManager : System.Web.UI.UserControl
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
        
        protected void Change_Manager(int ID)
        {
            try
            {
                ChangeManagerService service = new ChangeManagerService();
                bool result = service.ChangePAManager(ID);
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

                gridChangeManager.DataBind();
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
                detail.FromDate = null;
                detail.ToDate = null;
                detail.Notes = memoDescription.Text;

                // Save data
                bool result = false;
                int idNew = 0;
                ChangeManagerService detailService = new ChangeManagerService();
                idNew = detailService.CreateNew_PA(detail);

                if (idNew != 0)
                {
                    Change_Manager(idNew);
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