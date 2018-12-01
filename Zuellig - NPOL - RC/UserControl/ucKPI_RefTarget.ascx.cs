using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPOL.App_Code.Entities;
using NPOL.App_Code.Business;

namespace NPOL.UserControl
{
    public partial class ucKPI_RefTarget : System.Web.UI.UserControl
    {
        bool IsValid = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            Show_New_Edit();
        }

        private void Show_New_Edit()
        {
            if (String.IsNullOrEmpty(HiddenField1.Value))
            {
                btnNew.Visible = true;
                btnSave.Visible = false;
            }
            else
            {
                btnNew.Visible = false;
                btnSave.Visible = true;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                //Validate
                if (IsValid == false)
                {
                    return;
                }
                else
                {
                    tbl_KPI_RefTarget obj = new tbl_KPI_RefTarget();
                    obj.Description = memoDescription.Text;
                    obj.Description_eng = memoDescription_eng.Text;

                    // Save data
                    RefTargetService service = new RefTargetService();
                    bool result = false;
                    result = service.CreateNew(obj);

                    if (result)
                    {
                        clearContent();
                        Show_New_Edit();
                        gvDinhCap.DataBind();
                    }
                }
            }
            catch( Exception ex)
            {
                string message = "alert('Thêm mới bị lỗi: " + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
        }

        private void clearContent()
        {
            memoDescription.Text = "";
            memoDescription_eng.Text = "";
            btnSave.Enabled = true;
            memoDescription.Focus();
            HiddenField1.Value = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Validate
                if (IsValid == false)
                {
                    return;
                }
                else
                {
                    tbl_KPI_RefTarget obj = new tbl_KPI_RefTarget();
                    obj.Description = memoDescription.Text;
                    obj.Description_eng = memoDescription_eng.Text;

                    // Save data
                    RefTargetService service = new RefTargetService();
                    bool result = false;
                    obj.ID = int.Parse(HiddenField1.Value);
                    result = service.UpdateByID(obj);

                    if (result)
                    {
                        clearContent();
                        Show_New_Edit();
                        gvDinhCap.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = "alert('Cập nhậtdữ liệu bị lỗi: " + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(memoDescription.Text) || string.IsNullOrEmpty(memoDescription_eng.Text))
            {
                IsValid = false;
            }
            else
                IsValid = true;
        }

        protected void gvDinhCap_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            try
            {
                RefTargetService obj = new RefTargetService();
                switch (e.ButtonID)
                {
                    // Edit item
                    case "Edit":
                        HiddenField1.Value = gvDinhCap.GetRowValues(e.VisibleIndex, "ID").ToString();
                        memoDescription.Text = gvDinhCap.GetRowValues(e.VisibleIndex, "Description").ToString();
                        memoDescription_eng.Text = gvDinhCap.GetRowValues(e.VisibleIndex, "Description_eng").ToString();
                        //btnSave.Enabled = true;
                        Show_New_Edit();
                        memoDescription.Focus();
                        break;
                    // Delete item
                    case "Delete":
                        obj.DeleteByID(Convert.ToInt32(gvDinhCap.GetRowValues(e.VisibleIndex, "ID")));
                        gvDinhCap.DataBind();
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Load_RefTarget(int ID)
        {
            try
            {
                RefTargetService service = new RefTargetService();
                tbl_KPI_RefTarget item = service.GetObjectById(ID);
                if(item != null)
                {
                    memoDescription.Text = item.Description;
                    memoDescription_eng.Text = item.Description_eng;
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void btRefresh_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(HiddenField1.Value))
            {
                clearContent();
            }
            else
            {
                // reload content
                Load_RefTarget(Int32.Parse(HiddenField1.Value));
            }
        }
    }
}