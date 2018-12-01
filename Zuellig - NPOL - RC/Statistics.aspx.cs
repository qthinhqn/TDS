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
    public partial class Statistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validate Page
            if (Session["EmployeeID"] == null || Session["Role"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                Khuong kh = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
                if (!kh.IsShowCheckedLevel3(Session["EmployeeID"].ToString()))
                {
                    Response.Redirect("~/Login.aspx");
                }
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

        
        protected void ddlPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Period_ID = int.Parse(ddlPeriod.SelectedValue.ToString());
                Session["Period_ID"] = Period_ID;
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