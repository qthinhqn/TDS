using DevExpress.Web;
using NPOL.App_Code.Business;
using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NPOL.UserControl
{
    public partial class KPI_EmpList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Điền dữ liệu chu kỳ đánh giá
                LoadPeriod(Session["EmployeeID"].ToString());
                gvEmployee.DataBind();
                gvEmployee.DetailRows.ExpandRow(0);
            }
        }

        private void LoadPeriod(string EmployeeID)
        {
            try
            {
                DataTable dt = KPI_PeriodService.GetAllKPI_Year();

                ddlPeriod.DataSource = dt;
                ddlPeriod.DataTextField = "YearID";
                ddlPeriod.DataValueField = "YearID";
                ddlPeriod.DataBind();

                if (dt != null && dt.Rows.Count > 0)
                {
                    ddlPeriod.SelectedIndex = 0;
                    Session["YearID"] = ddlPeriod.SelectedValue;
                }
            }
            catch (Exception ex)
            { }
        }

        protected void ddlPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Chang Period_ID
            if (ddlPeriod.SelectedIndex >= 0)
            {
                Session["YearID"] = ddlPeriod.SelectedValue;
            }
            gvEmployee.DataBind();
        }

        protected void gvEmployee_SelectionChanged(object sender, EventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            Session["EmpID"] = grid.GetSelectedFieldValues(new string[] { "EmployeeID" });

        }
        protected void detailGrid_DataSelect(object sender, EventArgs e)
        {
            Session["EmpID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
            //(sender as ASPxGridView).DataBind();
        }

        protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
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
                    int YearID = int.Parse(Session["YearID"].ToString());
                    int KPI_ID = int.Parse(keys[0].ToString());
                    string EmployeeID = keys[1].ToString();
                    double weight = Convert.ToDouble(newValues["WeightDisplay"])/100.0;

                    thucthi.UpdateWeight(KPI_ID, EmployeeID, YearID, weight);
                }
            }
            catch (Exception ex)
            {
                string message = "alert('" + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
        }

    }
}