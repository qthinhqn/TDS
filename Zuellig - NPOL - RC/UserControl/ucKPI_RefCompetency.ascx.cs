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
using DevExpress.Utils;

namespace NPOL.UserControl
{
    public partial class ucKPI_RefCompetency : System.Web.UI.UserControl
    {
        bool IsValid = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["PeriodID"] = 1;
            ASPxGridLookup1.GridView.Width = ASPxGridLookup1.Width;
            if (!IsPostBack)
            {
                optShowActive.Checked = true;
            }
            // Session["ShowType"]
            Session["ShowType"] = (optShowAll.Checked ? 0 :
                (optShowActive.Checked ? 1 : 2));

            grid.DataBind();
            grid.DetailRows.ExpandRow(0);
        }

        protected void detailGrid_DataSelect(object sender, EventArgs e)
        {
            Session["ParentID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }

        protected void subDetailGrid_DataSelect(object sender, EventArgs e)
        {
            Session["SubParentID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
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
            if (ASPxGridLookup1.Value == null  )
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
                ASPxGridView gv = sender as ASPxGridView;
                RefCompetencyService service = new RefCompetencyService();
                switch (e.ButtonID)
                {
                    // New item
                    case "New_1":
                    case "New_2":
                    case "New_3":
                        int competency_ID = int.Parse(gv.GetRowValues(e.VisibleIndex, "Competency_ID").ToString());
                        int period_ID = int.Parse(Session["PeriodID"].ToString());
                        service.InsertRef(competency_ID, period_ID);
                        gv.DataBind();
                        break;

                    // Delete item
                    case "Delete_1":
                    case "Delete_2":
                    case "Delete_3":
                        int ID = int.Parse(gv.GetRowValues(e.VisibleIndex, "ID").ToString());
                        service.DeleteByID(ID);
                        gv.DataBind();
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
            if (e.Column.FieldName.Equals("Type"))
            {
                object type = e.GetFieldValue("Type");

                if (type == null || type.ToString() == "")
                    e.DisplayText = GetGlobalResourceObject("KPI_RefCompetency", "typenull").ToString();
                else if ((bool)type)
                    e.DisplayText = GetGlobalResourceObject("KPI_RefCompetency", "typeYes").ToString();
                else
                    e.DisplayText = GetGlobalResourceObject("KPI_RefCompetency", "typeNo").ToString();
            }
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
                Session["PeriodID"] = HiddenField1.Value;
                btnSave.Enabled = true;
            }
            Load_RefKPI();
            grid.DataBind();
            grid.DetailRows.ExpandRow(0);
        }

        protected void grid_DetailRowGetButtonVisibility(object sender, ASPxGridViewDetailRowButtonEventArgs e)
        {
            if (e.VisibleIndex >= 0)
            {
                //if (grid.GetDataRow(e.VisibleIndex)["Counter"] == null ||
                //    grid.GetDataRow(e.VisibleIndex)["Counter"].ToString() == "")
                //    e.ButtonState = GridViewDetailRowButtonState.Hidden;
            }
        }

        protected void DetailOds_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            //if (Context.User.Identity.IsAuthenticated)
            {
                e.InputParameters["RefID"].ToString();
            }
        }

        protected void grid_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                ASPxGridView gv = sender as ASPxGridView;

                int id = int.Parse(e.Values["ID"].ToString());
                RefCompetencyService service = new RefCompetencyService();
                service.DeleteByID(id);

                gv.DataBind();
                e.Cancel = true;
            }
            catch (Exception ex)
            {

            }
        }

        protected void grid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {
                ASPxGridView gv = sender as ASPxGridView;

                //int id = int.Parse(e.NewValues["ID"].ToString());
                //RefCompetencyService service = new RefCompetencyService();
                //service.CreateNew(id);

                gv.DataBind();
                e.Cancel = true;
            }
            catch (Exception ex)
            {

            }
        }


        protected void grid_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
        {
            int index = e.VisibleIndex;
            ASPxGridView grid = sender as ASPxGridView;
            object id = grid.GetRowValues(index, "ID");
            switch (e.Text)
            {
                case "Delete":
                    if (id == null || id.ToString() == "")
                        e.Visible = DefaultBoolean.False;
                    else
                        e.Visible = DefaultBoolean.True;
                    break;
                case "Add":
                    if (id == null || id.ToString() == "")
                        e.Visible = DefaultBoolean.True;
                    else
                        e.Visible = DefaultBoolean.False;
                    break;
                default:
                    break;
            }
        }

    }
}