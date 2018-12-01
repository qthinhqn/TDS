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
using System.Collections.Specialized;

namespace PAOL.UserControl
{
    public partial class ucKPI_EmpKPI_Detail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["PeriodID"] = 1;
            //Session["EmployeeID"] = "HR021";
            if(!IsPostBack)
            {
                // kiem tra het han danh gia
                int kpiid = KPI_PeriodService.GetKPI_LastActive();
                tbl_KPI_Period objKPI = (new KPI_PeriodService()).GetObjectById(kpiid);

                if (DateTime.Now >= objKPI.StartTime && DateTime.Now < objKPI.ReviewTime)
                {
                    // cho edit
                }
                else
                {
                    // khong cho edit
                    grid.DataColumns["Score"].ReadOnly = true;
                }
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

                if (newValues["ID"] != null)
                {
                    int empKpi_detailid = Convert.ToInt32(newValues["ID"].ToString());
                    int period = int.Parse(Session["PeriodID"].ToString());
                    string EmployeeID = Session["EmployeeID"].ToString();
                    double rating = Convert.ToDouble(newValues["Important"]);
                    double important = (rating < 100 ? 0.0 : (rating > 150 ? 5 : 3 + (rating - 100) * (1.0 / 25.0)));
                    //double important = Convert.ToDouble(newValues["Important"]);
                    //double point = Convert.ToDouble(newValues["Score"]);

                    thucthi.UpdateRating(EmployeeID, period, empKpi_detailid, important, rating/100.0);
                }
                else
                {
                    int period = int.Parse(Session["PeriodID"].ToString());
                    int kpi_id = int.Parse(keys[0].ToString());
                    string EmployeeID = Session["EmployeeID"].ToString();
                    double rating = Convert.ToDouble(newValues["Important"]);
                    double important = (rating < 100 ? 0.0 : (rating > 150 ? 5 : 3 + (rating - 100) * (1.0 / 25.0)));
                    //double important = Convert.ToDouble(newValues["Important"]);
                    //double point = Convert.ToDouble(newValues["Score"]);

                    thucthi.CreateNew(EmployeeID, period, kpi_id, important, rating/100.0);
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