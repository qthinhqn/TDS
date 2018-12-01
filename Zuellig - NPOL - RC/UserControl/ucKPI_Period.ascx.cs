using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPOL.App_Code.Entities;
using NPOL.App_Code.Business;
using DevExpress.Web;

namespace NPOL.UserControl
{
    public partial class ucKPI_Period : System.Web.UI.UserControl
    {
        bool IsValid = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            Show_New_Edit();
            gluType.GridView.Width = gluType.Width;
        }

        private void Show_New_Edit()
        {
            if (String.IsNullOrEmpty(HiddenField1.Value))
            {
                btnNew.Visible = true;
                btnSave.Visible = false;
                btCompetency.Visible = false;
                btPercent.Visible = false;
            }
            else
            {
                btnNew.Visible = false;
                btnSave.Visible = true;
                btCompetency.Visible = true;
                btPercent.Visible = true;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    // check exist current process performance assessment
                    if (KPI_PeriodService.GetKPI_LastActive() > 0)
                    {
                        string message = "alert('" + GetGlobalResourceObject("KPI_Period", "alertNotAllowInsert").ToString() + "')";
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                        
                        clearContent();
                        Show_New_Edit(); 
                        return;
                    }
                    tbl_KPI_Period obj = new tbl_KPI_Period();
                    obj.Name = memoDescription.Text;
                    obj.StartTime = deStart.Date;
                    obj.EndTime = deEnd.Date;
                    obj.ReviewTime = deReview.Date;
                    obj.ApprovalTime = deApproval.Date;
                    obj.ReviewTime_First = deReview_First.Date;
                    obj.TypeID = int.Parse(gluType.Value.ToString());

                    // Save data
                    KPI_PeriodService service = new KPI_PeriodService();
                    bool result = false;
                    result = service.CreateNew(obj);

                    if (result)
                    {
                        clearContent();
                        Show_New_Edit();
                        gvDinhCap.DataBind();

                        string message = "alert('" + GetGlobalResourceObject("KPI_Period", "alertSuccess").ToString() + "')";
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = "alert('" + GetGlobalResourceObject("KPI_Period", "alertFail").ToString() + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
        }

        private void clearContent()
        {
            memoDescription.Text = "";
            deStart.Text = "";
            deReview.Text = "";
            deReview_First.Text = "";
            deApproval.Text = "";
            deEnd.Text = "";
            gluType.Text = "";
            //
            btnSave.Enabled = true;
            memoDescription.Focus();
            HiddenField1.Value = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Validate
                //if (IsValid == false)
                //{
                //    return;
                //}
                //else
                {
                    tbl_KPI_Period obj = new tbl_KPI_Period();
                    obj.Name = memoDescription.Text;
                    obj.StartTime = deStart.Date;
                    obj.EndTime = deEnd.Date;
                    obj.ReviewTime = deReview.Date;
                    obj.ApprovalTime = deApproval.Date;
                    obj.ReviewTime_First = deReview_First.Date;
                    obj.TypeID = int.Parse(gluType.Value.ToString());

                    // Save data
                    KPI_PeriodService service = new KPI_PeriodService();
                    bool result = false;
                    obj.ID = int.Parse(HiddenField1.Value);
                    result = service.UpdateByID(obj);

                    if (result)
                    {
                        clearContent();
                        Show_New_Edit();
                        gvDinhCap.DataBind();

                        string message = "alert('" + GetGlobalResourceObject("KPI_Period", "alertSuccess").ToString() + "')";
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = "alert('" + GetGlobalResourceObject("KPI_Period", "alertFail").ToString() + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(memoDescription.Text) )
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
                KPI_PeriodService obj = new KPI_PeriodService();
                switch (e.ButtonID)
                {
                    // Edit item
                    case "Edit":
                        HiddenField1.Value = gvDinhCap.GetRowValues(e.VisibleIndex, "ID").ToString();
                        Load_RefTarget();
                        //btnSave.Enabled = true;
                        Show_New_Edit();
                        memoDescription.Focus();
                        break;
                    // Delete item
                    case "Delete":
                        // Check allow delete
                        int periodID = int.Parse(gvDinhCap.GetRowValues(e.VisibleIndex, "ID").ToString());
                        if (new KPI_PeriodService().AllowDelete(periodID))
                            obj.DeleteByID(Convert.ToInt32(gvDinhCap.GetRowValues(e.VisibleIndex, "ID")));
                        else
                        {
                            string message = "alert('Không thể XÓA vì đã có dữ liệu liên quan!')";
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                        }
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

        private void Load_RefTarget()
        {
            try
            {
                KPI_PeriodService service = new KPI_PeriodService();
                int ID = Int32.Parse(HiddenField1.Value);
                Session["PeriodID"] = ID;
                tbl_KPI_Period item = service.GetObjectById(ID);
                if(item != null)
                {
                    memoDescription.Text = item.Name;
                    deStart.Date = item.StartTime;
                    deEnd.Date = item.EndTime;
                    deReview.Date = item.ReviewTime;
                    deApproval.Date = item.ApprovalTime;
                    deReview_First.Date = item.ReviewTime_First;
                    gluType.Value = item.TypeID;
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
                Load_RefTarget();
            }
        }

        protected void grid_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e)
        {
            // tuy chinh hien thi 
            object active = e.GetFieldValue("Active");

            if (e.Column.FieldName.Equals("Active"))
            {
                if ((bool)active)
                    e.DisplayText = GetGlobalResourceObject("KPI_Period", "activeYes").ToString();
                else
                    e.DisplayText = GetGlobalResourceObject("KPI_Period", "activeNo").ToString();
            }
        }

        protected void btCompetency_Click(object sender, EventArgs e)
        {
            // 
            //ASPxWebControl.RedirectOnCallback("~/K_ChooseCompetency.aspx");
            if (Session["Role"].ToString().Equals("PA_Admin"))
                Response.Redirect("~/Ad_ChooseCompetency.aspx");
            else
                Response.Redirect("~/K_ChooseCompetency.aspx");
        }

        protected void btPercent_Click(object sender, EventArgs e)
        {
            if (Session["Role"].ToString().Equals("PA_Admin"))
                Response.Redirect("~/K_ConfigRating.aspx");
            else
                Response.Redirect("~/K_ConfigRating.aspx");
        }
    }
}