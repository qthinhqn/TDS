using DevExpress.Web;
using NPOL.App_Code.Business;
using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NPOL.UserControl
{
    public partial class uc_ManagerEmpGroup_RC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] != "RC_Admin")
            { 

            }
            //gridOTList.DataBind();
            //Session["RepresentativeID"] = "HR021";
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
            if (gridOTList.GetSelectedFieldValues("EmployeeID").Count <= 0)
            {
                string message = "alert('Vui lòng chọn nhân viên đại diện')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                return;
            }
            if (gvEmployee.GetSelectedFieldValues("EmployeeID").Count <= 0)
            {
                string message = "alert('Vui lòng chọn nhân viên cần phân bổ')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                return;
            }

            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
                //Xử lý sao chép
                foreach (object item in selectedEmployeeID)
                {
                    //object[] arr = item as object[];
                    //object empid = arr[0];
                    provider.CommandText = "spRecruit_InsertEmpGroup";
                    provider.CommandType = System.Data.CommandType.StoredProcedure;
                    provider.ParameterCollection = new string[] { "@RepresentativeID", "@EmployeeID" };
                    if (item.ToString().Equals(""))
                    {
                        return;
                    }
                    else
                    {
                        provider.ValueCollection = new object[] { Session["RepresentativeID"], item };
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
            selectedKPI = grid.GetSelectedFieldValues(new string[] { "EmployeeID" });
            Session["RepresentativeID"] = selectedKPI[0];
            LoadEmpList(Session["RepresentativeID"].ToString());
        }
        protected void gridKPIList_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["RepresentativeID"] = (sender as DevExpress.Web.ASPxGridView).GetMasterRowKeyValue();
        }

        protected void gridKPIList_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {
        }

        protected void gridKPIList_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {

        }
    }
}