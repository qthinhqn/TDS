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
    public partial class ucKPI_Competency : System.Web.UI.UserControl
    {
        bool IsValid = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxGridLookup2.GridView.Width = ASPxGridLookup2.Width;
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
                    tbl_Store_Competency obj = new tbl_Store_Competency();
                    //type
                    switch (ASPxRadioButtonList1.SelectedIndex)
                    {
                        case 1:
                            obj.Type = false;
                            break;
                        case 2:
                            obj.Type = null;
                            break;
                        default:
                            obj.Type = true;
                            break;
                    }
                    obj.Description = memoDescription.Text;
                    obj.Description_eng = memoDescription_eng.Text;
                    //if (cbTarget.Value != null)
                        //obj.Target = int.Parse(cbTarget.Value.ToString());
                    if (ASPxGridLookup2.Value != null)
                        obj.Parent = int.Parse(ASPxGridLookup2.Value.ToString());
                    // Save data
                    Store_CompetencyService service = new Store_CompetencyService();
                    bool result = false;
                    result = service.CreateNew(obj);

                    if (result)
                    {
                        clearContent();
                        Show_New_Edit();
                        gvStoreCompetency.DataBind();
                        ASPxGridLookup2.DataBind();
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
                    tbl_Store_Competency obj = new tbl_Store_Competency();
                    switch (ASPxRadioButtonList1.SelectedIndex)
                    {
                        case 1:
                            obj.Type = false;
                            break;
                        case 2:
                            obj.Type = null;
                            break;
                        default:
                            obj.Type = true;
                            break;
                    }
                    obj.Description = memoDescription.Text;
                    obj.Description_eng = memoDescription_eng.Text;
                    //if (cbTarget.Value != null)
                    //    obj.Target = int.Parse(cbTarget.Value.ToString());
                    if (ASPxGridLookup2.Value != null)
                        obj.Parent = int.Parse(ASPxGridLookup2.Value.ToString());

                    // Save data
                    Store_CompetencyService service = new Store_CompetencyService();
                    bool result = false;
                    obj.ID = int.Parse(HiddenField1.Value);
                    result = service.UpdateByID(obj);

                    if (result)
                    {
                        clearContent();
                        Show_New_Edit();
                        gvStoreCompetency.DataBind();
                        ASPxGridLookup2.DataBind();
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
                Store_CompetencyService obj = new Store_CompetencyService();
                switch (e.ButtonID)
                {
                    // Edit item
                    case "Edit":
                        HiddenField1.Value = gvStoreCompetency.GetRowValues(e.VisibleIndex, "ID").ToString();
                        Load_RefTarget(int.Parse(HiddenField1.Value.ToString()));
                        //btnSave.Enabled = true;
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
                Store_CompetencyService service = new Store_CompetencyService();
                tbl_Store_Competency item = service.GetObjectById(ID);
                if(item != null)
                {
                    if (item.Type == null)
                        ASPxRadioButtonList1.Items[2].Selected = true;
                    else if (item.Type == false)
                        ASPxRadioButtonList1.Items[1].Selected = true;
                    else
                        ASPxRadioButtonList1.Items[0].Selected = true;
                    memoDescription.Text = item.Description;
                    memoDescription_eng.Text = item.Description_eng;
                    //cbTarget.Value = item.Target;
                    ASPxGridLookup2.Value = item.Parent;
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
            object type = e.GetFieldValue("Type");
            object target = e.GetFieldValue("Target_ID");

            if (e.Column.FieldName.Equals("Type"))
                {
                    e.DisplayText = getTypeName(type);
                }
            if (target != null && e.Column.FieldName.Equals("Target_ID"))
                {
                    e.DisplayText = getTargetName(target);
                }
        }

        private string getTargetName(object target)
        {
            try
            {
                if (string.IsNullOrEmpty(target.ToString()))
                {
                    return "";
                }
                RefTargetService obj = new RefTargetService();
                tbl_KPI_RefTarget item = obj.GetObjectById((int)target);
                return item.Description;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private string getTypeName(object type)
        {
            if (string.IsNullOrEmpty(type.ToString()))
            {
                return ASPxRadioButtonList1.Items[2].Text;//"KHÔNG BẮT BUỘC (OPTIONAL)";
            }
            else if ((bool)type)
            {
                return ASPxRadioButtonList1.Items[0].Text;//"TẤT CẢ (ALL Employee)";
            }
            else
                return ASPxRadioButtonList1.Items[1].Text;//"CẤP BẬC GIÁM SÁT TRỞ LÊN (FOR SUPERVISOR LEVEL AND ABOVE)";
        }
    }
}