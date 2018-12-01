using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PAOL.App_Code.Entities;
using PAOL.App_Code.Business;
using DevExpress.Web;
using System.Data;
using System.Collections;

namespace PAOL.UserControl
{
    public partial class ucKPI_RefKPI_ByPos : System.Web.UI.UserControl
    {
        bool IsValid = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxGridLookup1.GridView.Width = ASPxGridLookup1.Width;
            ASPxGridLookup2.GridView.Width = ASPxGridLookup2.Width;
            if (!IsPostBack)
            {
                grid.DataBind();
                grid.DetailRows.ExpandRow(0);

                DataTable dt = Store_KPIService.GetAllStore_KPI();
                ASPxGridLookup2.DataSource = dt;
                ASPxGridLookup2.DataBind();
            }
        }

        protected void detailGrid_DataSelect(object sender, EventArgs e)
        {
            Session["PosID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }
        protected void detailGrid_CustomUnboundColumnData(object sender, ASPxGridViewColumnDataEventArgs e)
        {
            //if (e.Column.FieldName == "Total")
            //{
            //    decimal price = (decimal)e.GetListSourceFieldValue("UnitPrice");
            //    int quantity = Convert.ToInt32(e.GetListSourceFieldValue("Quantity"));
            //    e.Value = price * quantity;
            //}
        }

        private void clearContent()
        {
            ASPxGridLookup1.Value = null;
            ASPxGridLookup2.Value = null;
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
                    tbl_KPI_RefPosition obj = new tbl_KPI_RefPosition();
                    obj.Position_ID = ASPxGridLookup1.Value.ToString();
                    var tags = ASPxGridLookup2.GridView.GetSelectedFieldValues(ASPxGridLookup2.KeyFieldName) as List<object>;
                    foreach (object item in tags)
                    {
                        // Save data
                        obj.KPI_ID = int.Parse(item.ToString());
                        KPI_RefPositionService service = new KPI_RefPositionService();
                        service.CreateNew(obj);
                    }
                    
                    clearContent();
                    grid.DataBind();

                    string message = "alert('Cập nhật dữ liệu thành công!')";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
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
            if (ASPxGridLookup1.Value == null ||
                ASPxGridLookup2.Value == null )
            {
                IsValid = false;
            }
            else
                IsValid = true;
        }

        protected void grid_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            try
            {
                switch (e.ButtonID)
                {
                    // Edit item
                    case "Edit":
                        HiddenField1.Value = grid.GetRowValues(e.VisibleIndex, "PosID").ToString();
                        ASPxGridLookup1.Value = HiddenField1.Value;
                        Load_RefKPI();
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Load_RefKPI()
        {
            try
            {
                if(!string.IsNullOrEmpty(HiddenField1.Value))
                {
                    string posid = HiddenField1.Value;
                    DataTable dtKpi = KPI_RefPositionService.GetKPI_RefPosition(posid);
                    if (dtKpi != null && dtKpi.Rows.Count > 0)
                    {
                        // mark check in grid.
                        string strMark = "";
                        foreach(DataRow r in dtKpi.Rows)
                        {
                            strMark += r["KPI_ID"].ToString() + ", ";
                        }
                        ASPxGridLookup2.Text = strMark.PadLeft(strMark.Length - 2);
                    }

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
                Load_RefKPI();
            }
        }

        protected void grid_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e)
        {
            // tuy chinh hien thi 
            
        }

        protected void ASPxGridLookup1_ValueChanged(object sender, EventArgs e)
        {
            // reload reference KPI
            ASPxGridLookup lookup = sender as ASPxGridLookup;
            if(lookup.Value == null)
            {
                HiddenField1.Value = "";
                btnSave.Enabled = false;
            }
            else
            {
                HiddenField1.Value = lookup.Value.ToString();
                btnSave.Enabled = true;
            }
            Load_RefKPI();
        }

        protected void grid_DetailRowGetButtonVisibility(object sender, ASPxGridViewDetailRowButtonEventArgs e)
        {
            if (e.VisibleIndex >= 0)
            {
                if (grid.GetDataRow(e.VisibleIndex)["Counter"] == null ||
                    grid.GetDataRow(e.VisibleIndex)["Counter"].ToString() == "")
                    e.ButtonState = GridViewDetailRowButtonState.Hidden;
            }
        }

        protected void DetailOds_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            //if (Context.User.Identity.IsAuthenticated)
            {
                e.InputParameters["RefID"].ToString();
            }
        }

    }
}