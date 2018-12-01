using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NPOL.Report;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using NPOL.App_Code.Business;
using DevExpress.Web;
using System.Collections.Specialized;
using DevExpress.XtraPrinting;
using DevExpress.Export;
using DevExpress.Web.ASPxTreeList;
using NPOL.App_Code.Entities;
using DevExpress.Utils;


namespace NPOL
{
    public partial class Ad_SummaryKPI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validate Page
            if (Session["EmployeeID"] == null || Session["Role"] == null || !Session["Role"].ToString().Equals("PA_Admin"))
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {

            }

            if (!IsPostBack)
            {
                //Điền dữ liệu chu kỳ đánh giá
                LoadPeriod(Session["EmployeeID"].ToString());
                ddlPeriod_SelectedIndexChanged(null, null);
            }
        }

        private void LoadPeriod(string EmployeeID)
        {
            try
            {
                DataTable dt = KPI_PeriodService.GetAllKPI_Period();

                ddlPeriod.DataSource = dt;
                ddlPeriod.DataTextField = "Name";
                ddlPeriod.DataValueField = "ID";
                ddlPeriod.DataBind();

                if (dt != null && dt.Rows.Count > 0)
                {
                    ddlPeriod.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            { }
        }

        protected void treeList_CustomCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomCallbackEventArgs e)
        {
            if (e.Argument.StartsWith("btnReassessment"))
            {
                String key = e.Argument.Split('|')[1];
			    TreeListNode node  = treeList.FindNodeByKeyValue(key);

			    object tmp = node.GetValue("ManagerID");
                string managerID = tmp.ToString().Split('_')[0];
                object ManagerName = node.GetValue("ManagerName");
                object LineName = node.GetValue("LineName");
                object DepName = node.GetValue("DepName");
                object TeamName = node.GetValue("TeamName");
            }
        }


        protected void treeList_NodeUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                // Save chu ky phu
                tblSubPeriod item = new tblSubPeriod();
                item.ManagerID = e.NewValues["ManagerID"].ToString();
                item.Period_ID = int.Parse(Session["Period_ID"].ToString());
                if (e.NewValues["FromDate"] != null)
                    item.FromDate = (DateTime)e.NewValues["FromDate"];
                if (e.NewValues["ToDate"] != null)
                    item.ToDate = (DateTime)e.NewValues["ToDate"];
                
                SubPeriodService.UpdateNews(item);
            }
            catch (Exception ex)
            { }
            e.Cancel = false;
        }

        protected void treeList_CommandColumnButtonInitialize(object sender, TreeListCommandColumnButtonEventArgs e)
        {
            //if (e.ButtonType != TreeListCommandColumnButtonType.Edit)
            {
                try
                {
                    int Period_ID = int.Parse(ddlPeriod.SelectedValue.ToString());
                    if (KPI_PeriodService.GetKPI_LastActive() != Period_ID)
                    {
                        //e.CommandColumn.EditButton.Visible = false;
                        e.Visible = DefaultBoolean.False;
                    }
                    else
                    {
                        e.CommandColumn.EditButton.Visible = true;
                    }
                }
                catch (Exception ex)
                { }
            }
        }

        protected void btnPublic_Click(object sender, EventArgs e)
        {
            try
            {
                // confirm public
                //string confirmValue = Request.Form["confirm_value"];
                //if (confirmValue == "Yes")
                {
                    int Period_ID = int.Parse(Session["Period_ID"].ToString());
                    if (KPI_PeriodService.GetKPI_LastActive() == Period_ID)
                    {
                        if (KPI_PeriodService.PublicPeriod(Period_ID))
                        {
                            Response.Redirect(Request.Url.AbsoluteUri);

                            string message = "alert('" + GetGlobalResourceObject("KPI_Summary", "alertSuscess").ToString() + "')";
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);

                            //Response.Redirect(Request.Url.AbsoluteUri);
                        }
                        else
                        {
                            string message = "alert('" + GetGlobalResourceObject("KPI_Summary", "alertFail").ToString() + "')";
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        protected void ddlPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Period_ID = int.Parse(ddlPeriod.SelectedValue.ToString());
                Session["Period_ID"] = Period_ID;
                if (KPI_PeriodService.GetKPI_LastActive() != Period_ID)
                {
                    btnPublic.Visible = false;
                }
            }
            catch (Exception ex)
            { }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                int Period_ID = int.Parse(Session["Period_ID"].ToString());
                if (KPI_PeriodService.GetKPI_LastActive() == Period_ID)
                {
                    KPI_PeriodService.UpdateIncentive(Period_ID);
                    gvReport.DataBind();
                }
            }
            catch(Exception ex)
            { }
        }

        #region Export tool
        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            try
            {
                gridExport.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnXlsxExport_Click(object sender, EventArgs e)
        {
            try
            {
                gridExport.WriteXlsxToResponse(new XlsxExportOptionsEx { ExportType = ExportType.WYSIWYG });
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }       
}