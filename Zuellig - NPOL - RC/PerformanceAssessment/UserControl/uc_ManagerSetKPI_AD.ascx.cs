using DevExpress.Web;
using PAOL.App_Code.Business;
using PAOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAOL.UserControl
{
    public partial class uc_ManagerSetKPI_AD : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Params["KPI_ID"]))
            {
                Session["KPI_ID"] = Request.Params["KPI_ID"];
                LoadEmpList(Request.Params["KPI_ID"]);
            }
            try
            {
                if (Session["Role"] != "PA_Admin")
                {
                    object refUrl = ViewState["RefUrl"];
                    if (refUrl != null)
                        Response.Redirect((string)refUrl);
                }
            }
            catch (Exception ex)
            {
            
            }
        }

        private void LoadEmpList(string p)
        {
            gvEmployee.DataBind();
            gvTrainLine.DataBind();
        }

        static List<object> selectedKPI = new List<object>();
        static List<object> selectedEmployeeID = new List<object>();
        protected void gvEmployee_SelectionChanged(object sender, EventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            selectedEmployeeID.Clear();
            selectedEmployeeID = grid.GetSelectedFieldValues(new string[] { "EmployeeID" });
        }

        protected void gvTrainLine_RowDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {
            gvEmployee.DataBind();
        }

        protected void gvTrainLine_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            //if (gridKPIList.GetSelectedFieldValues("ID").Count <= 0)
            //{
            //    string message = "alert('Vui lòng chọn chỉ tiêu cần phân bổ nhân viên')";
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            //    return;
            //}
            if (gvEmployee.GetSelectedFieldValues("EmployeeID").Count <= 0)
            {
                string message = "alert('Vui lòng chọn nhân viên cần phân bổ')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                return;
            }

            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligPAConnection"].ConnectionString);
                //Xử lý sao chép
                foreach (object item in selectedEmployeeID)
                {
                    //object[] arr = item as object[];
                    //object empid = arr[0];
                    provider.CommandText = "spKPI_InsertDonebyList";
                    provider.CommandType = System.Data.CommandType.StoredProcedure;
                    provider.ParameterCollection = new string[] { "@KPI_ID", "EmployeeID" };
                    if (item.ToString().Equals(""))
                    {
                        return;
                    }
                    else
                    {
                        provider.ValueCollection = new object[] { Session["KPI_ID"], item };
                    }
                    provider.ExecuteNonQuery();
                }
                provider.CloseConnection();
                gvEmployee.Selection.UnselectAll();
                gvTrainLine.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + ex.Message + "')", true);
            }
        }

        protected void gridKPIList_SelectionChanged(object sender, EventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            selectedKPI.Clear();
            selectedKPI = grid.GetSelectedFieldValues(new string[] { "ID" });
            Session["KPI_ID"] = selectedKPI[0];
            LoadEmpList(Session["KPI_ID"].ToString());
        }
        protected void gridKPIList_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["KPI_ID"] = (sender as DevExpress.Web.ASPxGridView).GetMasterRowKeyValue();
        }

        protected void gridKPIList_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {
        }

        protected void gridKPIList_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // Show popup add Doneby list
            ASPxButton bt = sender as ASPxButton;
            GridViewDataItemTemplateContainer container = bt.NamingContainer as GridViewDataItemTemplateContainer;
            ASPxGridView grid = container.Grid;
            object kpiid = grid.GetRowValues(container.VisibleIndex, new string[] { "ID" });

            //Xử lý giá trị biến
            kpiid = (kpiid == null ? DBNull.Value : kpiid);

            //Gán dữ liệu vào Popup control
            ASPxPopupControl1.ShowOnPageLoad = true;
            //gvEmployee.DataSource = OT_DataDetailService.GetTableByid((int)kpid);
            Session["KPI_ID"] = kpiid;
            gvEmployee.DataBind();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            // Show popup view Doneby list
            ASPxButton bt = sender as ASPxButton;
            GridViewDataItemTemplateContainer container = bt.NamingContainer as GridViewDataItemTemplateContainer;
            ASPxGridView grid = container.Grid;
            object kpiid = grid.GetRowValues(container.VisibleIndex, new string[] { "ID" });

            //Xử lý giá trị biến
            kpiid = (kpiid == null ? DBNull.Value : kpiid);

            //Gán dữ liệu vào Popup control
            ASPxPopupControl1.ShowOnPageLoad = true;
            //gvEmployee.DataSource = OT_DataDetailService.GetTableByid((int)kpid);
            Session["KPI_ID"] = kpiid;
            gvTrainLine.DataBind();
            gvEmployee.DataBind();
        }

        protected void ASPxGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}