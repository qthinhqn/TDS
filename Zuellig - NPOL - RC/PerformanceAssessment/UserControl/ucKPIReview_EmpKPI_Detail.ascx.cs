﻿using System;
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
using System.Collections.Specialized;

namespace PAOL.UserControl
{
    public partial class ucKPIReview_EmpKPI_Detail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
            }
            grid.DataBind();
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
        
        protected void grid_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            try
            {
                switch (e.ButtonID)
                {
                    // Edit item
                    case "Edit":
                        HiddenField1.Value = grid.GetRowValues(e.VisibleIndex, "EmpKPI_ID").ToString();
                        HiddenField2.Value = grid.GetRowValues(e.VisibleIndex, "ID").ToString();
                        
                        break;

                    case "Delete":
                        int ID = int.Parse(grid.GetRowValues(e.VisibleIndex, "ID").ToString());
                        EmpCompetency_DetailService service = new EmpCompetency_DetailService();
                        service.DeleteByID(ID);
                        grid.DataBind();
                        break;

                    default:
                        break;
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

            //object adj_Score = e.GetFieldValue("Adj_Score");
            //object adj_Important = e.GetFieldValue("Adj_Important");
            //object adj_Point = e.GetFieldValue("Adj_Point");
            //if (e.Column.FieldName.Equals("Score"))
            //{
            //    if (adj_Score != null && adj_Score.ToString() != "")
            //    {
            //        e.DisplayText = adj_Score.ToString();
            //    }
            //} if (e.Column.FieldName.Equals("Important"))
            //{
            //    if (adj_Important != null && adj_Important.ToString() != "")
            //    {
            //        e.DisplayText = adj_Important.ToString();
            //    }
            //} 
            //if (e.Column.FieldName.Equals("Point"))
            //{
            //    object adj_Point = e.GetFieldValue("Adj_Point");
            //    if (adj_Point != null && adj_Point.ToString() != "" && adj_Point.ToString() != "0")
            //    {
            //        e.DisplayText = adj_Point.ToString();
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
            HiddenField1.Value = "";
            HiddenField2.Value = "";
        }

        protected void btnBackward_Click(object sender, EventArgs e)
        {
            // Return back
            Session["Current"] = 1;
            Response.Redirect("~/SelfAssessmentHistory.aspx");
        }

        protected void btnForward_Click(object sender, EventArgs e)
        {
            // save data
            //try
            //{
            //    if (string.Compare(obj.Notes, MemoNote.Text) != 0)
            //    {
            //        obj.Notes = MemoNote.Text;
            //        obj.ID = int.Parse(HiddenField1.Value);
            //        service.UpdateNotes(obj);
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
            // Next step
            Session["Current"] = 3;
            Response.Redirect("~/SelfAssessmentHistory.aspx");
        }

        protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            UpdateItem(e.Keys, e.NewValues);

            //Hủy chức năng cập nhật tự động của SqlDatasource
            e.Cancel = true;
        }

        protected void UpdateItem(OrderedDictionary keys, OrderedDictionary newValues)
        {
            try
            {
                EmpKPI_DetailService thucthi = new EmpKPI_DetailService();

                
                {
                    int period = int.Parse(Session["PeriodID"].ToString());
                    int kpi_id = int.Parse(keys[0].ToString());
                    string EmployeeID = Session["EmployeeIDReview"].ToString();
                    double important = Convert.ToDouble(newValues["Weight"]);
                    double point = Convert.ToDouble(newValues["Adj_Score"]);
                    if (point > 10)
                        point = point / 10;

                    thucthi.UpdateAdj_Score(EmployeeID, period, kpi_id, point, important);
                }
            }
            catch (Exception ex)
            {
                string message = "alert('" + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
        }

        protected void grid_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType == DevExpress.Web.GridViewRowType.Data)
            {
                e.Row.Height = Unit.Pixel(40);
            }
        }
    }
}