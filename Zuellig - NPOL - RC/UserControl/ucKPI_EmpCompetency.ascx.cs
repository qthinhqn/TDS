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
using System.Collections.Specialized;

namespace NPOL.UserControl
{
    public partial class ucKPI_EmpCompetency : System.Web.UI.UserControl
    {
        bool IsValid = false;
        private string v4Time { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            grid.JSProperties["cpIsUpdated"] = "";

            grid.DataBind();
            grid.DetailRows.ExpandAllRows();
            //if (message != null && message != "")
            {
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                v4Time = "";
            }
            if (!IsPostBack)
            {
                Session.Remove("ParentID");
                Session.Remove("SubParentID");

            }
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
            e.Column.ReadOnly = true;
            if (e.Column.FieldName == "Point")
            {
                decimal price = (decimal)e.GetListSourceFieldValue("Score");
                decimal quantity = (decimal)(e.GetListSourceFieldValue("Important"));
                e.Value = price * quantity;
            }
        }

        private void clearContent()
        {
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
                    //

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

        protected void grid_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            try
            {
                switch (e.ButtonID)
                {
                    // Edit item
                    case "Edit":
                        //HiddenField1.Value = grid.GetRowValues(e.VisibleIndex, "PosID").ToString();
                        //ASPxGridLookup1.Value = HiddenField1.Value;

                        break;

                    default:
                        break;
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
            }
        }

        protected void grid_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e)
        {
            try
            {
                // tuy chinh hien thi 
                object order = e.GetFieldValue("Order");
                object level = e.GetFieldValue("Level");

                if (e.Column.FieldName.Equals("Order"))
                {
                    if (order != null)
                    {
                        int i = (int)order;
                        if (level.ToString() == "1")
                        {
                            e.DisplayText = new NPOL.App_Code.Business.ToRomanNumber().ToRoman(i);
                        }
                        if (level.ToString() == "3")
                        {
                            e.DisplayText = i > 0 && i < 27 ? ((char)(i + 96)).ToString() + "." : null;
                        }
                    }
                }

                object Description = e.GetFieldValue("Description");
                object Description_eng = e.GetFieldValue("Description_eng");
                if (e.Column.FieldName.Equals("Description"))
                {
                    if (level != null)// && level.ToString() != "1")
                    {
                        //e.DisplayText = Description_eng + " / " + Description;
                        if (Session["lang"] == null || Session["lang"].ToString().ToLower() == "vi")
                        {
                            e.DisplayText = Description.ToString();
                        }
                        else
                        {
                            e.DisplayText = Description_eng.ToString();
                        }
                    }
                }
            }
            catch (Exception ex) { }					
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

        protected void gvDetail_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                UpdateItem(e.Keys, e.NewValues);
                //Hủy chức năng cập nhật tự động của SqlDatasource
                if (v4Time != null && v4Time != "")
                {
                    ((ASPxGridView)sender).JSProperties["cpIsUpdated"] = e.Keys[0];
                    ((ASPxGridView)sender).JSProperties["cpLang"] = Session["Lang"];
                    v4Time = null;
                }
                e.Cancel = true;

                var gridView = sender as ASPxGridView;
                //Thoát chế độ edit
                gridView.CancelEdit();

                //Cập nhật lại lưới
                LoadDetail(gridView);
            }
            catch (Exception ex)
            { }
        }


        protected void UpdateItem(OrderedDictionary keys, OrderedDictionary newValues)
        {
            try
            {
                EmpCompetency_DetailService thucthi = new EmpCompetency_DetailService();

                int competency_id = Convert.ToInt32(keys[0]);
                int period = int.Parse(Session["PeriodID"].ToString());
                string EmployeeID = Session["EmployeeID"].ToString();
                double important = Convert.ToDouble(newValues["Important"]);
                double point = Convert.ToDouble(newValues["Score"]);
                if (point > 10)
                    point = point / 10;

                if (thucthi.CountSameImportant(EmployeeID, period, competency_id, important) >= 4)
                {
                    v4Time = competency_id.ToString();
                }
                else
                {
                    thucthi.UpdateScore(EmployeeID, period, competency_id, point, important);
                }
            }
            catch (Exception ex)
            {
                string message = "alert('" + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
        }

        protected void detailGrid_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType == DevExpress.Web.GridViewRowType.Data)
            {
                e.Row.Height = Unit.Pixel(40);
            }
        }

        protected void detailGrid_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {
            if (e.Exception == null)
            {
                ((ASPxGridView)sender).JSProperties["cpIsUpdated"] = e.Keys[0];
            }
        }

        protected void detailGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            var gridView = sender as ASPxGridView;

            //foreach (var args in e.InsertValues)
            //    InsertNewItem(args.NewValues);
            foreach (var args in e.UpdateValues)
                UpdateItem(args.Keys, args.NewValues);
            //foreach (var args in e.DeleteValues)
            //    DeleteItem(args.Keys, args.Values);

            e.Handled = true;

            //Thoát chế độ edit
            gridView.CancelEdit();

            //Cập nhật lại lưới
            LoadDetail(gridView);
        }

        protected void detailGrid_Init(object sender, EventArgs e)
        {
            var gridView = sender as ASPxGridView;
            LoadDetail(gridView);
        }

        public void LoadDetail(ASPxGridView gridView)
        {
            try
            {
                int period = int.Parse(Session["PeriodID"].ToString());
                int parent = int.Parse(gridView.GetMasterRowKeyValue().ToString());
                string EmployeeID = Session["EmployeeID"].ToString();
                gridView.DataSource = NPOL.App_Code.Business.EmpCompetency_DetailService.GetDetailCompetency(period, parent, EmployeeID);
                gridView.DataBind();
                // kiem tra het han danh gia
                int kpiid = KPI_PeriodService.GetKPI_LastActive();
                tbl_KPI_Period objKPI = (new KPI_PeriodService()).GetObjectById(kpiid);
                // bo qua trong gia doan test
                
                if (DateTime.Now >= objKPI.StartTime && DateTime.Now < objKPI.ReviewTime_First)
                {
                    // cho edit
                }
                else
                {
                    // khong cho edit
                    gridView.DataColumns["Important"].ReadOnly = true;
                    gridView.DataColumns["Score"].ReadOnly = true;
                }
                 
            }
            catch (Exception ex)
            { }
        }
    }
}