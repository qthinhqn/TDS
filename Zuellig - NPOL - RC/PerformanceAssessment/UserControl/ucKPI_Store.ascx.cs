using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PAOL.App_Code.Entities;
using PAOL.App_Code.Business;

namespace PAOL.UserControl
{
    public partial class ucKPI_Store : System.Web.UI.UserControl
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
                    tbl_Store_KPI obj = new tbl_Store_KPI();
                    //type
                    obj.Type = true;
                    obj.Description = memoDescription.Text;
                    obj.Description_eng = memoDescription_eng.Text;
                    obj.Target = ASPxMemo1.Text;
                    obj.DoneBy = ASPxMemo2.Text;
                    // Save data
                    Store_KPIService service = new Store_KPIService();
                    bool result = false;
                    result = service.CreateNew(obj);

                    if (result)
                    {
                        clearContent();
                        Show_New_Edit();
                        gvStoreCompetency.DataBind();
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
            ASPxMemo1.Text = "";
            ASPxMemo2.Text = "";
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
                    tbl_Store_KPI obj = new tbl_Store_KPI();
                    obj.Type = true;
                    obj.Description = memoDescription.Text;
                    obj.Description_eng = memoDescription_eng.Text;
                    obj.Target = ASPxMemo1.Text;
                    obj.DoneBy = ASPxMemo2.Text;

                    // Save data
                    Store_KPIService service = new Store_KPIService();
                    bool result = false;
                    obj.ID = int.Parse(HiddenField1.Value);
                    result = service.UpdateByID(obj);

                    if (result)
                    {
                        clearContent();
                        Show_New_Edit();
                        gvStoreCompetency.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = "alert('Cập nhật dữ liệu bị lỗi: " + ex.Message + "')";
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
                Store_KPIService obj = new Store_KPIService();
                switch (e.ButtonID)
                {
                    // Edit item
                    case "Edit":
                        HiddenField1.Value = gvStoreCompetency.GetRowValues(e.VisibleIndex, "ID").ToString();
                        Load_RefTarget(int.Parse(HiddenField1.Value.ToString()));
                        Show_New_Edit();
                        memoDescription.Focus();
                        break;
                    // Delete item
                    case "Delete":
                        obj.DeleteByID(Convert.ToInt32(gvStoreCompetency.GetRowValues(e.VisibleIndex, "ID")));
                        gvStoreCompetency.DataBind();
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
                Store_KPIService service = new Store_KPIService();
                tbl_Store_KPI item = service.GetObjectById(ID);
                if(item != null)
                {
                    memoDescription.Text = item.Description;
                    memoDescription_eng.Text = item.Description_eng;
                    ASPxMemo1.Text = item.Target;
                    ASPxMemo2.Text = item.DoneBy;
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

        protected void gvStoreCompetency_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e)
        {
            // tuy chinh hien thi 
            
        }
    }
}